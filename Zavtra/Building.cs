namespace Zavtra
{
    /// <summary>
    /// Die Ressource der Gebäude
    /// </summary>
    public class Building : Ressource
    {
        public Building()
        {
            ressourceType = RessourceType.building;
            maxRessource = 5;
            currentRessource = 3;
        }
    }
}