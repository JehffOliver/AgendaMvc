using AgendaMvc.Data;
using AgendaMvc.Models;
using System;
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

        public List<Contatos> FindAll()
        {
            return _context.Contatos.ToList();
        }

        public void Insert(Contatos obj)
        {
            obj.TipoContato = _context.TipoContato.First();
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
