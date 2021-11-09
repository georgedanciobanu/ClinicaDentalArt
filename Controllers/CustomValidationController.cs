using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClinicaDentalArt.Controllers
{
    public class CustomValidationController : Controller
    {
        public ActionResult Index()
        {
            return View(model);
        }
    }
    public class GreaterThanAttribute : ValidationAttribute, IClientValidatable
    {
        public GreaterThanAttribute(string otherProperty)
        {
            ErrorMessage = "{0} must be greater than {1}.";
            OtherProperty = otherProperty;
        }

            public string OtherProperty { get; private set; }
        string FormatErrorMessage(string thisPropertyDisplayName, string otherPropertyDisplayName)
        {
            return String.Format(ErrorMessageString, thisPropertyDisplayName, otherPropertyDisplayName);
        }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata)
        {
            var otherPropertyMetadata = ModelMetadataProviders.Current.GetMetadataForProperty(null, metadata);
            var rule = new ModelClientValidationRule
            {
                FormatErrorMessage = FormatErrorMessage(
                    metadata.GetDisplayName())
            }

        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherProperty = validationContext.ObjectType.GetProperty(this.OtherProperty);
            var otherValue = (int)otherProperty.GetValue(validationContext.ObjectInstance, null);
            var thisValue = (int)value;
            if (thisValue > otherValue)
                return null;
            var otherPropertyMetadata = ModelMetadataProviders.Current.GetMetadataForProperty(() => value);
            return new ValidationResult(
                FormatErrorMessage(
                    validationContext.DisplayName,
                    otherPropertyMetadata.GetDisplayName()
                    )
                );
        }

    }
}