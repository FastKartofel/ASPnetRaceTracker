using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceTrackingAPI.DAL;
using RaceTrackingAPI.DTOs;
using RaceTrackingAPI.Services.Interfaces;

namespace RaceTrackingAPI.Controllers
{
    [Route("api/cars")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carRepository;

        public CarController(ICarService carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet("{manufacturerName}")]
        public async Task<IActionResult> GetCarInfoByManufactureNameAsync([FromRoute] string manufacturerName)
        {
            var doesAnyCarExists = await _carRepository.DoesCarWithManufacturerExistsAsync(manufacturerName);
            if (!doesAnyCarExists) return NotFound($"No car found with manufaturer: {manufacturerName}");
            var cars = await _carRepository.GetCarsByManufacturerAsync(manufacturerName);
            return Ok(cars);
        }

    }
}
