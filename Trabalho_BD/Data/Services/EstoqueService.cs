using Trabalho_BD.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Trabalho_BD.Data.Services
{
    public class EstoqueService
    {
        private readonly MyAppDbContext _context;

        public EstoqueService(MyAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Estoque>> GetEstoquesAsync()
        {
            return await _context.Estoques.ToListAsync();
        }

        public async Task<Estoque?> GetEstoqueByIdAsync(int id)
        {
            return await _context.Estoques.FindAsync(id);
        }

        public async Task AddEstoqueAsync(Estoque Estoque)
        {
            _context.Estoques.Add(Estoque);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEstoqueAsync(Estoque Estoque)
        {
            _context.Estoques.Update(Estoque);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEstoqueAsync(int id)
        {
            var Estoque = await _context.Estoques.FindAsync(id);
            if (Estoque != null)
            {
                _context.Estoques.Remove(Estoque);
                await _context.SaveChangesAsync();
            }
        }
    }
}
