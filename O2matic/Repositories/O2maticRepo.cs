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

        public ICollection<EquipmentType> GetEquipmentTypes()
        {
            string commandString = $"SELECT * FROM dbo.EquipmentType";
            SqlCommand command = new SqlCommand(commandString, Connection);

            List<EquipmentType> result = new List<EquipmentType>();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string? name = reader[1].ToString();

                    if (name == null)
                        name = "n/a";

                        result.Add(new EquipmentType(
                        id: Convert.ToInt32(reader[0].ToString()),
                        name: name
                        ));
                }
            }
            return result;
        }

        public Location? GetLocation(int id)
        {
            string commandString = $"SELECT * FROM dbo.Location WHERE ID = {id};";
            SqlCommand command = new SqlCommand(commandString, Connection);

            Location? result = null;

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {

                    string? name = reader[2].ToString();

                    if (name == null)
                        name = "n/a";

                    result = new Location(
                        id: Convert.ToInt32(reader[0].ToString()),
                        addressId: Convert.ToInt32(reader[1].ToString()),
                        name: name
                        );
                }
            }

            return result;
        }

        public ICollection<Location> GetLocations()
        {
            string commandString = $"SELECT * FROM dbo.Location";
            SqlCommand command = new SqlCommand(commandString, Connection);

            List<Location> result = new List<Location>();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string? name = reader[2].ToString();

                    if (name == null)
                        name = "n/a";

                    result.Add(new Location(
                    id: Convert.ToInt32(reader[0].ToString()),
                    addressId: Convert.ToInt32(reader[1].ToString()),
                    name: name
                    ));
                }
            }
            return result;
        }


        public Address? GetAddress(int id)
        {
            string commandString = $"SELECT * FROM dbo.Address WHERE ID = {id};";
            SqlCommand command = new SqlCommand(commandString, Connection);

            Address? result = null;

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string? addressLine1 = reader[1].ToString();
                    string? addressLine2 = reader[2].ToString();
                    string? postalCode = reader[3].ToString();
                    string? countryCode = reader[4].ToString();

                    if (addressLine1 == null)
                        addressLine1 = "n/a";
                    if (addressLine2 == null)
                        addressLine2 = "n/a";
                    if (postalCode == null)
                        postalCode = "n/a";
                    if (countryCode == null)
                        countryCode = "n/a";

                    result = new Address(
                        id: Convert.ToInt32(reader[0].ToString()),
                        addressLine1: addressLine1,
                        addressLine2: addressLine2,
                        postalCode: postalCode,
                        countryCode: countryCode
                        );
                }
            }
            return result;
        }

        public ICollection<Address> GetAddresses()
        {
            string commandString = $"SELECT * FROM dbo.Address";
            SqlCommand command = new SqlCommand(commandString, Connection);

            List<Address> result = new List<Address>();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string? addressLine1 = reader[1].ToString();
                    string? addressLine2 = reader[2].ToString();
                    string? postalCode = reader[3].ToString();
                    string? countryCode = reader[4].ToString();

                    if (addressLine1 == null)
                        addressLine1 = "n/a";
                    if (addressLine2 == null)
                        addressLine2 = "n/a";
                    if (postalCode == null)
                        postalCode = "n/a";
                    if (countryCode == null)
                        countryCode = "n/a";

                    result.Add(new Address(
                    id: Convert.ToInt32(reader[0].ToString()),
                        addressLine1: addressLine1,
                        addressLine2: addressLine2,
                        postalCode: postalCode,
                        countryCode: countryCode
                    ));
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
