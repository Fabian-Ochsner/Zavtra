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
        private int DethTimer = 0;
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

            UpdateRessourceData(BuildingType.townhall);

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
                            UpdateRessourceData(type);
                            break;
                        case BuildingType.farm:
                            BuildFarm();
                            UpdateRessourceData(type);
                            break;
                        case BuildingType.quarry:
                            BuildQuarry();
                            UpdateRessourceData(type);
                            break;
                        case BuildingType.lumberjackHut:
                            BuildLumberjack();
                            UpdateRessourceData(type);
                            break;
                        case BuildingType.storehouse:
                            BuildStorehouse();
                            UpdateRessourceData(type);
                            break;
                        default:
                            Console.WriteLine(type + " is not a switch BuildingType!");
                            break;
                    }
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


        public void UpdateRessourceData(BuildingType t)
        {
            int woodCost;
            int stoneCost;
            switch (t)
            {
                case BuildingType.residence:
                case BuildingType.farm:
                    woodCost = 2500;
                    stoneCost = 2500;
                    break;
                case BuildingType.lumberjackHut:
                    woodCost = 1000;
                    stoneCost = 2500;
                    break;
                case BuildingType.quarry:
                    woodCost = 2500;
                    stoneCost = 1000;
                    break;
                case BuildingType.storehouse:
                    woodCost = 5000;
                    stoneCost = 5000;
                    break;
                default:
                    woodCost = 0;
                    stoneCost = 0;
                    break;
            }

            foreach (var ressource in ressource)
            {
                switch (ressource.ressourceType)
                {
                    case RessourceType.worker:
                        ressource.maxRessource = 0;
                        break;
                    case RessourceType.food:
                        ressource.currentRessource -= 0;
                        break;
                    case RessourceType.wood:
                        ressource.currentRessource -= woodCost;
                        break;
                    case RessourceType.stone:
                        ressource.currentRessource -= stoneCost;
                        break;
                    case RessourceType.building:
                        ressource.currentRessource = structures.Count;
                        break;
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
            if(DethTimer <= 0)
            {
                DethTimer = 10;
            }
            foreach (var ressi in ressource)
            {
                if (ressi.ressourceType == RessourceType.worker)
                {
                    foreach (var ressource in ressource)
                    {
                        if (ressource.ressourceType == RessourceType.food || ressource.ressourceType == RessourceType.wood)
                        {
                            ressource.currentRessource -= (ressi.currentRessource * 20);
                            if (ressource.currentRessource <= 0)
                            {
                                ressource.currentRessource = 0;
                                DethTimer -= 1;
                                if(DethTimer == 0)
                                {
                                    ressi.currentRessource -= 1;
                                    if (ressi.currentRessource < 0)
                                    {
                                        ressi.currentRessource = 0;
                                    }
                                }
                            }
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

        internal void updateCost(long costWood, long costStone)
        {
            foreach(var ress in ressource)
            {
                switch (ress.ressourceType)
                {
                    case RessourceType.stone:
                        ress.currentRessource -= costStone;
                        break;
                    case RessourceType.wood:
                        ress.currentRessource -= costWood;
                        break;
                }
            }
        }
    }
}