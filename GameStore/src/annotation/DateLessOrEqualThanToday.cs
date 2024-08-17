using System.ComponentModel.DataAnnotations;

namespace app.annotation;

public class DateLessThanOrEqualToToday : ValidationAttribute
{
  public override string FormatErrorMessage(string name)
  {
    return "Date value should not be a future date";
  }

  protected override ValidationResult IsValid(object objValue,
                                                 ValidationContext validationContext)
  {
    var dateValue = objValue as DateTime? ?? new DateTime();


    if (dateValue.Date > DateTime.Now.Date)
    {
      return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
    }
    return ValidationResult.Success;
  }
}