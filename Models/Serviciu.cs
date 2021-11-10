using System.ComponentModel.DataAnnotations;

namespace ClinicaDentalArt.Models
{
    public class Serviciu
    {
        [Key]
        public int ID { get; set; }
        public string Nume { get; set; }
        public string Info { get; set; }
    }
}