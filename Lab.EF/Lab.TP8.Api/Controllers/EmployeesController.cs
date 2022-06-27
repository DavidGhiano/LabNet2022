using Lab.TP7.Entities;
using Lab.TP7.Logic;
using Lab.TP8.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Lab.TP8.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmployeesController : ApiController
    {
        EmployeesLogic employeesLogic = new EmployeesLogic();

        
        public IHttpActionResult GetAll()
        {
            List<Employees> employeesList = employeesLogic.GetAll();
            List<EmployeesView> employeesViews = employeesList.Select(e => new EmployeesView
            {
                ID = e.EmployeeID,
                Nombre = e.FirstName,
                Apellido = e.LastName
            }).ToList();

            if (employeesViews.Count == 0)
            {
                return NotFound();
            }

            return Ok(employeesViews);
        }

        // 8080/api/employees/5
        public IHttpActionResult GetById(int id)
        {
            Employees employees = employeesLogic.GetOne(id);

            if (employees == null)
            {
                return NotFound();
            }
            EmployeesView employeesView = new EmployeesView
            {
                ID = employees.EmployeeID,
                Nombre = employees.FirstName,
                Apellido = employees.LastName
            };

            return Ok(employeesView);
        }

        public IHttpActionResult PostCreate(EmployeesView employeesView)
        {
            if (!ModelState.IsValid)
                return BadRequest("Datos inválidos");
            Employees employees = new Employees
            {
                FirstName = employeesView.Nombre,
                LastName = employeesView.Apellido
            };
            employeesLogic.Add(employees);
            return Ok("Agregado con éxito");
        }

        public IHttpActionResult PatchEdit(EmployeesView employeesView)
        {
            if (!ModelState.IsValid)
                return BadRequest("Datos inválidos");
            Employees employees = new Employees
            {
                EmployeeID = employeesView.ID,
                FirstName = employeesView.Nombre,
                LastName = employeesView.Apellido
            };
            employeesLogic.Update(employees);
            return Ok("Actualizado con éxito");
        }

        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Id invalido");

            if (!employeesLogic.Delete(id)) return BadRequest("Hubo un problema");

            return Ok("Registro eliminado");
        }

    }
}
