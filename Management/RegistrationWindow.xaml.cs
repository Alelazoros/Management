using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using Management.Repository;
using Management.DataAccess;
using Management.DataModel;

namespace Management
{

    /// Логика взаимодействия для RegistrationWindow.xaml
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        UsersRepository oUsersRepository;

        /// Выполнение операций при загрузке окна
        private async void Window_Loaded_Reg(object sender, RoutedEventArgs e)
        {
            await Initialize_Database();
        }

        private async Task Initialize_Database()
        {
            DBConnection oDBConnection = new DBConnection();

            await oDBConnection.InitializeDatabase();

            oUsersRepository = new UsersRepository(oDBConnection);
        }


        /// Регистрация нового пользователя в системе
        public async void Registration(string login, string password)
        {
            await oUsersRepository.Insert_Users_Async(new Users(login, password));

            MessageBox.Show("Вы зарегистрированы!");

            this.Close();
        }

        /// Проверка на уникальность имени пользователя системы
        public async Task<bool> Check_Login(string login)
        {
            List<Users> users = await oUsersRepository.Select_All_Users_Async();

            foreach (var u in users)
            {
                if (u.login == login)
                {
                    return false; // false, если такое имя существует
                }
            }
            
            return true; // true, если такого логина нет
        }

        private async void button_Registration_Click(object sender, RoutedEventArgs e)
        {
            {
                if (textbox_Login.Text == "" || passwordbox_Password.Password == "")
                {
                    label_Allert.Content = "Заполнены не все поля.";
                    label_Allert.Visibility = System.Windows.Visibility.Visible;
                } 
                else
                {
                    if (await Check_Login(textbox_Login.Text))
                    {
                        label_Allert.Visibility = System.Windows.Visibility.Hidden;

                        Registration(textbox_Login.Text, passwordbox_Password.Password);

                        this.Close();
                    }
                    else
                    {
                        label_Allert.Content = "Такое имя пользователя уже существует.";
                        label_Allert.Visibility = System.Windows.Visibility.Visible;
                    }

                }
            }
        }
    }
}
