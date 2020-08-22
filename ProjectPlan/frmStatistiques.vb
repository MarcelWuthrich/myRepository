Imports System.Data.SqlClient



Public Class frmStatistics

    Dim InitialLoad As Boolean = True

    Private Sub btcClose_Click(sender As Object, e As EventArgs) Handles btcClose.Click

        Try
            Me.Close()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub frmStatistics_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Try

            'On charge la liste des membres de projets
            pLoadMembers()

            'On charge la liste des projets
            pLoadProjects()

            'Les membres sont chargé, à partir de maintenant on peut lire les FreeDays
            InitialLoad = False

            'On sélectionne le premier membre de la liste --> cela déclenche automatiquement le calcul des statistiques
            If lstMembers.Items.Count > 0 Then lstMembers.SetSelected(0, True)

            'On sélectionne le premier project de la liste --> cela déclenche automatiquement le calcul des statistiques
            If lstProjects.Items.Count > 0 Then lstProjects.SetSelected(0, True)


        Catch ex As Exception

        End Try

    End Sub

    Private Sub pLoadMembers()

        Try


            Me.lstMembers.Items.Clear()

            Dim myDictionnary As New Dictionary(Of String, String)()



            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT ID_ProjectMember, FirstName, Lastname FROM ProjectsMembers where Enable = 1 ;"
            Dim MySQLConnection As New SqlConnection


            MySQLConnection.ConnectionString = cnProjectPlan


            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)

            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read


                Try
                    Dim _ID_ProjectMember As Integer = 0
                    Dim _FirstName As String = ""
                    Dim _LastName As String = ""

                    Try
                        _ID_ProjectMember = mySQLDataReader.GetValue(0)
                    Catch ex As Exception
                    End Try

                    Try
                        _FirstName = mySQLDataReader.GetString(1)
                    Catch ex As Exception
                    End Try

                    Try
                        _LastName = mySQLDataReader.GetString(2)
                    Catch ex As Exception
                    End Try


                    myDictionnary.Add(Str(_ID_ProjectMember), _LastName & " " & _FirstName)

                Catch ex As Exception
                End Try

            End While

            mySQLDataReader.Close()
            MySQLConnection.Close()

            Me.lstMembers.DataSource = New BindingSource(myDictionnary, Nothing)
            Me.lstMembers.DisplayMember = "Value"
            Me.lstMembers.ValueMember = "Key)"

            'If lstMembers.Items.Count > 0 Then lstMembers.SetSelected(0, True)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub pLoadProjects()

        Try


            Me.lstProjects.Items.Clear()

            Dim myDictionnary As New Dictionary(Of String, String)()



            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT DISTINCT CE_ID_Project FROM PlanResources;"
            Dim MySQLConnection As New SqlConnection


            MySQLConnection.ConnectionString = cnProjectPlan


            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)

            mySQLDataReader = mySQLCommand.ExecuteReader()

            Dim thisProject As New myProject

            While mySQLDataReader.Read

                Try
                    thisProject.ID_Project = mySQLDataReader.GetValue(0)
                Catch ex As Exception
                End Try

                'On enlève des resources planifiées admin
                If thisProject.ID_Project <> 0 Then
                    thisProject.Read()
                    myDictionnary.Add(Str(thisProject.ID_Project), thisProject.Title)
                End If

            End While

            mySQLDataReader.Close()
            MySQLConnection.Close()

            Me.lstProjects.DataSource = New BindingSource(myDictionnary, Nothing)
            Me.lstProjects.DisplayMember = "Value"
            Me.lstProjects.ValueMember = "Key)"

            'If lstProjects.Items.Count > 0 Then lstProjects.SetSelected(0, True)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub lstProjectMembers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstMembers.SelectedIndexChanged

        Try

            'On ne veut pas passer 2x dans la boucle
            'On vient dans la boucle uniquement lorsqu'on a chargö les membres dans lstprojectmembers
            If InitialLoad = True Then Exit Sub

            'On lit le membre de projet sélectionné
            Dim ID_ProjectMember As String = DirectCast(lstMembers.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim ProjectMember As String = DirectCast(lstMembers.SelectedItem, KeyValuePair(Of String, String)).Value

            Me.texProjectMember.Text = ProjectMember

            Dim thisStat As New myStatistics
            thisStat.ID_ProjectMember = ID_ProjectMember

            Me.labEndYear.Text = "Fin " & Format(Year(Today), "0000")

            thisStat.GetProjectDays()
            Me.texStatProjects1Month.Text = thisStat.DaysOnProjects1Month
            Me.texStatProjects3Month.Text = thisStat.DaysOnProjects3Month
            Me.texStatProjects6Month.Text = thisStat.DaysOnProjects6Month
            Me.texStatProjects12Month.Text = thisStat.DaysOnProjects12Month
            Me.texStatProjectsEndYear.Text = thisStat.DaysOnProjectsEndYear

            thisStat.GetAdminDays()
            Me.texStatAdmin1Month.Text = thisStat.DaysOnAdmin1Month
            Me.texStatAdmin3Month.Text = thisStat.DaysOnAdmin3Month
            Me.texStatAdmin6Month.Text = thisStat.DaysOnAdmin6Month
            Me.texStatAdmin12Month.Text = thisStat.DaysOnAdmin12Month
            Me.texStatAdminEndYear.Text = thisStat.DaysOnAdminEndYear

            thisStat.GetFreeDays()
            Me.texStatFree1Month.Text = thisStat.DaysFree1Month
            Me.texStatFree3Month.Text = thisStat.DaysFree3Month
            Me.texStatFree6Month.Text = thisStat.DaysFree6Month
            Me.texStatFree12Month.Text = thisStat.DaysFree12Month
            Me.texStatFreeEndYear.Text = thisStat.DaysFreeEndYear

            thisStat.GetProjectList()
            Me.texProjects.Text = thisStat.ProjectList

            thisStat.GetAdminList()
            Me.texAdminTasks.Text = thisStat.AdminList

        Catch ex As Exception

        End Try

    End Sub

    Private Sub lstProjects_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstProjects.SelectedIndexChanged

        Try

            'On ne veut pas passer 2x dans la boucle
            'On vient dans la boucle uniquement lorsqu'on a chargö les membres dans lstprojects
            If InitialLoad = True Then Exit Sub

            'On lit le membre de projet sélectionné
            Dim ID_Project As String = DirectCast(lstProjects.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim ProjectTitle As String = DirectCast(lstProjects.SelectedItem, KeyValuePair(Of String, String)).Value

            Dim thisProject As New myProject
            thisProject.ID_Project = ID_Project
            thisProject.Read()

            Me.texProjectDescription.Text = thisProject.Description
            Me.texProjectDeadline.Text = Format(thisProject.DeadLine, "d")
            Me.texProjectDaysInitialPlaned.Text = Format(thisProject.EstimatedResources, "0.0")
            Me.texProjectRate.Text = thisProject.ImplementationRate & " %"
            Me.texEffectiveResources.Text = Format(thisProject.EffectiveResources, "0.0")

            Dim thisStat As New myStatistics
            thisStat.ID_Project = thisProject.ID_Project
            thisStat.GetPlanedDaysOnProject()
            Me.texProjectDaysEffectivePlaned.Text = Format(thisStat.DaysOnProjectPlaned, "0.0")
            Me.texEffectivePlusEstimatedResources.Text = Format(thisStat.DaysOnProjectPlaned + thisProject.EffectiveResources, "0.0")

            pLoadProjectMembers(thisProject.ID_Project)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub pLoadProjectMembers(ID_Project As Integer)

        Try


            Me.lstProjectMembers.DataSource = Nothing
            Me.lstProjectMembers.Items.Clear()

            Dim myDictionnary As New Dictionary(Of String, String)()



            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT ID_Resource FROM PlanResources WHERE CE_ID_Project = " & ID_Project & " ORDER BY PlanDate, HalfDay, CE_ID_ProjectMember"

            Dim MySQLConnection As New SqlConnection


            MySQLConnection.ConnectionString = cnProjectPlan


            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)

            mySQLDataReader = mySQLCommand.ExecuteReader()


            Dim thisResource As New myPlanResource
            Dim thisMember As New myProjectMember

            While mySQLDataReader.Read

                Try
                    thisResource.ID_Resource = mySQLDataReader.GetValue(0)
                Catch ex As Exception
                End Try

                thisResource.Read()
                thisMember.ID_ProjectMember = thisResource.CE_ID_ProjectMember
                thisMember.Read()

                Select Case thisResource.HalfDay
                    Case 1
                        myDictionnary.Add(Str(thisResource.ID_Resource), Format(thisResource.PlanDate, "D") & " (matin) - " & thisMember.FullName)
                    Case 2
                        myDictionnary.Add(Str(thisResource.ID_Resource), Format(thisResource.PlanDate, "D") & " (après-midi) - " & thisMember.FullName)
                End Select

            End While

            mySQLDataReader.Close()
            MySQLConnection.Close()

            Me.lstProjectMembers.DataSource = New BindingSource(myDictionnary, Nothing)
            Me.lstProjectMembers.DisplayMember = "Value"
            Me.lstProjectMembers.ValueMember = "Key)"

            'If lstProjectMembers.Items.Count > 0 Then lstProjectMembers.SetSelected(0, True)

        Catch ex As Exception

        End Try
    End Sub

End Class