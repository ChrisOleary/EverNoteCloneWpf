﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EverNoteCloneWpf.Model
{
    class Note
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Indexed] // works similar to foriegn key
        public int NotebookId { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime dateTime { get; set; }
        public string FileLocation { get; set; }
    }
}