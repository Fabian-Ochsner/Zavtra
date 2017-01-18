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
    public abstract class Ressource
    {
        public RessourceType ressourceType { get; protected set; }
        public long maxRessource { get; protected set; }
        public long currentRessource { get; protected set; }
    }
}