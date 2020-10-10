using AgendaMvc.Data;
using AgendaMvc.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AgendaMvc.Services
{
    public class TipoContatosService
    {
        private readonly AgendaMvcContext _service;

        public TipoContatosService(AgendaMvcContext service)
        {
            _service = service;
        }

        public List<TipoContato> FindAll()
        {
            return _service.TipoContato.OrderBy(x => x.Name).ToList();
        }
    }
}
