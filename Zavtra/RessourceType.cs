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
    /// Dieser Enum enth�lt alle Ressourcen die im Spiel vorkommen
    /// </summary>
    public enum RessourceType
    {
        building,
        worker,
        storage,
        food,
        wood,
        stone
    }
}