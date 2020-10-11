using System;
using System.ComponentModel.DataAnnotations;

namespace AgendaMvc.Models
{
    public class Contatos
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display (Name = "Birth Date")]
        [DataType (DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }
        public string Tel { get; set; }
        [Display (Name = "Tipo Contato")]
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
