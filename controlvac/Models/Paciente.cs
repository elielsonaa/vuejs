using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace controlvac.Models
{
    public class Paciente
    {
        [Key]
        public int Id { get; private set; }
        [Required(ErrorMessage = "O CPF é Obrigatório")]
        public string Cpf { get; private set; }
        [Required(ErrorMessage = "O Nome é Obrigatório")]
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        [Display(Name = "Nº Cartão SUS")]
        public string Sus { get; private set; }
        [Required(ErrorMessage = "O Sexo é Obrigatório")]
        public string Sexo { get; private set; }
        [Required(ErrorMessage = "A Data de Nascimento é Obrigatória")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime Nascimento { get; private set; }
        [Display(Name = "Endereço")]
        public string Endereco { get; private set; }
        [Display(Name = "Cep")]
        public string Cep { get; private set; }
        [StringLength(200)]
        public string Municipio { get; private set; }
        [StringLength(2)]
        public string Estado { get; private set; }
        public List<Vacinacao> Vacinacao { get; set; }
    }
}