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
                int rows = conn.Insert(item);
               
                if (rows > 0)
                    result = true;
                
            }
            
            return result;
        }

        public static bool Delete<T>(T item)
        {
            var result = false;

            using (SQLiteConnection conn = new SQLiteConnection(dbFile))
            {
            
                conn.CreateTable<T>();
                int rows = conn.Delete(item);
                if (rows > 0)
                    return true;
            }
            return result;
        }

        public static List<T> Read<T>() where T : new() // where T : new() is needed to use the generic version of conn.Table<T>
        {
            List<T> items;

            using (SQLiteConnection conn = new SQLiteConnection(dbFile))
            {
                conn.CreateTable<T>();
                items = conn.Table<T>().ToList();
            }
            return items;
        }
    }
}
