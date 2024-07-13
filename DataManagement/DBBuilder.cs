using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DataManagement.Model;
using DataManagement;


namespace DataManagement
{
    public class DBBuilder : DataAdapter
    {
        /// <summary>
        /// Sends a request to SQL Server to check if a databse exists matching name 
        /// provided in the connection string. If it does not exists the query then asks the
        /// server to create a new databse with the provided connection string name.
        /// </summary>
        public void CreateDatabase()
        {
            //Our connection object to link to the database
            SqlConnection connection = Helper.CreateSQLServerConnection("Default");
            try
            {
                //Custom connection string to only connect to the server layer of your SQL Database
                string connectionString = $"Data Source={connection.DataSource}; Integrated Security = True";
                //Query to build new Database if it does not already exist.
                string query = $"IF NOT EXISTS (SELECT 1 FROM sys.databases WHERE name ='{connection.Database}') " +
                $" CREATE DATABASE {connection.Database}";
                using (connection = new SqlConnection(connectionString))
                {
                    //A command object which will send our request to the Database <= Normally done for us by Dapper
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        //Checks if the connection is currently open, if not, it opens the connection.<= Normally done
                        //for us by Dapper
                        if (connection.State == ConnectionState.Closed)
                        {
                            connection.Open();
                        }
                        //Executes an SQL Request that does not expect a response(Query) to be returned.
                        command.ExecuteNonQuery();
                        //Closes the connection to the database manually.<= Normally done for us by Dapper
                        connection.Close();
                    }
                }
            }
            catch (Exception e)
            {
             
            }
        }

        /// <summary>
        /// Runs a query against the database to get a count of how many base tables exist in the database.
        /// </summary>
        /// <returns>A confirmation of whther there are tables (TRUE) or not (FALSE)</returns>
        public bool DoTablesExist()
        {
            //Our using statemtnqwhich builds our connection and disposes of it once finished.
            using (var connection = Helper.CreateSQLServerConnection("Default"))
            {
                //Quey to request the count of how many base tables are in the database structure. Base tables refers to user
                //built tables and ignores inbuild tables such as index tables and reference/settings tables.
                string query = $"SELECT COUNT(*) FROM {connection.Database}.INFORMATION_SCHEMA.TABLES " +
                $"WHERE TABLE_TYPE = 'BASE TABLE'";
                //Sends the query to the databse and stores the returned table count.
                int count = connection.QuerySingle<int>(query);
                //If the count is above 0 return true, otherwise return false to indicate whether the databse has tabes or not.
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// Method to send a request to the databse to create a new databse table. 
        /// This method requires the table name and column/attributes details to be 
        /// pre-populated and passed to the method for it to work.
        /// </summary>
        /// <param name="name">The name to be given to the table when created.</param>
        /// <param name="structure">A string oulining all the table column/attributes 
        ///                     and their names, types and any other special rules for each
        ///                     of them such as PK
        /// identification, nullability rules and foreighn key connections.</param>
        private void CreateTable(string name, string structure)
        {
            try
            {
                //Partial query to build table in database. Parameters passe to method will be inserted to complete the query string.
                string query = $"CREATE TABLE {name} ({structure})";
                //Our using statemtnqwhich builds our connection and disposes of it once finished.
                using (var connection = Helper.CreateSQLServerConnection("Default"))
                {
                    //Passes the query to the databse to be perfomed.
                    connection.Execute(query);
                }
            }
            catch (Exception e)
            {
                //Log error on failure
            }
        }

        /// <summary>
        /// Runs all the separate methods to create all the database tables, ensuring to run them in the correct sequence to ensure tables with foreign key declarations are 
        /// not made until after the tables they are referencing are already created.
        /// </summary>
        public void BuildDatabaseTable()
        {
            CreateTeamTable();
            CreateEventTable();
            CreateGamePlayedTable();
            CreateTeamResultTable();
        }

        /// <summary>
        /// Outlines the table structure of the team table and passes it to the CreateTable() method to be built.
        /// Each column/attribute is defined using the following format: 
        ///     <Name> <DataType> <Rules>
        /// 
        /// The rules for each attribute use the following options:
        ///     IDENTITY (1,1) - Sets auto-incrementation for the column with a start number and increment matching the provided numbers
        ///     PRIMARY KEY - Marks the clumn as the primary key for the table
        ///     NULL or NOT NULL sets the nullability of the column accordingly. If not defined the NULL 
        /// 
        /// </summary>
        private void CreateTeamTable()
        {
            //Outlines structure of a team table
            string structure = "Id int PRIMARY KEY IDENTITY(1,1), " +
                               "Name VARCHAR(100) UNIQUE NOT NULL, " +
                               "PrimaryContact VARCHAR(50) NOT NULL, " +
                               "Phone VARCHAR(50) NOT NULL, " +
                               "Email VARCHAR(100) NOT NULL, " +
                               "CompPoints int NOT NULL ";
            //Passes name and strucutre to creation method.
            CreateTable("Teams", structure);
        }

        private void CreateEventTable()
        {
            //Outlines structure of an event table
            string structure = "Id int PRIMARY KEY IDENTITY(1,1), " +
                              "Name VARCHAR(100) NOT NULL, " +
                              "Location VARCHAR(100) NOT NULL, " +
                              "Date DATE NOT NULL ";
            //Passes name and strucutre to creation method.
            CreateTable("Events", structure);
        }

        private void CreateGamePlayedTable()
        {
            //Outlines structure of a gamePlayed table
            string structure = "Id int PRIMARY KEY IDENTITY(1,1), " +
                              "Name VARCHAR(100) NOT NULL, " +
                              "GameType VARCHAR(10) NOT NULL, ";

            //Passes name and strucutre to creation method.
            CreateTable("GamePlayed", structure);
        }

        private void CreateTeamResultTable()
        {
            //Outlines structure of  a team result table
            string structure = "Id int PRIMARY KEY IDENTITY(1,1), " +
                               "EventHeldId int FOREIGN KEY REFERENCES Events(Id)," +
                               "GamePlayedId int FOREIGN KEY REFERENCES GamePlayed(Id)," +
                               "Team1Id int FOREIGN KEY REFERENCES Teams(Id)," +
                               "Team2Id int FOREIGN KEY REFERENCES Teams(Id)," +
                               "Result VARCHAR(50) NOT NULL" ;

            //Passes name and strucutre to creation method.
            CreateTable("TeamResults", structure);
        }

    }
}
