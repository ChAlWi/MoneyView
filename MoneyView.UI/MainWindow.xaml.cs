using System.Windows;
using MoneyView.UI.Views;

namespace MoneyView.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IHaveOverviewOfAccountMovement _mainWindow;

        public MainWindow(IHaveOverviewOfAccountMovement mainWindow)
        {
            _mainWindow = mainWindow;
            InitializeComponent();
            this.Content = _mainWindow;
        }
    }
}
