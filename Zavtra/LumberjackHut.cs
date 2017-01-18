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
    public class LumberjackHut : Structure
    {
        public LumberjackHut()
        {
            level = 1;
            building = Buildings.lumberjackHut;
            costWood = 2000;
            costStone = 5000;
            ressource = Ressources.wood;
            worker = 0;
            minWorker = 0;
            maxWorker = 5;
        }
    }
}