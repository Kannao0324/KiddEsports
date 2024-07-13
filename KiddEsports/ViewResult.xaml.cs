using DataManagement;
using DataManagement.Model;
using System;
using System.Collections.Generic;
using System.Formats.Tar;
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
using System.Windows.Shapes;

namespace KiddEsports
{
    /// <summary>
    /// Interaction logic for ViewResult.xaml
    /// </summary>
    public partial class ViewResult : Window
    {
        ////Creates the class object needed to manage our database transactions.
        DataAdapter data = new DataAdapter();
        ////The list to store all our database records once received.
        List<TeamResults> resultList = new List<TeamResults>();
        List<ResultView> resultViewList = new List<ResultView>();
        List<Teams> teamList = new List<Teams>();
        List<Events> eventList;
        List<GamePlayed> gamePlayedList;
        ////Acts as a falg to detrrmine whow entries are saved when the SAVE button is
        ////pressed. If TRUE it will save as a new record, if FALSE it will try to update
        ////the currently displayed record.
        bool isUpdateEntry = false;
        public ViewResult()
        {
            InitializeComponent();
            LoadResultTable();
            SetupComboBoxes();
            ClearDataEntryFields();
            

        }
        /// <summary>
        /// Retrives all the result records from the DB and displays them in the data grid.
        /// </summary>
        private void LoadResultTable()
        {
            resultViewList = data.GetAllTeamResult();
            dgvTeamResults.ItemsSource = resultViewList;
            dgvTeamResults.Items.Refresh();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            //Make sure the table has a valid row currently selected
            if (dgvTeamResults.SelectedIndex < 0)
            {
                MessageBox.Show("Please select the record");
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

            if (isUpdateEntry)
            {
                resultEntry.Id = int.Parse(txtId.Text);
                data.UpdateTeamResults(resultEntry);

                // Revise comp points from the old record
                string team1Name = resultViewList[dgvTeamResults.SelectedIndex].Team1;
                string team2Name = resultViewList[dgvTeamResults.SelectedIndex].Team2;
                Teams oldTeam1 = data.GetTeamByName(team1Name);
                Teams oldTeam2 = data.GetTeamByName(team2Name);
                string result = resultViewList[dgvTeamResults.SelectedIndex].Result;
                // if Team 1 win is selected, subtract 2 points to team 1
                if (result.Equals("Team1 Win"))
                {
                    oldTeam1.CompPoints -= 2;
                    data.UpdateTeamPointsTransaction(oldTeam1);
                }
                // if draw is selected, subtract 1 points for each team 
                else if (result.Equals("Draw"))
                {
                    oldTeam1.CompPoints -= 1;
                    data.UpdateTeamPointsTransaction(oldTeam1);
                    oldTeam2.CompPoints -= 1;
                    data.UpdateTeamPointsTransaction(oldTeam2);
                }
                // if Team 2 win is selected, subtract 2 points to team 2
                else if (result.Equals("Team2 Win"))
                {
                    oldTeam2.CompPoints -= 2;
                    data.UpdateTeamPointsTransaction(oldTeam2);
                }
                else
                {
                    MessageBox.Show("Error");
                }

                // Update the comp points when updated
                int team1Id = resultEntry.Team1Id;
                int team2Id = resultEntry.Team2Id;
                Teams team1 = data.GetTeamById(team1Id);
                Teams team2 = data.GetTeamById(team2Id);
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

                MessageBox.Show("The selected record has been updated");
            }
            else
            {
                MessageBox.Show("Please select the record to update");
            }
            ClearDataEntryFields();
            LoadResultTable();
            isUpdateEntry = false;
            

        }

        /// <summary>
        /// Event triggered when the delete button is pressed. 
        /// </summary>
        /// <param name="sender">The component triggering the the event.</param>
        /// <param name="e">Details fo the event passed by the calling component.</param>
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //Checks whether the data grid currently has a valid row selected.
            //If none is selected it will return a value of -1
            if (dgvTeamResults.SelectedIndex < 0)
            {
                return;
            }

            //Retrieves the primary key from the currently slected row
            int id = resultViewList[dgvTeamResults.SelectedIndex].Id;

            //Displays message box to user asking to confirm deletion of selected entry.
            //This message box stores the selected response from the user.
            MessageBoxResult response = MessageBox.Show($"Delete ID:{resultViewList[dgvTeamResults.SelectedIndex].Id}?",
                                                          "Delete Confirmation", MessageBoxButton.YesNo);
            //If the user response was a yes/confirmation response the delete proceeds.
            if (response == MessageBoxResult.Yes)
            {
                // Select the record from the datagrid
                ResultView selectedItem = dgvTeamResults.SelectedItem as ResultView;
                string team1Name = resultViewList[dgvTeamResults.SelectedIndex].Team1;
                string team2Name = resultViewList[dgvTeamResults.SelectedIndex].Team2;
                // Call the team names from team details
                Teams team1 = data.GetTeamByName(team1Name);
                Teams team2 = data.GetTeamByName(team2Name);
                // If the result is selected "Team 1 Win", Remove 2 points from the team1
                if (selectedItem.Result.Equals("Team1 Win"))
                {
                    team1.CompPoints -= 2;
                    if (team1.CompPoints <= 0)
                    {
                        team1.CompPoints = 0;
                    }
                    data.UpdateTeamPointsTransaction(team1);
                }
                // If the result is selected "Draw", Remove 1 point wach from the team1 and team2
                else if (selectedItem.Result.Equals("Draw"))
                {
                    team1.CompPoints -= 1;
                    team2.CompPoints -= 1;
                    if (team1.CompPoints <= 0)
                    {
                        team1.CompPoints = 0;
                    }
                    data.UpdateTeamPointsTransaction(team1);
                    if (team2.CompPoints <= 0)
                    {
                        team2.CompPoints = 0;
                    }
                    data.UpdateTeamPointsTransaction(team2);
                }
                // If the result is selected "Team 2 Win", Remove 2 points from the team2
                else if (selectedItem.Result.Equals("Team2 Win"))
                {
                    team2.CompPoints -= 2;
                    if (team2.CompPoints <= 0)
                    {
                        team2.CompPoints = 0;
                    }
                    data.UpdateTeamPointsTransaction(team2);
                }
                //Pass the desired primary key to the delete method to trigger deletion from database.
                data.DeleteTeamResults(id);
                //Clears and refreshes UI and confirms the deletion with the user via message box.
                LoadResultTable();
                MessageBox.Show("Record Deleted.");
            }
            LoadResultTable();
        }

