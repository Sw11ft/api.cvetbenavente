using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web.cvetbenavente.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace api.cvetbenavente.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Eventos")]
    public class EventosController : Controller
    {
        private readonly ApplicationDbContext db;
        public EventosController(ApplicationDbContext context)
        {
            db = context;
        }

        // GET api/
        [HttpGet]
        public IActionResult GetSms(DateTime? from = null, DateTime? to = null)
        {
            from = from ?? DateTime.UtcNow;

            var eventos = db.Eventos.Include(x => x.Cliente).Include(x => x.Animal).Where(x => x.Data != null).AsQueryable();

            if (from != null)

            {
                eventos = eventos.Where(x => x.Data > from);
            }

            if (to != null)
            {
                eventos = eventos.Where(x => x.Data < to);
            }


            List<object> lista = new List<object>();

            foreach (var item in eventos.Select(x => new { modelo = x.Modelo,
                                                           desc = x.Desc,
                                                           data = x.Data,
                                                           cl = x.Cliente.Nome,
                                                           nr = x.Cliente.Contacto,
                                                           animal = x.Animal.Nome,
                                                           animalGenero = x.Animal.Genero,
                                                           esp = x.Animal.Especie.Nome,
                                                           espF = x.Animal.Especie.NomeF }).ToList())
            {
                string msg = "";

                switch (item.modelo)
                {
                    case web.cvetbenavente.Models.Enums.Modelos.Lembrete:
                        msg = "Caro(a) " + item.cl + " não se esqueça de efetuar a marcação de " + item.desc
                            + ((item.animalGenero == web.cvetbenavente.Models.Enums.Genero.M || string.IsNullOrWhiteSpace(item.espF))
                            ? " do seu " + item.esp.ToLower() : " da sua " + item.espF.ToLower()) + " " + item.animal + " dentro de " + Math.Ceiling(((DateTime)item.data - DateTime.UtcNow).TotalDays)
                            + " dias. CVETBENAVENTE";
                        break;
                    case web.cvetbenavente.Models.Enums.Modelos.MarcacaoEfetuada:
                        msg = "Caro(a) " + item.cl + " não se esqueça que tem " + item.desc
                            + ((item.animalGenero == web.cvetbenavente.Models.Enums.Genero.M || string.IsNullOrWhiteSpace(item.espF))
                            ? " do seu " + item.esp.ToLower() : " da sua " + item.espF.ToLower()) + " " + item.animal + " agendada para o dia "
                            + ((DateTime)item.data).ToString("dd-MM-yyyy") /* + pelas item.hora*/ + ". CVETBENAVENTE";
                        break;
                    default:
                        break;
                }

                lista.Add(new { nr = item.nr, msg = msg });
            }

            return Json(lista);
        }
    }
}