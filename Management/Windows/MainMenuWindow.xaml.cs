using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using Management.Repository;
using Management.DataAccess;
using Management.DataModel;

namespace Management
{

    /// Логика взаимодействия для MainMenuWindow.xaml
    public partial class MainMenuWindow : Window
    {
        public MainMenuWindow()
        {
            InitializeComponent();
        }

/*
        /// Переход к окну создания нового клиента
        private void button_New_Client_Click(object sender, RoutedEventArgs e)
        {
            NewClientWindow ncw = new NewClientWindow();
            ncw.ShowDialog();
        }
*/
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
