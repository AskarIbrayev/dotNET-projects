using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor
{
    public class TextEditor : ITextEditor
    {
        private Cursor _cursor = new();
        private readonly Stack<ICommand> _commandsHistory = new();
        private readonly Stack<ICommand> _undoneHistory = new();
        private readonly LinkedList<LinkedList<char>> _text = new();

        public TextEditor(String[] incomingText)
        {
            foreach (var row in incomingText)
            {
                var currentRow = new LinkedList<char>(row);
                _text.AddLast(currentRow);
            }
        }

        private void ExecuteCommandAddToHistory(ICommand command)
        {
            command.Do();
            _commandsHistory.Push(command);
            _undoneHistory.Clear();
        }
        public void InsertChar(char c)
        {
            var insertCharCommand = new InsertCharCommand(this, c);
            ExecuteCommandAddToHistory(insertCharCommand);
        }

        public void MoveCursorTo(int col, int row)
        {
            var moveCursorCommand = new MoveCursorCommand(this, col, row);
            ExecuteCommandAddToHistory(moveCursorCommand);
        }

        public void DeleteChar()
        {
            var deleteCharCommand = new DeleteCharCommand(this);
            ExecuteCommandAddToHistory(deleteCharCommand);
        }

        public void Undo()
        {
            if (_commandsHistory.Count != 0)
            {
                ICommand command = _commandsHistory.Pop();
                command.Undo();
                _undoneHistory.Push(command);
            }
            else
            {
                throw new InvalidOperationException("There is no commands in history to undo");
            }
        }

        public void Redo()
        {
            if (_undoneHistory.Count != 0)
            {
                ICommand command = _undoneHistory.Pop();
                command.Redo();
                _commandsHistory.Push(command);
            }
            else
            {
                throw new InvalidOperationException("There is no commands in undone history to redo");
            }
        }

        private void InsertCharInternal(char c)
        {
            var currentRow = GetRowOfCursorPosition();

            if (_cursor.Column == currentRow.Count())
            {
                currentRow.AddLast(c);
                return;
            }
            var currentColumn = GetColumnOfCursorPosition(currentRow);
            currentRow.AddBefore(currentColumn, c);

            _cursor.Column++;
        }

        private char DeleteCharInternal()
        {
            char deletedChar;
            var currentRow = GetRowOfCursorPosition();

            if (_cursor.Column == currentRow.Count())
            {
                deletedChar = currentRow.Last.Value;
                currentRow.RemoveLast();
                return deletedChar;
            }
            var currentColumn = GetColumnOfCursorPosition(currentRow);
            
            deletedChar = currentColumn.Previous.Value;
            currentRow.Remove(currentColumn.Previous);

            _cursor.Column--;
            return deletedChar;
        }

        private class Cursor
        {
            public int Column { get; set; } = 0;
            public int Row { get; set; } = 0;
            public void MoveTo(int col, int row)
            {
                Column = col;
                Row = row;
            }
        }

        private class InsertCharCommand : ICommand
        {
            private readonly TextEditor _textEditor;
            private readonly char _c;

            public InsertCharCommand(TextEditor textEditor, char c)
            {
                this._textEditor = textEditor;
                this._c = c;
            }
            public void Do()
            {
                _textEditor.InsertCharInternal(_c);
            }

            public void Undo()
            {
                _textEditor.DeleteCharInternal();
            }

            public void Redo()
            {
                this.Do();
            }
        }

        private class MoveCursorCommand : ICommand
        {
            private TextEditor _textEditor;
            private int _newCol;
            private int _newRow;
            private int _previousCol;
            private int _previousRow;

            public MoveCursorCommand(TextEditor textEditor, int col, int row)
            {
                this._textEditor = textEditor;
                this._newCol = col;
                this._newRow = row;
                this._previousCol = textEditor._cursor.Column;
                this._previousRow = textEditor._cursor.Row;
            }

            public void Do()
            {
                _textEditor._cursor.MoveTo(_newCol, _newRow);
            }

            public void Undo()
            {
                _textEditor._cursor.MoveTo(_previousCol, _previousRow);
            }

            public void Redo()
            {
                this.Do();
            }

        }
        private class DeleteCharCommand : ICommand
        {
            private TextEditor _textEditor;
            private char _deletedChar;
            public DeleteCharCommand(TextEditor textEditor)
            {
                this._textEditor = textEditor;
            }
            public void Do()
            {
                _deletedChar = _textEditor.DeleteCharInternal();
            }
            public void Undo()
            {
                _textEditor.InsertCharInternal(_deletedChar);
            }

            public void Redo()
            {
                this.Do();
            }

        }

        private LinkedList<char> GetRowOfCursorPosition()
        {
            var currentRow = _text.First;
            for (var i = 0; i < _cursor.Row; i++)
            {
                currentRow = currentRow.Next;
            }
            return currentRow.Value;
        }
        private LinkedListNode<char> GetColumnOfCursorPosition(LinkedList<char> currentString)
        {
            var currentColumn = currentString.First;
            for (var i = 0; i < _cursor.Column; i++)
            {
                currentColumn = currentColumn.Next;
            }
            return currentColumn;
        }

        public override string ToString()
        {
            String[] resultString = new String[_text.Count];
            var row = _text.First;
            var currentString = row.Value;
            for (var i = 0; i < _text.Count; i++)
            {
                currentString = row.Value;
                var currentChar = currentString.First;
                var rowString = new StringBuilder("");
                for (var j = 0; j < currentString.Count; j++)
                {
                    rowString.Append(currentChar.Value);
                    currentChar = currentChar.Next;
                }
                row = row.Next;
                resultString[i] = rowString.ToString();
            }
            return string.Join("\n", resultString);
        }

    }
}
