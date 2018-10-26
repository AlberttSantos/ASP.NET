<%@ Page Title="" Language="C#" MasterPageFile="~/Jogos/SiteMasterPage.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="Biblioteca_Jogos.Site.Jogos.Catalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/Jogos/Catalogo.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater runat="server" ID="RepeaterJogos">
        <HeaderTemplate>Jogos</HeaderTemplate>
        <ItemTemplate>
            <div class="jogo">
                <div class="capa-jogo"></div>
                <div class="nome-jogo"><%# DataBinder.Eval(Container.DataItem, "Titulo") %></div> <!-- Pega o valor contido na coluna Titulo -->
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
