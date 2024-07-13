using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagement.Model
{
    // Class object for Game details
    public class GamePlayed
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string GameType { get; set; } = string.Empty;


        public GamePlayed()
        {

        }

        public GamePlayed(int id,string name,string gameType)
        {
            Id = id;
            Name = name;
            GameType = gameType;
        }
    }
}
