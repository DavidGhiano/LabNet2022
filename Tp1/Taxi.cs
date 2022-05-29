using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp1
{
    public class Taxi : TransportePublico
    {
        public Taxi(string patente, int pasajeros) : base(patente, pasajeros)
        {
            this.tipo = "Taxi";
        }

        public override void Avanzar(){}

        public override void Detenerse(){}

    }
}
