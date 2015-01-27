using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dominio;

namespace Repositorio
{
    public class ScoreDAO
    {
        private Contexto contexto;
        private void Inserir(Score score)
        {
            var strQuery = "";
            strQuery += " INSERT INTO SCORE (score, idAtividade,idAluno)";
            strQuery += string.Format(" VALUES ('{0}','{1}','{2}') ",
                score.score, score.idAtividade,score.idAluno);
            ;
            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }

        }
        private void Alterar(Score score)
        {
            var strQuery = "";
            strQuery += " UPDATE SCORE SET ";
            strQuery += string.Format(" score = '{0}',", score.score);
            strQuery += string.Format(" idAtividade = '{0}',", score.idAtividade);
            strQuery += string.Format(" idAluno = '{0}',", score.idAluno);

            strQuery += string.Format(" WHERE idScore = {0} ", score.idScore);
            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        public void Salvar(Score score)
        {
            if (score.idAtividade > 0)
                Alterar(score);
            else
                Inserir(score);
        }
    }
}
