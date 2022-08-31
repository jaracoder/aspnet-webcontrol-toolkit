Imports System.Data

Partial Class Register
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Label1.Visible = False
    End Sub

    Protected Sub Register_Submit(sender As Object, e As System.EventArgs) Handles Register1.Submit
        Label1.Text =
            String.Format("Gracias, {0}! Te has registrado correctamente. ", Register1.Name)
        Label1.Visible = True
        Register1.Visible = False
    End Sub
   
End Class
