using Interface_communication.Utils;
using Interface_communication.Utils.Logging;

namespace Interface_communication;

/// <summary>
/// Orchestre les actions de l'IA
/// </summary>
internal class Orchestrateur()
{
    private readonly IntelligenceArtificielle ia;
    private int tourActuel;
    private List<ReponseServeur> dernieresReponsesServeur;

    public Orchestrateur(IntelligenceArtificielle ia) : this()
    {
        this.ia = ia;
        tourActuel = 0;
        dernieresReponsesServeur = [];
    }
    
    /// <summary>
    /// Exécute un tour de jeu
    /// </summary>
    public void Tour()
    {
        tourActuel++;
        Logger.Log(NiveauxLog.Info, $"--- DÉBUT DU TOUR {tourActuel} ---");
        for (int phase = 0; phase < Config.NombrePhaseTour; phase++)
        {
            PhaseTour(phase);
        }
        Logger.Log(NiveauxLog.Info, $"--- FIN DU TOUR {tourActuel} ---");
    }

    private void PhaseTour(int phase)
    {
        List<Message> ordresListe = ia.PhaseTour(tourActuel, phase, dernieresReponsesServeur);
        
        List<ReponseServeur> reponseServeur = EnvoyerListeMessages(ordresListe);
        
        this.dernieresReponsesServeur = reponseServeur;
    }

    private ReponseServeur EnvoyerMessage(Message message)
    {
        Connexion.Instance.EnvoyerMessage(message.MessageServeur);
        return new ReponseServeur(message, Connexion.Instance.RecevoirMessage());
    }

    private List<ReponseServeur> EnvoyerListeMessages(List<Message> messagesList)
    {
        // On envoie chaque message et on reçoit le résultat
        return messagesList.Select(EnvoyerMessage).ToList();
    }
}