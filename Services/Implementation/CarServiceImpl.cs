using Microsoft.EntityFrameworkCore;
using RaceTrackingAPI.DAL;
using RaceTrackingAPI.DTOs;
using RaceTrackingAPI.Services.Interfaces;

namespace RaceTrackingAPI.Services.Implementation
{
    public class CarServiceImpl : ICarService
    {
        private readonly MainDbContext _dbContext;

        public CarServiceImpl(MainDbContext context)
        {
            _dbContext = context;
        }

        public async Task<bool> DoesCarWithManufacturerExistsAsync(string manufacturer)
        {
            return await _dbContext.Cars.AnyAsync(c => c.Manufacturer == manufacturer);
        }

        public async Task<List<CarDto>> GetCarsByManufacturerAsync(string manufacturer)
        {
            return await _dbContext.Cars.Where(c => c.Manufacturer == manufacturer)
                .Select(t => new CarDto
                {
                    IdCar = t.IdCar,
                    Model = t.Model,
                    Description = t.Description,
                    Manufacturer = t.Manufacturer,
                    Parts = t.PartInCars.Select(p => new PartDto
                    {
                        IdPart = p.Part.IdPart,
                        Name = p.Part.Name,
                        MountedDate = p.MountedDate,
                        LastServiceDate = p.LastServiceDate
                    }).ToList()
                }).ToListAsync();
        }

        public async Task<bool> CheckIfCarsExistsAsync(List<CarInfoToRaceDto> carsInfo)
        {
            bool allExists = true;
            foreach (var car in carsInfo)
            {
                allExists = await _dbContext.Cars.AnyAsync(c => c.IdCar == car.IdCar);
            }

            return allExists;
        }
    }
}