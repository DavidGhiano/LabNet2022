using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp1
{
    public abstract class TransportePublico
    {
        public string patente { get; set; }
        public string tipo { get; set; }
        public int pasajeros { get; set; }

        public TransportePublico(string patente, int pasajeros)
        {
            this.patente = patente;
            this.pasajeros = pasajeros;
        }

        public abstract void Avanzar();

        public abstract void Detenerse();

        public void Info()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("TRANSPORTE: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(this.tipo.ToUpper());
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\tPATENTE: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(this.patente);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\tPASAJEROS: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(this.pasajeros);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

    }
}
