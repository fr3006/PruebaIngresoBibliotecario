using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaIngresoBibliotecario.Aplicacion.Util.Validaciones
{
    public class ValidacionUsuario : IValidaciones
    {

        private DateTime fechaFinal =  DateTime.Now;   
        
        public DateTime Validacion(int diasEntregaLibro)
        {            
            for (int i = 0; i < diasEntregaLibro; i++)
            {
                fechaFinal = fechaFinal.AddDays(1);
                if (fechaFinal.DayOfWeek == DayOfWeek.Saturday || fechaFinal.DayOfWeek == DayOfWeek.Sunday)
                {

                    i -= 1;
                }
               
            }
         
            return fechaFinal;
        }
    }
}
