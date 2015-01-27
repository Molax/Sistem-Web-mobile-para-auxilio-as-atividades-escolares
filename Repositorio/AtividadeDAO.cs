using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dominio;


namespace Repositorio
{
    public class AtividadeDAO
    {
        private Contexto contexto;

        private void Inserir(Atividade atividade)
        {
            var strQuery = "";
            strQuery += " INSERT INTO ATIVIDADE (descricao,ano,estado,idTurma,turma) ";
            strQuery += string.Format(" VALUES ('{0}','{1}','{2}','{3}','{4}') ",
                atividade.descricao, atividade.ano, atividade.estado, atividade.idTurma,atividade.turma);
            ;
            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        private void Alterar(Atividade atividade)
        {
            var strQuery = "";
            strQuery += " UPDATE ATIVIDADE SET ";
            strQuery += string.Format(" estado = '{0}'", atividade.estado);
            strQuery += string.Format(" WHERE idAtividade = {0} ", atividade.idAtividade);
            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        public void Salvar(Atividade atividade)
        {
            if (atividade.idAtividade > 0)
                Alterar(atividade);
            else
                Inserir(atividade);
        }

        public void Excluir(int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format(" DELETE FROM ATIVIDADE WHERE idAtividade = {0}", id);
                contexto.ExecutaComando(strQuery);
            }
        }

        public int BuscaTurma(string name)
        {
            int id = 0;
            using (contexto = new Contexto())
            {
                string select = "SELECT idTurma FROM Turma WHERE nome= '" + name + "'";
                SqlDataReader reader = contexto.ExecutaComandoComRetorno(select);
                if (reader.Read())
                {
                    id = Convert.ToInt16(reader[0]);

                }
                reader.Dispose();
                return id;
            }
        }


        public List<Atividade> ListarTodos()
        {
            using (contexto = new Contexto())
            {
                var strQuery = " SELECT * FROM ATIVIDADE";
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjeto(retornoDataReader);
            }
        }
        public List<Questao> listaQuestao(int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = " SELECT * FROM QUESTAO WHERE idAtividade like '" + id + "'";
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaQuestao (retornoDataReader);
            }
        }

        public List<Opcao> ListOpc(int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = " SELECT * FROM OPCAO WHERE idQuestao like '"+id+"'";
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaOPC(retornoDataReader);
            }
        }

        private List<Opcao> TransformaOPC(SqlDataReader reader)
        {
            var questoes = new List<Opcao>();
            while (reader.Read())
            {
                var temObjeto = new Opcao()
                {

                    descricao = reader["descricao"].ToString(),
                    opcaoCorreta = char.Parse(reader["opcaoCorreta"].ToString()),
                    idOpcao =  int.Parse(reader["idOpcao"].ToString()),

                };                

                questoes.Add(temObjeto);
            }
            reader.Close();
            return questoes;
        }

        private List<Questao> TransformaQuestao(SqlDataReader reader)
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
                temObjeto.opcoes = ListOpc(temObjeto.idQuestao);

                questoes.Add(temObjeto);
            }
            reader.Close();
            return questoes;
        }
        public Atividade ListarPorId(int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format(" SELECT * FROM ATIVIDADE WHERE idAtividade = {0}", id);
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjeto(retornoDataReader).FirstOrDefault();
            }
        }

        private List<Atividade> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var atividades = new List<Atividade>();
            while (reader.Read())
            {
                var temObjeto = new Atividade()
                {
                    idAtividade = int.Parse(reader["idAtividade"].ToString()),
                    descricao = reader["descricao"].ToString(),
                    ano=DateTime.Parse(reader["ano"].ToString()),
                    estado=char.Parse(reader["estado"].ToString()),
                    idTurma = int.Parse(reader["idTurma"].ToString()),
                    turma=reader["turma"].ToString()

                };

                atividades.Add(temObjeto);
            }
            reader.Close();
            return atividades;
        }
        public List<Atividade> listaporAluno(int id)
        {
            using (contexto = new Contexto())
            {
                string select = "SELECT idTurma FROM Pessoa WHERE idPessoa= '" + id + "'";
                SqlDataReader reader = contexto.ExecutaComandoComRetorno(select);
                if (reader.Read())
                {
                    id = Convert.ToInt16(reader[0]);

                }
                reader.Dispose();
                var strQuery = string.Format(" SELECT * FROM ATIVIDADE WHERE idTurma = {0}", id);
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjeto(retornoDataReader);
            }
        }

        public List<Turma> ListaTurma()
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format(" SELECT * FROM TURMA");
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaTurma(retornoDataReader);
            }
        }

        private List<Turma> TransformaTurma(SqlDataReader reader)
        {
            var turmas = new List<Turma>();
            while (reader.Read())
            {
                var temObjeto = new Turma()
                {
                    idTurma = int.Parse(reader["idTurma"].ToString()),
                    nome = reader["nome"].ToString(),


                };

                turmas.Add(temObjeto);
            }
            reader.Close();
            return turmas;
        }
        public List<Score> listascore()
        {
            using (contexto = new Contexto())
            {
                var strQuery = " SELECT * FROM SCORE";
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaScore(retornoDataReader);
            }
        }

        private List<Score> TransformaScore(SqlDataReader reader)
        {
            var scores = new List<Score>();
            while (reader.Read())
            {
                var temObjeto = new Score()
                {
                    nomealuno=reader["nomealuno"].ToString(),
                    idAluno = int.Parse(reader["idAluno"].ToString()),
                    idAtividade = int.Parse(reader["idAtividade"].ToString()),
                    score = int.Parse(reader["score"].ToString()),

                };

                scores.Add(temObjeto);
            }
            reader.Close();
            return scores;
        }
    }

}
