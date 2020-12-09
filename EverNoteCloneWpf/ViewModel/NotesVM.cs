using EverNoteCloneWpf.Model;
using EverNoteCloneWpf.ViewModel.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace EverNoteCloneWpf.ViewModel
{
    public class NotesVM : INotifyPropertyChanged
    {
        public ObservableCollection<Notebook> NoteBooks { get; set; }

        private Notebook SelectedNotebook;

        public Notebook SelectedNoteBook
        {
            get { return SelectedNotebook; }
            set 
            { 
                SelectedNotebook = value;
                OnPropertyChanged("SelectedNotebook");
                // TODO: Get the notes
            }
        }

        public ObservableCollection<Note> Notes { get; set; }
        public NewNotebookCommand NewNotebookCommand { get; set; }
        public NewNoteCommand NewNoteCommand { get; set; }


        public NotesVM()
        {
            NewNotebookCommand = new NewNotebookCommand(this);
            NewNoteCommand = new NewNoteCommand(this);
        }

        public ObservableCollection<Note> Note { get; set; }

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
