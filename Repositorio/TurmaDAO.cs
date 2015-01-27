using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dominio;
namespace Repositorio
{
    public class TurmaDAO
    {
        private Contexto contexto;

        private void Inserir(Turma turma)
        {
            var strQuery = "";
            strQuery += " INSERT INTO TURMA (nome,ano,idProfessor,idDisciplina) ";
            strQuery += string.Format(" VALUES ('{0}','{1}','{2}','{3}') ",
                turma.nome, turma.ano,turma.idProf,turma.idDisciplina)
            ;
            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        private void Alterar(Turma turma)
        {
            var strQuery = "";
            strQuery += " UPDATE TURMA SET ";
            strQuery += string.Format(" nome = '{0}', ", turma.nome);
            strQuery += string.Format(" ano = '{0}' ", turma.ano);
            strQuery += string.Format(" WHERE idTurma = {0} ", turma.idTurma);
            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }


        public void Salvar(Turma turma)
        {
            if (turma.idTurma > 0)
                Alterar(turma);
            else
                Inserir(turma);
        }

        public void Excluir(int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format(" DELETE FROM TURMA WHERE idTurma = {0}", id);
                contexto.ExecutaComando(strQuery);
            }
        }

        public List<Turma> ListarTodos()
        {
            using (contexto = new Contexto())
            {
                var strQuery = " SELECT * FROM TURMA ";
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjeto(retornoDataReader);
            }
        }

        public Turma ListarPorId(int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format(" SELECT * FROM TURMA WHERE idTurma = {0}  ", id);
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjeto(retornoDataReader).FirstOrDefault();
            }
        }

        private List<Turma> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var turmas = new List<Turma>();
            while (reader.Read())
            {
                var temObjeto = new Turma()
                {
                    idTurma = int.Parse(reader["idTurma"].ToString()),
                    nome = reader["nome"].ToString(),
                    ano = DateTime.Parse(reader["ano"].ToString()),
                    

                };
                turmas.Add(temObjeto);
            }
            reader.Close();
            return turmas;
        }
        public List<Disciplina> listaDisciplina()
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format(" SELECT * FROM DISCIPLINA");
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaDisciplina(retornoDataReader);
            }
        }

        private List<Disciplina> TransformaDisciplina(SqlDataReader reader)
        {
            var disciplinas = new List<Disciplina>();
            while (reader.Read())
            {
                var temObjeto = new Disciplina()
                {
                    idDisciplina = int.Parse(reader["idDisciplina"].ToString()),
                    nome = reader["nome"].ToString(),


                };

                disciplinas.Add(temObjeto);
            }
            reader.Close();
            return disciplinas;
        }
        public List<Professor> listaProfessor()
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format(" SELECT * FROM PESSOA WHERE tipo = 2");
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaProfessor(retornoDataReader);
            }
        }

        private List<Professor> TransformaProfessor(SqlDataReader reader)
        {
            var professores = new List<Professor>();
            while (reader.Read())
            {
                var temObjeto = new Professor()
                {
                    
                    Nome = reader["Nome"].ToString(),


                };

                professores.Add(temObjeto);
            }
            reader.Close();
            return professores;
        }

        public int buscaProf(string nameprof)
        {
            int id = 0;
            using (contexto = new Contexto())
            {
                string select = "SELECT idPessoa FROM PESSOA WHERE nome= '" + nameprof + "'";
                SqlDataReader reader = contexto.ExecutaComandoComRetorno(select);
                if (reader.Read())
                {
                    id = Convert.ToInt16(reader[0]);

                }
                reader.Dispose();
                return id;
            }
        }
        public int buscaDisciplina(string namedisc)
        {
            int id = 0;
            using (contexto = new Contexto())
            {
                string select = "SELECT idDisciplina FROM DISCIPLINA WHERE nome= '" + namedisc + "'";
                SqlDataReader reader = contexto.ExecutaComandoComRetorno(select);
                if (reader.Read())
                {
                    id = Convert.ToInt16(reader[0]);

                }
                reader.Dispose();
                return id;
            }
        }
    }
}
