﻿using MyVet.Web.Data.Entities;
using MyVet.Web.Models;
using System.Threading.Tasks;

namespace MyVet.Web.Helpers
{
    public interface IConverterHelper
    {
        Task<Pet> ToPetAsync(PetViewModel petViewModel, string path, bool isNew);
        PetViewModel ToPetViewModelAsync(Pet pet);

        Task<History> ToHistoryAsync(HistoryViewModel model, bool isNew);
        HistoryViewModel ToHistoryViewModelAsync(History history);
    }
}