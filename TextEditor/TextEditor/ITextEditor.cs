interface ITextEditor
{
    void MoveCursorTo(int row, int col);
    void InsertChar(char c);
    void DeleteChar();
    void Undo();
    void Redo();
}