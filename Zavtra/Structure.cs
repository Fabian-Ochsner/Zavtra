namespace Zavtra
{
    /// <summary>
    /// Die Abstrakte Klasse aller Geb�ude
    /// </summary>
    public abstract class Structure
    {
        public int level { get; protected set; }
        public BuildingType building { get; protected set; }
        public long costWood { get; protected set; }
        public long costStone { get; protected set; }
        public RessourceType ressource { get; protected set; }
        public int worker { get; set; }
        public int minWorker { get; protected set; }
        public int maxWorker { get; protected set; }

        public abstract void upgrade();
        protected void costCalculator()
        {
            costWood *= ((level + 10) / 10);
            costStone *= ((level + 10) / 10);
            level += 1;
        }

    }
}