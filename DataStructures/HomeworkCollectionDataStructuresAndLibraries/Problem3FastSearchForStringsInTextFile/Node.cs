namespace Problem3FastSearchForStringsInTextFile
{
    using System.Collections;
    using System.Collections.Specialized;

    public class Node
    {
        public const char Eow = '$';
        public const char Root = ' ';

        public Node(char letter = default(char))
        {
            this.Letter = letter;
        }

        public char Letter { get; set; }

        public HybridDictionary Children { get; private set; }

        public Node this[char index]
        {
            get
            {
                return (Node) this.Children[index];
            }
        }

        public ICollection Keys
        {
            get
            {
                return this.Children.Keys;
            }
        }

        public bool ContainsKey(char key)
        {
            return this.Children.Contains(key);
        }

        public Node AddChild(char letter)
        {
            if (this.Children == null)
            {
                this.Children = new HybridDictionary();
            }

            if (!this.Children.Contains(letter))
            {
                var node = letter != Eow ? new Node(letter) : null;
                this.Children.Add(letter, node);
                return node;
            }

            return (Node) this.Children[letter];
        }

        public override string ToString()
        {
            return this.Letter.ToString();
        }
    }
}
