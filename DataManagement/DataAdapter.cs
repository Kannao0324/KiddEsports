using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManagement.Model;
using Dapper;
using System.Formats.Tar;
using System.Data;
using System.Data.SqlClient;

namespace DataManagement
{
    public class DataAdapter
    {
        #region Teams

        /// <summary>
        /// Retrieves all team records from the database
        ///</summary>
        /// <returns>A list of team records</returns>
        public List<Teams> GetAllTeams()
        {
            try
            {
                //The query to be passsed to the databse to be executed.
                string query = "SELECT * FROM Teams";
                //The using statement which manages our connection and disposes of it
                //once the request is compelted.
                using (var connection = Helper.CreateSQLServerConnection("Default"))
                {
                    //The request/command method being executed by Dapper to perform the
                    //SQL query.
                    return connection.Query<Teams>(query).ToList();
                }
            }
            catch(Exception e)
            {
                //Returns an empty record if the quey fails.
                return new List<Teams>();
            }
        }

        /// <summary>
        /// Retrieves a team record from the database based upon a given id(Primary Key).
        /// </summary>
        /// <param name="id">The Id number of the record to be retrieved</param>
        /// <returns>A team model representing a single DB record.</returns>
        public Teams GetTeamById(int id)
        {
            try { 
            //The query to be passsed to the databse to be executed.
            string query = "SELECT * FROM Teams " +
                           $"WHERE Id = {id}";
            //The using statement which manages our connection and disposes of it
            //once the request is compelted.
            using (var connection = Helper.CreateSQLServerConnection("Default"))
            {
                //The request/command method being executed by Dapper to perform the
                //SQL query.
                return connection.QuerySingle<Teams>(query);
            }
            }
            catch(Exception e)
            {
                //Returns an empty record if the quey fails.
                return new Teams();
            }
        }

        /// <summary>
        /// Retrieves a team record from the database based on team name.
        /// </summary>
        /// <param name="name">The Id number of the record to be retrieved</param>
        /// <returns>A team model representing a single DB record.</returns>
        public Teams GetTeamByName(string name)
        {
            try
            {
                //The query to be passsed to the databse to be executed.
                string query = "SELECT * FROM Teams " +
                               $"WHERE Name = '{name}'";
                //The using statement which manages our connection and disposes of it
                //once the request is compelted.
                using (var connection = Helper.CreateSQLServerConnection("Default"))
                {
                    //The request/command method being executed by Dapper to perform the
                    //SQL query.
                    return connection.QuerySingle<Teams>(query);
                }
            }
            catch (Exception e)
            {
                //Returns an empty record if the quey fails.
                return new Teams();
            }
        }

        /// <summary>
        /// Search team records by Team names to the database based upon the provided data model.
        ///</summary>
        /// <param name="name">The data model holding the details to be stored in the database</param>
        public List<Teams> SearchTeamByName(string name)
        {
            try
            {
                //The query to be passsed to the databse to be executed.
                string query = "SELECT * FROM Teams " +
                           $"WHERE Name LIKE '%{name}%'";
                //The using statement which manages our connection and disposes of it
                //once the request is compelted.
                using (var connection = Helper.CreateSQLServerConnection("Default"))
                {
                    //The request/command method being executed by Dapper to perform the
                    //SQL query.
                    return connection.Query<Teams>(query).ToList();
                }
            }
            catch (Exception e)
            {
                //Returns an empty record if the quey fails.
                return new List<Teams>();
            }
        }



        /// <summary>
        /// Adds a new team record to the database based upon the provided data model.
        /// </summary>
        /// <param name="teamEntry">The data model holding the details to be stored in the database</param>
        public void AddNewTeam(Teams teamEntry)
        {
            try
            {
                //The query to be passsed to the databse to be executed.
                string query = "INSERT INTO Teams (Name, PrimaryContact, Phone, Email, CompPoints) " +
                           "VALUES (@Name,@PrimaryContact, @Phone, @Email, @CompPoints)";
                //The using statement which manages our connection and disposes of it
                //once the request is compelted.
                using (var connection = Helper.CreateSQLServerConnection("Default"))
                {
                //The request/command method being executed by Dapper to perform the
                //SQL query.
                connection.Execute(query, teamEntry);
                }
            }
            catch(Exception e)
            {

            }
        }


        /// <summary>
        /// Updates a team record in the database based upon the provided data model.
        /// </summary>
        ///<param name="teamEntry">The data model holding the details of the updated record to be stored in the database</param>