        /// <summary>
        /// Event triggered when the selected record of the data grid is changed 
        /// by either selecting or unselecting a row. 
        /// </summary>
        /// <param name="sender">The component triggering the the event.</param>
        /// <param name="e">Details fo the event passed by the calling component.</param>
        private void dgvTeamResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Make sure the table has a valid row currently selected
            if (dgvTeamResults.SelectedIndex < 0)
            {
                return;
            }

            
            //Grab the Id(primary key) from the entry in the list that matcheds the row
            //selected in the table.
            int id = resultViewList[dgvTeamResults.SelectedIndex].Id;
            //Retreieve the team record from the database that matches the selected id.
            ResultView selectedResult = data.GetResultViewById(id);
            //If the selected id is invalid or null, show the error message.
            if (selectedResult == null)
            {
                MessageBox.Show("Something went wrong. \nPlease try again");
                LoadResultTable();
                return;
            }
            selectedResult = resultViewList[dgvTeamResults.SelectedIndex];
            
            //Reads all the details from the data entry fields and stores them in the result view object for saving
            txtId.Text = selectedResult.Id.ToString();
            cboEvent.Text = selectedResult.EventHeld;
            cboGame.Text = selectedResult.GamePlayed;
            cboTeam1.Text = selectedResult.Team1;
            cboTeam2.Text = selectedResult.Team2;
            cboResult.Text = selectedResult.Result;
            //Set the save mode to update.
            isUpdateEntry = true;

        }

        /// <summary>
        /// method to clear all the data entry fields back to blank.
        /// </summary>
        private void ClearDataEntryFields()
        {
            txtId.Text = string.Empty;
            cboEvent.SelectedIndex = -1;
            cboGame.SelectedIndex = -1;
            cboTeam1.SelectedIndex = -1;
            cboTeam2.SelectedIndex = -1;
            cboResult.SelectedIndex = -1;
            //Set the save mode to new
            isUpdateEntry = false;
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
    }
}
