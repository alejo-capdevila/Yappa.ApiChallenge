using System.Collections.Generic;
using System.Threading.Tasks;
using Yappa.Models;

namespace Yappa.Services
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> GetAllClientes();
        Task<Cliente> GetCliente(int id);
        Task<IEnumerable<Cliente>> SearchClientes(string searchTerm);
        Task AddCliente(Cliente cliente);
        Task UpdateCliente(Cliente cliente);
    }
}