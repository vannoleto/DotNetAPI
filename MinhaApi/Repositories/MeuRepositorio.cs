using MinhaApi.Models;
using MinhaApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaApi.Repositories
{
    public class MeuRepositorio : IMeuRepositorio
    {
        private readonly DbContext _context;

        public MeuRepositorio(DbContext context)
        {
            _context = context;
        }

        public async Task Adicionar(MeuModelo modelo)
        {
            await _context.Set<MeuModelo>().AddAsync(modelo);
            await _context.SaveChangesAsync();
        }

        public async Task<MeuModelo> BuscarPorId(int id)
        {
            return await _context.Set<MeuModelo>().FindAsync(id);
        }

        public async Task Atualizar(MeuModelo modelo)
        {
            _context.Set<MeuModelo>().Update(modelo);
            await _context.SaveChangesAsync();
        }

        public async Task Remover(int id)
        {
            var modelo = await BuscarPorId(id);
            if (modelo != null)
            {
                _context.Set<MeuModelo>().Remove(modelo);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<MeuModelo>> ObterTodos()
        {
            return await _context.Set<MeuModelo>().ToListAsync();
        }
    }
}