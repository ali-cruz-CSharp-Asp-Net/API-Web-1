using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APi_Web_1.Datos
{
    public class Parametro
    {
        public string Nombre { get; set; }
        public object Valor { get; set; }
        public bool Salida { get; set; }

        public Parametro(string nombre, object valor)
        {
            this.Nombre = nombre;
            this.Valor = valor;
            this.Salida = false;
        }

        public Parametro(string nombre)
        {
            this.Nombre = nombre;
            this.Salida = true;
        }
    }
}