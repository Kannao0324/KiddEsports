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
    /// Interaction logic for GamePlayedPanel.xaml
    /// </summary>
    public partial class GamePlayedPanel : UserControl
    {
        ////Creates the class object needed to manage our database transactions.
        DataAdapter data = new DataAdapter();
        ////The list to store all our database records once received.
        List<GamePlayed> gamePlayedList = new List<GamePlayed>();
        ////Acts as a falg to determine how entries are saved when the SAVE button is
        ////pressed. If TRUE it will save as a new record, if FALSE it will try to update
        ////the currently displayed record.
        bool isNewEntry = true;
        public GamePlayedPanel()
        {
            InitializeComponent();
            UpdateDataGrid();
            SetupComboBoxes();
        }

        /// <summary>
        /// Retrives all the game records from the DB and displays them in the data grid.
        /// </summary>
        private void UpdateDataGrid()
        {
            //Retrieves the table data from the database and assigns it to the list.
            gamePlayedList = data.GetAllGamePlayed();
            //Sets the list as the data source for the data grid.
            dgvGamePlayed.ItemsSource = gamePlayedList;
            //Refreshes the data grid diplay to match the current list contents.
            dgvGamePlayed.Items.Refresh();
        }

        /// <summary>
        /// method to set up the combo box of game type using the array.
        /// </summary>
        private void SetupComboBoxes()
        {
            string[] comboItems = new[] { "Team", "Solo" };
            cboGameTypes.ItemsSource = comboItems;
        }

        /// <summary>
        /// method to clear all the data entry fields back to blank.
        /// </summary>
        private void ClearEntryFormFields()
        {
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
            cboGameTypes.SelectedIndex = -1;
            //Set the save mode to new
            isNewEntry = true;
        }

        /// <summary>
        /// Checks whether each field in the data entry form has valid data selected/entered 
        /// and returns false if any field is blank or containt invalid data.
        /// </summary>
        /// <returns>Whether the current data in the entry fields is valid or not.</returns>
        private bool AreFieldsFilledCorrectly()
        {
            if (String.IsNullOrWhiteSpace(txtName.Text))
            {
                return false;
            }
            if (cboGameTypes.SelectedItem == null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Event triggered by the new button is pressed to clear the form.
        /// </summary>
        /// <param name="sender">The object triggering the event</param>
        /// <param name="e">Any paramaters passed when the event is triggered by its component</param>
        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            ClearEntryFormFields();
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
                MessageBox.Show("Please fill in the form the correctly befere saving");
                return;
            }

            //Reads all the details from the data entry fields and stores them in the game object for saving
            GamePlayed gamePlayedEntry = new GamePlayed();
            gamePlayedEntry.Name = txtName.Text;
            gamePlayedEntry.GameType = (string)cboGameTypes.SelectedItem;

            //Save a new entry
            if (isNewEntry)
            {
                data.AddNewGamePlayed(gamePlayedEntry);
            }
            //Update the existing record
            else
            {
                gamePlayedEntry.Id = int.Parse(txtId.Text);
                data.UpdateGamePlayed(gamePlayedEntry);
            }

            ClearEntryFormFields();
            UpdateDataGrid();
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
            if (dgvGamePlayed.SelectedIndex < 0)
            {
                MessageBox.Show("No row selected to delete");
                return;
            }

            // Display the warning message whether the user uses the team record in the result records.
            MessageBoxResult response = MessageBox.Show($"If {gamePlayedList[dgvGamePlayed.SelectedIndex].Name} is used in the team result record," +
                $"{gamePlayedList[dgvGamePlayed.SelectedIndex].Name} can't be deleted. " +
                $"\nPlease delete the result record first. \nIf No, Click Yes to proceed",
                "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            // If the user selected Yes, proceed the step for deletion
            if (response == MessageBoxResult.Yes)
            {

                //Displays message box to user asking to confirm deletion of selected entry.
                //This message box stores the selected response from the user.
                MessageBoxResult answer = MessageBox.Show($"Delete {gamePlayedList[dgvGamePlayed.SelectedIndex].Name}?",
                "Delete Confirmation", MessageBoxButton.YesNo);
                //If the user response was a yes/confirmation response the delete proceeds.
                if (answer == MessageBoxResult.Yes)
                {
                    //Retrieves the primary key from the currently slected row
                    int id = gamePlayedList[dgvGamePlayed.SelectedIndex].Id;
                    //Pass the desired primary key to the delete method to trigger deletion from database.
                    data.DeleteTeam(id);
                    //Clears and refreshes UI and confirms the deletion with the user via message box.
                    ClearEntryFormFields();
                    UpdateDataGrid();
                    MessageBox.Show("Record Deleted.");
                }
            }
        }

        private void GameTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        /// <summary>
        /// Event triggered when the selected record of the data grid is changed 
        /// by either selecting or unselecting a row. 
        /// </summary>
        /// <param name="sender">The component triggering the the event.</param>
        /// <param name="e">Details fo the event passed by the calling component.</param>
        private void dgvGamePlayed_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Make sure the table has a valid row currently selected
            if (dgvGamePlayed.SelectedIndex < 0)
            {
                return;
            }

            //Grab the Id(primary key) from the entry in the list that matcheds the row
            //selected in the table.
            int id = gamePlayedList[dgvGamePlayed.SelectedIndex].Id;
            //Retreieve the gamePlayed record from the database that matches the selected id.
            GamePlayed selectedGame = data.GetGamePlayedById(id);
            //If the selected id is invalid or null, show the error message.
            if (selectedGame == null)
            {
                MessageBox.Show("Something went wrong. \nPlease try again");
                UpdateDataGrid();
                return;
            }
            //Set the text fields to match the values in the model for their associated properties.
            txtId.Text = selectedGame.Id.ToString();
            txtName.Text = selectedGame.Name;
            cboGameTypes.SelectedValue = selectedGame.GameType;
            //Set the save mode to update.
            isNewEntry = false;
        }
    }
}
