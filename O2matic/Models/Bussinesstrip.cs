using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2matic.Models
{
    public class Bussinestrip
    {
        public string Purpose { get; set; }
        public DateTime Date { get; set; }
        public int EquiptmentId { get; set; }
        public string Location { get; set; }

        public Bussinestrip(string purpose, DateTime date, int equiptmentId, string location)
        {
            Purpose = purpose;
            Date = date;    
            EquiptmentId = equiptmentId;    
            Location = location;    
        }
    }
}
