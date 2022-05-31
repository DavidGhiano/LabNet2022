using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp2.Exceptions
{
    public class ExceptionPersonalizada : Exception
    {
        public ExceptionPersonalizada(): base("Oh oh!!! Hubo un pequeño error. ¡¡Puedes solucionarlo con reiniciar la compu!!")
        {

        }
    }
}
