<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Biblioteca_Jogos.Site.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center; margin-top: 200px">
            <div>
                <div>Usuário</div>
                <asp:TextBox ID="TxtUsuario" runat="server"></asp:TextBox>
            </div>
            <br />
            <div>
                <div>Senha</div>
                <asp:TextBox ID="TxtSenha" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <br /> 
            <div>
                <asp:Button class="btn btn-outline-success" ID="btnLogin" Text="Entrar" runat="server" OnClick="btnLogin_Click" />
            </div>
            <br />  
            <div>   
                <asp:Label ID="LblStatus" runat="server"> </asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
