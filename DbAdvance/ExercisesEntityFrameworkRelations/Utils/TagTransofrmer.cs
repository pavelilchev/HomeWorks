namespace Utils
{
    using System;

    public static class TagTransofrmer
    {
        public static string Transform(string tag)
        {

            if (!tag.StartsWith("#"))
            {
                tag = "#" + tag;
            }

            tag = tag.Replace(" ", "");
            tag = tag.Substring(0, Math.Min(20, tag.Length));

            return tag;
        }
    }
}
