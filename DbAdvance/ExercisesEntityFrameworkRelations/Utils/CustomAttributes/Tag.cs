namespace Utils.CustomAttributes
{
    using System;
    using System.ComponentModel.DataAnnotations;

    [AttributeUsage(AttributeTargets.Property |
    AttributeTargets.Field, AllowMultiple = false)]
    public class TagAttribute : ValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            string value = obj.ToString();
            if (string.IsNullOrEmpty(value) || !value.StartsWith("#") || value.IndexOf(' ') >= 0 || value.Length > 20)
            {
                return false;
            }

            return true;
        }
    }
}
