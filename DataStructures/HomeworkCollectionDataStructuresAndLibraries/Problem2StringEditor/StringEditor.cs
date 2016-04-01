namespace Problem2StringEditor
{
    using System;
    using System.Text;
    using Wintellect.PowerCollections;

    public class StringEditor
    {
        private BigList<char> text; 

        public StringEditor()
        {
            this.text = new BigList<char>();
        }

        public string Append(string str)
        {
            foreach (char c in str)
            {
                this.text.Add(c);
            }

            return "OK";
        }

        public string Insert(int position, string str)
        {
            if (0 > position || position > this.text.Count)
            {
                return "ERROR";
            }

            int index = 0;
            for (int i = position; i < str.Length + position; i++)
            {
                this.text.Insert(i, str[index]);
                index++;
            }
           
            return "OK";
        }

        public string Delete(int startIndex, int count)
        {
            if (0 > startIndex || startIndex + count > this.text.Count)
            {
                return "ERROR";
            }

            this.text.RemoveRange(startIndex, count);
            return "OK";
        }

        public string Replace(int startIndex, int count, string str)
        {
            if (0 > startIndex || startIndex + count > this.text.Count)
            {
                return "ERROR";
            }

            this.Delete(startIndex, count);
            this.Insert(startIndex, str);
            return "OK";
        }

        public string Print()
        {
            var output = new StringBuilder();
            foreach (char c in this.text)
            {
                output.Append(c);
            }

            return output.ToString();
        }
    }
}
