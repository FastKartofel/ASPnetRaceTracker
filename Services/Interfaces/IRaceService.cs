using RaceTrackingAPI.DTOs;

namespace RaceTrackingAPI.Services.Interfaces
{
    public interface IRaceService
    {
        public Task<dynamic> AddNewRaceWithCarsAsync(RaceDto raceDto);
    }
}
