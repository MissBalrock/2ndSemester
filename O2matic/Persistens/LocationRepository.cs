using O2matic.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace O2matic.Persistens
{
    public class LocationRepository
    {
        private List<Location> locations = new List<Location>();

        public LocationRepository()
        {
            InitializeRepository();
        }
        private void InitializeRepository()
        {
            try
            {
                using (StreamReader sr = new StreamReader("Location.csv"))
                {
                    String line = sr.ReadLine();
                    while (line != null)
                    {
                        string[] parts = line.Split(' ');

                        this.Add(parts[0], parts[1], int.Parse(parts[2]), int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]);
                        line = sr.ReadLine();
                    }
                }
            }
            catch (IOException)
            {
                throw;
            }
        }
        public Location Add(string address, string title, int equiptmentId, int bussinestripId, int customerId, int orderId, int stockId)
        {
            Equipment result = null;

            if (!string.IsNullOrEmpty(address) &&
                !string.IsNullOrEmpty(title) &&
                equiptmentId >= 0 &&
                bussinestripId >= 0 &&
                customerId >= &&
                orderId >= &&
                stockId >=)
            {
                result = new Location()
                {
                    Address = address,
                    Title = title,
                    EquiptmentId = equiptmentId,
                    BussinestripId = bussinestripId,
                    CustomerId = customerId,
                    OrderId = orderId,
                    StockId = stockId
                };
                equiptments.Add(result);
            }
            else
                throw (new ArgumentException("not all arguments are Valid"));
            return result;
        }
        public Location Get(int Id)
        {
            Location locations = null;

            foreach (Location l in locations)
            {
                if (l.Id == Id)
                {
                    result = l;
                    break;
                }
            }
            return result;
        }
        public List<Location> GetAll()
        {
            return locations;
        }
        public void Update(string address, string title, int equiptmentId, int bussinestripId, int customerId, int orderId, int stockId)
        {
            Location foundLocation = this.Get(Id);

            if (foundLocation != null)
            {
                if (!string.IsNullOrEmpty(address) &&
                    !string.IsNullOrEmpty(title) &&
                    equiptmentId > 0 &&
                    bussinestripId > 0 &&
                    customerId > 0 &&
                    orderId > 0 &&
                    stockId > 0 &&)
                {
                    if (foundLocation.Address != address)
                        foundLocation.Address = address;
                    if (foundLocation.Title != title)
                        foundLocation.Title = title;
                    if (foundLocation.EquiptmentId != equiptmentId)
                        foundLocation.EquiptmentId = equiptmentId;
                    if (foundLocation.BussinestripId != bussinestripId)
                        foundLocation.BussinestripId = bussinestripId;
                    if (foundLocation.CustomerId != customerId)
                        foundLocation.CustomerId = customerId;
                    if (foundLocation.OrderId != orderId)
                        foundLocation.OrderId = orderId;
                    if (foundLocation.StockId != stockId)
                        foundLocation.StockId = stockId;
                }
                else
                    throw (new ArgumentException("Not all arguments for locations are valid"));
            }
            else
                throw new ArgumentException("Location with id = " + Id + " not found"));
        }
        public void Remove(int Id)
        {
            Location foundLocation = this.Get(Id);
            if (foundLocation != null)
                locations.Remove(foundLocation);
            else
                throw (new ArgumentException("Equiptment with id = " + Id + "not found"));
        }
    }
}
