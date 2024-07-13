using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagement.Model
{
    // Class object for Team details
     public class Teams
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PrimaryContact { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int CompPoints { get; set; }


        public Teams()
        {

        }

        public Teams(int id, string name, string contact,string phone,string email, int compPoints)
        {
            Id = id;
            Name = name;
            PrimaryContact = contact;
            Phone = phone;
            Email = email;
            CompPoints = compPoints;
        }

    }
}
