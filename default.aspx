<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="SMS._default" %>

<!DOCTYPE html>

<html lang="en">

    <head>

        <meta charset="utf-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <title>SMS</title>

        <!-- CSS -->
        <link rel="stylesheet" href="assets/css/style1.css">
        <link rel="stylesheet" href="assets/bootstrap/css/bootstrap.min.css">
        <link rel="stylesheet" href="assets/font-awesome/css/font-awesome.min.css">
		<link rel="stylesheet" href="assets/css/form-elements.css">
        <link rel="stylesheet" href="assets/css/style.css">

        <!-- Favicon and touch icons -->
        <link rel="shortcut icon" href="assets/ico/favicon.png">
        <link rel="apple-touch-icon-precomposed" sizes="144x144" href="assets/ico/apple-touch-icon-144-precomposed.png">
        <link rel="apple-touch-icon-precomposed" sizes="114x114" href="assets/ico/apple-touch-icon-114-precomposed.png">
        <link rel="apple-touch-icon-precomposed" sizes="72x72" href="assets/ico/apple-touch-icon-72-precomposed.png">
        <link rel="apple-touch-icon-precomposed" href="assets/ico/apple-touch-icon-57-precomposed.png">

    </head>

    <body>

        <!-- Top content -->
        <div class="top-content">
        	
            <div class="inner-bg">
                <div class="container">
                    <div class="row">
                        <div class="col-sm-8 col-sm-offset-2 text">
                            <h1><strong>Welcome</strong> To School Management System</h1>
                            <div class="description">
                            	<p>
	                            	<strong>Smruti Ranjan Raut</strong>
                            	</p>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-6 col-sm-offset-3 form-box">
                        	<div class="form-top">
                        		<div class="form-top-left">
                        			<h3>Login</h3>
                            		<p>Enter your username and password to log on:</p>
                        		</div>
                        		<div class="form-top-right">
                        			<i class="fa fa-key"></i>
                        		</div>
                            </div>
                            <div class="form-bottom">
			                    <form role="form" runat="server" action="" method="post" class="login-form">
			                    	<div class="form-group">
			                    		<asp:Label ID="lblUserName" runat="server" style="font-family:Verdana; font-weight:bold" Text="Email"></asp:Label>
                                         &nbsp;&nbsp;
			                            <asp:TextBox ID="txtUsername" runat="server" AutoCompleteType="Disabled" placeholder="Username..." CssClass="form-username form-control"></asp:TextBox>
                                    </div>
			                        <div class="form-group">
			                        	<asp:Label ID="lblPassword" runat="server" style="font-family:Verdana; font-weight:bold" Text="Password"></asp:Label>
                                         &nbsp;&nbsp;
                                        <asp:TextBox ID="txtPassword" runat="server" placeholder="Password..." CssClass="form-password form-control" TextMode="Password"></asp:TextBox>
                                        <asp:Label ID="lblMessage" runat="server" style="font-family:'Times New Roman'; font-weight:bold; color:brown;" Text=""></asp:Label>
			                        </div>
                                    <center>
                                        <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-success" type="submit" Text="Sign in!" OnClick="btnSubmit_Click" />
                                    </center>
			                    </form>
		                    </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-6 col-sm-offset-3 social-login">
                        	<font face="verdana" size="3" color ="white" bold="true">© 2018 KC Consultancy Service</font>
                        </div>
                    </div>
                </div>
            </div>
            
        </div>

        <!-- Javascript -->
        <script src="assets/js/jquery-1.11.1.min.js"></script>
        <script src="assets/bootstrap/js/bootstrap.min.js"></script>
        <script src="assets/js/jquery.backstretch.min.js"></script>
        <script src="assets/js/scripts.js"></script>

    </body>

</html>
