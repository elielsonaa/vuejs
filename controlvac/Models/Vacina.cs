using System;
using System.ComponentModel.DataAnnotations;

namespace controlvac.Models
{
    public class Vacina
    {
       
        public Vacina(int id, string nome, string fabricante, string lote, DateTime validade, int doses, int intervalo)
        {
            this.Id = id;
            this.Nome = nome;
            this.Fabricante = fabricante;
            this.Lote = lote;
            this.Validade = validade;
            this.Doses = doses;
            this.Intervalo = intervalo;

        }
        [Key]
        public int Id { get; private set; }
        public string Nome { get; private set; }
        [Required(ErrorMessage = "O Fabricante é Obrigatório")]
        public string Fabricante { get; private set; }
        public string Lote { get; private set; }
        [Required(ErrorMessage = "A Data de validade é Obrigatória")]
        [Display(Name = "Validade")]
        [DataType(DataType.Date)]
        public DateTime Validade { get; private set; }
        public int Doses { get; private set; }
        public int Intervalo { get; private set; }

    }
}