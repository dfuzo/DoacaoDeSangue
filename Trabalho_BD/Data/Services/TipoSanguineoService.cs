using Trabalho_BD.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Trabalho_BD.Data.Services
{
    public class TipoSanguineoService
    {
        private readonly MyAppDbContext _context;

        public TipoSanguineoService(MyAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TipoSanguineo>> GetTipoSanguineosAsync()
        {
            return await _context.TipoSanguineos.ToListAsync();
        }

        public async Task<TipoSanguineo?> GetTipoSanguineoByIdAsync(int id)
        {
            return await _context.TipoSanguineos.FindAsync(id);
        }

        public async Task AddTipoSanguineoAsync(TipoSanguineo TipoSanguineo)
        {
            _context.TipoSanguineos.Add(TipoSanguineo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTipoSanguineoAsync(TipoSanguineo TipoSanguineo)
        {
            _context.TipoSanguineos.Update(TipoSanguineo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTipoSanguineoAsync(int id)
        {
            var TipoSanguineo = await _context.TipoSanguineos.FindAsync(id);
            if (TipoSanguineo != null)
            {
                _context.TipoSanguineos.Remove(TipoSanguineo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
