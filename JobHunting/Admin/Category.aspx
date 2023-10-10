<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="JobHunting.Admin.Category" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="adminbody" runat="server">
                <!-- Start content -->
                <div class="content">
                    <div class="container-fluid">

                        <div class="row">
                            <div class="col-12">
                                <div class="page-title-box">
                                    <h4 class="page-title float-left">Category Form </h4>

                                    <ol class="breadcrumb float-right">
                                        <li class="breadcrumb-item"><a href="#">Admin</a></li>
                                        <li class="breadcrumb-item"><a href="#">Action</a></li>
                                        <li class="breadcrumb-item active">Category Form </li>
                                    </ol>

                                    <div class="clearfix"></div>
                                </div>
                            </div>
                        </div>
                        <!-- end row -->


                        <div class="row">
                            <div class="col-12">
                            <form  id="fc" runat="server" >
                                <div class="row">
                                    
                            <div class="col-4">
                                <div class="card-box">
                                    <h4 class="m-t-0 m-b-30 header-title">Category Form</h4>

                                    
                                        <div class="form-group">
                                            <label for="exampleInputEmail1">Category name</label>
                                            <input type="text" class="form-control" id="txtcategoryname" runat="server" placeholder="Enter category name">
                                        </div>
                                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
                                        <asp:Label ID="lblResult" runat="server"></asp:Label>
                                    
                                </div>
                            </div>
                            <!-- end col -->

                            <div class="col-6">
                                
                                <div class="card-box">
                                    <h4 class="m-t-0 header-title"><b>Category Table</b></h4>
                                    <asp:GridView ID="gvCategoryList" runat="server"></asp:GridView>
                                </div>
                            </div>
                                </div>
</form>
                            </div>
                        </div>
                        <!-- end row -->
                    </div> <!-- container -->

                </div> <!-- content -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptarea" runat="server">
</asp:Content>
