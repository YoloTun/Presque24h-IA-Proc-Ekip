using System.Runtime.CompilerServices;

namespace Interface_communication.Utils.Logging;

/// <summary>
/// Un logger simple pour les besoins de l'application
/// </summary>
public class Logger
{
    #region Attributs
    private static NiveauxLog niveauLog = NiveauxLog.Action;
    private static string? cheminLog;
    private static bool logFichier = false;
    private static bool logConsole = true;
    #endregion
    
    /// <summary>
    /// Définis le niveau de log
    /// </summary>
    public static NiveauxLog NiveauLog
    {
        get => niveauLog;
        set => niveauLog = value;
    }

    /// <summary>
    /// Définis si les logs doivent s'afficher dans la console
    /// </summary>
    public static bool LogConsole
    {
        get => logConsole;
        set => logConsole = value;
    }

    #region Méthodes
    private Logger(){}

    public static void ActiveLogFichier(string chemin)
    {
        cheminLog = chemin;
        logFichier = true;
    }

    public static void DesactiveLogFichier()
    {
        logFichier = false;
    }

    
    public static void Log(NiveauxLog niveauMessage, string message)
    {
        if (niveauMessage >= niveauLog)
        {
            if (logConsole)
                Console.WriteLine($"[{niveauMessage}] {message}");
            if (logFichier)
                File.AppendAllText(cheminLog, $"[{niveauMessage}] {message}\n");
        }
    }
    #endregion
}