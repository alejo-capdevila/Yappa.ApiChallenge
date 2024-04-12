using System.Collections.Generic;
using System.Threading.Tasks;
using Yappa.Models;

namespace Yappa.Repositories
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetAll();
        Task<Cliente> Get(int id);
        Task<IEnumerable<Cliente>> Search(string searchTerm);
        Task Insert(Cliente cliente);
        Task Update(Cliente cliente);
    }
}