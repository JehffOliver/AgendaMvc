using System.Collections.Generic;

namespace AgendaMvc.Models
{
    public class TipoContato
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Contatos> Contato{ get; set; } = new List<Contatos>();

        public TipoContato()
        {
        }

        public TipoContato(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void addContato(Contatos contatos)
        {
            Contato.Add(contatos);
        }
    }
}
