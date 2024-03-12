<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AllowancePage.aspx.vb" Inherits="Payroll.Web.AllowancePage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="card">
            <div class="card-header">
                <h3 class="card-title">Allowance Page</h3>
            </div>
            <div class="card-body">
                <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#addAllowanceModal">
                    Add
                </button>
                <asp:Literal ID="ltMessage" runat="server" />
                <br />
                <br />
                <asp:ListView ID="lvAllowance" runat="server" DataKeyNames="allowance_id" OnItemDeleting="lvAllowance_ItemDeleting"
                    OnItemCommand="lvAllowance_ItemCommand" OnSelectedIndexChanging="lvAllowance_SelectedIndexChanging">
                    <LayoutTemplate>
                        <table class="table table-hover table-bordered">
                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th>Allowance Name</th>
                                    <th>Allowance Amount</th>
                                    <th>Position</th>
                                    <th>Action</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                            </tbody>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("allowance_id") %></td>
                            <td><%# Eval("allowance_name") %></td>
                            <td><%# Eval("allowance_amount") %></td>
                            <td><%# Eval("position_name") %></td>
                            <td>
                                <asp:LinkButton ID="lnkEdit" Text="Edit" CssClass="btn btn-outline-warning btn-sm"
                                    CommandName="Select" CommandArgument='<%# Eval("allowance_id") %>' runat="server" />
                                &nbsp;
                              <asp:LinkButton ID="lnkDelete" Text="Delete" CssClass="btn btn-outline-danger btn-sm"
                                  CommandName="Delete" CommandArgument='<%# Eval("allowance_id") %>' runat="server" />

                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </div>
    </div>


    <!-- Modal for Add -->
    <div class="modal fade" id="addAllowanceModal" tabindex="-1" role="dialog" aria-labelledby="addAllowanceModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="addAllowanceModalLabel">Add Allowance</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <%--     <div class="form-group">
                        <label for="txtIDAllowance">Allowance:</label>
                        <asp:TextBox ID="txtIDAllowance" ReadOnly="true" runat="server" EnableViewState="false" CssClass="form-control" />
                    </div>--%>
                    <div class="form-group">
                        <label for="txtAllowanceName">Allowance Name :</label>
                        <asp:TextBox ID="txtAllowanceName" runat="server" EnableViewState="false" CssClass="form-control" placeholder="Enter Position Name" />
                    </div>
                    <div class="form-group">
                        <label for="txtAllowanceAmount">Allowance Amount :</label>
                        <asp:TextBox ID="txtAllowanceAmount" runat="server" EnableViewState="false" CssClass="form-control" placeholder="Enter Allowance Amount" />
                    </div>
                    <div class="form-group">
                        <label for="ddPositionName">Position Name :</label>
                        <asp:DropDownList ID="ddPositionName" CssClass="form-control" runat="server" />
                    </div>

                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                        <asp:Button ID="btnSave" Text="Save" runat="server" class="btn btn-primary" OnClick="btnSave_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal for Edit -->
    <div class="modal fade" id="editAllowanceModal" tabindex="-1" role="dialog" aria-labelledby="addAllowanceModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="editAllowanceModalLabel">Edit Allowance</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <%--     <div class="form-group">
                       <label for="txtIDAllowance">Allowance:</label>
                       <asp:TextBox ID="txtIDAllowance" ReadOnly="true" runat="server" EnableViewState="false" CssClass="form-control" />
                   </div>--%>
                    <asp:HiddenField ID="hdnEditAllowanceID" runat="server" />
                    <div class="form-group">
                        <label for="txtEditAllowanceName">Allowance Name :</label>
                        <asp:TextBox ID="txtEditAllowanceName" runat="server" EnableViewState="false" CssClass="form-control" placeholder="Enter Position Name" />
                    </div>
                    <div class="form-group">
                        <label for="txtEditAllowanceAmount">Allowance Amount :</label>
                        <asp:TextBox ID="txtEditAllowanceAmount" runat="server" EnableViewState="false" CssClass="form-control" placeholder="Enter Allowance Amount" />
                    </div>
                    <div class="form-group">
                        <label for="ddEditPositionName">Position Name :</label>
                        <asp:DropDownList ID="ddEditPositionName" CssClass="form-control" runat="server" />
                    </div>

                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                        <asp:Button ID="BtnEdit" Text="Save" runat="server" class="btn btn-primary" OnClick="BtnEdit_Click"/>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


