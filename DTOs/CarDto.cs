namespace RaceTrackingAPI.DTOs
{
    public class CarDto
    {
        public int IdCar { get; set; }

        public string Model { get; set; }

        public string Description { get; set; }

        public string Manufacturer { get; set; }

        public List<PartDto> Parts { get; set; }

    }
}
