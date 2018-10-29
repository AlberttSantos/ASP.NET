<%@ Page Title="" Language="C#" MasterPageFile="~/Jogos/SiteMasterPage.Master" AutoEventWireup="true" CodeBehind="EdicaoJogo.aspx.cs" Inherits="Biblioteca_Jogos.Site.Jogos.EdicaoJogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-left: 20px; margin-top: 30px">
        <div class="form-group">
            <label>Titulo:</label>
            <asp:TextBox runat="server" ID="TxtTitulo" CssClass="form-control col-md-4" />
            <asp:RequiredFieldValidator ID="RfvTitulo" ErrorMessage="O campo titulo é obrigatorio" ControlToValidate="TxtTitulo" runat="server" Text="*" />
        </div>
        <div class="form-row">
            <div class="form-group col-md-2">
                <label>Valor Pago:</label>
                <asp:TextBox runat="server" ID="TxtValorPago" TextMode="Number" CssClass="form-control" />
            </div>
            <div class="form-group col-md-2">
                <label>Data da compra:</label>
                <asp:TextBox runat="server" ID="DataCompra" TextMode="Date" CssClass="form-control" />
            </div>
        </div>
        <div class="form-group">
            <label>Imagem:</label>
            <asp:FileUpload runat="server" />
        </div>
        <div class="form-group">
            <label>Genero:</label>
            <asp:DropDownList runat="server" ID="DdlGenero" DataValueField="Id" DataTextField="Descricao" CssClass="form-control col-md-4" />
            <asp:RequiredFieldValidator ID="RfvGenero" ErrorMessage="O campo Genero é obrigatorio" ControlToValidate="DdlGenero" runat="server" Text="*" />
        </div>
        <div class="form-group">
            <label>Editor:</label>
            <asp:DropDownList runat="server" ID="DdlEditor" DataValueField="Id" DataTextField="Nome" CssClass="form-control col-md-4" />
            <asp:RequiredFieldValidator ID="RfvEditor" ErrorMessage="O campo Editor é obrigatorio" ControlToValidate="DdlEditor" runat="server" Text="*" />
        </div>
        <asp:Button Text="Gravar" runat="server" ID="BtnGravar" CssClass="btn btn-primary" OnClick="BtnGravar_Click" />
        <br />
        <asp:Label ID="LblStatus" runat="server" />
    </div>
    <br />
    <asp:ValidationSummary runat="server" />
</asp:Content>
