<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DeductionPage.aspx.vb" Inherits="Payroll.Web.DeductionPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="card">
            <div class="card-header">
                <h3 class="card-title">Deduction Page</h3>
            </div>
            <div class="card-body">
                <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#addDeductionModal">
                    Add
                </button>
                <asp:Literal ID="ltMessage" runat="server" />
                <br />
                <br />
                <asp:ListView ID="lvDeduction" runat="server" DataKeyNames="deduction_id" OnItemDeleting="lvDeduction_ItemDeleting"
                    OnItemCommand="lvDeduction_ItemCommand">
                    <LayoutTemplate>
                        <table class="table table-hover table-bordered">
                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th>Deduction Name</th>
                                    <th>Deduction Amount</th>
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
                            <td><%# Eval("deduction_id") %></td>
                            <td><%# Eval("deduction_name") %></td>
                            <td><%# Eval("deduction_amount") %></td>
                            <td><%# Eval("position_name") %></td>
                            <td>
                                <asp:LinkButton ID="lnkEdit" Text="Edit" CssClass="btn btn-outline-warning btn-sm"
                                    CommandName="Select" CommandArgument="Edit" runat="server" />
                                &nbsp;
                                <asp:LinkButton ID="lnkDelete" Text="Delete" CssClass="btn btn-outline-danger btn-sm"
                                    CommandName="Delete" CommandArgument='<%# Container.DataItemIndex %>' runat="server" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </div>
    </div>


    <!-- Modal for Add -->
    <div class="modal fade" id="addDeductionModal" tabindex="-1" role="dialog" aria-labelledby="addDeductionModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="addDeductionModalLabel">Add Deduction</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label for="txtIDDeduction">Deduction:</label>
                        <asp:TextBox ID="txtIDDeduction" ReadOnly="true" runat="server" EnableViewState="false" CssClass="form-control" />
                    </div>
                    <div class="form-group">
                        <label for="txtDeductionName">Deduction Name :</label>
                        <asp:TextBox ID="txtDeductionName" runat="server" EnableViewState="false" CssClass="form-control" placeholder="Enter Deduction Name" />
                    </div>
                    <div class="form-group">
                        <label for="txtDeductionAmount">Deduction Amount :</label>
                        <asp:TextBox ID="txtDeductionAmount" runat="server" EnableViewState="false" CssClass="form-control" placeholder="Enter Deduction Amount" />
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
</asp:Content>
