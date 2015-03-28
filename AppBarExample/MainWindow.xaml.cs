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
using WpfAppBar;

namespace AppBarExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool appBar = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void toggleAppbar(object sender, RoutedEventArgs e)
        {
            if (appBar == false)
            {
                appBar = true;
                AppBarFunctions.SetAppBar(this, ABEdge.Right);
            }
            else
            {
                appBar = false;
                AppBarFunctions.SetAppBar(this, ABEdge.None);
            }
            
        }
    }
}
