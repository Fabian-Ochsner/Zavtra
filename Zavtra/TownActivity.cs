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

namespace Zavtra
{
    [Activity(Label = "TownActivity")]
    public class TownActivity : Activity
    {
        private Button mBtnNewResidence;
        private Button mBtnNewFarm;
        private Button mBtnNewQuarry;
        private Button mBtnNewLumberjack;
        private Button mBtnNewStorehouse;
        private Button mBtnResidence;
        private Button mBtnFarm;
        private Button mBtnQuarry;
        private Button mBtnLumberjack;
        private Button mBtnStorehouse;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            bool _load = Intent.GetBooleanExtra("Load", false);


            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Town);
            // Create your application here
            Town zavtra;
            if (_load == true)
            {
                zavtra = new Town();
            }
            else
            {
                zavtra = new Town();
            }




            mBtnNewResidence = FindViewById<Button>(Resource.Id.btnNewResidence);
            mBtnNewFarm = FindViewById<Button>(Resource.Id.btnNewFarm);
            mBtnNewQuarry = FindViewById<Button>(Resource.Id.btnNewQuarry);
            mBtnNewLumberjack = FindViewById<Button>(Resource.Id.btnNewLumberjack);
            mBtnNewStorehouse = FindViewById<Button>(Resource.Id.btnNewStorehouse);
            mBtnResidence = FindViewById<Button>(Resource.Id.btnResidence);
            mBtnFarm = FindViewById<Button>(Resource.Id.btnFarm);
            mBtnQuarry = FindViewById<Button>(Resource.Id.btnQuarry);
            mBtnLumberjack = FindViewById<Button>(Resource.Id.btnLumberjackHut);
            mBtnStorehouse = FindViewById<Button>(Resource.Id.btnStorehouse);

            mBtnNewResidence.Click += (object sender, EventArgs args) =>
            {
                zavtra.BuildStructure(BuildingType.residence);
            };
            mBtnNewFarm.Click += (object sender, EventArgs args) =>
            {
                zavtra.BuildStructure(BuildingType.farm);
            };
            mBtnNewQuarry.Click += (object sender, EventArgs args) =>
            {
                zavtra.BuildStructure(BuildingType.quarry);
            };
            mBtnNewLumberjack.Click += (object sender, EventArgs args) =>
            {
                zavtra.BuildStructure(BuildingType.lumberjackHut);
            };
            mBtnNewStorehouse.Click += (object sender, EventArgs args) =>
            {
                zavtra.BuildStructure(BuildingType.storehouse);
            };

        }
    }
}