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
    public class AlunoAplicacao
    {
        private readonly AlunoDAO repositorio;

        public AlunoAplicacao()
        {
            repositorio = new AlunoDAO();
        }

        public void Salvar(Aluno aluno)
        {
            repositorio.Salvar(aluno);
        }

        public int buscaTurma(string name)
        {
           return repositorio.BuscaTurma(name);
        }

        public void Excluir(int id)
        {
            repositorio.Excluir(id);
        }

        public List<Aluno> ListarTodos()
        {
            return repositorio.ListarTodos();
        }

        public List<Turma> listaTurma()
        {
            return repositorio.ListaTurma();
        }
        public Aluno ListarPorId(int id)
        {
            return repositorio.ListarPorId(id);
        }
    }
}
