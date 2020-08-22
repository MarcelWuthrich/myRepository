Imports System.Data.SqlClient



Public Class myStatistics


    Private _ID_ProjectMember As Integer
    Private _ID_Project As Integer
    Private _DaysOnProjectPlaned As Single
    Private _DaysOnProjects1Month As Single
    Private _DaysOnProjects3Month As Single
    Private _DaysOnProjects6Month As Single
    Private _DaysOnProjects12Month As Single
    Private _DaysOnProjectsEndYear As Single
    Private _DaysOnAdmin1Month As Single
    Private _DaysOnAdmin3Month As Single
    Private _DaysOnAdmin6Month As Single
    Private _DaysOnAdmin12Month As Single
    Private _DaysOnAdminEndYear As Single
    Private _DaysFree1Month As Single
    Private _DaysFree3Month As Single
    Private _DaysFree6Month As Single
    Private _DaysFree12Month As Single
    Private _DaysFreeEndYear As Single
    Private _ProjectList As String
    Private _AdminList As String

    Public Property DaysOnProjectsEndYear As Single
        Get
            Return _DaysOnProjectsEndYear
        End Get
        Set(value As Single)
            _DaysOnProjectsEndYear = value
        End Set
    End Property

    Public Property DaysOnAdminEndYear As Single
        Get
            Return _DaysOnAdminEndYear
        End Get
        Set(value As Single)
            _DaysOnAdminEndYear = value
        End Set
    End Property

    Public Property DaysFreeEndYear As Single
        Get
            Return _DaysFreeEndYear
        End Get
        Set(value As Single)
            _DaysFreeEndYear = value
        End Set
    End Property


    Public Property ProjectList As String
        Get
            Return _ProjectList
        End Get
        Set(value As String)
            _ProjectList = value
        End Set
    End Property

    Public Property AdminList As String
        Get
            Return _AdminList
        End Get
        Set(value As String)
            _AdminList = value
        End Set
    End Property

    Public Property DaysFree1Month As Single
        Get
            Return _DaysFree1Month
        End Get
        Set(value As Single)
            _DaysFree1Month = value
        End Set
    End Property

    Public Property DaysFree3Month As Single
        Get
            Return _DaysFree3Month
        End Get
        Set(value As Single)
            _DaysFree3Month = value
        End Set
    End Property

    Public Property DaysFree6Month As Single
        Get
            Return _DaysFree6Month
        End Get
        Set(value As Single)
            _DaysFree6Month = value
        End Set
    End Property

    Public Property DaysFree12Month As Single
        Get
            Return _DaysFree12Month
        End Get
        Set(value As Single)
            _DaysFree12Month = value
        End Set
    End Property

    Public Property DaysOnAdmin12Month As Single
        Get
            Return _DaysOnAdmin12Month
        End Get
        Set(value As Single)
            _DaysOnAdmin12Month = value
        End Set
    End Property

    Public Property DaysOnAdmin6Month As Single
        Get
            Return _DaysOnAdmin6Month
        End Get
        Set(value As Single)
            _DaysOnAdmin6Month = value
        End Set
    End Property

    Public Property DaysOnAdmin3Month As Single
        Get
            Return _DaysOnAdmin3Month
        End Get
        Set(value As Single)
            _DaysOnAdmin3Month = value
        End Set
    End Property

    Public Property DaysOnAdmin1Month As Single
        Get
            Return _DaysOnAdmin1Month
        End Get
        Set(value As Single)
            _DaysOnAdmin1Month = value
        End Set
    End Property

    Public Property DaysOnProjects12Month As Single
        Get
            Return _DaysOnProjects12Month
        End Get
        Set(value As Single)
            _DaysOnProjects12Month = value
        End Set
    End Property

    Public Property DaysOnProjects6Month As Single
        Get
            Return _DaysOnProjects6Month
        End Get
        Set(value As Single)
            _DaysOnProjects6Month = value
        End Set
    End Property

    Public Property DaysOnProjects3Month As Single
        Get
            Return _DaysOnProjects3Month
        End Get
        Set(value As Single)
            _DaysOnProjects3Month = value
        End Set
    End Property

    Public Property DaysOnProjects1Month As Single
        Get
            Return _DaysOnProjects1Month
        End Get
        Set(value As Single)
            _DaysOnProjects1Month = value
        End Set
    End Property

    Public Property DaysOnProjectPlaned As Single
        Get
            Return _DaysOnProjectPlaned
        End Get
        Set(value As Single)
            _DaysOnProjectPlaned = value
        End Set
    End Property

    Public Property ID_ProjectMember As Single
        Get
            Return _ID_ProjectMember
        End Get
        Set(value As Single)
            _ID_ProjectMember = value
        End Set
    End Property

    Public Property ID_Project As Single
        Get
            Return _ID_Project
        End Get
        Set(value As Single)
            _ID_Project = value
        End Set
    End Property

    Public Function GetProjectDays() As myStatistics

        Try

            Try

                'Recherche le nombre de jours planifiés sur des projets pour une personne donnée
                'INPUT : ID_ProjectManager
                'OUTPUT : DaysOnProjects1Month
                'OUTPUT : DaysOnProjects3Month
                'OUTPUT : DaysOnProjects6Month
                'OUTPUT : DaysOnProjects12Month
                'OUTPUT : DaysOnProjectsEndYear

                Dim DateIn1Month As Date = DateAdd(DateInterval.Month, 1, Now)
                Dim DateIn3Month As Date = DateAdd(DateInterval.Month, 3, Now)
                Dim DateIn6Month As Date = DateAdd(DateInterval.Month, 6, Now)
                Dim DateIn12Month As Date = DateAdd(DateInterval.Month, 12, Now)
                Dim DateEndYear As Date = New Date(Year(Today), 12, 31)

                Dim MySQLConnection As New SqlConnection

                Dim mySQLDataReader As SqlDataReader
                MySQLConnection.ConnectionString = cnProjectPlan

                Dim Sql As String = "SELECT COUNT(ID_Resource) FROM PlanResources WHERE CE_ID_ProjectMember = " & Me.ID_ProjectMember & " AND CE_ID_Project <> 0 AND PlanDate <= '" & fConvertDateOnlySQL(DateIn1Month) & "';"

                MySQLConnection.Open()
                Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)
                mySQLDataReader = mySQLCommand.ExecuteReader()
                While mySQLDataReader.Read
                    'Lecture du premier paramètre
                    Try
                        Me.DaysOnProjects1Month = (mySQLDataReader.GetValue(0)) / 2
                    Catch ex As Exception
                    End Try
                End While
                mySQLDataReader.Close()

                Sql = "SELECT COUNT(ID_Resource) FROM PlanResources WHERE CE_ID_ProjectMember = " & Me.ID_ProjectMember & " AND CE_ID_Project <> 0 AND PlanDate <= '" & fConvertDateOnlySQL(DateIn3Month) & "';"

                'MySQLConnection.Open()
                mySQLCommand = New SqlCommand(Sql, MySQLConnection)
                mySQLDataReader = mySQLCommand.ExecuteReader()
                While mySQLDataReader.Read
                    'Lecture du premier paramètre
                    Try
                        Me.DaysOnProjects3Month = (mySQLDataReader.GetValue(0)) / 2
                    Catch ex As Exception
                    End Try
                End While
                mySQLDataReader.Close()

                Sql = "SELECT COUNT(ID_Resource) FROM PlanResources WHERE CE_ID_ProjectMember = " & Me.ID_ProjectMember & " AND CE_ID_Project <> 0 AND PlanDate <= '" & fConvertDateOnlySQL(DateIn6Month) & "';"

                'MySQLConnection.Open()
                mySQLCommand = New SqlCommand(Sql, MySQLConnection)
                mySQLDataReader = mySQLCommand.ExecuteReader()
                While mySQLDataReader.Read
                    'Lecture du premier paramètre
                    Try
                        Me.DaysOnProjects6Month = (mySQLDataReader.GetValue(0)) / 2
                    Catch ex As Exception
                    End Try
                End While
                mySQLDataReader.Close()

                Sql = "SELECT COUNT(ID_Resource) FROM PlanResources WHERE CE_ID_ProjectMember = " & Me.ID_ProjectMember & " AND CE_ID_Project <> 0 AND PlanDate <= '" & fConvertDateOnlySQL(DateIn12Month) & "';"

                'MySQLConnection.Open()
                mySQLCommand = New SqlCommand(Sql, MySQLConnection)
                mySQLDataReader = mySQLCommand.ExecuteReader()
                While mySQLDataReader.Read
                    'Lecture du premier paramètre
                    Try
                        Me.DaysOnProjects12Month = (mySQLDataReader.GetValue(0)) / 2
                    Catch ex As Exception
                    End Try
                End While
                mySQLDataReader.Close()

                Sql = "SELECT COUNT(ID_Resource) FROM PlanResources WHERE CE_ID_ProjectMember = " & Me.ID_ProjectMember & " AND CE_ID_Project <> 0 AND PlanDate <= '" & fConvertDateOnlySQL(DateEndYear) & "';"

                'MySQLConnection.Open()
                mySQLCommand = New SqlCommand(Sql, MySQLConnection)
                mySQLDataReader = mySQLCommand.ExecuteReader()
                While mySQLDataReader.Read
                    'Lecture du premier paramètre
                    Try
                        Me.DaysOnProjectsEndYear = (mySQLDataReader.GetValue(0)) / 2
                    Catch ex As Exception
                    End Try
                End While
                mySQLDataReader.Close()

                MySQLConnection.Close()


            Catch ex As Exception


            End Try


        Catch ex As Exception

        End Try


        Return Me


    End Function

    Public Function GetAdminDays() As myStatistics

        Try

            Try

                'Recherche le nombre de jours planifiés sur de l'administratif pour une personne donnée
                'INPUT : ID_ProjectManager
                'OUTPUT : DaysOnAdmin1Month
                'OUTPUT : DaysOnAdmin3Month
                'OUTPUT : DaysOnAdmin6Month
                'OUTPUT : DaysOnAdmin12Month
                'OUTPUT : DaysOnAdminEndYear

                Dim DateIn1Month As Date = DateAdd(DateInterval.Month, 1, Now)
                Dim DateIn3Month As Date = DateAdd(DateInterval.Month, 3, Now)
                Dim DateIn6Month As Date = DateAdd(DateInterval.Month, 6, Now)
                Dim DateIn12Month As Date = DateAdd(DateInterval.Month, 12, Now)
                Dim DateEndYear As Date = New Date(Year(Today), 12, 31)

                Dim MySQLConnection As New SqlConnection

                Dim mySQLDataReader As SqlDataReader
                MySQLConnection.ConnectionString = cnProjectPlan

                Dim Sql As String = "SELECT COUNT(ID_Resource) FROM PlanResources WHERE CE_ID_ProjectMember = " & Me.ID_ProjectMember & " AND CE_ID_AdminResource <> 0 AND PlanDate <= '" & fConvertDateOnlySQL(DateIn1Month) & "';"

                MySQLConnection.Open()
                Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)
                mySQLDataReader = mySQLCommand.ExecuteReader()
                While mySQLDataReader.Read
                    'Lecture du premier paramètre
                    Try
                        Me.DaysOnAdmin1Month = (mySQLDataReader.GetValue(0)) / 2
                    Catch ex As Exception
                    End Try
                End While
                mySQLDataReader.Close()

                Sql = "SELECT COUNT(ID_Resource) FROM PlanResources WHERE CE_ID_ProjectMember = " & Me.ID_ProjectMember & " AND CE_ID_AdminResource <> 0 AND PlanDate <= '" & fConvertDateOnlySQL(DateIn3Month) & "';"

                'MySQLConnection.Open()
                mySQLCommand = New SqlCommand(Sql, MySQLConnection)
                mySQLDataReader = mySQLCommand.ExecuteReader()
                While mySQLDataReader.Read
                    'Lecture du premier paramètre
                    Try
                        Me.DaysOnAdmin3Month = (mySQLDataReader.GetValue(0)) / 2
                    Catch ex As Exception
                    End Try
                End While
                mySQLDataReader.Close()

                Sql = "SELECT COUNT(ID_Resource) FROM PlanResources WHERE CE_ID_ProjectMember = " & Me.ID_ProjectMember & " AND CE_ID_AdminResource <> 0 AND PlanDate <= '" & fConvertDateOnlySQL(DateIn6Month) & "';"

                'MySQLConnection.Open()
                mySQLCommand = New SqlCommand(Sql, MySQLConnection)
                mySQLDataReader = mySQLCommand.ExecuteReader()
                While mySQLDataReader.Read
                    'Lecture du premier paramètre
                    Try
                        Me.DaysOnAdmin6Month = (mySQLDataReader.GetValue(0)) / 2
                    Catch ex As Exception
                    End Try
                End While
                mySQLDataReader.Close()

                Sql = "SELECT COUNT(ID_Resource) FROM PlanResources WHERE CE_ID_ProjectMember = " & Me.ID_ProjectMember & " AND CE_ID_AdminResource <> 0 AND PlanDate <= '" & fConvertDateOnlySQL(DateIn12Month) & "';"

                'MySQLConnection.Open()
                mySQLCommand = New SqlCommand(Sql, MySQLConnection)
                mySQLDataReader = mySQLCommand.ExecuteReader()
                While mySQLDataReader.Read
                    'Lecture du premier paramètre
                    Try
                        Me.DaysOnAdmin12Month = (mySQLDataReader.GetValue(0)) / 2
                    Catch ex As Exception
                    End Try
                End While
                mySQLDataReader.Close()

                Sql = "SELECT COUNT(ID_Resource) FROM PlanResources WHERE CE_ID_ProjectMember = " & Me.ID_ProjectMember & " AND CE_ID_AdminResource <> 0 AND PlanDate <= '" & fConvertDateOnlySQL(DateEndYear) & "';"

                'MySQLConnection.Open()
                mySQLCommand = New SqlCommand(Sql, MySQLConnection)
                mySQLDataReader = mySQLCommand.ExecuteReader()
                While mySQLDataReader.Read
                    'Lecture du premier paramètre
                    Try
                        Me.DaysOnAdminEndYear = (mySQLDataReader.GetValue(0)) / 2
                    Catch ex As Exception
                    End Try
                End While
                mySQLDataReader.Close()

                MySQLConnection.Close()


            Catch ex As Exception


            End Try


        Catch ex As Exception

        End Try


        Return Me


    End Function

    Public Function GetFreeDays() As myStatistics



        Try

            'Recherche le nombre de jours planifiés sur de l'administratif pour une personne donnée
            'INPUT : ID_ProjectManager
            'OUTPUT : DaysFree1Month
            'OUTPUT : DaysFree3Month
            'OUTPUT : DaysFree6Month
            'OUTPUT : DaysFree12Month
            'OUTPUT : DaysFreeEndYear

            Dim DateIn1Month As Date = DateAdd(DateInterval.Month, 1, Today)
            Dim DateIn3Month As Date = DateAdd(DateInterval.Month, 3, Today)
            Dim DateIn6Month As Date = DateAdd(DateInterval.Month, 6, Today)
            Dim DateIn12Month As Date = DateAdd(DateInterval.Month, 12, Today)
            Dim DateEndYear As Date = New Date(Year(Today), 12, 31)


            Dim CounterFreeIn1Month As Single = 0
            Dim CounterFreeIn3Month As Single = 0
            Dim CounterFreeIn6Month As Single = 0
            Dim CounterFreeIn12Month As Single = 0
            Dim CounterFreeEndYear As Single = 0


            Dim thisDate As Date = Today



            While thisDate <= DateIn12Month


                Select Case thisDate.DayOfWeek

                    Case DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday

                        Dim thisPlanResource As New myPlanResource
                        thisPlanResource.CE_ID_ProjectMember = Me.ID_ProjectMember
                        thisPlanResource.PlanDate = thisDate
                        thisPlanResource.HalfDay = 1
                        thisPlanResource.CheckIfPlaned()
                        If thisPlanResource.IsPlaned = False Then

                            If thisDate <= DateIn1Month Then
                                CounterFreeIn1Month = CounterFreeIn1Month + 0.5
                            End If

                            If thisDate <= DateIn3Month Then
                                CounterFreeIn3Month = CounterFreeIn3Month + 0.5
                            End If

                            If thisDate <= DateIn6Month Then
                                CounterFreeIn6Month = CounterFreeIn6Month + 0.5
                            End If

                            If thisDate <= DateIn12Month Then
                                CounterFreeIn12Month = CounterFreeIn12Month + 0.5
                            End If

                            If thisDate <= DateEndYear Then
                                CounterFreeEndYear = CounterFreeEndYear + 0.5
                            End If

                        End If

                        thisPlanResource.HalfDay = 2
                        thisPlanResource.CheckIfPlaned()
                        If thisPlanResource.IsPlaned = False Then

                            If thisDate <= DateIn1Month Then
                                CounterFreeIn1Month = CounterFreeIn1Month + 0.5
                            End If

                            If thisDate <= DateIn3Month Then
                                CounterFreeIn3Month = CounterFreeIn3Month + 0.5
                            End If

                            If thisDate <= DateIn6Month Then
                                CounterFreeIn6Month = CounterFreeIn6Month + 0.5
                            End If

                            If thisDate <= DateIn12Month Then
                                CounterFreeIn12Month = CounterFreeIn12Month + 0.5
                            End If

                            If thisDate <= DateEndYear Then
                                CounterFreeEndYear = CounterFreeEndYear + 0.5
                            End If

                        End If

                End Select

                thisDate = DateAdd(DateInterval.Day, 1, thisDate)

            End While


            Me.DaysFree1Month = CounterFreeIn1Month
            Me.DaysFree3Month = CounterFreeIn3Month
            Me.DaysFree6Month = CounterFreeIn6Month
            Me.DaysFree12Month = CounterFreeIn12Month
            Me.DaysFreeEndYear = CounterFreeEndYear


        Catch ex As Exception

            'Debug.WriteLine(ex.ToString)

        End Try

        Return Me

    End Function

    Public Function GetProjectList() As myStatistics

        Try

            'Recherche le nombre de jours planifiés sur des project
            'INPUT : ID_ProjectManager
            'OUTPUT : ProjectList (texte avec le nom des membres et les jours planifiés)

            Dim thisCount As Single = 0
            Dim thisID As Integer = 0
            Me.ProjectList = ""

            Dim MySQLConnection As New SqlConnection

            Dim mySQLDataReader As SqlDataReader
            MySQLConnection.ConnectionString = cnProjectPlan

            Dim Sql As String = "Select COUNT(ID_RESOURCE),CE_ID_Project From PlanResources where CE_ID_ProjectMember = " & Me.ID_ProjectMember & " AND CE_ID_Project <> 0 GROUP BY CE_ID_Project ;"

            MySQLConnection.Open()
            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)
            mySQLDataReader = mySQLCommand.ExecuteReader()
            While mySQLDataReader.Read

                'Lecture du premier paramètre
                Try
                    thisCount = (mySQLDataReader.GetValue(0)) / 2
                Catch ex As Exception
                End Try

                'Lecture du 2e paramètre
                Try
                    thisID = mySQLDataReader.GetValue(1)
                Catch ex As Exception
                End Try

                Dim thisProject As New myProject
                thisProject.ID_Project = thisID
                thisProject.Read()
                If thisCount <= 1 Then
                    Me.ProjectList &= Format(thisCount, "0.0") & " jour : " & thisProject.Title & vbCrLf
                Else
                    Me.ProjectList &= Format(thisCount, "0.0") & " jours : " & thisProject.Title & vbCrLf
                End If

            End While

            mySQLDataReader.Close()
            MySQLConnection.Close()


        Catch ex As Exception

        End Try

        Return Me

    End Function

    Public Function GetAdminList() As myStatistics

        Try

            'Recherche le nombre de jours planifiés sur des project
            'INPUT : ID_ProjectManager
            'OUTPUT : AdminList (texte avec le nom des membres et les jours planifiés)

            Dim thisCount As Single = 0
            Dim thisID As Integer = 0
            Me.AdminList = ""

            Dim MySQLConnection As New SqlConnection

            Dim mySQLDataReader As SqlDataReader
            MySQLConnection.ConnectionString = cnProjectPlan

            Dim Sql As String = "Select COUNT(ID_RESOURCE),CE_ID_AdminResource From PlanResources where CE_ID_ProjectMember = " & Me.ID_ProjectMember & " AND CE_ID_AdminResource <> 0 GROUP BY CE_ID_AdminResource ;"

            MySQLConnection.Open()
            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)
            mySQLDataReader = mySQLCommand.ExecuteReader()
            While mySQLDataReader.Read

                'Lecture du premier paramètre
                Try
                    thisCount = (mySQLDataReader.GetValue(0)) / 2
                Catch ex As Exception
                End Try

                'Lecture du 2e paramètre
                Try
                    thisID = mySQLDataReader.GetValue(1)
                Catch ex As Exception
                End Try

                Dim thisAdmin As New myAdminResource
                thisAdmin.ID_AdminResource = thisID
                thisAdmin.read()
                If thisCount <= 1 Then
                    Me.AdminList &= Format(thisCount, "0.0") & " jour : " & thisAdmin.AdminResource & vbCrLf
                Else
                    Me.AdminList &= Format(thisCount, "0.0") & " jours : " & thisAdmin.AdminResource & vbCrLf
                End If

            End While

            mySQLDataReader.Close()
            MySQLConnection.Close()


        Catch ex As Exception

        End Try

        Return Me

    End Function

    Public Function GetPlanedDaysOnProject()

        Try

            'Recherche le nombre de jours planifiés sur un project donnée
            'INPUT : ID_Project
            'OUTPUT : DaysOnProjectPlaned

            Dim MySQLConnection As New SqlConnection

            Dim mySQLDataReader As SqlDataReader
            MySQLConnection.ConnectionString = cnProjectPlan

            Dim Sql As String = "Select COUNT(ID_RESOURCE) FROM PlanResources where CE_ID_Project = " & Me.ID_Project & ";"

            MySQLConnection.Open()
            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)
            mySQLDataReader = mySQLCommand.ExecuteReader()
            While mySQLDataReader.Read

                'Lecture du premier paramètre
                Try
                    Me.DaysOnProjectPlaned = (mySQLDataReader.GetValue(0)) / 2
                Catch ex As Exception
                End Try

            End While

            mySQLDataReader.Close()
        MySQLConnection.Close()


        Catch ex As Exception

        End Try

        Return Me

    End Function
End Class

