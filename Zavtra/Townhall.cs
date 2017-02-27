namespace Zavtra
{
    /// <summary>
    /// Die Stadthalle legt fest wie viele Gebäude in einem Gorf gebaut werden können
    /// </summary>
    public class Townhall : Structure
    {
        public int MaxBuildings { get; private set; }
        public int currentBuildings { get; private set; }
        public Townhall()
        {
            level = 1;
            building = BuildingType.townhall;
            costWood = 15000;
            costStone = 15000;
            ressource = RessourceType.building;
            worker = 1;
            minWorker = 0;
            maxWorker = 1;
            MaxBuildings = 10;
        }

        public override void upgrade()
        {
            costCalculator();
            MaxBuildings += 5;
        }
    }
}