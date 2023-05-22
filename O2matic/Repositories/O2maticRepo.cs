using O2maticTracking.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2maticTracking.Repositories
{
    public class EquiptmentRepository : IDisposable
    {
        public SqlConnection Connection { get; private set; }
        public EquiptmentRepository()
        {
            var dataSource = "(local)\\SQLEXPRESS";
            var initialCatalog = "O2maticDb";

            var connectionString = $"Data Source={dataSource};Initial Catalog={initialCatalog};Integrated Security=True;TrustServerCertificate=True";
            Connection = new SqlConnection(connectionString);
            Connection.Open();
        }

        public void Save(Equipment equipment)
        {

            var commandString = "INSERT INTO Equipment (EquipmentTypeID, SerialNumber, RegistrationDate, LocationID) " +
                $"VALUES ({equipment.EquipmentTypeId}, '{equipment.SerialNumber}', {DateTime.Now}, {equipment.LocationId});";
            var command = new SqlCommand(commandString, Connection);

            command.ExecuteReader().Close();
        }

        public Equipment? Get(int id)
        {
            var commandString = $"SELECT * FROM dbo.Equipment WHERE ID = {id};";
            var command = new SqlCommand(commandString, Connection);

            Equipment? result = null;

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    // TODO:  Correct datetime reading.
                     
                    var dateString = reader[3].ToString();
                    var registrationDate = DateTime.UnixEpoch;
                    if (dateString != null)
                        registrationDate = DateTime.Parse(dateString);
                    
                   // DateTime registrationDate = DateTime.UtcNow; //tager tiden den bliver hentet! Tid er det væreste!!!

                    result = new Equipment(
                        id: Convert.ToInt32(reader[0].ToString()),
                        equipmentTypeId: Convert.ToInt32(reader[1].ToString()),
                        serialNumber: Convert.ToInt32(reader[2].ToString()),
                        registrationDate: registrationDate,
                        locationId: Convert.ToInt32(reader[4].ToString())
                        );
                }
            }
            return result;
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
