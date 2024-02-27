namespace TextEditor
{
    public interface ICommand
    {
        public void Do();
        public void Undo();
        public void Redo();
    }
}