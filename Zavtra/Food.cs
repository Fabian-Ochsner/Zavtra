namespace Zavtra
{
    /// <summary>
    /// Die Ressource Nahrung wird von den Arbeitern zum �berleben ben�tigt
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