using System;
using System.Collections;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Zavtra
{
    [Activity(Label = "Zavtra", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Button mBtnNewGame;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            mBtnNewGame = FindViewById<Button>(Resource.Id.btnNewGame);

            mBtnNewGame.Click += (object sender, EventArgs args) =>
            {
                //New Game Activity 

                StartActivity(typeof(TownActivity));

                //TownActivity townActivity = new TownActivity();
            };
        }
    }
}

