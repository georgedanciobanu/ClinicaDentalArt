using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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