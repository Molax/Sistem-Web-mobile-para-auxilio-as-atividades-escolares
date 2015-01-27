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
    public class LoginAplicacao
    {
        private readonly LoginDAO repositorio;

        public LoginAplicacao()
        {
            repositorio = new LoginDAO();
        }

        public bool ConfereUsuario(string usuario, string senha)
        {
            bool confere = false;
            var senhaUsuario = repositorio.pegasenha(usuario, senha);
            

            if (usuario != null)
            {
                if (senha != null)
                {
                    confere = false;
                    if (senhaUsuario == senha)
                    {
                        confere = true;
                    }
                }
                else
                    confere = false;
            }
            else
                confere = false;

            return confere;
        }

    }
}
