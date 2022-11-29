using System.ComponentModel.DataAnnotations;

namespace RoosterApp.Controllers
{
    public class FormulierVM : IValidatableObject
    {
        //Geen spaties!
        [Required]
        [MinLength(2)]
        [CannotContain('J')]
        public string Naam { get; set; }
        public FormulierVM()
        {
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var count = Naam.ToUpper().Where(i => i == 'X').Count();


            if (count > 3)
            {
                yield return new ValidationResult("U mag maximaal 3x een X gebruiken", new[] { "Naam" });
            }
        }
    }
}