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
                            <li class="breadcrumb-item"><a href="#">Dashboard</a></li>
                            <li class="breadcrumb-item active">Category Form </li>
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
                        <div class="confirmalert" runat="server">
                            <span class="msg">
                                <asp:Label ID="lblConfirm" runat="server"></asp:Label></span>
                        </div>
                        <div class="row">
                            <div class="col-4">
                                <div class="card-box">
                                    <%--<h4 class="m-t-0 m-b-30 header-title">JobType Form</h4>  --%>
                                    <div class="form-group">
                                        <label>Category Name</label>
                                        <input type="text" class="form-control" id="txtCategoryName" runat="server" placeholder="Enter Category Name">
                                    </div>
                                    <div class="form-group form-button">
                                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary btn-rounded w-md waves-light bs" Text="Save" OnClick="btnSave_Click" />
                                        <asp:Button ID="btnUpdate" CssClass="btn btn-primary btn-rounded w-md waves-light bu hid" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                                    </div>
                                </div>
                            </div>
                            <!-- end col -->

                            <asp:HiddenField ID="hfCID" runat="server" />
                            <div class="col-sm-8">
                                <div class="card-box table-responsive">
                                    <table class="table table-striped add-edit-table" id="datatable-editable" style="width: 100%">
                                        <thead>
                                            <tr>
                                                <th>Job Role ID</th>
                                                <th>Job Role Name</th>
                                                <th>Actions</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <% foreach (var res in GetAllCategory())
                                                { %>
                                            <tr>
                                                <td class="cid"><%=res.CategoryID %></td>
                                                <td class="cname"><%=res.CategoryName%></td>
                                                <td class="actions">
                                                    <a href="#" class="on-default" onclick="ShowData(this)"><i class="fa fa-pencil"></i></a>
                                                    <asp:LinkButton ID="lbtnDelete" runat="server" OnClick="lbtnDelete_Click" OnClientClick="return deleteConfirm(this);"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                                </td>
                                            </tr>
                                            <%  } %>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
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
            var categoryid = eleList[0].innerHTML;
            var categoryname = eleList[1].innerHTML;

            $('[id$=hfCID]').val(categoryid);
            $('[id$=txtCategoryName]').val(categoryname);

            // console.log(categoryid + " " + categoryname);

            $('.bu').removeClass('hid');
            $('.bs').addClass('hid');

        }

        function deleteConfirm(btn) {
            var eleList = $(btn).parent().siblings('td');
            var categoryid = eleList[0].innerHTML;

            if (btn.dataset.confirmed) {
                btn.dataset.confirmed = false;
                return true;
            }

            Swal.fire({
                title: 'Delete Data Confirmation',
                text: "Are you sure that you want to delete this data?",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonText: 'Yes, delete it!',
                cancelButtonText: 'No, Cancel',
            }).then((result) => {
                if (result.isConfirmed) {
                    // Trigger the button click event to proceed with the server event
                    //  console.log("This is success");
                    $(this).closest("tr").remove();
                    $('[id$=hfCID]').val(categoryid);
                    btn.dataset.confirmed = true;
                    btn.click();
                }
            })
            return false;
        }
    </script>
</asp:Content>
