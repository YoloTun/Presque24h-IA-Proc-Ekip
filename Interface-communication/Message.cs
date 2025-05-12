using Interface_communication.Utils;

namespace Interface_communication;

/// <summary>
/// Représente un ordre donné par l'IA
/// </summary>
public class Message
{
    private readonly string messageServeur;
    private readonly List<string> arguments;

    public Message(string messageServeur)
    {
        this.messageServeur = messageServeur;
        arguments = [];
    }

    private string PrintableArguments => string.Join(Config.ArgumentsDelimiter, arguments);
    
    /// <summary>
    /// Message formaté et prêt à être envoyé au serveur
    /// </summary>
    public string MessageServeur => arguments.Count > 0 ? $"{messageServeur}{Config.ArgumentsDelimiter}{PrintableArguments}" : messageServeur;

    /// <summary>
    /// Ajoute un nouvel argument au message
    /// </summary>
    /// <param name="argument">L'argument à ajouter à la liste</param>
    public void AddArgument(string argument)
    {
        arguments.Add(argument);
    }

    /// <summary>
    /// Ajoute une liste d'arguments au message
    /// </summary>
    /// <param name="newArguments">Liste des arguments à ajouter</param>
    public void AddArguments(string[] newArguments)
    {
        this.arguments.AddRange(newArguments);
    }
}