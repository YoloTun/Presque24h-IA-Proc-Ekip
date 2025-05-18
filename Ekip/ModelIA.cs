using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interface_communication;

namespace Ekip
{
    public class ModelIA : IntelligenceArtificielle
    {
        public override List<Message> PhaseTour(int tour, int phase, List<ReponseServeur> reponsesServeur)
        {
            List<Message> messages = new List<Message>();
            Joueur moi = new Joueur();
            if (phase != 16) //pas la nuit de sang
            {
                if (tour <= 3)
                {
                    if ((phase == 3) || (phase == 7) || (phase == 11) || (phase == 15)) //C'est la nuit
                    {
                        messages.Add(new Message("UTILISER", ["2"]));
                        messages.Add(new Message("PIOCHER", ["2"]));
                    }
                    else
                    {
                        messages.Add(new Message("UTILISER", ["2"]));
                        messages.Add(new Message("PIOCHER", ["2"]));
                    }
                        
                }
                else
                {
                    if ((phase == 3) || (phase == 7) || (phase == 11) || (phase == 15)) //C'est la nuit
                    {
                        messages.Add(new Message("UTILISER", ["0"]));
                        messages.Add(new Message("PIOCHER", ["0"]));
                    }   
                    else
                    {
                        messages.Add(new Message("UTILISER", ["0"]));
                        messages.Add(new Message("PIOCHER", ["2"]));
                    }             
                }           
            }
            return messages;
        }

        public override List<Message> GetProtocoleDemarragePartie()
        {
            return [new Message("/Proc/Lekip")];
        }
    }
}
