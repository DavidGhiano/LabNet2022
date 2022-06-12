using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Net.LINQ.Entities
{
    public class Customers_Orders
    {
        [Key]
        [StringLength(5)]
        public string CustomerID { get; set; }

        [Required]
        [StringLength(40)]
        public string CompanyName { get; set; }

        [StringLength(15)]
        public string Region { get; set; }

        public int OrderID { get; set; }

        public DateTime? OrderDate { get; set; }

        public int? Cantidad { get; set; }
    }
}
