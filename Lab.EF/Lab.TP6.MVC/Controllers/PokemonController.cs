using Lab.TP6.MVC.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Lab.TP6.MVC.Controllers
{
    public class PokemonController : Controller
    {
        // GET: Pokemon
        public ActionResult Index()
        {
            Random random = new Random();
            int id = random.Next(1, 387);
            Pokemon pokemon = null;
            JObject json = null;
            List<string> types = new List<string>() ;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://pokeapi.co/api/v2/");

                var responseTask = client.GetAsync($"pokemon/{id}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();
                    json = JObject.Parse(readTask.Result);
                    foreach(var item in json["types"].ToArray())
                    {
                        types.Add(item["type"]["name"].ToString());
                    }
                    pokemon = new Pokemon
                    {
                        id = Convert.ToInt32(json["id"]),
                        name = json["name"].ToString(),
                        height = Convert.ToDouble(json["height"]) / 10.0d,
                        weight = Convert.ToDouble(json["weight"]) / 10.0d,
                        imagen = json["sprites"]["other"]["dream_world"]["front_default"].ToString(),
                        types = types,
                        hp = Convert.ToInt32(json["stats"][0]["base_stat"]),
                        attack = Convert.ToInt32(json["stats"][1]["base_stat"]),
                        defense = Convert.ToInt32(json["stats"][2]["base_stat"]),
                        specialAttack = Convert.ToInt32(json["stats"][3]["base_stat"]),
                        specialDefense = Convert.ToInt32(json["stats"][4]["base_stat"]),
                        speed = Convert.ToInt32(json["stats"][5]["base_stat"])
                    };

                }
            }



            return View(pokemon);
        }
    }
}