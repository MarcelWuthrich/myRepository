Imports System.Data.SqlClient


Public Class frmPlanProject
    Private Sub frmPlanProject_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try



            'charge les projets
            pPopulateProjects()

        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Sub pPopulateProjects()

        Try
            Cursor.Current = Cursors.WaitCursor

            Me.lstProjects.DataSource = Nothing
            Me.lstProjects.Items.Clear()

            Dim myDictionnary As New Dictionary(Of String, String)()

            Dim thisProject As New myProject

            Dim mySQLDataReader As SqlDataReader
            Dim SQL As String = ""
            Dim Count As Integer = 0

            If Me.radProjectsPlaned.Checked = True Then
                SQL = "SELECT DISTINCT CE_ID_Project FROM PlanResources WHERE CE_ID_Project > 0 ;"
            End If

            If Me.radProjectsAll.Checked = True Then
                SQL = "SELECT DISTINCT ID_Project FROM Projects WHERE ID_Project > 0;"
            End If

            Dim MySQLConnection As New SqlConnection
            MySQLConnection.ConnectionString = cnProjectPlan


            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)

            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read


                Try

                    Try
                        thisProject.ID_Project = mySQLDataReader.GetValue(0)
                        Count = Count + 1
                    Catch ex As Exception
                    End Try

                    thisProject.Read()

                    myDictionnary.Add(Str(thisProject.ID_Project), thisProject.Title)

                Catch ex As Exception
                End Try

            End While

            mySQLDataReader.Close()
            MySQLConnection.Close()

            Me.labProjectNumber.Text = "Nombre de projets : " & Str(Count)

            Me.lstProjects.DataSource = New BindingSource(myDictionnary, Nothing)
            Me.lstProjects.DisplayMember = "Value"
            Me.lstProjects.ValueMember = "Key"

            If Me.lstProjects.Items.Count > 0 Then

                lstProjects.SetSelected(0, True)

                'On lit le projet sélectionné
                Dim ID_Project As String = ""
                ID_Project = DirectCast(lstProjects.SelectedItem, KeyValuePair(Of String, String)).Key

                Dim Project As String = ""
                Project = DirectCast(lstProjects.SelectedItem, KeyValuePair(Of String, String)).Value

                'On affiche les ressources planifiés
                pPopulatePlanResources(ID_Project)

                'On affiche les ressources exécutées
                pPopulateExecutedResources(ID_Project)

            End If

            Cursor.Current = Cursors.Default

        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub radProjectsPlaned_CheckedChanged(sender As Object, e As EventArgs) Handles radProjectsPlaned.CheckedChanged

        Try

            pPopulateProjects()

        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Sub radProjectsAll_CheckedChanged(sender As Object, e As EventArgs) Handles radProjectsAll.CheckedChanged

        Try

            pPopulateProjects()

        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Sub lstProjects_Click(sender As Object, e As EventArgs) Handles lstProjects.Click

        'On lit le projet sélectionné
        Dim ID_Project As String = DirectCast(lstProjects.SelectedItem, KeyValuePair(Of String, String)).Key
        Dim Project As String = DirectCast(lstProjects.SelectedItem, KeyValuePair(Of String, String)).Value

        'On affiche les ressources planifiés
        pPopulatePlanResources(ID_Project)

        'On affiche les ressources exécutées
        pPopulateExecutedResources(ID_Project)


    End Sub

    Private Sub pPopulatePlanResources(ID_Project As Integer)

        Try

            Cursor.Current = Cursors.WaitCursor

            Me.lstPlanResources.DataSource = Nothing
            Me.lstPlanResources.Items.Clear()
            Dim myDictionnary As New Dictionary(Of String, String)()

            Dim thisResource As New myPlanResource
            Dim thisMember As New myProjectMember
            Dim mySQLDataReader As SqlDataReader
            Dim SQL As String = ""
            Dim FoundData As Boolean = False
            Dim Count As Single = 0


            SQL = "SELECT ID_Resource FROM PlanResources where CE_ID_Project = " & ID_Project & " ORDER BY PlanDate ASC"
            Dim MySQLConnection As New SqlConnection
            MySQLConnection.ConnectionString = cnProjectPlan

            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(SQL, MySQLConnection)

            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read


                Try

                    Try
                        thisResource.ID_Resource = mySQLDataReader.GetValue(0)
                        FoundData = True
                        thisResource.Read()

                        thisMember.ID_ProjectMember = thisResource.CE_ID_ProjectMember
                        thisMember.Read()

                        If thisResource.HalfDay = 1 Or thisResource.HalfDay = 2 Then
                            Count = Count + 0.5
                        Else
                            Count = Count + 1
                        End If
                    Catch ex As Exception
                    End Try


                    Select Case thisResource.HalfDay
                        Case 1
                            myDictionnary.Add(Str(thisResource.ID_Resource), thisResource.PlanDate & " (matin) : " & thisMember.FullName)
                        Case 2
                            myDictionnary.Add(Str(thisResource.ID_Resource), thisResource.PlanDate & " (après-midi) : " & thisMember.FullName)
                        Case Else
                            myDictionnary.Add(Str(thisResource.ID_Resource), thisResource.PlanDate & " : " & thisMember.FullName)
                    End Select


                Catch ex As Exception
                End Try

            End While

            mySQLDataReader.Close()
            MySQLConnection.Close()

            If FoundData = True Then
                Me.lstPlanResources.DataSource = New BindingSource(myDictionnary, Nothing)
                Me.lstPlanResources.DisplayMember = "Value"
                Me.lstPlanResources.ValueMember = "Key"
            Else
                Me.lstPlanResources.DataSource = Nothing
                Me.lstPlanResources.Items.Clear()
            End If


            Select Case Count
                Case 0
                    Me.labTotalPlanResources.Text = "Total : aucun jour"
                Case < 2
                    Me.labTotalPlanResources.Text = "Total : " & Format(Count, "0.0") & " jour"
                Case Else
                    Me.labTotalPlanResources.Text = "Total : " & Format(Count, "0.0") & " jours"
            End Select

            Cursor.Current = Cursors.Default

        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Sub pPopulateExecutedResources(ID_Project As Integer)

        Try

            Cursor.Current = Cursors.WaitCursor

            Me.lstExecutedResources.DataSource = Nothing
            Me.lstExecutedResources.Items.Clear()
            Dim myDictionnary As New Dictionary(Of String, String)()

            Dim thisResource As New myExecuteResource
            Dim thisMember As New myProjectMember
            Dim mySQLDataReader As SqlDataReader
            Dim SQL As String = ""
            Dim FoundData As Boolean = False
            Dim Count As Single = 0

            SQL = "SELECT ID_Resource FROM ExecutedResources where CE_ID_Project = " & ID_Project & " ORDER BY PlanDate, HalfDay ASC"
            Dim MySQLConnection As New SqlConnection
            MySQLConnection.ConnectionString = cnProjectPlan

            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(SQL, MySQLConnection)

            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read


                Try

                    Try
                        thisResource.ID_Resource = mySQLDataReader.GetValue(0)
                        FoundData = True
                        thisResource.Read()

                        thisMember.ID_ProjectMember = thisResource.CE_ID_ProjectMember
                        thisMember.Read()

                        If thisResource.HalfDay = 1 Or thisResource.HalfDay = 2 Then
                            Count = Count + 0.5
                        Else
                            Count = Count + 1
                        End If
                    Catch ex As Exception
                    End Try

                    Select Case thisResource.HalfDay
                        Case 1
                            myDictionnary.Add(Str(thisResource.ID_Resource), thisResource.PlanDate & " (matin) : " & thisMember.FullName)
                        Case 2
                            myDictionnary.Add(Str(thisResource.ID_Resource), thisResource.PlanDate & " (après-midi) : " & thisMember.FullName)
                        Case Else
                            myDictionnary.Add(Str(thisResource.ID_Resource), thisResource.PlanDate & " : " & thisMember.FullName)
                    End Select

                Catch ex As Exception
                End Try

            End While

            mySQLDataReader.Close()
            MySQLConnection.Close()

            If founddata = True Then
                Me.lstExecutedResources.DataSource = New BindingSource(myDictionnary, Nothing)
                Me.lstExecutedResources.DisplayMember = "Value"
                Me.lstExecutedResources.ValueMember = "Key"
            Else
                Me.lstExecutedResources.DataSource = Nothing
                Me.lstExecutedResources.Items.Clear()
            End If

            Select Case Count
                Case 0
                    Me.labTotalExecutedResources.Text = "Total : aucun jour"
                Case < 2
                    Me.labTotalExecutedResources.Text = "Total : " & Format(Count, "0.0") & " jour"
                Case Else
                    Me.labTotalExecutedResources.Text = "Total : " & Format(Count, "0.0") & " jours"
            End Select

            Cursor.Current = Cursors.Default

        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Sub btcClose_Click(sender As Object, e As EventArgs) Handles btcClose.Click
        Try
            Me.Close()
        Catch ex As Exception
        End Try
    End Sub

End Class