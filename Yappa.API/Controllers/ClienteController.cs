using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yappa.Models;
using Yappa.Services;

namespace Yappa.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetAllClientes()
        {
            try
            {
                var clientes = await _clienteService.GetAllClientes();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            try
            {
                var cliente = await _clienteService.GetCliente(id);
                if (cliente == null)
                {
                    return NotFound();
                }
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddCliente([FromBody] Cliente cliente)
        {
            try
            {
                if (cliente == null)
                {
                    return BadRequest("Cliente object is null");
                }

                await _clienteService.AddCliente(cliente);

                return CreatedAtAction(nameof(GetCliente), new { id = cliente.ID }, cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCliente([FromBody] Cliente cliente)
        {
            try
            {
                if (cliente == null)
                {
                    return BadRequest("Invalid cliente object");
                }

                // Verificar si el cliente existe
                var clienteToUpdate = await _clienteService.GetCliente(cliente.ID);
                if (clienteToUpdate == null)
                {
                    return NotFound();
                }

                // Actualizar el cliente utilizando el servicio
                clienteToUpdate.Nombres = cliente.Nombres;
                clienteToUpdate.Apellidos = cliente.Apellidos;
                clienteToUpdate.FechaNacimiento = cliente.FechaNacimiento;
                clienteToUpdate.CUIT = cliente.CUIT;
                clienteToUpdate.Domicilio = cliente.Domicilio;
                clienteToUpdate.TelefonoCelular = cliente.TelefonoCelular;
                clienteToUpdate.Email = cliente.Email;

                // Llamar al método UpdateCliente del servicio
                await _clienteService.UpdateCliente(clienteToUpdate);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
    }