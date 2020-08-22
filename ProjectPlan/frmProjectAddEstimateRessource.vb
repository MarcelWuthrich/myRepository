Imports System.Data.SqlClient


Public Class frmProjectAddEstimateRessource
    Private Sub frmProjectAddEstimateRessource_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            'Polulate des tâches
            pPopulateTasks()

        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
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

    Private Sub btcAnnuler_Click(sender As Object, e As EventArgs) Handles btcAnnuler.Click

        Try
            Me.Close()
        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Sub btcOK_Click(sender As Object, e As EventArgs) Handles btcOK.Click

        Try

            'On lit la tâche
            G_Add_ID_Task = DirectCast(lovTasks.SelectedItem, KeyValuePair(Of String, String)).Key
            G_Add_NumberDays = Me.texDaysNumber.Text

            Me.Close()
        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try

    End Sub
End Class