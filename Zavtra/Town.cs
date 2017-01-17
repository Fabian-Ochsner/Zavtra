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
    class Town
    {
        public List<Structure> structures { get; private set; }
        public List<Ressource> ressource { get; private set; }


        public Town()
        {
            structures.Add(new Townhall());
        }
    }
}