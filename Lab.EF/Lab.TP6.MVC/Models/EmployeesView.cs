using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab.TP6.MVC.Models
{
    public class EmployeesView
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string Apellido { get; set; }

        [Required]
        [StringLength(10)]
        public string Nombre { get; set; }
    }
}