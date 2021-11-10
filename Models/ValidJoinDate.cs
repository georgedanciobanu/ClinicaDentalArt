using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicaDentalArt.Models
{
    public class ValidJoinDate : ValidationAttribute
    {
        protected override ValidationResult
                IsValid(object value, ValidationContext validationContext)
        {
            DateTime Data = Convert.ToDateTime(value);
            if (Data > DateTime.Now)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult
                    ("Data programarii trebuie sa fie mai mare decat data curenta.");
            }
        }
    }
}