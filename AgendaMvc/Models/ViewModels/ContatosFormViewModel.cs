using System.Collections.Generic;

namespace AgendaMvc.Models.ViewModels
{
    public class ContatosFormViewModel
    {
        public Contatos Contato { get; set; }
        public ICollection<TipoContato> TipoContatos { get; set; }
    }
}
