using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2matic.Models
{
    public class Employee
    {
        public string Name { get; set; }
        public string JobTitle { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public int CPRNumber { get; set; }
        public string Email { get; set; }

        public Employee(string name, string jobTitle, int phoneNumber, string address, int cPRNumber, string email)
        {
            Name = name;
            JobTitle = jobTitle;
            PhoneNumber = phoneNumber;
            Address = address;
            CPRNumber = cPRNumber;
            Email = email;
        }   
    }
}
