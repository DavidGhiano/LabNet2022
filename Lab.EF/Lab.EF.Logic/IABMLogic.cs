using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.TP7.Logic
{
    public interface IABMLogic<T>
    {
        List<T> GetAll();

        T GetOne(int id);

        void Add(T newObject);

        bool Delete(int id);

        void Update(T objectUpdate);
    }
}
