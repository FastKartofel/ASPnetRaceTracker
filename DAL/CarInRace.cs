using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RaceTrackingAPI.DAL
{
    public class CarInRace
    {
        [Key, Column(Order = 0)]
        public int IdCar { get; set; }

        [Key, Column(Order = 1)]
        public int IdRace { get; set; }

        public virtual Car Car { get; set; }
        public virtual Race Race { get; set; }
        [Required]
        public bool IsConfirmedByDriver { get; set; }
    }
}
