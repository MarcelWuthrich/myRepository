Public Class frmProjectRemarkText
    Private Sub btcOK_Click(sender As Object, e As EventArgs) Handles btcOK.Click

        Try

            Dim thisRemark As New myProjectRemark
            Dim thisNow As Date = Now



            If ID_Remark = 0 Then
                thisRemark.CreationDate = thisNow
                thisRemark.LastModifyDate = thisNow
                thisRemark.CE_ID_Project = ID_Project
            Else
                thisRemark.ID_Remark = ID_Remark
                thisRemark.Read()
                thisRemark.LastModifyDate = thisNow
            End If

            thisRemark.Remark = Me.texRemark.Text
            thisRemark.Save()

            Me.Close()
        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub btcAnnuler_Click(sender As Object, e As EventArgs) Handles btcAnnuler.Click

        Try
            Me.Close()
        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Sub frmProjectRemarkText_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            If ID_Remark > 0 Then
                Dim thisRemark As New myProjectRemark
                thisRemark.ID_Remark = ID_Remark
                thisRemark.Read()
                Me.texRemark.Text = thisRemark.Remark
            End If

        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class