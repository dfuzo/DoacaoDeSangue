using Trabalho_BD.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Trabalho_BD.Data.Services
{
    public class TransfusaoService
    {
        private readonly MyAppDbContext _context;

        public TransfusaoService(MyAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Transfusao>> GetTransfusoesAsync()
        {
            return await _context.Transfusoes.ToListAsync();
        }

        public async Task<Transfusao?> GetTransfusaoByIdAsync(int id)
        {
            return await _context.Transfusoes.FindAsync(id);
        }

        public async Task AddTransfusaoAsync(Transfusao Transfusao)
        {
            _context.Transfusoes.Add(Transfusao);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTransfusaoAsync(Transfusao Transfusao)
        {
            _context.Transfusoes.Update(Transfusao);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTransfusaoAsync(int id)
        {
            var Transfusao = await _context.Transfusoes.FindAsync(id);
            if (Transfusao != null)
            {
                _context.Transfusoes.Remove(Transfusao);
                await _context.SaveChangesAsync();
            }
        }
    }
}
