using System.Collections.Generic;
using System.Threading.Tasks;
using Management.DataModel;

namespace Management.Repository
{
    interface ISpecialDealsRepository
    {
        Task Insert_SpecialDeals_Async(SpecialDeals specialdeals);
        Task Update_SpecialDeals_Async(SpecialDeals specialdeals);
        Task Delete_SpecialDeals_Async(SpecialDeals specialdeals);
        Task<List<SpecialDeals>> Select_All_SpecialDeals_Async();
        Task<List<SpecialDeals>> Select_SpecialDeals_Async(string query);
    }
}
