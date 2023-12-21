using System.ComponentModel.DataAnnotations;

namespace RaceTrackingAPI.DAL
{
    public class Part
    {
        [Key]
        public int IdPart { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<PartInCar> PartInCars { get; set; } = new List<PartInCar>();
    }
}
