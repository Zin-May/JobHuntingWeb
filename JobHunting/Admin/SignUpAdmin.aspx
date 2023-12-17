<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUpAdmin.aspx.cs" Inherits="JobHunting.Admin.SignUpAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <!-- App favicon -->
    <link rel="shortcut icon" href="adminox/default/assets/images/favicon.ico" />

    <!-- App css -->
    <link href="adminox/default/assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="adminox/default/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link href="adminox/default/assets/css/style.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body class="bg-accpunt-pages">
    <!-- HOME -->
    <section class="u-clearfix u-container-align-center-sm u-container-align-center-xs u-image u-section-5" data-image-width="2000" data-image-height="1125">
        <div class="container">
            <div class="row">
                <div class="col-sm-12">

                    <div class="wrapper-page">

                        <div class="account-pages">
                            <div class="account-box">

                                <div class="account-content">
                                    <form class="form-horizontal" runat="server">

                                        <div id="messagealert" runat="server" visible="false">
                                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                            <strong>
                                                <asp:Label ID="lblResult" runat="server"></asp:Label></strong>
                                        </div>

                                        <div class="form-group row m-b-20">
                                            <div class="col-12">
                                                <label>User Name</label>
                                                <input class="form-control" type="text" runat="server" id="txtUserName" required="" placeholder="Enter User Name" />
                                            </div>
                                        </div>

                                        <div class="form-group row m-b-20">
                                            <div class="col-12">
                                                <label>Email address</label>
                                                <input class="form-control" type="email" runat="server" id="txtEmail" required="" placeholder="john@deo.com" />
                                            </div>
                                        </div>

                                        <div class="form-group row m-b-20">
                                            <div class="col-12">
                                                <label>Password</label>
                                                <input class="form-control" type="password" runat="server" required="" id="txtPassword" placeholder="Enter Your Password" />
                                            </div>
                                        </div>

                                        <div class="form-group row m-b-20">
                                            <div class="col-12">
                                                <label>Confirm Password</label>
                                                <input class="form-control" type="password" runat="server" required="" id="txtConfirmPassword" placeholder="Enter Your Confirm Password" />
                                            </div>
                                        </div>

                                        <div class="form-group row m-b-20">
                                            <div class="col-12">

                                                <div class="checkbox checkbox-success">
                                                    <input id="remember" type="checkbox" checked="" />
                                                    <label for="remember">
                                                        I accept <a href="#">Terms and Conditions</a>
                                                    </label>
                                                </div>

                                            </div>
                                        </div>

                                        <div class="form-group row text-center m-t-10">
                                            <div class="col-12">
                                                <asp:Button ID="btnSignUp" CssClass="btn-md btn-block btn-primary waves-light" runat="server" Text="SignUp" OnClick="btnSignUp_Click" />
                                            </div>
                                        </div>

                                    </form>

                                    <div class="row m-t-50">
                                        <div class="col-12 text-center">
                                            <p class="text-muted">Already have an account?  <a href="../login" class="text-dark m-l-5"><b>Sign In</b></a></p>
                                        </div>
                                    </div>

                                </div>
                            </div>
                            <!-- end card-box-->
                        </div>


                    </div>
                    <!-- end wrapper -->

                </div>
            </div>
        </div>
    </section>
    <!-- END HOME -->
    <script>
        var resizefunc = [];
    </script>

    <!-- jQuery  -->
    <script src="adminox/default/assets/js/jquery.min.js"></script>
    <script src="adminox/default/assets/js/tether.min.js"></script>
    <!-- Tether for Bootstrap -->
    <script src="adminox/default/assets/js/bootstrap.min.js"></script>
    <script src="adminox/default/assets/js/waves.js"></script>
    <script src="adminox/default/assets/js/jquery.slimscroll.js"></script>
</body>
</html>
