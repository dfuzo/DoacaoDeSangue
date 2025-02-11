using Trabalho_BD.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Trabalho_BD.Data.Services
{
    public class DoadorHistoricoService
    {
        private readonly MyAppDbContext _context;

        public DoadorHistoricoService(MyAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<DoadorHistorico>> GetHistoricoDoadoresAsync()
        {
            return await _context.DoadoresHistorico.AsNoTracking().ToListAsync();
        }
    }
}
