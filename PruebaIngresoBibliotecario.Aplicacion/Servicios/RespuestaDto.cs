using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PruebaIngresoBibliotecario.Aplicacion.Servicios
{
    public  class RespuestaDto
    {
     
        public Guid id { get; set; }    

       public DateTime fechaMaximaDevolucion { get; set; }
    }
}
