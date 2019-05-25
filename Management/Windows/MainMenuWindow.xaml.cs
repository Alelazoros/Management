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

namespace Management
{

    /// Логика взаимодействия для MainMenuWindow.xaml
    public partial class MainMenuWindow : Window
    {
        public MainMenuWindow()
        {
            InitializeComponent();
        }


        /// Переход к окну создания нового клиента
        private void button_New_Client_Click(object sender, RoutedEventArgs e)
        {
            NewClientWindow ncw = new NewClientWindow();
            ncw.ShowDialog();
        }

        /// Переход к окну "Заказы"
        private void bt_Orders_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow ord_win = new OrderWindow();
            ord_win.ShowDialog();
        }

        /// Переход к окну "Клиенты"
        private void bt_Clients_Click(object sender, RoutedEventArgs e)
        {
            ClientsWindow cl_win = new ClientsWindow();
            cl_win.ShowDialog();
        }
    }
}
