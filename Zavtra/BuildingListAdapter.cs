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
    /// Diese Klasse ist daf�r zust�ndig die ListView abzuf�llen
    /// </summary>
    public class BuildingListAdapter : BaseAdapter<Structure>
    {

        public List<Structure> mItems;
        private int _position;
        private Button btnUpgrade;
        private Button btnDetail;
        private Context mContext;

        public BuildingListAdapter(Context context, List<Structure> items)
        {
            mItems = items;
            mContext = context;
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
            txtLevel.Text = "Level: " + mItems[position].level.ToString();

            TextView txtStone = row.FindViewById<TextView>(Resource.Id.txtStone);
            txtStone.Text = "Stone: " + mItems[position].costStone.ToString();

            TextView txtWood = row.FindViewById<TextView>(Resource.Id.txtWood);
            txtWood.Text = "Wood: " + mItems[position].costWood.ToString();

            btnUpgrade = row.FindViewById<Button>(Resource.Id.btnUpgrade);

            btnUpgrade.SetOnClickListener(new UpgradeClickListener(this.mContext, mItems, position));

            btnDetail = row.FindViewById<Button>(Resource.Id.btnDetail);


            btnDetail.SetOnClickListener(new DetailClickListener(this.mContext, mItems, position));

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





            //{
            //    btnUpgradeClick();
            //    //Console.WriteLine("clicked item: " + position);
            //    //NotifyDataSetChanged();
            //};


            return row;
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
            private Context context;
            private int mPosition;

            public UpgradeClickListener(Context context, List<Structure> Items , int position)
            {
                this.context = context;
                this.mPosition = position;
                this.mItems = Items;
            }
            public void OnClick(View v)
            {
                string name = (string)v.Tag;
                string text = string.Format(name + "Upgrade started");
                Toast.MakeText(this.context, text, ToastLength.Long).Show();
                mItems[mPosition].upgrade();
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
                string text = string.Format(name + "Detail ansicht");
                Toast.MakeText(this.context, text, ToastLength.Long).Show();
                //mItems[mPosition].upgrade();
            }
        }
    }
}