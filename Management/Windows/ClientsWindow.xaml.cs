using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Management.Repository;
using Management.DataAccess;
using Management.DataModel;

namespace Management
{

    /// Логика взаимодействия для ClientsWindow.xaml
    public partial class ClientsWindow : Window
    {
        public ClientsWindow()
        {
            InitializeComponent();
        }

        struct Clients_Cards
        {
            public Clients client { get; set; }
            public Clients referer { get; set; }
            public Cards card { get; set; }
        }

        ClientsRepository oClientsRepository;
        CardsRepository oCardsRepository;

        Clients_Cards oClents_Cards;

        SQLite.SQLiteAsyncConnection conn;

        private async void Window_Loaded_Reg(object sender, RoutedEventArgs e)
        {
            DBConnection oDBConnection = new DBConnection();

            await oDBConnection.InitializeDatabase();

            oClientsRepository = new ClientsRepository(oDBConnection);
            oCardsRepository = new CardsRepository(oDBConnection);

            conn = oDBConnection.GetAsyncConnection();

            await Update_ListView();
        }


        /// Выделение Клиента в listview Клиентов ЛКМ. Заполнение полей texbox`ов данными выделенного клиента. Поиск и отображение ФИО реферера в textbox_Referer_Number
        private void listview_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                oClents_Cards = (Clients_Cards)listview_Clients_Cards.SelectedItem;

                grid.DataContext = oClents_Cards;
                //textbox_Referer_Number.IsEnabled = false;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Клиент не выбран!");
            }

        }

        /// Обновление содержимого ListView
        private async Task Update_ListView()
        {
            List<Clients_Cards> clientcard = new List<Clients_Cards>();

            List<Clients> result = await oClientsRepository.Select_All_Clients_Async();

            foreach (Clients client in result)
            {
                Clients_Cards cc = new Clients_Cards();
                cc.client = client;
                cc.card = await conn.GetAsync<Cards>(client.cards_id);

                if (client.referer_id != -1)
                {
                    cc.referer = await conn.GetAsync<Clients>(client.referer_id);
                }

                clientcard.Add(cc);
            }

            listview_Clients_Cards.ItemsSource = clientcard;

            Clear_Controls();
        }

        /// Обновление содержимого ListView
        private async Task Update_ListView(string text)
        {
            List<Clients_Cards> clientcard = new List<Clients_Cards>();

            List<Clients> result = await oClientsRepository.Select_All_Clients_Async();

            foreach (Clients client in result)
            {
                Clients_Cards cc = new Clients_Cards();
                cc.client = client;
                cc.card = await conn.GetAsync<Cards>(client.cards_id);

                if (client.referer_id != -1)
                {
                    cc.referer = await conn.GetAsync<Clients>(client.referer_id);
                }

                if (client.full_name.ToLower().Contains(text.ToLower()) || client.phone_number.ToLower().Contains(text.ToLower()) || client.email.ToLower().Contains(text.ToLower()))
                {
                    clientcard.Add(cc);
                }
            }

            listview_Clients_Cards.ItemsSource = clientcard;

            Clear_Controls();
        }

        private void Clear_Controls()
        {
            //grid.DataContext = null;

            textbox_Full_Name.Text = "";
            textbox_Address.Text = "";
            textbox_Phone_Number.Text = "";
            textbox_Email.Text = "";
            //textbox_Referer_Number.Text = "";

            listview_Clients_Cards.SelectedIndex = -1;

            //button_Create.IsEnabled = true;
            //button_Update.IsEnabled = false;
            //textbox_Referer_Number.IsEnabled = true;
        }

        /// Нажатие клавиши "Создать"
        /// Создаёт в таблице запись Cards и Clients
        /// Связывает записи Cards и Clients
        /// Связывает Клиента с его реферером (не закончено)
        private async void button_Create_Click(object sender, RoutedEventArgs e)
        {
            {
                Cards card = new Cards();

                await oCardsRepository.Insert_Cards_Async(card);

                Clients client = new Clients(textbox_Full_Name.Text, textbox_Address.Text, textbox_Phone_Number.Text, textbox_Email.Text, card.cards_id);

                /*
                if (!String.IsNullOrWhiteSpace(textbox_Referer_Number.Text))
                {
                    List<Clients> lClients = await oClientsRepository.Select_All_Clients_Async();

                    foreach (var c in lClients)
                    {
                        if (c.referal_number.StartsWith(textbox_Referer_Number.Text))
                        {
                            client.referer_id = c.clients_id;

                            break;
                        }
                    }
                }
                */

                await oClientsRepository.Insert_Clients_Async(client);

                await Update_ListView();
            }
        }


        /// Нажатие клавиши обновления данных клиента
        /// Обновляет только поля с ФИО, Адресом, Телефоном и Email
        private async void button_Update_Click(object sender, RoutedEventArgs e)
        {
            oClents_Cards.client.full_name = textbox_Full_Name.Text;
            oClents_Cards.client.address = textbox_Address.Text;
            oClents_Cards.client.phone_number = textbox_Phone_Number.Text;
            oClents_Cards.client.email = textbox_Email.Text;

            await oClientsRepository.Update_Clients_Async(oClents_Cards.client);

            await Update_ListView();
        }

    }
}
