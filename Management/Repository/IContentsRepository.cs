using System.Collections.Generic;
using System.Threading.Tasks;
using Management.DataModel;

namespace Management.Repository
{
    interface IContentsRepository
    {
        Task Insert_Contents_Async(Contents contents);
        Task Update_Contents_Async(Contents contents);
        Task Delete_Contents_Async(Contents contents);
        Task<List<Contents>> Select_All_Contents_Async();
        Task<List<Contents>> Select_Contents_Async(string query);
    }
}
