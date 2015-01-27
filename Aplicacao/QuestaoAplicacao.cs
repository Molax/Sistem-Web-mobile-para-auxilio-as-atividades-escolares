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
    public class QuestaoAplicacao
    {
        private readonly QuestaoDAO repositorio;

        public QuestaoAplicacao()
        {
            repositorio = new QuestaoDAO();
        }

        public void Salvar(Questao questao)
        {
            repositorio.Salvar(questao);
        }

        public int buscaAtividade(string name)
        {
           return repositorio.buscaAtividade(name);
        }

        public void Excluir(int id)
        {
            repositorio.Excluir(id);
        }

        public List<Questao> ListarTodos()
        {
            return repositorio.ListarTodos();
        }


        public Questao ListarPorId(int id)
        {
            return repositorio.ListarPorId(id);
        }
    }
}
