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
    /// Логика взаимодействия для EmployeeFindPage.xaml
    /// </summary>
    public partial class EmployeeFindPage : Page
    {
        Chatroom room;
        public EmployeeFindPage()
        {
            InitializeComponent();
        }
        public EmployeeFindPage(Chatroom chatroom)
        {
            InitializeComponent();
            room = chatroom;
        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (room != null)
            {
                NavigationService.Navigate(new ChatroomPage(room));
            }
            else
            {
                NavigationService.Navigate(new LstChatPage());
            }
        }
        private void SearchEmployee_TextChanged(object sender, TextChangedEventArgs e)
        {
            var search = App.bd.Employee.Where(x => x.Name.Contains(SearchEmployee.Text.ToLower())).ToList();
            LstEmpl.ItemsSource = search.ToList();
        }

        private void LstEmpl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = LstEmpl.SelectedItem as Employee;
            if(room !=null)
            {
                Empl_Chatr chroom = new Empl_Chatr();
                {
                    chroom.ID_Chatroom = room.ID_Chatroom;
                    chroom.ID_Employee = item.ID_Employee;
                }
                App.bd.Empl_Chatr.Add(chroom);
                App.bd.SaveChanges();
                MessageBox.Show("Employee added!");
            }
            else
            {
                try
                {
                    Chatroom chatroom = new Chatroom();
                    {
                        chatroom.Topic = item.Name;
                    }
                    App.bd.Chatroom.Add(chatroom);
                    App.bd.SaveChanges();
                    Empl_Chatr empl_chatr = new Empl_Chatr();
                    {
                        empl_chatr.ID_Chatroom = chatroom.ID_Chatroom;
                        empl_chatr.ID_Employee = item.ID_Employee;
                    }
                    Empl_Chatr empl_chatr2 = new Empl_Chatr();
                    {
                        empl_chatr2.ID_Chatroom = chatroom.ID_Chatroom;
                        empl_chatr2.ID_Employee = App.employee.ID_Employee;
                    }
                    App.bd.Empl_Chatr.Add(empl_chatr);
                    App.bd.Empl_Chatr.Add(empl_chatr2);
                    App.bd.SaveChanges();
                    NavigationService.Navigate(new ChatroomPage(chatroom));
                }
                catch(Exception ex) { MessageBox.Show($"{ex}"); }
            }
        }
    }
}
