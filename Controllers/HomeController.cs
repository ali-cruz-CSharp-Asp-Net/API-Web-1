using APi_Web_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace APi_Web_1.Controllers
{
    public class HomeController : ApiController
    {
        [Route("api/GenerarResponse")]
        [HttpGet]
        public dynamic Listar()
        {
            return "Mensaje retornado desde API";
        }

        [Route("api/Persona/Crear")]
        [HttpPost]
        public dynamic Crear(Persona persona)
        {
            return Persona.AddPerson(persona);
        }

        [Route("api/Persona/Listar")]
        [HttpGet]
        public dynamic GetPersonByName(string name)
        {
            return Persona.GetPersonByName(name);
        }


    }
}