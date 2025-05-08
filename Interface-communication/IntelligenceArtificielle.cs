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
    /// Gère une phase d'un tour
    /// </summary>
    /// <param name="tour">Numéro du tour courant (commence à 1)</param>
    /// <param name="phase">Numéro de la phase courante (commence à 0)</param>
    /// <param name="reponsesServeur"></param>
    /// <returns></returns>
    public abstract List<Message> PhaseTour(int tour, int phase, List<ReponseServeur> reponsesServeur);
}