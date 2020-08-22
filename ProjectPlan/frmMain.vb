Imports System.Data.SqlClient

Public Class frmMain

    'Cette variable permet d'éviter de charge 3x les données dans le résumé des ressources planifiées
    'Une fois avec le chargement de la fenêtre, une 2e fois en chargant le lovProject et une 3e fois en chargeant le lovProjectMember
    Dim InitialProjectResourceResume As Boolean = True

    Private Sub btcFermer_Click(sender As Object, e As EventArgs) Handles btcFermer.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btcProjets_Click(sender As Object, e As EventArgs) Handles BTCProjets.Click
        Try

            pDisplayGroup("Projects")


            'Polulate des statuts
            pPopulateFilterStatus()

            'Polulate des categories
            pPopulateFilterCategory()

            'Affichage de tous les projets
            pDisplayProjects()



        Catch ex As Exception

            If DebugFlag = True Then MessageBox.Show(ex.ToString)

        End Try
    End Sub

    Private Sub pPopulateFilterCategory()

        Try

            Me.lovFilterCategory.Items.Clear()

            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT ID_Category, Category FROM ProjectCategories WHERE Enable = 1 ORDER BY DisplayOrder ASC ;"
            Dim MySQLConnection As New SqlConnection

            Dim Category As String = ""
            Dim ID_Category As Integer = 0
            Dim myDictionnary As New Dictionary(Of String, String)()

            'On insère une ligne vide
            myDictionnary.Add(Str(0), "")

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

            Me.lovFilterCategory.DataSource = New BindingSource(myDictionnary, Nothing)
            Me.lovFilterCategory.DisplayMember = "Value"
            Me.lovFilterCategory.ValueMember = "Key)"

            Me.lovFilterCategory.SelectedIndex = 0

        Catch ex As Exception

        End Try

    End Sub

    Private Sub pPopulateFilterStatus()

        Try

            Me.lovFilterStatus.Items.Clear()

            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT ID_Status, Status FROM Status WHERE Enable = 1 ORDER BY DisplayOrder ASC ;"
            Dim MySQLConnection As New SqlConnection

            Dim Status As String = ""
            Dim ID_Status As Integer = 0
            Dim myDictionnary As New Dictionary(Of String, String)()

            'On insère une ligne vide
            myDictionnary.Add(Str(0), "")

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

            mySQLDataReader.Close()
            MySQLConnection.Close()

            Me.lovFilterStatus.DataSource = New BindingSource(myDictionnary, Nothing)
            Me.lovFilterStatus.DisplayMember = "Value"
            Me.lovFilterStatus.ValueMember = "Key)"

            Me.lovFilterStatus.SelectedIndex = 0

        Catch ex As Exception

        End Try

    End Sub


    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try




            'Quel est le domaine/username de l'utilisateur ?
            Logon = System.Environment.GetEnvironmentVariable("USERDOMAIN") & "\" & System.Environment.GetEnvironmentVariable("USERNAME")

            'Choix de la base de données
            Dim DB As New Form
            DB = frmSelectDB
            DB.ShowDialog()
            DB.Dispose()

            'cnProjectPlan = cnProjectPlanWUM


            'cnProjectPlan = InputBox("Connection String", "DB", cnProjectPlan)
            Me.WindowState = FormWindowState.Maximized

            Select Case cnProjectPlan
                Case cnProjectPlanProd
                    Me.Text = "ProjectPlan - Productive Database"
                Case cnProjectPlanTest
                    Me.Text = "ProjectPlan - Test Database"
                Case cnProjectPlanWUM
                    Me.Text = "ProjectPlan - WUM Private Database"
            End Select

            pDisplayGroup("")

            'pComputeEffectivesResources()


        Catch ex As Exception

        End Try
    End Sub

    Private Sub pDisplayGroup(GroupName As String)

        Try

            grpProjects.Visible = False
            grpProjectManager.Visible = False
            grpProjectsMembers.Visible = False
            grpResourcePlanning.Visible = False
            grpCustomers.Visible = False

            Select Case GroupName

                Case "ProjectManagers"
                    grpProjectManager.Visible = True

                Case "Projects"
                    grpProjects.Visible = True

                Case "ProjectsMembers"
                    grpProjectsMembers.Visible = True

                Case "ResourcePlanning"
                    grpResourcePlanning.Visible = True
                    InitialProjectResourceResume = True

                Case "Customers"
                    grpCustomers.Visible = True

            End Select


        Catch ex As Exception

        End Try
    End Sub

    Private Sub btcMembresProjets_Click(sender As Object, e As EventArgs) Handles btcMembresProjets.Click

        Try

            pDisplayGroup("ProjectsMembers")

            'Affichage de tous les membres de projets
            pDisplayProjectMembers()



        Catch ex As Exception

        End Try
    End Sub

    Private Sub btcPlanificationRessources_Click(sender As Object, e As EventArgs) Handles btcPlanificationRessources.Click

        Try

            Cursor.Current = Cursors.WaitCursor

            pDisplayGroup("ResourcePlanning")


            Cursor.Current = Cursors.Default

            InitialProjectResourceResume = False

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvProjets_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvProjets.CellClick

        Try

            dgvProjets.Rows(dgvProjets.CurrentCell.RowIndex).Selected = True
            ID_Project = dgvProjets.Item(0, dgvProjets.CurrentCell.RowIndex).Value

        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgvProjets_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvProjets.CellDoubleClick

        Try

            dgvProjets.Rows(dgvProjets.CurrentCell.RowIndex).Selected = True
            ID_Project = dgvProjets.Item(0, dgvProjets.CurrentCell.RowIndex).Value

            'Dim thisProject As New myProject
            'thisProject.ID_Project = ID_Project
            'thisProject.Read()

            'Dim Message As String = ""
            'Dim Caption As String = ""
            'Dim Buttons As MessageBoxButtons
            'Dim Icon As MessageBoxIcon
            'Dim Result As New DialogResult

            'Message &= "Titre : " & vbCrLf & thisProject.Title & vbCrLf & vbCrLf
            'Message &= "Catégrorie : " & vbCrLf & thisProject.Category & vbCrLf & vbCrLf
            'Message &= "Descrption : " & vbCrLf & thisProject.Description

            ''Displays the MessageBox
            'Caption = "Info sur le projet"
            'Buttons = MessageBoxButtons.OK
            'Icon = MessageBoxIcon.Information
            'Result = MessageBox.Show(Message, Caption, Buttons, Icon)

            Dim myForm As Form = frmProjectDetails
            myForm.ShowDialog()
            myForm.Dispose()

            pDisplayProjects()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub pDisplayProjects()

        Try
            Dim ActiveRow As Integer = 0
            Dim MySQLConnection As New SqlConnection

            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = ""
            If Me.chkAllProjects.Checked = True Then
                Sql = "SELECT ID_Project FROM Projects;"
            Else
                Sql = "SELECT ID_Project FROM Projects WHERE CE_ID_Status in (6,7,8,9);"
            End If

            Me.Cursor = Cursors.WaitCursor

            'On vide le DataGridView
            dgvProjets.Rows.Clear()
            dgvProjets.Columns.Clear()

            'On rend certains éléments invisible durant le chargement des données
            dgvProjets.Visible = False



            'Définition du DataGridView
            dgvProjets.ReadOnly = True
            dgvProjets.AllowUserToAddRows = False
            dgvProjets.AllowUserToDeleteRows = False
            dgvProjets.MultiSelect = False


            'Définition des colonnes
            'dgvProjets.Columns.Add("ID_Project", "ID_Project")
            dgvProjets.Columns.Add("ID", "ID")
            dgvProjets.Columns.Add("Titre", "Titre")
            dgvProjets.Columns.Add("Categorie", "Catégorie")
            dgvProjets.Columns.Add("Description", "Description")
            dgvProjets.Columns.Add("Statut", "Statut")
            dgvProjets.Columns.Add("Deadline", "Deadline")
            dgvProjets.Columns.Add("Chef de projet", "Chef de projet")
            dgvProjets.Columns.Add("Ressources", "Ressources estimées")
            dgvProjets.Columns.Add("Ressources", "Ressources réalisées")
            dgvProjets.Columns.Add("Taux", "Taux de réalisation")
            dgvProjets.Columns.Add("Priorité", "Priorité")
            dgvProjets.Columns.Add("Urgence", "Urgence")


            MySQLConnection.ConnectionString = cnProjectPlan
            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)

            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read

                Dim thisProject As New myProject
                Dim thisCategory As New myProjectCategory
                Dim thisPrio As New myPriority
                Dim thisUrgency As New myUrgency

                'Lecture du premier paramètre COUNT
                Try
                    'Lecture du projet
                    thisProject.ID_Project = mySQLDataReader.GetValue(0)
                    thisProject.Read()

                    'Lecture de la catégorie
                    thisCategory.ID_Category = thisProject.CE_ID_Category
                    thisCategory.Read()

                    'Lecture de la priorité
                    thisPrio.ID_Priority = thisProject.CE_ID_Priority
                    thisPrio.Read()

                    'Lecture de l'urgence
                    thisUrgency.ID_Urgency = thisProject.CE_ID_Urgency
                    thisUrgency.Read()

                    'On ajoute le projet dans le DataGridView
                    dgvProjets.Rows.Add()
                    dgvProjets.Item(0, ActiveRow).Value = thisProject.ID_Project
                    dgvProjets.Item(1, ActiveRow).Value = thisProject.Title
                    dgvProjets.Item(2, ActiveRow).Value = thisCategory.Category
                    dgvProjets.Item(3, ActiveRow).Value = thisProject.Description
                    Dim _myStatus As New myStatus
                    _myStatus.ID_Status = thisProject.CE_ID_Status
                    _myStatus.Read()
                    dgvProjets.Item(4, ActiveRow).Value = _myStatus.Status
                    dgvProjets.Item(5, ActiveRow).Value = Format(thisProject.DeadLine, "yyyy-MM-dd")
                    Dim _myPM As New myProjectManager
                    _myPM.ID_ProjectManager = thisProject.CE_ID_ProjectManager
                    _myPM.Read()
                    dgvProjets.Item(6, ActiveRow).Value = _myPM.FullName
                    dgvProjets.Item(7, ActiveRow).Value = thisProject.EstimatedResources
                    dgvProjets.Item(8, ActiveRow).Value = thisProject.EffectiveResources
                    dgvProjets.Item(9, ActiveRow).Value = thisProject.ImplementationRate
                    dgvProjets.Item(10, ActiveRow).Value = thisPrio.Priority
                    dgvProjets.Item(11, ActiveRow).Value = thisUrgency.Urgency

                    'La colonne 0 (ID_Project) n'est pas visible
                    'dgvProjets.Columns(0).Visible = False
                    'dgvProjets.Columns(0).Visible = True

                    'On ajuste automatiquement la taille des coloness titre et catégorie
                    Dim myCol0 As DataGridViewColumn = dgvProjets.Columns(0)
                    myCol0.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    dgvProjets.AutoResizeColumn(1)
                    dgvProjets.AutoResizeColumn(2)
                    dgvProjets.AutoResizeColumn(4)
                    dgvProjets.AutoResizeColumn(5)
                    dgvProjets.AutoResizeColumn(6)
                    dgvProjets.AutoResizeColumn(7)
                    dgvProjets.AutoResizeColumn(8)
                    dgvProjets.AutoResizeColumn(9)
                    dgvProjets.AutoResizeColumn(10)
                    dgvProjets.AutoResizeColumn(11)


                    'Le solde la largeur est attribué à la description
                    Dim myMinWidth As Integer = 60
                    Dim myWidth As Integer = dgvProjets.Width - dgvProjets.Columns(1).Width - dgvProjets.Columns(2).Width - dgvProjets.Columns(4).Width - dgvProjets.Columns(5).Width - dgvProjets.Columns(6).Width - dgvProjets.Columns(7).Width - dgvProjets.Columns(8).Width - dgvProjets.Columns(9).Width - dgvProjets.Columns(10).Width - dgvProjets.Columns(11).Width - 70
                    If myWidth >= myMinWidth Then
                        dgvProjets.Columns(3).Width = myWidth
                    Else
                        dgvProjets.Columns(3).Width = myMinWidth
                    End If



                    ActiveRow = ActiveRow + 1
                Catch ex As Exception
                End Try

            End While

            mySQLDataReader.Close()
            MySQLConnection.Close()

            dgvProjets.Rows(0).Selected = True
            ID_Project = dgvProjets.Item(0, dgvProjets.CurrentCell.RowIndex).Value

            'On rend certains éléments visible après le chargement des données
            dgvProjets.Visible = True

            Me.labProjectsNumber.Text = "Projects : " & dgvProjets.RowCount & "/" & dgvProjets.RowCount

            'Si le filtre contient une valeur, on filtre
            If Me.texFilter.Text <> "" Or Me.lovFilterStatus.SelectedIndex <> 0 Or Me.lovFilterCategory.SelectedIndex <> 0 Then
                pFilterDGV()
            End If

            Me.Cursor = Cursors.Default

        Catch ex As Exception

            If DebugFlag = True Then MessageBox.Show(ex.ToString)

        End Try
    End Sub

    Private Sub btcModifyProject_Click(sender As Object, e As EventArgs) Handles btcModifyProject.Click

        Try

            Dim myForm As Form = frmProjectDetails
            myForm.ShowDialog()
            myForm.Dispose()

            pDisplayProjects()

            pFilterDGV()


        Catch ex As Exception

        End Try

    End Sub

    Private Sub btcAddProject_Click(sender As Object, e As EventArgs) Handles btcAddProject.Click

        Try

            ID_Project = 0

            Dim myForm As Form = frmProjectDetails
            myForm.ShowDialog()
            myForm.Dispose()

            pDisplayProjects()
            pFilterDGV()


        Catch ex As Exception

        End Try

    End Sub

    Private Sub btcProjectManager_Click(sender As Object, e As EventArgs) Handles btcProjectManager.Click


        Try

            pDisplayGroup("ProjectManagers")


            'Affichage de tous les chefs de projets
            pDisplayProjectManagers()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub pDisplayProjectManagers()

        Try
            Dim ActiveRow As Integer = 0
            Dim MySQLConnection As New SqlConnection

            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT ID_ProjectManager FROM ProjectManagers"



            'On vide le DataGridView
            dgvProjectManager.Rows.Clear()
            dgvProjectManager.Columns.Clear()


            'Définition du DataGridView
            dgvProjectManager.ReadOnly = True
            dgvProjectManager.AllowUserToAddRows = False
            dgvProjectManager.AllowUserToDeleteRows = False
            dgvProjectManager.MultiSelect = False


            'Définition des colonnes
            dgvProjectManager.Columns.Add("ID_ProjectManager", "ID_ProjectManager")
            dgvProjectManager.Columns.Add("Prenom", "Prénom")
            dgvProjectManager.Columns.Add("Nom", "Nom")


            MySQLConnection.ConnectionString = cnProjectPlan
            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)

            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read

                Dim _thisPM As New myProjectManager

                'Lecture du premier paramètre COUNT
                Try
                    _thisPM.ID_ProjectManager = mySQLDataReader.GetValue(0)
                    _thisPM.Read()

                    'On ajoute le projet dans le DataGridView
                    dgvProjectManager.Rows.Add()
                    dgvProjectManager.Item(0, ActiveRow).Value = _thisPM.ID_ProjectManager
                    dgvProjectManager.Item(1, ActiveRow).Value = _thisPM.FirstName
                    dgvProjectManager.Item(2, ActiveRow).Value = _thisPM.Lastname

                    'La colonne 0 (ID_Project) n'est pas visible
                    dgvProjectManager.Columns(0).Visible = False

                    'On ajuste la taille des colonnes
                    dgvProjectManager.Columns(1).Width = 150
                    dgvProjectManager.Columns(2).Width = 150
                    'dgvProjectManager.AutoResizeColumn(1)
                    'dgvProjectManager.AutoResizeColumn(2)

                    ActiveRow = ActiveRow + 1
                Catch ex As Exception
                End Try

            End While

            mySQLDataReader.Close()
            MySQLConnection.Close()

            dgvProjectManager.Rows(0).Selected = True
            ID_ProjectManager = dgvProjectManager.Item(0, dgvProjectManager.CurrentCell.RowIndex).Value

        Catch ex As Exception

        End Try
    End Sub


    Private Sub pDisplayCustomers()
        Try

            Dim ActiveRow As Integer = 0
            Dim MySQLConnection As New SqlConnection

            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT ID_Customer FROM Customers"



            'On vide le DataGridView
            dgvCustomers.Rows.Clear()
            dgvCustomers.Columns.Clear()


            'Définition du DataGridView
            dgvCustomers.ReadOnly = True
            dgvCustomers.AllowUserToAddRows = False
            dgvCustomers.AllowUserToDeleteRows = False
            dgvCustomers.MultiSelect = False


            'Définition des colonnes
            dgvCustomers.Columns.Add("ID_Customer", "ID_Customer")
            dgvCustomers.Columns.Add("Nom", "Nom")
            dgvCustomers.Columns.Add("Prenom", "Prénom")


            MySQLConnection.ConnectionString = cnProjectPlan
            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)

            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read

                Dim thisCustomer As New myCustomer

                'Lecture du premier paramètre COUNT
                Try
                    thisCustomer.ID_Customer = mySQLDataReader.GetValue(0)
                    thisCustomer.Read()

                    'On ajoute le commanditaire dans le DataGridView
                    dgvCustomers.Rows.Add()
                    dgvCustomers.Item(0, ActiveRow).Value = thisCustomer.ID_Customer
                    dgvCustomers.Item(1, ActiveRow).Value = thisCustomer.Lastname
                    dgvCustomers.Item(2, ActiveRow).Value = thisCustomer.FirstName

                    'La colonne 0 (ID_Customer) n'est pas visible
                    dgvCustomers.Columns(0).Visible = False

                    'On ajuste la taille des colonnes
                    'dgvCustomers.Columns(1).Width = 150
                    'dgvCustomers.Columns(2).Width = 150
                    dgvCustomers.AutoResizeColumn(1)
                    dgvCustomers.AutoResizeColumn(2)

                    ActiveRow = ActiveRow + 1
                Catch ex As Exception
                End Try

            End While

            mySQLDataReader.Close()
            MySQLConnection.Close()

            dgvCustomers.Rows(0).Selected = True
            ID_Customer = dgvCustomers.Item(0, dgvCustomers.CurrentCell.RowIndex).Value


        Catch ex As Exception

        End Try

    End Sub


    Private Sub pDisplayProjectMembers()

        Try
            Dim ActiveRow As Integer = 0
            Dim MySQLConnection As New SqlConnection

            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT ID_ProjectMember FROM ProjectsMembers"



            'On vide le DataGridView
            dgvProjectsMembers.Rows.Clear()
            dgvProjectsMembers.Columns.Clear()


            'Définition du DataGridView
            dgvProjectsMembers.ReadOnly = True
            dgvProjectsMembers.AllowUserToAddRows = False
            dgvProjectsMembers.AllowUserToDeleteRows = False
            dgvProjectsMembers.MultiSelect = False


            'Définition des colonnes
            dgvProjectsMembers.Columns.Add("ID_ProjectMember", "ID_ProjectMember")
            dgvProjectsMembers.Columns.Add("Prenom", "Prénom")
            dgvProjectsMembers.Columns.Add("Nom", "Nom")
            dgvProjectsMembers.Columns.Add("Tâche", "Tâche")


            MySQLConnection.ConnectionString = cnProjectPlan
            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)

            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read

                Dim thisMember As New myProjectMember
                Dim thisTask As New myTask

                'Lecture du premier paramètre COUNT
                Try
                    thisMember.ID_ProjectMember = mySQLDataReader.GetValue(0)
                    thisMember.Read()

                    thisTask.ID_Task = thisMember.CE_ID_Task
                    thisTask.Read()

                    'On ajoute le projet dans le DataGridView
                    dgvProjectsMembers.Rows.Add()
                    dgvProjectsMembers.Item(0, ActiveRow).Value = thisMember.ID_ProjectMember
                    dgvProjectsMembers.Item(1, ActiveRow).Value = thisMember.FirstName
                    dgvProjectsMembers.Item(2, ActiveRow).Value = thisMember.Lastname
                    dgvProjectsMembers.Item(3, ActiveRow).Value = thisTask.Task

                    'La colonne 0 (ID_Project) n'est pas visible
                    dgvProjectsMembers.Columns(0).Visible = False

                    'On ajuste  la taille des colonnes
                    dgvProjectsMembers.Columns(1).Width = 150
                    dgvProjectsMembers.Columns(2).Width = 150
                    dgvProjectsMembers.Columns(3).Width = 100

                    ActiveRow = ActiveRow + 1
                Catch ex As Exception
                End Try

            End While

            mySQLDataReader.Close()
            MySQLConnection.Close()

            dgvProjectsMembers.Rows(0).Selected = True
            ID_ProjectMember = dgvProjectsMembers.Item(0, dgvProjectsMembers.CurrentCell.RowIndex).Value

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btcAddProjectManager_Click(sender As Object, e As EventArgs) Handles btcAddProjectManager.Click

        Try

            ID_ProjectManager = 0

            Dim myForm As Form = frmProjectManagerDetails
            myForm.ShowDialog()
            myForm.Dispose()

            pDisplayProjectManagers()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btcModifyProjectManager_Click(sender As Object, e As EventArgs) Handles btcModifyProjectManager.Click

        Try

            Dim myForm As Form = frmProjectManagerDetails
            myForm.ShowDialog()
            myForm.Dispose()

            pDisplayProjectManagers()


        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgvProjectManager_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProjectManager.CellClick

        Try

            dgvProjectManager.Rows(dgvProjectManager.CurrentCell.RowIndex).Selected = True
            ID_ProjectManager = dgvProjectManager.Item(0, dgvProjectManager.CurrentCell.RowIndex).Value

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvProjetManager_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvProjectManager.CellDoubleClick

        Try

            dgvProjectManager.Rows(dgvProjectManager.CurrentCell.RowIndex).Selected = True
            ID_ProjectManager = dgvProjectManager.Item(0, dgvProjectManager.CurrentCell.RowIndex).Value


        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvProjectsMembers_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProjectsMembers.CellClick

        Try

            dgvProjectsMembers.Rows(dgvProjectsMembers.CurrentCell.RowIndex).Selected = True
            ID_ProjectMember = dgvProjectsMembers.Item(0, dgvProjectsMembers.CurrentCell.RowIndex).Value

        Catch ex As Exception

        End Try

    End Sub



    Private Sub btcAddProjectsMembers_Click(sender As Object, e As EventArgs) Handles btcAddProjectsMembers.Click

        Try

            ID_ProjectMember = 0

            Dim myForm As Form = frmProjectMemberDetails
            myForm.ShowDialog()
            myForm.Dispose()

            pDisplayProjectMembers()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btcModifyProjectsMembers_Click(sender As Object, e As EventArgs) Handles btcModifyProjectsMembers.Click

        Try

            Dim myForm As Form = frmProjectMemberDetails
            myForm.ShowDialog()
            myForm.Dispose()

            pDisplayProjectMembers()

        Catch ex As Exception

        End Try

    End Sub




    Private Sub btcAdminResource_Click(sender As Object, e As EventArgs) Handles btcAdminResource.Click

        Try

            Dim myForm As Form = frmResourceAdmin
            myForm.ShowDialog()
            myForm.Dispose()

        Catch ex As Exception

        End Try

    End Sub


    Private Sub btcTableResources_Click(sender As Object, e As EventArgs) Handles btcTableResources.Click

        Try

            Dim myForm As Form = frmTabResources
            Cursor.Current = Cursors.WaitCursor

            'Affiche la fenêtre en mode non-modal
            myForm.Show()

            'Affiche la fenêtre en mode modal
            'myForm.ShowDialog()
            'myForm.Dispose()
            Cursor.Current = Cursors.Default

        Catch ex As Exception
        End Try

    End Sub




    Private Sub btcStatistics_Click(sender As Object, e As EventArgs) Handles btcStatistics.Click

        Try

            Dim myForm As Form = frmStatistics
            myForm.ShowDialog()
            myForm.Dispose()

        Catch ex As Exception

        End Try

    End Sub
    Private Sub btcFilter_Click(sender As Object, e As EventArgs) Handles btcFilter.Click

        Try
            pFilterDGV()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub pFilterDGV()

        Try

            Dim ProjectDisplayedCount As Integer = 0

            'On lit le status
            Dim ID_Status As Integer = Val(DirectCast(lovFilterStatus.SelectedItem, KeyValuePair(Of String, String)).Key)
            Dim myStatus As New myStatus
            If ID_Status <> 0 Then
                myStatus.ID_Status = Val(ID_Status)
                myStatus.Read()
            End If

            'On lit la catégorie
            Dim ID_Category As Integer = Val(DirectCast(lovFilterCategory.SelectedItem, KeyValuePair(Of String, String)).Key)
            Dim myCategory As New myProjectCategory
            If ID_Category <> 0 Then
                myCategory.ID_Category = Val(ID_Category)
                myCategory.Read()
            End If


            Dim I = 0

            For I = 0 To dgvProjets.RowCount - 1

                Dim StrFound As Integer = 0
                Dim StatusFound As Integer = 0
                Dim CategoryFound As Integer = 0

                'On recherche le texte à filtrer dans les champs 0, 1 ou 3 (ID, titre, description)
                StrFound &= InStr(UCase(dgvProjets.Item(0, I).Value), UCase(Me.texFilter.Text))
                StrFound &= InStr(UCase(dgvProjets.Item(1, I).Value), UCase(Me.texFilter.Text))
                StrFound &= InStr(UCase(dgvProjets.Item(3, I).Value), UCase(Me.texFilter.Text))

                'On recherche le status
                StatusFound = InStr(dgvProjets.Item(4, I).Value, myStatus.Status)



                'On recherche la catégorie
                CategoryFound = InStr(dgvProjets.Item(2, I).Value, myCategory.Category)

                'On recherche la catégorie
                CategoryFound = InStr(dgvProjets.Item(2, I).Value, myCategory.Category)


                If StrFound > 0 And StatusFound > 0 And CategoryFound > 0 Then
                    dgvProjets.Rows(I).Visible = True
                    ProjectDisplayedCount = ProjectDisplayedCount + 1
                Else
                    dgvProjets.Rows(I).Visible = False
                End If

            Next I

            Me.labProjectsNumber.Text = "Projects : " & ProjectDisplayedCount & "/" & dgvProjets.RowCount

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btcFilterClear_Click(sender As Object, e As EventArgs) Handles btcFilterClear.Click

        Try

            Me.texFilter.Text = ""
            Me.lovFilterStatus.SelectedIndex = 0
            Me.lovFilterCategory.SelectedIndex = 0

            pFilterDGV()

        Catch ex As Exception

        End Try

    End Sub

    'Private Sub dgvProjets_ColumnWidthChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProjets.ColumnWidthChanged

    '    Try
    '        MessageBox.Show("resize")
    '    Catch ex As Exception
    '        If DebugFlag = True Then MessageBox.Show(ex.ToString)
    '    End Try

    'End Sub

    Private Sub btcResources_Click(sender As Object, e As EventArgs) Handles btcResources.Click

        Try

            Dim myForm As Form = frmResourceProject
            myForm.ShowDialog()
            myForm.Dispose()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btcGestion_Click(sender As Object, e As EventArgs) Handles btcGestion.Click

        Try

            Dim myForm As Form = frmManage
            myForm.ShowDialog()
            myForm.Dispose()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btcCustomers_Click(sender As Object, e As EventArgs) Handles btcCustomers.Click
        Try

            pDisplayGroup("Customers")

            'Affichage de tous les commanditaires
            pDisplayCustomers()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvCustomer_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCustomers.CellClick

        Try
            dgvCustomers.Rows(dgvCustomers.CurrentCell.RowIndex).Selected = True
            ID_Customer = dgvCustomers.Item(0, dgvCustomers.CurrentCell.RowIndex).Value
        Catch ex As Exception
        End Try

    End Sub

    Private Sub btcCustomerAdd_Click(sender As Object, e As EventArgs) Handles btcCustomerAdd.Click

        Try

            ID_Customer = 0

            Dim myForm As Form = frmProjectCustomer
            myForm.ShowDialog()
            myForm.Dispose()

            pDisplayCustomers()

        Catch ex As Exception
        End Try


    End Sub

    Private Sub btcCustomerModify_Click(sender As Object, e As EventArgs) Handles btcCustomerModify.Click

        Try

            Dim myForm As Form = frmProjectCustomer
            myForm.ShowDialog()
            myForm.Dispose()

            pDisplayCustomers()

        Catch ex As Exception
        End Try

    End Sub

    'Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

    '    Try
    '        Cursor.Current = Cursors.WaitCursor

    '        Dim mySQLDataReader As SqlDataReader
    '        Dim Sql As String = "SELECT ID_Resource FROM PlanResources;"
    '        Dim MySQLConnection As New SqlConnection

    '        Dim ID_Resource As Integer = 0

    '        MySQLConnection.ConnectionString = cnProjectPlan
    '        MySQLConnection.Open()

    '        Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)
    '        mySQLDataReader = mySQLCommand.ExecuteReader()

    '        While mySQLDataReader.Read

    '            Try
    '                ID_Resource = mySQLDataReader.GetValue(0)
    '            Catch ex As Exception
    '            End Try

    '            Dim myResource As New myPlanResource
    '            myResource.ID_Resource = ID_Resource
    '            myResource.Read()
    '            myResource.HalfDay = 1
    '            myResource.Save()
    '            myResource.ID_Resource = 0
    '            myResource.HalfDay = 2
    '            myResource.Save()

    '        End While

    '        mySQLDataReader.Close()
    '        MySQLConnection.Close()

    '        Cursor.Current = Cursors.Default

    '    Catch ex As Exception

    '    End Try

    'End Sub

    Private Sub pComputeEffectivesResources()

        Try

            Dim myProject As New myProject
            Dim mySQLDataReader As SqlDataReader
            Dim MySQLConnection As New SqlConnection
            Dim Sql As String = ""
            Dim Count As Integer = 0

            Sql = "SELECT DISTINCT CE_ID_Project FROM ExecutedResources;"

            MySQLConnection.ConnectionString = cnProjectPlan
            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)
            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read

                Try
                    myProject.ID_Project = mySQLDataReader.GetValue(0)
                    If myProject.ID_Project <> 0 Then
                        If myProject.ID_Project = 56 Then
                            Dim x As Integer = 0
                        End If
                        myProject.Read()
                        myProject.GetEffectiveResources()
                        myProject.ImplementationRate = myProject.EffectiveResources / myProject.EstimatedResources * 100
                        myProject.Save()
                    End If

                Catch ex As Exception
                End Try
            End While

            mySQLDataReader.Close()
            MySQLConnection.Close()

        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            Cursor.Current = Cursors.WaitCursor

            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT ID_Resource FROM ExecutedResources ORDER BY PlanDate asc;"
            Dim MySQLConnection As New SqlConnection

            Dim ID_Resource As Integer = 0

            MySQLConnection.ConnectionString = cnProjectPlan
            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)
            mySQLDataReader = mySQLCommand.ExecuteReader()

            Dim Counter As Integer = 0

            While mySQLDataReader.Read

                Try
                    ID_Resource = mySQLDataReader.GetValue(0)
                    Counter = Counter + 1
                Catch ex As Exception
                End Try

                Dim myResource As New myExecuteResource
                myResource.ID_Resource = ID_Resource
                myResource.Read()

                Dim SQL1 As String = ""
                SQL1 = "UPDATE ExecutedResources SET HalfDay=1 WHERE ID_Resource = " & ID_Resource

                Dim SQL2 As String = ""
                SQL2 = "INSERT INTO ExecutedResources "
                SQL2 &= "(ID_Resource, CE_ID_ProjectMember, CE_ID_Project, CE_ID_AdminResource, PlanDate, HalfDay, Timestamp) VALUES ("
                SQL2 &= CStr("100000" & CInt(myResource.ID_Resource)) & ","
                SQL2 &= myResource.CE_ID_ProjectMember & ","
                SQL2 &= myResource.CE_ID_Project & ","
                SQL2 &= myResource.CE_ID_AdminResource & ","
                SQL2 &= "'" & fConvertDateOnlySQL(myResource.PlanDate) & "',"
                SQL2 &= "2,"
                SQL2 &= "'" & fConvertDateOnlySQL(Now) & "')"


                Dim MySQL1Conn As New SqlConnection
                MySQL1Conn.ConnectionString = cnProjectPlan
                MySQL1Conn.Open()
                Dim mySQL1 As SqlCommand = New SqlCommand(SQL1, MySQL1Conn)
                mySQL1.ExecuteNonQuery()
                mySQL1 = Nothing
                MySQL1Conn.Close()
                Debug.Print("SQL1 : " & SQL1)

                Dim MySQL2Conn As New SqlConnection
                MySQL2Conn.ConnectionString = cnProjectPlan
                MySQL2Conn.Open()
                Dim mySQL2 As SqlCommand = New SqlCommand(SQL2, MySQL2Conn)
                mySQL2.ExecuteNonQuery()
                mySQL2 = Nothing
                MySQL2Conn.Close()
                Debug.Print("SQL2 : " & SQL2)

                Debug.Print("PlanDate : " & myResource.PlanDate & ", Counter : " & Counter)

            End While

            mySQLDataReader.Close()
            MySQLConnection.Close()

            Cursor.Current = Cursors.Default

            Debug.Print("Nombre de ligne : " & Counter)

        Catch ex As Exception

            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub btcTableResourcesExecuted_Click(sender As Object, e As EventArgs) Handles btcTableResourcesExecuted.Click

        Try

            Dim myForm As Form = frmAllResources
            Cursor.Current = Cursors.WaitCursor
            myForm.ShowDialog()
            myForm.Dispose()
            Cursor.Current = Cursors.Default

        Catch ex As Exception
        End Try
    End Sub

    Private Sub btcDuplicates_Click(sender As Object, e As EventArgs) Handles btcDuplicates.Click

        Try

            Dim thisRes As New myPlanResource
            Dim MinDate As Date = Nothing
            Dim MaxDate As Date = Nothing

            Dim ID_Member As Integer = 0
            Dim ID_ResourceMax As Integer = 0
            Dim HalfDay As Integer = 0

            Dim Count As Integer = 0


            thisRes.GetMinPlanDate()
            MinDate = thisRes.MinPlanDate

            thisRes.GetMaxPlanDate()
            MaxDate = thisRes.MaxPlanDate

            Dim _LoopDate As Date


            _LoopDate = MinDate

            Do Until _LoopDate > MaxDate
                For ID_Member = 1 To 9
                    For HalfDay = 1 To 2

                        Dim MySQLConnection As New SqlConnection
                        Dim mySQLDataReader As SqlDataReader
                        Dim Sql As String = "SELECT ID_Resource FROM PlanResources WHERE plandate = '" & fConvertDateTimeSQL(_LoopDate) & "' and CE_ID_ProjectMember=" & ID_Member & " and HalfDay=" & HalfDay & ";"

                        MySQLConnection.ConnectionString = cnProjectPlan
                        MySQLConnection.Open()

                        Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)
                        mySQLDataReader = mySQLCommand.ExecuteReader()

                        Dim Array_ID_Resource(0) As Integer

                        While mySQLDataReader.Read

                            Try
                                Dim ID_Resource As Integer = 0
                                ID_Resource = mySQLDataReader.GetValue(0)
                                If ID_ResourceMax < ID_Resource Then
                                    ID_ResourceMax = ID_Resource
                                End If
                                ReDim Preserve Array_ID_Resource(Array_ID_Resource.Length)
                                Array_ID_Resource(Array_ID_Resource.Length - 1) = ID_Resource
                                Count = Count + 1
                            Catch ex As Exception
                            End Try

                        End While

                        mySQLDataReader.Close()
                        MySQLConnection.Close()

                        If Count > 1 Then
                            Debug.Print("PlanDate : " & _LoopDate & ", CE_ID_ProjectMember : " & ID_Member & ", Halfday : " & HalfDay & ", Keep : " & ID_ResourceMax)
                            For Z = 1 To Array_ID_Resource.Length - 1
                                If Array_ID_Resource(Z) = ID_ResourceMax Then
                                    Debug.Print("on garde : " & Array_ID_Resource(Z))
                                Else
                                    Debug.Print("on efface : " & Array_ID_Resource(Z))
                                    Dim thisResource As New myPlanResource
                                    thisResource.ID_Resource = Array_ID_Resource(Z)
                                    thisResource.Delete()
                                End If
                            Next Z
                        End If


                        Count = 0
                        ID_ResourceMax = 0

                    Next HalfDay
                Next ID_Member

                _LoopDate = DateAdd(DateInterval.Day, 1, _LoopDate)

            Loop

        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Sub btcDashboard_Click(sender As Object, e As EventArgs) Handles btcDashboard.Click

        Try

            Dim myForm As Form = frmDashboard

            Me.Cursor = Cursors.WaitCursor

            'Affiche la fenêtre en mode non-modal
            myForm.Show()

            'Affiche la fenêtre en mode modal
            'myForm.ShowDialog()
            'myForm.Dispose()

            Me.Cursor = Cursors.Default

        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub chkAllProjects_CheckedChanged(sender As Object, e As EventArgs) Handles chkAllProjects.CheckedChanged
        Try
            'Affichage de tous les projets
            pDisplayProjects()
        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub dgvProjectsMembers_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProjectsMembers.CellDoubleClick


        dgvProjectsMembers.Rows(dgvProjectsMembers.CurrentCell.RowIndex).Selected = True
        ID_ProjectMember = dgvProjectsMembers.Item(0, dgvProjectsMembers.CurrentCell.RowIndex).Value

        Dim myForm As Form = frmProjectMemberDetails
        myForm.ShowDialog()
        myForm.Dispose()

        pDisplayProjectMembers()

    End Sub

    Private Sub CommanditairesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CommanditairesToolStripMenuItem.Click
        Try

            pDisplayGroup("Customers")

            'Affichage de tous les commanditaires
            pDisplayCustomers()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChefsDeProjetsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChefsDeProjetsToolStripMenuItem.Click
        Try

            pDisplayGroup("ProjectManagers")


            'Affichage de tous les chefs de projets
            pDisplayProjectManagers()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub MembresDeProjetsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MembresDeProjetsToolStripMenuItem.Click
        Try

            pDisplayGroup("ProjectsMembers")

            'Affichage de tous les membres de projets
            pDisplayProjectMembers()



        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListeToolStripMenuItem.Click
        Try

            pDisplayGroup("Projects")


            'Polulate des statuts
            pPopulateFilterStatus()

            'Polulate des categories
            pPopulateFilterCategory()

            'Affichage de tous les projets
            pDisplayProjects()



        Catch ex As Exception

            If DebugFlag = True Then MessageBox.Show(ex.ToString)

        End Try
    End Sub

    Private Sub TableauDesRessourcesPlanifiéesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TableauDesRessourcesPlanifiéesToolStripMenuItem.Click
        Try

            Dim myForm As Form = frmTabResources
            Cursor.Current = Cursors.WaitCursor

            'Affiche la fenêtre en mode non-modal
            myForm.Show()

            'Affiche la fenêtre en mode modal
            'myForm.ShowDialog()
            'myForm.Dispose()
            Cursor.Current = Cursors.Default

        Catch ex As Exception
        End Try
    End Sub

    Private Sub TableauDesRessourcesPlanifiéesEtExécutéesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TableauDesRessourcesPlanifiéesEtExécutéesToolStripMenuItem.Click
        Try

            Dim myForm As Form = frmAllResources
            Cursor.Current = Cursors.WaitCursor
            myForm.ShowDialog()
            myForm.Dispose()
            Cursor.Current = Cursors.Default

        Catch ex As Exception
        End Try
    End Sub

    Private Sub StatistiquesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StatistiquesToolStripMenuItem.Click
        Try

            Dim myForm As Form = frmStatistics
            myForm.ShowDialog()
            myForm.Dispose()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btcDisplayProjectResources_Click(sender As Object, e As EventArgs) Handles btcDisplayProjectResources.Click
        Try

            Dim myForm As Form = frmPlanProject
            myForm.ShowDialog()
            myForm.Dispose()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub VisualiserLesRessourcesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VisualiserLesRessourcesToolStripMenuItem.Click
        Try

            Dim myForm As Form = frmPlanProject
            myForm.ShowDialog()
            myForm.Dispose()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub AjoutDeTâchesAdministrativesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AjoutDeTâchesAdministrativesToolStripMenuItem.Click

        Try

            Dim myForm As Form = frmResourceAdmin
            myForm.ShowDialog()
            myForm.Dispose()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub AjoutDeRessourcesDeProjetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AjoutDeRessourcesDeProjetToolStripMenuItem.Click
        Try

            Dim myForm As Form = frmResourceProject
            myForm.ShowDialog()
            myForm.Dispose()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ValidationDesRessourcesEffectuéesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ValidationDesRessourcesEffectuéesToolStripMenuItem.Click
        Try

            Dim myForm As Form = frmManage
            myForm.ShowDialog()
            myForm.Dispose()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub RessourcesÀPlanifierToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RessourcesÀPlanifierToolStripMenuItem.Click
        Try

            Dim myForm As Form = frmDashboard

            Me.Cursor = Cursors.WaitCursor

            'Affiche la fenêtre en mode non-modal
            myForm.Show()

            'Affiche la fenêtre en mode modal
            'myForm.ShowDialog()
            'myForm.Dispose()

            Me.Cursor = Cursors.Default

        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub PlanificationDeLannéeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlanificationDeLannéeToolStripMenuItem.Click
        Try
            Dim myForm As Form = frmChart

            'Affiche la fenêtre en mode non-modal
            myForm.Show()

            'Affiche la fenêtre en mode modal
            'myForm.ShowDialog()
            'myForm.Dispose()

        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Sub QuitterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitterToolStripMenuItem.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AProposDeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AProposDeToolStripMenuItem.Click
        Try
            Dim myForm As Form = frmAbout
            myForm.ShowDialog()
            myForm.Dispose()
        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub ConnexionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConnexionToolStripMenuItem.Click
        Try
            Dim myForm As Form = frmSelectDB
            myForm.ShowDialog()
            myForm.Dispose()
        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try
    End Sub


End Class
