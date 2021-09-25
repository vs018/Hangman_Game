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
using Android.Views;

namespace GuessGame.Resources.Models
{
    public class ViewHolder 
    {
        public TextView txtWords { get; set; }
        public TextView txtHints { get; set; }
        public ImageView img { get; set; }
    }
    public class ListViewAdapter : BaseAdapter
    {
        private Activity activity;
        private List<Word> listword;
        public ListViewAdapter(Activity activity, List<Word> listWord)
        {
            this.activity = activity;
            this.listword = listWord;
        }

        public override int Count
        {
            get { return listword.Count; }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return listword[position].WordID;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.wordList, parent, false);
            var txtText= view.FindViewById<TextView>(Resource.Id.wordView) ?? new TextView(parent.Context);
            var txtHint = view.FindViewById<TextView>(Resource.Id.hintView) ?? new TextView(parent.Context);
            var hintImg = view.FindViewById<ImageView>(Resource.Id.imgView) ?? new ImageView(parent.Context);
            txtText.Text = listword[position].text;
            txtHint.Text = listword[position].hint;
            if (listword[position].img != null)
            {
                Android.Graphics.Bitmap bitmap = BitmapFactory.DecodeByteArray(listword[position].img, 0, listword[position].img.Length);
                hintImg.SetImageBitmap(bitmap);
            }
            return view;
        }
    }
}