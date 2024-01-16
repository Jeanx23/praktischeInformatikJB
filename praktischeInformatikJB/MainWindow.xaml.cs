using praktischeInformatikJB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace praktischeInformatikJB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel _viewModel;
        private readonly SplashScreenWindow _splashScreen;

        public MainWindow()
        {
            _splashScreen = new SplashScreenWindow();
            _splashScreen.Show();

            // Event-Handler für das Loaded-Event
            Loaded += MainWindow_Loaded;

            _viewModel = new MainWindowViewModel();
            this.DataContext = _viewModel;    
            InitializeComponent();         
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Entferne den Loaded-Event-Handler, um zu verhindern, dass er erneut aufgerufen wird
            Loaded -= MainWindow_Loaded;

            // Verstecke den Splash Screen, da _viewModel bereits initialisiert ist
            _splashScreen.Close();
        }
    }
}
