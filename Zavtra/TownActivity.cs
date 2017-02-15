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
using System.Threading.Tasks;

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
        private bool _Timer;
        //private Timer mTimer;
        //int test = 300;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            bool _load = Intent.GetBooleanExtra("Load", false);


            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Town);
            // Create your application here

            //Neues dorf erstellen oder laden
            if (_load == true)
            {
                zavtra = new Town();
            }
            else
            {
                zavtra = new Town();
            }

            //GUI elemente verbinden
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

            //Ressourcen auf GUI initialisieren
            initRessource();
            AddTimer();

            //mTimer = new Timer();
            //mTimer.Interval = 1000;
            //mTimer.Elapsed += OnTimedEvent;

            //mTimer.Enabled = true;




            //Button click neue gebäude erstellen
            mBtnNewResidence.Click += (object sender, EventArgs args) =>
            {
                createNewBuilding(BuildingType.residence);
            };
            mBtnNewFarm.Click += (object sender, EventArgs args) =>
            {
                createNewBuilding(BuildingType.farm);
            };
            mBtnNewQuarry.Click += (object sender, EventArgs args) =>
            {
                createNewBuilding(BuildingType.quarry);
            };
            mBtnNewLumberjack.Click += (object sender, EventArgs args) =>
            {
                createNewBuilding(BuildingType.lumberjackHut);
            };
            mBtnNewStorehouse.Click += (object sender, EventArgs args) =>
            {
                createNewBuilding(BuildingType.storehouse);
            };


            //Button click Gebäudeliste
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


        /// <summary>
        /// Erstellt ein neue Gebäudeliste mit den Gebäuden vom Typ der übergeben wurde
        /// </summary>
        /// <param name="type"></param>
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









        /// <summary>
        /// Initialisiert die Ressourcen auf dem GUI
        /// </summary>
        private void initRessource()
        {
            bool stoneFarm = true;
            bool stoneQuarry = true;
            bool stoneLumberjack = true;
            bool stonResidence = true;
            bool stoneStorehouse = true;
            bool woodFarm = true;
            bool woodQuarry = true;
            bool woodLumberjack = true;
            bool woodResidence = true;
            bool woodStorehouse = true;
            foreach (var ress in zavtra.ressource)
            {
                switch (ress.ressourceType)
                {
                    case RessourceType.food:
                        mTxtFood.Text = "Food:" + ress.currentRessource.ToString() + " ";
                        break;
                    case RessourceType.stone:
                        if (ress.currentRessource > 2500)
                        {
                            stoneFarm= true;
                            stoneQuarry = true;
                            stoneLumberjack = true;
                            stonResidence = true;
                            stoneStorehouse = true;
                        }
                        else if (ress.currentRessource > 1000)
                        {
                            stoneFarm = false;
                            stoneQuarry = true;
                            stoneLumberjack = false;
                            stonResidence = false;
                            stoneStorehouse = false;
                        }
                        else
                        {
                            stoneFarm = false;
                            stoneQuarry = false;
                            stoneLumberjack = false;
                            stonResidence = false;
                            stoneStorehouse = false;
                        }
                        mTxtStone.Text = "Stone:" + ress.currentRessource.ToString() + " ";
                        break;
                    case RessourceType.wood:
                        if (ress.currentRessource > 2500)
                        {
                            woodFarm = true;
                            woodQuarry = true;
                            woodLumberjack = true;
                            woodResidence  = true;
                            woodStorehouse = true;
                        }
                        else if (ress.currentRessource > 1000)
                        {
                            woodFarm = false;
                            woodQuarry = false;
                            woodLumberjack = true;
                            woodResidence = false;
                            woodStorehouse = false;
                        }
                        else
                        {
                            woodFarm = false;
                            woodQuarry = false;
                            woodLumberjack = false;
                            woodResidence = false;
                            woodStorehouse = false;
                        }
                        mTxtWood.Text = "Wood:" + ress.currentRessource.ToString() + " ";
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
                if(woodFarm == false || stoneFarm == false)
                {
                    mBtnNewFarm.Enabled = false;
                }
                else
                {
                    mBtnNewFarm.Enabled = true;
                }
                if (woodLumberjack == false || stoneLumberjack == false)
                {
                    mBtnNewLumberjack.Enabled = false;
                }
                else
                {
                    mBtnNewLumberjack.Enabled = true;
                }
                if (woodQuarry == false || stoneQuarry == false)
                {
                    mBtnNewQuarry.Enabled = false;
                }
                else
                {
                    mBtnNewQuarry.Enabled = true;
                }
                if (woodResidence == false || stonResidence == false)
                {
                    mBtnNewResidence.Enabled = false;
                }
                else
                {
                    mBtnNewResidence.Enabled = true;
                }
                if (woodStorehouse == false || stoneStorehouse == false)
                {
                    mBtnNewStorehouse.Enabled = false;
                }
                else
                {
                    mBtnNewStorehouse.Enabled = true;
                }

            }
        }

        /// <summary>
        /// Erstellt ein neues Gebäude vom Typ der übergeben wurde
        /// Gibt dem User einen Toast aus falls das Maximum erreicht wurde
        /// </summary>
        /// <param name="type"></param>
        private void createNewBuilding(BuildingType type)
        {
            zavtra.UpdateRessourceData(BuildingType.townhall);
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

        private async void AddTimer()
        {
            _Timer = true;

            while (_Timer)
            {
                RessourceUpdate();

                if (_Timer)
                {
                    await Task.Delay(TimeSpan.FromSeconds(1));
                }

            }

        }

        private void RessourceUpdate()
        {
            zavtra.AddResource();
            initRessource();
        }


        //public void OnTimedEvent(object sender, ElapsedEventArgs e)
        //{
        //    mTxtFood.Text = "Food:" + test;
        //    test += test;
        //    this.Recreate();
        //}




    }
}