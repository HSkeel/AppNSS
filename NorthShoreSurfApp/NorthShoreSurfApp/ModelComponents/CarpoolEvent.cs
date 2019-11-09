using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NorthShoreSurfApp.ModelComponents
{
    public partial class CarpoolEvent
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int StateId { get; set; }
        [ForeignKey(nameof(StateId))]
        public State State { get; set; }
        [Required]
        public int DriverId { get; set; }
        [ForeignKey(nameof(DriverId))]
        public User Driver { get; set; }
        [Required]
        public DateTime DepartureTime { get; set; }
        [StringLength(255)]
        [Required]
        public string Address { get; set; }
        [StringLength(4)]
        [Required]
        public string ZipCode { get; set; }
        [StringLength(255)]
        [Required]
        public string City { get; set; }       
        public List<CarpoolConfirmation> CarpoolConfirmations { get; set; }
        [Required]
        public int CarId { get; set; }
        [ForeignKey(nameof(CarId))]
        public Car Car { get; set; }
        [Required]
        public int NumberOfSeats { get; set; }
        [Required]
        public int PricePerPassenger { get; set; }
        public List<CarpoolEvents_Events_Relation> CarpoolEvents_Events_Relations { get; set; }
        [StringLength(255)]
        public string Comment { get; set; }
    }
}
