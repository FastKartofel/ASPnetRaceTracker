using System.ComponentModel.DataAnnotations;

namespace RaceTrackingAPI.DAL
{
    public class Race
    {
        [Key]
        public int IdRace { get; set; }

        [MaxLength(300)]
        [Required]
        public string TrackName { get; set; }

        [MaxLength(30)]
        [Required]
        public string Difficulty { get; set; }

        public DateTime? Date { get; set; }

        public virtual ICollection<CarInRace> CarInRaces { get; set; } = new List<CarInRace>();
    }
}
