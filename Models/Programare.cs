using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ClinicaDentalArt.Models;

namespace ClinicaDentalArt.Models
{
    public class Programare
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Nume obligatoriu")]
        [StringLength(50)]
        public string Nume { get; set; }
        [Required(ErrorMessage = "Prenume obligatoriu")]
        [StringLength(50)]
        public string Prenume { get; set; }
        [Display(Name = "Serviciu")]
        public string Tratament { get; set; }
        [ValidJoinDate(ErrorMessage = "Date should be later than today!")]

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = @"{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }

        //public Ora {get; set;}
        
        [Required]
        [StringLength(10)]
        public string Telefon { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Medic")]
        public int EchipaID { get; set; }
        [StringLength(2000)]
        [Display(Name = "Mesaj")]

        public string Comment { get; set; }
        [StringLength(250, ErrorMessage = "String too long (max 250 chars)")]
        public string Tags { get; set; }

    }
}