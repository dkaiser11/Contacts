using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace Contacts.WPF.Validators
{
    public class PhoneNumberRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string tvalue = value as string;
            if (!Regex.IsMatch(tvalue, @"^\+?[\d*#]*$"))
            {
                return new ValidationResult(false, "Phone numbers can only contain digits, number signs and asterisks and can have a plus sign at the start.");
            }
            return ValidationResult.ValidResult;
        }
    }
}