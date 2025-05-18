using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekip
{
    public class Joueur
    {
        private int pv;
        private int atk;
        private int def;
        private int savoir;

        public int Pv { get => pv; set => pv = value; }
        public int Atk { get => atk; set => atk = value; }
        public int Def { get => def; set => def = value; }
        public int Savoir { get => savoir; set => savoir = value; }

        public Joueur()
        {

        }
    }
}
