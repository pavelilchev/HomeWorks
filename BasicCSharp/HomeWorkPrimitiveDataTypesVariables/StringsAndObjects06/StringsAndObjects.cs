using System;

class StringsAndObjects
{
    static void Main()
    {
        string greetings = "Hello";
        string name = "World";
        object wellcomeNote = greetings + " " + name;
        string newNote = (string)wellcomeNote;
        Console.WriteLine(newNote);
    }
}

