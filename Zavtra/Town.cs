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
            structures = new List<Structure>();
            structures.Add(new Townhall());
            structures.Add(new Residence());
            structures.Add(new Storehouse());

            ressource = new List<Ressource>();
            ressource.Add(new Building());
            ressource.Add(new Worker());
            ressource.Add(new Food());
            ressource.Add(new Wood());
            ressource.Add(new Stone());
        }

        public void BuildStructure(Buildings type)
        {
            switch (type)
            {
                case Buildings.residence:
                    BuildResidence();
                    break;
                case Buildings.farm:
                    BuildFarm();
                    break;
                case Buildings.quarry:
                    BuildQuarry();
                    break;
                case Buildings.lumberjackHut:
                    BuildLumberjack();
                    break;
                case Buildings.storehouse:
                    BuildStorehouse();
                    break;
                default:

                    break;
            }
        }


        private void BuildResidence()
        {
            structures.Add(new Residence());
        }
        private void BuildFarm()
        {
            structures.Add(new Farm());
        }
        private void BuildQuarry()
        {
            structures.Add(new Quarry());
        }
        private void BuildLumberjack()
        {
            structures.Add(new LumberjackHut());
        }
        private void BuildStorehouse()
        {
            structures.Add(new Storehouse());
        }
    }
}