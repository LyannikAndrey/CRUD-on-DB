using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using CourseWork3._1.BusinessLogic;
using CourseWork3._1.Models;
using CourseWork3._1.Windows;

namespace CourseWork3._1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TourismDB db;
        Facade f;
        bool admin;

        public MainWindow()
        {
            InitializeComponent();
            db = new TourismDB();
            f = new Facade(db, dataGrid, TableComboBox, SearchComboBox, SearchTextBox);
        }

        public MainWindow(bool admin)
        {
            this.admin = admin;
            InitializeComponent();
            db = new TourismDB();
            f = new Facade(db, dataGrid, TableComboBox, SearchComboBox, SearchTextBox);
            if (admin == false)
                DeactivateButons();
        }

        private void DeactivateButons()
        {
            AddButton.IsEnabled = false;
            EditButton.IsEnabled = false;
            DeleteButton.IsEnabled = false;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            f.Add();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            f.Edit();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                f.Delete();
            }
            catch (Exception) { MessageBox.Show("Выберите элемент для удаления"); }
        }

        private void ShowTableButton_Click(object sender, RoutedEventArgs e)
        {
            f.ShowTables();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                f.Search();
            }
            catch { MessageBox.Show("Некорректные данные для поиска"); }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Authorization aut = new Authorization();
            aut.Show();
            this.Close();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Process.Start("Help.pdf");
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Разработчник Лянник Андрей\nГруппа КН - 34В", "Информация о разработчике", new MessageBoxButton());
        }
    }
}
