using Trabalho_BD.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Trabalho_BD.Data.Services
{
    public class EnderecoService
    {
        private readonly MyAppDbContext _context;

        public EnderecoService(MyAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Endereco>> GetEnderecosAsync()
        {
            return await _context.Enderecos.ToListAsync();
        }

        public async Task<Endereco?> GetEnderecoByIdAsync(int id)
        {
            return await _context.Enderecos.FindAsync(id);
        }

        public async Task AddEnderecoAsync(Endereco Endereco)
        {
            _context.Enderecos.Add(Endereco);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEnderecoAsync(Endereco Endereco)
        {
            _context.Enderecos.Update(Endereco);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEnderecoAsync(int id)
        {
            var Endereco = await _context.Enderecos.FindAsync(id);
            if (Endereco != null)
            {
                _context.Enderecos.Remove(Endereco);
                await _context.SaveChangesAsync();
            }
        }
    }
}
