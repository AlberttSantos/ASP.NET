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
                //CarregarEditoresDdl();
                //CareegarGenerosDdl();
            }

        }
        protected void BtnGravar_Click(object sender, EventArgs e)
        {
            // _jogoBo.EditarJogos(_jogo);
        }

        public void CarregarJogo()
        {
            //Obtem ID da querystring
            var id = ObeterIdJogo();

            _jogoBo = new JogoBo();        

            var jogoSelecionado = _jogoBo.CarregarJogoSelecionado(id);

            TxtTitulo.Text = jogoSelecionado.Titulo;
            TxtValorPago.Text = jogoSelecionado.ValorPago.ToString();
            DataCompra.Text = Convert.ToDateTime(jogoSelecionado.DataCompra).ToString("dd/MM/yyyy");
            DdlEditor.SelectedValue = jogoSelecionado.Id_Editor.ToString();
            DdlGenero.SelectedValue = jogoSelecionado.Id_Genero.ToString();
        }

        public int ObeterIdJogo()
        {
            int id = 0;
            string id_query = Request.QueryString["id"];
            if (int.TryParse(id_query, out id))
            {
                if (id <= 0)
                {
                    throw new Exception("Id inválido");
                }

                return id;
            }
            else
            {
                throw new Exception("Id inválido");
            }
        }

        public void CarregarEditoresDdl()
        {
            _editorBo = new EditorBo();

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