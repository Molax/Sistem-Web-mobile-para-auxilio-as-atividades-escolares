using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class Questao
    {
        public int idQuestao { get; set; }
        public string descricao { get; set; }
        public int idAtividade { get; set; }
        public IEnumerable<Opcao> opcoes {get; set;}
        public IEnumerable<Atividade> Atividade { get; set; }
    }
}
