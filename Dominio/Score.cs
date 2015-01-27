using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class Score
    {
        [DisplayName("Aluno")]
        public string nomealuno { get; set; }
        public int idScore { get; set; }
        [DisplayName("Pontuação")]
        public int score { get; set; }
        public int idAluno { get; set; }
        [DisplayName("Atividade")]
        public int idAtividade { get; set; }
    }
}
