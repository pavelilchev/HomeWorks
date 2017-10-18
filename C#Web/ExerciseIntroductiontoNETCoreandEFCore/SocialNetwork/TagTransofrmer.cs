namespace SocialNetwork
{
    public static class TagTransofrmer
    {
		public static string Transform(string tag)
        {
            tag = tag.Replace(" ", string.Empty);
            if(!tag.StartsWith('#'))
            {
                tag = $"#{tag}";
            }

            if(tag.Length > 20)
            {
                tag = tag.Substring(0, 20);
            }

            return tag;
        }
    }
}
