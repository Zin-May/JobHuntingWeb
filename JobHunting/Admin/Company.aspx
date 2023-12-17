<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.Master" AutoEventWireup="true" CodeBehind="Company.aspx.cs" Inherits="JobHunting.Admin.Company" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <!-- Jquery filer css -->
    <link href="adminox/plugins/jquery.filer/css/jquery.filer.css" rel="stylesheet" />
    <link href="adminox/plugins/jquery.filer/css/themes/jquery.filer-dragdropbox-theme.css" rel="stylesheet" />

    <!-- Bootstrap fileupload css -->
    <link href="adminox/plugins/bootstrap-fileupload/bootstrap-fileupload.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="adminbody" runat="server">
    <!-- Start content -->
    <div class="content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-12">
                    <div class="page-title-box">
                        <h4 class="page-title float-left">Company Form </h4>
                        <ol class="breadcrumb float-right">
                            <li class="breadcrumb-item"><a href="#">Admin</a></li>
                            <li class="breadcrumb-item"><a href="#">Company</a></li>
                            <li class="breadcrumb-item active">Company Form </li>
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
                                                <label>Company Name</label>
                                                <input type="text" class="form-control" id="txtCompanyName" runat="server" placeholder="Enter Company Name">
                                            </div>
                                            <div class="form-group">
                                                <label>Description</label>
                                                <textarea class="form-control" rows="3" id="txtDescription" runat="server" placeholder="Enter company description"></textarea>
                                            </div>
                                            <div class="form-group">
                                                <label>Employee Count</label>
                                                <input type="number" min="0" step="1" class="form-control" runat="server" id="txtEmployeeCount" />
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label>Address(Please Choose Street & City & Country)</label>
                                                <asp:DropDownList ID="ddlAddress" CssClass="form-control" runat="server"></asp:DropDownList>
                                            </div>
                                            <div class="form-group">
                                                <label>Phone Number</label>
                                                <input type="text" class="form-control" id="txtPhoneNumber" runat="server" placeholder="Enter Your Phone Number">
                                            </div>
                                            <div class="form-group">
                                                <label>Email</label>
                                                <input type="text" class="form-control" id="txtEmail" runat="server" placeholder="Enter Your Email">
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label>Company Image Upload</label>
                                                <div class="col-9">
                                                    <div class="fileupload fileupload-new" data-provides="fileupload">
                                                        <div class="fileupload-new thumbnail" style="width: 200px; height: 150px;" id="imgDiv">
                                                            <img src="adminox/default/assets/images/small/img-1.jpg" alt="image" id="imgCompany" style="width: 200px; height: 150px;" />
                                                        </div>
                                                        <div class="fileupload-preview fileupload-exists thumbnail" style="max-width: 200px; max-height: 150px; line-height: 20px;">
                                                        </div>
                                                        <div>
                                                            <button type="button" class="btn btn-secondary btn-file" runat="server">
                                                                <span class="fileupload-new"><i class="fa fa-paper-clip"></i>Select image</span>
                                                                <span class="fileupload-exists"><i class="fa fa-undo"></i>Change</span>
                                                                <input type="file" class="btn-secondary" runat="server" id="imgCompanyFile" name="imgCompanyFile" accept="image/png,image/jpeg" />
                                                            </button>
                                                            <a href="#" class="btn btn-danger fileupload-exists" data-dismiss="fileupload"><i class="fa fa-trash"></i>Remove</a>
                                                        </div>
                                                    </div>
                                                </div>
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
                            <asp:HiddenField ID="hfCOMID" runat="server" />
                            <input type="hidden" id="hfIMGURL" runat="server" />
                            <div class="col-sm-12">
                                <div class="card-box table-responsive">
                                    <table class="table table-striped add-edit-table" id="datatable-editable" style="width: 100%">
                                        <thead>
                                            <tr>
                                                <th hidden>Company ID</th>
                                                <th>Company Name</th>
                                                <th>Company Image</th>
                                                <th>Description</th>
                                                <th>Address</th>
                                                <th>Phone Number</th>
                                                <th>Email</th>
                                                <th>Employee Count</th>
                                                <th hidden></th>
                                                <th hidden></th>
                                                <th>Actions</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <% foreach (var res in GetCompany())
                                                { %>
                                            <tr>
                                                <td class="comid" hidden><%=res.CompanyID %></td>
                                                <td class="comname"><%=res.CompanyName%></td>
                                                <td class="comimg">
                                                    <img id="tdcompanyimg" src="data:image/jpeg;base64,<%= res.CompanyImage != null ? Convert.ToBase64String(res.CompanyImage.ToArray()) : string.Empty %>" style="max-width: 100px; max-height: 100px;" alt="Image" />
                                                </td>
                                                <td class="des"><%=res.Description%></td>
                                                <td class="add"><%=res.Address%></td>
                                                <td class="ph"><%=res.Phone%></td>
                                                <td class="email"><%=res.Email%></td>
                                                <td class="empcount"><%=res.EmployeeCount%></td>
                                                <td hidden>data:image/jpeg;base64,<%= res.CompanyImage != null ? Convert.ToBase64String(res.CompanyImage.ToArray()) : string.Empty %>
                                                </td>
                                                <td hidden><%=Convert.ToBase64String(res.CompanyImage.ToArray())%></td>
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
            var companyid = eleList[0].innerHTML;
            var companyname = eleList[1].innerHTML;
            // var companyimage = eleList[2].innerHTML;
            var description = eleList[3].innerHTML;
            var address = eleList[4].innerHTML;
            var phone = eleList[5].innerHTML;
            var email = eleList[6].innerHTML;
            var employeecount = eleList[7].innerHTML;
            var updateURL = eleList[8].innerHTML;
            var imgURL = eleList[9].innerHTML;

            //console.log("this is companyimage" + companyimage);
            // console.log(imgURL);

            $('[id$=hfCOMID]').val(companyid);
            $('[id$=txtCompanyName]').val(companyname);
            document.getElementById("imgCompany").src = updateURL;
            $('[id$=txtDescription]').val(description);

            $("[id$='ddlAddress'] option").map(function () {
                if (this.text == address) {
                    $('[id$=ddlAddress]').val(this.value);
                }
            })
            $('[id$=txtPhoneNumber]').val(phone);
            $('[id$=txtEmail]').val(email);
            $('[id$=txtEmployeeCount]').val(employeecount);
            $('[id$=hfIMGURL]').val(imgURL);

            $('.bu').removeClass('hid');
            $('.bs').addClass('hid');

        }

        function DeleteData(ele) {
            var eleList = $(ele).parent().siblings('td');
            var companyid = eleList[0].innerHTML;

            $(this).closest("tr").remove();
            $('[id$=hfCOMID]').val(companyid);
            $("#lbtnDelete").click();
        }
    </script>

    <!-- Bootstrap fileupload js -->
    <script src="adminox/plugins/bootstrap-fileupload/bootstrap-fileupload.js"></script>
    <!-- page specific js -->
    <%--<script src="adminox/default/assets/pages/jquery.fileuploads.init.js"></script>--%>
</asp:Content>
