using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class Atividade
    {
        [DisplayName("ID")]
        public int idAtividade { get; set; }
        [DisplayName("Descrição")]
        public string descricao { get; set; }
        [DisplayName("Data da Atividade")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ano { get; set; }
        [DisplayName("Atividade Avaliada")]
        public char estado { get; set; }
        [DisplayName("Turma")]
        public int idTurma { get; set; }
        public IEnumerable<Turma> Turma{get; set;}
        [DisplayName("Turma")]
        public string turma { get; set; }
        public IEnumerable<Questao> questao { get; set; }
        public IEnumerable<Score> score { get; set; }
    }
}
