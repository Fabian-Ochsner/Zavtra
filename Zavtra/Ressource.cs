namespace Zavtra
{
    /// <summary>
    /// Die abstrakte Klasse aller Ressourcen
    /// </summary>
    public abstract class Ressource
    {
        public RessourceType ressourceType { get; protected set; }
        public long maxRessource { get;  set; }
        public long currentRessource { get;  set; }
    }
}