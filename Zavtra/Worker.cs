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
    /// Die Ressource Arbeiter
    /// </summary>
    public class Worker : Ressource
    {
        public long ressource { get; set; }
        public Worker()
        {
            ressourceType = RessourceType.worker;
            maxRessource = 5;
            currentRessource = 3;
            ressource = 5;
        }
    }
}