namespace Zavtra
{
    /// <summary>
    /// Die Ressource Nahrung wird von den Arbeitern zum überleben benötigt
    /// </summary>
    public class Food : Ressource
    {
        public Food()
        {
            ressourceType = RessourceType.food;
            maxRessource = 30000;
            currentRessource = 30000;
        }
    }
}