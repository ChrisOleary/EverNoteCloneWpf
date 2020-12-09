using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace EverNoteCloneWpf.ViewModel.Commands
{
    public class NewNotebookCommand : ICommand
    {
        public NewNotebookCommand newNotebook { get; set; }

        public NotesVM VM { get; set; }

        public NewNotebookCommand(NotesVM vm)
        {
            VM = vm;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            // TODO
        }
    }
}
