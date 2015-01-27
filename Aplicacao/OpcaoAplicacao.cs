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
    public class OpcaoAplicacao
    {
        private readonly OpcaoDAO repositorio;

        public OpcaoAplicacao()
        {
            repositorio = new OpcaoDAO();
        }

        public void Salvar(Opcao opcao)
        {
            repositorio.Salvar(opcao);
        }

        public int buscaQuestao(string name)
        {
           return repositorio.buscaQuestao(name);
        }

        public void Excluir(int id)
        {
            repositorio.Excluir(id);
        }

        public List<Opcao> ListarTodos()
        {
            return repositorio.ListarTodos();
        }


        public Opcao ListarPorId(int id)
        {
            return repositorio.ListarPorId(id);
        }
    }
}
