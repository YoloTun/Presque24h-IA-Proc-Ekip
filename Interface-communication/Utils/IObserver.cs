namespace Interface_communication.Utils;

/// <summary>
/// Un observeur simple
/// </summary>
public interface IObserver
{
    /// <summary>
    /// Reçoit et traite de la façon voulue le message envoyé par un observable
    /// </summary>
    /// <param name="message">Message envoyé par un observable</param>
    /// <param name="emetteur">Emetteur du message</param>
    public void ReceptionMessage(string message, Observable emetteur);
}