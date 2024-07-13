using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
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
using System.Xml.Linq;
using DataManagement;
using DataManagement.Model;
using Microsoft.Win32;

namespace KiddEsports
{
    /// <summary>
    /// Interaction logic for Reports.xaml
    /// </summary>
    public partial class Reports : Window
    {
        //Databse connection object to manage all data interactions.
        DataAdapter data = new DataAdapter();
        //List of options for reports combo box selction.
        List<string> reportOptions = new List<string>
        { "Team By Competition Points", "Team Result By Event", "Team Result By Team1" };
        //Lists to manage the filtering functionality of the result reports.
        //The full list holds all the entire records when initially retrieved from database.
        //The filters list is the state of the collection after applying the current filters.
        //The displaylist is the list used by the Data Grid to display whichever of the 2 lists is currently being used.
        //This list holds no data of its own and is just used keep a reference of the currently desired list when it is assigned.
        List<ResultView> fullResultViewList;
        List<ResultView> filteredResultViewsList = new List<ResultView>();
        List<ResultView> displayResultList;

        //Lists to manage the filtering functionality of the team reports.
        //The full list holds all the entire records when initially retrieved from database.
        //The filters list is the state of the collection after applying the current filters.
        //The displaylist is the list used by the Data Grid to display whichever of the 2 lists is currently being used.
        //This list holds no data of its own and is just used keep a reference of the currently desired list when it is assigned.
        List<Teams> fullTeamList;
        List<Teams> filteredTeamList = new List<Teams>();
        List<Teams> displayTeamList;

        public Reports()
        {
            InitializeComponent();

            //Assigns the list of options to the combo box.
            cboExport.ItemsSource = reportOptions;
        }


        
        private void cboExport_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //If the combo box is on the empty selection, do nothing.
            //Otherwise, retrieve and filter the required data according to the desired selection. 
            if (cboExport.SelectedIndex < 0)
            {
                return;
            }
            //If the combo box is selected "Team By Competition Points"
            else if (cboExport.SelectedIndex == 0)
            {
                //Retrieves the data from the database. 
                fullTeamList = data.GetAllTeams();
                //Using Linq, order the retrieved records by team's comp Points.
                fullTeamList = fullTeamList.OrderBy(s => s.CompPoints).ToList();
                DisplayActiveTeamList(fullTeamList);

            }
            //If the combo box is selected "Team Result By Event"
            else if (cboExport.SelectedIndex == 1)
            {
                //Retrieves the data from the database. 
                fullResultViewList = data.GetAllTeamResult();
                //Using Linq, order the retrieved result records order by Event .
                fullResultViewList = fullResultViewList.OrderBy(c => c.EventHeld).ToList();
                DisplayActiveResultList(fullResultViewList);
            }
            //If the combo box is selected "Team Result By Team1"
            else
            {
                //Retrieves the data from the database. 
                fullResultViewList = data.GetAllTeamResult();
                //Using Linq, order the retrieved records order by Team 1 name. 
                fullResultViewList = fullResultViewList.OrderByDescending(c => c.Team1).ToList();
                DisplayActiveResultList(fullResultViewList);
            }

            //Clear the text field.
            txtFilter.Text = "";
        }
        /// <summary>
        /// Display the team list on screen according to whichever version of the product list is desired(full or filtered) 
        /// </summary>
        /// <param name="activeList"> The list to be shown in the Data Grid</param>
        private void DisplayActiveTeamList(List<Teams> activeList)
        {
            displayTeamList = activeList;
            dgvReports.ItemsSource = displayTeamList;
            dgvReports.Items.Refresh();
        }

        /// <summary>
        /// Display the result list on screen according to whichever version of the product list is desired(full or filtered) 
        /// </summary>
        /// <param name="activeList"> The list to be shown in the Data Grid</param>
        private void DisplayActiveResultList(List<ResultView> activeList)
        {
            displayResultList = activeList;
            dgvReports.ItemsSource = displayResultList;
            dgvReports.Items.Refresh();
        }

