using Lab.TP7.Entities;
using Lab.TP7.Logic;
using Lab.TP6.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab.TP6.MVC.Controllers
{
    public class EmployeesController : Controller
    {
        EmployeesLogic employeesLogic = new EmployeesLogic();
        // GET: Employees
        public ActionResult Listar()
        {
            List<Employees> employeesList = employeesLogic.GetAll();

            List<EmployeesView> employeesView = employeesList.Select(
                                                                e => new EmployeesView { 
                                                                                         ID = e.EmployeeID,
                                                                                         Apellido = e.LastName,
                                                                                         Nombre = e.FirstName
                                                                                       }).ToList();
            return View(employeesView);
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(EmployeesView employees)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                var employeesEntity = new Employees
                {
                    FirstName = employees.Nombre,
                    LastName = employees.Apellido
                };
                employeesLogic.Add(employeesEntity);

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
                employeesLogic.Delete(id);
                return RedirectToAction("Listar");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult Edit(int id)
        {
            Employees employees = employeesLogic.GetOne(id);
            EmployeesView employeesView = new EmployeesView
            {
                ID = employees.EmployeeID,
                Nombre = employees.FirstName,
                Apellido = employees.LastName
            };
            return View(employeesView);
        }
        [HttpPost]
        public ActionResult Edit(EmployeesView employeesView)
        {
            if (!ModelState.IsValid) return View();
            try
            {
                var employeesEntity = new Employees
                {
                    EmployeeID = employeesView.ID,
                    FirstName = employeesView.Nombre,
                    LastName = employeesView.Apellido
                };
                employeesLogic.Update(employeesEntity);
                return RedirectToAction("Listar");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }
    }
}