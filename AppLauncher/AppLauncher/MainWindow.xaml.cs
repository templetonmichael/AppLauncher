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

namespace AppLauncher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<UserApplication> Applications = new List<UserApplication>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var explorer = new Microsoft.Win32.OpenFileDialog();
            explorer.DefaultExt = ".exe";
            explorer.Filter = "Executables (*.exe)|*.exe";

            var result = explorer.ShowDialog();

            if (result == true)
            {
                string filePath = explorer.FileName;
                var newApp = new UserApplication(filePath);
                Applications.Add(newApp);

                var newListItem = new ListBoxItem();
                newListItem.Content = newApp.Display();
                AppList.Items.Add(newListItem);
            }

        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selected = AppList.Items.IndexOf(AppList.SelectedItem);
                AppList.Items.RemoveAt(selected);

                var result = AppList.SelectedItems.First.Substring(str.LastIndexOf('\t') + 1);

            }
            catch
            {
                return;
            }
        }
    }
}
