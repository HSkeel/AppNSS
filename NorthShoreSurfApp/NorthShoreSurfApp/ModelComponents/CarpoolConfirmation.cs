using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NorthShoreSurfApp.ModelComponents
{
    public partial class CarpoolConfirmation
    {
        [Key]
        public int Id { get; set; }
        public int StateId { get; set; }
        [ForeignKey(nameof(StateId))]
        public State State { get; set; }
        public bool HasPassengerAccepted { get; set; }
        public bool HasDriverAccepted { get; set; }
        public int PassengerId { get; set; }
        [ForeignKey(nameof(PassengerId))]
        public User Passenger { get; set; }
        public int CarpoolEventId { get; set; }
        [ForeignKey(nameof(CarpoolEventId))]
        public CarpoolEvent CarpoolEvent { get; set; }
    }
}
