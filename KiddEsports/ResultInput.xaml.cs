using DataManagement;
using DataManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KiddEsports
{
    /// <summary>
    /// Interaction logic for ResultInput.xaml
    /// </summary>
    public partial class ResultInput : UserControl
    {
        ////Creates the class object needed to manage our database transactions.
        DataAdapter data = new DataAdapter();
        ////The list to store all our database records once received.
        List<Teams> teamList;
        List<Events> eventList;
        List<GamePlayed> gamePlayedList;
        ////Acts as a falg to detrrmine whow entries are saved when the SAVE button is
        ////pressed. If TRUE it will save as a new record, if FALSE it will try to update
        ////the currently displayed record.
        public bool isNewEntry = true;

        public ResultInput()
        {
            InitializeComponent();
            SetupComboBoxes();
        }



        /// <summary>
        /// Event triggered by the save button is pressed 
        /// </summary>
        /// <param name="sender">The object triggering the event</param>
        /// <param name="e">Any paramaters passed when the event is triggered by its component</param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //If any of the data entry fields are not correctly filled or contain invalid data
            //the save will not proceed and a message box will be issued to the user.
            if (AreFieldsFilledCorrectly() == false)
            {
                MessageBox.Show("Please selext all the form befere saving");
                return;
            }

            //Reads all the details from each combo boxes and stores them in the resultentry object for saving
            TeamResults resultEntry = new TeamResults();


            Events selectedEvent = (Events)cboEvent.SelectedItem;
            resultEntry.EventHeldId = selectedEvent.Id;
            GamePlayed selectedGame = (GamePlayed)cboGame.SelectedItem;
            resultEntry.GamePlayedId = selectedGame.Id;
            Teams selectedTeam1 = (Teams)cboTeam1.SelectedItem;
            resultEntry.Team1Id = selectedTeam1.Id;
            Teams selectedTeam2 = (Teams)cboTeam2.SelectedItem;
            resultEntry.Team2Id = selectedTeam2.Id;
            resultEntry.Result = (string)cboResult.SelectedItem;


            // If user selects the same team in team 1 and team 2, display a warning message
            if (cboTeam2.SelectedItem == cboTeam1.SelectedItem)
            {
                MessageBox.Show("Please select other team");
                return;
            }

            // Save a new entry
            if (isNewEntry)
            {
                // If user doesn't select option from the result combo box when entering a new entry, return
                if (cboResult.SelectedIndex < 0)
                {
                    return;
                }

                int team1Id = resultEntry.Team1Id;
                int team2Id = resultEntry.Team2Id;
                Teams team1 = data.GetTeamById(team1Id);
                Teams team2 = data.GetTeamById(team2Id);
                //Teams addPoints = new Teams();

                // if Team 1 win is selected, add 2 points to team 1
                if (cboResult.SelectedItem.Equals("Team1 Win"))
                {
                    team1.CompPoints = selectedTeam1.CompPoints += 2;
                    data.UpdateTeamPointsTransaction(selectedTeam1);
                }
                // if draw is selected, add 1 points for each team 
                else if (cboResult.SelectedItem.Equals("Draw"))
                {
                    team1.CompPoints = selectedTeam1.CompPoints += 1;
                    data.UpdateTeamPointsTransaction(selectedTeam1);
                    team2.CompPoints = selectedTeam2.CompPoints += 1;
                    data.UpdateTeamPointsTransaction(selectedTeam2);
                }
                // if Team 2 win is selected, add 2 points to team 2
                else if (cboResult.SelectedItem.Equals("Team2 Win"))
                {
                    team2.CompPoints = selectedTeam2.CompPoints += 2;
                    data.UpdateTeamPointsTransaction(selectedTeam2);
                }
                else
                {
                    MessageBox.Show("Error");
                }
                // Save a new entry and pass the input to the database
                data.AddNewTeamResults(resultEntry);
                // Display the message after saving
                MessageBox.Show("New entry saved");
            }
            // Update the existing entry
            else
            {
                MessageBox.Show("Error occurs");
                return;
                
            }
            ClearDataEntryFields();
        }

        /// <summary>
        /// Checks whether each field in the data entry form has valid data selected/entered 
        /// and returns false if any field is blank or containt invalid data.
        /// </summary>
        /// <returns>Whether the current data in the entry fields is valid or not.</returns>
        private bool AreFieldsFilledCorrectly()
        {
            if (cboEvent.SelectedItem == null)
            {
                return false;
            }
            if (cboGame.SelectedItem == null)
            {
                return false;
            }
            if (cboTeam1.SelectedItem == null)
            {
                return false;
            }
            if (cboTeam2.SelectedItem == null)
            {
                return false;
            }
            if (cboResult.SelectedItem == null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// method to clear all the data entry fields back to blank.
        /// </summary>
        private void ClearDataEntryFields()
        {
            cboEvent.SelectedIndex = -1;
            cboGame.SelectedIndex = -1;
            cboTeam1.SelectedIndex = -1;
            cboTeam2.SelectedIndex = -1;
            cboResult.SelectedIndex = -1;
            //Set the save mode to new
            isNewEntry = true;
        }

        /// <summary>
        /// method to set up all the combo boxes back to retrive data from each table in the database.
        /// </summary>
        private void SetupComboBoxes()
        {
            //Gets the Users from the database
            teamList = data.GetAllTeams();
            //Sets the list as the source of the combo box. 
            cboTeam1.ItemsSource = teamList;
            cboTeam2.ItemsSource = teamList;
            //Sets the Name property of each list item as what displays in the combo box.
            cboTeam1.DisplayMemberPath = "Name";
            cboTeam2.DisplayMemberPath = "Name";
            //Sets the value that is returned when a combo box option is selected.
            //IN this example the value will be the item Id (Primary Key)
            cboTeam1.SelectedValuePath = "Id";
            cboTeam2.SelectedValuePath = "Id";

            //Event combo box.
            eventList = data.GetAllEvents();
            cboEvent.ItemsSource = eventList;
            cboEvent.DisplayMemberPath = "Name";
            cboEvent.SelectedValuePath = "Id";

            //GamePlayed combo box.
            gamePlayedList = data.GetAllGamePlayed();
            cboGame.ItemsSource = gamePlayedList;
            cboGame.DisplayMemberPath = "Name";
            cboGame.SelectedValuePath = "Id";

            // Result combo box.
            string[] comboResultItems = new[] { "Team1 Win", "Team2 Win", "Draw" };
            cboResult.ItemsSource = comboResultItems;

        }


        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            ViewResult view = new ViewResult();
            view.ShowDialog();
        }

    }
}
