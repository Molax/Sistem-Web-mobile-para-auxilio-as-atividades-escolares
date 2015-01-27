using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dominio;

namespace Repositorio
{
    public class AlunoDAO
    {

        private Contexto contexto;

        private void Inserir(Aluno aluno)
        {
            var strQuery = "";
            strQuery += " INSERT INTO PESSOA (nome, telefone, sexo,dtNascimento,endereco,cpf,tipo,senha,login,idTurma,turma) ";
            strQuery += string.Format(" VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}') ",
                aluno.Nome, aluno.telAluno, aluno.sexoAluno, aluno.nascimentoAluno, aluno.enderecoAluno, aluno.cpfAluno, aluno.tipo=1,
                aluno.senha, aluno.login, aluno.idTurma, aluno.turma);
            ;
            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        private void Alterar(Aluno aluno)
        {
            var strQuery = "";
            strQuery += " UPDATE PESSOA SET ";
            strQuery += string.Format(" nome = '{0}',", aluno.Nome);
            strQuery += string.Format(" telefone = '{0}',", aluno.telAluno);
            strQuery += string.Format(" sexo = '{0}',", aluno.sexoAluno);
            strQuery += string.Format(" dtNascimento = '{0}',", aluno.nascimentoAluno);
            strQuery += string.Format(" endereco = '{0}',", aluno.enderecoAluno);
            strQuery += string.Format(" cpf = '{0}',", aluno.cpfAluno);
            strQuery += string.Format(" senha = '{0}',", aluno.senha);
            strQuery += string.Format(" login = '{0}'", aluno.login);

            strQuery += string.Format(" WHERE idPessoa = {0} ", aluno.idAluno);
            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        public void Salvar(Aluno aluno)
        {
            if (aluno.idAluno > 0)
                Alterar(aluno);
            else
                Inserir(aluno);
        }

        public void Excluir(int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format(" DELETE FROM PESSOA WHERE idPessoa = {0}", id);
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


        public List<Aluno> ListarTodos()
        {
            using (contexto = new Contexto())
            {
                var strQuery = " SELECT * FROM PESSOA WHERE TIPO = 1";
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjeto(retornoDataReader);
            }
        }

        public Aluno ListarPorId(int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format(" SELECT * FROM PESSOA WHERE idPessoa = {0} and TIPO = 1 ", id);
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjeto(retornoDataReader).FirstOrDefault();
            }
        }

        private List<Aluno> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var alunos = new List<Aluno>();
            while (reader.Read())
            {
                var temObjeto = new Aluno()
                {
                    idAluno = int.Parse(reader["idPessoa"].ToString()),
                    Nome = reader["nome"].ToString(),
                    telAluno = reader["telefone"].ToString(),
                    sexoAluno = reader["sexo"].ToString(),
                    nascimentoAluno = DateTime.Parse(reader["dtNascimento"].ToString()),
                    enderecoAluno = reader["endereco"].ToString(),
                    cpfAluno = reader["cpf"].ToString(),
                    tipo = int.Parse(reader["tipo"].ToString()),
                    senha = reader["senha"].ToString(),
                    login = reader["login"].ToString(),
                    idTurma = int.Parse(reader["idTurma"].ToString()),
                    turma = reader["turma"].ToString(),

                };

                alunos.Add(temObjeto);
            }
            reader.Close();
            return alunos;
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
    }
}