        public void UpdateTeam(Teams teamEntry)
        {
            try
            {
                //The query to be passsed to the databse to be executed.
                string query = "UPDATE Teams " +
                           "SET Name = @Name, PrimaryContact = @PrimaryContact, " +
                           "Phone = @Phone, Email = @Email, CompPoints = @CompPoints " +
                           "WHERE Id = @Id";
                //The using statement which manages our connection and disposes of it
                //once the request is compelted.
                using (var connection = Helper.CreateSQLServerConnection("Default"))
                {
                //The request/command method being executed by Dapper to perform the
                //SQL query.
                connection.Execute(query, teamEntry);
                }
            }
            catch (Exception e)
            {
                
            }
        }

        

        /// <summary>
        /// Deletes a record from the database based upon the provided id(Primary Key)
        /// </summary>
        /// <param name="id">The primary key of the record to be deleted</param>
        public void DeleteTeam(int id)
        {
            try
            {
                //The query to be passsed to the databse to be executed.
                string query = "DELETE FROM Teams " +
                               $"WHERE Id = {id}";
                //The using statement which manages our connection and disposes of it
                //once the request is compelted.
                using (var connection = Helper.CreateSQLServerConnection("Default"))
                {
                    //The request/command method being executed by Dapper to perform the
                    //SQL query.
                    connection.Execute(query);
                }
            }
            catch (Exception e)
            {

            }
        }

        #endregion

        #region Events

        // <summary>
        // Retrieves all event records from the database
        // </summary>
        // <returns>A list of event records</returns>
        public List<Events> GetAllEvents()
        {
            try
            {
                //The query to be passsed to the databse to be executed.
                string query = "SELECT * FROM Events";
                //The using statement which manages our connection and disposes of it
                //once the request is compelted.
                using (var connection = Helper.CreateSQLServerConnection("Default"))
                {
                    //The request/command method being executed by Dapper to perform the
                    //SQL query.
                    return connection.Query<Events>(query).ToList();
                }
            }
            catch (Exception e)
            {
                //Returns an empty record if the quey fails.
                return new List<Events>();
            }
        }

        // <summary>
        // Retrieves an event record from the database based upon a given id(Primary Key).
        // </summary>
        // <param name="id">The Id number of the record to be retrieved</param>
        // <returns>A event model representing a single DB record.</returns>
        public Events GetEventById(int id)
        {
            try
            {
                //The query to be passsed to the databse to be executed.
                string query = "SELECT * FROM Events " +
                           $"WHERE Id = {id}";
                //The using statement which manages our connection and disposes of it
                //once the request is compelted.
                using (var connection = Helper.CreateSQLServerConnection("Default"))
                {
                    //The request/command method being executed by Dapper to perform the
                    //SQL query.
                    return connection.QuerySingle<Events>(query);
                }
            }
            catch (Exception e)
            {
                //Returns an empty record if the quey fails.
                return new Events();
            }
        }

        // <summary>
        // Adds a new event record to the database based upon the provided data model.
        // </summary>
        // <param name="eventEntry">The data model holding the details to be stored in the database</param>
        public void AddNewEvent(Events eventEntry)
        {
            try
            {
                //The query to be passsed to the databse to be executed.
                string query = "INSERT INTO Events (Name, Location, Date) " +
                           "VALUES (@Name,@Location, @Date)";
                //The using statement which manages our connection and disposes of it
                //once the request is compelted.
                using (var connection = Helper.CreateSQLServerConnection("Default"))
                {
                //The request/command method being executed by Dapper to perform the
                //SQL query.
                 connection.Execute(query, eventEntry);
                }
            }
            catch (Exception e)
            {
               
            }
        }

        // <summary>
        // Updates an event record in the database based upon the provided data model.
        // </summary>
        // <param name="eventEntry">The data model holding the details of the updated record to be stored in the database</param>
        public void UpdateEvent(Events eventEntry)
        {
            try
            {
                //The query to be passsed to the databse to be executed.
                string query = "UPDATE Events " +
                           "SET Name = @Name, Location = @Location, Date = @Date " +
                           "WHERE Id = @Id";
                //The using statement which manages our connection and disposes of it
                //once the request is compelted.
                using (var connection = Helper.CreateSQLServerConnection("Default"))
                {
                    //The request/command method being executed by Dapper to perform the
                    //SQL query.
                    connection.Execute(query, eventEntry);
                }
            }
            catch (Exception e)
            {

            }
        }

