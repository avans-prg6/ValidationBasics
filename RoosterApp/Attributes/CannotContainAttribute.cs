
using System.ComponentModel.DataAnnotations;
using System.Linq;
using RoosterApp.Services;

namespace RoosterApp.Attributes
{
    public class CannotContainAttribute : ValidationAttribute
    {
        readonly char _thechar;

        public CannotContainAttribute(char thechar)
        {
            _thechar = thechar;
        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var caoService = context.GetRequiredService<CAOService>();

            string Naam = (string)value;

            if (Naam.ToUpper().Contains(_thechar)) //WHO DID THIS?!
            {
                var count = Naam.ToUpper().Where(i => i == _thechar).Count();

                return new ValidationResult("U heeft " + count + " " + _thechar + " teveel", new[] { "Naam" });
            }

            return null;
        }
    }
}