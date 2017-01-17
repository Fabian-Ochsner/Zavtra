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
        private int level { get; set; }
        private Building building { get; set; } 
        private double costWood { get; set; }
        private double costStone { get; set; }
        private Ressources ressource { get; set; }
        private int worker { get; set; }
        private int minWorker { get; set; }
        private int maxWorker { get; set; }
    }
}