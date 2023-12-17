<%@ Page Title="" Language="C#" MasterPageFile="~/Job.Master" AutoEventWireup="true" CodeBehind="joblist.aspx.cs" Inherits="JobHunting.joblist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="jobbody" runat="server">
    <!-- HOME -->

    <section class="home-section section-hero overlay bg-image" style="background-image: url('jobboard/images/hero_1.jpg');" id="home-section">

        <div class="container">
            <div class="row align-items-center justify-content-center">
                <div class="col-md-12">
                    <div class="mb-5 text-center">
                        <h1 class="text-white font-weight-bold">The Easiest Way To Get Your Dream Job</h1>
                    </div>
                    <form runat="server" id="fjoblist" class="search-jobs-form">
                        <div class="row mb-5">
                            <div class="col-12 col-sm-6 col-md-6 col-lg-3 mb-4 mb-lg-0">
                                <input type="text" class="form-control form-control-lg" placeholder="Job title, Company..." runat="server" id="txtcompanyname">
                            </div>
                            <div class="col-12 col-sm-6 col-md-6 col-lg-3 mb-4 mb-lg-0">
                                <asp:DropDownList ID="ddlCountry" CssClass="selectpicker" runat="server" data-style="btn-white btn-lg" data-width="100%" data-live-search="true"></asp:DropDownList>
                            </div>
                            <div class="col-12 col-sm-6 col-md-6 col-lg-3 mb-4 mb-lg-0">
                                <asp:DropDownList ID="ddlJobRole" CssClass="selectpicker" runat="server" data-style="btn-white btn-lg" data-width="100%" data-live-search="true"></asp:DropDownList>
                            </div>
                            <div class="col-12 col-sm-6 col-md-6 col-lg-3 mb-4 mb-lg-0">
                                <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn btn-primary btn-lg btn-block text-white btn-search" OnClick="lbtnSearch_Click"><span class="icon-search icon mr-2"></span>&nbsp;Search Job</asp:LinkButton>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12 popular-keywords">
                                <h3>Trending Keywords:</h3>
                                <ul class="keywords list-unstyled m-0 p-0">
                                    <li><a href="#" class="">UI Designer</a></li>
                                    <li><a href="#" class="">Python</a></li>
                                    <li><a href="#" class="">Developer</a></li>
                                </ul>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>

        <%-- <a href="#next" class="scroll-button smoothscroll">
        <span class=" icon-keyboard_arrow_down"></span>
      </a>--%>
    </section>

    <section class="site-section">
        <div class="container">
            <div class="row mb-5 justify-content-center">
                <div class="col-md-7 text-center">
                    <h2 class="section-title mb-2"><%=CountData()%> Job Listed</h2>
                </div>
            </div>
            <ul class="job-listings mb-5">
                <% foreach (var res in jobAllList)
                    { %>
                <li class="job-listing d-block d-sm-flex pb-3 pb-sm-0 align-items-center">
                    <input type="hidden" id="jobid" value="<%=res.JobID%>" />
                    <a href="#" onclick="ShowData();"></a>
                    <div class="job-listing-logo">
                        <img id="comIMG" src="data:image/jpeg;base64,<%=res.CompanyImage%>" alt="Free Website Template by Free-Template.co" class="img-fluid" />
                    </div>
                    <div class="job-listing-about d-sm-flex custom-width w-100 justify-content-between mx-4">
                        <div class="job-listing-position custom-width w-50 mb-3 mb-sm-0">
                            <h2><%=res.JobPositionName%></h2>
                            <strong id="companyname"><%=res.CompanyName%></strong>
                        </div>
                        <div class="job-listing-location mb-3 mb-sm-0 custom-width w-25">
                            <span class="icon-room"></span><%=res.JobStreetAddress%> , <%=res.CityName%> , <%=res.CountryName%>
                        </div>
                        <div class="job-listing-meta">
                            <% if (res.JobRoleName == "Full Time")
                                { %>
                            <span class="badge badge-success"><%=res.JobRoleName%></span>
                            <%  } %>
                            <% else
                                { %>
                            <span class="badge badge-danger"><%=res.JobRoleName%></span>
                            <%  } %>
                        </div>
                    </div>
                </li>
                <%  } %>
            </ul>
            <div class="row pagination-wrap">
                <div class="col-md-6 text-center text-md-left mb-4 mb-md-0">
                    <span>Showing 1-7 Of <%=CountData()%> Jobs</span>
                </div>
                <div class="col-md-6 text-center text-md-right">
                    <div class="custom-pagination ml-auto">
                        <a href="#" class="prev">Prev</a>
                        <div class="d-inline-block">
                            <a href="#" class="active">1</a>
                            <a href="#">2</a>
                            <a href="#">3</a>
                            <a href="#">4</a>
                        </div>
                        <a href="#" class="next">Next</a>
                    </div>
                </div>
            </div>

        </div>
    </section>

    <section class="py-5 bg-image overlay-primary fixed overlay" style="background-image: url('images/hero_1.jpg');">
        <div class="container">
            <div class="row align-items-center">
                <div class="col-md-8">
                    <h2 class="text-white">Looking For A Job?</h2>
                    <p class="mb-0 text-white lead">Lorem ipsum dolor sit amet consectetur adipisicing elit tempora adipisci impedit.</p>
                </div>
                <div class="col-md-3 ml-auto">
                    <a href="signUp.aspx" class="btn btn-warning btn-block btn-lg">Sign Up</a>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptarea" runat="server">
</asp:Content>
