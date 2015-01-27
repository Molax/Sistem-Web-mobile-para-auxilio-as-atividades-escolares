using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dominio;

namespace Repositorio
{
    public class RespostaDAO
    {
        private Contexto contexto;

        private void Inserir(RespostaAluno resposta)
        {
            var strQuery = "";
            strQuery += " INSERT INTO RespostaAluno (idAluno,idQuestao,idResposta) ";
            strQuery += string.Format(" VALUES ('{0}','{1}','{2}') ",
                 resposta.idAluno, resposta.idQuestao, resposta.idResposta);
            ;
            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        private void Alterar(RespostaAluno resposta)
        {
            var strQuery = "";
            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        public void Salvar(RespostaAluno resposta)
        {
            if (resposta.idRespAluno > 0)
                Alterar(resposta);
            else
                Inserir(resposta);
        }
        //public bool confereResposta(int opc, int questao)
        //{
        //    var questaocerta;
        //    var strQuery = " SELECT Login, Senha from PESSOA WHERE ";
        //    strQuery += string.Format("login = '{0}' and ", login);
        //    strQuery += string.Format("senha='{0}'", senha);
        //    SqlDataReader reader = contexto.ExecutaComandoComRetorno(strQuery);
        //    if (reader.Read())
        //    {
        //        senhaPessoa = Convert.ToString(reader[1]);

        //    }


        //    reader.Dispose();
        //    return senhaPessoa;

        //}
        public List<Opcao> listaOpcao(int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = " SELECT * FROM Opcao WHERE idQuestao like '" + id + "'";
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransofmraOpcao(retornoDataReader);
            }
        }
        private List<Opcao> TransofmraOpcao(SqlDataReader reader)
        {
            var opcoes = new List<Opcao>();
            while (reader.Read())
            {
                var temObjeto = new Opcao()
                {
                    idOpcao = int.Parse(reader["idOpcao"].ToString()),
                    opcaoCorreta = char.Parse(reader["opcaoCorreta"].ToString())

                };
                opcoes.Add(temObjeto);
            }
            reader.Close();
            return opcoes;
        }
    }
}