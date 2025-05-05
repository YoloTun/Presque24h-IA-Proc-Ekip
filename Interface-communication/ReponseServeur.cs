namespace Interface_communication;

/// <summary>
/// Réponse à un message envoyé par un serveur
/// </summary>
public class ReponseServeur
{
    private Message message;
    private string reponse;
    
    public ReponseServeur(Message message, string reponse)
    {
        this.message = message;
        this.reponse = reponse;
    }

    /// <summary>
    /// Message original
    /// </summary>
    public Message Message => message;

    /// <summary>
    /// Réponse du serveur
    /// </summary>
    public string Reponse => reponse;
}