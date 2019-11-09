using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NorthShoreSurfApp.ModelComponents
{
    public partial class Car
    {
        [Key]
        public int Id { get; set; }
        public int StateId { get; set; }
        [ForeignKey(nameof(StateId))]
        public State State { get; set; }
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        [StringLength(10)]
        [MinLength(4)]
        public string LicensePlate { get; set; }
        [StringLength(255)]
        public string Color { get; set; }
    }
}
