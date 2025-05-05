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
    
    public string MessageServeur => $"{messageServeur}{Config.ArgumentsDelimiter}{PrintableArguments}";

    /// <summary>
    /// Ajoute un nouvel argument au message
    /// </summary>
    /// <param name="argument">The argument to be added to the list.</param>
    public void AddArgument(string argument)
    {
        arguments.Add(argument);
    }
}