using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroRabbit.YappaApp.Data.Context;
using Microsoft.EntityFrameworkCore;
using Yappa.Models;

namespace Yappa.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly YappaAppDbContext _context;

        public ClienteRepository(YappaAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente> Get(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task<IEnumerable<Cliente>> Search(string searchTerm)
        {
            return await _context.Clientes
                .Where(c => c.Nombres.Contains(searchTerm) || c.Apellidos.Contains(searchTerm))
                .ToListAsync();
        }

        public async Task Insert(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}