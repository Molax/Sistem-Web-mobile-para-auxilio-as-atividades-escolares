using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Dominio
{
    public class ViewModelQuestao
    {
        public Questao questao { get; set; }
        public Opcao opcao { get; set; }
    }
}
