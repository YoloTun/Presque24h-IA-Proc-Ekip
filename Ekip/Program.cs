using Ekip;
using Interface_communication.Utils;
using Interface_communication.Utils.Logging;

ModelIA modelIA = new ModelIA();

Config.NombrePhaseTour = 17;
Logger.NiveauLog = NiveauxLog.Info;

modelIA.Jouer();
