using Trabalho_BD.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;


namespace Trabalho_BD.Data.Services
{
    public class FuncionarioService
    {
        private readonly MyAppDbContext _context;

        public FuncionarioService(MyAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Funcionario>> GetFuncionariosAsync(string? hemocentroId = null, string? cargo = null)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@HemocentroID", hemocentroId ?? (object)DBNull.Value),
                new SqlParameter("@Cargo", cargo ?? (object)DBNull.Value)
            };

            return await _context.Funcionarios
                .FromSqlRaw("EXEC sp_ListarFuncionarios @HemocentroID, @Cargo", parametros.ToArray())
                .ToListAsync();
        }

        public async Task<Funcionario?> GetFuncionarioByIdAsync(string id)
        {
            return await _context.Funcionarios.FindAsync(id);
        }

        public async Task AddFuncionarioAsync(Funcionario funcionario)
        {
            _context.Funcionarios.Add(funcionario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFuncionarioAsync(Funcionario funcionario)
        {
            _context.Funcionarios.Update(funcionario);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFuncionarioAsync(string id)
        {
            var funcionario = await _context.Funcionarios.FindAsync(id);
            if (funcionario != null)
            {
                _context.Funcionarios.Remove(funcionario);
                await _context.SaveChangesAsync();
            }
        }
    }
}
