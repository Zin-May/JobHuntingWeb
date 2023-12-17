<%@ Page Title="" Language="C#" MasterPageFile="~/Job.Master" AutoEventWireup="true" CodeBehind="jobsingle.aspx.cs" Inherits="JobHunting.jobsingle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="jobbody" runat="server">
    <!-- HOME -->
    <section class="section-hero overlay inner-page bg-image" style="background-image: url('jobboard/images/hero_1.jpg');" id="home-section">
        <div class="container">
            <% foreach (var res in jList)
                { %>
            <div class="row">
                <div class="col-md-7">
                    <h1 class="text-white font-weight-bold"><%=res.JobPositionName%></h1>
                    <div class="custom-breadcrumbs">
                        <a href="#">Home</a> <span class="mx-2 slash">/</span>
                        <a href="#">Job</a> <span class="mx-2 slash">/</span>
                        <span class="text-white"><strong><%=res.JobPositionName%></strong></span>
                    </div>
                </div>
            </div>
            <%  } %>
        </div>
    </section>
    <section class="site-section">
        <div class="container">
            <form id="fjs" runat="server">
                <div class="row align-items-center mb-5">
                    <div class="col-lg-8 mb-4 mb-lg-0">
                        <% foreach (var res in jList)
                            { %>
                        <div class="d-flex align-items-center">
                            <div class="border p-2 d-inline-block mr-3 rounded">
                                <img src="data:image/jpeg;base64,<%=res.CompanyImage%>" alt="Image">
                            </div>
                            <div>
                                <h2><%=res.JobPositionName%></h2>
                                <div>
                                    <span class="ml-0 mr-2 mb-2"><span class="icon-briefcase mr-2"></span><%=res.CompanyName%></span>
                                    <span class="m-2"><span class="icon-room mr-2"></span><%=res.CityName%></span>
                                    <span class="m-2"><span class="icon-clock-o mr-2"></span><span class="text-primary"><%=res.JobRoleName%></span></span>
                                </div>
                            </div>
                        </div>
                        <%  } %>
                    </div>
                    <div class="col-lg-4">
                        <div class="row">
                            <div class="col-6">
                                <a href="#" class="btn btn-block btn-light btn-md"><span class="icon-heart-o mr-2 text-danger"></span>Save Job</a>
                            </div>
                            <div class="col-6">
                                <asp:Button ID="btnApply" runat="server" Text="Apply Now" onClick="btnApply_Click" CssClass="btn btn-block btn-primary btn-md" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-8">
                        <div class="mb-5">
                            <figure class="mb-5">
                                <img src="jobboard/images/job_single_img_1.jpg" alt="Image" class="img-fluid rounded">
                            </figure>
                            <h3 class="h5 d-flex align-items-center mb-4 text-primary"><span class="icon-align-left mr-3"></span>Job Description</h3>
                            <% foreach (var res in jList)
                                { %>
                            <p><%=res.JobDescription%></p>
                            <%  } %>
                        </div>
                        <div class="mb-5">
                            <h3 class="h5 d-flex align-items-center mb-4 text-primary"><span class="icon-rocket mr-3"></span>Responsibilities</h3>
                            <% foreach (var res in jList)
                                { %>
                            <p><%=res.JobDescription%></p>
                            <%  } %>
                            <%-- <ul class="list-unstyled m-0 p-0">
                            <li class="d-flex align-items-start mb-2"><span class="icon-check_circle mr-2 text-muted"></span><span>Necessitatibus quibusdam facilis</span></li>
                            <li class="d-flex align-items-start mb-2"><span class="icon-check_circle mr-2 text-muted"></span><span>Velit unde aliquam et voluptas reiciendis n Velit unde aliquam et voluptas reiciendis non sapiente labore</span></li>
                            <li class="d-flex align-items-start mb-2"><span class="icon-check_circle mr-2 text-muted"></span><span>Commodi quae ipsum quas est itaque</span></li>
                            <li class="d-flex align-items-start mb-2"><span class="icon-check_circle mr-2 text-muted"></span><span>Lorem ipsum dolor sit amet, consectetur adipisicing elit</span></li>
                            <li class="d-flex align-items-start mb-2"><span class="icon-check_circle mr-2 text-muted"></span><span>Deleniti asperiores blanditiis nihil quia officiis dolor</span></li>
                        </ul>--%>
                        </div>

                        <%-- <div class="mb-5">
                        <h3 class="h5 d-flex align-items-center mb-4 text-primary"><span class="icon-book mr-3"></span>Education + Experience</h3>
                        <ul class="list-unstyled m-0 p-0">
                            <li class="d-flex align-items-start mb-2"><span class="icon-check_circle mr-2 text-muted"></span><span>Necessitatibus quibusdam facilis</span></li>
                            <li class="d-flex align-items-start mb-2"><span class="icon-check_circle mr-2 text-muted"></span><span>Velit unde aliquam et voluptas reiciendis non sapiente labore</span></li>
                            <li class="d-flex align-items-start mb-2"><span class="icon-check_circle mr-2 text-muted"></span><span>Commodi quae ipsum quas est itaque</span></li>
                            <li class="d-flex align-items-start mb-2"><span class="icon-check_circle mr-2 text-muted"></span><span>Lorem ipsum dolor sit amet, consectetur adipisicing elit</span></li>
                            <li class="d-flex align-items-start mb-2"><span class="icon-check_circle mr-2 text-muted"></span><span>Deleniti asperiores blanditiis nihil quia officiis dolor</span></li>
                        </ul>
                    </div>

                    <div class="mb-5">
                        <h3 class="h5 d-flex align-items-center mb-4 text-primary"><span class="icon-turned_in mr-3"></span>Other Benifits</h3>
                        <ul class="list-unstyled m-0 p-0">
                            <li class="d-flex align-items-start mb-2"><span class="icon-check_circle mr-2 text-muted"></span><span>Necessitatibus quibusdam facilis</span></li>
                            <li class="d-flex align-items-start mb-2"><span class="icon-check_circle mr-2 text-muted"></span><span>Velit unde aliquam et voluptas reiciendis non sapiente labore</span></li>
                            <li class="d-flex align-items-start mb-2"><span class="icon-check_circle mr-2 text-muted"></span><span>Commodi quae ipsum quas est itaque</span></li>
                            <li class="d-flex align-items-start mb-2"><span class="icon-check_circle mr-2 text-muted"></span><span>Lorem ipsum dolor sit amet, consectetur adipisicing elit</span></li>
                            <li class="d-flex align-items-start mb-2"><span class="icon-check_circle mr-2 text-muted"></span><span>Deleniti asperiores blanditiis nihil quia officiis dolor</span></li>
                        </ul>
                    </div>--%>

                        <div class="row mb-5">
                            <div class="col-6">
                                <a href="#" class="btn btn-block btn-light btn-md"><span class="icon-heart-o mr-2 text-danger"></span>Save Job</a>
                            </div>
                            <div class="col-6">
                                <%--<asp:Button ID="btnApplyNow" runat="server" Text="Apply Now" OnClick="btnApplyNow_Click" CssClass="btn btn-block btn-primary btn-md" />--%>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="bg-light p-3 border rounded mb-4">
                            <h3 class="text-primary  mt-3 h5 pl-3 mb-3 ">Job Summary</h3>
                            <ul class="list-unstyled pl-3 mb-0">
                                <% foreach (var res in jList)
                                    { %>
                                <li class="mb-2"><strong class="text-black">Employment Status:</strong> <%=res.JobRoleName%></li>
                                <%--<li class="mb-2"><strong class="text-black">Experience:</strong> 2 to 3 year(s)</li>--%>
                                <li class="mb-2"><strong class="text-black">Job Location:</strong> <%=res.CityName%> , <%=res.CountryName%></li>
                                <li class="mb-2"><strong class="text-black">Salary:</strong> <%=res.Salary%></li>
                                <%  } %>
                            </ul>
                        </div>

                        <div class="bg-light p-3 border rounded">
                            <h3 class="text-primary  mt-3 h5 pl-3 mb-3 ">Share</h3>
                            <div class="px-3">
                                <a href="#" class="pt-3 pb-3 pr-3 pl-0"><span class="icon-facebook"></span></a>
                                <a href="#" class="pt-3 pb-3 pr-3 pl-0"><span class="icon-twitter"></span></a>
                                <a href="#" class="pt-3 pb-3 pr-3 pl-0"><span class="icon-linkedin"></span></a>
                                <a href="#" class="pt-3 pb-3 pr-3 pl-0"><span class="icon-pinterest"></span></a>
                            </div>
                        </div>

                    </div>
                </div>
            </form>
        </div>
    </section>

    <section class="site-section" id="next">
        <div class="container">
            <div class="row mb-5 justify-content-center">
                <div class="col-md-7 text-center">
                    <h2 class="section-title mb-2"><%=CountData()%> Job Listed</h2>
                </div>
            </div>
            <ul class="job-listings mb-5">
                <% foreach (var res in relatedList)
                    { %>
                <li class="job-listing d-block d-sm-flex pb-3 pb-sm-0 align-items-center">
                    <input type="hidden" id="jobid" value="<%=res.JobID%>" />
                    <%--<a href="jobsingle.aspx"></a>--%>
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
    <section class="bg-light pt-5 testimony-full">
        <div class="owl-carousel single-carousel">
            <div class="container">
                <div class="row">
                    <div class="col-lg-6 align-self-center text-center text-lg-left">
                        <blockquote>
                            <p>&ldquo;Soluta quasi cum delectus eum facilis recusandae nesciunt molestias accusantium libero dolores repellat id in dolorem laborum ad modi qui at quas dolorum voluptatem voluptatum repudiandae.&rdquo;</p>
                            <p><cite>&mdash; Corey Woods, @Dribbble</cite></p>
                        </blockquote>
                    </div>
                    <div class="col-lg-6 align-self-end text-center text-lg-right">
                        <img src="jobboard/images/person_transparent_2.png" alt="Image" class="img-fluid mb-0">
                    </div>
                </div>
            </div>

            <div class="container">
                <div class="row">
                    <div class="col-lg-6 align-self-center text-center text-lg-left">
                        <blockquote>
                            <p>&ldquo;Soluta quasi cum delectus eum facilis recusandae nesciunt molestias accusantium libero dolores repellat id in dolorem laborum ad modi qui at quas dolorum voluptatem voluptatum repudiandae.&rdquo;</p>
                            <p><cite>&mdash; Chris Peters, @Google</cite></p>
                        </blockquote>
                    </div>
                    <div class="col-lg-6 align-self-end text-center text-lg-right">
                        <img src="jobboard/images/person_transparent.png" alt="Image" class="img-fluid mb-0">
                    </div>
                </div>
            </div>

        </div>

    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptarea" runat="server">
</asp:Content>
