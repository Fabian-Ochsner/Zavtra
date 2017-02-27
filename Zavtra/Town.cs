using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zavtra
{
    /// <summary>
    /// Diese Klasse ist das oberste Objekt. Alle Gebäude und Ressourcen befinden sich im Dorf
    /// </summary>
    public class Town
    {
        private int DethTimer = 0;
        private int LifeTimer = 0;
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


        public Town(string json)
        {
            string firstfour;
            string jsonFile;
            char splitChar =  '|';
            structures = new List<Structure>();
            ressource = new List<Ressource>();

            string[] classString = json.Split(splitChar);
            foreach(var subString in classString)
            {
                firstfour = subString.Substring(0, 4);

                    switch (firstfour)
                    {
                        case "town":
                         jsonFile = subString.Remove(0, 8);
                        Townhall loadTown = JsonConvert.DeserializeObject<Townhall>(jsonFile);
                        structures.Add(loadTown);
                            break;
                        case "farm":
                         jsonFile = subString.Remove(0, 4);
                        Farm loadfarm = JsonConvert.DeserializeObject<Farm>(jsonFile);
                        structures.Add(loadfarm);
                        break;
                        case "quar":
                         jsonFile = subString.Remove(0, 6);
                        Quarry loadQuar = JsonConvert.DeserializeObject<Quarry>(jsonFile);
                        structures.Add(loadQuar);
                        break;
                        case "lumb":
                         jsonFile = subString.Remove(0, 13);
                        LumberjackHut loadLumb = JsonConvert.DeserializeObject<LumberjackHut>(jsonFile);
                        structures.Add(loadLumb);
                        break;
                        case "stor":
                         jsonFile = subString.Remove(0, 10);
                        Storehouse loadStor = JsonConvert.DeserializeObject<Storehouse>(jsonFile);
                        structures.Add(loadStor);
                        break;
                        case "resi":
                         jsonFile = subString.Remove(0, 9);
                        Residence loadResi = JsonConvert.DeserializeObject<Residence>(jsonFile);
                        structures.Add(loadResi);
                        break;
                        case "buil":
                        jsonFile = subString.Remove(0, 8);
                        Building loadBuil = JsonConvert.DeserializeObject<Building>(jsonFile);
                        ressource.Add(loadBuil);
                        break;
                        case "food":
                        jsonFile = subString.Remove(0, 4);
                        Food loadfood = JsonConvert.DeserializeObject<Food>(jsonFile);
                        ressource.Add(loadfood);
                        break;
                        case "ston":
                        jsonFile = subString.Remove(0, 5);
                        Stone loadSton = JsonConvert.DeserializeObject<Stone>(jsonFile);
                        ressource.Add(loadSton);
                        break;
                        case "wood":
                        jsonFile = subString.Remove(0, 4);
                        Wood loadWood = JsonConvert.DeserializeObject<Wood>(jsonFile);
                        ressource.Add(loadWood);
                        break;
                        case "work":
                        jsonFile = subString.Remove(0, 6);
                        Worker loadWork = JsonConvert.DeserializeObject<Worker>(jsonFile);
                        ressource.Add(loadWork);
                        break;
                    }
                }
        }

        internal string SerializeObjects()
        {
            bool first = true;
            string json = "";
            string buildup;
            string marker = "|";

            foreach(var building in structures)
            {
                switch (building.building)
                {
                    case BuildingType.farm:
                        buildup = BuildingType.farm + JsonConvert.SerializeObject((Farm)building);
                            break;
                    case BuildingType.lumberjackHut:
                        buildup = BuildingType.lumberjackHut+JsonConvert.SerializeObject((LumberjackHut)building);
                        break;
                    case BuildingType.quarry:
                        buildup = BuildingType.quarry+JsonConvert.SerializeObject((Quarry)building);
                        break;
                    case BuildingType.residence:
                        buildup = BuildingType.residence+JsonConvert.SerializeObject((Residence)building);
                        break;
                    case BuildingType.storehouse:
                        buildup = BuildingType.storehouse+JsonConvert.SerializeObject((Storehouse)building);
                        break;
                    case BuildingType.townhall:
                        buildup = BuildingType.townhall+JsonConvert.SerializeObject((Townhall)building);
                        break;
                    default:
                        buildup = "";
                        break;
                }
                if (!first)
                    json += marker;
                first = false;
                json += buildup;
            }

            foreach (var ressi in ressource)
            {
                switch (ressi.ressourceType)
                {
                    case RessourceType.building:
                        buildup = RessourceType.building + JsonConvert.SerializeObject((Building)ressi);
                        break;
                    case RessourceType.food:
                        buildup = RessourceType.food + JsonConvert.SerializeObject((Food)ressi);
                        break;
                    case RessourceType.stone:
                        buildup = RessourceType.stone + JsonConvert.SerializeObject((Stone)ressi);
                        break;
                    case RessourceType.wood:
                        buildup = RessourceType.wood + JsonConvert.SerializeObject((Wood)ressi);
                        break;
                    case RessourceType.worker:
                        buildup = RessourceType.worker + JsonConvert.SerializeObject((Worker)ressi);
                        break;
                    default:
                        buildup = "";
                        break;
                }
                if (!first)
                    json += marker;
                first = false;
                json += buildup;
            }




            return json;
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
                DethTimer = 15;
            }
            if (LifeTimer <= 0)
            {
                LifeTimer = 10;
            }
            foreach (var ressi in ressource)
            {
                if (ressi.ressourceType == RessourceType.worker)
                {
                    foreach (var ressourc in ressource)
                    {
                        if (ressourc.ressourceType == RessourceType.food || ressourc.ressourceType == RessourceType.wood)
                        {
                            ressourc.currentRessource -= (((Worker)ressi).ressource * 20);
                            if (ressourc.currentRessource <= 0)
                            {
                                ressourc.currentRessource = 0;
                                DethTimer -= 1;
                                if(DethTimer == 0)
                                {
                                    ressi.currentRessource -= 1;
                                    ((Worker)ressi).ressource -= 1;
                                    if (ressi.currentRessource < 0)
                                    {
                                        bool worker = false;
                                        ressi.currentRessource = 0;
                                        foreach(var building in structures)
                                        {
                                            if(building.building != BuildingType.townhall && building.worker > 0 && !worker)
                                            {
                                                building.worker -= 1;
                                                worker = true;
                                            }
                                        }
                                    }
                                    if (((Worker)ressi).ressource < 0)
                                    {
                                        ((Worker)ressi).ressource = 0;
                                    }
                                }
                            }
                        }
                        if(ressourc.ressourceType == RessourceType.food)
                        {
                            foreach (var ress in ressource)
                            {
                                if (ress.ressourceType == RessourceType.wood)
                                {
                                    if(ressourc.currentRessource > 2000 && ress.currentRessource > 1000)
                                    {
                                        foreach(var building in structures)
                                        {
                                            if(building.building == BuildingType.residence && building.worker == 2 && ((Worker)ressi).ressource < ressi.maxRessource)
                                            {
                                                if (LifeTimer == 10)
                                                {
                                                    ressi.currentRessource += 1;
                                                    ((Worker)ressi).ressource += 1;
                                                }
                                                LifeTimer -= 1;
                                            }
                                        }
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
                            ressi.currentRessource += (((StructureRessource)building).output / building.maxWorker) * building.worker;
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