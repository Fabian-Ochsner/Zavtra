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
    public class Quarry : Structure
    {
        public int output { get; private set; }
        public Quarry()
        {
            level = 1;
            building = BuildingType.quarry;
            costWood = 5000;
            costStone = 2000;
            ressource = RessourceType.stone;
            worker = 0;
            minWorker = 0;
            maxWorker = 5;
            output = 30;
        }

        public override void upgrade()
        {
            maxWorker *= ((level + 10) / 10);
            output += 5;
            costCalvulater();
        }
    }
}