using AgendaMvc.Data;
using AgendaMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}
