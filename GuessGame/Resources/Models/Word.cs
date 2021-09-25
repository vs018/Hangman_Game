using SQLite;
using System;

namespace GuessGame.Resources.Models
{
    public class Word
    {
        [PrimaryKey, AutoIncrement]
        public int WordID { get; set; }
        public string hint { get; set; }
        public string text { get; set; }
        public byte[] img { get; set; }
    }
}