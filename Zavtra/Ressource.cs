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
    abstract class Ressource
    {
        private Ressources ressource { get; set; }
        private double maxRessource { get; set; }
        private double currentRessource { get; set; }
    }
}