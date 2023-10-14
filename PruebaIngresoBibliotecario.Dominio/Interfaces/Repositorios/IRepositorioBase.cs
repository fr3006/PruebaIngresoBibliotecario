using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaIngresoBibliotecario.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioBase<TEntidad, TEntidadId> : IConsultar<TEntidad,TEntidadId> , IAgregar<TEntidad, TEntidadId>
    {
    }
}