        /// <summary>
        /// Event triggered when the Export button is pressed.
        /// </summary>
        /// <param name="sender">The object triggering the event</param>
        /// <param name="e">Any paramaters passed when the event is triggered by its component</param>
        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            //If no eport type is selected, do nothing and return.
            if (cboExport.SelectedIndex < 0)
            {
                return;
            }

            //Create save dialog object. This will eventually open the Windows file chooser to allow file name and location selection.
            SaveFileDialog saveDialog = new SaveFileDialog();
            //Sets the filters for the allowed file types of the dialog.
            //These are passed as a string in the following format: {File Description}|{extension type} with each fileter separated by a new pipe(|) character.
            saveDialog.Filter = "Comma Separated Values (.csv)|*.csv";
            //Sets the initial file directory when the dialog first opens. This version retrieves the filepath for the desktop directory.
            saveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            //If the dialog returns a true message(OK/SAVE button pressed) proceed with the saving procedure.
            //The Show dialog process wihtin the if statement, opens the file chooser.
            if (saveDialog.ShowDialog() == true)
            {
                //Save the data in comma separated format based uponn whether the selecter is on the customer(0 index) or product ( 1+ indexes).
                if (cboExport.SelectedIndex == 0)
                {
                    //Create stream writer to manage writing to file.
                    using (StreamWriter writer = new StreamWriter(saveDialog.FileName))
                    {
                        //Iterate through each item in the displayed team list and write them to file.
                        foreach (var item in displayTeamList)
                        {
                            writer.WriteLine($"{item.Id},{item.Name},{item.PrimaryContact},{item.Phone},{item.Email},{item.CompPoints}");
                        }
                    }
                }
                else
                {
                    //Create stream writer to manage writing to file.
                    using (StreamWriter writer = new StreamWriter(saveDialog.FileName))
                    {
                        //Iterate through each item in the displayed result list and write them to file.
                        foreach (var item in displayResultList)
                        {
                            writer.WriteLine($"{item.Id},{item.EventHeld},{item.GamePlayed},{item.Team1},{item.Team2},{item.Result}");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Event which triggers when the text in the search text field changes.
        /// </summary>
        /// <param name="sender">The object triggering the event</param>
        /// <param name="e">Any paramaters passed when the event is triggered by its component</param>
        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            //If no report type is selected, do nothing.
            if (cboExport.SelectedIndex < 0)
            {
                return;
            }

            //If the combo box is selected "Team By Competition Points"(Index 0), filter the team list.
            if (cboExport.SelectedIndex == 0)
            {
                //If no text is in the search field, display the full list.
                if (String.IsNullOrWhiteSpace(txtFilter.Text))
                {
                    DisplayActiveTeamList(fullTeamList);
                    return;
                }

                //Filter list using Linq to copy all the team name contain contents of the search field.
                Teams searchEntry = new Teams();
                searchEntry.Name = txtFilter.Text;
                filteredTeamList = data.SearchTeamByName(searchEntry.ToString());
                string name = txtFilter.Text;
                filteredTeamList = data.SearchTeamByName(name);
                DisplayActiveTeamList(filteredTeamList);
            }

            //If the combo box is selected "Team Result By Event" or "Team Result By Team1" (Indexes 1+),
            //filter the result list.
            if (cboExport.SelectedIndex > 0)
            {
                //If no text is in the search field, display the full list.
                if (string.IsNullOrWhiteSpace(txtFilter.Text))
                {
                    DisplayActiveResultList(fullResultViewList);
                    return;
                }
                //Filter list using Linq to copy all the team 1 name contain contents of the search field.
                ResultView searchEntry = new ResultView();
                searchEntry.Team1 = txtFilter.Text;
                filteredResultViewsList = data.SearchResultByTeamName(searchEntry.ToString());
                string name = txtFilter.Text;
                filteredResultViewsList = data.SearchResultByTeamName(name);
                DisplayActiveResultList(filteredResultViewsList);
            }

        }

        private void dgvReports_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
