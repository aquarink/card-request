<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Hrd.aspx.cs" Inherits="JnyCardWebApplication.Hrd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>HRD | Request Card</title>
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
          <li><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/HrdCheck.aspx"><i class="glyphicon glyphicon-time"></i> Lihat Progress</asp:HyperLink></li>
          <li><asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/HrdEmployee.aspx"><i class="glyphicon glyphicon-time"></i> Employee Data</asp:HyperLink></li>
          <li class="active"><asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Hrd.aspx"><i class="glyphicon glyphicon-plus"></i> Request New Card</asp:HyperLink></li>
          </ul>
          <ul class="nav navbar-nav navbar-right">
            <li><a href="../navbar-static-top/"><i class="glyphicon glyphicon-log-out"></i> Logout</a></li>
          </ul>
        </div>
      </div>
    </nav>
    <div class="container">
        <div class="row">
            <div class="col-md-2">
            </div>
            <div class="col-md-8">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="panel-body">
                            <form id="newEmployeeForm" runat="server">
                            <h2 class="form-signin-heading">
                                Request Employee Card</h2>
                            <label>
                                ID Employee</label>
                            <asp:TextBox ID="TxtIdEmployee" runat="server" CssClass="form-control" placeholder="Eployee ID"
                                required="required" autofocus="autofocus"></asp:TextBox>
                            <hr />
                            <label>
                                Name</label>
                            <asp:TextBox ID="TxtName" runat="server" CssClass="form-control" placeholder="Employee Name"
                                required="required"></asp:TextBox>
                            <hr />
                            <asp:Label ID="msgLabel" runat="server" BackColor="#FF3300" ForeColor="White"></asp:Label>
                            <hr />
                            <asp:Button ID="NewEmployee" runat="server" CssClass="btn btn-lg btn-success btn-block"
                                Text="Submit" OnClick="NewEmployee_Click" />
                            </form>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-2">
            </div>
        </div>
    </div>
</body>
</html>
