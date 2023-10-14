using PruebaIngresoBibliotecario.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaIngresoBibliotecario.Aplicacion.Interfaces
{
    public interface IServicioBase<TEntidad, TEntidadId>: IConsultar<TEntidad, TEntidadId> , IAgregar<TEntidad, TEntidadId>
    {
    }
}
