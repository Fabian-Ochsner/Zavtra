namespace Zavtra
{
    /// <summary>
    /// Die Ressource Holz
    /// </summary>
    public class Wood : Ressource
    {
        public Wood()
        {
            ressourceType = RessourceType.wood;
            maxRessource = 30000;
            currentRessource = 30000;
        }
    }
}