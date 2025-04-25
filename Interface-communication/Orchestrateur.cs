using Interface_communication.Utils;

namespace Interface_communication;

/// <summary>
/// Orchestre les actions de l'IA
/// </summary>
public class Orchestrateur(IntelligenceArtificielle ia) : IObserver
{
    private readonly IntelligenceArtificielle ia = ia;

    public void ReceptionMessage(string message, Observable emetteur)
    {
        throw new NotImplementedException();
    }

    public void ReceptionOrdre(Ordre ordre, Observable emetteur)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Exécute un tour de jeu
    /// </summary>
    public void Tour()
    {
        var ordresInfos = ia.Renseignementation();
        // TODO Apporter à l'IA les informations récupérées

        var ordresActions = ia.Strategisation();
        // TODO Appliquer les ordres transmis ici
    }
}