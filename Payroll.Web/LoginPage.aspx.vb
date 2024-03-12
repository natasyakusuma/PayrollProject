Imports System.Web.Configuration
Imports Payroll.BLL.DTO
Imports Payroll.BLL

Public Class LoginPage
    Inherits System.Web.UI.Page

    Dim _userBLL As New UserBLL()


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Check if the user is already logged in
            'If Session("LoggedInUser") IsNot Nothing Then
            '    Response.Redirect("Default.aspx")
            'End If
        End If

    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs)
        Try

            Dim username As String = txtUsername.Text
            Dim password As String = txtPassword.Text
            Dim _staffDto As UserDTO = _userBLL.Login(username, password)

            If _staffDto IsNot Nothing Then
                'Save the user in session
                Session("LoggedInUser") = _staffDto
                'Access the Staff profile data then save to Session
                Response.Redirect("Default.aspx")
            Else
                ltMessage.Text = "<span class='alert alert-danger'>Invalid username or password</span>"
            End If
        Catch ex As Exception
            ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span>"
        End Try
    End Sub
End Class