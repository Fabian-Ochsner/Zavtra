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
    public class Townhall : Structure
    {
        public Townhall()
        {
            level = 1;
            building = Buildings.townhall;
            costWood = 20000;
            costStone = 20000;
            ressource = Ressources.building;
            worker = 1;
            minWorker = 1;
            maxWorker = 1;
        }
    }
}