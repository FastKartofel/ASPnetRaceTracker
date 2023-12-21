namespace RaceTrackingAPI.DTOs
{
    public class RaceDto
    {
        public string TrackName { get; set; }

        public string Difficulty { get; set; }

        public DateTime? Date { get; set; }

        public List<CarInfoToRaceDto> CarsInfo { get; set; }
    }
}
