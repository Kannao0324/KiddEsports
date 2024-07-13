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
using System.Xml.Linq;
using DataManagement;
using DataManagement.Model;
using static System.Net.Mime.MediaTypeNames;


namespace KiddEsports
{
    /// <summary>
    /// Interaction logic for TeamPanel.xaml
    /// </summary>
    public partial class TeamPanel : UserControl
    {
        ////Creates the class object needed to manage our database transactions.
        DataAdapter data = new DataAdapter();
        ////The list to store all our database records once received.
        List<Teams> teamList = new List<Teams>();

        ////Acts as a falg to detrrmine whow entries are saved when the SAVE button is
        ////pressed. If TRUE it will save as a new record, if FALSE it will try to update
        ////the currently displayed record.
        bool isNewEntry = true;

        public TeamPanel()
        {
            InitializeComponent();
            UpdateDataGrid();
        }

        /// <summary>
        /// Retrives all the team records from the DB and displays them in the data grid.
        /// </summary>
        private void UpdateDataGrid()
        {
            teamList = data.GetAllTeams();
            dgvTeams.ItemsSource = teamList;
            dgvTeams.Items.Refresh();
        }

        /// <summary>
        /// Event triggered by the new button is pressed to clear the form.
        /// </summary>
        /// <param name="sender">The object triggering the event</param>
        /// <param name="e">Any paramaters passed when the event is triggered by its component</param>
        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            ClearEntryField();
        }

        /// <summary>
        /// method to clear all the data entry fields back to blank.
        /// </summary>
        private void ClearEntryField()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtPrimaryContact.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtCompPoints.Text = "";
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

            //Reads all the details from the data entry fields and stores them in the team object for saving
            Teams teamEntry = new Teams();
            teamEntry.Name = txtName.Text;
            teamEntry.PrimaryContact = txtPrimaryContact.Text;
            teamEntry.Phone = txtPhone.Text;
            teamEntry.Email = txtEmail.Text;
            teamEntry.CompPoints = Convert.ToInt32(txtCompPoints.Text);

            //Save a new entry
            if (isNewEntry)
            {
                data.AddNewTeam(teamEntry);
            }
            //Update the existing entry
            else
            {
                teamEntry.Id = int.Parse(txtId.Text);
                data.UpdateTeam(teamEntry);
            }

            ClearEntryField();
            UpdateDataGrid();
        }

        /// <summary>
        /// Checks whether each field in the data entry form has valid data selected/entered 
        /// and returns false if any field is blank or containt invalid data.
        /// </summary>
        /// <returns>Whether the current data in the entry fields is valid or not.</returns>
        private bool AreFieldsFilledCorrectly()
        {
            if (String.IsNullOrEmpty(txtName.Text))
            {
                return false;
            }
            if (String.IsNullOrEmpty(txtPrimaryContact.Text))
            {
                return false;
            }
            if (String.IsNullOrEmpty(txtPhone.Text))
            {
                return false;
            }
            if (String.IsNullOrEmpty(txtEmail.Text))
            {
                return false;
            }
            int temp;
            if (!Int32.TryParse(txtCompPoints.Text, out temp) || temp < 0)
            {
                return false;
            }
            return true;
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
            if (dgvTeams.SelectedIndex < 0)
            {
                return;
            }
            // Display the warning message whether the user uses the team record in the result records.
            MessageBoxResult response = MessageBox.Show($"If {teamList[dgvTeams.SelectedIndex].Name} is used in the team result record," +
                $"{teamList[dgvTeams.SelectedIndex].Name} can't be deleted. " +
                $"\nPlease delete the result record first. \nIf No, Click Yes to proceed", 
                "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            try
            {
                // If the user selected Yes, proceed the step for deletion
                if (response == MessageBoxResult.Yes)
                {
                    //Displays message box to user asking to confirm deletion of selected entry.
                    //This message box stores the selected response from the user.
                    MessageBoxResult answer = MessageBox.Show($"Delete {teamList[dgvTeams.SelectedIndex].Name}?",
                    "Delete Confirmation", MessageBoxButton.YesNo);
                    //If the user response was a yes/confirmation response the delete proceeds.
                    if (answer == MessageBoxResult.Yes)
                    {
                        //Retrieves the primary key from the currently slected row
                        int id = teamList[dgvTeams.SelectedIndex].Id;
                        //Pass the desired primary key to the delete method to trigger deletion from database.
                        data.DeleteTeam(id);
                        //Clears and refreshes UI and confirms the deletion with the user via message box.
                        ClearEntryField();
                        UpdateDataGrid();
                        MessageBox.Show("Record Deleted.");
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Event triggered when the selected record of the data grid is changed 
        /// by either selecting or unselecting a row. 
        /// </summary>
        /// <param name="sender">The component triggering the the event.</param>
        /// <param name="e">Details fo the event passed by the calling component.</param>
        private void dgvTeams_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Make sure the table has a valid row currently selected
            if (dgvTeams.SelectedIndex < 0)
            {
                return;
            }
            //Grab the Id(primary key) from the entry in the list that matcheds the row
            //selected in the table.
            int id = teamList[dgvTeams.SelectedIndex].Id;
            //Retreieve the team record from the database that matches the selected id.
            Teams selectedTeam = data.GetTeamById(id);
            // If the selected record is null, diplay an error message
            if (selectedTeam == null)
            {
                MessageBox.Show("Something went wrong. \nPlease try again");
                UpdateDataGrid();
                return;
            }
            //Set the text fields to match the values in the model for their associated properties.
            txtId.Text = selectedTeam.Id.ToString();
            txtName.Text = selectedTeam.Name;
            txtPrimaryContact.Text = selectedTeam.PrimaryContact;
            txtPhone.Text = selectedTeam.Phone;
            txtEmail.Text = selectedTeam.Email;
            txtCompPoints.Text = selectedTeam.CompPoints.ToString();
            //Set the save mode to update.
            isNewEntry = false;

        }
 
    }
}
