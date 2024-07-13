using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagement.Model
{
    // Class object for Event details
    public class Events
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime Date { get; set; }

        public Events()
        {

        }

        public Events(int id, string name, string location, DateTime date)
        {
            Id = id;
            Name = name;
            Location = location;
            Date = date;
        }

    }
}
