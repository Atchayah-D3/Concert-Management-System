using System.ComponentModel.DataAnnotations;
using WebApplication1.DTO.Request;

namespace WebApplication1.ModelValidation
{
    public class BookingDateTimeAttribute :ValidationAttribute
    { 
        public string Error => "The end date/time must be after the start date/time.";
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (((HallBookingReqDto)validationContext.ObjectInstance).HallId == 0)
                return ValidationResult.Success;
            var ToDateTime = ((HallBookingReqDto)validationContext.ObjectInstance).ToDateTime;
            var FromDateTime = ((HallBookingReqDto)validationContext.ObjectInstance).FromDateTime;            
            if (ToDateTime <=FromDateTime)
                return new ValidationResult(Error);
            return ValidationResult.Success;
        }
    }
}
