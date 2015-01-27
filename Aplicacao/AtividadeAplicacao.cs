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
    public class AtividadeAplicacao
    {
        private readonly AtividadeDAO repositorio;

        public AtividadeAplicacao()
        {
            repositorio = new AtividadeDAO();
        }

        public void Salvar(Atividade atividade)
        {
            repositorio.Salvar(atividade);
        }

        public int buscaTurma(string name)
        {
            return repositorio.BuscaTurma(name);
        }

        public void Excluir(int id)
        {
            repositorio.Excluir(id);
        }

        public List<Atividade> ListarTodos()
        {
            return repositorio.ListarTodos();
        }

        public List<Turma> listaTurma()
        {
            return repositorio.ListaTurma();
        }
        public Atividade ListarPorId(int id)
        {
            return repositorio.ListarPorId(id);
        }
        public List<Atividade> listaporAluno(int id)
        {
            return repositorio.listaporAluno(id);
        }
        public List<Questao> listaQuestao(int id)
        {
            return repositorio.listaQuestao(id);
        }
        public List<Score> listascore()
        {
            return repositorio.listascore();
        }
    }
}
