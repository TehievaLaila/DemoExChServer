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
    /// Логика взаимодействия для LstChatPage.xaml
    /// </summary>
    public partial class LstChatPage : Page
    {
        public LstChatPage()
        {
            InitializeComponent();
            LstChatV.ItemsSource = App.bd.Empl_Chatr.Where(x => x.ID_Employee == App.employee.ID_Employee).ToList();
            UsNameBlock.Text = App.employee.Name;
        }

        private void LstChatV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var Chat = LstChatV.SelectedItem as Empl_Chatr;
                var item = App.bd.Chatroom.Where(x => x.ID_Chatroom == Chat.ID_Chatroom).FirstOrDefault();
                NavigationService.Navigate(new ChatroomPage(item));
            }
            catch (Exception ex) {MessageBox.Show($"{ex}"); }
        }

        private void CloseApplicBTN_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void EmployeeFinderBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EmployeeFindPage());
        }
    }
}
