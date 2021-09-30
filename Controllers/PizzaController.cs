using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoPizza.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        public PizzaController()
        {

        }

        [HttpGet]
        public ActionResult<List<Pizza>> GetAll()
        {
            return PizzaService.GetAll();
        }
        [HttpGet("{id}")]
        public ActionResult<Pizza> Get(int id)
        {
            var pizza = PizzaService.Get(id);

            if(pizza == null)
            {
                return NotFound();
            }

            return pizza;
        }

        // POST action

        // PUT action

        // DELETE action
    }
}
