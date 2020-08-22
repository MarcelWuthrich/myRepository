Imports System.Data.SqlClient


Public Class frmResourceProjectList

    Private Sub frmResourceProjectList_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            pLoadProjectResources()

            Me.lstProjectResources.ClearSelected()

        Catch ex As Exception
        End Try

    End Sub

    Private Sub pLoadProjectResources()

        Try

            Me.lstProjectResources.Items.Clear()

            Dim myDictionnary As New Dictionary(Of String, String)()

            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT ID_Project, Title FROM PROJECTS WHERE CE_ID_Status in (6,7,8,9) ORDER BY Title ASC;"
            Dim MySQLConnection As New SqlConnection


            MySQLConnection.ConnectionString = cnProjectPlan


            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)

            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read


                Try
                    Dim Title As String = ""
                    Dim ID_Project As Integer = 0

                    Try
                        ID_Project = mySQLDataReader.GetValue(0)
                    Catch ex As Exception
                    End Try

                    Try
                        Title = mySQLDataReader.GetString(1)
                    Catch ex As Exception
                    End Try


                    myDictionnary.Add(Str(ID_Project), Title)

                Catch ex As Exception
                End Try

            End While

            mySQLDataReader.Close()
            MySQLConnection.Close()

            Me.lstProjectResources.DataSource = New BindingSource(myDictionnary, Nothing)
            Me.lstProjectResources.DisplayMember = "Value"
            Me.lstProjectResources.ValueMember = "Key)"


        Catch ex As Exception

        End Try

    End Sub

    Private Sub lstProjectResources_Click(sender As Object, e As EventArgs) Handles lstProjectResources.Click

        Try

            'On lit la ressource administrative sélectionnée
            Dim ID_ProjectResource As String = DirectCast(lstProjectResources.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim ProjectResource As String = DirectCast(lstProjectResources.SelectedItem, KeyValuePair(Of String, String)).Value

            G_ID_ResourceProject = ID_ProjectResource

            Me.Close()


        Catch ex As Exception

        End Try

    End Sub
End Class