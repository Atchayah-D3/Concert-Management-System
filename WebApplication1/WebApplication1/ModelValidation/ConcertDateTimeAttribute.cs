
using System.ComponentModel.DataAnnotations;
using WebApplication1.DTO.Request;
using WebApplication1.Models;

namespace WebApplication1.ModelValidation
{
    public class ConcertDateTimeAttribute :ValidationAttribute
    {
        public string Error => "Can't create Concerts in past date and time.";
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var dateTime =((ConcertSpecReqDto)validationContext.ObjectInstance).Date_Time;
            if (dateTime <= DateTime.Now)
                return new ValidationResult(Error);
            return ValidationResult.Success;
        }
    }
}
