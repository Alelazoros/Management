using System.Threading.Tasks;
using SQLite;

namespace Management.DataAccess
{
    interface IDBConnection
    {
        Task InitializeDatabase();
        SQLiteAsyncConnection GetAsyncConnection();
    }
}
