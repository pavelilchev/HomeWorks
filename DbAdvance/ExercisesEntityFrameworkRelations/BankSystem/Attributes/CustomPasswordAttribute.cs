namespace BankSystem.Attributes
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;

    public class CustomPasswordAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string pass = value.ToString();
            string pattern = @"^.*(?=.{6,})(?=.*[A-Z])(?=.*[a-z])(?=.*\d).*$";
            if (Regex.IsMatch(pass, pattern))
            {
                return true;
            }

            return false;
        }
    }
}
