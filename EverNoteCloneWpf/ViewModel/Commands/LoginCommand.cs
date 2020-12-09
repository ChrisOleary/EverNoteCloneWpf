using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace EverNoteCloneWpf.ViewModel.Commands
{
    public class LoginCommand : ICommand
    {
        public LoginVM VM { get; set; }
        public LoginCommand loginCommand { get; set; }

        public LoginCommand(LoginVM vm)
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
            // todo add login method
        }
    }
}
