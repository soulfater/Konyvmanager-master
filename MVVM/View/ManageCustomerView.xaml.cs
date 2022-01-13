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
using Microsoft.Win32;
using System.IO;

namespace konyvManeger.MVVM.View
{
    /// <summary>
    /// Interaction logic for ManageCustomerView.xaml
    /// </summary>
    public partial class ManageCustomerView : UserControl
    {
        public ManageCustomerView()
        {
            InitializeComponent();
        }

        private void AddToList(object sender, RoutedEventArgs e)
        {
            string[] row = { Customer.Text, Book.Text, Date.Text };
            CustomerList.Items.Add(ItemsToRow(row));
        }

        private static string ItemsToRow(string[] row)
        {
            StringBuilder ItemRow = new StringBuilder();

            foreach (string Item in row)
            {
                ItemRow.Append(Item + " ");
            }

            return ItemRow.ToString();
        }

        private void DeleteItem(object sender, RoutedEventArgs e)
        {
            CustomerList.Items.RemoveAt(CustomerList.Items.IndexOf(CustomerList.SelectedItem));
        }

        private void DownloadCustomerList(object sender, RoutedEventArgs e)
        {
            SaveFile();
        }

        private void SaveFile()
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

                for (int i = 0; i < CustomerList.Items.Count; i ++)
                {
                    string listItem = CustomerList.Items[i].ToString();
                    save.WriteLine(listItem);
                }
                

                save.Dispose();
                save.Close();
            }
            FileName.Text = "FileName:" + " " + System.IO.Path.GetFileNameWithoutExtension(saveFile.FileName);
        }
    }
}
