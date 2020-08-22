Imports System.Data.SqlClient


Public Class myAdminResource


    Private _ID_AdminResource As Integer
    Private _AdminResource As String
    Private _Enable As Boolean
    Private _DisplayOrder As Integer
    Private _Symbol As String


    Public Property ID_AdminResource As Integer
        Get
            Return _ID_AdminResource
        End Get
        Set(value As Integer)
            _ID_AdminResource = value
        End Set
    End Property

    Public Property Symbol As String
        Get
            Return _Symbol
        End Get
        Set(value As String)
            _Symbol = value
        End Set
    End Property


    Public Property AdminResource As String
        Get
            Return _AdminResource
        End Get
        Set(value As String)
            _AdminResource = value
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

    Public Property DisplayOrder As Integer
        Get
            Return _DisplayOrder
        End Get
        Set(value As Integer)
            _DisplayOrder = value
        End Set
    End Property


    Public Function read() As myAdminResource

        Try

            'Recherche les données d'une autre ressource en fonction de son ID_AdminResource

            Dim MySQLConnection As New SqlConnection

            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT ID_AdminResource, AdminResource, Enable, DisplayOrder, Symbol FROM AdminResources where ID_AdminResource = " & Me.ID_AdminResource & ";"

            'Remise à zéro des variables
            ID_AdminResource = Nothing
            AdminResource = Nothing
            Enable = Nothing
            DisplayOrder = Nothing
            Symbol = Nothing

            MySQLConnection.ConnectionString = cnProjectPlan


            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)

            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read

                'Lecture du premier paramètre 
                Try
                    Me.ID_AdminResource = mySQLDataReader.GetValue(0)
                Catch ex As Exception
                End Try

                'Lecture du 2e paramètre
                Try
                    Me.AdminResource = mySQLDataReader.GetString(1)
                Catch ex As Exception
                End Try

                'Lecture du 3e paramètre
                Try
                    Me.Enable = mySQLDataReader.GetBoolean(2)
                Catch ex As Exception
                End Try

                'Lecture du 4e paramètre 
                Try
                    Me.DisplayOrder = mySQLDataReader.GetValue(3)
                Catch ex As Exception
                End Try
                'Lecture du 5e paramètre 
                Try
                    Me.Symbol = mySQLDataReader.GetString(4)
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
