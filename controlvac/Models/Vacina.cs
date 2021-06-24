using System;
using System.ComponentModel.DataAnnotations;

namespace controlvac.Models
{
    public class Vacina
    {
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