        /// <summary>
        /// Deletes a record from the database based upon the provided id(Primary Key)
        /// </summary>
        /// <param name="id">The primary key of the record to be deleted</param>
        public void DeleteEvent(int id)
        {
            try
            {
                //The query to be passsed to the databse to be executed.
                string query = "DELETE FROM Events " +
                           $"WHERE Id = {id}";
                //The using statement which manages our connection and disposes of it
                //once the request is compelted.
                using (var connection = Helper.CreateSQLServerConnection("Default"))
                {
                    //The request/command method being executed by Dapper to perform the
                    //SQL query.
                    connection.Execute(query);
                }
            }
            catch (Exception e)
            {

            }
        }

        #endregion

        #region GamepLayed

        // <summary>
        // Retrieves all gameplayed records from the database
        // </summary>
        // <returns>A list of game records</returns>
        public List<GamePlayed> GetAllGamePlayed()
        {
            try
            {
                //The query to be passsed to the databse to be executed.
                string query = "SELECT * FROM GamePlayed";
                //The using statement which manages our connection and disposes of it
                //once the request is compelted.
                using (var connection = Helper.CreateSQLServerConnection("Default"))
                {
                    //The request/command method being executed by Dapper to perform the
                    //SQL query.
                    return connection.Query<GamePlayed>(query).ToList();
                }
            }
            catch (Exception e)
            {
                //Returns an empty record if the quey fails.
                return new List<GamePlayed>();
            }
        }

        // <summary>
        // Retrieves a game record from the database based upon a given id(Primary Key).
        // </summary>
        // <param name="id">The Id number of the record to be retrieved</param>
        // <returns>A gamePlayed model representing a single DB record.</returns>
        public GamePlayed GetGamePlayedById(int id)
        {
            try
            {
                //The query to be passsed to the databse to be executed.
                string query = "SELECT * FROM GamePlayed " +
                               $"WHERE Id = {id}";
                //The using statement which manages our connection and disposes of it
                //once the request is compelted.
                using (var connection = Helper.CreateSQLServerConnection("Default"))
                {
                    //The request/command method being executed by Dapper to perform the
                    //SQL query.
                    return connection.QuerySingle<GamePlayed>(query);
                }
            }
            catch (Exception e)
            {
                //Returns an empty record if the quey fails.
                return new GamePlayed();    
            }
        }

        // <summary>
        // Adds a new game record to the database based upon the provided data model.
        // </summary>
        // <param name="gamePlayedEntry">The data model holding the details to be stored in the database</param>
        public void AddNewGamePlayed(GamePlayed gamePlayedEntry)
        {
            try
            {
                //The query to be passsed to the databse to be executed.
                string query = "INSERT INTO GamePlayed (Name, GameType) " +
                               "VALUES (@Name,@GameType)";
                //The using statement which manages our connection and disposes of it
                //once the request is compelted.
                using (var connection = Helper.CreateSQLServerConnection("Default"))
                {
                    //The request/command method being executed by Dapper to perform the
                    //SQL query.
                    connection.Execute(query, gamePlayedEntry);
                }
            }
            catch (Exception e)
            {

            }
        }

        // <summary>
        // Updates an game record in the database based upon the provided data model.
        // </summary>
        // <param name="gamePlayedEntry">The data model holding the details of the updated record to be stored in the database</param>

        public void UpdateGamePlayed(GamePlayed gamePlayedEntry)
        {
            try
            {
                //The query to be passsed to the databse to be executed.
                string query = "UPDATE GamePlayed " +
                               "SET Name = @Name, GameType = @GameType " +
                               "WHERE Id = @Id";
                //The using statement which manages our connection and disposes of it
                //once the request is compelted.
                using (var connection = Helper.CreateSQLServerConnection("Default"))
                {
                    //The request/command method being executed by Dapper to perform the
                    //SQL query.
                    connection.Execute(query, gamePlayedEntry);
                }
            }
            catch (Exception e)
            {

            }
        }

        /// <summary>
        /// Deletes a record from the database based upon the provided id(Primary Key)
        /// </summary>
        /// <param name="id">The primary key of the record to be deleted</param>
        public void DeleteGamePlayed(int id)
        {
            try
            {
                //The query to be passsed to the databse to be executed.
                string query = "DELETE FROM GamePlayed " +
                               $"WHERE Id = {id}";
                //The using statement which manages our connection and disposes of it
                //once the request is compelted.
                using (var connection = Helper.CreateSQLServerConnection("Default"))
                {
                    //The request/command method being executed by Dapper to perform the
                    //SQL query.
                    connection.Execute(query);
                }
            }
            catch (Exception e)
            {

            }
        }

