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
    class BuildingListAdapter : BaseAdapter<Structure>
    {
        public List<Structure> mItems;
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

            if(row == null)
            {
                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.DialogBuildingList, null, false);
            }

            TextView txtLevel = row.FindViewById<TextView>(Resource.Id.txtLevel);
            txtLevel.Text = mItems[position].level.ToString();

            TextView txtStone = row.FindViewById<TextView>(Resource.Id.txtStone);
            txtLevel.Text = mItems[position].costStone.ToString();

            TextView txtWood = row.FindViewById<TextView>(Resource.Id.txtWood);
            txtLevel.Text = mItems[position].costWood.ToString();

            return row;
        }
    }
}