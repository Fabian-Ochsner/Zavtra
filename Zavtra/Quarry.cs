namespace Zavtra
{
    /// <summary>
    /// Der Steinbruch ist das Geb�ude zur gewinnung von Stein
    /// </summary>
    public class Quarry : StructureRessource
    {
        public Quarry()
        {
            level = 1;
            building = BuildingType.quarry;
            costWood = 5000;
            costStone = 2000;
            ressource = RessourceType.stone;
            worker = 0;
            minWorker = 0;
            maxWorker = 5;
            output = 200;
        }

        public override void upgrade()
        {
            output += 5;
            costCalculator();
        }
    }
}