Imports System.Data.SqlClient

Public Class myProjectRemark


    'Défnition des proprétés privées
    Private _ID_Remark As Integer
    Private _CE_ID_Project As Integer
    Private _CreationDate As DateTime
    Private _LastModifyDate As DateTime
    Private _Remark As String




    'Défnition des proprétés publiques
    Public Property Remark As String
        Get
            Return _Remark
        End Get
        Set(value As String)
            _Remark = value
        End Set
    End Property

    Public Property CreationDate As Date
        Get
            Return _CreationDate
        End Get
        Set(value As Date)
            _CreationDate = value
        End Set
    End Property

    Public Property LastModifyDate As Date
        Get
            Return _LastModifyDate
        End Get
        Set(value As Date)
            _LastModifyDate = value
        End Set
    End Property

    Public Property ID_Remark As Integer
        Get
            Return _ID_Remark
        End Get
        Set(value As Integer)
            _ID_Remark = value
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

    Public Function NewID() As myProjectRemark

        'Recherche le plus grand ID_Remark, ajoute 1 et définit la variable  ID_Remark
        Dim _NewID As Integer = 0

        Try
            Dim MySQLConn As New SqlConnection
            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT TOP 1 ID_Remark FROM ProjectsRemarks ORDER BY ID_Remark DESC;"

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

        Me.ID_Remark = _NewID

        Return Me



    End Function

    Public Function Read() As myProjectRemark

        'Recherche les données d'un projet en fonction de son ID_Remark

        Try

            Dim MySQLConnection As New SqlConnection

            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT ID_Remark, CE_ID_Project, CreationDate, LastModifyDate, Remark FROM ProjectsRemarks WHERE ID_Remark=" & Me.ID_Remark

            'Remise à zéro des variables
            ID_Remark = Nothing
            CE_ID_Project = Nothing
            CreationDate = Nothing
            LastModifyDate = Nothing
            Remark = Nothing

            MySQLConnection.ConnectionString = cnProjectPlan


            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)

            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read

                'Lecture du premier paramètre
                Try
                    Me.ID_Remark = mySQLDataReader.GetValue(0)
                Catch ex As Exception
                End Try

                'Lecture du 2e paramètre 
                Try
                    Me.CE_ID_Project = mySQLDataReader.GetValue(1)
                Catch ex As Exception
                End Try

                'Lecture du 3e paramètre 
                Try
                    Me.CreationDate = mySQLDataReader.GetDateTime(2)
                Catch ex As Exception
                End Try

                'Lecture du 4e paramètre 
                Try
                    Me.LastModifyDate = mySQLDataReader.GetDateTime(3)
                Catch ex As Exception
                End Try

                'Lecture du 5e paramètre 
                Try
                    Me.Remark = mySQLDataReader.GetString(4)
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

    Public Function Save() As myProjectRemark

        Try

            Dim SQL As String = ""




            If Me.Exists = True Then

                'On définit la remark
                Dim thisRemark As New myProjectRemark
                thisRemark.ID_Remark = Me.ID_Remark
                thisRemark.Read()



                'L'enregistrement existe déjà, il faut faire un update
                SQL = "UPDATE ProjectsRemarks SET "
                SQL &= "CE_ID_Project = " & Me.CE_ID_Project & ", "
                SQL &= "CreationDate ='" & fConvertDateTimeSQL(Me.CreationDate) & "', "
                SQL &= "LastModifyDate ='" & fConvertDateTimeSQL(Me.LastModifyDate) & "', "
                SQL &= "Remark ='" & Replace(Me.Remark, "'", "''") & "' "
                SQL &= "WHERE ID_Remark = " & Me.ID_Remark & ";"

                'Dim myHistory As New myProjectHistory
                'myHistory.CE_ID_Project = Me.ID_Project
                'myHistory.ModifyBy = Logon
                'myHistory.Modification = ""
                'If myProjectDB.Title <> Me.Title Then myHistory.Modification &= "old title <" & myProjectDB.Title & "> new title <" & Me.Title & "> ; "
                'If myProjectDB.Description <> Me.Description Then myHistory.Modification &= "old description <" & myProjectDB.Description & "> new description <" & Me.Description & "> ; "
                'If myProjectDB.DeadLine <> Me.DeadLine Then myHistory.Modification &= "old deadline <" & myProjectDB.DeadLine & "> new deadline <" & Me.DeadLine & "> ; "
                'If myProjectDB.EstimatedResources <> Me.EstimatedResources Then myHistory.Modification &= "old estimated resources <" & myProjectDB.EstimatedResources & "> new estimated resources <" & Me.EstimatedResources & "> ; "
                'If myProjectDB.EffectiveResources <> Me.EffectiveResources Then myHistory.Modification &= "old effective resources <" & myProjectDB.EffectiveResources & "> new effective resources <" & Me.EffectiveResources & "> ; "
                'If myProjectDB.ImplementationRate <> Me.ImplementationRate Then myHistory.Modification &= "old implementationrate <" & myProjectDB.ImplementationRate & "> new implementation rate <" & Me.ImplementationRate & "> ; "
                'If myProjectDB.CE_ID_Status <> Me.CE_ID_Status Then myHistory.Modification &= "old CE_ID_Status <" & myProjectDB.CE_ID_Status & "> new CE_ID_Status <" & Me.CE_ID_Status & "> ; "
                'If myProjectDB.CE_ID_Priority <> Me.CE_ID_Priority Then myHistory.Modification &= "old CE_ID_Priority <" & myProjectDB.CE_ID_Priority & "> new CE_ID_Priority <" & Me.CE_ID_Priority & "> ; "
                'If myProjectDB.CE_ID_ProjectManager <> Me.CE_ID_ProjectManager Then myHistory.Modification &= "old CE_ID_ProjectManager <" & myProjectDB.CE_ID_ProjectManager & "> new CE_ID_ProjectManager <" & Me.CE_ID_ProjectManager & "> ; "
                'If myProjectDB.CE_ID_Customer <> Me.CE_ID_Customer Then myHistory.Modification &= "old CE_ID_Customer <" & myProjectDB.CE_ID_Customer & "> new CE_ID_Customer <" & Me.CE_ID_Customer & "> ; "
                'If myProjectDB.CE_ID_Category <> Me.CE_ID_Category Then myHistory.Modification &= "old CE_ID_Category <" & myProjectDB.CE_ID_Category & "> new CE_ID_Category <" & Me.CE_ID_Category & "> ; "

                'myHistory.ModifyDate = Now
                'myHistory.Save()

            Else


                Me.NewID()

                'L'enregistrement n'existe pas encore, il faut faire un insert
                SQL = "INSERT INTO ProjectsRemarks "
                SQL &= "(ID_Remark, CE_ID_Project, CreationDate, LastModifyDate, Remark ) VALUES ("
                SQL &= Me.ID_Remark & ","
                SQL &= Me.CE_ID_Project & ","
                SQL &= "'" & fConvertDateTimeSQL(Me.CreationDate) & "', "
                SQL &= "'" & fConvertDateTimeSQL(Me.LastModifyDate) & "', "
                SQL &= "'" & Replace(Me.Remark, "'", "''") & "' )"


                'Dim myHistory As New myProjectHistory
                'myHistory.CE_ID_Project = Me.ID_Project
                'myHistory.ModifyBy = Logon
                'myHistory.Modification = "new project creation, ID <" & Me.ID_Project & "> title <" & Me.Title & "> ; "
                'myHistory.ModifyDate = Now
                'myHistory.Save()

                ID_Remark = Me.ID_Remark

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

    Public Function Exists() As Boolean

        Dim _Exists As Boolean = False
        Dim _Count As Integer = 0

        Try

            Dim MySQLConnection As New SqlConnection

            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT COUNT(ID_Remark) FROM ProjectsRemarks WHERE ID_Remark = " & Me.ID_Remark

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

    Public Function Delete() As myProjectRemark

        Try

            Dim SQL As String = ""




            If Me.Exists = True Then

                'On définit la remark
                Dim thisRemark As New myProjectRemark
                thisRemark.ID_Remark = Me.ID_Remark
                thisRemark.Read()



                'L'enregistrement existe déjà, il faut faire un update
                SQL = "DELETE FROM ProjectsRemarks WHERE "
                SQL &= "ID_Remark = " & Me.ID_Remark & ";"

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

            End If

        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try

        Return Me

    End Function

End Class
