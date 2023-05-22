using O2maticTracking.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2maticTracking.Repositories
{
    public class O2maticRepo : IDisposable
    {
        public SqlConnection Connection { get; private set; }
        public O2maticRepo()
        {
            string dataSource = "(local)\\SQLEXPRESS";
            string initialCatalog = "O2maticDb";

            string connectionString = $"Data Source={dataSource};Initial Catalog={initialCatalog};Integrated Security=True;TrustServerCertificate=True";
            Connection = new SqlConnection(connectionString);
            Connection.Open();
        }

        public void Save(Equipment equipment)
        {

            string commandString = "INSERT INTO Equipment (EquipmentTypeID, SerialNumber, RegistrationDate, LocationID) " +
                $"VALUES ({equipment.EquipmentTypeId}, '{equipment.SerialNumber}', {DateTime.Now}, {equipment.LocationId});";
            SqlCommand command = new SqlCommand(commandString, Connection);

            command.ExecuteReader().Close();
        }

        public Equipment? Get(int id)
        {
            string commandString = $"SELECT * FROM dbo.Equipment WHERE ID = {id};";
            SqlCommand command = new SqlCommand(commandString, Connection);

            Equipment? result = null;

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    // TODO:  Correct datetime reading.
                     
                    string? dateString = reader[3].ToString();
                    DateTime registrationDate = DateTime.UnixEpoch;
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
            string commandString = $"SELECT * FROM dbo.Equipment";
            SqlCommand command = new SqlCommand(commandString, Connection);

            List<Equipment> result = new List<Equipment>();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string dateString = reader[3].ToString();
                    DateTime registrationDate = DateTime.UnixEpoch;
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

        public EquipmentType? GetEquipmentType(int id)
        {
            string commandString = $"SELECT * FROM dbo.EquipmentType WHERE ID = {id};";
            SqlCommand command = new SqlCommand(commandString, Connection);

            EquipmentType? result = null;

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {

                    string? name = reader[1].ToString();

                    if (name == null)
                        name = "n/a";

                    result = new EquipmentType(
                        id: Convert.ToInt32(reader[0].ToString()),
                        name: name
                        );
                }
            }
            return result;
        }

        public bool Update(Equipment equipment)
        {

            Equipment? existing = Get(equipment.Id);

            if (existing == null)
                return false;

            string commandString = "UPDATE Equipment" +
                 $"SET EquipmentTypeID = {equipment.EquipmentTypeId}, SerialNumber = {equipment.SerialNumber}, LocationID = {equipment.LocationId}" +
                 $"WHERE ID = {equipment.Id};";
            SqlCommand command = new SqlCommand(commandString, Connection);
            command.ExecuteReader().Close();

            return true;
        }

        public void Dispose()
        {
            Connection.Close();
        }
    }
}
