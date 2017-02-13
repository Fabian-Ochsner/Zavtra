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
    /// Die Ressource Stein
    /// </summary>
    public class Stone : Ressource
    {
        public Stone()
        {
            ressourceType = RessourceType.stone;
            maxRessource = 30000;
            currentRessource = 25000;
        }
    }
}
