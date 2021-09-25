using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Widget;
using GuessGame.Resources.Models;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace GuessGame
{
    [Activity(Label = "wordManage")]
    // this activity managing words
    public class wordManage : Activity
    {
        Button btnBrowse;
        ImageView imageView;
        ImageView hintImg;
        ListView lstViewData;
        List<Resources.Models.Word> listSource = new List<Resources.Models.Word>();
        Database db;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.words);

            db = new Database();
            db.createDatabase();

            lstViewData = FindViewById<ListView>(Resource.Id.listView1);
            var edtWord = FindViewById<EditText>(Resource.Id.wordTxt);
            var edtHint = FindViewById<EditText>(Resource.Id.hintTxt);
            var btnAdd = FindViewById<Button>(Resource.Id.btnAdd);
            var btnEdit = FindViewById<Button>(Resource.Id.btnEdit);
            var btnRemove = FindViewById<Button>(Resource.Id.btnRemove);
            imageView = FindViewById<ImageView>(Resource.Id.imgView);
            hintImg = FindViewById<ImageView>(Resource.Id.hintIMG);
            btnBrowse = FindViewById<Button>(Resource.Id.btnBrowse);
            btnBrowse.Tag = "";
            edtWord.Tag = "";
            LoadData();

            btnBrowse.Click += UploadButton_Click;
            btnAdd.Click += delegate
            {
                byte[] n = null;
                if (edtWord.Text.Length == 4 || edtWord.Text.Length == 5 || edtWord.Text.Length == 6 || edtWord.Text.Length == 7)
                {
             
                    Resources.Models.Word wordsText;
                    if (btnBrowse.Tag.ToString() == "")
                    {
                        wordsText = new Resources.Models.Word()
                        {
                            text = edtWord.Text,
                            hint = edtHint.Text,
                            img = n
                    };
                }
                else
                {
                        byte[] bindata = System.IO.File.ReadAllBytes(btnBrowse.Tag.ToString());
                        wordsText = new Resources.Models.Word()
                            {
                                text = edtWord.Text,
                                hint = edtHint.Text,
                                img = bindata
                            };
                        }
                    db.insertIntoTable(wordsText);
                    LoadData();
                    Toast.MakeText(Application.Context, "Word Added Successfuly", ToastLength.Short).Show();
                    edtWord.Text = "";
                    edtHint.Text = "";
                    btnBrowse.Tag = "";
                    hintImg.SetImageResource(Resource.Drawable.hint);
                }
            };

            // check statements according to word and hints
            btnEdit.Click += delegate
            {

                if (edtWord.Text.Length == 4 || edtWord.Text.Length == 5 || edtWord.Text.Length == 6 || edtWord.Text.Length == 7 || edtWord.Tag.ToString()!="")
                {
                    if (btnBrowse.Tag.ToString() == "")
                    {
                        Resources.Models.Word wordsText = new Resources.Models.Word()
                        {
                            WordID = int.Parse(edtWord.Tag.ToString()),
                            text = edtWord.Text,
                            hint = edtHint.Text,
                            img = null
                        };
                        db.updateTable(wordsText,"text");
                    }
                    else
                    {
                        byte[] bindata = System.IO.File.ReadAllBytes(btnBrowse.Tag.ToString());
                        Resources.Models.Word wordsText = new Resources.Models.Word()
                        {
                            WordID = int.Parse(edtWord.Tag.ToString()),
                            text = edtWord.Text,
                            hint = edtHint.Text,
                            img = bindata
                        };
                        db.updateTable(wordsText,"img");
                    }
                    LoadData();
                    Toast.MakeText(Application.Context, "Word Updated Successfuly", ToastLength.Short).Show();
                    edtWord.Text = "";
                    edtHint.Text = "";
                    btnBrowse.Tag = "";
                    hintImg.SetImageResource(Resource.Drawable.hint);
                }
            };
            btnRemove.Click += delegate
            {
                if (edtWord.Tag.ToString() != "")
                {
                    Resources.Models.Word word = new Resources.Models.Word()
                    {
                        WordID = int.Parse(edtWord.Tag.ToString()),
                        text = edtWord.Text,
                        hint = edtHint.Text,
                    };
                    db.removeTable(word);
                    LoadData();
                    Toast.MakeText(Application.Context, "Word Deleted Successfuly", ToastLength.Short).Show();
                    edtWord.Text = "";
                    edtHint.Text = "";
                    btnBrowse.Tag = "";
                    hintImg.SetImageResource(Resource.Drawable.hint);
                }
            };
            lstViewData.ItemClick += (s, e) =>
            {
                var txtWords = e.View.FindViewById<TextView>(Resource.Id.wordView);
                var txtHints = e.View.FindViewById<TextView>(Resource.Id.hintView);
                var img = e.View.FindViewById<ImageView>(Resource.Id.imgView);
                edtWord.Tag = e.Id;
                edtWord.Text=txtWords.Text;
                edtHint.Text=txtHints.Text.ToString();
                btnBrowse.Tag = "";
                if(listSource[e.Position].img!=null)
                {
                    byte[] imageArray = listSource[e.Position].img;
                    Android.Graphics.Bitmap bitmap = BitmapFactory.DecodeByteArray(imageArray, 0, imageArray.Length);
                    hintImg.SetImageBitmap(bitmap);
                }
                else
                {
                    hintImg.SetImageResource(Resource.Drawable.hint);
                }
            };

           
        }
        private void UploadButton_Click(object sender, EventArgs e)
        {
            UploadPhoto_Click();
        }
        async void UploadPhoto_Click()
        {
            await CrossMedia.Current.Initialize();
            if(!CrossMedia.Current.IsPickPhotoSupported)
            {
                Toast.MakeText(this,"Upload mot supported on this device",ToastLength.Short).Show();
                return;
            }
            var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Full,
                CompressionQuality = 40
            });
            btnBrowse.Tag = file.Path;
            byte[] imageArray = System.IO.File.ReadAllBytes(file.Path);
            Android.Graphics.Bitmap bitmap = BitmapFactory.DecodeByteArray(imageArray, 0, imageArray.Length);
            hintImg.SetImageBitmap(bitmap);
        }

        private void LoadData()
        {
            listSource = db.selectTable();
            var adapter = new ListViewAdapter(this, listSource);
            lstViewData.Adapter = adapter;
        }
    }
}