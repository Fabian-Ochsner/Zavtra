namespace Zavtra
{
    /// <summary>
    /// Die Holzf�llerh�tte ist das Geb�ude zum sammeln von Holz
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