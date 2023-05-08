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
    public class BussinesstripRepository
    {
        private List<Bussinesstrip> Bussinesstrips = new List<Bussinesstrip>();

        public BussinesstripRepository()
        {
            InitializeRepository();
        }
        private void InitializeRepository()
        {
            try
            {
                using (StreamReader sr = new StreamReader("Bussinesstrip.csv"))
                {
                    String line = sr.ReadLine();
                    while (line != null)
                    {
                        string[] parts = line.Split(' ');

                        this.Add(parts[0], DateTime.Parse(parts[1], int.Parse(parts[2]), parts[3]);
                        line = sr.ReadLine();
                    }
                }
            }
            catch (IOException)
            {
                throw;
            }
        }
        public Bussinesstrip Add(string purpose, DateTime date, int equiptmentId, string location)
        {
             result = null;

            if (!string.IsNullOrEmpty(purpose) &&
                !DateTime.IsNullOrEmpty(date) &&
                equiptmentId >= 0 &&
                location >= 0)
            {
                result = new Bussinesstrip()
                {
                    Purpose = purpose,
                    Date = date,
                    EquiptmentId = equiptmentId,
                    Location = location
                };
                bussinesstrips.Add(result);
            }
            else
                throw (new ArgumentException("not all arguments are Valid"));
            return result;
        }
        public Bussinesstrip Get(int Id)
        {
            Bussinesstrip bussinesstrips = null;

            foreach (Bussinesstrip b in bussinesstrips)
            {
                if (b.Id == Id)
                {
                    result = b;
                    break;
                }
            }
            return result;
        }
        public List<Bussinesstrip> GetAll()
        {
            return Bussinesstrips;
        }
        public void Update(string purpose, DateTime date, int equiptmentId, string location)
        {
            Bussinesstrip foundBussinesstrip = this.Get(Id);

            if (foundBussinesstrip != null)
            {
                if (!string.IsNullOrEmpty(purpose) &&
                    !DateTime.IsNullOrEmpty(date) &&
                    equiptmentId > 0 &&
                    !string.IsNullOrEmpty(location))
                {
                    if (foundBussinesstrip.Purpose != purpose)
                        foundBussinesstrip.Purpose = purpose;
                    if (foundBussinesstrip.Date != date)
                        foundBussinesstrip.Date = date;
                    if (foundBussinesstrip.EquiptmentId != equiptmentId)
                        foundBussinesstrip.EquiptmentId = equiptmentId;
                    if (foundBussinesstrip.Location != location)
                        foundBussinesstrip.Location = location;

                }
                else
                    throw (new ArgumentException("Not all arguments for bussinesstrip are valid"));
            }
            else
                throw new ArgumentException("Bussinesstrip with id = " + Id + " not found"));
        }
        public void Remove(int Id)
        {
            Bussinesstrip foundBussinesstrip = this.Get(Id);
            if (foundBussinesstrip != null)
                Bussinesstrips.Remove(foundBussinesstrip);
            else
                throw (new ArgumentException("Bussinesstrip with Id = " + Id + "not found"));
        }
    }
}
