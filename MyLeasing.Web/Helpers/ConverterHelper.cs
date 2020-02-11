using MyVet.Web.Data;
using MyVet.Web.Data.Entities;
using MyVet.Web.Models;
using System.Threading.Tasks;

namespace MyVet.Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        private readonly DataContext _dataContext;
        private readonly ICombosHelper _combosHelper;

        public ConverterHelper(DataContext dataContext, ICombosHelper combosHelper)
        {
            _dataContext = dataContext;
            _combosHelper = combosHelper;
        }

        public async Task<History> ToHistoryAsync(HistoryViewModel model, bool isNew)
        {
            return new History
            {
                Date = model.Date.ToUniversalTime(),
                Description = model.Description,
                Id = isNew ? 0 : model.Id,
                Pet = await _dataContext.Pets.FindAsync(model.PetId),
                Remarks = model.Remarks,
                ServiceType = await _dataContext.ServiceTypes.FindAsync(model.ServiceTypeId)
            };
        }

        public HistoryViewModel ToHistoryViewModelAsync(History model)
        {
            return new HistoryViewModel
            {
                Date = model.Date,
                Description = model.Description,
                Id = model.Id,
                PetId =model.Pet.Id,
                Remarks = model.Remarks,
                ServiceTypeId = model.ServiceType.Id,
                ServiceTypes = _combosHelper.GetComboServicesTypes()
            };
        }

        public async Task<Pet> ToPetAsync(PetViewModel petViewModel, string path, bool isNew)
        {
            var pet = new Pet
            {
                Agendas = petViewModel.Agendas,
                Born = petViewModel.Born,
                Histories = petViewModel.Histories,
                Id = isNew ? 0 : petViewModel.Id,
                ImageUrl = path,
                Name = petViewModel.Name,
                Owner = await _dataContext.Owners.FindAsync(petViewModel.OwnerId),
                PetType = await _dataContext.PetTypes.FindAsync(petViewModel.PetTypeId),
                Race = petViewModel.Race,
                Remarks = petViewModel.Remarks
            };

            return pet;
        }

        public PetViewModel ToPetViewModelAsync(Pet model)
        {
            var petViewModel = new PetViewModel
            {
                Agendas = model.Agendas,
                Born = model.Born,
                Histories = model.Histories,
                ImageUrl = model.ImageUrl,
                Name = model.Name,
                Owner = model.Owner,
                PetType = model.PetType,
                Race = model.Race,
                Remarks = model.Remarks,
                Id = model.Id,
                OwnerId = model.Owner.Id,
                PetTypeId = model.PetType.Id,
                PetTypes = _combosHelper.GetComboPetTypes()
            };

            /*if (petViewModel.Id != 0)
            {
                model.Id = petViewModel.Id;
            }    */

            return petViewModel;
        }
    }
}
