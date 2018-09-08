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
    /// Логика взаимодействия для AddEditTour_point.xaml
    /// </summary>
    public partial class AddEditTour_point : Window
    {
        public AddEditTour_point()
        {
            InitializeComponent();
        }

        Facade f;
        TourismDB db;
        DataGrid datagrid;
        bool edit;
        int index;

        public AddEditTour_point(TourismDB db, DataGrid datagrid, bool edit)
        {
            InitializeComponent();
            this.db = db;
            this.datagrid = datagrid;
            f = new Facade(db, datagrid);
            this.edit = edit;
            this.index = datagrid.SelectedIndex;
            CountrycomboBox.ItemsSource = db.Tours.ToList();
            HotelcomboBox.ItemsSource = db.Hotels.ToList();
            TranscomboBox.ItemsSource = db.Transports.ToList();
            if (edit)
                Init();
        }

        void Init()
        {
            Tour_point tourPoint = db.Tour_point.ToList()[index];
            CitytextBox.Text = tourPoint.City + "";
            CountrycomboBox.SelectedItem = tourPoint.Tours;
            HotelcomboBox.SelectedItem = tourPoint.Hotels;
            TranscomboBox.SelectedItem = tourPoint.Transports;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (edit)
                {
                    f.edd.EditTour_Point(index, new Tour_point(((Tours)CountrycomboBox.SelectedItem).Tour_ID, ((Hotels)HotelcomboBox.SelectedItem).Hotel_ID, ((Transports)TranscomboBox.SelectedItem).Transport_ID, CitytextBox.Text));
                }
                else
                {
                    f.add.AddTour_point(new Tour_point(((Tours)CountrycomboBox.SelectedItem).Tour_ID, ((Hotels)HotelcomboBox.SelectedItem).Hotel_ID, ((Transports)TranscomboBox.SelectedItem).Transport_ID, CitytextBox.Text));
                }
            }
            catch (Exception) { MessageBox.Show("Неплохая попытка..."); }
            this.Close();
        }
    }
}
