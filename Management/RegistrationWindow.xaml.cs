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
        UsersRepository oUsersRepository;

        public RegistrationWindow()
        {
            InitializeComponent();
        }
        private async Task Initialize_Database()
        {
            DBConnection oDBConnection = new DBConnection();

            await oDBConnection.InitializeDatabase();

            oUsersRepository = new UsersRepository(oDBConnection);
        }
        private async void reg_form_Loaded(object sender, RoutedEventArgs e)
        {
            await Initialize_Database();
        }

        /// Регистрация нового пользователя в системе
        public async void Registration(string login, string password)
        {
            await oUsersRepository.Insert_Users_Async(new Users(login, password));

            MessageBox.Show("Вы зарегистрированы!");

            this.Close();
        }

        /// Проверка на уникальность имени пользователя системы

        /// <returns>true, если такого логина нет или false, если такое имя существует</returns>
        public async Task<bool> Check_Login(string login)
        {
            //----------------------Пока выходят проблемы на этой точке-----------------------------
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
