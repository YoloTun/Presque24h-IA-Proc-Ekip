using Interface_communication.Utils;

namespace Interface_communication;

/// <summary>
/// Réponse à un message envoyé par un serveur
/// </summary>
public class ReponseServeur
{
    private Message message;
    private string reponse;
    private string[] arguments; // Les arguments de la réponse
    
    public ReponseServeur(Message message, string reponseBrute)
    {
        this.message = message;
        
        var reponseParsee = reponseBrute.Split(Config.ArgumentsDelimiter);
        this.reponse = reponseParsee[0];
        this.arguments = reponseParsee.Skip(1).ToArray();
    }

    /// <summary>
    /// Message original
    /// </summary>
    public Message Message => message;

    /// <summary>
    /// Réponse du serveur
    /// </summary>
    public string Reponse => reponse;
    
    public string[] Arguments => (string[])arguments.Clone();
}