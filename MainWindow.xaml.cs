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
using System.Collections.ObjectModel;
using System.Security.Policy;
using System.Data;

namespace Lab5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Notebook notebook = new Notebook();
        //public static List<Contact> FoundRecords;
        public static int EditIndex = -1;
        public static bool IsNew = false;
        public MainWindow()
        {
            InitializeComponent();
            notebook.LoadFromXML();
            grid1.ItemsSource = notebook.AllRecords;
        }

        private void grid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {            
             EditIndex = notebook.AllRecords.IndexOf((Contact)grid1.SelectedItem);
             if (EditIndex >= 0)
             {
                 text_surname.Text = notebook.AllRecords[EditIndex].Surname;
                 text_name.Text = notebook.AllRecords[EditIndex].Name;
                 text_phone.Text = notebook.AllRecords[EditIndex].Phone;
                 text_email.Text = notebook.AllRecords[EditIndex].Email;
             }
            
        }

        private void addbutton_Click(object sender, RoutedEventArgs e)
        {
            text_surname.Text = "";
            text_name.Text = "";
            text_phone.Text = "";
            text_email.Text = "";
            IsNew = true;
            EditIndex = -1;
        }

        private void savebutton_Click(object sender, RoutedEventArgs e)
        {
            if (EditIndex >= 0)
            {
                notebook.UpdateContact(EditIndex, text_name.Text, text_surname.Text, text_phone.Text, text_email.Text);
                grid1.Items.Refresh();
            }
            else if (IsNew)
            {
                if (notebook.Add(text_name.Text, text_surname.Text, text_phone.Text, text_email.Text))
                {
                    grid1.Items.Refresh();
                    IsNew = false;
                }
            }
        }
    }
}
