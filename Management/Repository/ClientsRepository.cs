using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Management.DataAccess;
using Management.DataModel;

namespace Management.Repository
{
    class ClientsRepository : IClientsRepository
    {
        SQLiteAsyncConnection conn;

        public ClientsRepository(IDBConnection oIDBConnection)
        {
            conn = oIDBConnection.GetAsyncConnection();
        }

        public async Task Insert_Clients_Async(Clients clients)
        {
            await conn.InsertAsync(clients);
        }

        public async Task Update_Clients_Async(Clients clients)
        {
            await conn.UpdateAsync(clients);
        }

        public async Task Delete_Clients_Async(Clients clients)
        {
            await conn.DeleteAsync(clients);
        }

        public async Task<List<Clients>> Select_All_Clients_Async()
        {
            return await conn.Table<Clients>().ToListAsync();
        }

        public async Task<List<Clients>> Select_Clients_Async(string query)
        {
            return await conn.QueryAsync<Clients>(query);
        }
    }
}
