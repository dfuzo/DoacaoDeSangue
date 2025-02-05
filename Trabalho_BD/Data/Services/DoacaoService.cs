using Trabalho_BD.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Trabalho_BD.Data.Services
{
    public class DoacaoService
    {
        private readonly MyAppDbContext _context;

        public DoacaoService(MyAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Doacao>> GetDoacaosAsync()
        {
            return await _context.Doacoes.ToListAsync();
        }

        public async Task<Doacao?> GetDoacaoByIdAsync(int id)
        {
            return await _context.Doacoes.FindAsync(id);
        }

        public async Task AddDoacaoAsync(Doacao Doacao)
        {
            _context.Doacoes.Add(Doacao);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDoacaoAsync(Doacao Doacao)
        {
            _context.Doacoes.Update(Doacao);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDoacaoAsync(int id)
        {
            var Doacao = await _context.Doacoes.FindAsync(id);
            if (Doacao != null)
            {
                _context.Doacoes.Remove(Doacao);
                await _context.SaveChangesAsync();
            }
        }
    }
}
