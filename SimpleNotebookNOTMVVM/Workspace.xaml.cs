using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

namespace SimpleNotebookNOTMVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Workspace : Window
    {
        string path = "";
        public Workspace()
        {
            InitializeComponent();
        }

        #region Menu File
        private void MI_NewFile_Click(object sender, RoutedEventArgs e)
        {
            TB_Note.Clear();
        }

        private void MI_OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new()
            {
                Filter = "Text Files (.txt)|.txt" 
            };
            if (dialog.ShowDialog() == true)
            {
                path = dialog.FileName;
                StreamReader reader = new(path);
                string data = reader.ReadToEnd();
                TB_Note.Text = data;
                reader.Close();
            }
        }

        private void MI_SaveFile_Click(object sender, RoutedEventArgs e)
        {
            string data = TB_Note.Text;
            SaveFileDialog dialog = new()
            {
                Filter = "Text Files (.txt)|.txt"
            };
            if (dialog.ShowDialog() == true)
            {
                path = dialog.FileName;
                StreamWriter writer = new(path);
                writer.Write(data);
                writer.Flush();
                writer.Close();
            }    
        }

        private void Mi_Exit_Click(object sender, RoutedEventArgs e)
        {
            _ = this;
            Close();
        }

        #endregion
        #region Menu Edit
        private void MI_Indo_Click(object sender, RoutedEventArgs e)
        {
            TB_Note.Undo();
        }

        private void MI_Redo_Click(object sender, RoutedEventArgs e)
        {
            TB_Note.Redo();
            MI_Redo.IsEnabled = false;
            MI_Indo.IsEnabled = true;
        }
        #endregion
        
        private void MI_ProgrammInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("SimpleNotebook was made for practice");
        }

        private void MI_VersionInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Version 1.0");
        }

        private void MI_Bonus_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Not bonus for you!");
        }
    }
}
