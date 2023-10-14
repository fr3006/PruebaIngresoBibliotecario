using Microsoft.EntityFrameworkCore;
using PruebaIngresoBibliotecario.Datos.Contexto;
using PruebaIngresoBibliotecario.Dominio;
using PruebaIngresoBibliotecario.Dominio.Interfaces.Repositorios;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Datos
{
    public class PrestamoRepositorio : IRepositorioBase<solicitudPrestamo, Guid>
    {
        private readonly PersistenceCotext _persistenceCotext;

        public PrestamoRepositorio(PersistenceCotext persistenceCotext)
        {
            this._persistenceCotext= persistenceCotext;
        }

        public async Task<solicitudPrestamo> Agregar(solicitudPrestamo tentidad)
        {
              await _persistenceCotext.Prestamos.AddAsync(tentidad);
              await _persistenceCotext.SaveChangesAsync();
            return tentidad;
        }

        public async Task<solicitudPrestamo> ConsultarPresatamoPorId(Guid entidadId)
        {

            return await _persistenceCotext.Prestamos.Where(a => a.id == entidadId).FirstOrDefaultAsync();
        }
    }
}
