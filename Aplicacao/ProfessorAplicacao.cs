using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio;
using Dominio;

namespace Aplicacao
{
    public class ProfessorAplicacao
    {
        private readonly ProfessorDAO repositorio;

        public ProfessorAplicacao()
        {
            repositorio = new ProfessorDAO();
        }

        public void Salvar(Professor prof)
        {
            repositorio.Salvar(prof);
        }
        public void Excluir(int id)
        {
            repositorio.Excluir(id);
        }

        public List<Professor> ListarTodos()
        {
            return repositorio.ListarTodos();
        }

        public Professor ListarPorId(int id)
        {
            return repositorio.ListarPorId(id);
        }
    }
}
