using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NorthShoreSurfApp.ModelComponents
{
    public partial class User
    {
        [Key]
        public int Id { get; set; }
        public int StateId { get; set; }
        [ForeignKey(nameof(StateId))]
        public State State { get; set; }
        [StringLength(255)]
        public string FirstName { get; set; }
        [StringLength(255)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string PhoneNo { get; set; }
        public int Age { get; set; }
        public int GenderId { get; set; }
        [ForeignKey(nameof(GenderId))]
        public Gender Gender { get; set; }

        public List<Car> Cars { get; set; }
        public List<CarpoolEvent> CarpoolEvents { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
