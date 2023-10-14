using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Dominio.Interfaces
{
    public interface IAgregar<TEntidad, TEntidadId>
    {
        Task<TEntidad> Agregar(TEntidad tentidad);
    }
}
