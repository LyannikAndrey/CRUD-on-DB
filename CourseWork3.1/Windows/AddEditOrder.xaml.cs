using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Логика взаимодействия для AddEditOrder.xaml
    /// </summary>
    public partial class AddEditOrder : Window
    {
        public AddEditOrder()
        {
            InitializeComponent();
        }

        Facade f;
        TourismDB db;
        DataGrid datagrid;
        bool edit;
        int index;

        public AddEditOrder(TourismDB db, DataGrid datagrid, bool edit)
        {
            InitializeComponent();
            this.db = db;
            this.datagrid = datagrid;
            f = new Facade(db, datagrid);
            this.edit = edit;
            this.index = datagrid.SelectedIndex;
            ClientcomboBox.ItemsSource = db.Clients.ToList();
            TourcomboBox.ItemsSource = db.Tours.ToList();
            EmplcomboBox.ItemsSource = db.Employees.ToList();
            if (edit)
                Init();
        }

        void Init()
        {
            Orders t = db.Orders.ToList()[index];
            DatetextBox.Text = t.DateOfRegistration.ToString(CultureInfo.CurrentCulture);
            ClientcomboBox.SelectedItem = t.Clients;
            TourcomboBox.SelectedItem = t.Tours;
            EmplcomboBox.SelectedItem = t.Employees;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (edit)
                {
                    f.edd.EditOrder(index, new Orders(((Clients)ClientcomboBox.SelectedItem).Client_ID, ((Tours)TourcomboBox.SelectedItem).Tour_ID, DateTime.Parse(DatetextBox.Text), ((Employees)EmplcomboBox.SelectedItem).Employee_ID));
                }
                else
                {
                    f.add.AddOrder(new Orders(((Clients)ClientcomboBox.SelectedItem).Client_ID, ((Tours)TourcomboBox.SelectedItem).Tour_ID, DateTime.Parse(DatetextBox.Text), ((Employees)EmplcomboBox.SelectedItem).Employee_ID));
                }
            }
            catch (Exception) { MessageBox.Show("Неплохая попытка..."); }
            this.Close();
        }
    }
}
