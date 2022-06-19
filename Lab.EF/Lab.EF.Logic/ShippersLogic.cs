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

        public void Delete(int id)
        {
            var shipper = context.Shippers.Find(id);

            context.Shippers.Remove(shipper);
            context.SaveChanges();
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
            return context.Shippers.First(s => s.ShipperID == id);
        }
    }
}
