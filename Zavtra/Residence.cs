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
        public Residence()
        {
            level = 1;
            building = Buildings.residence;
            costWood = 5000;
            costStone = 5000;
            ressource = Ressources.worker;
            worker = 0;
            minWorker = 0;
            maxWorker = 2;
        }
    }
}