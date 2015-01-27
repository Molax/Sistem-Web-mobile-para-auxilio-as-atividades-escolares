using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dominio;


namespace Repositorio
{
    public class DisciplinaDAO
    {
        private Contexto contexto;

        private void Inserir(Disciplina disciplina)
        {
            var strQuery = "";
            strQuery += " INSERT INTO DISCIPLINA (nome,tipo) ";
            strQuery += string.Format(" VALUES ('{0}','{1}') ",
                disciplina.nome, disciplina.tipo);
            ;
            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        private void Alterar(Disciplina disciplina)
        {
            var strQuery = "";
            strQuery += " UPDATE DISCIPLINA SET ";
            strQuery += string.Format(" nome = '{0}', ", disciplina.nome);
            strQuery += string.Format(" tipo = '{0}' ", disciplina.tipo);
            
            strQuery += string.Format(" WHERE idDisciplina = {0} ", disciplina.idDisciplina);
            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        public void Salvar(Disciplina disciplina)
        {
            if (disciplina.idDisciplina > 0)
                Alterar(disciplina);
            else
                Inserir(disciplina);
        }
        public void Excluir(int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format(" DELETE FROM DISCIPLINA WHERE idDisciplina = {0}", id);
                contexto.ExecutaComando(strQuery);
            }
        }

        public List<Disciplina> ListarTodos()
        {
            using (contexto = new Contexto())
            {
                var strQuery = " SELECT * FROM DISCIPLINA ";
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjeto(retornoDataReader);
            }
        }

        public Disciplina ListarPorId(int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format(" SELECT * FROM DISCIPLINA WHERE idDisciplina = {0} ", id);
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjeto(retornoDataReader).FirstOrDefault();
            }
        }

        private List<Disciplina> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var disciplinas = new List<Disciplina>();
            while (reader.Read())
            {
                var temObjeto = new Disciplina()
                {
                    idDisciplina = int.Parse(reader["idDisciplina"].ToString()),
                    nome=reader["nome"].ToString(),
                    tipo=reader["tipo"].ToString()

                };
                disciplinas.Add(temObjeto);
            }
            reader.Close();
            return disciplinas;
        }
    }
}
