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
using System.Windows.Shapes;
using CourseWork3._1.BusinessLogic;
using CourseWork3._1.Models;

namespace CourseWork3._1.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditClient.xaml
    /// </summary>
    public partial class AddEditClient : Window
    {
        public AddEditClient()
        {
            InitializeComponent();
        }
        Facade f;
        TourismDB db;
        DataGrid datagrid;
        bool edit;
        int index;

        public AddEditClient(TourismDB db, DataGrid datagrid, bool edit)
        {
            InitializeComponent();
            this.db = db;
            this.datagrid = datagrid;
            f = new Facade(db, datagrid);
            this.edit = edit;
            this.index = datagrid.SelectedIndex;
            if (edit)
                Init();
        }

        void Init()
        {
            Clients cl = db.Clients.ToList()[index];
            SurnameTextBox.Text = cl.Surname + "";
            NameTextBox.Text = cl.Name + "";
            PatronymicTextBox.Text = cl.Patronymic + "";
            PhoneTextBox.Text = cl.Phone + "";
            EmailTextBox.Text = cl.Email + "";
            AddressTextBox.Text = cl.Address + "";
        }


        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (edit)
                {
                    f.edd.EditClient(index, new Clients(SurnameTextBox.Text, NameTextBox.Text, PatronymicTextBox.Text, PhoneTextBox.Text, EmailTextBox.Text, AddressTextBox.Text));
                }
                else
                {
                    f.add.AddClient(new Clients(SurnameTextBox.Text, NameTextBox.Text, PatronymicTextBox.Text, PhoneTextBox.Text, EmailTextBox.Text, AddressTextBox.Text));
                }
            }
            catch (Exception) { MessageBox.Show("Error!"); }
            this.Close();
        }
    }
}
