using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Net.LINQ.Logic
{
    public interface IABMLogic<T>
    {
        List<T> GetAll();
    }
}
