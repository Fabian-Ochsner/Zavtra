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
using Newtonsoft.Json;
using System.Timers;

namespace Zavtra
{
    [Activity(Label = "TownActivity")]
    public class TownActivity : Activity
    {
        public static Town zavtra;
        private Button mBtnNewResidence;
        private Button mBtnNewFarm;
        private Button mBtnNewQuarry;
        private Button mBtnNewLumberjack;
        private Button mBtnNewStorehouse;
        private Button mBtnTownhall;
        private Button mBtnResidence;
        private Button mBtnFarm;
        private Button mBtnQuarry;
        private Button mBtnLumberjack;
        private Button mBtnStorehouse;
        private TextView mTxtFood;
        private TextView mTxtWood;
        private TextView mTxtStone;
        private TextView mTxtWorkforce;
        private TextView mTxtBuilding;
        //private Timer mTimer;
        //int test = 300;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            bool _load = Intent.GetBooleanExtra("Load", false);


            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Town);
            // Create your application here

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
            mBtnTownhall = FindViewById<Button>(Resource.Id.btnTownhall);
            mBtnResidence = FindViewById<Button>(Resource.Id.btnResidence);
            mBtnFarm = FindViewById<Button>(Resource.Id.btnFarm);
            mBtnQuarry = FindViewById<Button>(Resource.Id.btnQuarry);
            mBtnLumberjack = FindViewById<Button>(Resource.Id.btnLumberjackHut);
            mBtnStorehouse = FindViewById<Button>(Resource.Id.btnStorehouse);
            mTxtFood = FindViewById<TextView>(Resource.Id.txtFood);
            mTxtWood = FindViewById<TextView>(Resource.Id.txtWood);
            mTxtStone = FindViewById<TextView>(Resource.Id.txtStone);
            mTxtWorkforce = FindViewById<TextView>(Resource.Id.txtWorkforce);
            mTxtBuilding = FindViewById<TextView>(Resource.Id.txtBuilding);


            initRessource();


            //mTimer = new Timer();
            //mTimer.Interval = 1000;
            //mTimer.Elapsed += OnTimedEvent;

            //mTimer.Enabled = true;





            mBtnNewResidence.Click += (object sender, EventArgs args) =>
            {
                checkMax(BuildingType.residence);
            };
            mBtnNewFarm.Click += (object sender, EventArgs args) =>
            {
                checkMax(BuildingType.farm);
            };
            mBtnNewQuarry.Click += (object sender, EventArgs args) =>
            {
                checkMax(BuildingType.quarry);
            };
            mBtnNewLumberjack.Click += (object sender, EventArgs args) =>
            {
                checkMax(BuildingType.lumberjackHut);
            };
            mBtnNewStorehouse.Click += (object sender, EventArgs args) =>
            {
                checkMax(BuildingType.storehouse);
            };



            mBtnTownhall.Click += (object sender, EventArgs e) =>
            {
                newBuildingList(BuildingType.townhall);
            };

            mBtnResidence.Click += (object sender, EventArgs e) =>
            {
                newBuildingList(BuildingType.residence);
            };

            mBtnFarm.Click += (object sender, EventArgs e) =>
            {
                newBuildingList(BuildingType.farm);
            };

            mBtnLumberjack.Click += (object sender, EventArgs e) =>
            {
                newBuildingList(BuildingType.lumberjackHut);
            };

            mBtnQuarry.Click += (object sender, EventArgs e) =>
            {
                newBuildingList(BuildingType.quarry);
            };

            mBtnStorehouse.Click += (object sender, EventArgs e) =>
            {
                newBuildingList(BuildingType.storehouse);
            };
        }


            private void newBuildingList(BuildingType type)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            DialogBuildingList buildingListDialog = new DialogBuildingList();
            Bundle args = new Bundle();
            args.PutInt("Type", (int)type);
            //args.PutString("Town", JsonConvert.SerializeObject(zavtra));
            buildingListDialog.Arguments = args;
            buildingListDialog.Show(transaction, "dialog fragment");
            initRessource();
        }


        private void initRessource()
        {
            foreach (var ress in zavtra.ressource)
            {
                switch (ress.ressourceType)
                {
                    case RessourceType.food:
                        mTxtFood.Text = "Food:" + ress.currentRessource.ToString();
                        break;
                    case RessourceType.stone:
                        mTxtStone.Text = "Stone:" + ress.currentRessource.ToString();
                        break;
                    case RessourceType.wood:
                        mTxtWood.Text = "Wood:" + ress.currentRessource.ToString();
                        break;
                    case RessourceType.worker:
                        mTxtWorkforce.Text = "Worker:" + ress.currentRessource.ToString() + "/" + ress.maxRessource.ToString();
                        break;
                    case RessourceType.building:
                        mTxtBuilding.Text = "Building:" + ress.currentRessource.ToString() + "/" + ress.maxRessource.ToString();
                        break;
                    default:
                        Console.WriteLine(ress.ressourceType + " is not a switch ressource!");
                        break;
                }
            }
        }


        private void checkMax(BuildingType type)
        {
            zavtra.UpdateRessourceData();
            bool max = false;
            foreach (var ress in zavtra.ressource)
            {
                if (ress.ressourceType == RessourceType.building && ress.currentRessource < ress.maxRessource)
                {
                    max = true;
                }
            }

            if (max)
            {
                zavtra.BuildStructure(type);
                initRessource();
            }
            else
            {
                string text = string.Format("Max Building reached");
                Toast.MakeText(this, text, ToastLength.Long).Show();
            }

        }

        //public void OnTimedEvent(object sender, ElapsedEventArgs e)
        //{
        //    mTxtFood.Text = "Food:" + test;
        //    test += test;
        //    this.Recreate();
        //}



   
    }
}