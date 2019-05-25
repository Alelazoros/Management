using System.Collections.Generic;
using System.Threading.Tasks;
using Management.DataModel;

namespace Management.Repository
{
    interface ICardsRepository
    {
        Task Insert_Cards_Async(Cards cards);
        Task Update_Cards_Async(Cards cards);
        Task Delete_Cards_Async(Cards cards);
        Task<List<Cards>> Select_All_Cards_Async();
        Task<List<Cards>> Select_Cards_Async(string query);
    }
}
