namespace Interface_communication;

/// <summary>
/// Représente un ordre donné par l'IA
/// </summary>
public class Message
{
    private string messageServeur;
    private List<string> arguments;

    private string PrintableArguments => string.Join(Config.ArgumentsDelimiter, arguments);
    
    public string MessageServeur => $"{messageServeur}{Config.ArgumentsDelimiter}{PrintableArguments}";
}