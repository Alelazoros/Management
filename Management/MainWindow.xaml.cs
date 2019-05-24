using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using Management.Repository;
using Management.DataAccess;
using Management.DataModel;

namespace Management
{

    /// Логика взаимодействия для MainWindow.xaml
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        UsersRepository oUsersRepository; // Контроллер таблиц "Пользователи"

        /// Выполнение операций при загрузке окна
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await Initialize_Database();
        }

        private async Task Initialize_Database()
        {
            DBConnection oDBConnection = new DBConnection();

            if (!oDBConnection.Successful)
            {
                this.Close(); //Путь до БД не выбран! Приложение закрыто.
            }

            await oDBConnection.InitializeDatabase();
            oUsersRepository = new UsersRepository(oDBConnection);
        }

        /// Метод проверки корректности введённых данных
        public async Task<bool> Check_Login(string login, string password)
        {
            List<Users> users = await oUsersRepository.Select_All_Users_Async();

            if (users != null)
            {
                foreach (var c in users)
                {
                    if (login == c.login && password == c.password)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// Вызов метода входа пользователя в систему
        private async void button_Login_Click(object sender, RoutedEventArgs e)
        {
            if (await Check_Login(textbox_Login.Text, passwordbox_Password.Password))
            {
                MainMenuWindow mm = new MainMenuWindow();
                mm.Show();
                this.Close();
            }

            else
            {
                textbox_Login.Text = null;
                passwordbox_Password.Password = null;
                label_Attention.Visibility = Visibility.Visible;
            }
        }

        /// Вызов окна с регистрацией нового пользователя программы
        private void button_Registration_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow reg_form = new RegistrationWindow();
            reg_form.ShowDialog();
        }
    }
}
