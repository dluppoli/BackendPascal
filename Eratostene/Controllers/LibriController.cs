using Eratostene.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Eratostene.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibriController : ControllerBase
    {
        private static List<Libro> libri = new List<Libro> {
            new Libro() { Id = 1, Titolo = "I promessi sposi",Autore = "Alessandro Manzoni", Prezzo = 20, Copertina = "promessisposi.jpg"},
            new Libro() { Id = 2, Titolo = "La divina commedia", Autore = "Dante Alighieri", Prezzo = 12, Copertina = "divinacommedia.jpg" },
            new Libro() { Id = 3, Titolo = "La concessione del telefono", Autore = "Andrea Camilleri", Prezzo=11, Copertina=""}
         };

        [HttpGet()]
        public ActionResult<Libro[]> Get()
        {
            return libri.ToArray();
        }


        [HttpGet("random")]
        public ActionResult<Libro> GetRandom()
        {
            return libri[0];
        }

        [HttpGet("find/{stringaRicerca}")]
        public ActionResult<Libro[]> Find(string stringaRicerca)
        {
            return libri.FindAll(l => l.Titolo.Contains(stringaRicerca) || l.Autore.Contains(stringaRicerca)).ToArray();
        }

        [HttpGet("{id}")]
        public ActionResult<Libro> GetOne(int id)
        {
            var result = libri.Find(l => l.Id == id);
            if (result == null) return Ok(null);
            return result;
        }

        [HttpPost()]
        public ActionResult Add([FromBody]Libro l)
        {
            libri.Add(l);
            return Ok();
        }



    }
}
