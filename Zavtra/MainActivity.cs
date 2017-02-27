using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace Zavtra
{
    [Activity(Label = "Zavtra", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Button mBtnNewGame;
        private Button mBtnContinue;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            mBtnNewGame = FindViewById<Button>(Resource.Id.btnNewGame);
            mBtnContinue = FindViewById<Button>(Resource.Id.btnContinue);

            mBtnNewGame.Click += (object sender, EventArgs args) =>
            {
                //New Game Activity 

                StartActivity(typeof(TownActivity));
                
            };


            mBtnContinue.Click += delegate {
                var townActivity = new Intent(this, typeof(TownActivity));
                townActivity.PutExtra("Load", true);
                StartActivity(townActivity);
            };

        }
    }
}

