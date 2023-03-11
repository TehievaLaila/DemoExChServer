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
using DemoExChServer.DB;

namespace DemoExChServer.Pagess
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            var user = App.bd.Employee.Where(x => x.Username == UsNameBox.Text && x.Password == PassBox.Password).FirstOrDefault();
            if (user != null)
            {
                App.employee = user;
                MessageBox.Show($"Welcome, {user.Username}");
                NavigationService.Navigate(new LstChatPage());
            }
            else
            {
                MessageBox.Show("Not correct");
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
