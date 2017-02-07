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
    public class BuildingListAdapter : BaseAdapter<Structure>
    {

        public List<Structure> mItems;
        private int _position;
        private Button btnUpgrade;
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

            btnUpgrade.SetOnClickListener(new ButtonClickListener(this.mContext, mItems, position));

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

        private void btnUpgradeClick(int position)
        {
            mItems[position].upgrade();

        }


        private class ButtonClickListener : Java.Lang.Object, View.IOnClickListener
        {
            private List<Structure> mItems;
            private Context context;
            private int mPosition;

            public ButtonClickListener(Context context, List<Structure> Items , int position)
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
    }
}