Public Class frmProjectCustomer
    Private Sub frmProjectCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            Dim thisCustomer As New myCustomer
            thisCustomer.ID_Customer = ID_Customer
            thisCustomer.Read()

            Me.texID_Customer.Text = thisCustomer.ID_Customer
            Me.texNom.Text = thisCustomer.Lastname
            Me.texPrenom.Text = thisCustomer.FirstName

            If thisCustomer.Enable = True Then
                Me.chkActive.Checked = True
            Else
                Me.chkActive.Checked = False
            End If

            If Me.texID_Customer.Text = "0" Then Me.texID_Customer.Text = ""
        Catch ex As Exception
        End Try

    End Sub

    Private Sub btcAnnuler_Click(sender As Object, e As EventArgs) Handles btcAnnuler.Click
        Try
            Me.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btcOK_Click(sender As Object, e As EventArgs) Handles btcOK.Click

        Try

            Dim thisCustomer As New myCustomer

            thisCustomer.ID_Customer = Val(Me.texID_Customer.Text)
            thisCustomer.FirstName = Me.texPrenom.Text
            thisCustomer.Lastname = Me.texNom.Text
            If Me.chkActive.Checked = True Then
                thisCustomer.Enable = True
            Else
                thisCustomer.Enable = False
            End If

            ID_Customer = thisCustomer.ID_Customer
            thisCustomer.Save()

            Me.Close()

        Catch ex As Exception

        End Try

    End Sub
End Class