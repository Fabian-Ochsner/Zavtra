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
    /// Die Stadthalle legt fest wie viele Gebäude in einem Gorf gebaut werden können
    /// </summary>
    public class Townhall : Structure
    {
        public int MaxBuildings { get; private set; }
        public int currentBuildings { get; private set; }
        public Townhall()
        {
            level = 1;
            building = BuildingType.townhall;
            costWood = 15000;
            costStone = 15000;
            ressource = RessourceType.building;
            worker = 1;
            minWorker = 1;
            maxWorker = 1;
            MaxBuildings = 5;
        }

        public override void upgrade()
        {
            costCalculator();
            MaxBuildings += 5;
        }
    }
}