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
    public class DisciplinaAplicacao
    {
        private readonly DisciplinaDAO repositorio;

        public DisciplinaAplicacao()
        {
            repositorio = new DisciplinaDAO();
        }

        public void Salvar(Disciplina disciplina)
        {
            repositorio.Salvar(disciplina);
        }

        public void Excluir(int id)
        {
            repositorio.Excluir(id);
        }
        public List<Disciplina> ListarTodos()
        {
            return repositorio.ListarTodos();
        }

        public Disciplina ListarPorId(int id)
        {
            return repositorio.ListarPorId(id);
        }
    }
}
