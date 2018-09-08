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
    /// Логика взаимодействия для AddEditTour.xaml
    /// </summary>
    public partial class AddEditTour : Window
    {
        public AddEditTour()
        {
            InitializeComponent();
        }

        Facade f;
        TourismDB db;
        DataGrid datagrid;
        bool edit;
        int index;

        public AddEditTour(TourismDB db, DataGrid datagrid, bool edit)
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
            Tours tours = db.Tours.ToList()[index];
            CountrytextBox.Text = tours.Country + "";
            ArrDatetextBox.Text = tours.ArrivalDate.ToString(CultureInfo.CurrentCulture);
            DepDatetextBox.Text = tours.DepartureDate.ToString(CultureInfo.CurrentCulture);
            CosttextBox.Text = tours.Tour_cost.ToString();
            PeopletextBox.Text = tours.NumberOfPersons.ToString();
            TypetextBox.Text = tours.Type + "";
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (edit)
                {
                    f.edd.EditTour(index, new Tours(CountrytextBox.Text, DateTime.Parse(ArrDatetextBox.Text), DateTime.Parse(DepDatetextBox.Text), double.Parse(CosttextBox.Text), int.Parse(PeopletextBox.Text), TypetextBox.Text));
                }
                else
                {
                    f.add.AddTour(new Tours(CountrytextBox.Text, DateTime.Parse(ArrDatetextBox.Text), DateTime.Parse(DepDatetextBox.Text), double.Parse(CosttextBox.Text), int.Parse(PeopletextBox.Text), TypetextBox.Text));
                }
            }
            catch (Exception) { MessageBox.Show("Неплохая попытка..."); }
            this.Close();
        }
    }
}
