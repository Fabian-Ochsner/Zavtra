using System.Collections.Generic;

using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;


namespace Zavtra
{
    public class DialogBuildingList : DialogFragment
    {
        BuildingType mType;
        private ListView mBuildingList;
        private List<Structure> mBuildings;
        

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            Bundle args = Arguments;
            if(args != null)
            {
                mType = (BuildingType)args.GetInt("Type");
            }
            base.OnCreateView(inflater, container, savedInstanceState);
            mBuildings = new List<Structure>();
            foreach (var building in TownActivity.zavtra.structures)
            {
                if (building.building == mType)
                {
                    mBuildings.Add(building);
                }
            };


            //ArrayAdapter<string> adapter = new ArrayAdapter<Structure>(this, Android.Resource.Layout.SimpleListItem1, mBuildings);

           


            var view = inflater.Inflate(Resource.Layout.DiaBuildingList, container, false);

            mBuildingList = view.FindViewById<ListView>(Resource.Id.myListView);

            BuildingListAdapter adapter = new BuildingListAdapter(this.Activity, mBuildings, TownActivity.zavtra.ressource);

            mBuildingList.Adapter = adapter;




            return view;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);   //Removes title bar
            base.OnActivityCreated(savedInstanceState);
        }
    }
}