Imports Payroll.BLL
Imports Payroll.BLL.DTO

Public Class DeductionPage
    Inherits System.Web.UI.Page

    Dim _deductionBll As New DeductionBLL()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LoadData()
            LoadPositionDropDownList()
        End If
    End Sub

    Sub LoadData()
        Try
            Dim result = _deductionBll.GetDeductionWithPositionName()
            lvDeduction.DataSource = result
            lvDeduction.DataBind()
            If result Is Nothing OrElse result.Count = 0 Then
                ltMessage.Text = "No data available."
            End If
        Catch ex As Exception
            ltMessage.Text = "An error occurred while loading data: " & ex.Message
        End Try
    End Sub

    Sub LoadPositionDropDownList()
        Try
            Dim positions = _deductionBll.GetAll()
            ddPositionName.DataSource = positions
            ddPositionName.DataTextField = "Position_name"
            ddPositionName.DataValueField = "position_id"
            ddPositionName.DataBind()

            ' Tambahkan item kosong jika diperlukan
            ddPositionName.Items.Insert(0, New ListItem("--Select Position--", ""))
        Catch ex As Exception
            ' Handle any exceptions
            ltMessage.Text = "An error occurred while loading position data: " & ex.Message
        End Try
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs)
        Dim deduction As New DeductionDTO()

        ' Penanganan kesalahan untuk deduction_name
        If Not String.IsNullOrEmpty(txtDeductionName.Text.Trim()) Then
            deduction.deduction_name = txtDeductionName.Text.Trim()
        Else
            ' Handle error: deduction_name tidak boleh kosong
        End If

        Dim positionId As Integer
        If Not String.IsNullOrEmpty(ddPositionName.SelectedValue) AndAlso Int32.TryParse(ddPositionName.SelectedValue, positionId) Then
            deduction.position_id = positionId
        Else
            ' Handle error: posisi tidak valid atau tidak dipilih
        End If

        Dim deductionAmount As Decimal
        If Decimal.TryParse(txtDeductionAmount.Text, deductionAmount) Then
            deduction.deduction_amount = deductionAmount
        Else
            ' Handle error: invalid deduction amount
        End If

        ' Insert the new deduction
        Try
            _deductionBll.Insert(deduction)
            LoadData()
            ltMessage.Text = "<span class='alert alert-success'>Deduction inserted successfully</span>"
        Catch ex As Exception
            ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span>"
        End Try
    End Sub

    Protected Sub lvDeduction_ItemCommand(ByVal sender As Object, ByVal e As ListViewCommandEventArgs) Handles lvDeduction.ItemCommand
        'If e.CommandName = "Delete" Then
        '    Try
        '        Dim itemIndex As Integer = Convert.ToInt32(e.CommandArgument)
        '        Dim deductionId As Integer = Convert.ToInt32(lvDeduction.DataKeys(itemIndex).Value)

        '        _deductionBll.Delete(deductionId)
        '        LoadData()
        '        ltMessage.Text = "<span class='alert alert-success'>Deduction deleted successfully</span>"
        '    Catch ex As FormatException
        '        ltMessage.Text = "<span class='alert alert-danger'>Error: Invalid command argument format</span>"
        '    Catch ex As Exception
        '        ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span>"
        '    End Try
        'ElseIf e.CommandName = "Select" Then
        '    ' Handle Edit command here
        '    ' You can access the item using e.Item and perform any required actions
        'End If
    End Sub

    Protected Sub lvDeduction_ItemDeleting(ByVal sender As Object, ByVal e As ListViewDeleteEventArgs) Handles lvDeduction.ItemDeleting
        Dim deductionId As Integer = Convert.ToInt32(lvDeduction.DataKeys(e.ItemIndex).Value)
        Try
            _deductionBll.Delete(deductionId)
            LoadData()
            ltMessage.Text = "<span class='alert alert-success'>Deduction deleted successfully</span>"
        Catch ex As Exception
            ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span>"
        End Try
    End Sub

End Class
