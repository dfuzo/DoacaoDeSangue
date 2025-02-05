using Trabalho_BD.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Trabalho_BD.Data.Services
{
    public class ReceptorService
    {
        private readonly MyAppDbContext _context;

        public ReceptorService(MyAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Receptor>> GetReceptoresAsync()
        {
            return await _context.Receptores.ToListAsync();
        }

        public async Task<Receptor?> GetReceptorByIdAsync(string id)
        {
            return await _context.Receptores.FindAsync(id);
        }

        public async Task AddReceptorAsync(Receptor Receptor)
        {
            _context.Receptores.Add(Receptor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateReceptorAsync(Receptor Receptor)
        {
            _context.Receptores.Update(Receptor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReceptorAsync(string id)
        {
            var Receptor = await _context.Receptores.FindAsync(id);
            if (Receptor != null)
            {
                _context.Receptores.Remove(Receptor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
