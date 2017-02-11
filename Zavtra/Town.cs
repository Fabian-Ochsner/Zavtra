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
    /// Diese Klasse ist das oberste Objekt. Alle Gebäude und Ressourcen befinden sich im Dorf
    /// </summary>
    public class Town
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

            UpdateRessourceData();

        }


        public Town(List<Structure> _structure, List<Ressource> _ressource)
        {
            structures = new List<Structure>();
            structures = _structure;

            ressource = new List<Ressource>();
            ressource = _ressource;
        }

        public void BuildStructure(BuildingType type)
        {
            foreach(var ress in ressource)
            {
                if (ress.ressourceType == RessourceType.building && ress.currentRessource < ress.maxRessource)
                {
                    switch (type)
                    {
                        case BuildingType.residence:
                            BuildResidence();
                            break;
                        case BuildingType.farm:
                            BuildFarm();
                            break;
                        case BuildingType.quarry:
                            BuildQuarry();
                            break;
                        case BuildingType.lumberjackHut:
                            BuildLumberjack();
                            break;
                        case BuildingType.storehouse:
                            BuildStorehouse();
                            break;
                        default:
                            Console.WriteLine(type + " is not a switch BuildingType!");
                            break;
                    }
                    UpdateRessourceData();
                }


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


        public void UpdateRessourceData()
        {
            foreach (var ressource in ressource)
            {
                if (ressource.ressourceType == RessourceType.worker)
                {
                    ressource.maxRessource = 0;
                }
                else if (ressource.ressourceType == RessourceType.food)
                {
                    ressource.maxRessource = 0;
                }
                else if (ressource.ressourceType == RessourceType.wood)
                {
                    ressource.maxRessource = 0;
                }
                else if (ressource.ressourceType == RessourceType.stone)
                {
                    ressource.maxRessource = 0;
                }
                else if (ressource.ressourceType == RessourceType.building)
                {
                    ressource.currentRessource = structures.Count;
                }
            }



            foreach (var _building in structures)
            {
                switch (_building.building)
                {
                    case BuildingType.townhall:
                        foreach(var ressource in ressource)
                        {
                            if(ressource.ressourceType == RessourceType.building)
                            {
                                ressource.maxRessource = ((Townhall)_building).MaxBuildings;
                            }
                        }
                        break;
                    case BuildingType.residence:
                        foreach (var ressource in ressource)
                        {
                            if (ressource.ressourceType == RessourceType.worker)
                            {
                                ressource.maxRessource += ((Residence)_building).maxResident;
                            }
                        }
                        break;
                    case BuildingType.storehouse:
                        foreach (var ressource in ressource)
                        {
                            if (ressource.ressourceType == RessourceType.food)
                            {
                                ressource.maxRessource += ((Storehouse)_building).maxFood;
                            }
                            else if (ressource.ressourceType == RessourceType.wood)
                            {
                                ressource.maxRessource += ((Storehouse)_building).maxWood;
                            }
                            else if (ressource.ressourceType == RessourceType.stone)
                            {
                                ressource.maxRessource += ((Storehouse)_building).maxStone;
                            }
                        }
                        break;
                }
            }




            foreach(var type in Enum.GetValues(typeof(RessourceType)))
            {

            }
        }

        internal void AddResource()
        {
            foreach (var ressi in ressource)
            {
                if (ressi.ressourceType == RessourceType.worker)
                {
                    foreach (var ressource in ressource)
                    {
                        if (ressource.ressourceType == RessourceType.food || ressource.ressourceType == RessourceType.wood)
                        {
                            ressource.currentRessource -= (ressi.currentRessource * 20);
                        }
                    }
                }
                else if (ressi.ressourceType == RessourceType.food || ressi.ressourceType == RessourceType.stone || ressi.ressourceType == RessourceType.wood)
                {
                    foreach (var building in structures)
                    {
                        if (ressi.ressourceType == building.ressource)
                        {
                            ressi.currentRessource += ((StructureRessource)building).output;
                            if (ressi.currentRessource > ressi.maxRessource)
                            {
                                ressi.currentRessource = ressi.maxRessource;
                            }
                        }
                    }
                }
            }
        }
    }
}