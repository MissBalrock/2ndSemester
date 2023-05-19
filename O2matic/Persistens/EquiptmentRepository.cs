using O2matic.Model;
using O2matic.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace O2matic.Persistens
{
    public class EquiptmentRepository : IDisposable // Idispoddableinterfacet  lukker connection til database, så databasen ikke står åben til sidst. EquiptmentRepository har implemeteret Idisposabel
    {
        public SqlConnection Connection { get; private set; } // hentes fra MIckrosoft.Data.SqlClient, som er et bibliotek
        public EquiptmentRepository()
        {
            var dataSource = "(local)\\SQLEXPRESS"; // en variabel, der er adressen til databasen.
            var initialCatalog = "O2maticDevelopment"; // navnet på databasen

            var connectionString = $"Data Source={dataSource};Initial Catalog={initialCatalog};Integrated Security=True;TrustServerCertificate=True"; //Connectionstring er hele stien til at finde ind til databasen
            Connection = new SqlConnection(connectionString); //tager variablen connectionstring og instatiere den. 
            Connection.Open(); // databasen er nu åben
        }

        public void Save(Equipment equipment) // 
        {
            // man kan inkapsle det i en using, da den ´nedarver fra en klasse som immplemetere Idisposable
            var commandString = "INSERT INTO Equipment (EquipmentTypeID, SerialNumber, RegistrationDate, LocationID) " + // $= streng interpulation // Equiptment = tabel navnet på databasemn.// f.eks. serialnumber er navnet på en kolonne i databasen.
                $"VALUES ({equipment.EquipmentTypeId}, '{equipment.SerialNumber}', {DateTime.Now}, {equipment.LocationId});"; // Values funktion definerer veriderne i databasen for kolonnerne. // .=henter property fra model klassen.
            var command = new SqlCommand(commandString, Connection); // nu bliver SqlCommand istansieret og kommer ind i databasen.

            command.ExecuteReader().Close(); //lukker connection til databsen/table.  
        }

        public Equipment? Get(int id) // returnere det udstyr du leder efter, ved at søge efter ID. // der mangler en objekt reference, som kan være null, for at tjekke om man har en værdi som reference.
        {
            var commandString = $"SELECT * FROM dbo.Equipment WHERE ID = {id}"; // {id} = kommer fra Equiptment model klassen. // Det med "rødt" er syntaksten fra databasen // *= bruges, fordi vores table er lille, og alle vores kollene navne skal bruges. 
            var command = new SqlCommand(commandString, Connection); // nu bliver SqlCommand instiansieret og der er nu en connection til databasen, hvor udstyr bliver hentet via Id. 

            using (var reader = command.ExecuteReader()) // ExecuteReader læser data fra databasen. implementere Idisposabel, elles kan det ikke bruges. 
            {
                while (reader.Read()) // så længe metoden ExecuteReader metoden er igang med at læse
                {

                    var dateString = reader[3].ToString();
                    var registrationDate = DateTime.UnixEpoch;
                    if (dateString != null)
                        registrationDate = DateTime.Parse(dateString); // tjekekr om registration date er = null. // Dette har vi valgt at gøre, for at der ikke kan opstå en fejl.

                    var result = new Equipment(
                        id: Convert.ToInt32(reader[0].ToString()),
                        equipmentTypeId: Convert.ToInt32(reader[1].ToString()),
                        serialNumber: Convert.ToInt32(reader[2].ToString()),
                        registrationDate: registrationDate,
                        locationId: Convert.ToInt32(reader[4].ToString())
                        //Device status
                        );
                    return result;
                }
            }
            return null;
        }

        public ICollection<Equipment> GetAll()
        {
            var commandString = $"SELECT * FROM dbo.Equipment";
            var command = new SqlCommand(commandString, Connection);

            var result = new List<Equipment>();

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var dateString = reader[3].ToString();
                    var registrationDate = DateTime.UnixEpoch;
                    if (dateString != null)
                        registrationDate = DateTime.Parse(dateString);

                    result.Add(new Equipment(
                        id: Convert.ToInt32(reader[0].ToString()),
                        equipmentTypeId: Convert.ToInt32(reader[1].ToString()),
                        serialNumber: Convert.ToInt32(reader[2].ToString()),
                        registrationDate: registrationDate,
                        locationId: Convert.ToInt32(reader[4].ToString())
                        ));
                }
            }
            return result;
        }

        public bool Update(Equipment equipment)
        {

            var existing = Get(equipment.Id);

            if (existing == null)
                return false;

            var commandString = "UPDATE Equipment" +
                 $"SET EquipmentTypeID = {equipment.EquipmentTypeId}, SerialNumber = {equipment.SerialNumber}, LocationID = {equipment.LocationId}" +
                 $"WHERE ID = {equipment.Id};";
            var command = new SqlCommand(commandString, Connection);
            command.ExecuteReader().Close();

            return true;
        }

        public void Dispose()
        {
            Connection.Close();
        }
    }
}
