using Biblioteca_Jogos.BLL;
using Biblioteca_Jogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Biblioteca_Jogos.Site.Jogos
{
    public partial class EdicaoJogo : System.Web.UI.Page
    {
        private GeneroBo _generoBo;
        private EditorBo _editorBo;
        private JogoBo _jogoBo;
        private Jogo _jogo;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CarregarEditoresDdl();
                CareegarGenerosDdl();
            }

        }
        protected void BtnGravar_Click(object sender, EventArgs e)
        {
            _jogoBo.EditarJogos(_jogo);
        }

        public void CarregarEditoresDdl()
        {
            _editorBo = new EditorBo();

            string id_jogo = Request.QueryString["id"];

            DdlEditor.DataSource = _editorBo.ObterTodosEditores();
            DdlEditor.DataBind();            
        }
        
        public void CareegarGenerosDdl()
        {
            _generoBo = new GeneroBo();

            DdlGenero.DataSource = _generoBo.ObterTodosGeneros();
            DdlGenero.DataBind();
        }
    }
}