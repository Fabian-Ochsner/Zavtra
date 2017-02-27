namespace Zavtra
{
    /// <summary>
    /// Das Wohnhaus legt fest wieviele Arbeiter in einem Dorf leben können
    /// </summary>
    public class Residence : Structure
    {
        public int maxResident { get; private set; }
        public int outputTime { get; private set; }

        public Residence()
        {
            level = 1;
            building = BuildingType.residence;
            costWood = 5000;
            costStone = 5000;
            ressource = RessourceType.worker;
            worker = 0;
            minWorker = 0;
            maxWorker = 2;
            maxResident = 5;
            outputTime = 10;
        }

        public override void upgrade()
        {
            costCalculator();
            maxResident += 2;
        }
    }
}