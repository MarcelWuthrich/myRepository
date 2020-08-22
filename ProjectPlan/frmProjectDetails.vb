Imports System.Data.SqlClient


Public Class frmProjectDetails

    Dim thisProject As New myProject
    Dim ID_ProjectEstimatedResource As Integer = 0

    Private Sub btcAnnuler_Click(sender As Object, e As EventArgs) Handles btcAnnuler.Click

        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btcOK_Click(sender As Object, e As EventArgs) Handles btcOK.Click

        Try
            'On définit une nouvelle variable de type myProjet
            Dim thisProject As New myProject

            'On lit la priorité
            Dim ID_Priority As String = DirectCast(lovPriority.SelectedItem, KeyValuePair(Of String, String)).Key

            'On lit l'urgence
            Dim ID_Urgency As String = DirectCast(lovUrgency.SelectedItem, KeyValuePair(Of String, String)).Key

            'On lit le client
            Dim ID_Customer As String = DirectCast(lovCustomer.SelectedItem, KeyValuePair(Of String, String)).Key

            'On lit le chef de projet
            Dim ID_ProjectManager As String = DirectCast(lovProjectManager.SelectedItem, KeyValuePair(Of String, String)).Key

            'On lit la catégorie
            Dim ID_Category As String = DirectCast(lovProjectCategory.SelectedItem, KeyValuePair(Of String, String)).Key


            'On lit des données des champs texte
            thisProject.ID_Project = Val(Me.texID_Project.Text)
            thisProject.Title = Me.texTitre.Text
            thisProject.Description = Me.texDescription.Text
            thisProject.CE_ID_ProjectManager = Me.lovProjectManager.SelectedIndex
            thisProject.BeginDate = Me.dtpBegin.Value
            thisProject.DeadLine = Me.dtpDeadline.Value
            'thisProject.ImplementationRate = Me.texImplementationRate.Text
            thisProject.EstimatedResources = Me.texEstimatedResources.Text
            thisProject.EstimatedResourcesInfra = Me.texEstimatedResourcesInfra.Text
            thisProject.EstimatedResourcesSAP = Me.texEstimatedResourcesSAP.Text
            thisProject.EstimatedResourcesHelpdesk = Me.texEstimatedResourcesHelpdesk.Text
            thisProject.EstimatedResourcesPlaning = Me.texEstimatedResourcesPlaning.Text
            thisProject.CE_ID_Priority = ID_Priority
            thisProject.CE_ID_Category = ID_Category
            thisProject.CE_ID_Customer = ID_Customer
            thisProject.CE_ID_Urgency = ID_Urgency
            thisProject.Text_IT_Board = Me.texITBoard.Text


            'On recherche l'ID_Status qui correspond au texte de lovStatus
            Dim thisStatus As New myStatus
            thisStatus.Status = Me.lovStatus.Text
            thisStatus.Find_ID_From_Status()
            thisProject.CE_ID_Status = thisStatus.ID_Status

            'On recherche l'ID_ProjectManager qui correspond au texte de lovProjectManager
            Dim thisPM As New myProjectManager
            thisPM.FullName = Me.lovProjectManager.Text
            thisPM.Find_ID_From_FullName()
            thisProject.CE_ID_ProjectManager = thisPM.ID_ProjectManager


            ID_Project = thisProject.ID_Project
            thisProject.Save()


            Me.Close()
        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub frmProjectDetails_Close(sender As Object, e As EventArgs) Handles MyBase.Closing

        Try

            ID_Project = 0

        Catch ex As Exception

            If Me.texID_Project.Text = "0" Then Me.texID_Project.Text = ""

        End Try

    End Sub

    Private Sub frmProjectDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'cnProjectPlan = cnProjectPlanWUM
        'ID_Project = 83

        Dim ID As Integer = 0

        Try

            'on définit les status
            pPopulateStatus()

            'on définit les chefs de projets
            pPopulateProjectManager()

            'on définit les chefs de projets
            pPopulateCustomer()

            'On définit les priorités
            pPopulateProjectPriority()

            'On définit les urgences
            pPopulateProjectUrgencies()

            'On définit les catégories
            pPopulateProjectCategories()


            'On lit les informations du projet
            thisProject.ID_Project = ID_Project
            thisProject.Read()
            'thisProject.GetEffectiveResources()

            'On cherche le nombre de jours planifés
            Dim thisResource As New myPlanResource
            If ID_Project <> 0 Then
                thisResource.CE_ID_Project = thisProject.ID_Project
                thisResource.Get_Count_PlanResource_From_CE_ID_Project()
            End If


            'On renseigne les champs 
            Me.texID_Project.Text = thisProject.ID_Project
            Me.texTitre.Text = thisProject.Title
            Me.dtpBegin.Text = thisProject.BeginDate
            Me.dtpDeadline.Text = thisProject.DeadLine
            Me.texDescription.Text = thisProject.Description
            Me.texEstimatedResources.Text = thisProject.EstimatedResources
            Me.texEstimatedResourcesInfra.Text = thisProject.EstimatedResourcesInfra
            Me.texEstimatedResourcesSAP.Text = thisProject.EstimatedResourcesSAP
            Me.texEstimatedResourcesHelpdesk.Text = thisProject.EstimatedResourcesHelpdesk
            Me.texEstimatedResourcesPlaning.Text = thisProject.EstimatedResourcesPlaning
            Me.texImplementationRate.Text = thisProject.ImplementationRate
            Me.texExecutedResources.Text = Format(thisProject.EffectiveResources, "0.0")
            Me.texPlanResources.Text = Format(thisResource.CountPlanResource, "0.0")
            Me.texITBoard.Text = thisProject.Text_IT_Board

            'Chefs de projets
            For I = 0 To lovProjectManager.Items.Count - 1
                ID = DirectCast(lovProjectManager.Items(I), KeyValuePair(Of String, String)).Key
                If thisProject.CE_ID_ProjectManager = ID Then
                    Me.lovProjectManager.SelectedIndex = I
                    Exit For
                End If
            Next I

            'Status
            For I = 0 To lovStatus.Items.Count - 1
                ID = DirectCast(lovStatus.Items(I), KeyValuePair(Of String, String)).Key
                If thisProject.CE_ID_Status = ID Then
                    Me.lovStatus.SelectedIndex = I
                    Exit For
                End If
            Next I

            'Priorité
            For I = 0 To lovPriority.Items.Count - 1
                ID = DirectCast(lovPriority.Items(I), KeyValuePair(Of String, String)).Key
                If thisProject.CE_ID_Priority = ID Then
                    Me.lovPriority.SelectedIndex = I
                    Exit For
                End If
            Next I

            'Urgence
            For I = 0 To lovUrgency.Items.Count - 1
                ID = DirectCast(lovUrgency.Items(I), KeyValuePair(Of String, String)).Key
                If thisProject.CE_ID_Urgency = ID Then
                    Me.lovUrgency.SelectedIndex = I
                    Exit For
                End If
            Next I

            'Catégorie
            For I = 0 To lovProjectCategory.Items.Count - 1
                ID = DirectCast(lovProjectCategory.Items(I), KeyValuePair(Of String, String)).Key
                If thisProject.CE_ID_Category = ID Then
                    Me.lovProjectCategory.SelectedIndex = I
                    Exit For
                End If
            Next I

            'Client
            For I = 0 To lovCustomer.Items.Count - 1
                ID = DirectCast(lovCustomer.Items(I), KeyValuePair(Of String, String)).Key
                If thisProject.CE_ID_Customer = ID Then
                    Me.lovCustomer.SelectedIndex = I
                    Exit For
                End If
            Next I

            'Affichage de toutes les remarques
            pDisplayRemarks()

            If Me.texID_Project.Text = "0" Then Me.texID_Project.Text = ""

        Catch ex As Exception

        End Try
    End Sub

    Private Sub pPopulateStatus()

        Try

            Me.lovStatus.Items.Clear()

            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT ID_Status, Status FROM Status where enable = 1 order by DisplayOrder ASC;"
            Dim MySQLConnection As New SqlConnection

            Dim Status As String = ""
            Dim ID_Status As Integer = 0
            Dim myDictionnary As New Dictionary(Of String, String)()


            MySQLConnection.ConnectionString = cnProjectPlan


            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)

            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read



                Try
                    ID_Status = mySQLDataReader.GetValue(0)
                Catch ex As Exception
                End Try

                Try
                    Status = mySQLDataReader.GetString(1)
                Catch ex As Exception
                End Try

                myDictionnary.Add(Str(ID_Status), Status)

            End While

            Me.lovStatus.DataSource = New BindingSource(myDictionnary, Nothing)
            Me.lovStatus.DisplayMember = "Value"
            Me.lovStatus.ValueMember = "Key)"

            mySQLDataReader.Close()
            MySQLConnection.Close()


        Catch ex As Exception

        End Try

    End Sub

    Private Sub pPopulateProjectPriority()

        Try

            Me.lovPriority.Items.Clear()

            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT ID_Priority, Priority FROM ProjectPriority where enable = 1 order by DisplayOrder ASC;"
            Dim MySQLConnection As New SqlConnection

            Dim Priority As String = ""
            Dim ID_Priority As Integer = 0
            Dim myDictionnary As New Dictionary(Of String, String)()

            MySQLConnection.ConnectionString = cnProjectPlan
            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)

            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read

                Try
                    ID_Priority = mySQLDataReader.GetValue(0)
                Catch ex As Exception
                End Try

                Try
                    Priority = mySQLDataReader.GetString(1)
                Catch ex As Exception
                End Try

                myDictionnary.Add(Str(ID_Priority), Priority)

            End While

            mySQLDataReader.Close()
            MySQLConnection.Close()

            Me.lovPriority.DataSource = New BindingSource(myDictionnary, Nothing)
            Me.lovPriority.DisplayMember = "Value"
            Me.lovPriority.ValueMember = "Key)"

        Catch ex As Exception

        End Try

    End Sub

    Private Sub pPopulateProjectManager()

        Try

            Me.lovProjectManager.Items.Clear()

            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT ID_ProjectManager, FirstName, Lastname FROM ProjectManagers where Enable = 1 ;"
            Dim MySQLConnection As New SqlConnection

            Dim PM As String = ""
            Dim ID_Projectmanagery As Integer = 0
            Dim myDictionnary As New Dictionary(Of String, String)()

            Dim FirstName As String = ""
            Dim LastName As String = ""

            'Le premier enregistrement est une ligne vide
            myDictionnary.Add(Str(0), "")


            MySQLConnection.ConnectionString = cnProjectPlan


            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)
            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read


                Try
                    ID_ProjectManager = mySQLDataReader.GetValue(0)
                Catch ex As Exception
                End Try

                Try
                    FirstName = mySQLDataReader.GetString(1)
                Catch ex As Exception
                End Try

                Try
                    LastName = mySQLDataReader.GetString(2)
                Catch ex As Exception
                End Try

                myDictionnary.Add(Str(ID_ProjectManager), LastName & " " & FirstName)

            End While

            mySQLDataReader.Close()
            MySQLConnection.Close()

            Me.lovProjectManager.DataSource = New BindingSource(myDictionnary, Nothing)
            Me.lovProjectManager.DisplayMember = "Value"
            Me.lovProjectManager.ValueMember = "Key)"

        Catch ex As Exception

        End Try

    End Sub

    Private Sub pPopulateProjectCategories()

        Try

            Me.lovProjectCategory.Items.Clear()

            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT ID_Category, Category FROM ProjectCategories WHERE Enable = 1 ORDER BY DisplayOrder ASC ;"
            Dim MySQLConnection As New SqlConnection

            Dim Category As String = ""
            Dim ID_Category As Integer = 0
            Dim myDictionnary As New Dictionary(Of String, String)()

            MySQLConnection.ConnectionString = cnProjectPlan
            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)
            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read


                Try
                    ID_Category = mySQLDataReader.GetValue(0)
                Catch ex As Exception
                End Try

                Try
                    Category = mySQLDataReader.GetString(1)
                Catch ex As Exception
                End Try

                myDictionnary.Add(Str(ID_Category), Category)

            End While

            mySQLDataReader.Close()
            MySQLConnection.Close()

            Me.lovProjectCategory.DataSource = New BindingSource(myDictionnary, Nothing)
            Me.lovProjectCategory.DisplayMember = "Value"
            Me.lovProjectCategory.ValueMember = "Key"

        Catch ex As Exception

        End Try

    End Sub

    Private Sub texEstimatedResources_LostFocus(sender As Object, e As EventArgs) Handles texEstimatedResources.LostFocus

        Try

            If Val(Me.texEstimatedResources.Text) = 0 Then
                Me.texImplementationRate.Text = "0"
            Else
                Me.texImplementationRate.Text = CInt(thisProject.EffectiveResources / Me.texEstimatedResources.Text * 100)
            End If

        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Sub pPopulateCustomer()

        Try

            Me.lovCustomer.Items.Clear()

            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT ID_Customer, Lastname, Firstname FROM Customers where enable = 1 order by DisplayOrder ASC;"
            Dim MySQLConnection As New SqlConnection

            Dim Lastname As String = ""
            Dim Firstname As String = ""
            Dim ID_Client As Integer = 0
            Dim myDictionnary As New Dictionary(Of String, String)()

            'Le premier enregistrement est une ligne vide
            myDictionnary.Add(Str(0), "")

            MySQLConnection.ConnectionString = cnProjectPlan


            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)

            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read



                Try
                    ID_Client = mySQLDataReader.GetValue(0)
                Catch ex As Exception
                End Try

                Try
                    Lastname = mySQLDataReader.GetString(1)
                Catch ex As Exception
                End Try

                Try
                    Firstname = mySQLDataReader.GetString(2)
                Catch ex As Exception
                End Try

                myDictionnary.Add(Str(ID_Client), Lastname & " " & Firstname)

            End While

            Me.lovCustomer.DataSource = New BindingSource(myDictionnary, Nothing)
            Me.lovCustomer.DisplayMember = "Value"
            Me.lovCustomer.ValueMember = "Key)"

            mySQLDataReader.Close()
            MySQLConnection.Close()


        Catch ex As Exception

        End Try

    End Sub

    Private Sub btcComments_Click(sender As Object, e As EventArgs) Handles btcComments.Click
        Try

            Dim myForm As Form = frmProjectRemarks
            myForm.ShowDialog()
            myForm.Dispose()

        Catch ex As Exception
        End Try
    End Sub


    Private Sub pPopulateProjectUrgencies()

        Try

            Me.lovUrgency.Items.Clear()

            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT ID_Urgency, Urgency FROM Urgencies where enable = 1 order by DisplayOrder ASC;"
            Dim MySQLConnection As New SqlConnection

            Dim Urgency As String = ""
            Dim ID_Urgency As Integer = 0
            Dim myDictionnary As New Dictionary(Of String, String)()

            MySQLConnection.ConnectionString = cnProjectPlan
            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)

            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read

                Try
                    ID_Urgency = mySQLDataReader.GetValue(0)
                Catch ex As Exception
                End Try

                Try
                    Urgency = mySQLDataReader.GetString(1)
                Catch ex As Exception
                End Try

                myDictionnary.Add(Str(ID_Urgency), Urgency)

            End While

            mySQLDataReader.Close()
            MySQLConnection.Close()

            Me.lovUrgency.DataSource = New BindingSource(myDictionnary, Nothing)
            Me.lovUrgency.DisplayMember = "Value"
            Me.lovUrgency.ValueMember = "Key"

        Catch ex As Exception

        End Try

    End Sub

    'Private Sub btcAddRessource_Click(sender As Object, e As EventArgs) Handles btcAddRessource.Click

    '    Try

    '        G_Add_ID_Task = 0
    '        G_Add_NumberDays = 0

    '        Dim myForm As Form = frmProjectAddEstimateRessource
    '        myForm.ShowDialog()
    '        myForm.Dispose()

    '        'On définit la ressource et la sauve dans la DB
    '        Dim myResource As New myProjectEstimatedResource
    '        myResource.CE_ID_Project = thisProject.ID_Project
    '        myResource.CE_ID_Task = G_Add_ID_Task
    '        myResource.NumberDays = G_Add_NumberDays
    '        myResource.Save()

    '        'On affiche les ressources estimées
    '        pDispayEstimatedResources()

    '        G_Add_ID_Task = 0
    '        G_Add_NumberDays = 0


    '    Catch ex As Exception
    '        If DebugFlag = True Then MessageBox.Show(ex.ToString)
    '    End Try

    'End Sub

    'Private Sub pDispayEstimatedResources()

    '    Try
    '        Dim MySQLConnection As New SqlConnection
    '        Dim ActiveRow As Integer = 0

    '        Dim mySQLDataReader As SqlDataReader
    '        Dim Sql As String = "SELECT ID_ProjectEstimatedResource FROM ProjectEstimatedResources WHERE CE_ID_Project=" & thisProject.ID_Project

    '        Me.Cursor = Cursors.WaitCursor

    '        'On vide le DataGridView

    '        dgvEstimatedResources.Rows.Clear()
    '        dgvEstimatedResources.Columns.Clear()


    '        'Définition du DataGridView
    '        dgvEstimatedResources.ReadOnly = True
    '        dgvEstimatedResources.AllowUserToAddRows = False
    '        dgvEstimatedResources.AllowUserToDeleteRows = False
    '        dgvEstimatedResources.MultiSelect = False
    '        dgvEstimatedResources.RowHeadersVisible = False


    '        'Définition des colonnes
    '        dgvEstimatedResources.Columns.Add("ID_ProjectEstimatedResource", "ID_ProjectEstimatedResource")
    '        dgvEstimatedResources.Columns.Add("Tâche", "Tâche")
    '        dgvEstimatedResources.Columns.Add("Jours", "Jours")


    '        'La colonne 0 (ID_Project) n'est pas visible
    '        dgvEstimatedResources.Columns(0).Visible = False

    '        'On ajuste automatiquement la taille des coloness Tâche et nombre de jours
    '        dgvEstimatedResources.AutoResizeColumn(1)
    '        dgvEstimatedResources.AutoResizeColumn(2)

    '        MySQLConnection.ConnectionString = cnProjectPlan
    '        MySQLConnection.Open()

    '        Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)

    '        mySQLDataReader = mySQLCommand.ExecuteReader()

    '        While mySQLDataReader.Read

    '            Dim thisResource As New myProjectEstimatedResource
    '            Dim thisTask As New myTask

    '            'Lecture du premier paramètre ID_ProjectEstimatedResource
    '            Try
    '                'Lecture du projet
    '                thisResource.ID_ProjectEstimatedResource = mySQLDataReader.GetValue(0)
    '                thisResource.Read()

    '                thisTask.ID_Task = thisResource.CE_ID_Task
    '                thisTask.Read()

    '                'On ajoute la ressource dans le DataGridView
    '                dgvEstimatedResources.Rows.Add()
    '                dgvEstimatedResources.Item(0, ActiveRow).Value = thisResource.ID_ProjectEstimatedResource
    '                dgvEstimatedResources.Item(1, ActiveRow).Value = thisTask.Task
    '                dgvEstimatedResources.Item(2, ActiveRow).Value = thisResource.NumberDays

    '                'On ajuste automatiquement la taille des coloness Tâche et nombre de jours
    '                dgvEstimatedResources.AutoResizeColumn(1)
    '                dgvEstimatedResources.AutoResizeColumn(2)

    '                ActiveRow = ActiveRow + 1
    '            Catch ex As Exception
    '            End Try

    '        End While

    '        mySQLDataReader.Close()
    '        MySQLConnection.Close()

    '        'On sélectionne la première ligne
    '        Select Case dgvEstimatedResources.RowCount
    '            Case 0
    '                ID_ProjectEstimatedResource = 0

    '            Case Else
    '                dgvEstimatedResources.Rows(0).Selected = True
    '                ID_ProjectEstimatedResource = dgvEstimatedResources.Item(0, dgvEstimatedResources.CurrentCell.RowIndex).Value

    '        End Select

    '        ''On affiche le total des ressources par tâches
    '        'Dim thisRes As New myProjectEstimatedResource
    '        'thisRes.CE_ID_Project = ID_Project
    '        'thisRes.GetEstimatedProjectResources()
    '        'Me.texEstimatedResources.Text = thisRes.EstimatedProjectResources

    '        Me.Cursor = Cursors.Default

    '    Catch ex As Exception
    '        Me.Cursor = Cursors.Default
    '        If DebugFlag = True Then MessageBox.Show(ex.ToString)

    '    End Try

    'End Sub

    'Private Sub btcRemoveRessource_Click(sender As Object, e As EventArgs) Handles btcRemoveRessource.Click

    '    Try

    '        Dim myResource As New myProjectEstimatedResource
    '        myResource.ID_ProjectEstimatedResource = ID_ProjectEstimatedResource
    '        If myResource.Delete = True Then
    '            pDispayEstimatedResources()
    '        End If

    '    Catch ex As Exception
    '        If DebugFlag = True Then MessageBox.Show(ex.ToString)
    '    End Try

    'End Sub

    Private Sub texEstimatedResourcesInfra_TextChanged(sender As Object, e As EventArgs) Handles texEstimatedResourcesInfra.TextChanged
        Try
            pCalculateTotalEstimated()
        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub pCalculateTotalEstimated()
        Try

            Dim myInfra As Integer = 0
            Dim mySAP As Integer = 0
            Dim myHelpdesk As Integer = 0
            Dim myPlaning As Integer = 0

            Try
                myInfra = CInt(Me.texEstimatedResourcesInfra.Text)
            Catch ex As Exception
                myInfra = 0
            End Try

            Try
                mySAP = CInt(Me.texEstimatedResourcesSAP.Text)
            Catch ex As Exception
                mySAP = 0
            End Try

            Try
                myHelpdesk = CInt(Me.texEstimatedResourcesHelpdesk.Text)
            Catch ex As Exception
                myHelpdesk = 0
            End Try

            Try
                myPlaning = CInt(Me.texEstimatedResourcesPlaning.Text)
            Catch ex As Exception
                myPlaning = 0
            End Try

            Me.texEstimatedResources.Text = myInfra + mySAP + myHelpdesk + myPlaning

        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub texEstimatedResourcesSAP_TextChanged(sender As Object, e As EventArgs) Handles texEstimatedResourcesSAP.TextChanged
        Try
            pCalculateTotalEstimated()
        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub texEstimatedResourcesHelpdesk_TextChanged(sender As Object, e As EventArgs) Handles texEstimatedResourcesHelpdesk.TextChanged
        Try
            pCalculateTotalEstimated()
        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub texEstimatedResourcesPlaning_TextChanged(sender As Object, e As EventArgs) Handles texEstimatedResourcesPlaning.TextChanged
        Try
            pCalculateTotalEstimated()
        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try
    End Sub


    Private Sub pDisplayRemarks()

        Try
            Dim ActiveRow As Integer = 0
            Dim MySQLConnection As New SqlConnection

            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT ID_Remark FROM ProjectsRemarks WHERE CE_ID_Project = " & ID_Project & " ORDER BY ID_Remark DESC;"

            Me.Cursor = Cursors.WaitCursor

            'On vide le DataGridView
            dgvProjectRemarks.Rows.Clear()
            dgvProjectRemarks.Columns.Clear()

            'On rend certains éléments invisible durant le chargement des données
            'dgvProjectRemarks.Visible = False



            'Définition du DataGridView
            dgvProjectRemarks.ReadOnly = True
            dgvProjectRemarks.AllowUserToAddRows = False
            dgvProjectRemarks.AllowUserToDeleteRows = False
            dgvProjectRemarks.MultiSelect = False

            'Paramètres pour le multiline dans les DataGridView
            dgvProjectRemarks.DefaultCellStyle.WrapMode = DataGridViewTriState.False
            dgvProjectRemarks.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells


            'Définition des colonnes
            'dgvProjectRemarks.Columns.Add("ID_Project", "ID_Project")
            dgvProjectRemarks.Columns.Add("ID", "ID")
            dgvProjectRemarks.Columns.Add("CE_ID_Project", "CE_ID_Project")
            dgvProjectRemarks.Columns.Add("CreationDate", "CreationDate")
            dgvProjectRemarks.Columns.Add("LastModifyDate", "LastModifyDate")
            dgvProjectRemarks.Columns.Add("Remark", "Remark")


            'La colonne 0 (ID_Project) n'est pas visible
            'dgvProjets.Columns(0).Visible = False
            'dgvProjets.Columns(0).Visible = True

            'On ajuste automatiquement la taille des colonnes
            'Dim myCol0 As DataGridViewColumn = dgvProjectRemarks.Columns(0)
            'myCol0.Width = 25
            dgvProjectRemarks.Columns(0).Width = 25
            dgvProjectRemarks.Columns(0).Visible = False    'Inutile de voir l'ID
            dgvProjectRemarks.Columns(1).Width = 25
            dgvProjectRemarks.Columns(1).Visible = False    'Inutile de voir le projet
            dgvProjectRemarks.Columns(2).Width = 110        'parfait 110 pour les datetime
            dgvProjectRemarks.Columns(3).Width = 110        'parfait 110 pour les datetime
            dgvProjectRemarks.Columns(4).Width = dgvProjectRemarks.Width - 110 - 110 - 44   '44 c'est la marge




            MySQLConnection.ConnectionString = cnProjectPlan
            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)

            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read

                Dim thisRemark As New myProjectRemark

                'Lecture du premier paramètre 
                Try
                    'Lecture de la remark
                    thisRemark.ID_Remark = mySQLDataReader.GetValue(0)
                    thisRemark.Read()

                    'On ajoute les remarques dans le DataGridView
                    dgvProjectRemarks.Rows.Add()
                    dgvProjectRemarks.Item(0, ActiveRow).Value = thisRemark.ID_Remark
                    dgvProjectRemarks.Item(1, ActiveRow).Value = thisRemark.CE_ID_Project
                    dgvProjectRemarks.Item(2, ActiveRow).Value = thisRemark.CreationDate
                    dgvProjectRemarks.Item(3, ActiveRow).Value = thisRemark.LastModifyDate
                    dgvProjectRemarks.Item(4, ActiveRow).Value = thisRemark.Remark


                    'Le solde la largeur est attribué à la description
                    'Dim myMinWidth As Integer = 60
                    'Dim myWidth As Integer = dgvProjectRemarks.Width - dgvProjectRemarks.Columns(1).Width - dgvProjectRemarks.Columns(2).Width - dgvProjectRemarks.Columns(4).Width - 60
                    'If myWidth >= myMinWidth Then
                    '    dgvProjectRemarks.Columns(4).Width = myWidth
                    'Else
                    '    dgvProjectRemarks.Columns(4).Width = myMinWidth
                    'End If

                    ActiveRow = ActiveRow + 1
                Catch ex As Exception
                End Try

            End While

            mySQLDataReader.Close()
            MySQLConnection.Close()

            'Si dgvProjectRemarks contient des valeurs, on sélectionne la première ligne
            If dgvProjectRemarks.RowCount > 0 Then
                dgvProjectRemarks.Rows(0).Selected = True
                ID_Remark = dgvProjectRemarks.Item(0, 0).Value
            End If



            'On rend certains éléments visible après le chargement des données
            dgvProjectRemarks.Visible = True



            Me.Cursor = Cursors.Default

        Catch ex As Exception

            If DebugFlag = True Then MessageBox.Show(ex.ToString)

        End Try
    End Sub

    Private Sub btcRemarkAdd_Click(sender As Object, e As EventArgs) Handles btcRemarkAdd.Click

        Try

            ID_Remark = 0
            Dim myForm As Form = frmProjectRemarkText
            myForm.ShowDialog()
            myForm.Dispose()
            pDisplayRemarks()

        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Sub dgvProjectRemarks_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProjectRemarks.CellContentClick
        Try

            dgvProjectRemarks.Rows(dgvProjectRemarks.CurrentCell.RowIndex).Selected = True
            ID_Remark = dgvProjectRemarks.Item(0, dgvProjectRemarks.CurrentCell.RowIndex).Value

        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try
    End Sub


    Private Sub dgvProjectRemarks_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProjectRemarks.CellDoubleClick
        Try

            dgvProjectRemarks.Rows(dgvProjectRemarks.CurrentCell.RowIndex).Selected = True
            ID_Remark = dgvProjectRemarks.Item(0, dgvProjectRemarks.CurrentCell.RowIndex).Value

            Dim myForm As Form = frmProjectRemarkText
            myForm.ShowDialog()
            myForm.Dispose()

            pDisplayRemarks()
        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub btcRemarkRemove_Click(sender As Object, e As EventArgs) Handles btcRemarkRemove.Click

        Try

            Dim Response As DialogResult
            Dim myRemark As New myProjectRemark

            If ID_Remark <> 0 Then

                myRemark.ID_Remark = ID_Remark
                myRemark.Read()

                Response = MessageBox.Show(Me, "Voulez-vous vraiment supprimer la remarque suivante ?" & vbCrLf & vbCrLf & myRemark.Remark, "Supprimer", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

                If Response = vbYes Then
                    myRemark.Delete()
                    pDisplayRemarks()
                End If

            End If

        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Sub btcRemardModify_Click(sender As Object, e As EventArgs) Handles btcRemardModify.Click

        Try
            Dim myForm As Form = frmProjectRemarkText
            myForm.ShowDialog()
            myForm.Dispose()

            pDisplayRemarks()
        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class