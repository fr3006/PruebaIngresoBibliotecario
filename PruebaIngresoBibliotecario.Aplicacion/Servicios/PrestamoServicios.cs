using PruebaIngresoBibliotecario.Aplicacion.Interfaces;
using PruebaIngresoBibliotecario.Dominio.Interfaces.Repositorios;
using PruebaIngresoBibliotecario.Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using PruebaIngresoBibliotecario.Dominio.Interfaces;
using System.Threading.Tasks;
using PruebaIngresoBibliotecario.Aplicacion.Util.Enum;
using Microsoft.Extensions.Configuration;
using PruebaIngresoBibliotecario.Aplicacion.Util.Validaciones;

namespace PruebaIngresoBibliotecario.Aplicacion.Servicios
{
    public class PrestamoServicios : IServicioPrestamo<solicitudPrestamo, Guid>
    {
        
        private DateTime fechaEntrega = new DateTime();       
        private readonly IRepositorioBase<solicitudPrestamo, Guid> repositorioBase;
        private readonly ValidacionUsuario validaciones;
       



        public PrestamoServicios(IRepositorioBase<solicitudPrestamo ,Guid> _repositorioBase) 
        {
            this.repositorioBase = _repositorioBase;
            validaciones = new ValidacionUsuario();
         
    }

        public async Task<solicitudPrestamo> Agregar(solicitudPrestamo tentidad)
        {
            if (tentidad is null)
                 throw new ArgumentException();

           var prestamoUsuario =  await this.repositorioBase.ConsultarPresatamoPorId(tentidad.id);
              
            if(prestamoUsuario is  null)
               {
                  switch (tentidad.tipoUsuario)
                  {
                    case (int)TipoUsuario.INVITADO:
                        {
                            tentidad.fechaMaximaDevolucion = this.validaciones.Validacion((int)EntregaUsuario.INVITADO);
                        }
                        break;
                    case (int)TipoUsuario.EMPLEADO:
                        {
                            tentidad.fechaMaximaDevolucion = this.validaciones.Validacion((int)EntregaUsuario.EMPLEADO);
                        }
                        break;
                    case (int)TipoUsuario.AFILIADO:
                        {
                            tentidad.fechaMaximaDevolucion = this.validaciones.Validacion((int)EntregaUsuario.AFILIADO);
                        }
                        break;
                    default:
                        throw new ArgumentException($"no existe el tipo de usuario {tentidad.tipoUsuario} ");

                  }
                   return await this.repositorioBase.Agregar(tentidad);
                  
                
              
               

                
            }
                           
            return  prestamoUsuario;
           
        }

        public async Task<solicitudPrestamo> ConsultarPresatamoPorId(Guid entidadId)
        {
            return  await this.repositorioBase.ConsultarPresatamoPorId(entidadId);
            
        }

       
    }
}
