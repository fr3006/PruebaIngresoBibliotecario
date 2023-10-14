using PruebaIngresoBibliotecario.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
//using PruebaIngresoBibliotecario.Dominio.Interfaces;

namespace PruebaIngresoBibliotecario.Aplicacion.Interfaces
{
    public interface IServicios<TEntidad, TEntidadId> : IConsultar<TEntidad, TEntidadId>, IAgregar<TEntidad>
    {

    }
}
