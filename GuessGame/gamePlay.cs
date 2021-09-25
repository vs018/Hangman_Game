using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GuessGame.Resources.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GuessGame
{
    [Activity(Label = "gamePlay")]
    public class gamePlay : Activity
    {
        Android.Widget.Button btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn10, btn11, btn12, btn13, btn14, btn15, btn16, btn17, btn18, btn19, btn20, btn21, btn22, btn23, btn24, btn25, btn26;
        Random rd = new Random();
        int i = 0;
        int p1 = 0;
        int p2=0;
        int m = 1;
        int round=1;
        String player;
        Android.Widget.TextView txt;
        Android.Widget.TextView hint;
        Android.Widget.TextView level;
        Android.Widget.Button score1;
        Android.Widget.Button score2;
        Android.Widget.ImageView img;
        Android.Widget.EditText w;
        Android.Widget.ImageView hIMG;
        String wrd = "";
        String hnt = "";
        String j = "";
        int chnce = 0;
        Database db;
        List<Resources.Models.Word> listSource = new List<Resources.Models.Word>();

        private void LoadData()
        {
        
            if (db.selectTable() != null && db.selectTable().Count != 0 )
            {
                    listSource = db.selectTable();
            }
            else
            {
                Resources.Models.Word wordsText1 = new Resources.Models.Word() { text = "Blue", hint = "Color" };
                db.insertIntoTable(wordsText1);
                      Resources.Models.Word wordsText2 = new Resources.Models.Word() { text = "Black", hint = "Color" };
                       db.insertIntoTable(wordsText2);
                       Resources.Models.Word wordsText3 = new Resources.Models.Word() { text = "White", hint = "Color" };
                       db.insertIntoTable(wordsText3);
                       Resources.Models.Word wordsText4 = new Resources.Models.Word() { text = "Tiger", hint = "Animal" };
                       db.insertIntoTable(wordsText4);
                       Resources.Models.Word wordsText5 = new Resources.Models.Word() { text = "Lion", hint = "Animal" };
                       db.insertIntoTable(wordsText5);
                       Resources.Models.Word wordsText6 = new Resources.Models.Word() { text = "Hourse", hint = "Animal" };
                       db.insertIntoTable(wordsText6);
                       Resources.Models.Word wordsText7 = new Resources.Models.Word() { text = "Pune", hint = "City" };
                       db.insertIntoTable(wordsText7);
                       Resources.Models.Word wordsText8 = new Resources.Models.Word() { text = "Mumbai", hint = "City" };
                       db.insertIntoTable(wordsText8);
                       Resources.Models.Word wordsText9 = new Resources.Models.Word() { text = "Delhi", hint = "City" };
                       db.insertIntoTable(wordsText9);
                       Resources.Models.Word wordsText10 = new Resources.Models.Word() { text = "Apple", hint = "Fruit" };
                       db.insertIntoTable(wordsText10);
                       Resources.Models.Word wordsText11 = new Resources.Models.Word() { text = "Mango", hint = "Fruit" };
                       db.insertIntoTable(wordsText11);
                       Resources.Models.Word wordsText12 = new Resources.Models.Word() { text = "Banana", hint = "Fruit" };
                       db.insertIntoTable(wordsText12);
                       listSource = db.selectTable();
                   
            }
        }

        // single player 
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            player = Intent.GetStringExtra("player") ?? "Single";
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.game);
            db = new Database();
            db.createDatabase();
            LoadData();
            score1 = FindViewById<Button>(Resource.Id.txtScore1);
            score2 = FindViewById<Button>(Resource.Id.txtScore2);
            i = rd.Next(0, listSource.Count);
            txt = FindViewById<TextView>(Resource.Id.txtWord);
            hint = FindViewById<TextView>(Resource.Id.txtHint);
            w = FindViewById<EditText>(Resource.Id.wordAlt);
            img = FindViewById<ImageView>(Resource.Id.img);
            hIMG = FindViewById<ImageView>(Resource.Id.hntIMG);
            img.SetImageResource(Resource.Drawable.hanger);

            // if two players selected
            if (player == "Two")
            {
                score1.Visibility = ViewStates.Visible;
                var dialogview = LayoutInflater.Inflate(Resource.Layout.hintAlert, null);
                Android.App.AlertDialog.Builder dialo = new AlertDialog.Builder(this);

                AlertDialog alert = dialo.Create();
                alert.SetTitle("Enter word for Player-1");
                alert.SetView(dialogview);
                alert.SetButton("Save", (c, ev) =>
                {
                    if (dialogview.FindViewById<EditText>(Resource.Id.wordAlt).Text != "")
                    {
                        wrd = dialogview.FindViewById<EditText>(Resource.Id.wordAlt).Text;
                        hnt = "  " + dialogview.FindViewById<EditText>(Resource.Id.hintAlt).Text + "  ";

                        
                        hint.Text = hnt;
                        String h = "";
                        for (int y = 0; y < wrd.Length; y++)
                        {
                            h = h + "-";
                        }
                        txt.Text = h;
                        j = h;
                        hint = FindViewById<TextView>(Resource.Id.txtHint);
                        level = FindViewById<TextView>(Resource.Id.txtRound);
                        btn1 = FindViewById<Button>(Resource.Id.btn1);
                        btn2 = FindViewById<Button>(Resource.Id.btn2);
                        btn3 = FindViewById<Button>(Resource.Id.btn3);
                        btn4 = FindViewById<Button>(Resource.Id.btn4);
                        btn5 = FindViewById<Button>(Resource.Id.btn5);
                        btn6 = FindViewById<Button>(Resource.Id.btn6);
                        btn7 = FindViewById<Button>(Resource.Id.btn7);
                        btn8 = FindViewById<Button>(Resource.Id.btn8);
                        btn9 = FindViewById<Button>(Resource.Id.btn9);
                        btn10 = FindViewById<Button>(Resource.Id.btn10);
                        btn11 = FindViewById<Button>(Resource.Id.btn11);
                        btn12 = FindViewById<Button>(Resource.Id.btn12);
                        btn13 = FindViewById<Button>(Resource.Id.btn13);
                        btn14 = FindViewById<Button>(Resource.Id.btn14);
                        btn15 = FindViewById<Button>(Resource.Id.btn15);
                        btn16 = FindViewById<Button>(Resource.Id.btn16);
                        btn17 = FindViewById<Button>(Resource.Id.btn17);
                        btn18 = FindViewById<Button>(Resource.Id.btn18);
                        btn19 = FindViewById<Button>(Resource.Id.btn19);
                        btn20 = FindViewById<Button>(Resource.Id.btn20);
                        btn21 = FindViewById<Button>(Resource.Id.btn21);
                        btn22 = FindViewById<Button>(Resource.Id.btn22);
                        btn23 = FindViewById<Button>(Resource.Id.btn23);
                        btn24 = FindViewById<Button>(Resource.Id.btn24);
                        btn25 = FindViewById<Button>(Resource.Id.btn25);
                        btn26 = FindViewById<Button>(Resource.Id.btn26);

                        btn1.Click += new EventHandler(Btn1_Clicked);
                        btn2.Click += new EventHandler(Btn2_Clicked);
                        btn3.Click += new EventHandler(Btn3_Clicked);
                        btn4.Click += new EventHandler(Btn4_Clicked);
                        btn5.Click += new EventHandler(Btn5_Clicked);
                        btn6.Click += new EventHandler(Btn6_Clicked);
                        btn7.Click += new EventHandler(Btn7_Clicked);
                        btn8.Click += new EventHandler(Btn8_Clicked);
                        btn9.Click += new EventHandler(Btn9_Clicked);
                        btn10.Click += new EventHandler(Btn10_Clicked);
                        btn11.Click += new EventHandler(Btn11_Clicked);
                        btn12.Click += new EventHandler(Btn12_Clicked);
                        btn13.Click += new EventHandler(Btn13_Clicked);
                        btn14.Click += new EventHandler(Btn14_Clicked);
                        btn15.Click += new EventHandler(Btn15_Clicked);
                        btn16.Click += new EventHandler(Btn16_Clicked);
                        btn17.Click += new EventHandler(Btn17_Clicked);
                        btn18.Click += new EventHandler(Btn18_Clicked);
                        btn19.Click += new EventHandler(Btn19_Clicked);
                        btn20.Click += new EventHandler(Btn20_Clicked);
                        btn21.Click += new EventHandler(Btn21_Clicked);
                        btn22.Click += new EventHandler(Btn22_Clicked);
                        btn23.Click += new EventHandler(Btn23_Clicked);
                        btn24.Click += new EventHandler(Btn24_Clicked);
                        btn25.Click += new EventHandler(Btn25_Clicked);
                        btn26.Click += new EventHandler(Btn26_Clicked);

                    }
                    else
                    {
                        wrd = listSource[i].text.ToUpper();
                        hnt = "  " + listSource[i].hint.ToUpper() + "  ";
                    }
                });
                alert.Show();
            }
            else
            {
                score1.Visibility = ViewStates.Invisible;
                wrd = listSource[i].text.ToUpper();
                hnt = "  " + listSource[i].hint.ToUpper() + "  ";

                if (listSource[i].img != null)
                {
                    byte[] imageArray = listSource[i].img;
                    Android.Graphics.Bitmap bitmap = BitmapFactory.DecodeByteArray(imageArray, 0, imageArray.Length);
                    hIMG.SetImageBitmap(bitmap);
                }
                else
                {
                    hIMG.SetImageResource(Resource.Drawable.hint);
                }

                hint.Text = hnt;
                String h = "";
                for (int y = 0; y < wrd.Length; y++)
                {
                    h = h + "-";
                }
                txt.Text = h;
                j = h;
                hint = FindViewById<TextView>(Resource.Id.txtHint);
                level = FindViewById<TextView>(Resource.Id.txtRound);
                btn1 = FindViewById<Button>(Resource.Id.btn1);
                btn2 = FindViewById<Button>(Resource.Id.btn2);
                btn3 = FindViewById<Button>(Resource.Id.btn3);
                btn4 = FindViewById<Button>(Resource.Id.btn4);
                btn5 = FindViewById<Button>(Resource.Id.btn5);
                btn6 = FindViewById<Button>(Resource.Id.btn6);
                btn7 = FindViewById<Button>(Resource.Id.btn7);
                btn8 = FindViewById<Button>(Resource.Id.btn8);
                btn9 = FindViewById<Button>(Resource.Id.btn9);
                btn10 = FindViewById<Button>(Resource.Id.btn10);
                btn11 = FindViewById<Button>(Resource.Id.btn11);
                btn12 = FindViewById<Button>(Resource.Id.btn12);
                btn13 = FindViewById<Button>(Resource.Id.btn13);
                btn14 = FindViewById<Button>(Resource.Id.btn14);
                btn15 = FindViewById<Button>(Resource.Id.btn15);
                btn16 = FindViewById<Button>(Resource.Id.btn16);
                btn17 = FindViewById<Button>(Resource.Id.btn17);
                btn18 = FindViewById<Button>(Resource.Id.btn18);
                btn19 = FindViewById<Button>(Resource.Id.btn19);
                btn20 = FindViewById<Button>(Resource.Id.btn20);
                btn21 = FindViewById<Button>(Resource.Id.btn21);
                btn22 = FindViewById<Button>(Resource.Id.btn22);
                btn23 = FindViewById<Button>(Resource.Id.btn23);
                btn24 = FindViewById<Button>(Resource.Id.btn24);
                btn25 = FindViewById<Button>(Resource.Id.btn25);
                btn26 = FindViewById<Button>(Resource.Id.btn26);

                btn1.Click += new EventHandler(Btn1_Clicked);
                btn2.Click += new EventHandler(Btn2_Clicked);
                btn3.Click += new EventHandler(Btn3_Clicked);
                btn4.Click += new EventHandler(Btn4_Clicked);
                btn5.Click += new EventHandler(Btn5_Clicked);
                btn6.Click += new EventHandler(Btn6_Clicked);
                btn7.Click += new EventHandler(Btn7_Clicked);
                btn8.Click += new EventHandler(Btn8_Clicked);
                btn9.Click += new EventHandler(Btn9_Clicked);
                btn10.Click += new EventHandler(Btn10_Clicked);
                btn11.Click += new EventHandler(Btn11_Clicked);
                btn12.Click += new EventHandler(Btn12_Clicked);
                btn13.Click += new EventHandler(Btn13_Clicked);
                btn14.Click += new EventHandler(Btn14_Clicked);
                btn15.Click += new EventHandler(Btn15_Clicked);
                btn16.Click += new EventHandler(Btn16_Clicked);
                btn17.Click += new EventHandler(Btn17_Clicked);
                btn18.Click += new EventHandler(Btn18_Clicked);
                btn19.Click += new EventHandler(Btn19_Clicked);
                btn20.Click += new EventHandler(Btn20_Clicked);
                btn21.Click += new EventHandler(Btn21_Clicked);
                btn22.Click += new EventHandler(Btn22_Clicked);
                btn23.Click += new EventHandler(Btn23_Clicked);
                btn24.Click += new EventHandler(Btn24_Clicked);
                btn25.Click += new EventHandler(Btn25_Clicked);
                btn26.Click += new EventHandler(Btn26_Clicked);
            }
        }
        [Obsolete]

        // check bro 
        private void chk(Char x) {
            String t = txt.Text.ToString();
            wrd = wrd.ToUpper();            
            int ct = 0;
            int id = -1;
            for (int y=0;y<wrd.Length;y++) {
                if (x == wrd[y])
                { 
                    ct++;
                    id = y;
                    String k = "";
                    for (int z = 0; z < j.Length; z++)
                    {
                        if (z == id)
                        {
                            k = k + x;
                        }
                        else
                        {
                            k = k + j[z];
                        }
                    }
                    j = k;
                    txt.Text = j;
                }
            }

            // images changing according to the letters being entered
            if (ct==0) {
                chnce++;
                if (wrd.Length==4) {
                    switch (chnce) {
                        case 1:
                            img.SetImageResource(Resource.Drawable.hangman2);
                            break;
                        case 2:
                            img.SetImageResource(Resource.Drawable.hangman4);
                            break;
                        case 3:
                            img.SetImageResource(Resource.Drawable.hangman6);
                            break;
                        case 4:
                            fail();
                            break;
                    }
                }
                if (wrd.Length == 5)
                {
                    switch (chnce)
                    {
                        case 1:
                            img.SetImageResource(Resource.Drawable.hangman1);
                            break;
                        case 2:
                            img.SetImageResource(Resource.Drawable.hangman2);
                            break;
                        case 3:
                            img.SetImageResource(Resource.Drawable.hangman4);
                            break;
                        case 4:
                            img.SetImageResource(Resource.Drawable.hangman6);
                            break;
                        case 5:
                            fail();
                            break;
                    }
                }
                if (wrd.Length == 6)
                {
                    switch (chnce)
                    {
                        case 1:
                            img.SetImageResource(Resource.Drawable.hangman1);
                            break;
                        case 2:
                            img.SetImageResource(Resource.Drawable.hangman2);
                            break;
                        case 3:
                            img.SetImageResource(Resource.Drawable.hangman4);
                            break;
                        case 4:
                            img.SetImageResource(Resource.Drawable.hangman5);
                            break;
                        case 5:
                            img.SetImageResource(Resource.Drawable.hangman6);
                            break;
                        case 6:
                            fail();
                            break;
                    }
                }
                if (wrd.Length == 7)
                {
                    switch (chnce)
                    {
                        case 1:
                            img.SetImageResource(Resource.Drawable.hangman1);
                            break;
                        case 2:
                            img.SetImageResource(Resource.Drawable.hangman2);
                            break;
                        case 3:
                            img.SetImageResource(Resource.Drawable.hangman3);
                            break;
                        case 4:
                            img.SetImageResource(Resource.Drawable.hangman4);
                            break;
                        case 5:
                            img.SetImageResource(Resource.Drawable.hangman5);
                            break;
                        case 6:
                            img.SetImageResource(Resource.Drawable.hangman6);
                            break;
                        case 7:
                            fail();
                            break;
                    }
                }
            }
            else {
                String k = "";
                for (int z = 0; z < j.Length; z++)
                {
                    if (z == id)
                    {
                        k = k + x;
                    }
                    else
                    {
                        k = k + j[z];
                    }
                }
                j = k;
                txt.Text = j;
            }
            if (txt.Text.Equals(wrd))
            {
                win();
            }
        }
        private void win()
        {
                var dialogview = LayoutInflater.Inflate(Resource.Layout.win, null);
                Android.App.AlertDialog.Builder dialo = new AlertDialog.Builder(this);

                AlertDialog alert = dialo.Create();
                alert.SetView(dialogview);
            string s="";
            if (player == "Two")
            {
                if (m == 2)
                {
                    s = "Next Round";
                }
                else if (m == 1)
                {
                    s = "Play";
                }
            }
            else
            {
                s = "Next Round";
            }
      
            alert.SetButton(s, (c, ev) =>
                {
                    if(player == "Two")
                    {
                        if(m==2)
                        {
                            p2 += 10;
                            m = 1;
                            round++;
                        }
                        else if(m==1)
                        {
                            p1 += 10; 
                            m = 2;
                        }
                        score1.Text = p1. ToString();
                        score2.Text = p2.ToString();
                    }
                    else
                    {
                        round++;
                        score2.Text =( (round-1)*10).ToString();
                    }
                    level.Text =round.ToString();
                    btn1.Alpha = 1.0F;
                    btn2.Alpha = 1.0F;
                    btn3.Alpha = 1.0F;
                    btn4.Alpha = 1.0F;
                    btn5.Alpha = 1.0F;
                    btn6.Alpha = 1.0F;
                    btn7.Alpha = 1.0F;
                    btn8.Alpha = 1.0F;
                    btn9.Alpha = 1.0F;
                    btn10.Alpha = 1.0F;
                    btn11.Alpha = 1.0F;
                    btn12.Alpha = 1.0F;
                    btn13.Alpha = 1.0F;
                    btn14.Alpha = 1.0F;
                    btn15.Alpha = 1.0F;
                    btn16.Alpha = 1.0F;
                    btn17.Alpha = 1.0F;
                    btn18.Alpha = 1.0F;
                    btn19.Alpha = 1.0F;
                    btn20.Alpha = 1.0F;
                    btn21.Alpha = 1.0F;
                    btn22.Alpha = 1.0F;
                    btn23.Alpha = 1.0F;
                    btn24.Alpha = 1.0F;
                    btn25.Alpha = 1.0F;
                    btn26.Alpha = 1.0F;
                    btn1.Enabled = true;
                    btn2.Enabled = true;
                    btn3.Enabled = true;
                    btn4.Enabled = true;
                    btn5.Enabled = true;
                    btn6.Enabled = true;
                    btn7.Enabled = true;
                    btn8.Enabled = true;
                    btn9.Enabled = true;
                    btn10.Enabled = true;
                    btn11.Enabled = true;
                    btn12.Enabled = true;
                    btn13.Enabled = true;
                    btn14.Enabled = true;
                    btn15.Enabled = true;
                    btn16.Enabled = true;
                    btn17.Enabled = true;
                    btn18.Enabled = true;
                    btn19.Enabled = true;
                    btn20.Enabled = true;
                    btn21.Enabled = true;
                    btn22.Enabled = true;
                    btn23.Enabled = true;
                    btn24.Enabled = true;
                    btn25.Enabled = true;
                    btn26.Enabled = true;
                    txt = FindViewById<TextView>(Resource.Id.txtWord);
                    img = FindViewById<ImageView>(Resource.Id.img);
                    img.SetImageResource(Resource.Drawable.hanger);

                    if (player == "Single")
                    {
                        i = rd.Next(0, listSource.Count);
                        wrd = listSource[i].text.ToUpper();
                        hnt = "  " + listSource[i].hint.ToUpper() + "  ";
                        hint.Text = hnt;
                        if (listSource[i].img != null)
                        {
                            byte[] imageArray = listSource[i].img;
                            Android.Graphics.Bitmap bitmap = BitmapFactory.DecodeByteArray(imageArray, 0, imageArray.Length);
                            hIMG.SetImageBitmap(bitmap);
                        }
                        else
                        {
                            hIMG.SetImageResource(Resource.Drawable.hint);
                        }
                    }
                    else
                    {
                        var dialogview = LayoutInflater.Inflate(Resource.Layout.hintAlert, null);
                        Android.App.AlertDialog.Builder dialo = new AlertDialog.Builder(this);
                       
                        AlertDialog alert = dialo.Create();
                        
                        alert.SetTitle("Enter word for Player-"+m);
                        alert.SetView(dialogview);
                        alert.SetButton("Save", (c, ev) =>
                        {
                            if (dialogview.FindViewById<EditText>(Resource.Id.wordAlt).Text != "")
                            {
                                wrd = dialogview.FindViewById<EditText>(Resource.Id.wordAlt).Text;
                                hnt = "  " + dialogview.FindViewById<EditText>(Resource.Id.hintAlt).Text + "  ";
                                hint.Text = hnt;
                            }
                            else
                            {
                                wrd = listSource[i].text.ToUpper();
                                hnt = "  " + listSource[i].hint.ToUpper() + "  ";
                                hint.Text = hnt;

                            }
                        });
                        alert.Show();
                    }
      
                    String h = "";
                    for (int y = 0; y < wrd.Length; y++)
                    {
                        h = h + "-";
                    }
                    txt.Text = h;
                    j = h;
                    chnce = 0;
                    //Toast.MakeText(Application.Context, wrd, ToastLength.Short).Show();
                });
                alert.SetButton2("Exit", (c, ev) =>
                {
                    base.OnBackPressed();
                });
                alert.Show();
        }

        private void fail()
        {
            img.SetImageResource(Resource.Drawable.hangman7);
            btn1.Enabled = false;
            btn2.Enabled = false;
            btn3.Enabled = false;
            btn4.Enabled = false;
            btn5.Enabled = false;
            btn6.Enabled = false;
            btn7.Enabled = false;
            btn8.Enabled = false;
            btn9.Enabled = false;
            btn10.Enabled = false;
            btn11.Enabled = false;
            btn12.Enabled = false;
            btn13.Enabled = false;
            btn14.Enabled = false;
            btn15.Enabled = false;
            btn16.Enabled = false;
            btn17.Enabled = false;
            btn18.Enabled = false;
            btn19.Enabled = false;
            btn20.Enabled = false;
            btn21.Enabled = false;
            btn22.Enabled = false;
            btn23.Enabled = false;
            btn24.Enabled = false;
            btn25.Enabled = false;
            btn26.Enabled = false;

            btn1.Alpha = 0.5F;
            btn2.Alpha = 0.5F;
            btn3.Alpha = 0.5F;
            btn4.Alpha = 0.5F;
            btn5.Alpha = 0.5F;
            btn6.Alpha = 0.5F;
            btn7.Alpha = 0.5F;
            btn8.Alpha = 0.5F;
            btn9.Alpha = 0.5F;
            btn10.Alpha = 0.5F;
            btn11.Alpha = 0.5F;
            btn12.Alpha = 0.5F;
            btn13.Alpha = 0.5F;
            btn14.Alpha = 0.5F;
            btn15.Alpha = 0.5F;
            btn16.Alpha = 0.5F;
            btn17.Alpha = 0.5F;
            btn18.Alpha = 0.5F;
            btn19.Alpha = 0.5F;
            btn20.Alpha = 0.5F;
            btn21.Alpha = 0.5F;
            btn22.Alpha = 0.5F;
            btn23.Alpha = 0.5F;
            btn24.Alpha = 0.5F;
            btn25.Alpha = 0.5F;
            btn26.Alpha = 0.5F;

            var dialogview = LayoutInflater.Inflate(Resource.Layout.fail, null);
            Android.App.AlertDialog.Builder dialo = new AlertDialog.Builder(this);
            AlertDialog alert = dialo.Create();
            alert.SetView(dialogview);
            string s = "";
            if (player == "Two")
            {
                if (m == 2)
                {
                    s = "Next Round";
                }
                else if (m == 1)
                {
                    s = "Play";
                }
            }
            else
            {
                s = "Play Again";
            }
                alert.SetButton(s, (c, ev) => {
                if (player == "Two")
                {
                    if (m == 2)
                    {
                        m = 1;
                        round++;
                    }
                    else
                    {
                        m = 2;
                    }
                }
                else
                {
                    round = 1;
                        score1.Text = "0";
                }
                level.Text = round.ToString();
                btn1.Alpha = 1.0F;
                btn2.Alpha = 1.0F;
                btn3.Alpha = 1.0F;
                btn4.Alpha = 1.0F;
                btn5.Alpha = 1.0F;
                btn6.Alpha = 1.0F;
                btn7.Alpha = 1.0F;
                btn8.Alpha = 1.0F;
                btn9.Alpha = 1.0F;
                btn10.Alpha = 1.0F;
                btn11.Alpha = 1.0F;
                btn12.Alpha = 1.0F;
                btn13.Alpha = 1.0F;
                btn14.Alpha = 1.0F;
                btn15.Alpha = 1.0F;
                btn16.Alpha = 1.0F;
                btn17.Alpha = 1.0F;
                btn18.Alpha = 1.0F;
                btn19.Alpha = 1.0F;
                btn20.Alpha = 1.0F;
                btn21.Alpha = 1.0F;
                btn22.Alpha = 1.0F;
                btn23.Alpha = 1.0F;
                btn24.Alpha = 1.0F;
                btn25.Alpha = 1.0F;
                btn26.Alpha = 1.0F;
                btn1.Enabled = true;
                btn2.Enabled = true;
                btn3.Enabled = true;
                btn4.Enabled = true;
                btn5.Enabled = true;
                btn6.Enabled = true;
                btn7.Enabled = true;
                btn8.Enabled = true;
                btn9.Enabled = true;
                btn10.Enabled = true;
                btn11.Enabled = true;
                btn12.Enabled = true;
                btn13.Enabled = true;
                btn14.Enabled = true;
                btn15.Enabled = true;
                btn16.Enabled = true;
                btn17.Enabled = true;
                btn18.Enabled = true;
                btn19.Enabled = true;
                btn20.Enabled = true;
                btn21.Enabled = true;
                btn22.Enabled = true;
                btn23.Enabled = true;
                btn24.Enabled = true;
                btn25.Enabled = true;
                btn26.Enabled = true;

                txt = FindViewById<TextView>(Resource.Id.txtWord);
                    img = FindViewById<ImageView>(Resource.Id.img);
                    ////Button hntBtn = FindViewById<Button>(Resource.Id.btnAgain);
                    img.SetImageResource(Resource.Drawable.hanger);
                if (player == "Single")
                {
                    i = rd.Next(0, listSource.Count);
                    wrd = listSource[i].text.ToUpper();
                    hnt = "  " + listSource[i].hint.ToUpper() + "  ";
                        if (listSource[i].img != null)
                        {
                            byte[] imageArray = listSource[i].img;
                            Android.Graphics.Bitmap bitmap = BitmapFactory.DecodeByteArray(imageArray, 0, imageArray.Length);
                            hIMG.SetImageBitmap(bitmap);
                        }
                        else
                        {
                            hIMG.SetImageResource(Resource.Drawable.hint);
                        }
                    }
                    else
                {
                    var dialogview = LayoutInflater.Inflate(Resource.Layout.hintAlert, null);
                    //Button playBtn =FindViewById<Button>(Resource.Id.btnAgain);
                    Android.App.AlertDialog.Builder dialo = new AlertDialog.Builder(this);
                    AlertDialog alert = dialo.Create();
                    alert.SetTitle("Enter word for Player-"+m);
                    alert.SetView(dialogview);
                    alert.SetButton("Save", (c, ev) =>
                    {
                        if (dialogview.FindViewById<EditText>(Resource.Id.wordAlt).Text != "")
                        {
                            wrd = dialogview.FindViewById<EditText>(Resource.Id.wordAlt).Text;
                            hnt = "  " + dialogview.FindViewById<EditText>(Resource.Id.wordAlt).Text + "  ";
                        }
                        else
                        {
                            wrd = listSource[i].text.ToUpper();
                            hnt = "  " + listSource[i].hint.ToUpper() + "  ";
                        }
                    });
                    alert.Show();
                }

                String h = "";
                hint.Text = hnt;
                for (int y = 0; y < wrd.Length; y++)
                {
                    h = h + "-";
                }
                txt.Text = h;
                j = h;
                chnce = 0;
            });
            alert.SetButton2("Exit", (c, ev) => {
                base.OnBackPressed();
            });
            alert.Show();
        }

        [Obsolete]
        private void Btn1_Clicked(object sender, EventArgs e)
        {
            chk('A');
            btn1.Alpha = 0.5F;
            btn1.Enabled = false;
        }

        [Obsolete]
        private void Btn2_Clicked(object sender, EventArgs e)
        {
            chk('B');
            btn2.Enabled = false;
            btn2.Alpha = 0.5F;
        }

        [Obsolete]
        private void Btn3_Clicked(object sender, EventArgs e)
        {

            chk('C');
            btn3.Alpha = 0.5F;
            btn3.Enabled = false;
            // throw new NotImplementedException();
        }

        [Obsolete]
        private void Btn4_Clicked(object sender, EventArgs e)
        {
            chk('D');
            btn4.Enabled = false;
            btn4.Alpha = 0.5F;
        }

        [Obsolete]
        private void Btn5_Clicked(object sender, EventArgs e)
        {
            chk('E');
            btn5.Enabled = false;
            btn5.Alpha = 0.5F;
        }

        [Obsolete]
        private void Btn6_Clicked(object sender, EventArgs e)
        {
            chk('F');
            btn6.Alpha = 0.5F;
            btn6.Enabled = false;
        }

        [Obsolete]
        private void Btn7_Clicked(object sender, EventArgs e)
        {
            chk('G');
            btn7.Alpha = 0.5F;
            btn7.Enabled = false;
        }

        [Obsolete]
        private void Btn8_Clicked(object sender, EventArgs e)
        {
            chk('H');
            btn8.Alpha = 0.5F;
            btn8.Enabled = false;
        }

        [Obsolete]
        private void Btn9_Clicked(object sender, EventArgs e)
        {
            chk('I');
            btn9.Alpha = 0.5F;
            btn9.Enabled = false;
        }

        [Obsolete]
        private void Btn10_Clicked(object sender, EventArgs e)
        {
            chk('J');
            btn10.Enabled = false;
            btn10.Alpha = 0.5F;
        }

        [Obsolete]
        private void Btn11_Clicked(object sender, EventArgs e)
        {
            chk('K');
            btn11.Alpha = 0.5F;
            btn11.Enabled = false;
        }

        [Obsolete]
        private void Btn12_Clicked(object sender, EventArgs e)
        {
            chk('L');
            btn12.Alpha = 0.5F;
            btn12.Enabled = false;
        }

        [Obsolete]
        private void Btn13_Clicked(object sender, EventArgs e)
        {
            chk('M');
            btn13.Enabled = false;
            btn13.Alpha = 0.5F;
        }

        [Obsolete]
        private void Btn15_Clicked(object sender, EventArgs e)
        {
            chk('O');
            btn15.Alpha = 0.5F;
            btn15.Enabled = false;
        }

        [Obsolete]
        private void Btn14_Clicked(object sender, EventArgs e)
        {
            chk('N');
            btn14.Alpha = 0.5F;
            btn14.Enabled = false;
        }

        [Obsolete]
        private void Btn16_Clicked(object sender, EventArgs e)
        {
            chk('P');
            btn16.Alpha = 0.5F;
            btn16.Enabled = false;
        }

        [Obsolete]
        private void Btn17_Clicked(object sender, EventArgs e)
        {
            chk('Q');
            btn17.Alpha = 0.5F;
            btn17.Enabled = false;
        }

        [Obsolete]
        private void Btn18_Clicked(object sender, EventArgs e)
        {
            chk('R');
            btn18.Alpha = 0.5F;
            btn18.Enabled = false;
        }

        [Obsolete]
        private void Btn19_Clicked(object sender, EventArgs e)
        {
            chk('S');
            btn19.Alpha = 0.5F;
            btn19.Enabled = false;
        }

        [Obsolete]
        private void Btn20_Clicked(object sender, EventArgs e)
        {
            chk('T');
            btn20.Alpha = 0.5F;
            btn20.Enabled = false;
        }

        [Obsolete]
        private void Btn21_Clicked(object sender, EventArgs e)
        {
            chk('U');
            btn21.Alpha = 0.5F;
            btn21.Enabled = false;
        }

        [Obsolete]
        private void Btn23_Clicked(object sender, EventArgs e)
        {
            chk('W');
            btn23.Alpha = 0.5F;
            btn23.Enabled = false;
        }

        [Obsolete]
        private void Btn22_Clicked(object sender, EventArgs e)
        {
            chk('V');
            btn22.Alpha = 0.5F;
            btn22.Enabled = false;
        }

        [Obsolete]
        private void Btn24_Clicked(object sender, EventArgs e)
        {
            chk('X');
            btn24.Alpha = 0.5F;
            btn24.Enabled = false;
        }

        [Obsolete]
        private void Btn25_Clicked(object sender, EventArgs e)
        {
            chk('Y');
            btn25.Alpha = 0.5F;
            btn25.Enabled = false;
        }

        [Obsolete]
        private void Btn26_Clicked(object sender, EventArgs e)
        {
            chk('Z');
            btn26.Alpha = 0.5F;
            btn26.Enabled = false;
        }
    }
}