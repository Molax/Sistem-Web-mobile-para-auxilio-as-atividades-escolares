using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Dominio
{
    public class Professor
    {
        [DisplayName("ID")]
        public int idProf { get; set; }
        public string Nome { get; set; }
        [DisplayName("Telefone")]
        public string telProf { get; set; }
        [DisplayName("Sexo")]
        public string sexoProf { get; set; }
        [DisplayName("Data de Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime nascimentoProf { get; set; }
        [DisplayName("Endereço")]
        public string enderecoProf { get; set; }
        [DisplayName("CPF")]
        public string cpfProf { get; set; }
        [DisplayName("Tipo")]
        public int tipo { get; set; }
        [DisplayName("Formação")]
        public string formacao { get; set; }
        public string senha { get; set; }
        public string login { get; set; }
        [DisplayName("ID da Turma")]
        public int idTurma { get; set; }
        public IEnumerable<Turma> Turma { get; set; }
    }
}
