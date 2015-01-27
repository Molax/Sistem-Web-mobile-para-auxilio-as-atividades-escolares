using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dominio;


namespace Repositorio
{
    public class OpcaoDAO
    {
         private Contexto contexto;

        private void Inserir(Opcao opcao)
        {
            var strQuery = "";
            strQuery += " INSERT INTO OPCAO (descricao, opcaoCorreta,idQuestao) ";
            strQuery += string.Format(" VALUES ('{0}','{1}','{2}') ",
                opcao.descricao,opcao.opcaoCorreta,opcao.idQuestao);
            ;
            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        private void Alterar(Opcao opcap)
        {
            var strQuery = "";
            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        public void Salvar(Opcao opcao)
        {
            if (opcao.idOpcao > 0)
                Alterar(opcao);
            else
                Inserir(opcao);
        }

        public void Excluir(int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format(" DELETE FROM OPCAO WHERE idOpcao = {0}", id);
                contexto.ExecutaComando(strQuery);
            }
        }

        public int buscaQuestao(string name)
        {
            int id = 0;
            using (contexto = new Contexto())
            {
                string select = "SELECT TOP 1 idQuestao FROM Questao ORDER BY idQuestao DESC";
                SqlDataReader reader = contexto.ExecutaComandoComRetorno(select);
                if (reader.Read())
                {
                    id = Convert.ToInt16(reader[0]);

                }
                reader.Dispose();
                return id;
            }
        }


        public List<Opcao> ListarTodos()
        {
            using (contexto = new Contexto())
            {
                var strQuery = " SELECT * FROM OPCAO";
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjeto(retornoDataReader);
            }
        }

        public Opcao ListarPorId(int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format(" SELECT * FROM OPCAO WHERE idOpcao = {0}  ", id);
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjeto(retornoDataReader).FirstOrDefault();
            }
        }

        private List<Opcao> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var opcao = new List<Opcao>();
            while (reader.Read())
            {
                var temObjeto = new Opcao()
                {
                    idOpcao = int.Parse(reader["idOpcao"].ToString()),
                    descricao = reader["descricao"].ToString(),
                    opcaoCorreta = char.Parse(reader["opcaoCorrerta"].ToString()),
                    idQuestao = int.Parse(reader["idQuestao"].ToString())

                };

                opcao.Add(temObjeto);
            }
            reader.Close();
            return opcao;
        }


        }
    }
