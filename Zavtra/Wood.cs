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
    public class Wood : Ressource
    {
        public Wood()
        {
            ressource = RessourceType.wood;
            maxRessource = 20000;
            currentRessource = 10000;
        }
    }
}