using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EverNoteCloneWpf.Model
{
    public class Notebook
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }

        public string NoteFullName
        {
            get { return $"New Notebook: {Id}"; }
           
        }

    }
}
