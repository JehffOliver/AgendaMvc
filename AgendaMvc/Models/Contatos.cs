using System;
using System.ComponentModel.DataAnnotations;

namespace AgendaMvc.Models
{
    public class Contatos
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "{0} Campo Obrigatório")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "O tamanho do {0}, é de {2} a {1} Caracteres")]
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "{0} Campo Obrigatório")]
        [EmailAddress(ErrorMessage = "Entre com um email valido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "{0} Campo Obrigatório")]
        [Display (Name = "Birth Date")]
        [DataType (DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "{0} Campo Obrigatório")]
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
