<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HrdCheck.aspx.cs" Inherits="JnyCardWebApplication.HrdCheck" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>HRD | History Request Card</title>
    <link href="../../Layout/Dist/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../Layout/Dist/css/navbar-fixed-top.css" rel="stylesheet" />
    <script type="text/javascript" src="../../Layout/Dist/js/jquery.min.js"></script>
    <script type="text/javascript">        window.jQuery || document.write('<script src="../../Layout/Assets/js/vendor/jquery.min.js"><\/script>')</script>
    <script type="text/javascript" src="../../Layout/Dist/js/bootstrap.min.js"></script>
</head>
<body>
    <nav class="navbar navbar-default navbar-fixed-top">
      <div class="container">
        <div class="navbar-header">
          <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
            <span class="sr-only">Toggle navigation</span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
          </button>
          <a class="navbar-brand" href="#">JNY EMPLOYEE CARD REQUEST</a>
        </div>
        <div id="navbar" class="navbar-collapse collapse">
          <ul class="nav navbar-nav">
          <li class="active"><asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/HrdCheck.aspx"><i class="glyphicon glyphicon-time"></i> Lihat Progress</asp:HyperLink></li>
          <li><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/HrdEmployee.aspx"><i class="glyphicon glyphicon-time"></i> Employee Data</asp:HyperLink></li>
          <li><asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Hrd.aspx"><i class="glyphicon glyphicon-plus"></i> Request New Card</asp:HyperLink></li>
          </ul>
          <ul class="nav navbar-nav navbar-right">
            <li><a href="../navbar-static-top/"><i class="glyphicon glyphicon-log-out"></i> Logout</a></li>
          </ul>
        </div>
      </div>
    </nav>
    <form id="form1" runat="server">
    <div class="container">
        <div class="row">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <div class="panel-body">
                        <h2 class="form-signin-heading">
                            History of Request Employee Card</h2>
                        <asp:PlaceHolder ID="HistoryPlaceHolder" runat="server"></asp:PlaceHolder>
                        <hr />
                        <asp:Label ID="LabelHistory" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
