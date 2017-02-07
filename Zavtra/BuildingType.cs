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
    /// Dieser Enum beinhaltet alle Gebäude die im Spiel vorkommen
    /// </summary>
    public enum BuildingType
    {
        townhall,
        residence,
        farm,
        quarry,
        lumberjackHut,
        storehouse
    }
}