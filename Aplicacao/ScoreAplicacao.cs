using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio;
using Dominio;

namespace Aplicacao
{
    public class ScoreAplicacao
    {
         private readonly ScoreDAO repositorio;

        public ScoreAplicacao()
        {
            repositorio = new ScoreDAO();
        }
        public void Salvar(Score score)
        {
            repositorio.Salvar(score);
        }

    }
}
