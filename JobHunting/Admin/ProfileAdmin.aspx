<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.Master" AutoEventWireup="true" CodeBehind="ProfileAdmin.aspx.cs" Inherits="JobHunting.Admin.ProfileAdmin1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="adminbody" runat="server">
    <!-- Start content -->
    <div class="content">
        <div class="container-fluid">

            <div class="row">
                <div class="col-12">
                    <div class="page-title-box">
                        <h4 class="page-title float-left">Form Wizard</h4>

                        <ol class="breadcrumb float-right">
                            <li class="breadcrumb-item"><a href="#">Adminox</a></li>
                            <li class="breadcrumb-item"><a href="#">Forms</a></li>
                            <li class="breadcrumb-item active">Form Wizard</li>
                        </ol>

                        <div class="clearfix"></div>
                    </div>
                </div>
            </div>
            <!-- end row -->


            <!-- Basic Form Wizard -->
            <div class="row">
                <div class="col-md-12">
                    <div class="card-box">
                        <form id="default-wizard">
                            <fieldset title="1">
                                <legend>User Information</legend>

                                <div class="row m-t-20">
                                    <div class="col-sm-6">

                                        <div class="form-group">
                                            <label for="username">User Name</label>
                                            <input type="text" class="form-control" id="txtUserName">
                                        </div>

                                        <div class="form-group">
                                            <label for="password">Password</label>
                                            <input type="password" class="form-control" id="txtPassword">
                                        </div>

                                        <div class="form-group">
                                            <label for="password1">Confirm Password</label>
                                            <input type="password" class="form-control" id="txtConfirmPassword" placeholder="Please Enter Confirm Password">
                                        </div>
                                    </div>
                                    <div class="col-sm-6">

                                        <div class="form-group">
                                            <label for="emailaddress">Email Address</label>
                                            <input type="email" class="form-control" id="txtEmailAddress">
                                        </div>

                                        <div class="form-group">
                                            <label for="phonenumber">Phone Number</label>
                                            <input type="text" class="form-control" id="txtPhone" placeholder="Please Enter Phone Number">
                                        </div>
                                    </div>
                                </div>

                            </fieldset>

                            <fieldset title="2">
                                <legend>User Profile</legend>

                                <div class="row m-t-20">
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <label>Date Of Birth</label>
                                            <div class="input-group">
                                                <input type="text" class="form-control" placeholder="mm/dd/yyyy" id="datepicker">
                                                <span class="input-group-addon bg-custom b-0"><i class="mdi mdi-calendar text-white"></i></span>
                                            </div>
                                            <!-- input-group -->
                                        </div>

                                        <div class="form-group">
                                            <label>Education</label>
                                            <textarea class="form-control" rows="5" id="txtEducation"></textarea>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">

                                        <div class="form-group">
                                            <label>Address</label>
                                            <input type="text" class="form-control" id="address" placeholder="">
                                        </div>

                                    </div>
                                </div>
                            </fieldset>

                            <fieldset title="3">
                                <legend>Social Profiles</legend>

                                <div class="row m-t-20">
                                    <div class="col-sm-6">

                                        <div class="form-group">
                                            <label>Facebook</label>
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="mdi mdi-facebook"></i></span>
                                                <input type="text" class="form-control" id="txtFacebook" placeholder="Facebook url">
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label>Instagram</label>
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="mdi mdi-instagram"></i></span>
                                                <input type="text" class="form-control" id="txtInstagram" placeholder="Instagram url">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <label>Twitter</label>
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="mdi mdi-twitter"></i></span>
                                                <input type="text" class="form-control" id="txtTwitter" placeholder="Twitter url">
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label>Skype</label>
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="mdi mdi-skype"></i></span>
                                                <input type="text" class="form-control" id="txtSkype" placeholder="Skype url">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </fieldset>

                            <button type="submit" class="btn btn-primary stepy-finish">Submit</button>
                        </form>

                    </div>
                </div>
            </div>

            <!-- End row -->

        </div>
        <!-- container -->

    </div>
    <!-- content -->

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptarea" runat="server">
    <!--Form Wizard-->
    <script src="adminox/plugins/jquery.stepy/jquery.stepy.min.js" type="text/javascript"></script>
    <!--wizard initialization-->
    <script src="adminox/default/assets/pages/jquery.wizard-init.js" type="text/javascript"></script>
</asp:Content>
