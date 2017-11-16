using Microsoft.Win32;
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

namespace Sushi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel a;

        public MainWindow()
        {
            InitializeComponent();
            a = new ViewModel("1.txt");
            this.DataContext = a;
        }
        
        public void DeleteFromList(object Sender, RoutedEventArgs e)
        {
            a.Delete();
        }
        public void SaveCurrentList(object Sender, RoutedEventArgs e)
        {
            a.Save();
        }
        public void UploadFromFile(object Sender, RoutedEventArgs e)
        {
            a.Upload();
        }
        public void UploadFile(object Sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.DefaultExt = ".txt";
            dialog.Filter = "Text document (.txt)|*.txt";
            if(dialog.ShowDialog()==true)
            {
                a.Path = dialog.FileName;
            }
        }
    }
}
