using AgendaMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaMvc.Data
{
    public class SeedingService
    {
        private AgendaMvcContext _context;

        public SeedingService(AgendaMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.TipoContato.Any() || _context.Contatos.Any())
            {
                return; // testando se existe alguma informação nas tabelas do banco.
            }

            TipoContato tipo1 = new TipoContato(1, "Casa");
            TipoContato tipo2 = new TipoContato(2, "Familia");
            TipoContato tipo3 = new TipoContato(3, "Trabalho");

            Contatos c1 = new Contatos(1, "Maria brown", "maria@gmail.com", new DateTime(1995,05,02), "(11)-983662125", tipo1);
            Contatos c2 = new Contatos(2, "Bob Grey", "bob@gmail.com", new DateTime(1998,05,02), "(11)-983662315", tipo2);
            Contatos c3 = new Contatos(3, "Marcelo Green", "marcelo@gmail.com", new DateTime(1994,05,02), "(11)-983623425", tipo3);
            Contatos c4 = new Contatos(4, "Fernando Pink", "fernando@gmail.com", new DateTime(1993,05,02), "(11)-983665225", tipo1);
            Contatos c5 = new Contatos(5, "Chris Blue", "chris@gmail.com", new DateTime(1999,05,02), "(11)-983687625", tipo2);
            Contatos c6 = new Contatos(6, "Jefferson Oliveira", "jeff@gmail.com", new DateTime(1995,01,12), "(11)-983662125", tipo3);

            _context.TipoContato.AddRange(tipo1, tipo2, tipo3);
            _context.Contatos.AddRange(c1, c2, c3, c4, c5, c6);

            _context.SaveChanges();

        }
    }
}
