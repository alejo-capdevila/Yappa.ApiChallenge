using System.Collections.Generic;
using System.Threading.Tasks;
using Yappa.Models;
using Yappa.Repositories;

namespace Yappa.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<Cliente>> GetAllClientes()
        {
            return await _clienteRepository.GetAll();
        }

        public async Task<Cliente> GetCliente(int id)
        {
            return await _clienteRepository.Get(id);
        }

        public async Task<IEnumerable<Cliente>> SearchClientes(string searchTerm)
        {
            return await _clienteRepository.Search(searchTerm);
        }

        public async Task AddCliente(Cliente cliente)
        {
            await _clienteRepository.Insert(cliente);
        }

        public async Task UpdateCliente(Cliente cliente)
        {
            await _clienteRepository.Update(cliente);
        }
    }
}