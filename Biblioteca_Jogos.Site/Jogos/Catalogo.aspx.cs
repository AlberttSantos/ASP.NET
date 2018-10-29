using Biblioteca_Jogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Biblioteca_Jogos.BLL;

namespace Biblioteca_Jogos.Site.Jogos
{
    public partial class Catalogo : System.Web.UI.Page
    {
        private JogoBo _jogoBo;
        protected void Page_Load(object sender, EventArgs e)
        {
            //testar post back - só vai carregar quando carrega a primeira vez a pagina
            if (!Page.IsPostBack)
            {
                CarregarJogosNoRepeater();
            }
        }

        private void CarregarJogosNoRepeater()
        {
            _jogoBo = new JogoBo();

            RepeaterJogos.DataSource = _jogoBo.ObterTodosJogos();

            RepeaterJogos.DataBind();

        }
    }
}