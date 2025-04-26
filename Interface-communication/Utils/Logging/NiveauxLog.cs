namespace Interface_communication.Utils.Logging;

public enum NiveauxLog
{
    None, // Aucun niveau de log, ne doit pas être utilisé pour signaler un message mais uniquement comme niveau du logger
    Info, // Informations générales
    Action, // Actions plus importantes que de simples informations
    Erreur // Erreurs
}