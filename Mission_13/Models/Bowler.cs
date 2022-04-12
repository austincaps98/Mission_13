using System;
using System.ComponentModel.DataAnnotations;

namespace Mission_13.Models
{
    public class Bowler
    {
        [Key]
        [Required]
        public int BowlerID { get; set; } //Read only variables only allow the Get

        public string BowlerLastName { get; set; }
        public string BowlerFirstName { get; set; }
        public string BowlerMiddleInit { get; set; }

        public string BowlerAddress { get; set; }
        public string BowlerCity { get; set; }
        public string BowlerState { get; set; }
        public string BowlerZip { get; set; }
        public string BowlerPhoneNumber { get; set; }

        [Required]
        public int TeamID { get; set; }
        public Team Team { get; set; }
    }
}
