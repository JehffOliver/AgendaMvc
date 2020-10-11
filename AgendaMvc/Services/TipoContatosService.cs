using AgendaMvc.Data;
using AgendaMvc.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaMvc.Services
{
    public class TipoContatosService
    {
        private readonly AgendaMvcContext _service;

        public TipoContatosService(AgendaMvcContext service)
        {
            _service = service;
        }

        public async Task<List<TipoContato>> FindAllAsync()
        {
            return await _service.TipoContato.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
