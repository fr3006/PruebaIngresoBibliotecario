using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Dominio.Interfaces
{
    public interface IConsultar<TEntidad, TEntidadId>
    {
       Task<TEntidad> ConsultarPresatamoPorId(TEntidadId entidadId);
    }
}
