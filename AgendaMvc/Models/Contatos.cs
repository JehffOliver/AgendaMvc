using System;

namespace AgendaMvc.Models
{
    public class Contatos
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Tel { get; set; }
        public TipoContato TipoContato { get; set; }
        public int TipoContatoId { get; set; }

        public Contatos()
        {
        }

        public Contatos(int id, string name, string email, DateTime birthdate, string tel, TipoContato tipoContato)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthdate;
            Tel = tel;
            TipoContato = tipoContato;
        }
    }
}
