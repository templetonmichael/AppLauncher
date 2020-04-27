using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;

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
            try
            {
                var jsonText = File.ReadAllText(GetJsonFilePath());
                Applications = JsonConvert.DeserializeObject<List<UserApplication>>(jsonText);
                refreshList();
            }
            catch
            {

            }
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
                updateJsonFile();
                refreshList();
            }

        }

        private void updateJsonFile()
        {
            try
            {
                var appJson = JsonConvert.SerializeObject(Applications);
                string jsonPath = GetJsonFilePath();
                File.WriteAllText(jsonPath, appJson);
            }
            catch
            {
                Console.WriteLine("The application has failed for an unkown reason, please restart.");
            }

        }

        private void refreshList()
        {
            AppList.Items.Clear();
            foreach (var application in Applications)
            {
                var listItem = new ListBoxItem();
                listItem.Content = application.Display();
                AppList.Items.Add(listItem);
            }
        }
        private static string GetJsonFilePath()
        {
            return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Applications.json");
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selected = AppList.SelectedItem as ListBoxItem;
                Applications.RemoveAll(app => app.Display() == selected.Content.ToString());
                updateJsonFile();
                refreshList();
            }
            catch
            {
                return;
            }
        }

        private void Launch_Click(object sender, RoutedEventArgs e)
        {
            foreach (var app in Applications)
            {
                app.Process.Start();
            }

        }
    }
}
