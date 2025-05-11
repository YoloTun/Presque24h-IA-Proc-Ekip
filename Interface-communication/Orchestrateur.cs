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
    private bool partieEnCours;

    public Orchestrateur(IntelligenceArtificielle ia) : this()
    {
        this.ia = ia;
        tourActuel = 0;
        dernieresReponsesServeur = [];
        partieEnCours = false;
    }

    /// <summary>
    /// Lance la partie
    /// </summary>
    public void Jouer()
    {
        Logger.Log(NiveauxLog.Info, "Lancement de la partie");
        // Démarrage de la partie suivant le protocole fournit par l'IA
        dernieresReponsesServeur = EnvoyerListeMessages(ia.GetProtocoleDemarragePartie());
        partieEnCours = true;

        while (partieEnCours)
        {
            Tour();
        }
        Connexion.Instance.Stop();
    }

    /// <summary>
    /// Méthode à appeler pour mettre fin à la partie
    /// </summary>
    public void FinPartie()
    {
        partieEnCours = false;
    }
    
    /// <summary>
    /// Exécute un tour de jeu
    /// </summary>
    private void Tour()
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
        Logger.Log(NiveauxLog.Info, $">>> Début de la phase {phase}");
        
        List<Message> ordresListe = ia.PhaseTour(tourActuel, phase, dernieresReponsesServeur);
        List<ReponseServeur> reponseServeur = EnvoyerListeMessages(ordresListe);
        this.dernieresReponsesServeur = reponseServeur;
        
        Logger.Log(NiveauxLog.Info, $"<<< Fin de la phase {phase}");
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