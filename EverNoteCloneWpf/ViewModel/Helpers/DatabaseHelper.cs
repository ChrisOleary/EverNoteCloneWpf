using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EverNoteCloneWpf.ViewModel.Helpers
{
    public class DatabaseHelper
    {
        private static string dbFile = Path.Combine(Environment.CurrentDirectory, "notesDb.db3");

        public static bool Insert<T>(T item)
        {
            bool result = false;

            using (SQLiteConnection conn = new SQLiteConnection(dbFile))
            {
                conn.CreateTable<T>();
            }


            return result;
        }
    }
}
