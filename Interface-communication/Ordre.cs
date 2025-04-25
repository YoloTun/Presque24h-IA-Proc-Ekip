namespace Interface_communication;

/// <summary>
/// Représente un ordre donné par l'IA
/// </summary>
public class Ordre
{
    private string messageServeur;
    private List<string> arguments;
    
    public string MessageServeur => $"{messageServeur} {arguments}";
}