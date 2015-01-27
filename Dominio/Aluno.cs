using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Dominio
{
    public class Aluno
    {
        [DisplayName("ID")]
        public int idAluno { get; set; }
        public string Nome { get; set; }
        [DisplayName("Telefone")]
        public string telAluno { get; set; }
        [DisplayName("Sexo")]
        public string  sexoAluno { get; set; }
        [DisplayName("Data de Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime nascimentoAluno { get; set; }
        [DisplayName("Endereço")]
        public string enderecoAluno { get; set; }
        [DisplayName("CPF")]
        public string cpfAluno { get; set; }
        [DisplayName("Tipo")]
        public int tipo { get; set; }
        [DisplayName("Senha")]
        public string senha { get; set; }
        [DisplayName("Login")]
        public string login { get; set; }
        [DisplayName("Turma")]
        public int idTurma { get; set; }
        public IEnumerable<Turma> Turma { get; set; }
        public string turma { get; set; }
    }
}
