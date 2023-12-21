using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RaceTrackingAPI.DAL
{
    public class Car
    {
        [Key]
        public int IdCar { get; set; }

        [MaxLength(100)]
        public string Model { get; set; }

        [MaxLength(100)]
        [Required]
        [Column(TypeName = "text")]
        public string Description { get; set; }

        [MaxLength(100)]
        [Required]
        public string Manufacturer { get; set; }

        public virtual ICollection<PartInCar> PartInCars { get; set; } = new List<PartInCar>();

        public virtual ICollection<CarInRace> CarInRaces { get; set; } = new List<CarInRace>();
    }
}
