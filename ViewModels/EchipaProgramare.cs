using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicaDentalArt.ViewModels
{
    public class EchipaProgramare
    {
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Serviciu { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }
        public string Telefon { get; set; }

        public string Email { get; set; }
        [Display(Name = "Medic")]
        public string NumeMedic { get; set; }
        public string Mesaj { get; set; }

    }
}