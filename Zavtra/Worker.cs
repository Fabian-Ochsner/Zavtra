namespace Zavtra
{
    /// <summary>
    /// Die Ressource Arbeiter
    /// </summary>
    public class Worker : Ressource
    {
        public long ressource { get; set; }
        public Worker()
        {
            ressourceType = RessourceType.worker;
            maxRessource = 5;
            currentRessource = 3;
            ressource = 5;
        }
    }
}