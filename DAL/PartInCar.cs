using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RaceTrackingAPI.DAL
{
    public class PartInCar
    {
        [Key, Column(Order = 0)]
        public int IdPart { get; set; }

        [Key, Column(Order = 1)]
        public int IdCar { get; set; }

        public virtual Part Part { get; set; }
        public virtual Car Car { get; set; }

        [Required]
        public DateTime MountedDate { get; set; }

        public DateTime? LastServiceDate { get; set; }
    }
}
