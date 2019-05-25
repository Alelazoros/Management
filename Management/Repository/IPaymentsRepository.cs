using System.Collections.Generic;
using System.Threading.Tasks;
using Management.DataModel;

namespace Management.Repository
{
    interface IPaymentsRepository
    {
        Task Insert_Payments_Async(Payments payments);
        Task Update_Payments_Async(Payments payments);
        Task Delete_Payments_Async(Payments payments);
        Task<List<Payments>> Select_All_Payments_Async();
        Task<List<Payments>> Select_Payments_Async(string query);
    }
}
