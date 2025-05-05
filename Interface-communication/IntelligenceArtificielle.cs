using Interface_communication.Utils;
using Interface_communication.Utils.Observation;

namespace Interface_communication;

/// <summary>
/// Classe abstraite représentant une intelligence artificielle pour un jeu.
/// Hérite d'un observateur permettant d'interagir avec d'autres composants de l'application.
/// </summary>
public abstract class IntelligenceArtificielle
{
    private Orchestrateur orchestrateur;

    protected IntelligenceArtificielle()
    {
        orchestrateur = new Orchestrateur(this);
    }
    
    /// <summary>
    /// On se renseigne sur l'état du jeu
    /// </summary>
    /// <returns>Liste d'ordres pour récupérer des informations, ceux-ci ne doivent pas impacter le jeu</returns>
    public abstract List<Message> Renseignementation();
    // TODO Ajouter un système pour apporter à l'IA les informations qu'elle demande

    /// <summary>
    /// On définit la stratégie du tour courant
    /// </summary>
    /// <param name="infosJeu">Informations sur l'état du jeu fournies par le serveur (réponse à Renseignementation)</param>
    /// <returns>Liste d'ordres d'action à prendre ce tour</returns>
    public abstract List<Message> Strategisation(List<ReponseServeur> infosJeu);
}