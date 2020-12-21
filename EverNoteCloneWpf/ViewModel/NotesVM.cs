using EverNoteCloneWpf.Model;
using EverNoteCloneWpf.ViewModel.Commands;
using EverNoteCloneWpf.ViewModel.Helpers;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace EverNoteCloneWpf.ViewModel
{
    public class NotesVM : INotifyPropertyChanged
    {
        public ObservableCollection<Notebook> NoteBooks { get; set; }
        public ObservableCollection<Note> Notes { get; set; }
        public NewNotebookCommand NewNotebookCommand { get; set; }
        public NewNoteCommand NewNoteCommand { get; set; }
        public DeleteNotebookCommand DeleteNotebookCommand { get; set; }

        public ObservableCollection<Note> Note { get; set; }

        // inherited from INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;


        private Notebook SelectedNotebook;

        public Notebook SelectedNoteBook
        {
            get { return SelectedNotebook; }
            set 
            { 
                SelectedNotebook = value;
                OnPropertyChanged("SelectedNotebook");
                GetNotes();
            }
        }

        public NotesVM()
        {
            NewNotebookCommand = new NewNotebookCommand(this);
            NewNoteCommand = new NewNoteCommand(this);
            DeleteNotebookCommand = new DeleteNotebookCommand(this);

            NoteBooks = new ObservableCollection<Notebook>();
            Notes = new ObservableCollection<Note>();

            // get all the notebooks into a listview on page load
            GetNotebooks();
        }


        // create new note
        public void CreateNote(int notebookid)
        {
            // set inital values for the new note
            Note newNote = new Note()
            {
                Id = notebookid,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Title = $"New Note for {DateTime.Now.ToString()}"
            };

            // insert the new note into the db
            DatabaseHelper.Insert(newNote);

            // refresh the users side with updated data
            GetNotes();

        }

        // create new notebook
        public void CreateNoteBook()
        {
            Notebook newNoteBook = new Notebook()
            {
                Name = "New Notebook"
            };

            // insert into db
            DatabaseHelper.Insert(newNoteBook);

            // refresh the users side with updated data
            GetNotebooks();
        }

        // Delete notebook
        public void DeleteNoteBook(Notebook selectedNoteBook)
        {
            DatabaseHelper.Delete(selectedNoteBook);
            GetNotebooks();
        }



        private void GetNotebooks()
        {
            var notebooks = DatabaseHelper.Read<Notebook>();
            NoteBooks.Clear();
            foreach (var notebook in notebooks)
            {
                // add each notebook to the observable collection
                NoteBooks.Add(notebook);
            }
        }        
        
        private void GetNotes()
        {
            if (SelectedNotebook != null)
            {
                // get notes for only the selected notebook using LINQ
                var notes = DatabaseHelper.Read<Note>().Where(n => n.NotebookId == SelectedNoteBook.Id).ToList();
                
                Notes.Clear();
                foreach (var note in notes)
                {
                    // add each note to the observable collection
                    Notes.Add(note);
                }
            }
        }


        // very common method for event changes
        private void OnPropertyChanged(string propertyName)
        {
            // this triggers the event property above
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
