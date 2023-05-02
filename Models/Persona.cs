using APi_Web_1.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APi_Web_1.Models
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Sexo { get; set; }
        public string Pais { get; set; }
        public DateTime FechaAlta { get; set; }

        public static Response AddPerson(Persona persona)
        {
            List<Parametro> parametros = new List<Parametro>
            {
                new Parametro("@Nombre", persona.Nombre),
                new Parametro("@Sexo", persona.Sexo),
                new Parametro("@Pais", persona.Pais)
            };

            return DBDatos.Ejecutar("uspAltaPersona", parametros);
        }

        public static Response GetPersonByName(string name)
        {
            List<Parametro> parametrosList = new List<Parametro>
            {
                new Parametro("@Name", name)
            };

            return DBDatos.ListarPersona("uspGetPersonByName", parametrosList);
        }

        public static Response GetPersonByToken(string token)
        {
            List<Parametro> parametros = new List<Parametro>
            {
                new Parametro("@Token", token)
            };

            return DBDatos.ListarPersona("uspGetPersonByToken", parametros);
        }


    }


}