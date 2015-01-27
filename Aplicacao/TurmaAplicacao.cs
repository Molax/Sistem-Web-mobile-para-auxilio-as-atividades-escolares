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
    public class TurmaAplicacao
    {
        private readonly TurmaDAO repositorio;

        public TurmaAplicacao()
        {
            repositorio = new TurmaDAO();
        }

        public void Salvar(Turma turma)
        {
            repositorio.Salvar(turma);
        }
        public void Excluir(int id)
        {
            repositorio.Excluir(id);
        }

        public List<Turma> ListarTodos()
        {
            return repositorio.ListarTodos();
        }

        public Turma ListarPorId(int id)
        {
            return repositorio.ListarPorId(id);
        }
        public List<Professor> listaProfessor()
        {
            return repositorio.listaProfessor();
        }
        public List<Disciplina> listaDisciplina()
        {
            return repositorio.listaDisciplina();
        }
        public int buscaProf(string nameprof)
        {
            return repositorio.buscaProf(nameprof);
        }
        public int buscaDisciplina(string namedisc)
        {
            return repositorio.buscaDisciplina(namedisc);
        }
    }
}
