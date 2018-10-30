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
    public partial class CadastroJogo : System.Web.UI.Page
    {
        EditorBo _editorBo;
        GeneroBo _generoBo;
        JogoBo _jogoBo;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CarregarTodosEditores();
                CarregarTodosGeneros();
            }
        }

        protected void BtnGravar_Click(object sender, EventArgs e)
        {
            Jogo jogo = new Jogo();           

            jogo.Titulo = TxtTitulo.Text;
            jogo.ValorPago = string.IsNullOrWhiteSpace(TxtValorPago.Text) ? (double?)null : Convert.ToDouble(TxtValorPago.Text);
            jogo.DataCompra = string.IsNullOrWhiteSpace(DataCompra.Text) ? (DateTime?)null : Convert.ToDateTime(DataCompra.Text);
            jogo.Imagem = GravarImagemNoDisco();
            jogo.Id_Editor = Convert.ToInt32(DdlEditor.SelectedValue);
            jogo.Id_Genero = Convert.ToInt32(DdlGenero.SelectedValue);

            _jogoBo = new JogoBo();

            try
            {
                _jogoBo.InserirNovoJogo(jogo);
                
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
                    var fileName = DateTime.Now.ToString("yyyyMMddhhmmss") +"_"+ FileUploadImagem.FileName;

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

        public void CarregarTodosEditores()
        {
            _editorBo = new EditorBo();
            DdlEditor.DataSource = _editorBo.ObterTodosEditores();
            DdlEditor.DataBind();
        }

        public void CarregarTodosGeneros()
        {
            _generoBo = new GeneroBo();
            DdlGenero.DataSource = _generoBo.ObterTodosGeneros();
            DdlGenero.DataBind();
        }
    }
}