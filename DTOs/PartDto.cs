namespace RaceTrackingAPI.DTOs
{
    public class PartDto
    {
        public int IdPart { get; set; }

        public string Name { get; set; }

        public DateTime MountedDate { get; set; }

        public DateTime? LastServiceDate { get; set; }
    }
}
