using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace Lab.TP6.MVC.Models
{
    public class Pokemon
    {
        public double height { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string imagen { get; set; }
        public List<string> types { get; set; }
        public double weight { get; set; }
        public int hp { get; set; }
        public int attack { get; set; }
        public int defense { get; set; }
        public int specialAttack { get; set; }
        public int specialDefense { get; set; }
        public int speed { get; set; }

    }
}