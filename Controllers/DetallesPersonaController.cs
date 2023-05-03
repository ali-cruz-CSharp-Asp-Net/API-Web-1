using APi_Web_1.Datos;
using APi_Web_1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace APi_Web_1.Controllers
{
    public class DetallesPersonaController : ApiController
    {
        [Route("api/DetailsPerson/Add")]
        [HttpPost]
        public dynamic AddPersonDetails(DetallesPersona detallesPersona, HttpRequestMessage request)
        {
            Response response = new Response();

            int idPersona = ValidarToken(request);

            if (idPersona == 0)
            {
                response.Exito = false;
                response.Message = "Token incorrecto";
                return response;
            }

            detallesPersona.IdPersona = idPersona;
            return DetallesPersona.AddPersonDetails(detallesPersona);
        }
        

        public int ValidarToken(HttpRequestMessage request)
        {
            string token = string.Empty;

            foreach (var item in request.Headers)
            {
                //if (request.Headers.Contains("Authorization"))
                if (item.Key.Equals("Authorization"))
                {
                    token = item.Value.First();
                    break;
                }
            }

            DataTable dt = Persona.GetPersonByToken(token).Result;

            if (dt.Rows.Count > 0)
            {
                if (int.TryParse(dt.Rows[0]["id"].ToString(), out int num))
                {
                    return Convert.ToInt32(dt.Rows[0]["id"]);
                }
            }

            return 0;
        }



    }
}