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

namespace konyvManeger.MVVM.View
{
    /// <summary>
    /// Interaction logic for ManageBooksView.xaml
    /// </summary>
    public partial class ManageBooksView : UserControl
    {
        public ManageBooksView()
        {
            InitializeComponent();
        }

        private void AddNewBook(object sender, RoutedEventArgs e)
        { 
            string[] row = { Title.Text, Author.Text, ISBNnum.Text };
            BookList.Items.Add(ItemsTORow(row));

        }

        private static string ItemsTORow(string[] row)
        {
            StringBuilder ItemRow = new StringBuilder();

            foreach (string Item in row)
            {
                ItemRow.Append(Item + " ");
            }

            return ItemRow.ToString();
        }

        private void RemoveBook(object sender, RoutedEventArgs e)
        {
            BookList.Items.RemoveAt(BookList.Items.IndexOf(BookList.SelectedItem));
        }


        private void SaveBookFile()
        {
            SaveFileDialog saveFile = new SaveFileDialog()
            {
                Title = "Save File",
                Filter = "Text Document (*.txt) | *.txt",
                FileName = " "

            };

            if (saveFile.ShowDialog() == true)
            {
                StreamWriter save  = new StreamWriter(File.Create(saveFile.FileName));

               string[] fileRow = new string[] {};

                for (int i = 0; i < BookList.Items.Count; i ++)
                {
                    string listItem = BookList.Items[i].ToString();
                    save.WriteLine(listItem);
                }
                

                save.Dispose();
                save.Close();
            }
            FileName.Text = "FileName:" + " " + System.IO.Path.GetFileNameWithoutExtension(saveFile.FileName);
        }

        private void DownloadBooks(object sender, RoutedEventArgs e)
        {
            SaveBookFile();
        }
    }
}
