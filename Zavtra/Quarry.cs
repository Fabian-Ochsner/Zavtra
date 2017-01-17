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
    class Quarry : Structure
    {
        public Quarry()
        {
            level = 1;
            building = Buildings.quarry;
            costWood = 5000;
            costStone = 2000;
            ressource = Ressources.stone;
            worker = 0;
            minWorker = 0;
            maxWorker = 5;
        }
    }
}