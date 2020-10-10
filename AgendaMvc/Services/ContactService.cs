using AgendaMvc.Data;
using AgendaMvc.Models;
using AgendaMvc.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AgendaMvc.Services
{
    public class ContactService
    {
        private readonly AgendaMvcContext _context;

        public ContactService(AgendaMvcContext context)
        {
            _context = context;
        }

        public List<Contatos> FindAll()
        {
            return _context.Contatos.ToList();
        }

        public void Insert(Contatos obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Contatos FindById(int id)
        {
            return _context.Contatos.Include(obj => obj.TipoContato).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Contatos.Find(id);
            _context.Contatos.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Contatos obj)
        {
            if(!_context.Contatos.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }      

    }
}
