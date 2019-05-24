using Management.DataModel;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Management.Repository
{
    internal interface IUsersRepository
    {
        Task Insert_Users_Async(Users users);
        Task Update_Users_Async(Users users);
        Task Delete_Users_Async(Users users);
        Task<List<Users>> Select_All_Users_Async();
        Task<List<Users>> Select_Users_Async(string query);
    }
}