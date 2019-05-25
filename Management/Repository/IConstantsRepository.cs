using System.Collections.Generic;
using System.Threading.Tasks;
using Management.DataModel;

namespace Management.Repository
{
    interface IConstantsRepository
    {
        Task Insert_Constants_Async(Constants constants);
        Task Update_Constants_Async(Constants constants);
        Task Delete_Constants_Async(Constants constants);
        Task<List<Constants>> Select_All_Constants_Async();
        Task<List<Constants>> Select_Constants_Async(string query);
    }
}
