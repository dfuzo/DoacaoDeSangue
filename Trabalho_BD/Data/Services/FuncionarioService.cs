using Trabalho_BD.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Trabalho_BD.Data.Services
{
    public class FuncionarioService
    {
        private readonly MyAppDbContext _context;

        public FuncionarioService(MyAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Funcionario>> GetFuncionariosAsync()
        {
            return await _context.Funcionarios.ToListAsync();
        }

        public async Task<Funcionario?> GetFuncionarioByIdAsync(string id)
        {
            return await _context.Funcionarios.FindAsync(id);
        }

        public async Task AddFuncionarioAsync(Funcionario Funcionario)
        {
            _context.Funcionarios.Add(Funcionario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFuncionarioAsync(Funcionario Funcionario)
        {
            _context.Funcionarios.Update(Funcionario);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFuncionarioAsync(string id)
        {
            var Funcionario = await _context.Funcionarios.FindAsync(id);
            if (Funcionario != null)
            {
                _context.Funcionarios.Remove(Funcionario);
                await _context.SaveChangesAsync();
            }
        }
    }
}
