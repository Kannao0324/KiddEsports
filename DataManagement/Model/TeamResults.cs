namespace DataManagement.Model
{
    // Class object for team results
    public class TeamResults
    {
        public int Id { get; set; }
        public int EventHeldId { get; set; }
        public int GamePlayedId { get; set; }
        public int Team1Id { get; set; }
        public int Team2Id { get; set; }
        public string Result { get; set; } = string.Empty;


        public TeamResults()
        {

        }

        public TeamResults(int id, int eventHeldId, int gamePlayedId, int team1Id, int team2Id, string result)
        {
            Id = id;
            EventHeldId = eventHeldId;
            GamePlayedId= gamePlayedId;
            Team1Id = team1Id;
            Team2Id = team2Id;
            Result = result;
        }
    }

}
