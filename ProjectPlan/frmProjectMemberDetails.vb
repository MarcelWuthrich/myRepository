Imports System.Data.SqlClient

Public Class frmProjectMemberDetails
    Private Sub btcAnnuler_Click(sender As Object, e As EventArgs) Handles btcAnnuler.Click

        Try

            Me.Close()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btcOK_Click(sender As Object, e As EventArgs) Handles btcOK.Click

        Try

            Dim thisProjectMember As New myProjectMember
            Dim thisTask As New myTask

            thisProjectMember.ID_ProjectMember = Val(Me.texID_ProjectMember.Text)
            thisProjectMember.FirstName = Me.texPrenom.Text
            thisProjectMember.Lastname = Me.texNom.Text
            If Me.chkActive.Checked = True Then
                thisProjectMember.Enable = True
            Else
                thisProjectMember.Enable = False
            End If

            'On lit la tâche
            Dim ID_Task As String = DirectCast(lovTasks.SelectedItem, KeyValuePair(Of String, String)).Key

            thisProjectMember.CE_ID_Task = ID_Task
            ID_ProjectMember = thisProjectMember.ID_ProjectMember
            thisProjectMember.Save()

            Me.Close()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub frmProjectMemberDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim ID As Integer = 0

        Try

            'Polulate des tâches
            pPopulateTasks()

            Dim thisProjectMember As New myProjectMember
            thisProjectMember.ID_ProjectMember = ID_ProjectMember
            thisProjectMember.Read()

            Me.texID_ProjectMember.Text = thisProjectMember.ID_ProjectMember
            Me.texNom.Text = thisProjectMember.Lastname
            Me.texPrenom.Text = thisProjectMember.FirstName

            If thisProjectMember.Enable = True Then
                Me.chkActive.Checked = True
            Else
                Me.chkActive.Checked = False
            End If

            'Task
            For I = 0 To lovTasks.Items.Count - 1
                ID = DirectCast(lovTasks.Items(I), KeyValuePair(Of String, String)).Key
                If thisProjectMember.CE_ID_Task = ID Then
                    Me.lovTasks.SelectedIndex = I
                    Exit For
                End If
            Next I


            If Me.texID_ProjectMember.Text = "0" Then Me.texID_ProjectMember.Text = ""

        Catch ex As Exception

        End Try

    End Sub



    Private Sub pPopulateTasks()

        Try

            Me.lovTasks.Items.Clear()

            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT ID_Task, Task FROM Tasks WHERE Enable = 1 ORDER BY DisplayOrder ASC ;"
            Dim MySQLConnection As New SqlConnection

            Dim Task As String = ""
            Dim ID_Task As Integer = 0
            Dim myDictionnary As New Dictionary(Of String, String)()

            'On insère une ligne vide
            myDictionnary.Add(Str(0), "")

            MySQLConnection.ConnectionString = cnProjectPlan
            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)
            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read


                Try
                    ID_Task = mySQLDataReader.GetValue(0)
                Catch ex As Exception
                End Try

                Try
                    Task = mySQLDataReader.GetString(1)
                Catch ex As Exception
                End Try

                myDictionnary.Add(Str(ID_Task), Task)

            End While

            mySQLDataReader.Close()
            MySQLConnection.Close()

            Me.lovTasks.DataSource = New BindingSource(myDictionnary, Nothing)
            Me.lovTasks.DisplayMember = "Value"
            Me.lovTasks.ValueMember = "Key"

            Me.lovTasks.SelectedIndex = 0

        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try

    End Sub

End Class