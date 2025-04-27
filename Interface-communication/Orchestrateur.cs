using Interface_communication.Utils;
using Interface_communication.Utils.Logging;
using Interface_communication.Utils.Observation;

namespace Interface_communication;

/// <summary>
/// Orchestre les actions de l'IA
/// </summary>
public class Orchestrateur(IntelligenceArtificielle ia) : IObserver
{
    private readonly IntelligenceArtificielle ia = ia;
    private int tourActuel = 0;

    public void ReceptionMessage(string message, Observable emetteur)
    {
        throw new NotImplementedException();
    }

    public void ReceptionOrdre(Message message, Observable emetteur)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Exécute un tour de jeu
    /// </summary>
    public void Tour()
    {
        tourActuel++;
        Logger.Log(NiveauxLog.Info, $"--- DÉBUT DU TOUR {tourActuel} ---");
        RecuperationInfos();
        Strategie();
        Logger.Log(NiveauxLog.Info, $"--- FIN DU TOUR {tourActuel} ---");
    }

    private void RecuperationInfos()
    {
        // On récupère les ordres de l'IA pour obtenir les informations du jeu
        Logger.Log(NiveauxLog.Info, ">>> Début de renseignementation de l'IA");
        var ordresInfos = ia.Renseignementation();
        Logger.Log(NiveauxLog.Info, "<<< Fin de renseignementation de l'IA");
        // TODO Apporter à l'IA les informations récupérées
    }

    private void Strategie()
    {
        // On fait réfléchir l'IA avec les informations qu'elle a obtenu et on récupère ses ordres
        Logger.Log(NiveauxLog.Info, ">>> Début de stratégisation de l'IA");
        var ordresActions = ia.Strategisation();
        Logger.Log(NiveauxLog.Info, "<<< Fin de stratégisation de l'IA");
        
        // On applique la stratégie donnée par l'IA
        Logger.Log(NiveauxLog.Info, ">>> Application de la stratégie de l'IA");
        EnvoyerListeMessages(ordresActions);
        Logger.Log(NiveauxLog.Info, "<<< Fin de l'application de la stratégie de l'IA");
    }

    private void EnvoyerMessage(Message message)
    {
        Connexion.Instance.EnvoyerMessage(message.MessageServeur);
    }

    private void EnvoyerListeMessages(List<Message> messagesList)
    {
        foreach (var message in messagesList)
        {
            EnvoyerMessage(message);
        }
    }
}