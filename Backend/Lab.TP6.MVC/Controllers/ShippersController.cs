using Lab.TP6.MVC.Models;
using Lab.TP7.Entities;
using Lab.TP7.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab.TP6.MVC.Controllers
{
    public class ShippersController : Controller
    {
        ShippersLogic shippersLogic = new ShippersLogic();
        // GET: Shipper
        public ActionResult Listar()
        {
            List<Shippers> shippersList = shippersLogic.GetAll();

            List<ShippersView> shippersView = shippersList.Select(s => new ShippersView
            {
                ID = s.ShipperID,
                CompanyName = s.CompanyName,
                Telefono = s.Phone
            }).ToList();
            return View(shippersView);
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(ShippersView shippersView)
        {
            if (!ModelState.IsValid) return View();
            try
            {
                var shippers = new Shippers
                {
                    CompanyName = shippersView.CompanyName,
                    Phone = shippersView.Telefono
                };
                shippersLogic.Add(shippers);
                return RedirectToAction("Listar");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                shippersLogic.Delete(id);
                return RedirectToAction("Listar");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult Edit(int id)
        {
            Shippers shippers = shippersLogic.GetOne(id);
            ShippersView shippersView = new ShippersView
            {
                ID = shippers.ShipperID,
                CompanyName = shippers.CompanyName,
                Telefono = shippers.Phone
            };
            return View(shippersView);
        }

        [HttpPost]
        public ActionResult Edit(ShippersView shippersView)
        {
            if (!ModelState.IsValid) return View();
            try
            {
                var shipperEntity = new Shippers
                {
                    ShipperID = shippersView.ID,
                    CompanyName = shippersView.CompanyName,
                    Phone = shippersView.Telefono
                };
                shippersLogic.Update(shipperEntity);
                return RedirectToAction("Listar");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }
    }
}