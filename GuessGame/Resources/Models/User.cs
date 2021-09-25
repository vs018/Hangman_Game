using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace GuessGame.Resources.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int userID { get; set; }
        public string user { get; set; }
        public string pswd { get; set; }
    }
}