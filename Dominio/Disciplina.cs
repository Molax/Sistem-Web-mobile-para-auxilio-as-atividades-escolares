using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Dominio
{
    public class Disciplina
    {
        [DisplayName("ID")]
        public int idDisciplina { get; set; }
        [DisplayName("Nome")]
        public string nome { get; set; }
        [DisplayName("Tipo")]
        public string tipo { get; set; }
    }
}
