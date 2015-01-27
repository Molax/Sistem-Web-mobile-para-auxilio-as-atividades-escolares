using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class Opcao
    {
        public int idOpcao { get; set; }
        public string descricao { get; set; }
        public char opcaoCorreta { get; set; }
        public int idQuestao { get; set; }
        public IEnumerable <Questao>Questao { get; set; }
    }
}
