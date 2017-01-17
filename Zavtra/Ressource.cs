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
        public Ressources ressource { get; protected set; }
        public double maxRessource { get; protected set; }
        public double currentRessource { get; protected set; }
    }
}