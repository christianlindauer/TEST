using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace AutoReservation.Dal.Entities
{
       public abstract class Auto
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(20)]
        public string Marke { get; set; }

        [Timestamp]
        public Byte[] RowVersion { get; set; }

        [Required]
        public int Tagestarif { get; set; }
        
    }
    
    public class LuxusAuto : Auto
    {
        [Required]
        public int? Basistarif { get; set; }
    }

    public class MittelKlasseAuto : Auto
    {
    }

    public class StandardAuto : Auto
    {
    }
}
