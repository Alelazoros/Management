using System.Windows;
using Management.DataModel;
using Management.Repository;

namespace Management
{

    /// Логика взаимодействия для OrderWindow.xaml
    public partial class OrderWindow : Window
    {
        public OrderWindow()
        {
            InitializeComponent();
        }

        /// Структура для работы с заказом и его клиентом
        struct Clients_Orders
        {
            public Clients client { get; set; }
            public Orders order { get; set; }
        }

        /// Структура для работы с корзиной и её букетами
        struct Carts_Bouquets
        {
            public Carts cart { get; set; }
            public Bouquets bouquet { get; set; }
        }

        bool first_launch = true;

        ClientsRepository oClientsRepository;   //
        OrdersRepository oOrdersRepository;     //  Контроллеры
        CartsRepository oCartsRepository;       //  Таблиц
        BouquetsRepository oBouquetsRepository; //
        CardsRepository oCardsRepository;       //
        PaymentsRepository oPaymentsRepository;

        SQLite.SQLiteAsyncConnection conn;      //  Прямой коннект к БД для выдачи записей из таблиц по ID
    }




}
