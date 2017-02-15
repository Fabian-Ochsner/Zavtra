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
        private Button btnDetail;
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

            TextView txtLevel = row.FindViewById<TextView>(Resource.Id.txtLevel);
            txtLevel.Text = BuildingTypeConverter(mItems[position].building) + " Level " + mItems[position].level.ToString();

            TextView txtStone = row.FindViewById<TextView>(Resource.Id.txtStone);
            txtStone.Text = "Stone: " + mItems[position].costStone.ToString();

            TextView txtWood = row.FindViewById<TextView>(Resource.Id.txtWood);
            txtWood.Text = "Wood: " + mItems[position].costWood.ToString();

            btnUpgrade = row.FindViewById<Button>(Resource.Id.btnUpgrade);

            btnUpgrade.SetOnClickListener(new UpgradeClickListener(this.mContext, mItems, position, mRessource));

            btnDetail = row.FindViewById<Button>(Resource.Id.btnDetail);


            btnDetail.SetOnClickListener(new DetailClickListener(this.mContext, mItems, position));

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

        private class DetailClickListener : Java.Lang.Object, View.IOnClickListener
        {
            private List<Structure> mItems;
            private Context context;
            private int mPosition;

            public DetailClickListener(Context context, List<Structure> Items, int position)
            {
                this.context = context;
                this.mPosition = position;
                this.mItems = Items;
            }
            public void OnClick(View v)
            {
                string name = (string)v.Tag;
                string text = string.Format(name + "Detail Ansicht");
                Toast.MakeText(this.context, text, ToastLength.Long).Show();
                //mItems[mPosition].upgrade();
            }
        }
    }
}