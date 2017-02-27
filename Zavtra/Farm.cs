namespace Zavtra
{
    /// <summary>
    /// Die Farm ist das Gebäude zum anbauen und sammeln von Nahrung
    /// </summary>
    public class Farm : StructureRessource
    {
        public Farm()
        {
            level = 1;
            building = BuildingType.farm;
            costWood = 5000;
            costStone = 5000;
            ressource = RessourceType.food;
            worker = 0;
            minWorker = 0;
            maxWorker = 5;
            output = 250;
        }

        public override void upgrade()
        {
            maxWorker *= ((level + 10) / 10);
            output += 10;
            costCalculator();
        }
    }
}