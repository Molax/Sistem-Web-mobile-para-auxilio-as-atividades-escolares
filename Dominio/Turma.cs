using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class Turma
    {
        [DisplayName("ID")]
        public int idTurma { get; set; }
        [DisplayName("Nome")]
        public string nome { get; set; }
        [DisplayName("Ano da turma")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ano { get; set; }
        public int idProf { get; set; }
        public int idDisciplina { get; set; }
        public IEnumerable<Professor> Professor { get; set; }
        public IEnumerable<Disciplina> Disciplina { get; set; }
    }
}
