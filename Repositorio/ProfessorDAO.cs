using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dominio;

namespace Repositorio
{
    public class ProfessorDAO
    {
        private Contexto contexto;

        private void Inserir(Professor prof)
        {
            var strQuery = "";
            strQuery += " INSERT INTO PESSOA (nome, telefone, sexo,dtNascimento,endereco,cpf,tipo,formacao,senha,login) ";
            strQuery += string.Format(" VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}') ",
                prof.Nome, prof.telProf, prof.sexoProf, prof.nascimentoProf, prof.enderecoProf, prof.cpfProf, prof.tipo = 2, prof.formacao,
                prof.senha, prof.login);
            ;
            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        private void Alterar(Professor prof)
        {
            var strQuery = "";
            strQuery += " UPDATE PESSOA SET ";
            strQuery += string.Format(" nome = '{0}',", prof.Nome);
            strQuery += string.Format(" telefone = '{0}',", prof.telProf);
            strQuery += string.Format(" sexo = '{0}',", prof.sexoProf);
            strQuery += string.Format(" dtNascimento = '{0}',", prof.nascimentoProf);
            strQuery += string.Format(" endereco = '{0}',", prof.enderecoProf);
            strQuery += string.Format(" cpf = '{0}',", prof.cpfProf);
         
            strQuery += string.Format(" formacao = '{0}',", prof.formacao);
            strQuery += string.Format(" senha = '{0}',", prof.senha);
            strQuery += string.Format(" login = '{0}'", prof.login);
            strQuery += string.Format(" WHERE idPessoa = {0} ", prof.idProf);
            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        public void Salvar(Professor prof)
        {
            if (prof.idProf > 0)
                Alterar(prof);
            else
                Inserir(prof);
        }

        public void Excluir(int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format(" DELETE FROM PESSOA WHERE idPessoa = {0}", id);
                contexto.ExecutaComando(strQuery);
            }
        }

        public List<Professor> ListarTodos()
        {
            using (contexto = new Contexto())
            {
                var strQuery = " SELECT * FROM PESSOA WHERE TIPO = 2";
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjeto(retornoDataReader);
            }
        }

        public Professor ListarPorId(int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format(" SELECT * FROM PESSOA WHERE idPessoa = {0} and TIPO = 2 ", id);
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjeto(retornoDataReader).FirstOrDefault();
            }
        }

        private List<Professor> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var profs = new List<Professor>();
            while (reader.Read())
            {
                var temObjeto = new Professor()
                {
                    idProf = int.Parse(reader["idPessoa"].ToString()),
                    Nome = reader["nome"].ToString(),
                    telProf = reader["telefone"].ToString(),
                    sexoProf = reader["sexo"].ToString(),
                    nascimentoProf = DateTime.Parse(reader["dtNascimento"].ToString()),
                    enderecoProf = reader["endereco"].ToString(),
                    cpfProf = reader["cpf"].ToString(),
                    tipo = int.Parse(reader["tipo"].ToString()),
                    formacao = reader["formacao"].ToString(),
                    senha = reader["senha"].ToString(),
                    login = reader["login"].ToString(),

                };
                profs.Add(temObjeto);
            }
            reader.Close();
            return profs;
        }
        public int buscaTurma(string name)
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
        public List<Turma> listaTurma()
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
