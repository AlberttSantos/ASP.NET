using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Biblioteca_Jogos.BLL.Autenticacao;
using Biblioteca_Jogos.BLL.Exceptions;

namespace Biblioteca_Jogos.Site
{
    public partial class Login : System.Web.UI.Page
    {
        private LoginBo _loginBo;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {            
            string nomeUsuario = TxtUsuario.Text;
            string senha = TxtSenha.Text;

            try
            {
                _loginBo = new LoginBo();

                //Obtem usuario cadastrado no banco
                var usuario = _loginBo.ObterUsuarioParaLogar(nomeUsuario, senha);

                //Redireciona o usuário para tela de login caso o mesmo não esteja autenticado
                FormsAuthentication.RedirectFromLoginPage(usuario.Nome, false);

                //A Sessão do usuário irá durar 30mim
                Session.Timeout = 30;
                Session["Perfil"] = usuario.Perfil;
            }
            catch (UsuarioNaoCadastradoExceptions)
            {
                LblStatus.Text = "Usuário não cadastrado";
            }
            catch (Exception)
            {
                LblStatus.Text = "Erro inesperado";
            }

        }
    }
}