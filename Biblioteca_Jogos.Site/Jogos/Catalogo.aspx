<%@ Page Title="" Language="C#" MasterPageFile="~/Jogos/SiteMasterPage.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="Biblioteca_Jogos.Site.Jogos.Catalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/Jogos/Catalogo.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 style="margin-top: 50px; margin-left: 10px" > Catálogo de Jogos</h2>
    <hr />
    <asp:Repeater runat="server" ID="RepeaterJogos">
        <HeaderTemplate></HeaderTemplate>
        <ItemTemplate>
            <div class="jogo" onclick="redirecionarParaPerfil('<%= Session["Perfil"].ToString() %>', <%# DataBinder.Eval(Container.DataItem, "Id") %>)">
                <div class="capa-jogo">
                    <img src="../Content/ImagensJogos/<%# DataBinder.Eval(Container.DataItem, "Imagem") %>" alt="<%# DataBinder.Eval(Container.DataItem, "Titulo") %>" />
                </div>
                <div class="nome-jogo"><%# DataBinder.Eval(Container.DataItem, "Titulo") %></div>
                <!-- Pega o valor contido na coluna Titulo -->
            </div>
        </ItemTemplate>
    </asp:Repeater>

    <script>    
        function redirecionarParaPerfil(perfil, id) {
            if (perfil == "A")
            {
                top.location.href = "EdicaoJogo.aspx?id="+id;
            }
            else
            {
                top.location.href = "DetalhesJogo.aspx?id="+id;
            }
        }
    </script>
</asp:Content>
