using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NorthShoreSurfApp.ModelComponents
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public int StateId { get; set; }
        [ForeignKey(nameof(StateId))]
        public State State { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
    }
}
