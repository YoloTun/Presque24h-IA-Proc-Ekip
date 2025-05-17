using Interface_communication.Utils;

namespace Interface_communication;

/// <summary>
/// Message envoyé par le serveur
/// </summary>
public class MessageServeur : Message
{
    /// <summary>
    /// Indique si le message est une erreur serveur
    /// </summary>
    public bool EstErreur => VerbeMessage.StartsWith(Config.MessageErreurServeur);

    /// <summary>
    /// Indique le "verbe" du message
    /// </summary>
    public new string VerbeMessage => base.VerbeMessage;

    /// <summary>
    /// Instancie un message du serveur
    /// </summary>
    /// <param name="messageBrut">Chaîne de caractère brute envoyée par le serveur</param>
    internal MessageServeur(string messageBrut) : base(GetVerbe(messageBrut), GetArguments(messageBrut)) { }

    private static string GetVerbe(string messageBrut)
    {
        return messageBrut.Split(Config.ArgumentsDelimiter)[0];
    }

    private static string[] GetArguments(string messageBrut)
    {
        var messageParse = messageBrut.Split(Config.ArgumentsDelimiter);
        return messageParse.Skip(1).ToArray();
    }
}