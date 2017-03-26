using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using api.cvetbenavente.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.cvetbenavente.Controllers
{
    [Route("api/animais")]
    public class AnimaisController : Controller
    {

        private readonly Context db;

        public AnimaisController(Context context)
        {
            db = context;
        }

        // GET: api/values
        [HttpGet]
        public string Get()
        {
            var json = JsonConvert.SerializeObject(db.Animais.ToList());

            return json;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
