using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace Contacts.WPF.Validators
{
    public class AddressRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string tvalue = value as string;
            if (!Regex.IsMatch(tvalue, @"^[\w,.#()\-\s]*$"))
            {
                return new ValidationResult(false, "Addresses can only contain word characters, spaces and the following characters: \",.#()-\"");
            }
            else if (!Regex.IsMatch(tvalue, @"^\w") && !string.IsNullOrEmpty(tvalue))
            {
                return new ValidationResult(false, "Addresses can only start with a word character.");
            }
            else if (Regex.IsMatch(tvalue, @"\s$"))
            {
                return new ValidationResult(false, "Addresses cannot end with a space character.");
            }
            else if (Regex.IsMatch(tvalue, @"\s\s"))
            {
                return new ValidationResult(false, "Addresses can only have gaps with just one space character.");
            }
            return ValidationResult.ValidResult;
        }
    }
}