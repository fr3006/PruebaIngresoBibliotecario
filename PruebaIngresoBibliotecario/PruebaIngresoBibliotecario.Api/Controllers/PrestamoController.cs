using Microsoft.AspNetCore.Mvc;
using PruebaIngresoBibliotecario.Dominio;
using PruebaIngresoBibliotecario.Datos.Contexto;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using PruebaIngresoBibliotecario.Aplicacion.Servicios;
using PruebaIngresoBibliotecario.Datos;
using System.Threading.Tasks;
using PruebaIngresoBibliotecario.Aplicacion.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace PruebaIngresoBibliotecario.Api.Controllers
{
    [Route("api/prestamo")]
    [ApiController]
    public class PrestamoController : ControllerBase
    {
        
        private readonly PersistenceCotext Context;
        private readonly  PrestamoServicios _servicioPrestamo;
        

        public PrestamoController(PersistenceCotext Context)
        {
           
            this.Context = Context;
            PrestamoRepositorio _repo = new PrestamoRepositorio(this.Context);
            PrestamoServicios servicioPrestamo = new PrestamoServicios(_repo);
            _servicioPrestamo = servicioPrestamo;

        }
               
        [HttpPost]       
        public async Task<ActionResult> Prestamo([FromBody] solicitudPrestamo prestamos)
        {
            var result = await _servicioPrestamo.Agregar(prestamos);
            var respuestaDto = new RespuestaDto { fechaMaximaDevolucion =   Convert.ToDateTime(result.fechaMaximaDevolucion), id = result.id };
            
            if (respuestaDto is null)
                return NotFound($"El usuario con identificacion { prestamos.id } ya tiene un libro prestado por lo cual no se le puede realizar otro prestamo");

            return Ok(JsonConvert.SerializeObject(respuestaDto)); 

        }

        [Route("{prestamoId}")]
        [HttpGet]
        public async Task<ActionResult> ConsultaPrestamo(Guid prestamoId)
        {
           var  result = await _servicioPrestamo.ConsultarPresatamoPorId(prestamoId);

            if (result is null)             
                return NotFound($"El prestamo con id {prestamoId} no existe");


            return Ok(JsonConvert.SerializeObject(result));
            
        }
    }
}
