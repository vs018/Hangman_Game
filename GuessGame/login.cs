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
using GuessGame.Resources.Models;

namespace GuessGame
{
    [Activity(Label = "login")]
    public class login : Activity
    {
        Android.Widget.EditText txt; 
       Android.Widget.EditText txtpwd;
        Android.Widget.Button btn;
        Android.Widget.Button btn1;
        Database db;
        List<Resources.Models.User> listSource = new List<Resources.Models.User>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            db = new Database();
            db.createDatabase();
            txt = FindViewById<EditText>(Resource.Id.edtUser);
            txtpwd = FindViewById<EditText>(Resource.Id.edtpssword);
            btn = FindViewById<Button>(Resource.Id.btnLogin);
            btn.Click += new EventHandler(Btntest_Clicked);
            btn1 = FindViewById<Button>(Resource.Id.btnSignUP);
            btn1.Click += new EventHandler(Btntest1_Clicked);
        }
        // check the conditions with login 
        private void Btntest_Clicked(object sender, EventArgs e)
         {
             String usr = txt.Text.ToString();
             String pwd = txtpwd.Text.ToString();
            listSource = db.checkUser(usr, pwd);
            if (listSource.Count != 0)
            {
                Toast.MakeText(Application.Context, "Login Successful !", ToastLength.Short).Show();
                Intent intent = new Intent(this, typeof(home));
                StartActivity(intent);
            }
            else
            {
                Toast.MakeText(Application.Context, "Invalid Login credentials !", ToastLength.Short).Show();
            }
        }
        // login activity
        private void Btntest1_Clicked(object sender, EventArgs e)
         {
            String usr = txt.Text.ToString();
            String pwd = txtpwd.Text.ToString();
            if (usr!="" && pwd!="")
            {
                Toast.MakeText(Application.Context, "Welcome "+usr+" !", ToastLength.Short).Show();
                Resources.Models.User newUser = new Resources.Models.User()
                {
                    user = usr,
                    pswd = pwd
                };
                db.AddUser(newUser);
                Intent intent = new Intent(this, typeof(home));
                StartActivity(intent);
            }
            else
            {
                Toast.MakeText(Application.Context, "Enter Username & Password", ToastLength.Short).Show();
            }
        }
        public override void OnBackPressed()
        {
            FinishAffinity();
        }
        }
    }