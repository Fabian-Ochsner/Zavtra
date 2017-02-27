namespace Zavtra
{
    /// <summary>
    /// Das Lager enthält die Ressourcen die für den bau und zum Überleben benötigt werden
    /// </summary>
    public class Storehouse : Structure
    {
        public long maxFood { get; private set; }
        public long maxWood { get; private set; } 
        public long maxStone { get; private set; }
        public long food { get; private set; }
        public long wood { get; private set; }
        public long stone { get; private set; }


        public Storehouse()
        {
            level = 1;
            building = BuildingType.storehouse;
            costWood = 10000;
            costStone = 10000;
            ressource = RessourceType.storage;
            worker = 1;
            minWorker = 0;
            maxWorker = 1;
            maxFood = 30000;
            maxWood = 30000;
            maxStone = 30000;
            food = 0;
            wood = 0;
            stone = 0;
        }

        public override void upgrade()
        {
            maxFood *= ((level + 10) / 10);
            maxWood *= ((level + 10) / 10);
            maxStone *= ((level + 10) / 10);
            costCalculator();
        }
    }
}