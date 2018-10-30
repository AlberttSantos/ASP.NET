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
                CarregarJogo();    
            }

        }
        protected void BtnGravar_Click(object sender, EventArgs e)
        {
            // _jogoBo.EditarJogos(_jogo);
        }

        public void CarregarJogo()
        {
            string id_jogo = Request.QueryString["id"];
            _jogoBo = new JogoBo();

            var jogoSelecionado  = _jogoBo.CarregarJogoSelecionado(id_jogo);

            TxtTitulo.Text = jogoSelecionado.Titulo;
            TxtValorPago.Text = jogoSelecionado.ValorPago.ToString();
            DataCompra.Text = Convert.ToDateTime(jogoSelecionado.DataCompra).ToString("dd/MM/yyyy");
            string id_editor = Convert.ToString( jogoSelecionado.Id_Editor);

            CarregarEditoresDdl(id_editor);
            CareegarGenerosDdl();
        }

        public void CarregarEditoresDdl(string id_editor)
        {            
            _editorBo = new EditorBo();

            var editores = _editorBo.ObterTodosEditores();
            
            var item = DdlEditor.Items.FindByValue(id_editor);
            if (item != null)
                item.Selected = true;

            DdlEditor.DataSource = editores;

            DdlEditor.DataBind();
        }

        public void CareegarGenerosDdl()
        {
            string id_jogo = Request.QueryString["id"];
            _generoBo = new GeneroBo();

            DdlGenero.DataSource = _generoBo.ObterTodosGeneros();
            DdlGenero.DataBind();
        }
    }
}