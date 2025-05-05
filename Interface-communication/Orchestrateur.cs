using Interface_communication.Utils;
using Interface_communication.Utils.Logging;
using Interface_communication.Utils.Observation;

namespace Interface_communication;

/// <summary>
/// Orchestre les actions de l'IA
/// </summary>
public class Orchestrateur(IntelligenceArtificielle ia)
{
    private readonly IntelligenceArtificielle ia = ia;
    private int tourActuel = 0;

    /// <summary>
    /// Exécute un tour de jeu
    /// </summary>
    public void Tour()
    {
        tourActuel++;
        Logger.Log(NiveauxLog.Info, $"--- DÉBUT DU TOUR {tourActuel} ---");
        var infosJeu = RecuperationInfos();
        Strategie(infosJeu);
        Logger.Log(NiveauxLog.Info, $"--- FIN DU TOUR {tourActuel} ---");
    }

    private List<ReponseServeur> RecuperationInfos()
    {
        // On récupère les ordres de l'IA pour obtenir les informations du jeu
        Logger.Log(NiveauxLog.Info, ">>> Début de renseignementation de l'IA");
        var ordresInfos = ia.Renseignementation();
        var reponsesRenseignementation = EnvoyerListeMessages(ordresInfos);
        Logger.Log(NiveauxLog.Info, "<<< Fin de renseignementation de l'IA");

        return reponsesRenseignementation;
    }

    private void Strategie(List<ReponseServeur> infosJeu)
    {
        // On fait réfléchir l'IA avec les informations qu'elle a obtenu et on récupère ses ordres
        Logger.Log(NiveauxLog.Info, ">>> Début de stratégisation de l'IA");
        var ordresActions = ia.Strategisation(infosJeu);
        Logger.Log(NiveauxLog.Info, "<<< Fin de stratégisation de l'IA");
        
        // On applique la stratégie donnée par l'IA
        Logger.Log(NiveauxLog.Info, ">>> Application de la stratégie de l'IA");
        EnvoyerListeMessages(ordresActions);
        Logger.Log(NiveauxLog.Info, "<<< Fin de l'application de la stratégie de l'IA");
    }

    private ReponseServeur EnvoyerMessage(Message message)
    {
        Connexion.Instance.EnvoyerMessage(message.MessageServeur);
        return new ReponseServeur(message, Connexion.Instance.RecevoirMessage());
    }

    private List<ReponseServeur> EnvoyerListeMessages(List<Message> messagesList)
    {
        // On envoie chaque message et on reçoit le résultat
        return messagesList.Select(message => EnvoyerMessage(message)).ToList();
    }
}