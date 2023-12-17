<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signUp.aspx.cs" Inherits="JobHunting.signUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Sign Up</title>
    <link href="lib/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Site3/nicepage.css" rel="stylesheet" />
    <link href="Site3/Home.css" rel="stylesheet" />
    <script src="Site3/jquery.js"></script>
    <script src="Site3/nicepage.js"></script>

    <!-- Message alert -->
    <style type="text/css">
        .messagealert {
            width: 100%;
            position: absolute;
            top: 40%;
            z-index: 999;
            padding: 0;
            font-size: 15px;
            text-align: center;
        }
    </style>
</head>
<body runat="server">
    <div class="content">
        <section class="u-clearfix u-container-align-center-sm u-container-align-center-xs u-image u-section-5" id="carousel_359f" data-image-width="2000" data-image-height="1125">
            <div class="u-clearfix u-sheet u-sheet-1">
                <h3>MoMiji</h3>
                <h3 class="u-text u-text-default u-text-1">Sign Up</h3>
                <div class="u-form u-white u-form-1">
                    <form runat="server" id="f1" style="padding: 19px;">
                        <div id="messagealert" class="alert alert-danger alert-dismissible fade in" runat="server" style="margin: 0 0.5%; -webkit-box-shadow: 3px 4px 6px #999;" visible="false">
                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                            <strong>
                                <asp:Label ID="lblMessage" runat="server"></asp:Label></strong>
                        </div>
                        <div class="u-form-user u-form-group">
                            <label>User Name</label>
                            <input type="text" placeholder="Enter your User Name" id="txtUserName" runat="server" class="u-border-none u-input u-input-rectangle u-palette-3-light-3 u-radius-10" required="" />
                        </div>
                        <div class="u-form-email u-form-group">
                            <label>Email</label>
                            <input type="email" placeholder="Enter your Email Address" id="txtEmail" runat="server" class="u-border-none u-input u-input-rectangle u-palette-3-light-3 u-radius-10" required="" />
                        </div>
                        <div class="u-form-password u-form-group">
                            <label>Password</label>
                            <input type="password" placeholder="Enter Password" id="txtPassword" runat="server" class="u-border-none u-input u-input-rectangle u-palette-3-light-3 u-radius-10" required="" />
                        </div>
                        <div class="u-form-password u-form-group">
                            <label>Re-Password</label>
                            <input type="password" placeholder="Enter Re Password" id="txtRePassword" runat="server" class="u-border-none u-input u-input-rectangle u-palette-3-light-3 u-radius-10" required="" />
                        </div>
                        <div class="u-form-group">
                            <%--<div class="u-align-left">
             <input type="checkbox" runat="server" id="chkAdmin" value="On" class="u-field-input" />
                <label class="u-label">Is Admin</label>
            </div>--%>
                            <div class="u-align-right">
                                <asp:Button ID="Button1" runat="server" Text="SignUp" OnClick="Button1_Click" CssClass="btn btn-primary btn-rounded w-md waves-light" />
                                <p>Already Have account? <a href="login.aspx">Login</a></p>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </section>
    </div>
</body>
</html>
