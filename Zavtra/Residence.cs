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
    public class Residence : Structure
    {
        public int maxResident { get; private set; }
        public int outputTime { get; private set; }

        public Residence()
        {
            level = 1;
            building = BuildingType.residence;
            costWood = 5000;
            costStone = 5000;
            ressource = RessourceType.worker;
            worker = 0;
            minWorker = 0;
            maxWorker = 2;
            maxResident = 5;
            outputTime = 10;
        }

        public override void upgrade()
        {
            costCalvulater();
        }
    }
}