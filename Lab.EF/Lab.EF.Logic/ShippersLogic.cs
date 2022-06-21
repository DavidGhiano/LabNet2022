using Lab.TP7.Data;
using Lab.TP7.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.TP7.Logic
{
    public class ShippersLogic : BaseLogic, IABMLogic<Shippers>
    {

        public List<Shippers> GetAll()
        {
            return context.Shippers.ToList();
        }

        public void Add(Shippers shippers)
        {
            context.Shippers.Add(shippers);

            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            try
            {
                var shipper = context.Shippers.Find(id);

                context.Shippers.Remove(shipper);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public void Update(Shippers shipper)
        {
            var shipperUpdate = context.Shippers.Find(shipper.ShipperID);
            shipperUpdate.CompanyName = shipper.CompanyName;
            shipperUpdate.Phone = shipper.Phone;

            context.SaveChanges();
        }

        public Shippers GetOne(int id)
        {
            try
            {
                return context.Shippers.First(s => s.ShipperID == id);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
