using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Booking.DAL.Interfaces;
using Booking.Domain.Entities.AdvertiesementAggregate;
using Booking.Domain.Entities.CountryAggregate;
using Booking.Domain.Entities.UserAggregate;
using Booking.Domain.Interfaces;
using Booking.Prepopulator.Interfaces;
using Booking.Prepopulator.Parsers;
using Booking.Utils;

namespace Booking.Prepopulator.Services
{
    public class PrepopulatorService : IPrepopulatorService
    {
        private readonly IAdvertisementRepository _advertisementRepository;
        private readonly ICityRepository _cityRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public PrepopulatorService(IAdvertisementRepository advertisementRepo, ICountryRepository countryRepository, 
            ICityRepository cityRepository, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _countryRepository = countryRepository;
            _cityRepository = cityRepository;
            _userManager = userManager;
            _roleManager = roleManager;
            _advertisementRepository = advertisementRepo;
        }

        public async Task SeedAllDataAsync()
        {
            var countries = await EntitiesParser.ParseEntitiesAsync<CountryEntity>(
                GetFilePath(WebConstants.Prepopulator.CountriesFileName));
            await SeedDataAsync(countries, _countryRepository);

            var cities = await EntitiesParser.ParseEntitiesAsync<CityEntity>(
                GetFilePath(WebConstants.Prepopulator.CitiesFileName));
            await SeedDataAsync(cities, _cityRepository);
            
            var advertisements = await EntitiesParser.ParseEntitiesAsync<AdvertisementEntity>(
                GetFilePath(WebConstants.Prepopulator.AdvertisementsFileName));
            await SeedDataAsync(advertisements, _advertisementRepository);

            var roles = await EntitiesParser.ParseEntitiesAsync<ApplicationRole>(
                GetFilePath(WebConstants.Prepopulator.ApplicationRolesFileName));
            await SeedApplicationRolesAsync(roles);
            
            var users = await EntitiesParser.ParseEntitiesAsync<ApplicationUser>(
                GetFilePath(WebConstants.Prepopulator.ApplicationUsersFileName));
            await SeedApplicationUsersAsync(users.ToList());
            
        }

        private async Task SeedDataAsync<T>(IEnumerable<T> entities, IRepository<T> repository) where T : IDocument
        {
            foreach (var entity in entities)
            {
                var currentEntity = await repository.GetByIdAsync(entity.Id);

                if (currentEntity == null)
                {
                    await repository.AddAsync(entity);
                }
            }
        }

        private async Task SeedApplicationRolesAsync(IEnumerable<ApplicationRole> roles)
        {
            foreach (var role in roles)
            {
                if (!await _roleManager.RoleExistsAsync(role.Name))
                { 
                    await _roleManager.CreateAsync(role);
                }
            }
        }
        
        private async Task SeedApplicationUsersAsync(List<ApplicationUser> users)
        {
            foreach (var user in users)
            {
                if (await _userManager.FindByNameAsync(user.UserName) == null)
                {
                    var newUser = new ApplicationUser
                    {
                        UserName = user.UserName,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        PasswordHash = user.PasswordHash,
                        SecurityStamp = user.SecurityStamp
                    };
                    await _userManager.CreateAsync(newUser);

                    var adminRoles = await _userManager.GetUsersInRoleAsync(WebConstants.Account.AdminRole);
                    if (!adminRoles.Any())
                    {
                       await _userManager.AddToRolesAsync(newUser, new[] { WebConstants.Account.MemberRole, WebConstants.Account.AdminRole });
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(newUser, WebConstants.Account.MemberRole);
                    }
                }
            }
        }
        
        private string GetFilePath(string fileName) => Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\", fileName));
    }
}