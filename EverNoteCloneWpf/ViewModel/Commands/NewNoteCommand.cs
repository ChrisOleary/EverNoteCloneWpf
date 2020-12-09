﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace EverNoteCloneWpf.ViewModel.Commands
{
    public class NewNoteCommand : ICommand
    {
        public NotesVM VM { get; set; }

        public NewNoteCommand newNoteCommand { get; set; }

        public NewNoteCommand(NotesVM vm)
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
