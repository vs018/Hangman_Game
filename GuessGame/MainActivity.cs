using SQLite;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.IO;
using System.Threading;
using Felipecsl.GifImageViewLib;
using Android;
using System.Threading.Tasks;

namespace GuessGame
{
    [Activity( Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        GifImageView gifImageView;
        readonly string[] permissionGroup =
        {
            Manifest.Permission.ReadExternalStorage,
            Manifest.Permission.WriteExternalStorage,
            Manifest.Permission.Camera
        };
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.splash);

            gifImageView = FindViewById<GifImageView>(Resource.Id.gifImageView1);
            Stream input = Assets.Open("bulbAnimation.gif");
            byte[] bytes = ConvertByteArray(input);
            gifImageView.SetBytes(bytes);
            RequestPermissions(permissionGroup, 0);
            gifImageView.StartAnimation();
        }

        protected override void OnStop()
        {
            base.OnStop();
            gifImageView.StopAnimation();
        }
        protected override void OnResume()
        {
            base.OnResume();
           Task startupWork = new Task(()=>{ SimulateStartup(); });
           startupWork.Start();
        }
        async void SimulateStartup()
        {
            await Task.Delay(1500);
            StartActivity(new Intent(Application.Context, typeof(login)));
        }
        protected override void OnStart()
        {
            base.OnStart();
            gifImageView.StartAnimation();
        }
        private byte[] ConvertByteArray(Stream input)
        {
            byte[] buffer = new byte[16*1024];
            using (MemoryStream ms=new MemoryStream())
                {
                int read;
                while((read=input.Read(buffer,0,buffer.Length))>0)
                    ms.Write(buffer,0,read);
                 return ms.ToArray();
            }
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}