        #endregion

        #region TeamResultsView

        /// <summary>
        /// Retrieves all result view records from the database
        /// </summary>
        /// <returns>A list of team result records</returns>
        public List<ResultView> GetAllTeamResult()
        {
            try
            {
                //The query to be passsed to the databse to be executed.
                string query = "SELECT TeamResults.Id, Events.Name AS EventHeld, GamePlayed.Name AS GamePlayed, " +
                               "Team1.Name AS Team1 ,Team2.Name AS Team2, " +
                               "TeamResults.Result " +
                               "FROM TeamResults " +
                               "INNER JOIN " +
                               "Events ON Events.Id = TeamResults.EventHeldId " +
                               "INNER JOIN " +
                               "GamePlayed ON TeamResults.GamePlayedId = GamePlayed.Id " +
                               "INNER JOIN " +
                               "Teams AS Team1 ON TeamResults.Team1Id = Team1.Id " +
                               "INNER JOIN " +
                               "Teams As Team2 ON TeamResults.Team2Id = Team2.Id ";

                //The using statement which manages our connection and disposes of it
                //once the request is compelted.
                using (var connection = Helper.CreateSQLServerConnection("Default"))
                {
                    //The request/command method being executed by Dapper to perform the
                    //SQL query.
                    return connection.Query<ResultView>(query).ToList();
                }
            }
            catch (Exception e)
            {
                //Returns an empty record if the quey fails.
                return new List<ResultView>();
            }
        }

        /// <summary>
        /// Search result records by Team names to the database based upon the provided data model.
        /// </summary>
        /// <param name="name">The data model holding the details to be stored in the database</param>
        public List<ResultView> SearchResultByTeamName(string name)
        {
            try
            {
                //The query to be passsed to the databse to be executed.
                string query = "SELECT TeamResults.Id, Events.Name AS EventHeld, GamePlayed.Name AS GamePlayed, " +
                               "Team1.Name AS Team1 ,Team2.Name AS Team2, " +
                               "TeamResults.Result " +
                               "FROM TeamResults " +
                               "INNER JOIN " +
                               "Events ON Events.Id = TeamResults.EventHeldId " +
                               "INNER JOIN " +
                               "GamePlayed ON TeamResults.GamePlayedId = GamePlayed.Id " +
                               "INNER JOIN " +
                               "Teams AS Team1 ON TeamResults.Team1Id = Team1.Id " +
                               "INNER JOIN " +
                               "Teams As Team2 ON TeamResults.Team2Id = Team2.Id " +
                               $"WHERE Team1.Name LIKE '%{name}%'";

                //The using statement which manages our connection and disposes of it
                //once the request is compelted.
                using (var connection = Helper.CreateSQLServerConnection("Default"))
                {
                    //The request/command method being executed by Dapper to perform the
                    //SQL query.
                    return connection.Query<ResultView>(query).ToList();
                }
            }
            catch (Exception e)
            {
                //Returns an empty record if the quey fails.
                return new List<ResultView>();
            }
        }


        /// <summary>
        /// Retrieves a result record from the database based upon a given id(Primary Key).
        /// </summary>
        ///<param name="id">The Id number of the record to be retrieved</param>
        /// <returns>A team model representing a single DB record.</returns>
        public ResultView GetResultViewById(int id)
        {
            try
            {
                //The query to be passsed to the databse to be executed.
                string query = "SELECT TeamResults.Id, Events.Name AS EventHeld, GamePlayed.Name AS GamePlayed, " +
                               "Team1.Name AS Team1 ,Team2.Name AS Team2, " +
                               "TeamResults.Result " +
                               "FROM TeamResults " +
                               "INNER JOIN " +
                               "Events ON Events.Id = TeamResults.EventHeldId " +
                               "INNER JOIN " +
                               "GamePlayed ON TeamResults.GamePlayedId = GamePlayed.Id " +
                               "INNER JOIN " +
                               "Teams AS Team1 ON TeamResults.Team1Id = Team1.Id " +
                               "INNER JOIN " +
                               "Teams As Team2 ON TeamResults.Team2Id = Team2.Id " +
                               $"WHERE Id = {id}";
                //The using statement which manages our connection and disposes of it
                //once the request is compelted.
                using (var connection = Helper.CreateSQLServerConnection("Default"))
                {
                    //The request/command method being executed by Dapper to perform the
                    //SQL query.
                    return connection.QuerySingle<ResultView>(query);
                }
            }
            catch (Exception e)
            {
                //Returns an empty record if the quey fails.
                return new ResultView();
            }
        }

