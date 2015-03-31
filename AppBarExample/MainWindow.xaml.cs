using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using WpfAppBar;
using dragonz.actb.core;
using dragonz.actb.provider;

namespace RakutenDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool appBar = false;

        private AutoCompleteManager _acmBingSuggestion;

        public MainWindow()
        {
            InitializeComponent();

            //
            _acmBingSuggestion = new AutoCompleteManager(txtSearch);
            _acmBingSuggestion.DataProvider = new BingSuggestionProvider();
            _acmBingSuggestion.Asynchronous = true;
            txtSearch.KeyDown += txtBingSearch_KeyDown;
        }

        void txtBingSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                RakutenWebSearch(txtSearch.Text);
            }
            else if (e.Key == Key.Right) 
            {
                PopupButton.StaysOpen = true;
                PopupButton.IsOpen = true;
            }
        }

        void BringPopup(object sender, MouseEventArgs e)
        {
            PopupButton.StaysOpen = true;
            PopupButton.IsOpen = true;
        }

        void ClearPopup(object sender, MouseEventArgs e)
        {
            disappearPopup();
        }

        private void RakutenWebSearch(string text)
        {
            Process.Start("http://websearch.rakuten.co.jp/Web?qt=" + HttpUtility.UrlEncode(text) + "&ref=chexti&tool_id=1&col=OW");
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

        private void FrameMovable(object sender, MouseButtonEventArgs e)
        {
            if (appBar == false)
            {
                this.DragMove();
            }
            disappearPopup();
        }

        private void disappearPopup()
        {
            PopupButton.StaysOpen = false;
            PopupButton.IsOpen = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // ... Load this site.
            //RakutenBrowser.Navigate("http://msg.websearch.rakuten.co.jp/view/LatestMsg?mv=3.1R");
        }
    }
}
