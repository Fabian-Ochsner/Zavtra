namespace Zavtra
{
    /// <summary>
    /// Die Ressource der Geb�ude
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