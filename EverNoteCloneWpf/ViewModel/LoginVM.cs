using EverNoteCloneWpf.Model;
using EverNoteCloneWpf.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace EverNoteCloneWpf.ViewModel
{
    public class LoginVM : INotifyPropertyChanged
    {
        private User user;

        public User User
        {
            get { return user; }
            set 
            { 
                user = value;

                OnPropertyChanged("Register");


            }
        }

       

        public LoginCommand LoginCommand { get; set; }

        public RegisterCommand RegisterCommand { get; set; }

        public LoginVM()
        {
            // initialize the Commands
            LoginCommand = new LoginCommand(this);
            RegisterCommand = new RegisterCommand(this);
        }

        // inherited from INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        // very common method for event changes
        private void OnPropertyChanged(string propertyName)
        {
            // this triggers the event property above
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
