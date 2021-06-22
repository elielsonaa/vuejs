using System;
using System.ComponentModel.DataAnnotations;

namespace controlvac.Models
{
    public class Paciente
    {
        
        public Paciente(int id, string cpf, string nome, string sobrenome, string sus, DateTime nascimento, EComorbidade comorbidades, string municipio, string estado)
        {
            this.Id = id;
            this.Cpf = cpf;
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.Sus = sus;
            this.Nascimento = nascimento;
            this.Comorbidades = comorbidades;
            this.Municipio = municipio;
            this.Estado = estado;

        }
        [Key]
        public int Id { get; private set; }
        [Required(ErrorMessage = "O CPF é Obrigatório")]
        public string Cpf { get; private set; }
        [Required(ErrorMessage = "O Nome é Obrigatório")]
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        [Display(Name = "Nº Cartão SUS")]
        public string Sus { get; private set; }
        [Required(ErrorMessage = "A Data de Nascimento é Obrigatória")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime Nascimento { get; private set; }
        [Display(Name = "Tem Comorbidades?")]
        public EComorbidade Comorbidades { get; private set; }
        [StringLength(200)]
        public string Municipio { get; private set; }
        [StringLength(2)]
        public string Estado { get; private set; }
    }
}

//Enumeração informa se o paciente tem comorbidades ou não
public enum EComorbidade
{
    [Display(Name = "Sim")]
    Sim,
    [Display(Name = "Não")]
    Nao
}