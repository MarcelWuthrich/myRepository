Imports System.Data.SqlClient

Public Class myPlanResource


    Private _ID_Resource As Integer
    Private _CE_ID_ProjectMember As Integer
    Private _CE_ID_Project As Integer
    Private _CE_ID_AdminResource As Integer
    Private _CE_ID_Task As Integer
    Private _PlanDate As Date
    Private _HalfDay As Integer
    Private _Blocked As Boolean
    Private _Remark As String
    Private _IsPlaned As Boolean
    Private _ProjectMembersCount As Integer
    Private _IsAdminResource As Boolean
    Private _IsProjectResource As Boolean
    Private _FirstFreeDayForResource As Date
    Private _CountPlanResource As Integer
    Private _MinPlanDate As Date
    Private _MaxPlanDate As Date
    Private _PlanProjectResourcesPerTaskAndProject As Single


    Public Property CE_ID_Task As Integer
        Get
            Return _CE_ID_Task
        End Get
        Set(ByVal value As Integer)
            _CE_ID_Task = value
        End Set
    End Property

    Public Property PlanProjectResourcesPerTaskAndProject As Single
        Get
            Return _PlanProjectResourcesPerTaskAndProject
        End Get
        Set(value As Single)
            _PlanProjectResourcesPerTaskAndProject = value
        End Set
    End Property



    Public Property MaxPlanDate As Date
        Get
            Return _MaxPlanDate
        End Get
        Set(value As Date)
            _MaxPlanDate = value
        End Set
    End Property
    Public Property MinPlanDate As Date
        Get
            Return _MinPlanDate
        End Get
        Set(value As Date)
            _MinPlanDate = value
        End Set
    End Property
    Public Property Remark As String
        Get
            Return _Remark
        End Get
        Set(value As String)
            _Remark = value
        End Set
    End Property
    Public Property Blocked As Boolean
        Get
            Return _Blocked
        End Get
        Set(value As Boolean)
            _Blocked = value
        End Set
    End Property
    Public Property HalfDay As Integer
        Get
            Return _HalfDay
        End Get
        Set(value As Integer)
            _HalfDay = value
        End Set
    End Property

    Public Property CountPlanResource As Integer
        Get
            Return _CountPlanResource
        End Get
        Set(value As Integer)
            _CountPlanResource = value
        End Set
    End Property

    Public Property FirstFreeDayForResource As Date
        Get
            Return _FirstFreeDayForResource
        End Get
        Set(value As Date)
            _FirstFreeDayForResource = value
        End Set
    End Property

    Public Property IsProjectResource As Boolean
        Get
            Return _IsProjectResource
        End Get
        Set(value As Boolean)
            _IsProjectResource = value
        End Set
    End Property

    Public Property IsAdminResource As Boolean
        Get
            Return _IsAdminResource
        End Get
        Set(value As Boolean)
            _IsAdminResource = value
        End Set
    End Property

    Public Property ProjectMembersCount As Integer
        Get
            Return _ProjectMembersCount
        End Get
        Set(value As Integer)
            _ProjectMembersCount = value
        End Set
    End Property

    Public Property IsPlaned As Boolean
        Get
            Return _IsPlaned
        End Get
        Set(value As Boolean)
            _IsPlaned = value
        End Set
    End Property

    Public Property ID_Resource As Integer
        Get
            Return _ID_Resource
        End Get
        Set(value As Integer)
            _ID_Resource = value
        End Set
    End Property

    Public Property CE_ID_ProjectMember As Integer
        Get
            Return _CE_ID_ProjectMember
        End Get
        Set(value As Integer)
            _CE_ID_ProjectMember = value
        End Set
    End Property

    Public Property CE_ID_Project As Integer
        Get
            Return _CE_ID_Project
        End Get
        Set(value As Integer)
            _CE_ID_Project = value
        End Set
    End Property

    Public Property CE_ID_AdminResource As Integer
        Get
            Return _CE_ID_AdminResource
        End Get
        Set(value As Integer)
            _CE_ID_AdminResource = value
        End Set
    End Property

    Public Property PlanDate As Date
        Get
            Return _PlanDate
        End Get
        Set(value As Date)
            _PlanDate = value
        End Set
    End Property

    Public Function NewID() As myPlanResource

        'Recherche le plus grand ID_Resource, ajoute 1 et définit la variable ID_Resource

        'Attention : il est important de regarder dans les 2 tables "PlanResources" et "ExecutedResources".
        'parce que si on efface des ressources planifiées, il est possible que des ressources exécutées existent avec des ID déjà attribués et donc plus grand.
        'il y a un risque d'avoir des doublons dans les ID_Resource


        Dim _NewIDPlan As Integer = 0
        Dim _NewIDExecuted As Integer = 0
        Dim _NewID As Integer = 0

        Try

            Dim MySQLConn As New SqlConnection
            MySQLConn.ConnectionString = cnProjectPlan

            Dim mySQLDataReader1 As SqlDataReader
            Dim mySQLDataReader2 As SqlDataReader
            Dim Sql As String = ""


            MySQLConn.Open()

            Sql = "SELECT TOP 1 ID_Resource FROM PlanResources ORDER BY ID_Resource DESC;"
            Dim mySQLCommand1 As SqlCommand = New SqlCommand(Sql, MySQLConn)
            mySQLDataReader1 = mySQLCommand1.ExecuteReader()
            Try
                If mySQLDataReader1.Read Then
                    _NewIDPlan = mySQLDataReader1.GetValue(0)
                End If
            Catch ex As Exception
            End Try
            mySQLDataReader1.Close()

            Sql = "SELECT TOP 1 ID_Resource FROM ExecutedResources ORDER BY ID_Resource DESC;"
            Dim mySQLCommand2 As SqlCommand = New SqlCommand(Sql, MySQLConn)

            mySQLDataReader2 = mySQLCommand2.ExecuteReader()
            Try
                If mySQLDataReader2.Read Then
                    _NewIDExecuted = mySQLDataReader2.GetValue(0)
                End If
            Catch ex As Exception
            End Try
            mySQLDataReader2.Close()

            MySQLConn.Close()

            If _NewIDPlan > _NewIDExecuted Then
                _NewID = _NewIDPlan + 1
            Else
                _NewID = _NewIDExecuted + 1
            End If

        Catch ex As Exception

        End Try

        Me.ID_Resource = _NewID

        Return Me

    End Function

    Public Function Exists() As Boolean

        Dim _Exists As Boolean = False
        Dim _Count As Integer = 0

        Try

            Dim MySQLConnection As New SqlConnection

            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT COUNT(ID_Resource) FROM PlanResources WHERE ID_Resource = " & Me.ID_Resource

            MySQLConnection.ConnectionString = cnProjectPlan


            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)

            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read

                'Lecture du premier paramètre COUNT
                Try
                    _Count = mySQLDataReader.GetValue(0)
                Catch ex As Exception
                End Try

            End While

            mySQLDataReader.Close()
            MySQLConnection.Close()

            If _Count = 1 Then
                _Exists = True
            End If

        Catch ex As Exception

        End Try

        Return _Exists

    End Function

    Public Function Read() As myPlanResource

        'Recherche les données d'une ressource planifiée en fonction de son ID_Resource



        Try

            Dim MySQLConnection As New SqlConnection

            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT ID_Resource, CE_ID_ProjectMember, CE_ID_Project, CE_ID_AdminResource, PlanDate, HalfDay, Blocked, Remark FROM PlanResources WHERE ID_Resource=" & Me.ID_Resource


            'Remise à zéro des variables
            ID_Resource = Nothing
            CE_ID_ProjectMember = Nothing
            CE_ID_Project = Nothing
            CE_ID_AdminResource = Nothing
            PlanDate = Nothing
            HalfDay = Nothing
            Blocked = Nothing
            Remark = Nothing
            IsPlaned = Nothing
            ProjectMembersCount = Nothing
            IsAdminResource = Nothing
            IsProjectResource = Nothing
            FirstFreeDayForResource = Nothing

            MySQLConnection.ConnectionString = cnProjectPlan

            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)

            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read

                'Lecture du premier paramètre 
                Try
                    Me.ID_Resource = mySQLDataReader.GetValue(0)
                Catch ex As Exception
                End Try

                'Lecture du 2e paramètre
                Try
                    Me.CE_ID_ProjectMember = mySQLDataReader.GetValue(1)
                Catch ex As Exception
                End Try

                'Lecture du 3e paramètre
                Try
                    Me.CE_ID_Project = mySQLDataReader.GetValue(2)
                Catch ex As Exception
                End Try

                'Lecture du 4e paramètre 
                Try
                    Me.CE_ID_AdminResource = mySQLDataReader.GetValue(3)
                Catch ex As Exception
                End Try

                'Lecture du 5e paramètre 
                Try
                    Me.PlanDate = mySQLDataReader.GetDateTime(4)
                Catch ex As Exception
                End Try

                'Lecture du 6e paramètre 
                Try
                    Me.HalfDay = mySQLDataReader.GetValue(5)
                Catch ex As Exception
                End Try

                'Lecture du 7e paramètre 
                Try
                    Me.Blocked = mySQLDataReader.GetBoolean(6)
                Catch ex As Exception
                End Try

                'Lecture du 8e paramètre 
                Try
                    Me.Remark = mySQLDataReader.GetString(7)
                Catch ex As Exception
                End Try


            End While

            mySQLDataReader.Close()
            MySQLConnection.Close()

            'On détermine si c'est une ressource de projet
            If Me.CE_ID_Project = 0 Then
                Me.IsProjectResource = False
            Else
                Me.IsProjectResource = True
            End If

            'On détermine si c'est une ressource administrative
            If Me.CE_ID_AdminResource = 0 Then
                Me.IsAdminResource = False
            Else
                Me.IsAdminResource = True
            End If

            'Si c'est une ressource administrative ou une ressource de projet, c'est planifié
            If Me.IsAdminResource = True Or Me.IsProjectResource = True Then
                Me.IsPlaned = True
            End If


        Catch ex As Exception

            Debug.WriteLine(ex.ToString)

        End Try

        Return Me


    End Function

    Public Function Save() As myPlanResource

        Try

            Dim SQL As String = ""

            'Si l'ID de la ressource administrative et celle du projet sont nulles, c'est qu'il y a une erreur et qu'il ne faut rien sauver
            'WUM / 08.05.2019
            If CE_ID_AdminResource = 0 And CE_ID_Project = 0 Then
                Return Me
                Exit Function
            End If

            'Si l'ID du membre de projet est nulle, c'est qu'il y a une erreur et qu'il ne faut rien sauver
            'WUM / 10.05.2019
            If CE_ID_ProjectMember = 0 Then
                Return Me
                Exit Function
            End If

            'On regarde si on a déjà une ressource pour la personne et la date prévues
            If Me.ID_Resource = 0 Then
                'Return Me
                Me.GetIDResourceFromDateAndMember()
            End If

            If Me.Exists = True Then



                'L'enregistrement existe déjà, il faut faire un update
                SQL = "UPDATE PlanResources SET "
                SQL &= "CE_ID_ProjectMember =" & Me._CE_ID_ProjectMember & ", "
                SQL &= "CE_ID_Project =" & Me._CE_ID_Project & ", "
                SQL &= "CE_ID_AdminResource =" & Me.CE_ID_AdminResource & ", "
                SQL &= "PlanDate ='" & fConvertDateTimeSQL(Me.PlanDate) & "', "
                SQL &= "HalfDay =" & Me.HalfDay & ",  "
                If Me.Blocked = True Then
                    SQL &= "Blocked = 1, "
                Else
                    SQL &= "Blocked = 0, "
                End If
                SQL &= "Remark = '" & Replace(Me.Remark, "'", "''") & "' "

                SQL &= "WHERE ID_Resource=" & Me.ID_Resource & ";"



            Else


                Me.NewID()

                'L'enregistrement n'existe pas encore, il faut faire un insert
                SQL = "INSERT INTO PlanResources "
                SQL &= "(ID_Resource, CE_ID_ProjectMember, CE_ID_Project, CE_ID_AdminResource, PlanDate, HalfDay, Blocked, Remark) VALUES ("
                SQL &= Me.ID_Resource & ","
                SQL &= Me.CE_ID_ProjectMember & ","
                SQL &= Me.CE_ID_Project & ","
                SQL &= Me.CE_ID_AdminResource & ","
                SQL &= "'" & fConvertDateOnlySQL(Me.PlanDate) & "',"
                SQL &= Me.HalfDay & ","
                If Me.Blocked = True Then
                    SQL &= "1, "
                Else
                    SQL &= "0, "
                End If
                SQL &= "'" & Replace(Me.Remark, "'", "''") & "')"

            End If


            Dim MySQLConn As New SqlConnection



            If SQL <> "" Then

                'On exécute la commande SQL uniquement si elle existe
                MySQLConn.ConnectionString = cnProjectPlan
                MySQLConn.Open()

                Dim mySQLCommand As SqlCommand = New SqlCommand(SQL, MySQLConn)

                mySQLCommand.ExecuteNonQuery()
                mySQLCommand = Nothing
                MySQLConn.Close()

            End If



        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try

        Return Me

    End Function

    Public Function CheckIfPlaned() As myPlanResource

        'Vérifie s'il existe un enregistrement pour une personne à une date donnée et met la priorité IsPlaned 
        'INPUT : CE_ID_ProjectMember pour la personne
        'INPUT : PlanDate pour la personne
        'OUTPUT : IsPlaned (TRUE si on trouve un record, FALSE si on n'a rien trouvé)



        Dim _ID_Resource As Integer = 0
        Dim _CE_ID_Project As Integer = 0
        Dim _CE_ID_AdminResource As Integer = 0


        Try

            Dim MySQLConnection As New SqlConnection


            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT ID_Resource, CE_ID_Project, CE_ID_AdminResource FROM PlanResources WHERE  CE_ID_ProjectMember = " & Me.CE_ID_ProjectMember & " AND PlanDate = '" & fConvertDateOnlySQL(Me.PlanDate) & "' AND HalfDay = " & Me.HalfDay & ";"

            MySQLConnection.ConnectionString = cnProjectPlan


            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)

            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read

                'Lecture du premier paramètre 
                Try
                    _ID_Resource = mySQLDataReader.GetValue(0)
                Catch ex As Exception
                End Try

                'Lecture du 2e paramètre 
                Try
                    _CE_ID_Project = mySQLDataReader.GetValue(1)
                Catch ex As Exception
                End Try

                'Lecture du premier paramètre 
                Try
                    _CE_ID_AdminResource = mySQLDataReader.GetValue(2)
                Catch ex As Exception
                End Try

            End While

            mySQLDataReader.Close()
            MySQLConnection.Close()

            If _ID_Resource <> 0 Then

                'On a trouvé un record, on récupère l'ID et on met IsPlaned
                Me.ID_Resource = _ID_Resource
                Me.IsPlaned = True
            Else
                'On n'a pas trouvé de record, on met IsPlaned
                Me.IsPlaned = False
            End If


            'On détermine si c'est une ressource de projet
            If _CE_ID_Project = 0 Then
                Me.IsProjectResource = False
            Else
                Me.IsProjectResource = True
            End If


            'On détermine si c'est une ressource administrative
            If Me._CE_ID_AdminResource = 0 Then
                Me.IsAdminResource = False
            Else
                Me.IsAdminResource = True
            End If


        Catch ex As Exception

            'Debug.WriteLine(ex.ToString)

        End Try

        Return Me

    End Function

    Public Function GetProjectMembersCount() As myPlanResource

        Try

            'Recherche tous les membres de projets qui ont des ressources planifiées
            'INPUT : rien
            'OUTPUT : Le nombre de membres de projects qui ont des ressources planifiées

            Dim MySQLConnection As New SqlConnection

            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT COUNT(DISTINCT CE_ID_ProjectMember) FROM PlanResources;"

            MySQLConnection.ConnectionString = cnProjectPlan


            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)

            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read

                'Lecture du premier paramètre ID_PROJECT
                Try
                    Me.ProjectMembersCount = mySQLDataReader.GetValue(0)
                Catch ex As Exception
                End Try

            End While

            mySQLDataReader.Close()
            MySQLConnection.Close()
        Catch ex As Exception

        End Try

        Return Me

    End Function

    Public Function GetResourceFromDateAndMember() As myPlanResource

        Try
            'Recherche la ressource en fonction du CE_ID_Membre, d'une date PlanDate et d'une HalfDay
            'INPUT : CE_ID_ProjectMember
            'INPUT : PlanDate
            'INPUT : HalfDay
            'OUTPUT : myPlanResource

            Dim MySQLConnection As New SqlConnection

            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT ID_Resource FROM PlanResources WHERE CE_ID_ProjectMember = " & Me.CE_ID_ProjectMember & " AND PlanDate = '" & fConvertDateOnlySQL(Me.PlanDate) & "' AND HalfDay = " & Me.HalfDay & ";"

            MySQLConnection.ConnectionString = cnProjectPlan


            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)

            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read

                'Lecture du premier paramètre ID_Resource
                Try
                    Me.ID_Resource = mySQLDataReader.GetValue(0)
                Catch ex As Exception
                End Try

            End While

            mySQLDataReader.Close()
            MySQLConnection.Close()

            Me.Read()

        Catch ex As Exception

        End Try


        Return Me

    End Function

    Public Function GetIDResourceFromDateAndMember() As myPlanResource

        Try
            'Recherche le ID_Resource en fonction du CE_ID_Membre, d'une date PlanDate et d'une HalfDay
            'INPUT : CE_ID_ProjectMember
            'INPUT : PlanDate
            'INPUT : HalfDay
            'OUTPUT : ID_Resource

            Dim MySQLConnection As New SqlConnection

            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT ID_Resource FROM PlanResources WHERE CE_ID_ProjectMember = " & Me.CE_ID_ProjectMember & " AND PlanDate = '" & fConvertDateOnlySQL(Me.PlanDate) & "' AND HalfDay = " & Me.HalfDay & ";"

            MySQLConnection.ConnectionString = cnProjectPlan


            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)

            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read

                'Lecture du premier paramètre ID_Resource
                Try
                    Me.ID_Resource = mySQLDataReader.GetValue(0)
                Catch ex As Exception
                End Try

            End While

            mySQLDataReader.Close()
            MySQLConnection.Close()


        Catch ex As Exception

        End Try


        Return Me

    End Function

    Public Function Delete() As myPlanResource

        Try
            'On efface la ressource en fonction de son ID_Resource
            'INPUT : ID_Resource

            Dim MySQLConnection As New SqlConnection

            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "DELETE FROM PlanResources WHERE ID_Resource = " & Me.ID_Resource & ";"

            MySQLConnection.ConnectionString = cnProjectPlan

            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)

            mySQLDataReader = mySQLCommand.ExecuteReader()

            'While mySQLDataReader.Read

            '    'Lecture du premier paramètre ID_Resource
            '    Try
            '        Me.ID_Resource = mySQLDataReader.GetValue(0)
            '    Catch ex As Exception
            '    End Try

            'End While

            mySQLDataReader.Close()
            MySQLConnection.Close()

            Me.Read()

        Catch ex As Exception

        End Try


        Return Me

    End Function

    Public Function GetFirstFreeDayForResource() As myPlanResource

        'Recherche la première date libre à partir de la date d'une ressource définie par ID_Resource
        'INPUT : ID_Resource
        'OUTPUT : FirstFreeDayForResource

        Try


            Dim thisDate As Date = Me.PlanDate
            Dim thisHalfDay As Integer = Me.HalfDay
            Dim thisResource As New myPlanResource
            thisResource = Me

            '''' ça faut revoir avec le HalfDay (TODO)
            Do
                'On ajoute 1 jour à la date actuelle
                thisResource.PlanDate = DateAdd(DateInterval.Day, 1, thisResource.PlanDate)


                If Weekday(thisResource.PlanDate) = vbSaturday Or Weekday(thisResource.PlanDate) = vbSunday Then
                    'Si la date est un samedi ou un dimanche, on passe au jour suivant
                    Continue Do
                Else
                    'Si c'est un jour de semaine, on regarde si on peut planifier
                    thisResource.CheckIfPlaned()

                    If thisResource.IsPlaned = True Then
                        'Si c'est déjà planifié, on passe au jour suivant
                        Continue Do
                    End If
                End If

            Loop Until thisResource.IsPlaned = False

            Me.FirstFreeDayForResource = thisResource.PlanDate

        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try

        Return Me
    End Function

    Public Function Get_Count_PlanResource_From_CE_ID_Project() As myPlanResource

        Try
            'Recherche le nombre de jours planifiés pour sur un projet donné
            'INPUT : CE_ID_Project
            'OUTPUT : CountPlanResource

            Dim MySQLConnection As New SqlConnection

            Dim mySQLDataReader As SqlDataReader
            Dim SQL As String = "select COUNT(ID_Resource) from PlanResources WHERE CE_ID_Project=" & CE_ID_Project

            MySQLConnection.ConnectionString = cnProjectPlan


            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(SQL, MySQLConnection)

            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read

                'Lecture du premier paramètre ID_Resource
                Try
                    Me.CountPlanResource = mySQLDataReader.GetValue(0)
                Catch ex As Exception
                End Try

            End While

            mySQLDataReader.Close()
            MySQLConnection.Close()

        Catch ex As Exception

        End Try


        Return Me

    End Function

    Public Function GetMaxPlanDate() As myPlanResource

        Me.MaxPlanDate = Nothing

        Try


            'Recherche la PlanDate la plus récente
            'INPUT : nothing
            'OUTPUT : PlanDate


            Dim MySQLConnection As New SqlConnection
            Dim mySQLDataReader As SqlDataReader
            Dim SQL As String = "SELECT TOP 1 PlanDate FROM PlanResources ORDER BY plandate DESC;"
            Me.MaxPlanDate = Nothing


            MySQLConnection.ConnectionString = cnProjectPlan

            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(SQL, MySQLConnection)

            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read

                'Lecture du premier paramètre ID_Resource
                Try
                    Me.MaxPlanDate = mySQLDataReader.GetDateTime(0)
                Catch ex As Exception
                End Try

            End While

            mySQLDataReader.Close()
            MySQLConnection.Close()

        Catch ex As Exception

        End Try

        Return Me

    End Function

    Public Function GetMinPlanDate() As myPlanResource

        Me.MinPlanDate = Nothing

        Try


            'Recherche la PlanDate la plus ancienne
            'INPUT : nothing
            'OUTPUT : PlanDate


            Dim MySQLConnection As New SqlConnection
            Dim mySQLDataReader As SqlDataReader
            Dim SQL As String = "SELECT TOP 1 PlanDate FROM PlanResources ORDER BY plandate ASC;"
            Me.MinPlanDate = Nothing


            MySQLConnection.ConnectionString = cnProjectPlan

            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(SQL, MySQLConnection)

            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read

                'Lecture du premier paramètre ID_Resource
                Try
                    Me.MinPlanDate = mySQLDataReader.GetDateTime(0)
                Catch ex As Exception
                End Try

            End While

            mySQLDataReader.Close()
            MySQLConnection.Close()

        Catch ex As Exception

        End Try

        Return Me

    End Function


    Public Function GetPlanProjectResourcesPerTaskAndProject() As myPlanResource

        'Renvoi le nombre de jours planifiées pour un projet donné et pour les membres d'une tâches données
        'INPUT : CE_ID_Project
        'INPUT : CE_ID_Task
        'OUTPUT : EstimatedProjectResources

        Dim ProjectResources As Single = 0

        Try

            Dim MySQLConn As New SqlConnection
            Dim mySQLDataReader As SqlDataReader
            Dim SQL As String = ""

            SQL = "SELECT COUNT(ID_Resource) FROM PlanResources where CE_ID_Project=" & Me.CE_ID_Project & " AND CE_ID_ProjectMember IN (SELECT ID_ProjectMember FROM ProjectsMembers WHERE CE_ID_Task=" & Me.CE_ID_Task & ") "

            'SQL = "SELECT NumberDays FROM ProjectEstimatedResources WHERE CE_ID_Project = " & Me.CE_ID_Project & " AND CE_ID_TASK = " & Me.CE_ID_Task & ";"
            MySQLConn.ConnectionString = cnProjectPlan
            MySQLConn.Open()
            Dim mySQLCommand As SqlCommand = New SqlCommand(SQL, MySQLConn)
            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read

                'Lecture du paramètre HalfDay
                Try
                    'On lit et on divise par 2 parce que les valeurs de la DB sont des demi-jours
                    ProjectResources = mySQLDataReader.GetValue(0) / 2
                Catch ex As Exception
                End Try

            End While

            mySQLDataReader.Close()
            MySQLConn.Close()

        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try

        Me.PlanProjectResourcesPerTaskAndProject = ProjectResources
        Return Me

    End Function

End Class
