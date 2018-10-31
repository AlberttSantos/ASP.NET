using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Biblioteca_Jogos.Site
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            //Se o usuário estiver autenticado
            if (HttpContext.Current.Request.IsAuthenticated)
            {
                //Desloga usuário
                FormsAuthentication.SignOut();

                //Deireciona para pagina de login
                FormsAuthentication.RedirectToLoginPage();
                HttpContext.Current.Response.End();
            }
        }
    }
}