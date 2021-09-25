using Android.Util;
using SQLite;
using GuessGame.Resources.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace GuessGame.Resources.Models
{
    public class Database
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        public bool createDatabase()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Word.db")))
                {
                    connection.CreateTable<Word>();
                }
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "User.db")))
                {
                    connection.CreateTable<User>();
                }
                return true;
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }
        public bool insertIntoTable(Word word)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Word.db")))
                {
                    connection.Insert(word);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }
        public bool AddUser(User user)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "User.db")))
                {
                    connection.Insert(user);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }
        public List<User> checkUser(String u, String p)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "User.db")))
                {
                    return connection.Query<User>("Select * from User Where user=? and pswd=?", u, p);
                }

            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }

        public List<Word> selectTable()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Word.db")))
                {
                    return connection.Table<Word>().ToList();
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }
        public bool updateTable(Word word,String type)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Word.db")))
                {
                    if (type == "img")
                    {
                        connection.Query<Word>("UPDATE Word set text=?, hint=?, img=? Where WordID=?", word.text, word.hint, word.img, word.WordID);
                    }
                    else
                    {
                        connection.Query<Word>("UPDATE Word set text=?, hint=? Where WordID=?", word.text, word.hint, word.WordID);
                    }
                        return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }
        public bool removeTable(Word word)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Word.db")))
                {
                    connection.Delete(word);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }
        public bool selectTable(int Id)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Word.db")))
                {
                    connection.Query<Word>("SELECT * FROM Word Where WordID=?", Id);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }
    }
}