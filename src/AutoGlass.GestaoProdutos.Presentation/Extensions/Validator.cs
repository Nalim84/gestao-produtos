using System.ComponentModel.DataAnnotations;

namespace AutoGlass.GestaoProdutos.Presentation.Validator
{
    public class FutureDateOnlyAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime)
            {
                if ((DateTime)value > DateTime.Now)
                {
                    return true;
                }
            }
            return false;
        }
    }

    public class DateGreaterThanAttribute : ValidationAttribute
    {
        private readonly string _dateToCompareToFieldName;

        public DateGreaterThanAttribute(string dateToCompareToFieldName)
        {
            _dateToCompareToFieldName = dateToCompareToFieldName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime laterDate = (DateTime)value;

            DateTime earlierDate = (DateTime)validationContext.ObjectType.GetProperty(_dateToCompareToFieldName).GetValue(validationContext.ObjectInstance, null);

            if (laterDate > earlierDate)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(ErrorMessage);
            }
        }
    }

    public class DateIsNotDateTimeMinAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null && value is DateTime)
            {
                if ((DateTime)value > DateTime.MinValue)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
