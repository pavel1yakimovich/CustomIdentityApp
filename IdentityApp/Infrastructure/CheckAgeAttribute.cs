using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityApp.Infrastructure
{
    public class CheckAgeAttribute : ValidationAttribute, IClientValidatable
    {
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule();
            rule.ErrorMessage = "Your age should be >16 (ClientSide).";
            rule.ValidationType = "checkage";
            rule.ValidationParameters.Add("param", DateTime.Now.Year.ToString());
            return new List<ModelClientValidationRule> { rule };
        }

        public override bool IsValid(object value)
        {
            int yearOfBirth = (int)value;
            int year = DateTime.Now.Year;
            
            if (year - yearOfBirth < 16)
            {
                ErrorMessage = "Your age should be >16.";
                return false;
            }

            return base.IsValid(value);
        }
    }
}