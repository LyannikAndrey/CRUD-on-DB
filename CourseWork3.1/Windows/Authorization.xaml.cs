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

namespace CourseWork3._1.Windows
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (LogintextBox.Text == "admin" && passwordBox.Password == "admin")
            {
                MainWindow mw = new MainWindow(true);
                mw.Show();
                this.Close();
                return;
            }
            if (LogintextBox.Text == "user" && passwordBox.Password == "user")
            {
                MainWindow mw = new MainWindow(false);
                mw.Show();
                this.Close();
                return;
            }
            MessageBox.Show("Неверный логин или пароль.");
        }
    }
}
