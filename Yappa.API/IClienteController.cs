using Microsoft.AspNetCore.Mvc;
using Yappa.Models;

namespace Yappa.API.Controllers
{
    public interface IClienteController
    {
        Task<ActionResult<IEnumerable<Cliente>>> GetAllClientes();
        Task<ActionResult<Cliente>> GetCliente(int id);
        Task<ActionResult> AddCliente([FromBody] Cliente cliente);
        Task<ActionResult> UpdateCliente(int id, [FromBody] Cliente cliente);
    }
}