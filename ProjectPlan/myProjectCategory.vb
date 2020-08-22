Imports System.Data.SqlClient



Public Class myProjectCategory

    Private _ID_Category As Integer
    Private _Category As String
    Private _Enable As Boolean
    Private _DisplayOrder As Boolean


    Public Property Enable As Boolean
        Get
            Return _Enable
        End Get
        Set(value As Boolean)
            _Enable = value
        End Set
    End Property

    Public Property ID_Category As Integer
        Get
            Return _ID_Category
        End Get
        Set(ByVal value As Integer)
            _ID_Category = value
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

    Public Property Category As String
        Get
            Return _Category
        End Get

        Set(ByVal value As String)
            _Category = value
        End Set
    End Property


    Public Function Read() As myProjectCategory

        'Recherche les données d'un statut en fonction de son ID_Status


        Try

            Dim MySQLConnection As New SqlConnection

            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT ID_Category, Category, Enable, DisplayOrder from ProjectCategories where ID_Category =" & Me.ID_Category

            'Remise à zéro des variables
            ID_Category = Nothing
            Category = Nothing
            Enable = Nothing
            DisplayOrder = Nothing

            MySQLConnection.ConnectionString = cnProjectPlan


            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)

            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read

                'Lecture du premier paramètre
                Try
                    Me.ID_Category = mySQLDataReader.GetValue(0)
                Catch ex As Exception
                End Try

                'Lecture du 2e paramètre
                Try
                    Me.Category = mySQLDataReader.GetString(1)
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
