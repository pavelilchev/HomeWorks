namespace SocialNetwork.Models
{
    using System.ComponentModel.DataAnnotations;

    public class TagAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var tag = value as string;
            if(tag == null)
            {
                return true;
            }

            return IsValidTag(tag);
        }

        private bool IsValidTag(string tag)
        {
            var isValid = true;
            if (!tag.StartsWith('#') || tag.Contains(string.Empty) || tag.Length > 20)
            {
                isValid = false;
            }

            return isValid;
        }
    }
}