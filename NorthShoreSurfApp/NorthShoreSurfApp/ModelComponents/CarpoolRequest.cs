using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NorthShoreSurfApp.ModelComponents
{
    public partial class CarpoolRequest
    {
        [Key]
        public int Id { get; set; }
        public int StateId { get; set; }
        [ForeignKey(nameof(StateId))]
        public State State { get; set; }
        public int PassengerId { get; set; }
        [ForeignKey(nameof(PassengerId))]
        public User Passenger { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
        [StringLength(4)]
        public string ZipCode { get; set; }
        [StringLength(255)]
        public string City { get; set; }
    }
}
