﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Management.DataModel;

namespace Management.Repository
{
    interface IBouquetsRepository
    {
        Task Insert_Bouquets_Async(Bouquets bouquets);
        Task Update_Bouquets_Async(Bouquets bouquets);
        Task Delete_Bouquets_Async(Bouquets bouquets);
        Task<List<Bouquets>> Select_All_Bouquets_Async();
        Task<List<Bouquets>> Select_Bouquets_Async(string query);
    }
}
