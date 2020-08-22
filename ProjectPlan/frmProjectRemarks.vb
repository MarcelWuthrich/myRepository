Imports System.Data.SqlClient


Public Class frmProjectRemarks

    Private Sub frmProjectRemarks_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize

        Try

            Try

                dgvProjectRemarks.Columns(4).Width = dgvProjectRemarks.Width - 110 - 110 - 44   '44 c'est la marge

            Catch ex As Exception
            End Try

        Catch ex As Exception

            If DebugFlag = True Then MessageBox.Show(ex.ToString)

        End Try
    End Sub

    Private Sub frmProjectRemarks_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            'Affichage de toutes les remarques
            pDisplayRemarks()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub pDisplayRemarks()

        Try
            Dim ActiveRow As Integer = 0
            Dim MySQLConnection As New SqlConnection

            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT ID_Remark FROM ProjectsRemarks WHERE CE_ID_Project = " & ID_Project & " ORDER BY ID_Remark DESC;"

            Me.Cursor = Cursors.WaitCursor

            'On vide le DataGridView
            dgvProjectRemarks.Rows.Clear()
            dgvProjectRemarks.Columns.Clear()

            'On rend certains éléments invisible durant le chargement des données
            'dgvProjectRemarks.Visible = False



            'Définition du DataGridView
            dgvProjectRemarks.ReadOnly = True
            dgvProjectRemarks.AllowUserToAddRows = False
            dgvProjectRemarks.AllowUserToDeleteRows = False
            dgvProjectRemarks.MultiSelect = False

            'Paramètres pour le multiline dans les DataGridView
            dgvProjectRemarks.DefaultCellStyle.WrapMode = DataGridViewTriState.True
            dgvProjectRemarks.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells


            'Définition des colonnes
            'dgvProjectRemarks.Columns.Add("ID_Project", "ID_Project")
            dgvProjectRemarks.Columns.Add("ID", "ID")
            dgvProjectRemarks.Columns.Add("CE_ID_Project", "CE_ID_Project")
            dgvProjectRemarks.Columns.Add("CreationDate", "CreationDate")
            dgvProjectRemarks.Columns.Add("LastModifyDate", "LastModifyDate")
            dgvProjectRemarks.Columns.Add("Remark", "Remark")


            'La colonne 0 (ID_Project) n'est pas visible
            'dgvProjets.Columns(0).Visible = False
            'dgvProjets.Columns(0).Visible = True

            'On ajuste automatiquement la taille des colonnes
            'Dim myCol0 As DataGridViewColumn = dgvProjectRemarks.Columns(0)
            'myCol0.Width = 25
            dgvProjectRemarks.Columns(0).Width = 25
            dgvProjectRemarks.Columns(0).Visible = False    'Inutile de voir l'ID
            dgvProjectRemarks.Columns(1).Width = 25
            dgvProjectRemarks.Columns(1).Visible = False    'Inutile de voir le projet
            dgvProjectRemarks.Columns(2).Width = 110        'parfait 110 pour les datetime
            dgvProjectRemarks.Columns(3).Width = 110        'parfait 110 pour les datetime
            dgvProjectRemarks.Columns(4).Width = dgvProjectRemarks.Width - 110 - 110 - 44   '44 c'est la marge




            MySQLConnection.ConnectionString = cnProjectPlan
            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)

            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read

                Dim thisRemark As New myProjectRemark

                'Lecture du premier paramètre 
                Try
                    'Lecture de la remark
                    thisRemark.ID_Remark = mySQLDataReader.GetValue(0)
                    thisRemark.Read()

                    'On ajoute les remarques dans le DataGridView
                    dgvProjectRemarks.Rows.Add()
                    dgvProjectRemarks.Item(0, ActiveRow).Value = thisRemark.ID_Remark
                    dgvProjectRemarks.Item(1, ActiveRow).Value = thisRemark.CE_ID_Project
                    dgvProjectRemarks.Item(2, ActiveRow).Value = thisRemark.CreationDate
                    dgvProjectRemarks.Item(3, ActiveRow).Value = thisRemark.LastModifyDate
                    dgvProjectRemarks.Item(4, ActiveRow).Value = thisRemark.Remark


                    'Le solde la largeur est attribué à la description
                    'Dim myMinWidth As Integer = 60
                    'Dim myWidth As Integer = dgvProjectRemarks.Width - dgvProjectRemarks.Columns(1).Width - dgvProjectRemarks.Columns(2).Width - dgvProjectRemarks.Columns(4).Width - 60
                    'If myWidth >= myMinWidth Then
                    '    dgvProjectRemarks.Columns(4).Width = myWidth
                    'Else
                    '    dgvProjectRemarks.Columns(4).Width = myMinWidth
                    'End If

                    ActiveRow = ActiveRow + 1
                Catch ex As Exception
                End Try

            End While

            mySQLDataReader.Close()
            MySQLConnection.Close()

            'Si dgvProjectRemarks contient des valeurs, on sélectionne la première ligne
            If dgvProjectRemarks.RowCount > 0 Then
                dgvProjectRemarks.Rows(0).Selected = True
                ID_Remark = dgvProjectRemarks.Item(0, 0).Value
            End If



            'On rend certains éléments visible après le chargement des données
            dgvProjectRemarks.Visible = True



            Me.Cursor = Cursors.Default

        Catch ex As Exception

            If DebugFlag = True Then MessageBox.Show(ex.ToString)

        End Try
    End Sub

    Private Sub btcFermer_Click(sender As Object, e As EventArgs) Handles btcFermer.Click

        Try
            ID_Remark = 0
            Me.Close()

        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Sub dgvProjectRemarks_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProjectRemarks.CellClick
        Try

            dgvProjectRemarks.Rows(dgvProjectRemarks.CurrentCell.RowIndex).Selected = True
            ID_Remark = dgvProjectRemarks.Item(0, dgvProjectRemarks.CurrentCell.RowIndex).Value
            'MsgBox("ID_Remark : " & ID_Remark)

        Catch ex As Exception

        End Try
    End Sub


    Private Sub dgvProjectRemarks_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProjectRemarks.CellDoubleClick

        Try

            dgvProjectRemarks.Rows(dgvProjectRemarks.CurrentCell.RowIndex).Selected = True
            ID_Remark = dgvProjectRemarks.Item(0, dgvProjectRemarks.CurrentCell.RowIndex).Value

            Dim myForm As Form = frmProjectRemarkText
            myForm.ShowDialog()
            myForm.Dispose()

            pDisplayRemarks()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btcAdd_Click(sender As Object, e As EventArgs) Handles btcAdd.Click

        Try

            ID_Remark = 0
            Dim myForm As Form = frmProjectRemarkText
            myForm.ShowDialog()
            myForm.Dispose()

            pDisplayRemarks()

        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try


    End Sub

    Private Sub btcModify_Click(sender As Object, e As EventArgs) Handles btcModify.Click

        Try

            Dim myForm As Form = frmProjectRemarkText
            myForm.ShowDialog()
            myForm.Dispose()

            pDisplayRemarks()

        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Sub dgvProjectRemarks_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProjectRemarks.CellContentClick

    End Sub
End Class