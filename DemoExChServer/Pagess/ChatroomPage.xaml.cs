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
    /// Логика взаимодействия для ChatroomPage.xaml
    /// </summary>
    public partial class ChatroomPage : Page
    {
        public Chatroom room;
        public ChatroomPage(Chatroom chatroom)
        {
            InitializeComponent();
            room = chatroom;
            TopicBox.Text = room.Topic;
            LstUs.ItemsSource = App.bd.Empl_Chatr.Where(x => x.ID_Chatroom == room.ID_Chatroom).ToList();
            LstSMS.ItemsSource = App.bd.ChatMessage.Where(x => x.ID_ChatRoom == room.ID_Chatroom).ToList();
        }

        private void TopicBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter && (TopicBox.Text != "" || TopicBox.Text != " "))
            {
                room.Topic = TopicBox.Text;
                App.bd.SaveChanges();
                TopicBox.IsEnabled = false;
            }
        }

        private void AddUsBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EmployeeFindPage(room));
        }

        private void ChageTopicBtn_Click(object sender, RoutedEventArgs e)
        {
            TopicBox.IsEnabled = true;
        }

        private void LeaveChatroomBtn_Click(object sender, RoutedEventArgs e)
        {
            var item = App.bd.Empl_Chatr.Where(x => x.ID_Employee == App.employee.ID_Employee && x.ID_Chatroom == room.ID_Chatroom).FirstOrDefault();
            App.bd.Empl_Chatr.Remove(item);
            App.bd.SaveChanges();
            MessageBox.Show("Good!");
            NavigationService.Navigate(new LstChatPage());
        }

        private void SendBtn_Click(object sender, RoutedEventArgs e)
        {
            ChatMessage message = new ChatMessage();
            {
                message.ID_Employee = App.employee.ID_Employee;
                message.ID_ChatRoom = room.ID_Chatroom;
                message.Date = DateTime.Now;
                message.Message = TxtSMS.Text;
            }
            App.bd.ChatMessage.Add(message);
            App.bd.SaveChanges();
            LstSMS.ItemsSource = App.bd.ChatMessage.Where(x => x.ID_ChatRoom == room.ID_Chatroom).ToList();
            TxtSMS.Text = "";
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LstChatPage());
        }
    }
}
