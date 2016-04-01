namespace Problem3FastSearchForStringsInTextFile
{
    using System.Collections.Generic;
    using System.Linq;

    public class Trie
    {
        public Node RootNode { get; private set; }

        public Trie()
        {
            this.RootNode = new Node
            {
                Letter = Node.Root
            };
        }

        public void Add(string word)
        {
            word = word.ToLower() + Node.Eow;
            var currentNode = this.RootNode;
            foreach (var c in word)
            {
                currentNode = currentNode.AddChild(c);
            }
        }

        public List<string> Match(string prefix, int? maxMatches)
        {
            prefix = prefix.ToLower();

            var set = new HashSet<string>();

            MatchRecursive(this.RootNode, set, "", prefix, maxMatches);
            return set.ToList();
        }

        private static void MatchRecursive(Node node, ISet<string> rtn, string letters, string prefix, int? maxMatches)
        {
            if (maxMatches != null && rtn.Count == maxMatches)
            {
                return;
            }

            if (node == null)
            {
                if (!rtn.Contains(letters))
                {
                    rtn.Add(letters);
                }

                return;
            }

            letters += node.Letter.ToString();

            if (prefix.Length > 0)
            {
                if (node.ContainsKey(prefix[0]))
                {
                    MatchRecursive(node[prefix[0]], rtn, letters, prefix.Remove(0, 1), maxMatches);
                }
            }
            else
            {
                foreach (char key in node.Keys)
                {
                    MatchRecursive(node[key], rtn, letters, prefix, maxMatches);
                }
            }
        }
    }
}
