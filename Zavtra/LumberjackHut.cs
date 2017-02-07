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
    /// <summary>
    /// Die Holzfällerhütte ist das Gebäude zum sammeln von Holz
    /// </summary>
    public class LumberjackHut : Structure
    {
        public int output { get; private set; }
        public LumberjackHut()
        {
            level = 1;
            building = BuildingType.lumberjackHut;
            costWood = 2000;
            costStone = 5000;
            ressource = RessourceType.wood;
            worker = 0;
            minWorker = 0;
            maxWorker = 5;
            output = 30;
        }

        public override void upgrade()
        {
            maxWorker *= ((level + 10) / 10);
            output += 5;
            costCalculator();
        }
    }
}