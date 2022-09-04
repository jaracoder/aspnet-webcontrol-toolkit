Partial Class RegisterView
    Inherits Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Label1.Visible = False
    End Sub

    Protected Sub Register_Submit(sender As Object, e As EventArgs) Handles RegisterView.Submit
        Label1.Text =
            String.Format("Gracias, {0}! Te has registrado correctamente. ", RegisterView.Name)
        Label1.Visible = True
        RegisterView.Visible = False
    End Sub
End Class
