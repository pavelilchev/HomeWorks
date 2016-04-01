namespace Problem2StringEditor
{
    using System;

    public class StringEditorTest
    {
        public static void Main()
        {
            var editor = new StringEditor();

            string input = Console.ReadLine();
            int firstSpace = input.IndexOf(" ");
            string command = input.Substring(0, firstSpace);

            while (command != "END")
            {
                string output;
                switch (command)
                {
                    case "APPEND":
                        output= editor.Append(input.Substring(firstSpace + 1));
                        break;
                    case "INSERT":
                        int secondSpace = input.IndexOf(" ", firstSpace + 1);
                        string positionAsString = input.Substring(firstSpace + 1, secondSpace - firstSpace);
                        int position = int.Parse(positionAsString);
                        output = editor.Insert(position, input.Substring(secondSpace + 1));
                        break;
                    case "DELETE":
                        var deleteArgs = input.Split();
                        output = editor.Delete(int.Parse(deleteArgs[1]), int.Parse(deleteArgs[2]));
                        break;
                    case "REPLACE":
                        deleteArgs = input.Split();
                        output = editor.Replace(int.Parse(deleteArgs[1]), int.Parse(deleteArgs[2]), deleteArgs[3]);
                        break;
                    case "PRINT":
                        output = editor.Print();
                        break;
                    default: throw new NotSupportedException();
                }

                Console.WriteLine(output);
                input = Console.ReadLine();
                 firstSpace = input.IndexOf(" ");
                if (firstSpace >= 0)
                {
                    command = input.Substring(0, firstSpace);
                }
                else
                {
                    command = input;
                }
            }
        }
    }
}
