Imports System.Data.SqlClient


Public Class frmManage



    Private Sub frmManage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            pLoadPlanResources()
        Catch ex As Exception
        End Try

    End Sub


    Private Sub pLoadPlanResources()

        Try

            Me.lstPlanResources.Items.Clear()

            Dim thisResource As New myPlanResource
            Dim thisProject As New myProject
            Dim thisAdmin As New myAdminResource
            Dim thisMember As New myProjectMember

            Dim Line As String = ""

            Dim Category As String = ""
            Dim ID_Category As Integer = 0

            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT ID_Resource FROM PlanResources WHERE PlanDate < '" & fConvertDateOnlySQL(Today) & "' ORDER BY PlanDate, HalfDay ASC;"
            Dim MySQLConnection As New SqlConnection


            MySQLConnection.ConnectionString = cnProjectPlan
            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)
            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read

                Try

                    Try
                        thisResource.ID_Resource = mySQLDataReader.GetValue(0)
                    Catch ex As Exception
                    End Try

                    thisResource.Read()

                    thisMember.ID_ProjectMember = thisResource.CE_ID_ProjectMember
                    thisMember.Read()

                    If thisResource.CE_ID_AdminResource <> 0 Then
                        thisAdmin.ID_AdminResource = thisResource.CE_ID_AdminResource
                        thisAdmin.read()
                    End If

                    If thisResource.CE_ID_Project <> 0 Then
                        thisProject.ID_Project = thisResource.CE_ID_Project
                        thisProject.Read()
                    End If


                    If thisResource.HalfDay = 1 Then
                        If thisResource.CE_ID_AdminResource <> 0 Then
                            Line = Format(thisResource.PlanDate, "D") & " (matin) / " & thisMember.FullName & " / " & thisAdmin.AdminResource
                        End If
                        If thisResource.CE_ID_Project <> 0 Then
                            Line = Format(thisResource.PlanDate, "D") & " (matin) / " & thisMember.FullName & " / " & thisProject.Title
                        End If
                    End If

                    If thisResource.HalfDay = 2 Then
                        If thisResource.CE_ID_AdminResource <> 0 Then
                            Line = Format(thisResource.PlanDate, "D") & " (après-midi) / " & thisMember.FullName & " / " & thisAdmin.AdminResource
                        End If
                        If thisResource.CE_ID_Project <> 0 Then
                            Line = Format(thisResource.PlanDate, "D") & " (après-midi) / " & thisMember.FullName & " / " & thisProject.Title
                        End If
                    End If


                    Try
                        ID_Category = thisResource.ID_Resource
                    Catch ex As Exception
                    End Try

                    lstPlanResources.Items.Add(Line)

                Catch ex As Exception
                End Try

            End While

            mySQLDataReader.Close()
            MySQLConnection.Close()




        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try

    End Sub

    'Private Sub btcValidate_Click(sender As Object, e As EventArgs)

    '    Try

    '        'Dim I As Integer = 0
    '        'Dim ID_resource As String = ""
    '        'Dim thisPlanResource As New myPlanResource
    '        'Dim Count As Integer = 0

    '        'Cursor.Current = Cursors.WaitCursor

    '        'For I = 0 To chklovPlanResources.CheckedItems.Count - 1
    '        '    'If = True Then

    '        '    'On lit le membre de projet sélectionné
    '        '    ID_resource = DirectCast(chklovPlanResources.CheckedItems(I), KeyValuePair(Of String, String)).Key
    '        '    'Title = DirectCast(chklovPlanResources.Items(I), KeyValuePair(Of String, String)).Value

    '        '    thisPlanResource.ID_Resource = ID_resource
    '        '    thisPlanResource.Read()
    '        '    SetPlanToExecutedSQLTransaction(cnProjectPlan, thisPlanResource)

    '        '    'On sauve le projet avec le nouveau taux de réalisation
    '        '    Dim thisProject As New myProject
    '        '    thisProject.ID_Project = thisPlanResource.CE_ID_Project
    '        '    thisProject.Read()
    '        '    thisProject.GetEffectiveResources()
    '        '    If thisProject.EstimatedResources = 0 Then
    '        '        thisProject.ImplementationRate = 0
    '        '    Else
    '        '        thisProject.ImplementationRate = CInt(thisProject.EffectiveResources / thisProject.EstimatedResources * 100)
    '        '    End If
    '        '    thisProject.Save()

    '        '    Count = Count + 1

    '        '    'End If
    '        'Next I

    '        ''Actualisation de l'affichage
    '        'Call frmTabResources.pDisplayResourcesTable()

    '        'Cursor.Current = Cursors.Default

    '        'Select Case Count

    '        '    Case 0
    '        '        MessageBox.Show("pas de ressource validée")

    '        '    Case 1
    '        '        MessageBox.Show("1 ressource validée")

    '        '    Case >= 2
    '        '        MessageBox.Show(Count & " ressources validées")
    '        'End Select

    '    Catch ex As Exception
    '        If DebugFlag = True Then MessageBox.Show(ex.ToString)
    '    End Try

    'End Sub

    'Private Sub btcValidateAdmin_Click(sender As Object, e As EventArgs) Handles btcValidate.Click

    '    Try






    '        'Dim thisPlanResource As New myPlanResource
    '        'Dim Count As Integer = 0

    '        'Dim mySQLDataReader As SqlDataReader
    '        'Dim SQL As String = ""
    '        'Dim MySQLConnection As New SqlConnection

    '        'Cursor.Current = Cursors.WaitCursor

    '        'MySQLConnection.ConnectionString = cnProjectPlan
    '        'MySQLConnection.Open()


    '        'SQL = "SELECT ID_Resource FROM PlanResources WHERE CE_ID_AdminResource <> 0 AND "

    '        ''Si on a une date, on filtre sur la date
    '        'If Me.chkDateTo.Checked = True Then
    '        '    SQL = SQL & " PlanDate <= '" & fConvertDateOnlySQL(Me.dptDateTo.Value) & "'"
    '        'Else
    '        '    SQL = SQL & " PlanDate <= '" & fConvertDateOnlySQL(Today) & "'"
    '        'End If


    '        '''Si on a un membre de projet, on filtre sur le membre du projet
    '        ''If Me.chkProjectMember.Checked = True Then
    '        ''    'On lit le client
    '        ''    Dim ID_ProjectMember As String = DirectCast(lovProjectMembers.SelectedItem, KeyValuePair(Of String, String)).Key
    '        ''    SQL = SQL & " AND CE_ID_ProjectMember = " & ID_ProjectMember & ";"
    '        ''Else
    '        ''    SQL = SQL & ";"
    '        ''End If

    '        'Dim mySQLCommand As SqlCommand = New SqlCommand(SQL, MySQLConnection)
    '        'mySQLDataReader = mySQLCommand.ExecuteReader()

    '        'While mySQLDataReader.Read


    '        '    Try

    '        '        Try
    '        '            thisPlanResource.ID_Resource = mySQLDataReader.GetValue(0)
    '        '        Catch ex As Exception
    '        '        End Try

    '        '        thisPlanResource.Read()
    '        '        SetPlanToExecutedSQLTransaction(cnProjectPlan, thisPlanResource)
    '        '        Count = Count + 1

    '        '    Catch ex As Exception
    '        '    End Try

    '        'End While

    '        'mySQLDataReader.Close()
    '        'MySQLConnection.Close()

    '        ''Actualisation de l'affichage
    '        'Call frmTabResources.pDisplayResourcesTable()

    '        'Cursor.Current = Cursors.Default

    '        'Select Case Count

    '        '    Case 0
    '        '        MessageBox.Show("pas de ressource validée")

    '        '    Case 1
    '        '        MessageBox.Show("1 ressource validée")

    '        '    Case >= 2
    '        '        MessageBox.Show(Count & " ressources validées")
    '        'End Select


    '    Catch ex As Exception

    '    End Try

    'End Sub

    Private Sub SetPlanToExecutedSQLTransaction(ByVal connectionString As String, thisPlanResource As myPlanResource)

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Dim command As SqlCommand = connection.CreateCommand()
            Dim transaction As SqlTransaction

            ' Start a local transaction
            transaction = connection.BeginTransaction("SetPlanToExecuted")

            ' Must assign both transaction object and connection
            ' to Command object for a pending local transaction.
            command.Connection = connection
            command.Transaction = transaction

            Try
                Dim SQL As String = ""
                SQL = "INSERT INTO ExecutedResources (ID_Resource,CE_ID_ProjectMember,CE_ID_Project,CE_ID_AdminResource,PlanDate,HalfDay,Timestamp) "
                SQL &= " VALUES (" & thisPlanResource.ID_Resource & "," & thisPlanResource.CE_ID_ProjectMember & ","
                SQL &= thisPlanResource.CE_ID_Project & "," & thisPlanResource.CE_ID_AdminResource & ",'" & fConvertDateOnlySQL(thisPlanResource.PlanDate) & "'," & thisPlanResource.HalfDay & ",'" & fConvertDateTimeSQL(Now) & "');"
                command.CommandText = SQL
                command.ExecuteNonQuery()

                SQL = "DELETE FROM PlanResources WHERE ID_Resource=" & thisPlanResource.ID_Resource
                command.CommandText = SQL
                command.ExecuteNonQuery()

                ' Attempt to commit the transaction.
                transaction.Commit()
                Debug.WriteLine("Both records are written to database.")

            Catch ex As Exception
                Debug.WriteLine("Commit Exception Type: {0}", ex.GetType())
                Debug.WriteLine("  Message: {0}", ex.Message)

                ' Attempt to roll back the transaction.
                Try
                    transaction.Rollback()

                Catch ex2 As Exception
                    ' This catch block will handle any errors that may have occurred
                    ' on the server that would cause the rollback to fail, such as
                    ' a closed connection.
                    Debug.WriteLine("Rollback Exception Type: {0}", ex2.GetType())
                    Debug.WriteLine("  Message: {0}", ex2.Message)
                End Try
            End Try
        End Using

    End Sub

    Private Sub btcFermer_Click(sender As Object, e As EventArgs) Handles btcFermer.Click
        Try
            Me.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btcPlanAgainFree_Click(sender As Object, e As EventArgs)

        Try

            'Dim PlanCount As Integer = Me.chklovPlanResources.CheckedItems.Count
            'Dim ID_Resource As Integer = 0
            'Dim Title As String = ""
            'Dim thisPlanResource As New myPlanResource
            'Dim tmp As New myPlanResource

            'Dim Message As String = ""
            'Dim Caption As String = ""
            'Dim Buttons As MessageBoxButtons
            'Dim Icon As MessageBoxIcon
            'Dim Result As New DialogResult

            'Cursor.Current = Cursors.WaitCursor

            'Dim NewDate As Date = Today

            'For I = 0 To PlanCount - 1


            '    'On lit le membre de projet sélectionné
            '    ID_Resource = DirectCast(chklovPlanResources.CheckedItems(I), KeyValuePair(Of String, String)).Key
            '    Title = DirectCast(chklovPlanResources.CheckedItems(I), KeyValuePair(Of String, String)).Value
            '    thisPlanResource.ID_Resource = ID_Resource
            '    thisPlanResource.Read()

            '    'MessageBox.Show(ID_Resource & " " & Title)
            '    tmp.ID_Resource = ID_Resource
            '    tmp.Read()
            '    tmp.PlanDate = NewDate
            '    tmp.IsPlaned = True


            '    Do Until tmp.IsPlaned = False

            '        If Weekday(NewDate) = vbSaturday Or Weekday(NewDate) = vbSunday Then
            '            'on ne fait rien
            '        Else
            '            tmp.PlanDate = NewDate
            '            tmp.CheckIfPlaned()
            '            Dim y As Integer = 0
            '        End If

            '        NewDate = DateAdd(DateInterval.Day, 1, NewDate)

            '    Loop

            '    Message &= Format(tmp.PlanDate, "D") & vbCrLf
            '    thisPlanResource.PlanDate = tmp.PlanDate
            '    thisPlanResource.Save()

            'Next I

            'pLoadPlanResources()

            'Message = "Les nouvelles dates planifiées sont : " & vbCrLf & vbCrLf & Message

            'pLoadPlanResources()
            'Call frmTabResources.pDisplayResourcesTable()
            'Cursor.Current = Cursors.Default

            ''Displays the MessageBox
            'Caption = "Planification"
            'Buttons = MessageBoxButtons.OK
            'Icon = MessageBoxIcon.Information
            'Result = MessageBox.Show(Message, Caption, Buttons, Icon)

        Catch ex As Exception
        End Try

    End Sub

    Private Sub btcCheckDouble_Click(sender As Object, e As EventArgs) Handles btcCheckDouble.Click

        Try
            'Dim Max_ID_Resource As Integer = 0

            'Dim MySQLConn As New SqlConnection
            'Dim mySQLDataReader As SqlDataReader
            'Dim Sql As String = "SELECT TOP 1 ID_Resource FROM PlanResources ORDER BY ID_Resource DESC;"

            'MySQLConn.ConnectionString = cnProjectPlan
            'MySQLConn.Open()
            'Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConn)
            'mySQLDataReader = mySQLCommand.ExecuteReader()

            'Try
            '    If mySQLDataReader.Read Then
            '        Max_ID_Resource = mySQLDataReader.GetValue(0)
            '    End If
            'Catch ex As Exception
            'End Try
            'mySQLDataReader.Close()
            'MySQLConn.Close()

            'Dim I As Integer = 0
            'Dim myPlan As New myPlanResource
            'Dim myExec As New myExecuteResource
            'Dim ResultString As String = ""

            'For I = 1 To Max_ID_Resource

            '    myPlan.ID_Resource = I
            '    myPlan.Read()
            '    myExec.ID_Resource = I
            '    myExec.Read()

            '    If myPlan.ID_Resource = myExec.ID_Resource And myPlan.ID_Resource <> 0 Then

            '        Dim myPlanMember As New myProjectMember
            '        Dim myExecMember As New myProjectMember

            '        Dim myPlanAdminResource As New myAdminResource
            '        Dim myExecAdminResource As New myProject

            '        Dim myPlanProjectResource As New myAdminResource
            '        Dim myExecProjectResource As New myProject

            '        myPlanMember.ID_ProjectMember = myPlan.CE_ID_ProjectMember
            '        myPlanMember.Read()

            '        myExecMember.ID_ProjectMember = myExec.CE_ID_ProjectMember
            '        myExecMember.Read()

            '        'Affichage de l'ID
            '        ResultString &= "ID_Resource " & myPlan.ID_Resource & vbCrLf

            '        'Affichage de la ressource planifiée
            '        ResultString &= "planifiée le " & myPlan.PlanDate
            '        If myPlan.IsAdminResource Then
            '            Dim myAR As New myAdminResource
            '            myAR.ID_AdminResource = myPlan.CE_ID_AdminResource
            '            myAR.read()
            '            ResultString &= " - " & myAR.AdminResource & " - " & myPlanMember.FullName & vbCrLf
            '        End If
            '        If myPlan.IsProjectResource Then
            '            Dim myP As New myProject
            '            myP.ID_Project = myPlan.CE_ID_Project
            '            myP.Read()
            '            ResultString &= " - " & myP.Title & " - " & myPlanMember.FullName & vbCrLf
            '        End If

            '        'Affichage de la ressource exécutée
            '        ResultString &= "exécuté le " & myPlan.PlanDate
            '        If myExec.CE_ID_AdminResource <> 0 Then
            '            Dim myAR As New myAdminResource
            '            myAR.ID_AdminResource = myExec.CE_ID_AdminResource
            '            myAR.read()
            '            ResultString &= " - " & myAR.AdminResource & " - " & myPlanMember.FullName & vbCrLf
            '        End If
            '        If myExec.CE_ID_Project <> 0 Then
            '            Dim myP As New myProject
            '            myP.ID_Project = myExec.CE_ID_Project
            '            myP.Read()
            '            ResultString &= " - " & myP.Title & " - " & myPlanMember.FullName & vbCrLf
            '        End If

            '        ResultString &= vbCrLf

            '    End If

            'Next I

            'If ResultString = "" Then
            '    MessageBox.Show("Aucun doublon trouvé !")
            'Else
            '    MessageBox.Show(ResultString)
            'End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub lstPlanResources_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstPlanResources.SelectedIndexChanged
        Try
            'On lit le membre de projet sélectionné
            Dim ID_Resource As String = DirectCast(lstPlanResources.SelectedItem, KeyValuePair(Of String, String)).Key

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btcValidate_Click(sender As Object, e As EventArgs) Handles btcValidate.Click

        Try

            Dim thisResource As New myPlanResource
            Dim mySQLDataReader As SqlDataReader
            Dim MySQLConnection As New SqlConnection
            Dim Sql As String = ""
            Dim Count As Integer = 0

            If Me.chkDateTo.Checked = True Then
                Sql = "SELECT ID_Resource FROM PlanResources WHERE PlanDate <= '" & fConvertDateOnlySQL(Me.dptDateTo.Value) & "' ORDER BY PlanDate, HalfDay ASC;"
            Else
                Sql = "SELECT ID_Resource FROM PlanResources WHERE PlanDate < '" & fConvertDateOnlySQL(Today) & "' ORDER BY PlanDate, HalfDay ASC;"
            End If

            MySQLConnection.ConnectionString = cnProjectPlan
            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)
            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read

                Try
                    thisResource.ID_Resource = mySQLDataReader.GetValue(0)
                    thisResource.Read()
                    SetPlanToExecutedSQLTransaction(cnProjectPlan, thisResource)
                    Count = Count + 1

                    If thisResource.CE_ID_Project <> 0 Then
                        Dim myProject As New myProject
                        myProject.ID_Project = thisResource.CE_ID_Project
                        myProject.Read()
                        myProject.GetEffectiveResources()
                        myProject.ImplementationRate = myProject.EffectiveResources / myProject.EstimatedResources * 100
                        myProject.Save()
                    End If

                Catch ex As Exception
                End Try
            End While

            mySQLDataReader.Close()
            MySQLConnection.Close()


            pLoadPlanResources()

            Call frmTabResources.pDisplayResourcesTable()

            Select Case Count
                Case 0
                    MessageBox.Show("pas de ressource validée")
                Case 1
                    MessageBox.Show("1 ressource validée")
                Case >= 2
                    MessageBox.Show(Count & " ressources validées")
            End Select

        Catch ex As Exception
        End Try

    End Sub
End Class