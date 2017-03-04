namespace Zavtra
{
    /// <summary>
    /// Die Holzfällerhütte ist das Gebäude zum sammeln von Holz
    /// </summary>
    public class LumberjackHut : StructureRessource
    {
        public LumberjackHut()
        {
            level = 1;
            building = BuildingType.lumberjackHut;
            costWood = 2000;
            costStone = 5000;
            ressource = RessourceType.wood;
            worker = 0;
            minWorker = 0;
            maxWorker = 5;
            output = 250;
        }

        public override void upgrade()
        {
            output += 5;
            costCalculator();
        }
    }
}