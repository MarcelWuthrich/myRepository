Imports System.Data.SqlClient

Public Class myProjectPriority



    Private _ID_Priority As Integer
    Private _Priority As String
    Private _Enable As Boolean
    Private _DisplayOrder As Integer


    Public Property Enable As Boolean
        Get
            Return _Enable
        End Get
        Set(value As Boolean)
            _Enable = value
        End Set
    End Property

    Public Property ID_Priority As Integer
        Get
            Return _ID_Priority
        End Get
        Set(ByVal value As Integer)
            _ID_Priority = value
        End Set
    End Property

    Public Property DisplayOrder As Integer
        Get
            Return _DisplayOrder
        End Get
        Set(ByVal value As Integer)
            _DisplayOrder = value
        End Set
    End Property

    Public Property Priority As String
        Get
            Return _Priority
        End Get

        Set(ByVal value As String)
            _Priority = value
        End Set
    End Property

    Public Function Read() As myProjectPriority

        'Recherche les données d'une priorité en fonction de son ID_Priority


        Try

            Dim MySQLConnection As New SqlConnection

            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT ID_Priority, Priority, Enable, DisplayOrder from ProjectPriority where ID_Priority =" & Me.ID_Priority

            Me.ID_Priority = Nothing
            Me.Priority = Nothing
            Me.Enable = Nothing
            Me.DisplayOrder = Nothing

            MySQLConnection.ConnectionString = cnProjectPlan


            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)

            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read

                'Lecture du premier paramètre
                Try
                    Me.ID_Priority = mySQLDataReader.GetValue(0)
                Catch ex As Exception
                End Try

                'Lecture du 2e paramètre
                Try
                    Me.Priority = mySQLDataReader.GetString(1)
                Catch ex As Exception
                End Try

                'Lecture du 3e paramètre
                Try
                    Me.Enable = mySQLDataReader.GetValue(2)
                Catch ex As Exception
                End Try

                'Lecture du 4e paramètre
                Try
                    Me.DisplayOrder = mySQLDataReader.GetValue(3)
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
