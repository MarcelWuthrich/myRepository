Imports System.Data.SqlClient

Public Class frmSelectDB



    Private Sub btcConnect_Click(sender As Object, e As EventArgs) Handles btcConnect.Click

        Try

            pCreateConnectionString()

            'If Me.radDBProd.Checked = True Then cnProjectPlan = cnProjectPlanProd
            'If Me.radDBTest.Checked = True Then cnProjectPlan = cnProjectPlanTest
            'If Me.radDBWUM.Checked = True Then cnProjectPlan = cnProjectPlanWUM

            Me.Close()

        Catch ex As Exception
        End Try

    End Sub

    Private Sub frmSelectDB_Close(sender As Object, e As EventArgs) Handles MyBase.Closing

        Try

            If cnProjectPlan = "" Then Application.Exit()

        Catch ex As Exception
        End Try

    End Sub

    Private Sub frmSelectDB_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim DBName As String = ""
        Dim DBID As Integer = 0
        Dim myDictionnary As New Dictionary(Of String, String)()

        Me.labOKNOK.Text = ""

        DBID = 1
        DBName = "Productive Database"
        myDictionnary.Add(Str(DBID), DBName)

        DBID = 2
        DBName = "Test Database"
        myDictionnary.Add(Str(DBID), DBName)

        DBID = 3
        DBName = "WUM Private Database"
        myDictionnary.Add(Str(DBID), DBName)

        Me.lovDB.DataSource = New BindingSource(myDictionnary, Nothing)



        Me.lovDB.DisplayMember = "Value"
        Me.lovDB.ValueMember = "Key"

        Me.lovDB.SelectedIndex = 2

    End Sub

    Private Sub lovDB_SelectedValueChanged(sender As Object, e As EventArgs) Handles lovDB.SelectedValueChanged

        Try

            Me.labOKNOK.Text = ""

            Dim ID_Database As Integer = Val(DirectCast(lovDB.SelectedItem, KeyValuePair(Of String, String)).Key)

            Select Case ID_Database

                Case 1
                    Me.texUsername.Text = "ProjectPlan"
                    Me.texPassword.Text = "write_projectplan"
                    Me.texServerName.Text = "SRV-ESB-020\ITTOOLS"
                    Me.texDatabaseName.Text = "ProjectPlan"

                Case 2
                    Me.texUsername.Text = "ProjectPlan"
                    Me.texPassword.Text = "write_projectplan"
                    Me.texServerName.Text = "SRV-ESB-020\ITTOOLS"
                    Me.texDatabaseName.Text = "ProjectPlanTest"

                Case 3
                    Me.texUsername.Text = ""
                    Me.texPassword.Text = ""
                    Me.texServerName.Text = "(localdb)\MSSQLLocalDB"
                    Me.texDatabaseName.Text = "ProjectPlan"

            End Select

        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Sub btcTestConnexion_Click(sender As Object, e As EventArgs) Handles btcTestConnexion.Click

        Cursor.Current = Cursors.WaitCursor

        Try

            pCreateConnectionString()

            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT TOP 1 ID_Status FROM Status ;"
            Dim MySQLConnection As New SqlConnection

            MySQLConnection.ConnectionString = cnProjectPlan

            Try
                MySQLConnection.Open()
                Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)
                mySQLDataReader = mySQLCommand.ExecuteReader()
                MySQLConnection.Close()
                Me.labOKNOK.Text = "OK"
                Me.labOKNOK.ForeColor = Color.Green
            Catch ex As Exception
                Me.labOKNOK.Text = "NOK"
                Me.labOKNOK.ForeColor = Color.Red
            End Try



        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try

        Cursor.Current = Cursors.Default

    End Sub

    Private Sub pCreateConnectionString()

        Try

            Dim ID_Database As Integer = Val(DirectCast(lovDB.SelectedItem, KeyValuePair(Of String, String)).Key)

            Select Case ID_Database

                Case 1, 2
                    cnProjectPlan = "user id=" & Me.texUsername.Text & ";Password=" & Me.texPassword.Text & ";data source=" & Me.texServerName.Text & ";persist security info=False;initial catalog=" & Me.texDatabaseName.Text

                Case 3
                    cnProjectPlan = "Data Source=" & Me.texServerName.Text & ";Initial Catalog=" & Me.texDatabaseName.Text & ";Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"

            End Select

        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try

    End Sub


End Class