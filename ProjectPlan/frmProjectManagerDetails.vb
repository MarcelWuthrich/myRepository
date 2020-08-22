Public Class frmProjectManagerDetails
    Private Sub btcAnnuler_Click(sender As Object, e As EventArgs) Handles btcAnnuler.Click

        Try

            Me.Close()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btcOK_Click(sender As Object, e As EventArgs) Handles btcOK.Click

        Try

            Dim thisPM As New myProjectManager

            thisPM.ID_ProjectManager = Val(Me.texID_ProjectManager.Text)
            thisPM.FirstName = Me.texPrenom.Text
            thisPM.Lastname = Me.texNom.Text
            If Me.chkActive.Checked = True Then
                thisPM.Enable = True
            Else
                thisPM.Enable = False
            End If

            ID_ProjectManager = thisPM.ID_ProjectManager
            thisPM.Save()

            Me.Close()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub frmProjectManagerDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'ID_ProjectManager = 2

        Try

            Dim _thisPM As New myProjectManager
            _thisPM.ID_ProjectManager = ID_ProjectManager
            _thisPM.Read()

            Me.texID_ProjectManager.Text = _thisPM.ID_ProjectManager
            Me.texNom.Text = _thisPM.Lastname
            Me.texPrenom.Text = _thisPM.FirstName

            If _thisPM.Enable = True Then
                Me.chkActive.Checked = True
            Else
                Me.chkActive.Checked = False
            End If

            If Me.texID_ProjectManager.Text = "0" Then Me.texID_ProjectManager.Text = ""

        Catch ex As Exception

        End Try
    End Sub
End Class