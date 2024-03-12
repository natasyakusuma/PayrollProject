Imports System.EnterpriseServices
Imports Payroll.BLL
Imports Payroll.BLL.DTO

Public Class AllowancePage
    Inherits System.Web.UI.Page

    Dim _allowanceBll As New AllowanceBLL()
    Dim _positionBll As New PositionBLL()


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LoadData()
            LoadPositionDropDownList()
        End If
    End Sub

    Private Function GetEditModal(ByVal id As Integer)
        Dim allowance As New AllowanceDTO()
        allowance = _allowanceBll.GetAllowanceById(id)
        hdnEditAllowanceID.Value = allowance.allowance_id
        txtEditAllowanceName.Text = allowance.allowance_name
        txtEditAllowanceAmount.Text = allowance.allowance_amount
        ddEditPositionName.SelectedValue = allowance.position_id
    End Function

    Sub LoadData()
        Try
            Dim result = _allowanceBll.GetAllowanceWithPositionName()
            lvAllowance.DataSource = result
            lvAllowance.DataBind()
            If result Is Nothing OrElse result.Count = 0 Then
                ltMessage.Text = "No data available."
            End If
        Catch ex As Exception
            ltMessage.Text = "An error occurred while loading data: " & ex.Message
        End Try
    End Sub

    Sub LoadPositionDropDownList()
        Try
            Dim positions = _positionBll.GetAll()
            ddPositionName.DataSource = positions
            ddPositionName.DataTextField = "position_name"
            ddPositionName.DataValueField = "position_id"
            ddPositionName.DataBind()

            ddEditPositionName.DataSource = positions
            ddEditPositionName.DataTextField = "position_name"
            ddEditPositionName.DataValueField = "position_id"
            ddEditPositionName.DataBind()

            '' Tambahkan item kosong jika diperlukan
            'ddPositionName.Items.Insert(0, New ListItem("--Select Position--", ""))
        Catch ex As Exception
            ' Handle any exceptions
            ltMessage.Text = "An error occurred while loading position data: " & ex.Message
        End Try
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs)
        Dim allowance As New AllowanceDTO()

        ' Penanganan kesalahan untuk allowance_name
        If Not String.IsNullOrEmpty(txtAllowanceName.Text.Trim()) Then
            allowance.allowance_name = txtAllowanceName.Text.Trim()
        Else
            ' Handle error: allowance_name tidak boleh kosong
        End If

        ' Set property values from form input
        Dim positionId As Integer
        If Int32.TryParse(ddPositionName.SelectedValue, positionId) Then
            allowance.position_id = positionId
        Else
            ' Handle error: invalid position id
        End If


        Dim allowanceAmount As Decimal
        If Decimal.TryParse(txtAllowanceAmount.Text, allowanceAmount) Then
            allowance.allowance_amount = allowanceAmount
        Else
            ' Handle error: invalid allowance amount
        End If

        ' Insert the new allowance
        Try
            _allowanceBll.Insert(allowance)
            LoadData()
            ltMessage.Text = "<span class='alert alert-success'>Allowance inserted successfully</span>"
        Catch ex As Exception
            ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span>"
        End Try


    End Sub







    Protected Sub lvAllowance_ItemCommand(ByVal sender As Object, ByVal e As ListViewCommandEventArgs) Handles lvAllowance.ItemCommand
        If e.CommandName = "Delete" Then
            Dim itemIndex As Integer = Convert.ToInt32(e.CommandArgument)
            'Dim allowanceId As Integer = Convert.ToInt32(lvAllowance.DataKeys(itemIndex).Value)
            Try
                _allowanceBll.Delete(itemIndex)
                LoadData()
                ltMessage.Text = "<span class='alert alert-success'>Allowance deleted successfully</span>"
            Catch ex As FormatException
                ltMessage.Text = "<span class='alert alert-danger'>Error: Invalid command argument format</span>"
            Catch ex As Exception
                ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span>"
            End Try
        ElseIf e.CommandName = "Select" Then
            Dim itemIndex As Integer = Convert.ToInt32(e.CommandArgument)
            'Dim allowanceId As Integer = Convert.ToInt32(lvAllowance.DataKeys(itemIndex).Value)
            GetEditModal(itemIndex)
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenModalScript", "$(window).on('load',function(){$('#editAllowanceModal').modal('show');})", True)
        End If
    End Sub
    Protected Sub lvAllowance_ItemDeleting(ByVal sender As Object, ByVal e As ListViewDeleteEventArgs) Handles lvAllowance.ItemDeleting
        'Dim allowanceId As Integer = Convert.ToInt32(lvAllowance.DataKeys(e.ItemIndex).Value)
        'Try
        '    _allowanceBll.Delete(allowanceId)
        '    LoadData()
        '    ltMessage.Text = "<span class='alert alert-success'>Allowance deleted successfully</span>"
        'Catch ex As Exception
        '    ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span>"
        'End Try
    End Sub

    Protected Sub lvAllowance_SelectedIndexChanging(sender As Object, e As ListViewSelectEventArgs)
        If ViewState("Command") = "Edit" Then
            ltMessage.Text = "Edit"
            GetEditModal(CInt(lvAllowance.DataKeys(e.NewSelectedIndex).Value))
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenModalScript", "$(window).on('load',function(){$('#editAllowanceModal').modal('show');})", True)
        End If
    End Sub

    Protected Sub BtnEdit_Click(sender As Object, e As EventArgs)
        Dim allowance As New AllowanceDTO()
        allowance.allowance_id = hdnEditAllowanceID.Value
        allowance.allowance_name = txtEditAllowanceName.Text
        allowance.allowance_amount = txtEditAllowanceAmount.Text
        allowance.position_id = ddEditPositionName.SelectedValue
        Try
            _allowanceBll.Update(allowance)
            LoadData()
            ltMessage.Text = "<span class='alert alert-success'>Allowance updated successfully</span>"
        Catch ex As Exception
            ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span>"
        End Try

    End Sub
End Class
