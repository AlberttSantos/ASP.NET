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
                CarregarJogo();
            }

        }

        protected void BtnGravar_Click(object sender, EventArgs e)
        {
            _jogo = new Jogo();

            _jogo.Id = ObeterIdJogo();
            _jogo.Titulo = TxtTitulo.Text;
            _jogo.ValorPago = string.IsNullOrWhiteSpace(TxtValorPago.Text) ? (double?)null : Convert.ToDouble(TxtValorPago.Text);
            //_jogo.DataCompra = string.IsNullOrWhiteSpace(DataCompra.Text) ? (DateTime?)null : Convert.ToDateTime(DataCompra.Text);
            _jogo.Imagem = GravarImagemNoDisco();
            _jogo.Id_Editor = Convert.ToInt32(DdlEditor.SelectedValue);
            _jogo.Id_Genero = Convert.ToInt32(DdlGenero.SelectedValue);

            try
            {
                _jogoBo = new JogoBo();
                _jogoBo.EditarJogo(_jogo);

                //Redirecionar para pagina inicial
                Response.Redirect("Catalogo.aspx");

            }
            catch (Exception)
            {

                LblResultado.Text = "Erro ao salvar dados";
            }

        }

        private string GravarImagemNoDisco()
        {
            //Se o fileupload tiver um arquivo
            if (FileUploadImagem.HasFile)
            {
                try
                {
                    //Caminho de salvamento da imagem
                    var caminho = AppDomain.CurrentDomain.BaseDirectory + @"Content\ImagensJogos\";

                    //Pega a data/hora em que foi salvo o arquivo
                    var fileName = DateTime.Now.ToString("yyyyMMddhhmmss") + "_" + FileUploadImagem.FileName;

                    //Salva o arquivo
                    FileUploadImagem.SaveAs(caminho + fileName);

                    return fileName;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                return null;
            }
        }

        public void CarregarJogo()
        {
            //Obtem ID da querystring
            var id = ObeterIdJogo();

            _jogoBo = new JogoBo();

            var jogoSelecionado = _jogoBo.CarregarJogoSelecionado(id);

            TxtTitulo.Text = jogoSelecionado.Titulo;
            TxtValorPago.Text = jogoSelecionado.ValorPago.ToString();
            
            //Se o valor não for vazio set a data, se não salve a data como empty
            DataCompra.Text = jogoSelecionado.DataCompra.HasValue ? jogoSelecionado.DataCompra.Value.ToString("yyyy-MM-dd") : string.Empty;

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