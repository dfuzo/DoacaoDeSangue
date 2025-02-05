using Trabalho_BD.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Trabalho_BD.Data.Services
{
    public class HemocentroService
    {
        private readonly MyAppDbContext _context;

        public HemocentroService(MyAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Hemocentro>> GetHemocentrosAsync()
        {
            return await _context.Hemocentros.ToListAsync();
        }

        public async Task<Hemocentro?> GetHemocentroByIdAsync(string id)
        {
            return await _context.Hemocentros.FindAsync(id);
        }

        public async Task AddHemocentroAsync(Hemocentro Hemocentro)
        {
            _context.Hemocentros.Add(Hemocentro);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateHemocentroAsync(Hemocentro Hemocentro)
        {
            _context.Hemocentros.Update(Hemocentro);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteHemocentroAsync(string id)
        {
            var Hemocentro = await _context.Hemocentros.FindAsync(id);
            if (Hemocentro != null)
            {
                _context.Hemocentros.Remove(Hemocentro);
                await _context.SaveChangesAsync();
            }
        }
    }
}
