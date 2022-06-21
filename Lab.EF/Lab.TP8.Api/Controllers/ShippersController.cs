using Lab.TP7.Entities;
using Lab.TP7.Logic;
using Lab.TP8.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lab.TP8.Api.Controllers
{
    public class ShippersController : ApiController
    {
        ShippersLogic shippersLogic = new ShippersLogic();

        public IHttpActionResult GetAll()
        {
            List<Shippers> shippersList = shippersLogic.GetAll();
            List<ShippersView> shippersViews = shippersList.Select(s => new ShippersView
            {
                ID = s.ShipperID,
                CompanyName = s.CompanyName,
                Telefono = s.Phone
            }).ToList();

            if(shippersViews.Count == 0)
                return NotFound();

            return Ok(shippersViews);
        }

        public IHttpActionResult GetById(int id)
        {
            Shippers shippers = shippersLogic.GetOne(id);
            if(shippers == null)
                return NotFound();
            ShippersView shippersView = new ShippersView
            {
                ID = shippers.ShipperID,
                CompanyName = shippers.CompanyName,
                Telefono = shippers.Phone
            };

            return Ok(shippersView);
        }

        public IHttpActionResult PostCreate(ShippersView shippersView)
        {
            if (!ModelState.IsValid)
                return BadRequest("Datos inválidos");

            Shippers shippers = new Shippers
            {
                CompanyName = shippersView.CompanyName,
                Phone = shippersView.Telefono
            };
            shippersLogic.Add(shippers);
            return Ok("Agregado con éxito");
        }

        public IHttpActionResult PatchEdit(ShippersView shippersView)
        {
            if (!ModelState.IsValid)
                return BadRequest("Datos inválidos");

            Shippers shippers = new Shippers
            {
                ShipperID = shippersView.ID,
                CompanyName = shippersView.CompanyName,
                Phone = shippersView.Telefono
            };
            shippersLogic.Update(shippers);
            return Ok("Actualizado con éxito");
        }

        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Id invalido");
            if (!shippersLogic.Delete(id))
                return BadRequest("Hubo un problema");

            return Ok("Registro eliminado");
        }
    }
}
