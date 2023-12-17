<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.Master" AutoEventWireup="true" CodeBehind="Job.aspx.cs" Inherits="JobHunting.Admin.Job" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="adminbody" runat="server">
    <!-- Start content -->
    <div class="content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-12">
                    <div class="page-title-box">
                        <h4 class="page-title float-left">Job Form </h4>
                        <ol class="breadcrumb float-right">
                            <li class="breadcrumb-item"><a href="#">Admin</a></li>
                            <li class="breadcrumb-item"><a href="#">Job</a></li>
                            <li class="breadcrumb-item active">Job Form </li>
                        </ol>
                        <div class="clearfix"></div>
                    </div>
                </div>
            </div>
            <!-- end row -->

            <div class="row">
                <div class="col-12">
                    <form id="fc" runat="server">
                        <div id="messagealert" runat="server" visible="false">
                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                            <strong>
                                <asp:Label ID="lblResult" runat="server"></asp:Label></strong>
                        </div>
                        <div class="row">
                            <div class="col-12">
                                <div class="card-box">
                                    <div class="row m-t-20">
                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label>Choose Company Name</label>
                                                <asp:DropDownList ID="ddlCompany" CssClass="form-control" runat="server"></asp:DropDownList>
                                            </div>
                                            <div class="form-group">
                                                <label>Choose Job Location</label>
                                                <asp:DropDownList ID="ddlJobLocation" CssClass="form-control" runat="server"></asp:DropDownList>
                                            </div>
                                            <div class="form-group">
                                                <label>Choose Job Position</label>
                                                <asp:DropDownList ID="ddlJobPosition" CssClass="form-control" runat="server"></asp:DropDownList>
                                            </div>
                                            <div class="form-group">
                                                <label>Salary</label>
                                                <input type="text" class="form-control" id="txtSalary" runat="server" placeholder="Enter Salary">
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label>Choose Category</label>
                                                <asp:DropDownList ID="ddlCategory" CssClass="form-control" runat="server"></asp:DropDownList>
                                            </div>
                                            <div class="form-group">
                                                <label>Choose Job Role</label>
                                                <asp:DropDownList ID="ddlJobRole" CssClass="form-control" runat="server"></asp:DropDownList>
                                            </div>
                                            <div class="form-group">
                                                <label>Choose Job Type</label>
                                                <asp:DropDownList ID="ddlJobType" CssClass="form-control" runat="server"></asp:DropDownList>
                                            </div>

                                            <div class="form-group">
                                                <label>Allowence</label>
                                                <input type="text" class="form-control" id="txtAllowence" runat="server" placeholder="Enter Allowence">
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="form-group">

                                                <div class="form-group">
                                                    <label>Status</label>
                                                    <input type="text" class="form-control" id="txtStatus" runat="server" placeholder="Enter Status">
                                                </div>

                                                <label>Job Description</label>
                                                <textarea class="form-control" id="txtDescription" runat="server" placeholder="Enter Job Description"></textarea>
                                            </div>
                                            <div class="form-group">
                                                <label>Job Responsibility</label>
                                                <textarea class="form-control" runat="server" id="txtResponibility" placeholder="Enter Job Responsibility"></textarea>
                                            </div>
                                        </div>
                                        <div class="form-group form-button offset-10">
                                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary btn-rounded w-md waves-light bs" Text="Save" OnClick="btnSave_Click" />
                                            <asp:Button ID="btnUpdate" CssClass="btn btn-primary btn-rounded w-md waves-light bu hid " runat="server" Text="Update" OnClick="btnUpdate_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <asp:HiddenField ID="hfJID" runat="server" />
                            <input type="hidden" id="hfCreateddate" runat="server" />
                            <div class="col-sm-12">
                                <div class="card-box table-responsive">
                                    <table class="table table-striped add-edit-table" id="datatable-editable" style="width: 100%">
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
                                                <th>JobDescription</th>
                                                <th>JobResponsibility</th>
                                                <th>Status</th>
                                                <th>CreatedDate</th>
                                                <th>UpdatedDate</th>
                                                <th>Actions</th>
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
                                                <td class="jdescript"><%=res.JobDescription%></td>
                                                <td class="jresponsiblity"><%=res.JobResponsibility%></td>
                                                <td class="status"><%=res.Status%></td>
                                                <td class="cdate"><%=res.CreatedDate%></td>
                                                <td class="udate"><%=res.UpdatedDate%></td>
                                                <td class="actions">
                                                    <a href="#" class="on-default" onclick="ShowData(this)"><i class="fa fa-pencil"></i></a>
                                                    <asp:LinkButton ID="lbtnDelete" runat="server" OnClick="lbtnDelete_Click" OnClientClick="DeleteData(this)"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                                </td>
                                            </tr>
                                            <%  } %>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                        <!-- end Row -->
                    </form>
                </div>
            </div>
            <!-- end row -->
        </div>
        <!-- container -->

    </div>
    <!-- content -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptarea" runat="server">

    <script>
        function ShowData(ele) {
            var eleList = $(ele).parent().siblings('td');
            var jobid = eleList[0].innerHTML;
            var companyname = eleList[1].innerHTML;
            var jobroleename = eleList[2].innerHTML;
            var jobtypename = eleList[3].innerHTML;
            var categoryname = eleList[4].innerHTML;
            var joblocationname = eleList[5].innerHTML;
            var jobpositionname = eleList[6].innerHTML;
            var allowence = eleList[7].innerHTML;
            var salary = eleList[8].innerHTML;
            var description = eleList[9].innerHTML;
            var responsibility = eleList[10].innerHTML;
            var status = eleList[11].innerHTML;
            var createddate = eleList[12].innerHTML;

            $('[id$=hfJID]').val(jobid);
            console.log(createddate);

            $("[id$='ddlCompany'] option").map(function () {
                if (this.text == companyname) {
                    $('[id$=ddlCompany]').val(this.value);
                }
            })

            $("[id$='ddlJobType'] option").map(function () {
                if (this.text == jobtypename) {
                    $('[id$=ddlJobType]').val(this.value);
                }
            })

            $("[id$='ddlCategory'] option").map(function () {
                if (this.text == categoryname) {
                    $('[id$=ddlCategory]').val(this.value);
                }
            })

            $("[id$='ddlJobRole'] option").map(function () {
                if (this.text == jobroleename) {
                    $('[id$=ddlJobRole]').val(this.value);
                }
            })

            $("[id$='ddlJobLocation'] option").map(function () {
                if (this.text == joblocationname) {
                    $('[id$=ddlJobLocation]').val(this.value);
                }
            })

            $("[id$='ddlJobPosition'] option").map(function () {
                if (this.text == jobpositionname) {
                    $('[id$=ddlJobPosition]').val(this.value);
                }
            })

            $('[id$=txtAllowence]').val(allowence);
            $('[id$=txtSalary]').val(salary);
            $('[id$=txtDescription]').val(description);
            $('[id$=txtResponibility]').val(responsibility);
            $('[id$=txtStatus]').val(status);
            $('[id$=hfCreateddate]').val(createddate);

            $('.bu').removeClass('hid');
            $('.bs').addClass('hid');

        }

        function DeleteData(ele) {
            var eleList = $(ele).parent().siblings('td');
            var jobid = eleList[0].innerHTML;

            $(this).closest("tr").remove();
            $('[id$=hfJID]').val(jobid);
            $("#lbtnDelete").click();
        }
    </script>
</asp:Content>
