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
    /// <summary>
    /// Diese Klasse ist dafür zuständig die ListView abzufüllen
    /// </summary>
    public class BuildingListAdapter : BaseAdapter<Structure>
    {

        public List<Structure> mItems;
        private List<Ressource> mRessource;
        private Button btnUpgrade;
        private Button btnRemove;
        private Button btnAdd;
        private Context mContext;

        public BuildingListAdapter(Context context, List<Structure> items, List<Ressource> ressource)
        {
            mItems = items;
            mContext = context;
            mRessource = ressource;
        }
        public override int Count
        {
            get { return mItems.Count; }
        }


        public override long GetItemId(int position)
        {
            return position;
        }

        public override Structure this[int position]
        {
            get { return mItems[position]; }
        }



        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            View row = convertView;


            if (row == null)
            {
                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.DialogBuildingList_row, null, false);
            }

            TextView txtWorker = row.FindViewById<TextView>(Resource.Id.txtWorker);
            txtWorker.Text = "Arbeiter: " + mItems[position].worker + "/" + mItems[position].maxWorker;

            TextView txtRessource = row.FindViewById<TextView>(Resource.Id.txtRessource);
            txtRessource.Text = "Ressource: " + RessourceTypeConverter(mItems[position].ressource);

            TextView txtMaxOutput = row.FindViewById<TextView>(Resource.Id.txtMaxOutput);
            txtMaxOutput.Text = MaxOutput(mItems[position]);

            TextView txtOutput = row.FindViewById<TextView>(Resource.Id.txtCurrentOutput);
            txtOutput.Text = Output(mItems[position]);

            TextView txtLevel = row.FindViewById<TextView>(Resource.Id.txtLevel);
            txtLevel.Text = BuildingTypeConverter(mItems[position].building) + " Level " + mItems[position].level.ToString();

            TextView txtStone = row.FindViewById<TextView>(Resource.Id.txtStone);
            txtStone.Text = "Stone: " + mItems[position].costStone.ToString();

            TextView txtWood = row.FindViewById<TextView>(Resource.Id.txtWood);
            txtWood.Text = "Wood: " + mItems[position].costWood.ToString();

            btnUpgrade = row.FindViewById<Button>(Resource.Id.btnUpgrade);
            btnUpgrade.SetOnClickListener(new UpgradeClickListener(this.mContext, mItems, position, mRessource));

            btnRemove = row.FindViewById<Button>(Resource.Id.btnRemove);
            btnRemove.SetOnClickListener(new RemoveClickListener(this.mContext, mItems, position, mRessource));

            btnAdd = row.FindViewById<Button>(Resource.Id.btnAdd);
            btnAdd.SetOnClickListener(new AddClickListener(this.mContext, mItems, position, mRessource));

            //NotifyDataSetChanged();

            //btnDetail.Click += delegate
            //    {
            //        //FragmentTransaction transaction = FragmentManager.BeginTransaction();
            //        Console.WriteLine("building detali fragment" + mItems[position].level);
            //    };



            //btnUpgrade.Click -= delegate {};
            //btnUpgrade.Click += delegate
            //{
            //    btnUpgradeClick(position);
            //};


            return row;
        }

        private string MaxOutput(Structure structure)
        {
            string MaxOutput;
            switch (structure.building)
            {
                case BuildingType.farm:
                case BuildingType.lumberjackHut:
                case BuildingType.quarry:
                    MaxOutput = "Max. Produktion: " + Convert.ToString(((StructureRessource)structure).output);
                    break;
                case BuildingType.residence:
                    MaxOutput = "Max. Einwohner: " + Convert.ToString(((Residence)structure).maxResident);
                    break;
                case BuildingType.storehouse:
                    MaxOutput = "Max. Lagermenge: " + Convert.ToString(((Storehouse)structure).maxWood);
                    break;
                case BuildingType.townhall:
                    MaxOutput = "Max. Gebäude: " + Convert.ToString(((Townhall)structure).MaxBuildings);
                    break;
                default:
                    MaxOutput = "";
                    break;
            }
            return MaxOutput;
        }

        private string Output(Structure structure)
        {
            string MaxOutput;
            switch (structure.building)
            {
                case BuildingType.farm:
                case BuildingType.lumberjackHut:
                case BuildingType.quarry:
                    MaxOutput = "Produktion: " + Convert.ToString((((StructureRessource)structure).output/structure.maxWorker)*structure.worker);
                    break;
                case BuildingType.residence:
                    MaxOutput = "Einwohner: " + Convert.ToString(((Residence)structure).maxResident);
                    break;
                case BuildingType.storehouse:
                    MaxOutput = "";
                    break;
                case BuildingType.townhall:
                    MaxOutput = "Gebäude: " + Convert.ToString(((Townhall)structure).currentBuildings);
                    break;
                default:
                    MaxOutput = "";
                    break;
            }
            return MaxOutput;
        }


        private string BuildingTypeConverter(BuildingType _building)
        {
            string name = "";
            switch (_building)
            {
                case BuildingType.farm:
                    name = "Farm";
                    break;
                case BuildingType.lumberjackHut:
                    name = "Holzhällerhütte";
                    break;
                case BuildingType.quarry:
                    name = "Steinbruch";
                    break;
                case BuildingType.residence:
                    name = "Wohnhaus";
                    break;
                case BuildingType.storehouse:
                    name = "Lagerhaus";
                    break;
                case BuildingType.townhall:
                    name = "Stadthalle";
                    break;
            }
            return name;
        }


        private string RessourceTypeConverter(RessourceType _ressource)
        {
            string name = "";
            switch (_ressource)
            {
                case RessourceType.building:
                    name = "Max. Gebäude";
                    break;
                case RessourceType.food:
                    name = "Nahrung";
                    break;
                case RessourceType.stone:
                    name = "Stein";
                    break;
                case RessourceType.storage:
                    name = "Lagermenge";
                    break;
                case RessourceType.wood:
                    name = "Holz";
                    break;
                case RessourceType.worker:
                    name = "Einwohner";
                    break;
            }
            return name;
        }


        //private void HandleClick(object sender, EventArgs e)
        //{
        //    mItems[_position].upgrade();
        //    this.NotifyDataSetChanged();
        //}

        //private void btnUpgradeClick(int position)
        //{
        //    mItems[position].upgrade();

        //}


        private class UpgradeClickListener : Java.Lang.Object, View.IOnClickListener
        {
            private List<Structure> mItems;
            private List<Ressource> mRessource;
            private Context mContext;
            private int mPosition;

            public UpgradeClickListener(Context context, List<Structure> Items , int position, List<Ressource> ressource)
            {
                mContext = context;
                mPosition = position;
                mItems = Items;
                mRessource = ressource;
            }
            public void OnClick(View v)
            {
                bool wood = false;
                bool stone = false;
                string text;
                foreach (var ress in mRessource)
                {
                    switch (ress.ressourceType)
                    {
                        case RessourceType.stone:
                            if(mItems[mPosition].costStone > ress.currentRessource)
                            {
                                stone = false;
                            }
                            else
                            {
                                stone = true;
                            }
                            break;
                        case RessourceType.wood:
                            if (mItems[mPosition].costStone > ress.currentRessource)
                            {
                                wood = false;
                            }
                            else
                            {
                                wood = true;
                            }
                            break;
                    }
                }
                
                if(wood && stone)
                {
                    text = string.Format("Upgrade gestarted");
                    foreach (var ress in mRessource)
                    {
                        switch (ress.ressourceType)
                        {
                            case RessourceType.stone:
                                ress.currentRessource -= mItems[mPosition].costStone;
                                break;
                            case RessourceType.wood:
                                ress.currentRessource -= mItems[mPosition].costWood;
                                break;
                        }
                    }
                    mItems[mPosition].upgrade();
                }
                else
                {
                    text = string.Format("Nicht genug Ressourcen!");
                }
                Toast.MakeText(this.mContext, text, ToastLength.Long).Show();
            }









        }

        private class RemoveClickListener : Java.Lang.Object, View.IOnClickListener
        {
            private List<Structure> mItems;
            private List<Ressource> mRessource;
            private Context context;
            private int mPosition;

            public RemoveClickListener(Context context, List<Structure> Items, int position, List<Ressource> ressource)
            {
                this.context = context;
                this.mPosition = position;
                this.mItems = Items;
                this.mRessource = ressource;
            }
            public void OnClick(View v)
            {
                string name = (string)v.Tag;
                string text = string.Format(name + "Arbeiter entfernt");

                foreach (var ress in mRessource)
                {
                    if (mItems[mPosition].worker > mItems[mPosition].minWorker && ress.ressourceType == RessourceType.worker)
                    {
                        ress.currentRessource += 1;
                        mItems[mPosition].worker -= 1;
                    }
                    else
                    {
                        text = string.Format(name + "Entfernen nicht möglich");
                    }
                }
                Toast.MakeText(this.context, text, ToastLength.Long).Show();
            }
        }


        private class AddClickListener : Java.Lang.Object, View.IOnClickListener
        {
            private List<Structure> mItems;
            private List<Ressource> mRessource;
            private Context context;
            private int mPosition;

            public AddClickListener(Context context, List<Structure> Items, int position, List<Ressource> ressource)
            {
                this.context = context;
                this.mPosition = position;
                this.mItems = Items;
                this.mRessource = ressource;
            }
            public void OnClick(View v)
            {
                string name = (string)v.Tag;
                string text = string.Format(name + "Arbeiter zugewiesen");

                foreach(var ress in mRessource)
                {
                    if (mItems[mPosition].worker < mItems[mPosition].maxWorker && ress.ressourceType == RessourceType.worker && ress.currentRessource != 0)
                    {
                        ress.currentRessource -= 1;
                        mItems[mPosition].worker += 1;
                    }
                    else
                    {
                        text = string.Format(name + "Zuweisen nicht möglich");
                    }
                }
                Toast.MakeText(this.context, text, ToastLength.Long).Show();
            }
        }
    }
}