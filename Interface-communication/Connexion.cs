using System.Net.Sockets;

namespace Interface_communication;

/// <summary>
/// Permet d'établir la connexion avec le serveur et d'échanger des messages avec lui 
/// </summary>
public class Connexion
{
    #region Attributs
    private TcpClient? client;
    private StreamReader fluxEntrant;
    private StreamWriter fluxSortant;
    #endregion

    #region Propriétés
    public StreamReader FluxEntrant { get => fluxEntrant; }
    public StreamWriter FluxSortant { get => fluxSortant; set => fluxSortant = value; }
    #endregion

    #region Méthodes
    public void ConnexionServeur()
    {
        client = new TcpClient("127.0.0.1", 1234);
    }

    public void CreationFlux()
    {
        if (client == null)
            ConnexionServeur(); //TODO à tester, c'est une modification effectuée pour le toolkit (un peu plus propre que ce qui existait avant)
        fluxEntrant = new StreamReader(client.GetStream());
        fluxSortant = new StreamWriter(client.GetStream());
        fluxSortant.AutoFlush = true;
    }

    /// <summary>
    /// Réceptionne le dernier message envoyé par le serveur
    /// </summary>
    /// <returns>Le message</returns>
    public string RecevoirMessage()
    {
        var message = FluxEntrant.ReadLine();
        message ??= "";
        Console.WriteLine($"<< réception message : {message}");
        return message;
    }

    public void EnvoyerMessage(string message)
    {
        this.FluxSortant.WriteLine(message);
        Console.WriteLine($">> envoi message : {message}");
    }

    public void Stop()
    {
        client?.Close();
    }
    #endregion

}