using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoReservation.Dal.Entities
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        [ ForeignKey("Auto")]
        public int AutoId { get; set; }

        [Required]
        public Auto Auto { get; set; }


        [ForeignKey("Kunde")]
        public int KundeId { get; set; }

        [Required]
        public Kunde Kunde { get; set; }

        [Required]
        public DateTime Von { get; set; }

        [Required]
        public DateTime Bis { get; set; }

        [Timestamp]
        public Byte[] RowVersion { get; set; }
    }
}
