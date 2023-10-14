using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PruebaIngresoBibliotecario.Dominio
{
    public class solicitudPrestamo
    {
        [Required]
        [Key]
        public Guid id { get; set; }

        [Required]
        public Guid isbn { get; set; }

        [Required]
        [MaxLength(10)]
        public string identificacionUsuario { get; set; }


        [Required]
        public int tipoUsuario { get; set; }


        public DateTime fechaMaximaDevolucion { get; set; }
    }
}
