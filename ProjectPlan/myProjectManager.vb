Imports System.Data.SqlClient



Public Class myProjectManager

    Private _ID_ProjectManager As Integer
    Private _FirstName As String
    Private _Lastname As String
    Private _Enable As Boolean
    Private _FullName As String

    'Défnition des proprétés publiques

    Public Property FullName As String
        Get
            Return _FullName
        End Get

        Set(ByVal value As String)
            _FullName = value
        End Set
    End Property

    Public Property Lastname As String
        Get
            Return _Lastname
        End Get

        Set(ByVal value As String)
            _Lastname = value
        End Set
    End Property

    Public Property FirstName As String
        Get
            Return _FirstName
        End Get

        Set(ByVal value As String)
            _FirstName = value
        End Set
    End Property

    Public Property Enable As Boolean
        Get
            Return _Enable
        End Get
        Set(value As Boolean)
            _Enable = value
        End Set
    End Property

    Public Property ID_ProjectManager As Integer
        Get
            Return _ID_ProjectManager
        End Get
        Set(ByVal value As Integer)
            _ID_ProjectManager = value
        End Set
    End Property

    'Défintion des fonctions

    Public Function Read() As myProjectManager

        'Recherche les données d'un statut en fonction de son ID_ProjectManager


        Try

            Dim MySQLConnection As New SqlConnection

            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT ID_ProjectManager, FirstName, Lastname, Enable from ProjectManagers where ID_ProjectManager =" & Me.ID_ProjectManager

            'Remise à zéro des variables
            ID_ProjectManager = Nothing
            FirstName = Nothing
            Lastname = Nothing
            Enable = Nothing
            FullName = Nothing

            MySQLConnection.ConnectionString = cnProjectPlan


            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)

            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read

                'Lecture du premier paramètre
                Try
                    Me.ID_ProjectManager = mySQLDataReader.GetValue(0)
                Catch ex As Exception
                End Try

                'Lecture du 2e paramètre
                Try
                    Me.FirstName = mySQLDataReader.GetString(1)
                Catch ex As Exception
                End Try

                'Lecture du 3e paramètre
                Try
                    Me.Lastname = mySQLDataReader.GetString(2)
                Catch ex As Exception
                End Try

                'Lecture du 4e paramètre
                Try
                    Me.Enable = mySQLDataReader.GetValue(3)
                Catch ex As Exception
                End Try

                'Construction du FullName
                Me.FullName = Me.Lastname & " " & Me.FirstName

            End While

            mySQLDataReader.Close()
            MySQLConnection.Close()


        Catch ex As Exception

            Debug.WriteLine(ex.ToString)

        End Try

        Return Me


    End Function

    Public Function Find_ID_From_FullName() As myProjectManager

        'Recherche les données d'un Project Manager en fonction de son fullname


        Try

            Dim MySQLConnection As New SqlConnection

            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT ID_ProjectManager, FirstName, Lastname  from ProjectManagers;"

            MySQLConnection.ConnectionString = cnProjectPlan


            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)

            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read

                'Lecture du premier paramètre
                Try
                    Me.ID_ProjectManager = mySQLDataReader.GetValue(0)
                Catch ex As Exception
                End Try

                'Lecture du 2e paramètre
                Try
                    Me.FirstName = mySQLDataReader.GetString(1)
                Catch ex As Exception
                End Try

                'Lecture du 3e paramètre
                Try
                    Me.Lastname = mySQLDataReader.GetString(2)
                Catch ex As Exception
                End Try

                If Me.Lastname & " " & Me.FirstName = Me.FullName Then
                    Exit While
                Else
                    Me.ID_ProjectManager = 0
                End If

            End While

            mySQLDataReader.Close()
            MySQLConnection.Close()


        Catch ex As Exception

            Debug.WriteLine(ex.ToString)

        End Try

        Return Me


    End Function

    Public Function NewID() As myProjectManager

        'Recherche le plus grand ID_ProjectManager, ajoute 1 et définit la variable ID_ProjectManager
        Dim _NewID As Integer = 0

        Try
            Dim MySQLConn As New SqlConnection
            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT TOP 1 ID_ProjectManager FROM ProjectManagers ORDER BY ID_ProjectManager DESC;"

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

        Me.ID_ProjectManager = _NewID

        Return Me

    End Function

    Public Function Exists() As Boolean

        Dim _Exists As Boolean = False
        Dim _Count As Integer = 0

        Try

            Dim MySQLConnection As New SqlConnection

            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT COUNT(ID_ProjectManager) FROM ProjectManagers WHERE ID_ProjectManager = " & Me.ID_ProjectManager

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

    Public Function Save() As myProjectManager

        Try

            Dim SQL As String = ""




            If Me.Exists = True Then

                'L'enregistrement existe déjà, il faut faire un update
                SQL = "UPDATE ProjectManagers SET "
                SQL &= "FirstName ='" & Replace(Me.FirstName, "'", "''") & "',"
                SQL &= "Lastname ='" & Replace(Me.Lastname, "'", "''") & "', "
                If Me.Enable = True Then
                    SQL &= "Enable = 1 "
                Else
                    SQL &= "Enable = 0 "
                End If

                SQL &= "WHERE ID_ProjectManager=" & Me.ID_ProjectManager & ";"

            Else


                Me.NewID()

                'L'enregistrement n'existe pas encore, il faut faire un insert
                SQL = "INSERT INTO ProjectManagers "
                SQL &= "(ID_ProjectManager, FirstName, Lastname, Enable ) VALUES ("
                SQL &= Me.ID_ProjectManager & ","
                SQL &= "'" & Replace(Me._FirstName, "'", "''") & "',"
                SQL &= "'" & Replace(Me.Lastname, "'", "''") & "',"
                If Me.Enable = True Then
                    SQL &= "1)"
                Else
                    SQL &= "0)"
                End If


                ID_ProjectManager = Me.ID_ProjectManager

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

        End Try

        Return Me

    End Function


End Class
