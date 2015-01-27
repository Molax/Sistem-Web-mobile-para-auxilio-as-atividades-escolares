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
    public class RespostaAplicacao
    {
        private readonly RespostaDAO repositorio;

        public RespostaAplicacao()
        {
            repositorio = new RespostaDAO();
        }
        public void Salvar(RespostaAluno resposta)
        {
            repositorio.Salvar(resposta);
        }
        //public bool confereResposta(int opc, int questao)
        //{ 
        //    return repositorio.confereResposta(opc, );
        //}
        public List<Opcao> listaOpcao(int id)
        {
            return repositorio.listaOpcao(id);
        }
     
    }
}
