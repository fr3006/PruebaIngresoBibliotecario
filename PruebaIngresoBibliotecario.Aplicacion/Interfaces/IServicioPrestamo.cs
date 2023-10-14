using PruebaIngresoBibliotecario.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaIngresoBibliotecario.Aplicacion.Interfaces
{
    public interface IServicioPrestamo<Tentidad, TEntidadId> : IAgregar<Tentidad, TEntidadId> , IConsultar<Tentidad, TEntidadId>
    {
    }
}
