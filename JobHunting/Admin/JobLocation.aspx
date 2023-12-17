<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.Master" AutoEventWireup="true" CodeBehind="JobLocation.aspx.cs" Inherits="JobHunting.Admin.JobLocation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="adminbody" runat="server">
     <!-- Start content -->
 <div class="content">
     <div class="container-fluid">
         <div class="row">
             <div class="col-12">
                 <div class="page-title-box">
                     <h4 class="page-title float-left">Job Location Form </h4>
                     <ol class="breadcrumb float-right">
                         <li class="breadcrumb-item"><a href="#">Admin</a></li>
                         <li class="breadcrumb-item"><a href="#">Address</a></li>
                         <li class="breadcrumb-item active">Job Location Form </li>
                     </ol>
                     <div class="clearfix"></div>
                 </div>
             </div>
         </div>
         <!-- end row -->

         <div class="row">
             <div class="col-12">
             <form  id="fc" runat="server" >
                 <div id="messagealert" runat="server" visible="false">
                     <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                     <i class="fa fa-check-circle"></i>
                     <strong><asp:Label ID="lblResult" runat="server"></asp:Label></strong>
                 </div>
                 <div class="row">
                     <div class="col-5">
                         <div class="card-box">
                             <div class="form-group">
                             <label">Job Street Address</label>
                             <input type="text" class="form-control" id="txtJobStreetAddress" runat="server" placeholder="Enter Job Street Address">
                         </div>
                         <div class="form-group">
                             <label>Choose City & Country</label>
                             <asp:DropDownList ID="ddlCityCountry" CssClass="form-control" runat="server"></asp:DropDownList>
                         </div>
                             <div class="form-group form-button">
                                 <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary btn-rounded w-md waves-light bs" Text="Save" OnClick="btnSave_Click"/>
                                 <asp:Button ID="btnUpdate" CssClass="btn btn-primary btn-rounded w-md waves-light bu hid" runat="server" Text="Update" onClick="btnUpdate_Click"/>
                             </div>
                         </div>
                     </div>                                       
                 </div>  <!-- end col -->
                 <div class="row">
                     <asp:HiddenField ID="hfJLlID" runat="server" />
                      <div class="col-sm-12">
                          <div class="card-box table-responsive">  
                         <table class="table table-striped add-edit-table" id="datatable-editable" style="width:100%">
                             <thead>
                                 <tr>
                                     <th>Job Location ID</th>
                                     <th>Job Street Address</th>
                                     <th>City ID</th>
                                     <th>Actions</th>
                                 </tr>
                             </thead>
                             <tbody>
                                 <% foreach (var res in GetAllJobLocation())
                                     { %>
                                         <tr>
                                             <td class="jlid"><%=res.JobLocationID %></td>
                                             <td class="jsadd"><%=res.JobStreetAddress%></td>
                                             <td class="cid"><%=res.CityID%></td>
                                             <td class="actions">
                                                 <a href="#" class="on-default" onclick="ShowData(this)"><i class="fa fa-pencil"></i></a>   
                                                 <asp:LinkButton ID="lbtnDelete" runat="server" onClick="lbtnDelete_Click" OnClientClick="return deleteConfirm(this);"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                             </td>
                                         </tr>
                                 <%  } %>
                             </tbody>
                         </table>
                     </div>
                     </div>
                 </div> <!-- end Row -->                                                         
             </form>
             </div>
         </div>
         <!-- end row -->
     </div> <!-- container -->
 </div> <!-- content -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptarea" runat="server">
    <script>

        function ShowData(ele) {
            var eleList = $(ele).parent().siblings('td');
            var joblocationid = eleList[0].innerHTML;
            var jobstreetaddress = eleList[1].innerHTML;
            var cityid = eleList[2].innerHTML;

            $('[id$=hfJLlID]').val(joblocationid);
            $('[id$=txtJobStreetAddress]').val(jobstreetaddress);
            $('[id$=ddlCityCountry]').val(cityid);

            // console.log(joblocationid + " " + jobstreetaddress + " " + cityid);

            $('.bu').removeClass('hid');
            $('.bs').addClass('hid');

        }

        function deleteConfirm(btn) {
            var eleList = $(btn).parent().siblings('td');
            var joblocationid = eleList[0].innerHTML;

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
                    //console.log("This is success");
                    $(this).closest("tr").remove();
                    $('[id$=hfJLlID]').val(joblocationid);
                    btn.dataset.confirmed = true;
                    btn.click();
                }
            })
            return false;
        }
    </script>
</asp:Content>
