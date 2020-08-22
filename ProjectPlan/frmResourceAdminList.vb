Imports System.Data.SqlClient


Public Class frmResourceAdminList


    Private Sub frmResourceAdminList_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            pLoadAdminResources()

            Me.lstAdminResources.ClearSelected()

        Catch ex As Exception
        End Try

    End Sub


    Private Sub pLoadAdminResources()

        Try

            Me.lstAdminResources.Items.Clear()

            Dim myDictionnary As New Dictionary(Of String, String)()

            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT ID_AdminResource, AdminResource FROM AdminResources where Enable = 1 ORDER by DisplayOrder ASC;"
            Dim MySQLConnection As New SqlConnection


            MySQLConnection.ConnectionString = cnProjectPlan


            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)

            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read


                Try
                    Dim _Resource As String = ""
                    Dim _ID_Resource As Integer = 0

                    Try
                        _ID_Resource = mySQLDataReader.GetValue(0)
                    Catch ex As Exception
                    End Try

                    Try
                        _Resource = mySQLDataReader.GetString(1)
                    Catch ex As Exception
                    End Try


                    myDictionnary.Add(Str(_ID_Resource), _Resource)

                Catch ex As Exception
                End Try

            End While

            mySQLDataReader.Close()
            MySQLConnection.Close()

            Me.lstAdminResources.DataSource = New BindingSource(myDictionnary, Nothing)
            Me.lstAdminResources.DisplayMember = "Value"
            Me.lstAdminResources.ValueMember = "Key)"


        Catch ex As Exception

        End Try

    End Sub


    Private Sub lstAdminResources_Click(sender As Object, e As EventArgs) Handles lstAdminResources.Click

        Try

            'On lit la ressource administrative sélectionnée
            Dim ID_AdminResource As String = DirectCast(lstAdminResources.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim AdminResource As String = DirectCast(lstAdminResources.SelectedItem, KeyValuePair(Of String, String)).Value

            G_ID_ResourceAdmin = ID_AdminResource

            Me.Close()

        Catch ex As Exception

        End Try

    End Sub
End Class