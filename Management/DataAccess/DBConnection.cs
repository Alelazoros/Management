using System.Windows;
using System.Xml.Serialization;
using System.IO;
using System.Threading.Tasks;
using SQLite;
using Management.DataModel;


namespace Management.DataAccess
{
    class DBConnection : IDBConnection
    {
        public bool Successful { get; set; }

        Settings settings;

        SQLiteAsyncConnection conn;

        public DBConnection()
        {
            Successful = Load_Connection();
            conn = new SQLiteAsyncConnection(settings.dbpath);
        }


        /// Загрузка пути до БД из файла с настройками. Если файл с настройкмаи не найден, то указать путь до папки с БД.
        private bool Load_Connection()
        {
            if (File.Exists("Settings.xml") && File.Exists("db.sqlite"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Settings));

                FileStream fs = new FileStream("Settings.xml", FileMode.Open);

                using (StreamReader sr = new StreamReader(fs))
                {
                    settings = serializer.Deserialize(sr) as Settings;
                }
            }

            if (settings == null)
            {
                System.Windows.MessageBox.Show("Пожалуйста, укажите путь до базы данных.");
                settings = new Settings();

                if (!settings.Set_DB_Path())
                {
                    MessageBox.Show("Путь до БД не выбран!\nПриложение закрыто.");
                    return false;
                }

                if (!File.Exists("Settings.xml"))
                {
                    Save_Connection(settings);
                }
            }

            return true;
        }

        /// Сохранение пути до БД в файл.
        public static void Save_Connection(Settings settings)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Settings));

            if (File.Exists("Settings.xml"))
            {
                File.Delete("Settings.xml");
            }

            FileStream fs = new FileStream("Settings.xml", FileMode.CreateNew);

            using (StreamWriter sw = new StreamWriter(fs))
            {
                serializer.Serialize(sw, settings);
            }
        }


        /// Создание Таблиц в БД
        public async Task InitializeDatabase()
        {
            //В процессе
            /*
            ----------------
            await conn.CreateTableAsync<Accessories>();
            await conn.CreateTableAsync<Bouquets>();
            await conn.CreateTableAsync<Carts>();
            await conn.CreateTableAsync<Cards>();
            await conn.CreateTableAsync<Clients>();
            await conn.CreateTableAsync<Constants>();
            await conn.CreateTableAsync<Contents>();
            await conn.CreateTableAsync<Discounts>();
            await conn.CreateTableAsync<SpecialDeals>();
            await conn.CreateTableAsync<Flowers>();
            await conn.CreateTableAsync<Orders>();
            await conn.CreateTableAsync<Payments>();
            ----------------
            */
            await conn.CreateTableAsync<Users>();
        }

        public SQLiteAsyncConnection GetAsyncConnection()
        {
            return conn;
        }
    }
}