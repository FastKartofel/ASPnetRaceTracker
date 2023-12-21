using RaceTrackingAPI.DAL;
using RaceTrackingAPI.DTOs;
using RaceTrackingAPI.Enums;
using RaceTrackingAPI.Services.Interfaces;

namespace RaceTrackingAPI.Services.Implementation
{
    public class RaceServiceImpl : IRaceService
    {
        private readonly MainDbContext _dbContext;

        public RaceServiceImpl(MainDbContext context)
        {
            _dbContext = context;
        }

        public async Task<dynamic> AddNewRaceWithCarsAsync(RaceDto raceDto)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var newRace = new Race
                    {
                        TrackName = raceDto.TrackName,
                        Difficulty = raceDto.Difficulty,
                        Date = raceDto.Date
                    };
                    await _dbContext.Races.AddAsync(newRace);
                    await _dbContext.SaveChangesAsync();
                    var newRaceId = newRace.IdRace;

                    var carsList = raceDto.CarsInfo;
                    foreach (var car in carsList)
                    {
                        await _dbContext.CarsInRaces.AddAsync(new CarInRace
                        {
                            IdCar = car.IdCar,
                            IdRace = newRaceId,
                            IsConfirmedByDriver = car.IsConfirmedByDriver
                        });
                    }

                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return newRaceId;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return StatusEnum.Failure;
                }
            }
        }
    }
}
