using EverNoteCloneWpf.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace EverNoteCloneWpf.ViewModel.Commands
{
    public class DeleteNotebookCommand : ICommand
    {
        public DeleteNotebookCommand deleteNotebookCommand { get; set; }

        public NotesVM VM { get; set; }

        public DeleteNotebookCommand(NotesVM vm)
        {
            VM = vm;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }


        public bool CanExecute(object parameter)
        {
            Notebook selectedNotebook = parameter as Notebook;
            if (selectedNotebook != null)
                return true;
            return false;
        }

        public void Execute(object parameter)
        {
            VM.DeleteNoteBook(VM.SelectedNoteBook);
        }
    }
}
