namespace BankSystem.Attributes
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;

    public class UsernameAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string username = value.ToString();
            string pattern = "[a-zA-Z][a-zA-Z0-9]{2,}";
            if (Regex.IsMatch(username, pattern))
            {
                return true;
            }

            return false;
        }
    }
}
