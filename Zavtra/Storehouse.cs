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
    class Storehouse : Structure
    {
        public Storehouse()
        {
            level = 1;
            building = Buildings.storehouse;
            costWood = 10000;
            costStone = 10000;
            ressource = Ressources.storage;
            worker = 1;
            minWorker = 1;
            maxWorker = 1;
        }
    }
}