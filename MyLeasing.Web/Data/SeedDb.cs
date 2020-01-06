using MyVet.Web.Data.Entities;
using MyVet.Web.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckRoles();
            var manager = await CheckUserAsync("1", "Juan", "Perez", "jperez@gmail.com", "1", "Guapiles", "Admin");
            var customer = await CheckUserAsync("2", "María", "Perez", "mperez@gmail.com", "2", "Guapiles", "Customer");
            await CheckAgendaAsync();
            //await CheckHistoriesAsync();
            await CheckManagerAsync(manager);
            await CheckOwnersAsync(customer);
            await CheckPetsAsync();
            await CheckPetTypesAsync();
            await CheckServiceTypesAsync();
        }

        private async Task CheckOwnersAsync(User user)
        {
            if (!_context.Owners.Any())
            {
                await _context.Owners.AddAsync(new Owner { User = user });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckManagerAsync(User user)
        {
            if (!_context.Managers.Any())
            {
                await _context.Managers.AddAsync(new Manager { User = user });
                await _context.SaveChangesAsync();
            }
        }

        private async Task<User> CheckUserAsync(string document,
            string firstName,
            string LastName,
            string email,
            string phone,
            string address,
            string role)
        {
            var user = await _userHelper.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new User
                {
                    Document = document,
                    FirstName = firstName,
                    LastName = LastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, role);
            }
            return user;
        }

        private async Task CheckRoles()
        {
            await _userHelper.CheckRoleAsync("Admin");
            await _userHelper.CheckRoleAsync("Customer");
        }

        private async Task CheckServiceTypesAsync()
        {
            if (!_context.ServiceTypes.Any())
            {
                await _context.ServiceTypes.AddAsync(new ServiceType { Name = "Consulta" });
                await _context.ServiceTypes.AddAsync(new ServiceType { Name = "Urgencia" });
                await _context.ServiceTypes.AddAsync(new ServiceType { Name = "Vacunación" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckPetsAsync()
        {
            var owner = _context.Owners.FirstOrDefault();
            var petType = _context.PetTypes.FirstOrDefault();
            if (!_context.Pets.Any())
            {
                await _context.Pets.AddAsync(new Pet { Name = "Otto", Owner = owner, PetType = petType, Race = "German sheeper" });
                await _context.Pets.AddAsync(new Pet { Name = "Rambo", Owner = owner, PetType = petType, Race = "Chihuahua" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckHistoriesAsync()
        {
            throw new NotImplementedException();
        }

        private async Task CheckAgendaAsync()
        {
            if (!_context.Agendas.Any())
            {
                var initialDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
                var finalDate = initialDate.AddYears(1);

                while (initialDate < finalDate)
                {
                    if (initialDate.DayOfWeek != DayOfWeek.Sunday)
                    {
                        var finalDate2 = initialDate.AddHours(10);
                        while (initialDate < finalDate2)
                        {
                            await _context.Agendas.AddAsync(new Agenda
                            {
                                Date = initialDate.ToUniversalTime(),
                                IsAvaible = true
                            });
                            initialDate = initialDate.AddMinutes(30);
                        }

                        initialDate = initialDate.AddHours(14);
                    }
                    else
                    {
                        initialDate = initialDate.AddDays(1);
                    }

                    await _context.SaveChangesAsync();
                }
            }
        }

        private async Task CheckPetTypesAsync()
        {
            if (!_context.PetTypes.Any())
            {
                await _context.PetTypes.AddAsync(new PetType { Name = "Dog" });
                await _context.PetTypes.AddAsync(new PetType { Name = "Cat" });
                await _context.PetTypes.AddAsync(new PetType { Name = "Turtle" });
                await _context.SaveChangesAsync();
            }
        }
    }
}