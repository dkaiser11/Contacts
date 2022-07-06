using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace Contacts.WPF.Validators
{
    internal class NameRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string tvalue = value as string;
            if (string.IsNullOrWhiteSpace(tvalue))
            {
                return new ValidationResult(false, "Names cannot be white space only.");
            }
            else if (!Regex.IsMatch(tvalue, @"^[\w,.()\s]*$"))
            {
                return new ValidationResult(false, "Names can only contain word characters, commas, periods, brackets and spaces.");
            }
            else if (!Regex.IsMatch(tvalue, @"^\w"))
            {
                return new ValidationResult(false, "Names have to start with a word character.");
            }
            else if (!Regex.IsMatch(tvalue, @"\w$"))
            {
                return new ValidationResult(false, "Names have to end with a word character.");
            }
            else if (Regex.IsMatch(tvalue, @"\s\s"))
            {
                return new ValidationResult(false, "Names can only have gaps of one space character.");
            }
            return ValidationResult.ValidResult;
        }
    }
}