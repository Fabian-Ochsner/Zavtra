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
    /// Die Abstrakte Klasse aller Gebäude
    /// </summary>
    public abstract class Structure
    {
        public int level { get; protected set; }
        public BuildingType building { get; protected set; }
        public long costWood { get; protected set; }
        public long costStone { get; protected set; }
        public RessourceType ressource { get; protected set; }
        public int worker { get; set; }
        public int minWorker { get; protected set; }
        public int maxWorker { get; protected set; }

        public abstract void upgrade();
        protected void costCalculator()
        {
            costWood *= ((level + 10) / 10);
            costStone *= ((level + 10) / 10);
            level += 1;
        }

    }
}