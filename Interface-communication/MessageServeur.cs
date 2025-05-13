using Interface_communication.Utils;

namespace Interface_communication;

/// <summary>
/// Message envoyé par le serveur
/// </summary>
public class MessageServeur
{
    private readonly string message;
    private readonly string[] arguments; // Les arguments de la réponse
    
    /// <summary>
    /// Message envoyé par le serveur
    /// </summary>
    public string Message => message;

    /// <summary>
    /// Arguments associés au message du serveur
    /// </summary>
    public string[] Arguments => arguments;

    /// <summary>
    /// Indique si le message est une erreur serveur
    /// </summary>
    public bool EstErreur => message.StartsWith(Config.MessageErreurServeur);

    /// <summary>
    /// Instancie un message du serveur
    /// </summary>
    /// <param name="messageBrut">Chaîne de caractère brute envoyée par le serveur</param>
    internal MessageServeur(string messageBrut)
    {
        var messageParse = messageBrut.Split(Config.ArgumentsDelimiter);
        this.message = messageParse[0];
        this.arguments = messageParse.Skip(1).ToArray();
    }

    public override string ToString()
    {
        return arguments.Length > 0 ? $"({Message}{string.Join(", ", Arguments)})" : Message;
    }
}