using AgendaMvc.Data;
using AgendaMvc.Models;
using AgendaMvc.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaMvc.Services
{
    public class ContactService
    {
        private readonly AgendaMvcContext _context;

        public ContactService(AgendaMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Contatos>> FindAllAsync()
        {
            return await _context.Contatos.ToListAsync();
        }

        public async Task InsertAsync(Contatos obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Contatos> FindByIdAsync(int id)
        {
            return await _context.Contatos.Include(obj => obj.TipoContato).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task Remove(int id)
        {
            var obj = await _context.Contatos.FindAsync(id);
            _context.Contatos.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Contatos contatos)
        {
            if (!await  _context.Contatos.AnyAsync(x => x.Id == contatos.Id))
            {
                throw new NotFoundException("Id not found");
            }

            try {
                _context.Update(contatos);
            await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

    }
}
