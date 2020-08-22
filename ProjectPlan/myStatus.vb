Imports System.Data.SqlClient


Public Class myStatus


    Private _ID_Status As Integer
    Private _Status As String
    Private _Enable As Boolean


    Public Property Enable As Boolean
        Get
            Return _Enable
        End Get
        Set(value As Boolean)
            _Enable = value
        End Set
    End Property

    Public Property ID_Status As Integer
        Get
            Return _ID_Status
        End Get
        Set(ByVal value As Integer)
            _ID_Status = value
        End Set
    End Property

    Public Property Status As String
        Get
            Return _Status
        End Get

        Set(ByVal value As String)
            _Status = value
        End Set
    End Property


    Public Function Read() As myStatus

        'Recherche les données d'un statut en fonction de son ID_Status


        Try

            Dim MySQLConnection As New SqlConnection

            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT ID_Status, Status, Enable from Status where ID_Status =" & Me.ID_Status

            MySQLConnection.ConnectionString = cnProjectPlan


            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)

            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read

                'Lecture du premier paramètre
                Try
                    Me.ID_Status = mySQLDataReader.GetValue(0)
                Catch ex As Exception
                End Try

                'Lecture du 2e paramètre
                Try
                    Me.Status = mySQLDataReader.GetString(1)
                Catch ex As Exception
                End Try

                'Lecture du 3e paramètre
                Try
                    Me.Enable = mySQLDataReader.GetValue(2)
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

    Public Function Find_ID_From_Status() As myStatus

        'Recherche les données d'un statut en fonction de son status


        Try

            Dim MySQLConnection As New SqlConnection

            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT ID_Status from Status where CONVERT(VARCHAR, Status) = '" & Me.Status & "';"

            MySQLConnection.ConnectionString = cnProjectPlan


            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)

            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read

                'Lecture du premier paramètre
                Try
                    Me.ID_Status = mySQLDataReader.GetValue(0)
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

End Class
