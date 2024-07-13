using DataManagement;
using System.Configuration;
using System.Data;
using System.Windows;

namespace KiddEsports
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            //Create oour class for database building
            DBBuilder builder = new DBBuilder();
            //Tell the builder to build the database. This will do nothing if it already exists.
            builder.CreateDatabase();
            //Check if the database has any tables yet.
            if (builder.DoTablesExist() == false)
            {
                //If not, trigger the building of the database tables
                builder.BuildDatabaseTable();
            }
        }
    }

}
