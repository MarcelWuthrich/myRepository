Imports System.Data.SqlClient


Public Class myProjectHistory



    Private _ID_History As Integer
    Private _CE_ID_Priority As Integer
    Private _CE_ID_Status As Integer
    Private _CE_ID_Project As Integer
    Private _ModifyBy As String
    Private _ModifyDate As DateTime
    Private _Modification As String



    'Défnition des proprétés publiques


    Public Property ID_History As Integer
        Get
            Return _ID_History
        End Get
        Set(value As Integer)
            _ID_History = value
        End Set
    End Property
    Public Property CE_ID_Priority As Integer
        Get
            Return _CE_ID_Priority
        End Get
        Set(value As Integer)
            _CE_ID_Priority = value
        End Set
    End Property

    Public Property CE_ID_Status As Integer
        Get
            Return _CE_ID_Status
        End Get
        Set(value As Integer)
            _CE_ID_Status = value
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

    Public Property ModifyBy As String
        Get
            Return _ModifyBy
        End Get

        Set(ByVal value As String)
            _ModifyBy = value
        End Set
    End Property

    Public Property Modification As String
        Get
            Return _Modification
        End Get
        Set(ByVal value As String)
            _Modification = value
        End Set
    End Property

    Public Property ModifyDate As Date
        Get
            Return _ModifyDate
        End Get
        Set(value As Date)
            _ModifyDate = value
        End Set
    End Property



    Public Function NewID() As myProjectHistory

        'Recherche le plus grand ID_Project_History, ajoute 1 et définit la variable  ID_Project_History
        Dim _NewID As Integer = 0

        Try
            Dim MySQLConn As New SqlConnection
            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT TOP 1 ID_History FROM ProjectsHistory ORDER BY ID_History DESC;"

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

        Me.ID_History = _NewID

        Return Me



    End Function

    Public Function Read() As myProjectHistory

        'Recherche les données d'un projet en fonction de son ID_Projet

        'Dim tmp As New myProject

        Try

            Dim MySQLConnection As New SqlConnection

            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT ID_History, CE_ID_Project, ModifyBy, ModifyDate, Modifcation FROM ProjectsHistory WHERE ID_History=" & Me.ID_History

            'Remise à zéro des variables
            ID_History = Nothing
            CE_ID_Priority = Nothing
            CE_ID_Status = Nothing
            CE_ID_Project = Nothing
            ModifyBy = Nothing
            ModifyDate = Nothing
            Modification = Nothing

            MySQLConnection.ConnectionString = cnProjectPlan


            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)

            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read

                'Lecture du premier paramètre
                Try
                    Me.ID_History = mySQLDataReader.GetValue(0)
                Catch ex As Exception
                End Try

                'Lecture du 2e paramètre 
                Try
                    Me.CE_ID_Project = mySQLDataReader.GetValue(1)
                Catch ex As Exception
                End Try

                'Lecture du 3e paramètre 
                Try
                    Me.ModifyBy = mySQLDataReader.GetString(2)
                Catch ex As Exception
                End Try

                'Lecture du 4e paramètre 
                Try
                    Me.ModifyDate = mySQLDataReader.GetDateTime(3)
                Catch ex As Exception
                End Try

                'Lecture du 5e paramètre DESCRIPTION
                Try
                    Me.Modification = mySQLDataReader.GetString(4)
                Catch ex As Exception
                End Try


            End While

            mySQLDataReader.Close()
            MySQLConnection.Close()


        Catch ex As Exception

            Debug.WriteLine(ex.ToString)

        End Try

        Return Me


    End Function

    Public Function Exists() As Boolean

        Dim _Exists As Boolean = False
        Dim _Count As Integer = 0

        Try

            Dim MySQLConnection As New SqlConnection

            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT COUNT(ID_History) FROM ProjectsHistory WHERE ID_History = " & Me.ID_History

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

    Public Function Save() As myProjectHistory

        Try

            Dim SQL As String = ""




            If Me.Exists = True Then

                'L'enregistrement existe déjà, il faut faire un update
                SQL = "UPDATE ProjectsHistory SET "
                SQL &= "CE_ID_Project = " & Me.CE_ID_Project & ", "
                SQL &= "ModifyBy ='" & Replace(Me.ModifyBy, "'", "''") & "', "
                SQL &= "ModifyDate ='" & fConvertDateTimeSQL(Me.ModifyDate) & "', "
                SQL &= "Modification ='" & Replace(Me.Modification, "'", "''") & "' "
                SQL &= "WHERE ID_History=" & Me.ID_History & ";"

            Else


                Me.NewID()

                'L'enregistrement n'existe pas encore, il faut faire un insert
                SQL = "INSERT INTO ProjectsHistory "
                SQL &= "(ID_History, CE_ID_Project, ModifyBy, ModifyDate, Modification ) VALUES ("
                SQL &= Me.ID_History & ","
                SQL &= Me.CE_ID_Project & ","
                SQL &= "'" & Replace(Me.ModifyBy, "'", "''") & "',"
                SQL &= "'" & fConvertDateTimeSQL(Me.ModifyDate) & "',"
                SQL &= "'" & Replace(Me.Modification, "'", "''") & "')"

                ID_History = Me.ID_History

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

End Class
