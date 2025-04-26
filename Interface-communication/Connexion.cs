using System.Net.Sockets;
using Interface_communication.Utils.Logging;

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
    private static Connexion? instance;
    #endregion

    /// <summary>
    /// Obtient l'instance unique (singleton) de la classe <see cref="Connexion"/>.
    /// Fournit un point d'entrée unique pour établir la connexion avec le serveur et
    /// échanger des messages via les flux de communication initialisés.
    /// </summary>
    public static Connexion Instance { get { instance ??= new Connexion(); return instance; }}

    #region Méthodes
    private void ConnexionServeur()
    {
        client = new TcpClient(Config.HostnameServeur, Config.PortServeur);
    }

    /// <summary>
    /// Initialise les flux de communication avec le serveur en créant des objets
    /// StreamReader et StreamWriter associés au client connecté.
    /// </summary>
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
        var message = fluxEntrant.ReadLine();
        message ??= "";
        Logger.Log(NiveauxLog.Action, $"<-- réception message : {message}");
        return message;
    }

    public void EnvoyerMessage(string message)
    {
        fluxSortant.WriteLine(message);
        Logger.Log(NiveauxLog.Action, $"--> envoi message : {message}");
    }

    public void Stop()
    {
        client?.Close();
    }
    #endregion

}