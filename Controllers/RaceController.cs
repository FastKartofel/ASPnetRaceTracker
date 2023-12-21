using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RaceTrackingAPI.DTOs;
using RaceTrackingAPI.Services.Implementation;
using RaceTrackingAPI.Services.Interfaces;

namespace RaceTrackingAPI.Controllers
{
    [Route("api/race")]
    [ApiController]
    public class RaceController : ControllerBase
    {
        private readonly ICarService _carRepository;
        private readonly IRaceService _raceRepository;

        public RaceController(ICarService carRepository, IRaceService raceRepository)
        {
            _carRepository = carRepository;
            _raceRepository = raceRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddNewRaceWithCars([FromBody] RaceDto raceDto)
        {
            var allExists = await _carRepository.CheckIfCarsExistsAsync(raceDto.CarsInfo);
            if (!allExists) return NotFound("Couldn't find given car");
            var res = await _raceRepository.AddNewRaceWithCarsAsync(raceDto);
            if (res is int) return Ok($"Successfully added new race with id: {res}");
            return Conflict("Problem with data base accured.");
        }
    }
}
