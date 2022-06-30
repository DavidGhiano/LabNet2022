using Lab.TP8.Api.Models.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab.TP8.Api.Models
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