using O2matic.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace O2matic.Persistens
{
    public class EquiptmentRepository
    {
        private List<Equiptment> equiptments = new List<Equiptment>();

        public Equiptment result { get; private set; }

        public EquiptmentRepository()
        {
            InitializeRepository();
        }
        private void InitializeRepository()
        {
            try
            {
                using (StreamReader sr = new StreamReader("Equiptment.csv"))
                {
                    String line = sr.ReadLine();
                    while (line != null)
                    {
                        string[] parts = line.Split(' ');

                        this.Add(parts[0], int.Parse(parts[1]), int.Parse(parts[2]));
                        line = sr.ReadLine();
                    }
                }
            }
            catch (IOException)
            {
                throw;
            }
        }
        public Equiptment Add(string equiptmentType, int serialNumber, int id)
        {
            Equiptment result = null;

            if (!string.IsNullOrEmpty(equiptmentType) &&
                serialNumber >= 0 &&
                id >= 0)
            {
                result = new Equiptment()
                {
                    EquiptmentType = equiptmentType,
                    SerialNumber = serialNumber,
                    Id = id
                };
                equiptments.Add(result);
            }
            else
                throw (new ArgumentException("not all arguments are Valid"));
            return result;
        }
        public Equiptment Get(int id)
        {
            Equiptment equiptment = null;

            foreach(Equiptment e in equiptments)
            {
                if(e.Id == id)
                { 
                    result = e;
                    break;
                }
            }
            return result;
        }
        public List<Equiptment> GetAll()
        {
            return equiptments;
        }
        public void Update(string equiptmentType, int serialNumber, int id)
        {
            Equiptment foundEquiptment = this.Get(id);

            if(foundEquiptment != null)
            {
                if (!string.IsNullOrEmpty(equiptmentType) &&
                    serialNumber <= 0)
                {
                    if (foundEquiptment.EquiptmentType != equiptmentType)
                        foundEquiptment.EquiptmentType = equiptmentType;
                    if (foundEquiptment.SerialNumber != serialNumber)
                        foundEquiptment.SerialNumber = serialNumber;
                }
                else
                    throw (new ArgumentException("Not all arguments for equiptment are valid"));
            }
            else
                throw new ArgumentException("Equiptment with id = " +id + " not found");
        }
        public void Remove(int id)
        {
            Equiptment foundEquiptment = this.Get(id);
            if (foundEquiptment != null)
                equiptments.Remove(foundEquiptment);
            else
                throw (new ArgumentException("Equiptment with id = " + id + "not found"));
        }
    }
}
