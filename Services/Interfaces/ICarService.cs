using RaceTrackingAPI.DTOs;

namespace RaceTrackingAPI.Services.Interfaces
{
    public interface ICarService
    {
        public Task<bool> DoesCarWithManufacturerExistsAsync(string manufacturer);

        public Task<List<CarDto>> GetCarsByManufacturerAsync(string manufacturer);

        public Task<bool> CheckIfCarsExistsAsync(List<CarInfoToRaceDto> carsInfo);
    }
}
