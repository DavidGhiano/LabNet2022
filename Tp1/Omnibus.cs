using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp1
{
    public class Omnibus : TransportePublico
    {
        public Omnibus(string patente, int pasajeros) : base(patente, pasajeros)
        {
            this.tipo = "Omnibus";
        }

        public override void Avanzar(){}

        public override void Detenerse(){}

    }
}
