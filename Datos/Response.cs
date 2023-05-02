using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APi_Web_1.Datos
{
    public class Response
    {
        public string Status { get; set; }
        public bool Exito { get; set; }
        public string Message { get; set; }
        public dynamic Result { get; set; }

        public Response()
        {
            this.Status = "success";
        }

    }
}