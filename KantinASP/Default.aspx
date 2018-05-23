<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="KantinASP.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- start: Meta -->
    <meta charset="utf-8" />
    <title>Login | PT Khoirul Mustofa</title>
    <meta name="description" content="Bootstrap Metro Dashboard" />
    <meta name="author" content="Dennis Ji" />
    <meta name="keyword" content="Metro, Metro UI, Dashboard, Bootstrap, Admin, Template, Theme, Responsive, Fluid, Retina">
    <!-- end: Meta -->
    <!-- start: Mobile Specific -->
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- end: Mobile Specific -->
    <!-- start: CSS -->
    <link href="Metro/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Metro/css/bootstrap-responsive.min.css" rel="stylesheet" />
    <link href="Metro/css/style.css" rel="stylesheet" />
    <link href="Metro/css/style-responsive.css" rel="stylesheet" />
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:300italic,400italic,600italic,700italic,800italic,400,300,600,700,800&subset=latin,cyrillic-ext,latin-ext'
        rel='stylesheet' type='text/css' />
    <!-- end: CSS -->
    <!-- The HTML5 shim, for IE6-8 support of HTML5 elements -->
    <!--[if lt IE 9]>
	  	<script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
		<link href="Metro/css/ie.css" rel="stylesheet">
	<![endif]-->
    <!--[if IE 9]>
		<link id="ie9style" href="Metro/css/ie9.css" rel="stylesheet">
	<![endif]-->
    <!-- start: Favicon -->
    <link rel="shortcut icon" href="Metro/img/avatar.jpg" />
    <!-- end: Favicon -->
    <style type="text/css">
        body
        {
            background: url(Metro/img/bg-login.jpg) !important;
        }
    </style>
</head>
<body>
    <div class="container-fluid-full">
        <div class="row-fluid">
            <div class="row-fluid">
                <div class="login-box">
                    <div class="icons">
                        <a href="#"><i class="halflings-icon home"></i></a><a href="#"><i class="halflings-icon cog">
                        </i></a>
                    </div>
                    <h2>
                        Login to your account</h2>
                    <form id="form1" runat="server" class="form-horizontal">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <fieldset>
                                <div class="input-prepend" title="Username">
                                    <span class="add-on"><i class="halflings-icon user"></i></span>
                                    <asp:TextBox ID="txtUserName" runat="server" class="input-large span10" placeholder="type username"></asp:TextBox>
                                </div>
                                <div class="clearfix">
                                </div>
                                <div class="input-prepend" title="Password">
                                    <span class="add-on"><i class="halflings-icon lock"></i></span>
                                    <asp:TextBox ID="txtPassword" runat="server" class="input-large span10" placeholder="type password"
                                        TextMode="Password"></asp:TextBox>
                                </div>
                                <div class="clearfix">
                                </div>
                                <label class="remember" for="remember">
                                    <input type="checkbox" id="remember" />Remember me</label>
                                <div class="button-login">
                                    <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary"
                                        OnClick="btnLogin_Click" />
                                </div>
                                <div class="clearfix">
                                </div>
                            </fieldset>
                            <p>
                                <asp:Label ID="lblMessege" runat="server" Text=""></asp:Label>
                            </p>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    </form>
                </div>
                <!--/span-->
            </div>
            <!--/row-->
        </div>
        <!--/.fluid-container-->
    </div>
    <!--/fluid-row-->
    <!-- start: JavaScript-->
    <script type="text/javascript" src="Metro/js/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="Metro/js/jquery-migrate-1.0.0.min.js"></script>
    <script type="text/javascript" src="Metro/js/jquery-ui-1.10.0.custom.min.js"></script>
    <script type="text/javascript" src="Metro/js/jquery.ui.touch-punch.js"></script>
    <script type="text/javascript" src="Metro/js/modernizr.js"></script>
    <script type="text/javascript" src="Metro/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="Metro/js/jquery.cookie.js"></script>
    <script type="text/javascript" src='Metro/js/fullcalendar.min.js'></script>
    <script type="text/javascript" src='Metro/js/jquery.dataTables.min.js'></script>
    <script type="text/javascript" src="Metro/js/excanvas.js"></script>
    <script type="text/javascript" src="Metro/js/jquery.flot.js"></script>
    <script type="text/javascript" src="Metro/js/jquery.flot.pie.js"></script>
    <script type="text/javascript" src="Metro/js/jquery.flot.stack.js"></script>
    <script type="text/javascript" src="Metro/js/jquery.flot.resize.min.js"></script>
    <script type="text/javascript" src="Metro/js/jquery.chosen.min.js"></script>
    <script type="text/javascript" src="Metro/js/jquery.uniform.min.js"></script>
    <script type="text/javascript" src="Metro/js/jquery.cleditor.min.js"></script>
    <script type="text/javascript" src="Metro/js/jquery.noty.js"></script>
    <script type="text/javascript" src="Metro/js/jquery.elfinder.min.js"></script>
    <script type="text/javascript" src="Metro/js/jquery.raty.min.js"></script>
    <script type="text/javascript" src="Metro/js/jquery.iphone.toggle.js"></script>
    <script type="text/javascript" src="Metro/js/jquery.uploadify-3.1.min.js"></script>
    <script type="text/javascript" src="Metro/js/jquery.gritter.min.js"></script>
    <script type="text/javascript" src="Metro/js/jquery.imagesloaded.js"></script>
    <script type="text/javascript" src="Metro/js/jquery.masonry.min.js"></script>
    <script type="text/javascript" src="Metro/js/jquery.knob.modified.js"></script>
    <script type="text/javascript" src="Metro/js/jquery.sparkline.min.js"></script>
    <script type="text/javascript" src="Metro/js/counter.js"></script>
    <script type="text/javascript" src="Metro/js/retina.js"></script>
    <script type="text/javascript" src="Metro/js/custom.js"></script>
    <!-- end: JavaScript-->
</body>
</html>
