using System;

namespace TextEditor;
internal class Program
{
    static void Main(string[] args)
    {
        var strArray = new String[3]{"abcd", "bbbb", "cccc"};
        var text = new TextEditor(strArray);
        Console.WriteLine(text);
        text.InsertChar('A');
        text.InsertChar('B');
        text.InsertChar('С');
        text.InsertChar('D');
        Console.WriteLine(text);
        text.Undo();
        text.Undo();
        Console.WriteLine(text);
        text.Redo();
        Console.WriteLine(text);
        text.DeleteChar();
        text.DeleteChar();
        Console.WriteLine(text);
        text.Undo();
        Console.WriteLine(text);
        text.Undo();
        Console.WriteLine(text);
        text.Redo();
        Console.WriteLine(text);
        text.InsertChar('D');
        Console.WriteLine(text);
        text.MoveCursorTo(2, 2);
        text.InsertChar('F');
        Console.WriteLine(text);
        text.DeleteChar();
        Console.WriteLine(text);
    }
}