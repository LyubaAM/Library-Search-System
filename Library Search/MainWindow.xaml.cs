using Library_Search.DataAccess;
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

namespace Library_Search
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //private async void btnSearch_Click(object sender, RoutedEventArgs e)
        //{
        //    int cmbSelectedIndex = cmbSearchCriteria.SelectedIndex;
        //    Models.Books result = await HttpDataAccess.GetStringAsync("https://openlibrary.org/search.json?title=the+lord+of+the+rings");

        //    int i = 4;
        //}
    }
}