        public TeamResults GetTeamResultsById(int id)
        {
            try
            {
                //The query to be passsed to the databse to be executed.
                string query = "SELECT Id, EventHeldId, GamePlayedId, Team1Id, Team2Id, Result " +
                               "FROM TeamResults" +
                                $"WHERE Id = {id}";
                //The using statement which manages our connection and disposes of it
                //once the request is compelted.
                using (var connection = Helper.CreateSQLServerConnection("Default"))
                {
                    //The request/command method being executed by Dapper to perform the
                    //SQL query.
                    return connection.QuerySingle<TeamResults>(query);
                }
            }
            catch (Exception e)
            {
                //Returns an empty record if the quey fails.
                return new TeamResults();
            }
        }

        /// <summary>
        /// Adds a new result record to the database based upon the provided data model.
        /// </summary>
        /// <param name="resultEntry">The data model holding the details to be stored in the database</param>
        public void AddNewTeamResults(TeamResults resultEntry)
        {
            try
            {
                //The query to be passsed to the databse to be executed.
                string query = "INSERT INTO TeamResults (EventHeldId, GamePlayedId, Team1Id, Team2Id, Result) " +
                               "VALUES (@EventHeldId, @GamePlayedId, @Team1Id, @Team2Id, @Result)";
                //The using statement which manages our connection and disposes of it
                //once the request is compelted.
                using (var connection = Helper.CreateSQLServerConnection("Default"))
                {
                    //The request/command method being executed by Dapper to perform the
                    //SQL query.
                    connection.Execute(query, resultEntry);
                }
            }
            catch (Exception e)
            {

            }
        }

        /// <summary>
        /// Updates result records in the database based upon the provided data model.
        /// </summary>
        /// <param name="resultEntry">The data model holding the details of the updated record to be stored in the database</param>
        public void UpdateTeamResults(TeamResults resultEntry)
        {
            try
            {
                //The query to be passsed to the databse to be executed.
                string query = "UPDATE TeamResults " +
                               "SET EventHeldId = @EventHeldId, GamePlayedId = @GamePlayedId," +
                               "Team1Id = @Team1Id, Team2Id = @Team2Id, Result = @Result " +
                               "WHERE Id = @Id";
                //The using statement which manages our connection and disposes of it
                //once the request is compelted.
                using (var connection = Helper.CreateSQLServerConnection("Default"))
                {
                    //The request/command method being executed by Dapper to perform the
                    //SQL query.
                    connection.Execute(query, resultEntry);
                }
            }
            catch (Exception e)
            {

            }
        }

        /// <summary>
        /// Deletes a record from the database based upon the provided id(Primary Key)
        /// </summary>
        /// <param name="id">The primary key of the record to be deleted</param>
        public void DeleteTeamResults(int id)
        {
            try
            {
                //The query to be passsed to the databse to be executed.
                string query = "DELETE FROM TeamResults " +
                             $"WHERE Id = {id}";
                //The using statement which manages our connection and disposes of it
                //once the request is compelted.
                using (var connection = Helper.CreateSQLServerConnection("Default"))
                {
                //The request/command method being executed by Dapper to perform the
                //SQL query.
                    connection.Execute(query);
                }
            }
            catch(Exception e)
            {

            }
        }

        #endregion


        /// <summary>
        /// Create a transaction to update points from the database
        /// </summary>
        /// <param name="updatePoints">The data model holding the details of the updated record 
        /// to be stored in the database</param>
        public bool UpdateTeamPointsTransaction(Teams updatePoints)
        {
            //Requests and SQL connection from the helper class to use for the queries to be executed.
            using (var connection = Helper.CreateSQLServerConnection("Default"))
            {
                //Mnually opens the connection to the databse if it did not open automatically when the connection was created. This is usually
                //done by dapper but needs to be done manually in this method to allow us to create our transaction.
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                //Creates an SQL transaction to track any changes made and roll them back if needed.
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        //The query for the first SQL interaction to be performed.
                        string query = "UPDATE Teams " +
                               "SET CompPoints = @CompPoints " +
                               "WHERE Id = @Id";

                        //Executing the above query using the transaction.
                        connection.Execute(query, updatePoints, transaction);

                        //Makes the queries executed in the transaction permanent in the database.
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        //Undoes the queries executed in the transaction due to an error so that no changes have been made permanantly in the database.
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }
    }
}
