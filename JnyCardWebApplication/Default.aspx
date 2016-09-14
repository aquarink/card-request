<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="JnyCardWebApplication._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login to Access</title>
    <link href="../../Layout/Dist/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../Layout/Dist/css/navbar-fixed-top.css" rel="stylesheet" />
    <script type="text/javascript" src="../../Layout/Dist/js/jquery.min.js"></script>
    <script type="text/javascript">        window.jQuery || document.write('<script src="../../Layout/Assets/js/vendor/jquery.min.js"><\/script>')</script>
    <script type="text/javascript" src="../../Layout/Dist/js/bootstrap.min.js"></script>
</head>
<body>
    <div class="container">
        <div class="col-md-4">
        </div>
        <div class="col-md-4">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <div class="panel-body">
                        <form id="loginForm" runat="server">
                        <h2 class="form-signin-heading">
                            Please sign in</h2>
                        <label for="TxtEmail" class="sr-only">
                            Email address</label>
                        <asp:TextBox ID="TxtEmail" runat="server" CssClass="form-control" placeholder="Email address"
                            required="required" autofocus="autofocus"></asp:TextBox>
                        <hr />
                        <label for="inputPassword" class="sr-only">
                            Password</label>
                        <asp:TextBox ID="TxtPassword" runat="server" CssClass="form-control" placeholder="Password"
                            required=""></asp:TextBox>
                        <hr />
                        <asp:Label ID="msgLabel" runat="server" BackColor="#FF3300" ForeColor="White"></asp:Label>
                        <hr />
                        <asp:Button ID="LoginBtn" runat="server" CssClass="btn btn-lg btn-primary btn-block"
                            Text="Login" OnClick="LoginBtn_Click" />
                        </form>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-4">
        </div>
    </div>
</body>
</html>
