using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace EverNoteCloneWpf.ViewModel.Commands
{
    public class RegisterCommand : ICommand
    {
        public LoginVM VM { get; set; }

        public RegisterCommand register { get; set; }

        public RegisterCommand(LoginVM vm)
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
            // todo add register method
        }
    }
}
