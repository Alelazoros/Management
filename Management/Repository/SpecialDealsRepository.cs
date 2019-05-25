using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Management.DataAccess;
using Management.DataModel;

namespace Management.Repository
{
    class SpecialDealsRepository :ISpecialDealsRepository
    {
        SQLiteAsyncConnection conn;

        public SpecialDealsRepository(IDBConnection oIDBConnection)
        {
            conn = oIDBConnection.GetAsyncConnection();
        }

        public async Task Insert_SpecialDeals_Async(SpecialDeals specialdeals)
        {
            await conn.InsertAsync(specialdeals);
        }

        public async Task Update_SpecialDeals_Async(SpecialDeals specialdeals)
        {
            await conn.UpdateAsync(specialdeals);
        }

        public async Task Delete_SpecialDeals_Async(SpecialDeals specialdeals)
        {
            await conn.DeleteAsync(specialdeals);
        }

        public async Task<List<SpecialDeals>> Select_All_SpecialDeals_Async()
        {
            return await conn.Table<SpecialDeals>().ToListAsync();
        }

        public async Task<List<SpecialDeals>> Select_SpecialDeals_Async(string query)
        {
            return await conn.QueryAsync<SpecialDeals>(query);
        }
    }
}
