Imports System.Data.SqlClient


Public Class myProjectEstimatedResource

    Private _ID_ProjectEstimatedResource As Integer
    Private _CE_ID_Project As Integer
    Private _CE_ID_Task As Integer
    Private _NumberDays As Integer
    Private _EstimatedProjectResources As Single
    Private _EstimatedProjectResourcesPerTask As Single


    Public Property EstimatedProjectResourcesPerTask As Single
        Get
            Return _EstimatedProjectResourcesPerTask
        End Get
        Set(ByVal value As Single)
            _EstimatedProjectResourcesPerTask = value
        End Set
    End Property



    Public Property EstimatedProjectResources As Single
        Get
            Return _EstimatedProjectResources
        End Get
        Set(ByVal value As Single)
            _EstimatedProjectResources = value
        End Set
    End Property



    Public Property ID_ProjectEstimatedResource As Integer
        Get
            Return _ID_ProjectEstimatedResource
        End Get
        Set(ByVal value As Integer)
            _ID_ProjectEstimatedResource = value
        End Set
    End Property




    Public Property CE_ID_Project As Integer
        Get
            Return _CE_ID_Project
        End Get
        Set(ByVal value As Integer)
            _CE_ID_Project = value
        End Set
    End Property


    Public Property CE_ID_Task As Integer
        Get
            Return _CE_ID_Task
        End Get
        Set(ByVal value As Integer)
            _CE_ID_Task = value
        End Set
    End Property



    Public Property NumberDays As Integer
        Get
            Return _NumberDays
        End Get
        Set(ByVal value As Integer)
            _NumberDays = value
        End Set
    End Property


    Public Function NewID() As myProjectEstimatedResource

        'Recherche le plus grand ID_ProjectEstimatedResource, ajoute 1 et définit la variable ID_ProjectEstimatedResource
        Dim _NewID As Integer = 0

        Try
            Dim MySQLConn As New SqlConnection
            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT TOP 1 ID_ProjectEstimatedResource FROM ProjectEstimatedResources ORDER BY ID_ProjectEstimatedResource DESC;"

            MySQLConn.ConnectionString = cnProjectPlan
            MySQLConn.Open()
            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConn)
            mySQLDataReader = mySQLCommand.ExecuteReader()

            Try
                If mySQLDataReader.Read Then
                    _NewID = mySQLDataReader.GetValue(0)
                End If
            Catch ex As Exception
            End Try
            _NewID = _NewID + 1
            mySQLDataReader.Close()
            MySQLConn.Close()

        Catch ex As Exception

        End Try

        Me.ID_ProjectEstimatedResource = _NewID

        Return Me

    End Function

    Public Function Read() As myProjectEstimatedResource

        'Recherche les données d'une ressource de projet estimée en fonction de son ID_ProjectEstimatedResource

        Try

            Dim MySQLConnection As New SqlConnection

            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT ID_ProjectEstimatedResource, CE_ID_Project, CE_ID_Task, NumberDays FROM ProjectEstimatedResources WHERE ID_ProjectEstimatedResource=" & Me.ID_ProjectEstimatedResource

            'Réinitialisation des variables
            ID_ProjectEstimatedResource = Nothing
            CE_ID_Project = Nothing
            CE_ID_Task = Nothing
            NumberDays = Nothing


            MySQLConnection.ConnectionString = cnProjectPlan


            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)

            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read

                'Lecture du paramètre ID_ProjectEstimatedResource
                Try
                    Me.ID_ProjectEstimatedResource = mySQLDataReader.GetValue(0)
                Catch ex As Exception
                End Try

                'Lecture du paramètre CE_ID_Project
                Try
                    Me.CE_ID_Project = mySQLDataReader.GetValue(1)
                Catch ex As Exception
                End Try

                'Lecture du paramètre CE_ID_Task
                Try
                    Me.CE_ID_Task = mySQLDataReader.GetValue(2)
                Catch ex As Exception
                End Try

                'Lecture du paramètre NumberDays
                Try
                    Me.NumberDays = mySQLDataReader.GetValue(3)
                Catch ex As Exception
                End Try

            End While

            mySQLDataReader.Close()
            MySQLConnection.Close()


        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try

        Return Me

    End Function

    Public Function Save() As myProjectEstimatedResource

        Try

            Dim SQL As String = ""

            If Me.Exists = True Then

                'L'enregistrement existe déjà, il faut faire un update
                SQL = "UPDATE ProjectEstimatedResources SET "
                SQL &= "CE_ID_Project =" & Me.CE_ID_Project & ", "
                SQL &= "CE_ID_Task =" & Me.CE_ID_Task & ", "
                SQL &= "NumberDays =" & Me.NumberDays & " "
                SQL &= "WHERE ID_ProjectEstimatedResource=" & Me.ID_ProjectEstimatedResource & ";"

            Else


                Me.NewID()

                'L'enregistrement n'existe pas encore, il faut faire un insert
                SQL = "INSERT INTO ProjectEstimatedResources "
                SQL &= "(ID_ProjectEstimatedResource, CE_ID_Project, CE_ID_Task, NumberDays) VALUES ("
                SQL &= Me.ID_ProjectEstimatedResource & ","
                SQL &= Me.CE_ID_Project & ","
                SQL &= Me.CE_ID_Task & ","
                SQL &= Me.NumberDays & " )"


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

            'On met à jour le champ EstimatedResources dans la table Projects
            Me.GetEstimatedProjectResources()
            Dim myProj As New myProject
            myProj.ID_Project = Me.CE_ID_Project
            myProj.Read()
            myProj.EstimatedResources = Me.EstimatedProjectResources
            myProj.Save()


        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try

        Return Me

    End Function

    Public Function Exists() As Boolean

        Dim _Exists As Boolean = False
        Dim _Count As Integer = 0

        Try

            Dim MySQLConnection As New SqlConnection

            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT COUNT(ID_ProjectEstimatedResource) FROM ProjectEstimatedResources WHERE ID_ProjectEstimatedResource = " & Me.ID_ProjectEstimatedResource

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

    Public Function Delete() As Boolean

        'On efface une ressource de projet estimée en fonction de son ID_ProjectEstimatedResource

        Dim ReturnValue As Boolean = False  'on renvoie TRUE si l'effacement s'est bien passé
        Dim myRes As New myProjectEstimatedResource

        Try

            Dim SQL As String = ""

            If Me.Exists = True Then


                'On met à jour le champ EstimatedRes dans la table Projects
                myRes.ID_ProjectEstimatedResource = Me.ID_ProjectEstimatedResource
                myRes.Read()

                SQL = "DELETE FROM ProjectEstimatedResources WHERE ID_ProjectEstimatedResource=" & Me.ID_ProjectEstimatedResource & ";"
                Dim MySQLConn As New SqlConnection

                'On exécute la commande SQL 
                MySQLConn.ConnectionString = cnProjectPlan
                MySQLConn.Open()
                Dim mySQLCommand As SqlCommand = New SqlCommand(SQL, MySQLConn)
                mySQLCommand.ExecuteNonQuery()
                mySQLCommand = Nothing
                MySQLConn.Close()

                'On met à jour le champ EstimatedResources dans la table Projects
                myRes.GetEstimatedProjectResources()
                Dim myProj As New myProject
                myProj.ID_Project = myRes.CE_ID_Project
                myProj.Read()
                myProj.EstimatedResources = myRes.EstimatedProjectResources
                myProj.Save()

                ReturnValue = True

            Else
            End If

        Catch ex As Exception

        End Try

        Return ReturnValue

    End Function

    Public Function GetEstimatedProjectResources() As myProjectEstimatedResource

        'Renvoi le nombre de jours estimés pour un projet donnée 
        'INPUT : CE_ID_Project
        'OUTPUT : EstimatedProjectResources

        Dim ProjectResources As Integer = 0

        Try

            Dim MySQLConn As New SqlConnection
            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = ""

            Sql = "SELECT NumberDays FROM ProjectEstimatedResources WHERE CE_ID_Project = " & Me.CE_ID_Project & ";"
            MySQLConn.ConnectionString = cnProjectPlan
            MySQLConn.Open()
            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConn)
            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read

                'Lecture du paramètre HalfDay
                Try
                    'On lit et on divise par 2 parce que les valeurs de la DB sont des demi-jours
                    ProjectResources = ProjectResources + mySQLDataReader.GetValue(0)
                Catch ex As Exception
                End Try

            End While

            mySQLDataReader.Close()
            MySQLConn.Close()

        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try

        Me.EstimatedProjectResources = ProjectResources
        Return Me

    End Function

    Public Function GetEstimatedProjectResourcesPerTask() As myProjectEstimatedResource

        'Renvoi le nombre de jours estimés pour un projet donné et une tâche données
        'INPUT : CE_ID_Project
        'INPUT : CE_ID_Task
        'OUTPUT : EstimatedProjectResources

        Dim ProjectResourcesPerTask As Single = 0

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
                    ProjectResourcesPerTask = mySQLDataReader.GetValue(0) / 2
                Catch ex As Exception
                End Try

            End While

            mySQLDataReader.Close()
            MySQLConn.Close()

        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try

        Me.EstimatedProjectResourcesPerTask = ProjectResourcesPerTask
        Return Me

    End Function

End Class
