using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PruebaIngresoBibliotecario.Dominio
{
    public  class Usuarios
    {
        [MaxLength(10)]
        public string IdUsuarioPrestamoLibro { get; set; }                  

        public string TipoUsuarioServicioBibliteca { get; set; }        
                

    }
}
