<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.Master" AutoEventWireup="true" CodeBehind="indexadmin.aspx.cs" Inherits="JobHunting.Admin.indexadmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- C3 charts css -->
    <link href="adminox/plugins/c3/c3.min.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="adminbody" runat="server">

    <!-- Start content -->
    <div class="content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-12">
                    <div class="page-title-box">
                        <h4 class="page-title float-left">Dashboard 2</h4>
                        <ol class="breadcrumb float-right">
                            <li class="breadcrumb-item"><a href="#">Adminox</a></li>
                            <li class="breadcrumb-item"><a href="#">Dashboard</a></li>
                            <li class="breadcrumb-item active">Dashboard 2</li>
                        </ol>
                        <div class="clearfix"></div>
                    </div>
                </div>
            </div>
            <!-- end row -->

            <div class="row">
                <div class="col-lg-8">
                    <div class="row">
                        <div class="col-sm-4">
                            <div class="card-box widget-box-four">
                                <div id="dashboard-1" class="widget-box-four-chart"></div>
                                <div class="wigdet-four-content pull-left">
                                    <h2 class="m-t-0 font-16 font-600 m-b-5 text-overflow" title="Total Unique Visitors">Job Type</h2>
                                    <p></p>
                                    <% foreach (var res in GetAllJobRole())
                                        { %>
                                    <p class="font-secondary text-muted"><%=res.JobRoleName%></p>
                                    <%  } %>
                                </div>
                                <div class="clearfix"></div>
                            </div>
                        </div>
                        <!-- end col -->

                        <div class="col-sm-4">
                            <div class="card-box widget-box-four">
                                <div id="dashboard-2" class="widget-box-four-chart"></div>
                                <div class="wigdet-four-content pull-left">
                                    <h3 class="m-t-0 font-16 font-600 m-b-5 text-overflow" title="Total Unique Visitors">Job Role</h3>
                                    <p></p>
                                    <% foreach (var res in GetAllJobType())
                                        { %>
                                    <p class="font-secondary text-muted"><%=res.JobTypeName%></p>
                                    <%  } %>
                                </div>
                                <div class="clearfix"></div>
                            </div>
                        </div>
                        <!-- end col -->

                        <div class="col-sm-4">
                            <div class="card-box widget-box-four">
                                <div id="dashboard-3" class="widget-box-four-chart"></div>
                                <div class="wigdet-four-content pull-left">
                                    <h4 class="m-t-0 font-16 font-600 m-b-5 text-overflow" title="Number of Transactions">Number of Transactions</h4>
                                    <p class="font-secondary text-muted">Jan - Apr 2017</p>
                                    <h3 class="m-b-0 m-t-20 font-600"><span>$</span> <span data-plugin="counterup">28,5960</span></h3>
                                </div>
                                <div class="clearfix"></div>
                            </div>
                        </div>
                        <!-- end col -->

                    </div>
                    <!-- end row -->
                    <div class="row">
                        <div class="col-12">
                            <div class="card-box">
                                <h4 class="header-title m-t-0">Company</h4>
                                <div class="text-center">
                                    <div class="row">
                                        <% foreach (var res in GetAllJob())
                                            { %>
                                        <div class="col-4">
                                            <div class="m-t-20 m-b-20">
                                                <div class="company-card card-box">
                                                    <img src="assets/images/companies/apple.png" alt="logo" class="company-logo">
                                                    <p class="text-uppercase m-b-5 font-13 font-600"><%=res.CompanyName%></p>
                                                </div>
                                            </div>
                                        </div>
                                        <%  } %>
                                    </div>
                                </div>
                                <div id="morris-bar-stacked" style="height: 310px;"></div>
                            </div>
                        </div>
                        <!-- end col -->
                    </div>
                    <!-- end row -->
                </div>
                <!-- end col -->


                <div class="col-lg-4">
                    <div class="card-box text-center">
                        <div class="text-center">
                            <h3 class="font-normal text-muted">Category</h3>
                            <p></p>
                            <% foreach (var res in GetAllCategory())
                                { %>
                            <h5 class="m-b-30"><i class="mdi mdi-arrow-up-bold-hexagon-outline text-success"></i><%=res.CategoryName%></h5>
                            <%  } %>
                        </div>
                        <div id="morris-line-example" style="height: 180px;"></div>
                    </div>


                    <div class="card-box">
                        <h4 class="header-title m-t-0 m-b-15">Recent Notifications</h4>
                        <div class="m-b-15">
                            <p><span class="pull-right text-dark">Mark Loyerdn</span> <span class="label label-primary">Visitor</span></p>
                            <p class="font-13 m-b-5">Praesent libero. Nunc nec dui vitae urna cursus lacinia. In venenatis eget justo in dictum. Vestibulum auctor raesent quisnm.</p>
                            <p class="font-13"><i>2 Min ago</i></p>
                        </div>
                        <div class="">
                            <p><span class="pull-right text-dark">Mark Loyerdn</span> <span class="label label-success">Seller</span></p>
                            <p class="font-13 m-b-5">Praesent libero. Nunc nec dui vitae urna cursus lacinia. In venenatis eget justo in dictum. Vestibulum auctor raesent quisnm.</p>
                            <p class="font-13 m-b-0"><i>5 Hours ago</i></p>
                        </div>
                    </div>
                </div>
                <!-- end col -->

            </div>
            <!-- end row -->


            <div class="row">
                <div class="col-12">
                    <div class="card-box">
                        <h4 class="m-t-0 header-title"><b>Job List</b></h4>

                        <div class="table-responsive">
                            <table class="table m-0 table-colored table-primary table-hover">
                                <thead>
                                    <tr>
                                        <th hidden>JobID</th>
                                        <th>Company</th>
                                        <th>JobRole</th>
                                        <th>JobType</th>
                                        <th>Category</th>
                                        <th>JobLocation</th>
                                        <th>JobPosition</th>
                                        <th>Allowence</th>
                                        <th>Salary</th>
                                        <th>Status</th>
                                        <th>CreatedDate</th>
                                        <th>UpdatedDate</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <% foreach (var res in GetAllJob())
                                        { %>
                                    <tr>
                                        <td class="jid" hidden><%=res.JobID %></td>
                                        <td class="cid"><%=res.CompanyName%></td>
                                        <td class="jrid"><%=res.JobRoleName%></td>
                                        <td class="jtid"><%=res.JobTypeName%></td>
                                        <td class="caid"><%=res.CategoryName%></td>
                                        <td class="jlid"><%=res.JobStreetAddress%> , <%=res.CityName%> , <%=res.CountryName%></td>
                                        <td class="jpid"><%=res.JobPositionName%></td>
                                        <td class="allow"><%=res.Allowence%></td>
                                        <td class="salary"><%=res.Salary%></td>
                                        <td class="status"><%=res.Status%></td>
                                        <td class="cdate"><%=res.CreatedDate%></td>
                                        <td class="udate"><%=res.UpdatedDate%></td>
                                    </tr>
                                    <%  } %>
                                </tbody>
                            </table>

                        </div>
                    </div>
                </div>
            </div>
            <!-- end row -->

        </div>
        <!-- container -->

    </div>
    <!-- content -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptarea" runat="server">
    <!-- Counter js  -->
    <script src="adminox/plugins/waypoints/jquery.waypoints.min.js"></script>
    <script src="adminox/plugins/counterup/jquery.counterup.min.js"></script>

    <!--C3 Chart-->
    <script type="text/javascript" src="adminox/plugins/d3/d3.min.js"></script>
    <script type="text/javascript" src="adminox/plugins/c3/c3.min.js"></script>

    <!--Echart Chart-->
    <script src="adminox/plugins/echart/echarts-all.js"></script>

    <!-- Dashboard init -->
    <script src="adminox/default/assets/pages/jquery.dashboard.js"></script>
</asp:Content>
