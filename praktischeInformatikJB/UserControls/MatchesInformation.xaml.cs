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

namespace praktischeInformatikJB.UserControls
{
    /// <summary>
    /// Interaktionslogik für MatchesInformation.xaml
    /// </summary>
    public partial class MatchesInformation : UserControl
    {
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public string KickOff { get; set; }
        public MatchesInformation()
        {
            HomeTeam = "Home Team Name";
            AwayTeam = "Away Team Name";
            KickOff = "Match Kickoff Time";
            InitializeComponent();
            DataContext = this;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
