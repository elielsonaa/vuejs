using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace controlvac.Models
{
    public class Vacinacao
    {
        [Key]
        public int Id { get; private set; }
        [Required(ErrorMessage = "A Data de Vacinação é Obrigatório")]
        [Display(Name = "Data de Vacinação")]
        [DataType(DataType.Date)]
        public DateTime Data { get; private set; }
        [Required(ErrorMessage = "O Campo Paciente é Obrigatório")]
        [Display(Name = "Paciente")]
        public int PacienteId { get; private set; }
        public Paciente Paciente { get; private set; }
        [Required(ErrorMessage = "O Campo Vacina é Obrigatório")]
        [Display(Name = "Vacina")]
        public int VacinaId { get; private set; }
        public Vacina Vacina { get; private set; }
        [Required(ErrorMessage = "O Campo Dose é Obrigatório")]
        [Display(Name = "Dose")]
        public int Dose { get; private set; }
        [Required(ErrorMessage = "O Paciente é Obrigatório")]
        [Display(Name = "Total Doses")]
        public int DosesTomadas { get; private set; }
        public List<Paciente> Pacientes { get; private set; }
    }
}