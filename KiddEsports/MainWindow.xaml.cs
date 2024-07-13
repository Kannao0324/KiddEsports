using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            conMain.Content = new TeamPanel();
        }

        /// <summary>
        /// Event triggered when the GamePlayed button is pressed. 
        /// </summary>
        /// <param name="sender">The component triggering the the event.</param>
        /// <param name="e">Details fo the event passed by the calling component.</param>
        private void btnGamePlayed_Click(object sender, RoutedEventArgs e)
        {
            conMain.Content = new GamePlayedPanel();
        }

        /// <summary>
        /// Event triggered when the TeamResult button is pressed. 
        /// </summary>
        /// <param name="sender">The component triggering the the event.</param>
        /// <param name="e">Details fo the event passed by the calling component.</param>
        private void btnTeamResults_Click(object sender, RoutedEventArgs e)
        {
            conMain.Content = new ResultInput();
        }

        /// <summary>
        /// Event triggered when the Team button is pressed. 
        /// </summary>
        /// <param name="sender">The component triggering the the event.</param>
        /// <param name="e">Details fo the event passed by the calling component.</param>
        private void btnTeams_Click(object sender, RoutedEventArgs e)
        {
            conMain.Content = new TeamPanel();
        }

        /// <summary>
        /// Event triggered when the Event button is pressed. 
        /// </summary>
        /// <param name="sender">The component triggering the the event.</param>
        /// <param name="e">Details fo the event passed by the calling component.</param>
        private void btnEvents_Click(object sender, RoutedEventArgs e)
        {
            conMain.Content = new EventsPanel();
        }

        /// <summary>
        /// Event triggered when the Report button is pressed. 
        /// </summary>
        /// <param name="sender">The component triggering the the event.</param>
        /// <param name="e">Details fo the event passed by the calling component.</param>
        private void btnReports_Click(object sender, RoutedEventArgs e)
        {
            //Open a new window for exporting the report
            Reports reportWindow = new Reports();   
            reportWindow.ShowDialog();
        }

        
    }
}