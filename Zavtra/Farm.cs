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
    public class Farm : Structure
    {
        public int output { get; private set; }
        public Farm()
        {
            level = 1;
            building = Buildings.quarry;
            costWood = 5000;
            costStone = 5000;
            ressource = Ressources.food;
            worker = 0;
            minWorker = 0;
            maxWorker = 5;
            output = 50;
        }

        public override void upgrade()
        {
            maxWorker *= ((level + 10) / 10);
            output += 5;
            costCalvulater();
        }
    }
}