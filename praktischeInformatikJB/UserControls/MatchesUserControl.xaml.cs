using CommunityToolkit.Mvvm.ComponentModel;
using praktischeInformatikJB.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaktionslogik für MatchesUserControl.xaml
    /// </summary>
    public partial class MatchesUserControl : UserControl
    {
        public static readonly DependencyProperty MatchesProperty =
            DependencyProperty.Register(nameof(Matches), typeof(List<MatchViewModel>), typeof(MatchesUserControl), new PropertyMetadata(null));

        public List<MatchViewModel> Matches
        {
            get { return (List<MatchViewModel>)GetValue(MatchesProperty); }
            set { SetValue(MatchesProperty, value); }
        }

        public MatchesUserControl()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}
