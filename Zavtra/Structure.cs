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
    abstract class Structure
    {
        public int level { get; protected set; }
        public Buildings building { get; protected set; }
        public double costWood { get; protected set; }
        public double costStone { get; protected set; }
        public Ressources ressource { get; protected set; }
        public int worker { get; protected set; }
        public int minWorker { get; protected set; }
        public int maxWorker { get; protected set; }
    }
}