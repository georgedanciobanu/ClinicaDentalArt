using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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