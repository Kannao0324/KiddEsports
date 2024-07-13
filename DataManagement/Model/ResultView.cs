using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagement.Model
{
    // Class object for viewing results
    public class ResultView
    {
        public int Id { get; set; }
        public string EventHeld { get; set; } = string.Empty;
        public string GamePlayed { get; set; } = string.Empty;
        public string Team1 { get; set; } = string.Empty;
        public string Team2 { get; set; } = string.Empty;
        public string Result { get; set; } = string.Empty;
    }
}
