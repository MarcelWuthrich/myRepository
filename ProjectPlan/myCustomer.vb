Imports System.Data.SqlClient



Public Class myCustomer

    Private _ID_Customer As Integer
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

    Public Property ID_Customer As Integer
        Get
            Return _ID_Customer
        End Get
        Set(ByVal value As Integer)
            _ID_Customer = value
        End Set
    End Property

    'Défintion des fonctions

    Public Function Read() As myCustomer

        'Recherche les données d'un statut en fonction de son ID_Customer


        Try

            Dim MySQLConnection As New SqlConnection

            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT ID_Customer, FirstName, LastName, Enable from Customers where ID_Customer =" & Me.ID_Customer

            'Remise à zéro des variables
            Me.ID_Customer = Nothing
            Me.FirstName = Nothing
            Me.Lastname = Nothing
            Me.Enable = Nothing
            Me.FullName = Nothing


            MySQLConnection.ConnectionString = cnProjectPlan


            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)

            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read

                'Lecture du premier paramètre
                Try
                    Me.ID_Customer = mySQLDataReader.GetValue(0)
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

    Public Function NewID() As myCustomer

        'Recherche le plus grand ID_Customer, ajoute 1 et définit la variable ID_Customer
        Dim _NewID As Integer = 0

        Try
            Dim MySQLConn As New SqlConnection
            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT TOP 1 ID_Customer FROM Customers ORDER BY ID_Customer DESC;"

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

        Me.ID_Customer = _NewID

        Return Me

    End Function

    Public Function Exists() As Boolean

        Dim _Exists As Boolean = False
        Dim _Count As Integer = 0

        Try

            Dim MySQLConnection As New SqlConnection

            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT COUNT(ID_Customer) FROM Customers WHERE ID_Customer = " & Me.ID_Customer

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

    Public Function Save() As myCustomer

        Try

            Dim SQL As String = ""




            If Me.Exists = True Then

                'L'enregistrement existe déjà, il faut faire un update
                SQL = "UPDATE Customers SET "
                SQL &= "FirstName ='" & Replace(Me.FirstName, "'", "''") & "',"
                SQL &= "LastName ='" & Replace(Me.Lastname, "'", "''") & "', "
                If Me.Enable = True Then
                    SQL &= "Enable = 1 "
                Else
                    SQL &= "Enable = 0 "
                End If

                SQL &= "WHERE ID_Customer=" & Me.ID_Customer & ";"

            Else


                Me.NewID()

                'L'enregistrement n'existe pas encore, il faut faire un insert
                SQL = "INSERT INTO Customers "
                SQL &= "(ID_Customer, FirstName, LastName, Enable ) VALUES ("
                SQL &= Me.ID_Customer & ","
                SQL &= "'" & Replace(Me._FirstName, "'", "''") & "',"
                SQL &= "'" & Replace(Me.Lastname, "'", "''") & "',"
                If Me.Enable = True Then
                    SQL &= "1)"
                Else
                    SQL &= "0)"
                End If


                ID_Customer = Me.ID_Customer

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

    Public Function GetIDMemberFromFullName() As myCustomer

        'Recherche le ID_Customer en fonction du Fullname
        'INPUT : FullName
        'OUTPUT : myCustomer

        Try

            Dim _ProjectMember As String = Me.FullName

            Dim MySQLConnection As New SqlConnection

            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT ID_Customer FROM Customers;"

            MySQLConnection.ConnectionString = cnProjectPlan


            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)

            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read

                'Lecture du premier paramètre COUNT
                Try
                    Me.ID_Customer = mySQLDataReader.GetValue(0)
                Catch ex As Exception
                End Try

                Me.Read()
                If Me.FullName = _ProjectMember Then Exit While

            End While

            mySQLDataReader.Close()
            MySQLConnection.Close()
        Catch ex As Exception

        End Try

        Return Me

    End Function

End Class
