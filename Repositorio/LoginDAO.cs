using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dominio;

namespace Repositorio
{
    public class LoginDAO
    {
        private Contexto contexto;
        public string pegasenha(string login, string senha)
        {
            using (contexto = new Contexto())
            {
                var senhaPessoa = "";
                var strQuery = " SELECT Login, Senha from PESSOA WHERE ";
                strQuery += string.Format("login = '{0}' and ", login);
                strQuery += string.Format("senha='{0}'",senha);
                SqlDataReader reader = contexto.ExecutaComandoComRetorno(strQuery);
                if (reader.Read())
                {
                    senhaPessoa = Convert.ToString(reader[1]);

                }


                reader.Dispose();
                return senhaPessoa;
            }
        }
    }
}
