using Trabalho_BD.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Trabalho_BD.Data.Services
{
    public class ColetaService
    {
        private readonly MyAppDbContext _context;

        public ColetaService(MyAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Coleta>> GetColetasAsync()
        {
            return await _context.Coletas.ToListAsync();
        }

        public async Task<Coleta?> GetColetaByIdAsync(int id)
        {
            return await _context.Coletas.FindAsync(id);
        }

        public async Task AddColetaAsync(Coleta coleta)
        {
            _context.Coletas.Add(coleta);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateColetaAsync(Coleta Coleta)
        {
            _context.Coletas.Update(Coleta);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteColetaAsync(int id)
        {
            var Coleta = await _context.Coletas.FindAsync(id);
            if (Coleta != null)
            {
                _context.Coletas.Remove(Coleta);
                await _context.SaveChangesAsync();
            }
        }
    }
}
