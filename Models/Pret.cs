using System.ComponentModel.DataAnnotations;

namespace ClinicaDentalArt.Models
{
    public class Pret
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Serviciu")]
        public string Nume { get; set; }
        [Display(Name = "Pret")]
        public int Valoare { get; set; }
    }
}