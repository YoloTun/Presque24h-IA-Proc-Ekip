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
    
    #region Méthodes
    private Logger(){}

    public void ActiveLogFichier(string chemin)
    {
        cheminLog = chemin;
        logFichier = true;
    }

    public void DesactiveLogFichier()
    {
        logFichier = false;
    }

    public void ActiveLogConsole()
    {
        logConsole = true;
    }
    
    public void DesactiveLogConsole()
    {
        logConsole = false;
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