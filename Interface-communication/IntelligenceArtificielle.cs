using Interface_communication.Utils;
using Interface_communication.Utils.Observation;

namespace Interface_communication;

/// <summary>
/// Classe abstraite représentant une intelligence artificielle pour un jeu.
/// </summary>
public abstract class IntelligenceArtificielle
{
    private Orchestrateur orchestrateur;

    /// <summary>
    /// Constructeur par défaut, doit être obligatoirement appelé par les sous-classes.
    /// </summary>
    protected IntelligenceArtificielle()
    {
        orchestrateur = new Orchestrateur(this);
    }
    
    /// <summary>
    /// On se renseigne sur l'état du jeu
    /// </summary>
    /// <returns>Liste d'ordres pour récupérer des informations, ceux-ci ne doivent pas impacter le jeu</returns>
    public abstract List<Message> Renseignementation();

    /// <summary>
    /// On définit la stratégie du tour courant
    /// </summary>
    /// <param name="infosJeu">Informations sur l'état du jeu fournies par le serveur (réponse à Renseignementation)</param>
    /// <returns>Liste d'ordres d'action à prendre ce tour</returns>
    public abstract List<Message> Strategisation(List<ReponseServeur> infosJeu);
}