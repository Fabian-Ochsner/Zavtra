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
    public class Building : Ressource
    {
        public Building()
        {
            ressourceType = RessourceType.building;
            maxRessource = 5;
            currentRessource = 3;
        }
    }
}