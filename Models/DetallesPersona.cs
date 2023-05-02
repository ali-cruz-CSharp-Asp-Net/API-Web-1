using APi_Web_1.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APi_Web_1.Models
{
    public class DetallesPersona
    {
        public int Id { get; set; }
        public string TituloProfesional { get; set; }
        public string URIFotoPerfil { get; set; }
        public double Salario { get; set; }
        public int IdPersona { get; set; }

        public static Response AddPersonDetails(DetallesPersona detallesPersona)
        {
            List<Parametro> parametros = new List<Parametro>
            {
                new Parametro("@TituloProfesional", detallesPersona.TituloProfesional),
                new Parametro("@URIFoto", detallesPersona.URIFotoPerfil),
                new Parametro("@Salario", detallesPersona.Salario),
                new Parametro("@IdPersona", detallesPersona.IdPersona)
            };

            return DBDatos.Ejecutar("uspAddPersonDetail", parametros);

        }


    }
}