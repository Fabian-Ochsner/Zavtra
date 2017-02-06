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
    public class Storehouse : Structure
    {
        public double maxFood { get; private set; }
        public double maxWood { get; private set; } 
        public double maxStone { get; private set; }
        public double food { get; private set; }
        public double wood { get; private set; }
        public double stone { get; private set; }


        public Storehouse()
        {
            level = 1;
            building = BuildingType.storehouse;
            costWood = 10000;
            costStone = 10000;
            ressource = RessourceType.storage;
            worker = 1;
            minWorker = 1;
            maxWorker = 1;
            maxFood = 20000;
            maxWood = 20000;
            maxStone = 20000;
            food = 0;
            wood = 0;
            stone = 0;
        }

        public override void upgrade()
        {
            maxFood *= ((level + 10) / 10);
            maxWood *= ((level + 10) / 10);
            maxStone *= ((level + 10) / 10);
            costCalculator();
        }
    }
}