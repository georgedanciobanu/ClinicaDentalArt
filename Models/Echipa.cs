using System.ComponentModel.DataAnnotations;

namespace ClinicaDentalArt.Models
{
    public class Echipa
    {
        [Key]
        public int EchipaID { get; set; }
        public string Nume { get; set; }
        public string Specializare { get; set; }
        public string Info { get; set; }
    }
}