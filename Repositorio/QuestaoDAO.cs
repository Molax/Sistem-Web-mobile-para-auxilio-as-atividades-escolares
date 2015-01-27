using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dominio;


namespace Repositorio
{
    public class QuestaoDAO
    {
        private Contexto contexto;

        private void Inserir(Questao questao)
        {
            var strQuery = "";
            strQuery += " INSERT INTO QUESTAO (descricao, idAtividade) ";
            strQuery += string.Format(" VALUES ('{0}','{1}') ",
                questao.descricao,questao.idAtividade);
            ;
            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        private void Alterar(Questao questao)
        {
            var strQuery = "";
            strQuery += " UPDATE QUESTAO SET ";
            strQuery += string.Format(" descricao = '{0}',", questao.descricao);
            strQuery += string.Format(" idAtividade = '{0}',", questao.idAtividade);
            

            strQuery += string.Format(" WHERE idQuestao = {0} ", questao.idQuestao);
            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        public void Salvar(Questao questao)
        {
            if (questao.idQuestao > 0)
                Alterar(questao);
            else
                Inserir(questao);
        }

        public void Excluir(int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format(" DELETE FROM QUESTAO WHERE idQuestao = {0}", id);
                contexto.ExecutaComando(strQuery);
            }
        }

        public int buscaAtividade(string name)
        {
            int id = 0;
            using (contexto = new Contexto())
            {
                string select = "SELECT TOP 1 idAtividade FROM Atividade ORDER BY idAtividade DESC";
                SqlDataReader reader = contexto.ExecutaComandoComRetorno(select);
                if (reader.Read())
                {
                    id = Convert.ToInt16(reader[0]);

                }
                reader.Dispose();
                return id;
            }
        }


        public List<Questao> ListarTodos()
        {
            using (contexto = new Contexto())
            {
                var strQuery = " SELECT * FROM QUESTAO";
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjeto(retornoDataReader);
            }
        }

        public Questao ListarPorId(int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format(" SELECT * FROM QUESTAO WHERE idQuestao = {0}  ", id);
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjeto(retornoDataReader).FirstOrDefault();
            }
        }

        private List<Questao> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var questoes = new List<Questao>();
            while (reader.Read())
            {
                var temObjeto = new Questao()
                {
                    idQuestao = int.Parse(reader["idQuestao"].ToString()),
                    descricao = reader["descricao"].ToString(),
                    idAtividade = int.Parse(reader["idAtividade"].ToString())

                };

                questoes.Add(temObjeto);
            }
            reader.Close();
            return questoes;
        }


        }
    }

