namespace Zavtra
{
    /// <summary>
    /// Die Ressource Stein
    /// </summary>
    public class Stone : Ressource
    {
        public Stone()
        {
            ressourceType = RessourceType.stone;
            maxRessource = 30000;
            currentRessource = 30000;
        }
    }
}
