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
    /// Das Lager enth�lt die Ressourcen die f�r den bau und zum �berleben ben�tigt werden
    /// </summary>
    public class Storehouse : Structure
    {
        public long maxFood { get; private set; }
        public long maxWood { get; private set; } 
        public long maxStone { get; private set; }
        public long food { get; private set; }
        public long wood { get; private set; }
        public long stone { get; private set; }


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