using Trabalho_BD.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Trabalho_BD.Data.Services
{
    public class DoadorService
    {
        private readonly MyAppDbContext _context;

        public DoadorService(MyAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Doador>> GetDoadoresAsync()
        {
            return await _context.Doadores.ToListAsync();
        }

        public async Task<Doador?> GetDoadorByIdAsync(string id)
        {
            return await _context.Doadores.FindAsync(id);
        }

        public async Task AddDoadorAsync(Doador Doador)
        {
            _context.Doadores.Add(Doador);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDoadorAsync(Doador Doador)
        {
            _context.Doadores.Update(Doador);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDoadorAsync(string id)
        {
            var Doador = await _context.Doadores.FindAsync(id);
            if (Doador != null)
            {
                _context.Doadores.Remove(Doador);
                await _context.SaveChangesAsync();
            }
        }
    }
}
