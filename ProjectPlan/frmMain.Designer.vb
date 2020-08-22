<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.BTCProjets = New System.Windows.Forms.Button()
        Me.btcProjectManager = New System.Windows.Forms.Button()
        Me.btcMembresProjets = New System.Windows.Forms.Button()
        Me.btcPlanificationRessources = New System.Windows.Forms.Button()
        Me.btcFermer = New System.Windows.Forms.Button()
        Me.grpProjects = New System.Windows.Forms.GroupBox()
        Me.chkAllProjects = New System.Windows.Forms.CheckBox()
        Me.labFilterCategory = New System.Windows.Forms.Label()
        Me.labFilterStatus = New System.Windows.Forms.Label()
        Me.LabFilterText = New System.Windows.Forms.Label()
        Me.labProjectsNumber = New System.Windows.Forms.Label()
        Me.lovFilterCategory = New System.Windows.Forms.ComboBox()
        Me.lovFilterStatus = New System.Windows.Forms.ComboBox()
        Me.btcFilterClear = New System.Windows.Forms.Button()
        Me.btcFilter = New System.Windows.Forms.Button()
        Me.labFilters = New System.Windows.Forms.Label()
        Me.texFilter = New System.Windows.Forms.TextBox()
        Me.btcModifyProject = New System.Windows.Forms.Button()
        Me.btcAddProject = New System.Windows.Forms.Button()
        Me.dgvProjets = New System.Windows.Forms.DataGridView()
        Me.grpProjectManager = New System.Windows.Forms.GroupBox()
        Me.btcModifyProjectManager = New System.Windows.Forms.Button()
        Me.btcAddProjectManager = New System.Windows.Forms.Button()
        Me.dgvProjectManager = New System.Windows.Forms.DataGridView()
        Me.grpProjectsMembers = New System.Windows.Forms.GroupBox()
        Me.btcModifyProjectsMembers = New System.Windows.Forms.Button()
        Me.btcAddProjectsMembers = New System.Windows.Forms.Button()
        Me.dgvProjectsMembers = New System.Windows.Forms.DataGridView()
        Me.grpResourcePlanning = New System.Windows.Forms.GroupBox()
        Me.grpVisualisation = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btcTableResourcesExecuted = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btcTableResources = New System.Windows.Forms.Button()
        Me.labDisplayProjectResources = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btcDisplayProjectResources = New System.Windows.Forms.Button()
        Me.btcStatistics = New System.Windows.Forms.Button()
        Me.grpAttribution = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btcAdminResource = New System.Windows.Forms.Button()
        Me.btcGestion = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btcResources = New System.Windows.Forms.Button()
        Me.btcCustomers = New System.Windows.Forms.Button()
        Me.grpCustomers = New System.Windows.Forms.GroupBox()
        Me.btcCustomerAdd = New System.Windows.Forms.Button()
        Me.btcCustomerModify = New System.Windows.Forms.Button()
        Me.dgvCustomers = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btcDuplicates = New System.Windows.Forms.Button()
        Me.btcDashboard = New System.Windows.Forms.Button()
        Me.myMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.ProjectPlanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BaseDeDonnéesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConnexionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuitterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PersonnesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CommanditairesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChefsDeProjetsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MembresDeProjetsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProjetsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlanificationDesRessourcesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TableauDesRessourcesPlanifiéesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TableauDesRessourcesPlanifiéesEtExécutéesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatistiquesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VisualiserLesRessourcesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.AjoutDeTâchesAdministrativesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AjoutDeRessourcesDeProjetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ValidationDesRessourcesEffectuéesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DashboardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RessourcesÀPlanifierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlanificationDeLannéeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AideToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AProposDeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.grpProjects.SuspendLayout()
        CType(Me.dgvProjets, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpProjectManager.SuspendLayout()
        CType(Me.dgvProjectManager, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpProjectsMembers.SuspendLayout()
        CType(Me.dgvProjectsMembers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpResourcePlanning.SuspendLayout()
        Me.grpVisualisation.SuspendLayout()
        Me.grpAttribution.SuspendLayout()
        Me.grpCustomers.SuspendLayout()
        CType(Me.dgvCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.myMenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'BTCProjets
        '
        Me.BTCProjets.Location = New System.Drawing.Point(31, 41)
        Me.BTCProjets.Name = "BTCProjets"
        Me.BTCProjets.Size = New System.Drawing.Size(152, 23)
        Me.BTCProjets.TabIndex = 0
        Me.BTCProjets.Text = "Projets"
        Me.BTCProjets.UseVisualStyleBackColor = True
        '
        'btcProjectManager
        '
        Me.btcProjectManager.Location = New System.Drawing.Point(347, 41)
        Me.btcProjectManager.Name = "btcProjectManager"
        Me.btcProjectManager.Size = New System.Drawing.Size(152, 23)
        Me.btcProjectManager.TabIndex = 1
        Me.btcProjectManager.Text = "Chefs de projets"
        Me.btcProjectManager.UseVisualStyleBackColor = True
        '
        'btcMembresProjets
        '
        Me.btcMembresProjets.Location = New System.Drawing.Point(505, 41)
        Me.btcMembresProjets.Name = "btcMembresProjets"
        Me.btcMembresProjets.Size = New System.Drawing.Size(152, 23)
        Me.btcMembresProjets.TabIndex = 2
        Me.btcMembresProjets.Text = "Membres de projets"
        Me.btcMembresProjets.UseVisualStyleBackColor = True
        '
        'btcPlanificationRessources
        '
        Me.btcPlanificationRessources.Location = New System.Drawing.Point(663, 41)
        Me.btcPlanificationRessources.Name = "btcPlanificationRessources"
        Me.btcPlanificationRessources.Size = New System.Drawing.Size(152, 23)
        Me.btcPlanificationRessources.TabIndex = 3
        Me.btcPlanificationRessources.Text = "Planification de ressources"
        Me.btcPlanificationRessources.UseVisualStyleBackColor = True
        '
        'btcFermer
        '
        Me.btcFermer.Location = New System.Drawing.Point(1080, 41)
        Me.btcFermer.Name = "btcFermer"
        Me.btcFermer.Size = New System.Drawing.Size(152, 23)
        Me.btcFermer.TabIndex = 4
        Me.btcFermer.Text = "Fermer"
        Me.btcFermer.UseVisualStyleBackColor = True
        '
        'grpProjects
        '
        Me.grpProjects.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpProjects.Controls.Add(Me.chkAllProjects)
        Me.grpProjects.Controls.Add(Me.labFilterCategory)
        Me.grpProjects.Controls.Add(Me.labFilterStatus)
        Me.grpProjects.Controls.Add(Me.LabFilterText)
        Me.grpProjects.Controls.Add(Me.labProjectsNumber)
        Me.grpProjects.Controls.Add(Me.lovFilterCategory)
        Me.grpProjects.Controls.Add(Me.lovFilterStatus)
        Me.grpProjects.Controls.Add(Me.btcFilterClear)
        Me.grpProjects.Controls.Add(Me.btcFilter)
        Me.grpProjects.Controls.Add(Me.labFilters)
        Me.grpProjects.Controls.Add(Me.texFilter)
        Me.grpProjects.Controls.Add(Me.btcModifyProject)
        Me.grpProjects.Controls.Add(Me.btcAddProject)
        Me.grpProjects.Controls.Add(Me.dgvProjets)
        Me.grpProjects.Location = New System.Drawing.Point(31, 93)
        Me.grpProjects.Name = "grpProjects"
        Me.grpProjects.Size = New System.Drawing.Size(1233, 491)
        Me.grpProjects.TabIndex = 5
        Me.grpProjects.TabStop = False
        Me.grpProjects.Text = "Projets"
        '
        'chkAllProjects
        '
        Me.chkAllProjects.AutoSize = True
        Me.chkAllProjects.Location = New System.Drawing.Point(678, 35)
        Me.chkAllProjects.Name = "chkAllProjects"
        Me.chkAllProjects.Size = New System.Drawing.Size(95, 17)
        Me.chkAllProjects.TabIndex = 19
        Me.chkAllProjects.Text = "Project inactifs"
        Me.chkAllProjects.UseVisualStyleBackColor = True
        '
        'labFilterCategory
        '
        Me.labFilterCategory.AutoSize = True
        Me.labFilterCategory.Location = New System.Drawing.Point(401, 14)
        Me.labFilterCategory.Name = "labFilterCategory"
        Me.labFilterCategory.Size = New System.Drawing.Size(52, 13)
        Me.labFilterCategory.TabIndex = 18
        Me.labFilterCategory.Text = "Catégorie"
        '
        'labFilterStatus
        '
        Me.labFilterStatus.AutoSize = True
        Me.labFilterStatus.Location = New System.Drawing.Point(275, 14)
        Me.labFilterStatus.Name = "labFilterStatus"
        Me.labFilterStatus.Size = New System.Drawing.Size(35, 13)
        Me.labFilterStatus.TabIndex = 17
        Me.labFilterStatus.Text = "Statut"
        '
        'LabFilterText
        '
        Me.LabFilterText.AutoSize = True
        Me.LabFilterText.Location = New System.Drawing.Point(87, 14)
        Me.LabFilterText.Name = "LabFilterText"
        Me.LabFilterText.Size = New System.Drawing.Size(34, 13)
        Me.LabFilterText.TabIndex = 16
        Me.LabFilterText.Text = "Texte"
        '
        'labProjectsNumber
        '
        Me.labProjectsNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.labProjectsNumber.Location = New System.Drawing.Point(941, 32)
        Me.labProjectsNumber.Name = "labProjectsNumber"
        Me.labProjectsNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.labProjectsNumber.Size = New System.Drawing.Size(118, 21)
        Me.labProjectsNumber.TabIndex = 15
        Me.labProjectsNumber.Text = "Projets : 10/10"
        Me.labProjectsNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lovFilterCategory
        '
        Me.lovFilterCategory.FormattingEnabled = True
        Me.lovFilterCategory.Location = New System.Drawing.Point(398, 32)
        Me.lovFilterCategory.Name = "lovFilterCategory"
        Me.lovFilterCategory.Size = New System.Drawing.Size(121, 21)
        Me.lovFilterCategory.TabIndex = 14
        '
        'lovFilterStatus
        '
        Me.lovFilterStatus.FormattingEnabled = True
        Me.lovFilterStatus.Location = New System.Drawing.Point(271, 32)
        Me.lovFilterStatus.Name = "lovFilterStatus"
        Me.lovFilterStatus.Size = New System.Drawing.Size(121, 21)
        Me.lovFilterStatus.TabIndex = 13
        '
        'btcFilterClear
        '
        Me.btcFilterClear.Image = CType(resources.GetObject("btcFilterClear.Image"), System.Drawing.Image)
        Me.btcFilterClear.Location = New System.Drawing.Point(617, 30)
        Me.btcFilterClear.Name = "btcFilterClear"
        Me.btcFilterClear.Size = New System.Drawing.Size(23, 23)
        Me.btcFilterClear.TabIndex = 12
        Me.btcFilterClear.UseVisualStyleBackColor = True
        '
        'btcFilter
        '
        Me.btcFilter.Location = New System.Drawing.Point(536, 30)
        Me.btcFilter.Name = "btcFilter"
        Me.btcFilter.Size = New System.Drawing.Size(75, 23)
        Me.btcFilter.TabIndex = 11
        Me.btcFilter.Text = "Filtre"
        Me.btcFilter.UseVisualStyleBackColor = True
        '
        'labFilters
        '
        Me.labFilters.AutoSize = True
        Me.labFilters.Location = New System.Drawing.Point(39, 35)
        Me.labFilters.Name = "labFilters"
        Me.labFilters.Size = New System.Drawing.Size(34, 13)
        Me.labFilters.TabIndex = 10
        Me.labFilters.Text = "Filtres"
        '
        'texFilter
        '
        Me.texFilter.Location = New System.Drawing.Point(84, 32)
        Me.texFilter.Name = "texFilter"
        Me.texFilter.Size = New System.Drawing.Size(180, 20)
        Me.texFilter.TabIndex = 9
        '
        'btcModifyProject
        '
        Me.btcModifyProject.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btcModifyProject.Location = New System.Drawing.Point(1094, 77)
        Me.btcModifyProject.Name = "btcModifyProject"
        Me.btcModifyProject.Size = New System.Drawing.Size(107, 23)
        Me.btcModifyProject.TabIndex = 8
        Me.btcModifyProject.Text = "Modifier"
        Me.btcModifyProject.UseVisualStyleBackColor = True
        '
        'btcAddProject
        '
        Me.btcAddProject.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btcAddProject.Location = New System.Drawing.Point(1094, 33)
        Me.btcAddProject.Name = "btcAddProject"
        Me.btcAddProject.Size = New System.Drawing.Size(107, 23)
        Me.btcAddProject.TabIndex = 7
        Me.btcAddProject.Text = "Ajouter"
        Me.btcAddProject.UseVisualStyleBackColor = True
        '
        'dgvProjets
        '
        Me.dgvProjets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvProjets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProjets.Location = New System.Drawing.Point(37, 62)
        Me.dgvProjets.Name = "dgvProjets"
        Me.dgvProjets.Size = New System.Drawing.Size(1022, 406)
        Me.dgvProjets.TabIndex = 5
        '
        'grpProjectManager
        '
        Me.grpProjectManager.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpProjectManager.Controls.Add(Me.btcModifyProjectManager)
        Me.grpProjectManager.Controls.Add(Me.btcAddProjectManager)
        Me.grpProjectManager.Controls.Add(Me.dgvProjectManager)
        Me.grpProjectManager.Location = New System.Drawing.Point(31, 93)
        Me.grpProjectManager.Name = "grpProjectManager"
        Me.grpProjectManager.Size = New System.Drawing.Size(1233, 491)
        Me.grpProjectManager.TabIndex = 11
        Me.grpProjectManager.TabStop = False
        Me.grpProjectManager.Text = "Chefs de projet"
        '
        'btcModifyProjectManager
        '
        Me.btcModifyProjectManager.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btcModifyProjectManager.Location = New System.Drawing.Point(1094, 77)
        Me.btcModifyProjectManager.Name = "btcModifyProjectManager"
        Me.btcModifyProjectManager.Size = New System.Drawing.Size(107, 23)
        Me.btcModifyProjectManager.TabIndex = 8
        Me.btcModifyProjectManager.Text = "Modifier"
        Me.btcModifyProjectManager.UseVisualStyleBackColor = True
        '
        'btcAddProjectManager
        '
        Me.btcAddProjectManager.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btcAddProjectManager.Location = New System.Drawing.Point(1094, 33)
        Me.btcAddProjectManager.Name = "btcAddProjectManager"
        Me.btcAddProjectManager.Size = New System.Drawing.Size(107, 23)
        Me.btcAddProjectManager.TabIndex = 7
        Me.btcAddProjectManager.Text = "Ajouter"
        Me.btcAddProjectManager.UseVisualStyleBackColor = True
        '
        'dgvProjectManager
        '
        Me.dgvProjectManager.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProjectManager.Location = New System.Drawing.Point(37, 33)
        Me.dgvProjectManager.Name = "dgvProjectManager"
        Me.dgvProjectManager.Size = New System.Drawing.Size(550, 440)
        Me.dgvProjectManager.TabIndex = 5
        '
        'grpProjectsMembers
        '
        Me.grpProjectsMembers.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpProjectsMembers.Controls.Add(Me.btcModifyProjectsMembers)
        Me.grpProjectsMembers.Controls.Add(Me.btcAddProjectsMembers)
        Me.grpProjectsMembers.Controls.Add(Me.dgvProjectsMembers)
        Me.grpProjectsMembers.Location = New System.Drawing.Point(31, 93)
        Me.grpProjectsMembers.Name = "grpProjectsMembers"
        Me.grpProjectsMembers.Size = New System.Drawing.Size(1233, 491)
        Me.grpProjectsMembers.TabIndex = 12
        Me.grpProjectsMembers.TabStop = False
        Me.grpProjectsMembers.Text = "Membres de projets"
        '
        'btcModifyProjectsMembers
        '
        Me.btcModifyProjectsMembers.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btcModifyProjectsMembers.Location = New System.Drawing.Point(1094, 77)
        Me.btcModifyProjectsMembers.Name = "btcModifyProjectsMembers"
        Me.btcModifyProjectsMembers.Size = New System.Drawing.Size(107, 23)
        Me.btcModifyProjectsMembers.TabIndex = 8
        Me.btcModifyProjectsMembers.Text = "Modifier"
        Me.btcModifyProjectsMembers.UseVisualStyleBackColor = True
        '
        'btcAddProjectsMembers
        '
        Me.btcAddProjectsMembers.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btcAddProjectsMembers.Location = New System.Drawing.Point(1094, 33)
        Me.btcAddProjectsMembers.Name = "btcAddProjectsMembers"
        Me.btcAddProjectsMembers.Size = New System.Drawing.Size(107, 23)
        Me.btcAddProjectsMembers.TabIndex = 7
        Me.btcAddProjectsMembers.Text = "Ajouter"
        Me.btcAddProjectsMembers.UseVisualStyleBackColor = True
        '
        'dgvProjectsMembers
        '
        Me.dgvProjectsMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProjectsMembers.Location = New System.Drawing.Point(37, 33)
        Me.dgvProjectsMembers.Name = "dgvProjectsMembers"
        Me.dgvProjectsMembers.Size = New System.Drawing.Size(550, 440)
        Me.dgvProjectsMembers.TabIndex = 5
        '
        'grpResourcePlanning
        '
        Me.grpResourcePlanning.Controls.Add(Me.grpVisualisation)
        Me.grpResourcePlanning.Controls.Add(Me.grpAttribution)
        Me.grpResourcePlanning.Location = New System.Drawing.Point(31, 93)
        Me.grpResourcePlanning.Name = "grpResourcePlanning"
        Me.grpResourcePlanning.Size = New System.Drawing.Size(1068, 485)
        Me.grpResourcePlanning.TabIndex = 14
        Me.grpResourcePlanning.TabStop = False
        Me.grpResourcePlanning.Text = "Planification des ressources"
        '
        'grpVisualisation
        '
        Me.grpVisualisation.Controls.Add(Me.Label6)
        Me.grpVisualisation.Controls.Add(Me.btcTableResourcesExecuted)
        Me.grpVisualisation.Controls.Add(Me.Label3)
        Me.grpVisualisation.Controls.Add(Me.btcTableResources)
        Me.grpVisualisation.Controls.Add(Me.labDisplayProjectResources)
        Me.grpVisualisation.Controls.Add(Me.Label4)
        Me.grpVisualisation.Controls.Add(Me.btcDisplayProjectResources)
        Me.grpVisualisation.Controls.Add(Me.btcStatistics)
        Me.grpVisualisation.Location = New System.Drawing.Point(195, 33)
        Me.grpVisualisation.Name = "grpVisualisation"
        Me.grpVisualisation.Size = New System.Drawing.Size(603, 201)
        Me.grpVisualisation.TabIndex = 28
        Me.grpVisualisation.TabStop = False
        Me.grpVisualisation.Text = "Visualisation"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(47, 76)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(237, 13)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "Affichage des ressources planifiées et exécutées"
        '
        'btcTableResourcesExecuted
        '
        Me.btcTableResourcesExecuted.Location = New System.Drawing.Point(437, 71)
        Me.btcTableResourcesExecuted.Name = "btcTableResourcesExecuted"
        Me.btcTableResourcesExecuted.Size = New System.Drawing.Size(75, 23)
        Me.btcTableResourcesExecuted.TabIndex = 28
        Me.btcTableResourcesExecuted.Text = "Tableau"
        Me.btcTableResourcesExecuted.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(47, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(173, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Affichage des ressources planifiées"
        '
        'btcTableResources
        '
        Me.btcTableResources.Location = New System.Drawing.Point(437, 29)
        Me.btcTableResources.Name = "btcTableResources"
        Me.btcTableResources.Size = New System.Drawing.Size(75, 23)
        Me.btcTableResources.TabIndex = 20
        Me.btcTableResources.Text = "Tableau"
        Me.btcTableResources.UseVisualStyleBackColor = True
        '
        'labDisplayProjectResources
        '
        Me.labDisplayProjectResources.AutoSize = True
        Me.labDisplayProjectResources.Location = New System.Drawing.Point(47, 153)
        Me.labDisplayProjectResources.Name = "labDisplayProjectResources"
        Me.labDisplayProjectResources.Size = New System.Drawing.Size(170, 13)
        Me.labDisplayProjectResources.TabIndex = 26
        Me.labDisplayProjectResources.Text = "Visualiser les ressources de projets"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(47, 115)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(262, 13)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Affichage de statistiques (jours libres ou attribués, etc.)"
        '
        'btcDisplayProjectResources
        '
        Me.btcDisplayProjectResources.Location = New System.Drawing.Point(437, 148)
        Me.btcDisplayProjectResources.Name = "btcDisplayProjectResources"
        Me.btcDisplayProjectResources.Size = New System.Drawing.Size(75, 23)
        Me.btcDisplayProjectResources.TabIndex = 25
        Me.btcDisplayProjectResources.Text = "Visualiser"
        Me.btcDisplayProjectResources.UseVisualStyleBackColor = True
        '
        'btcStatistics
        '
        Me.btcStatistics.Location = New System.Drawing.Point(437, 110)
        Me.btcStatistics.Name = "btcStatistics"
        Me.btcStatistics.Size = New System.Drawing.Size(75, 23)
        Me.btcStatistics.TabIndex = 22
        Me.btcStatistics.Text = "Statistiques"
        Me.btcStatistics.UseVisualStyleBackColor = True
        '
        'grpAttribution
        '
        Me.grpAttribution.Controls.Add(Me.Label1)
        Me.grpAttribution.Controls.Add(Me.btcAdminResource)
        Me.grpAttribution.Controls.Add(Me.btcGestion)
        Me.grpAttribution.Controls.Add(Me.Label5)
        Me.grpAttribution.Controls.Add(Me.Label2)
        Me.grpAttribution.Controls.Add(Me.btcResources)
        Me.grpAttribution.Location = New System.Drawing.Point(195, 240)
        Me.grpAttribution.Name = "grpAttribution"
        Me.grpAttribution.Size = New System.Drawing.Size(603, 160)
        Me.grpAttribution.TabIndex = 27
        Me.grpAttribution.TabStop = False
        Me.grpAttribution.Text = "Attribution"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(39, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(364, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Ajout de tâches administratives (séances, vacances, congé, formation, etc.)"
        '
        'btcAdminResource
        '
        Me.btcAdminResource.Location = New System.Drawing.Point(437, 28)
        Me.btcAdminResource.Name = "btcAdminResource"
        Me.btcAdminResource.Size = New System.Drawing.Size(75, 23)
        Me.btcAdminResource.TabIndex = 16
        Me.btcAdminResource.Text = "Admin"
        Me.btcAdminResource.UseVisualStyleBackColor = True
        '
        'btcGestion
        '
        Me.btcGestion.Location = New System.Drawing.Point(437, 104)
        Me.btcGestion.Name = "btcGestion"
        Me.btcGestion.Size = New System.Drawing.Size(75, 23)
        Me.btcGestion.TabIndex = 24
        Me.btcGestion.Text = "Gestion"
        Me.btcGestion.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(39, 109)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(159, 13)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Gestion des ressources passées"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(39, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(186, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Attribution de ressources à des projets"
        '
        'btcResources
        '
        Me.btcResources.Location = New System.Drawing.Point(437, 65)
        Me.btcResources.Name = "btcResources"
        Me.btcResources.Size = New System.Drawing.Size(75, 23)
        Me.btcResources.TabIndex = 18
        Me.btcResources.Text = "Ressources"
        Me.btcResources.UseVisualStyleBackColor = True
        '
        'btcCustomers
        '
        Me.btcCustomers.Location = New System.Drawing.Point(189, 41)
        Me.btcCustomers.Name = "btcCustomers"
        Me.btcCustomers.Size = New System.Drawing.Size(152, 23)
        Me.btcCustomers.TabIndex = 15
        Me.btcCustomers.Text = "Commanditaires"
        Me.btcCustomers.UseVisualStyleBackColor = True
        '
        'grpCustomers
        '
        Me.grpCustomers.Controls.Add(Me.btcCustomerAdd)
        Me.grpCustomers.Controls.Add(Me.btcCustomerModify)
        Me.grpCustomers.Controls.Add(Me.dgvCustomers)
        Me.grpCustomers.Location = New System.Drawing.Point(31, 93)
        Me.grpCustomers.Name = "grpCustomers"
        Me.grpCustomers.Size = New System.Drawing.Size(1233, 491)
        Me.grpCustomers.TabIndex = 16
        Me.grpCustomers.TabStop = False
        Me.grpCustomers.Text = "Commanditaires"
        '
        'btcCustomerAdd
        '
        Me.btcCustomerAdd.Location = New System.Drawing.Point(929, 33)
        Me.btcCustomerAdd.Name = "btcCustomerAdd"
        Me.btcCustomerAdd.Size = New System.Drawing.Size(107, 23)
        Me.btcCustomerAdd.TabIndex = 2
        Me.btcCustomerAdd.Text = "Ajouter"
        Me.btcCustomerAdd.UseVisualStyleBackColor = True
        '
        'btcCustomerModify
        '
        Me.btcCustomerModify.Location = New System.Drawing.Point(929, 77)
        Me.btcCustomerModify.Name = "btcCustomerModify"
        Me.btcCustomerModify.Size = New System.Drawing.Size(107, 23)
        Me.btcCustomerModify.TabIndex = 1
        Me.btcCustomerModify.Text = "Modifier"
        Me.btcCustomerModify.UseVisualStyleBackColor = True
        '
        'dgvCustomers
        '
        Me.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCustomers.Location = New System.Drawing.Point(37, 33)
        Me.dgvCustomers.Name = "dgvCustomers"
        Me.dgvCustomers.Size = New System.Drawing.Size(550, 440)
        Me.dgvCustomers.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(460, 622)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 17
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(226, 622)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(198, 23)
        Me.Button2.TabIndex = 18
        Me.Button2.Text = "Convert Executed Resources"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'btcDuplicates
        '
        Me.btcDuplicates.Location = New System.Drawing.Point(606, 622)
        Me.btcDuplicates.Name = "btcDuplicates"
        Me.btcDuplicates.Size = New System.Drawing.Size(152, 23)
        Me.btcDuplicates.TabIndex = 19
        Me.btcDuplicates.Text = "Duplicates"
        Me.btcDuplicates.UseVisualStyleBackColor = True
        Me.btcDuplicates.Visible = False
        '
        'btcDashboard
        '
        Me.btcDashboard.Location = New System.Drawing.Point(821, 41)
        Me.btcDashboard.Name = "btcDashboard"
        Me.btcDashboard.Size = New System.Drawing.Size(152, 23)
        Me.btcDashboard.TabIndex = 20
        Me.btcDashboard.Text = "Dashboard"
        Me.btcDashboard.UseVisualStyleBackColor = True
        '
        'myMenuStrip
        '
        Me.myMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProjectPlanToolStripMenuItem, Me.PersonnesToolStripMenuItem, Me.ProjetsToolStripMenuItem, Me.PlanificationDesRessourcesToolStripMenuItem, Me.DashboardToolStripMenuItem, Me.AideToolStripMenuItem})
        Me.myMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.myMenuStrip.Name = "myMenuStrip"
        Me.myMenuStrip.Size = New System.Drawing.Size(1283, 24)
        Me.myMenuStrip.TabIndex = 21
        Me.myMenuStrip.Text = "MenuStrip1"
        '
        'ProjectPlanToolStripMenuItem
        '
        Me.ProjectPlanToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BaseDeDonnéesToolStripMenuItem, Me.QuitterToolStripMenuItem})
        Me.ProjectPlanToolStripMenuItem.Name = "ProjectPlanToolStripMenuItem"
        Me.ProjectPlanToolStripMenuItem.Size = New System.Drawing.Size(82, 20)
        Me.ProjectPlanToolStripMenuItem.Text = "Programme"
        '
        'BaseDeDonnéesToolStripMenuItem
        '
        Me.BaseDeDonnéesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConnexionToolStripMenuItem})
        Me.BaseDeDonnéesToolStripMenuItem.Name = "BaseDeDonnéesToolStripMenuItem"
        Me.BaseDeDonnéesToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.BaseDeDonnéesToolStripMenuItem.Text = "Base de données"
        '
        'ConnexionToolStripMenuItem
        '
        Me.ConnexionToolStripMenuItem.Name = "ConnexionToolStripMenuItem"
        Me.ConnexionToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.ConnexionToolStripMenuItem.Text = "Connexion"
        '
        'QuitterToolStripMenuItem
        '
        Me.QuitterToolStripMenuItem.Name = "QuitterToolStripMenuItem"
        Me.QuitterToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.QuitterToolStripMenuItem.Text = "Quitter"
        '
        'PersonnesToolStripMenuItem
        '
        Me.PersonnesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CommanditairesToolStripMenuItem, Me.ChefsDeProjetsToolStripMenuItem, Me.MembresDeProjetsToolStripMenuItem})
        Me.PersonnesToolStripMenuItem.Name = "PersonnesToolStripMenuItem"
        Me.PersonnesToolStripMenuItem.Size = New System.Drawing.Size(73, 20)
        Me.PersonnesToolStripMenuItem.Text = "Personnes"
        '
        'CommanditairesToolStripMenuItem
        '
        Me.CommanditairesToolStripMenuItem.Name = "CommanditairesToolStripMenuItem"
        Me.CommanditairesToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.CommanditairesToolStripMenuItem.Text = "Commanditaires"
        '
        'ChefsDeProjetsToolStripMenuItem
        '
        Me.ChefsDeProjetsToolStripMenuItem.Name = "ChefsDeProjetsToolStripMenuItem"
        Me.ChefsDeProjetsToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.ChefsDeProjetsToolStripMenuItem.Text = "Chefs de projets"
        '
        'MembresDeProjetsToolStripMenuItem
        '
        Me.MembresDeProjetsToolStripMenuItem.Name = "MembresDeProjetsToolStripMenuItem"
        Me.MembresDeProjetsToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.MembresDeProjetsToolStripMenuItem.Text = "Membres de projets"
        '
        'ProjetsToolStripMenuItem
        '
        Me.ProjetsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ListeToolStripMenuItem})
        Me.ProjetsToolStripMenuItem.Name = "ProjetsToolStripMenuItem"
        Me.ProjetsToolStripMenuItem.Size = New System.Drawing.Size(55, 20)
        Me.ProjetsToolStripMenuItem.Text = "Projets"
        '
        'ListeToolStripMenuItem
        '
        Me.ListeToolStripMenuItem.Name = "ListeToolStripMenuItem"
        Me.ListeToolStripMenuItem.Size = New System.Drawing.Size(98, 22)
        Me.ListeToolStripMenuItem.Text = "Liste"
        '
        'PlanificationDesRessourcesToolStripMenuItem
        '
        Me.PlanificationDesRessourcesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TableauDesRessourcesPlanifiéesToolStripMenuItem, Me.TableauDesRessourcesPlanifiéesEtExécutéesToolStripMenuItem, Me.StatistiquesToolStripMenuItem, Me.VisualiserLesRessourcesToolStripMenuItem, Me.ToolStripSeparator1, Me.AjoutDeTâchesAdministrativesToolStripMenuItem, Me.AjoutDeRessourcesDeProjetToolStripMenuItem, Me.ValidationDesRessourcesEffectuéesToolStripMenuItem})
        Me.PlanificationDesRessourcesToolStripMenuItem.Name = "PlanificationDesRessourcesToolStripMenuItem"
        Me.PlanificationDesRessourcesToolStripMenuItem.Size = New System.Drawing.Size(164, 20)
        Me.PlanificationDesRessourcesToolStripMenuItem.Text = "Planification des ressources"
        '
        'TableauDesRessourcesPlanifiéesToolStripMenuItem
        '
        Me.TableauDesRessourcesPlanifiéesToolStripMenuItem.Name = "TableauDesRessourcesPlanifiéesToolStripMenuItem"
        Me.TableauDesRessourcesPlanifiéesToolStripMenuItem.Size = New System.Drawing.Size(314, 22)
        Me.TableauDesRessourcesPlanifiéesToolStripMenuItem.Text = "Tableau des ressources planifiées"
        '
        'TableauDesRessourcesPlanifiéesEtExécutéesToolStripMenuItem
        '
        Me.TableauDesRessourcesPlanifiéesEtExécutéesToolStripMenuItem.Name = "TableauDesRessourcesPlanifiéesEtExécutéesToolStripMenuItem"
        Me.TableauDesRessourcesPlanifiéesEtExécutéesToolStripMenuItem.Size = New System.Drawing.Size(314, 22)
        Me.TableauDesRessourcesPlanifiéesEtExécutéesToolStripMenuItem.Text = "Tableau des ressources planifiées et exécutées"
        '
        'StatistiquesToolStripMenuItem
        '
        Me.StatistiquesToolStripMenuItem.Name = "StatistiquesToolStripMenuItem"
        Me.StatistiquesToolStripMenuItem.Size = New System.Drawing.Size(314, 22)
        Me.StatistiquesToolStripMenuItem.Text = "Statistiques"
        '
        'VisualiserLesRessourcesToolStripMenuItem
        '
        Me.VisualiserLesRessourcesToolStripMenuItem.Name = "VisualiserLesRessourcesToolStripMenuItem"
        Me.VisualiserLesRessourcesToolStripMenuItem.Size = New System.Drawing.Size(314, 22)
        Me.VisualiserLesRessourcesToolStripMenuItem.Text = "Visualiser les ressources"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(311, 6)
        '
        'AjoutDeTâchesAdministrativesToolStripMenuItem
        '
        Me.AjoutDeTâchesAdministrativesToolStripMenuItem.Name = "AjoutDeTâchesAdministrativesToolStripMenuItem"
        Me.AjoutDeTâchesAdministrativesToolStripMenuItem.Size = New System.Drawing.Size(314, 22)
        Me.AjoutDeTâchesAdministrativesToolStripMenuItem.Text = "Ajout de tâches administratives"
        '
        'AjoutDeRessourcesDeProjetToolStripMenuItem
        '
        Me.AjoutDeRessourcesDeProjetToolStripMenuItem.Name = "AjoutDeRessourcesDeProjetToolStripMenuItem"
        Me.AjoutDeRessourcesDeProjetToolStripMenuItem.Size = New System.Drawing.Size(314, 22)
        Me.AjoutDeRessourcesDeProjetToolStripMenuItem.Text = "Ajout de ressources de projet"
        '
        'ValidationDesRessourcesEffectuéesToolStripMenuItem
        '
        Me.ValidationDesRessourcesEffectuéesToolStripMenuItem.Name = "ValidationDesRessourcesEffectuéesToolStripMenuItem"
        Me.ValidationDesRessourcesEffectuéesToolStripMenuItem.Size = New System.Drawing.Size(314, 22)
        Me.ValidationDesRessourcesEffectuéesToolStripMenuItem.Text = "Validation des ressources effectuées"
        '
        'DashboardToolStripMenuItem
        '
        Me.DashboardToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RessourcesÀPlanifierToolStripMenuItem, Me.PlanificationDeLannéeToolStripMenuItem})
        Me.DashboardToolStripMenuItem.Name = "DashboardToolStripMenuItem"
        Me.DashboardToolStripMenuItem.Size = New System.Drawing.Size(76, 20)
        Me.DashboardToolStripMenuItem.Text = "Dashboard"
        '
        'RessourcesÀPlanifierToolStripMenuItem
        '
        Me.RessourcesÀPlanifierToolStripMenuItem.Name = "RessourcesÀPlanifierToolStripMenuItem"
        Me.RessourcesÀPlanifierToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.RessourcesÀPlanifierToolStripMenuItem.Text = "Ressources à planifier"
        '
        'PlanificationDeLannéeToolStripMenuItem
        '
        Me.PlanificationDeLannéeToolStripMenuItem.Name = "PlanificationDeLannéeToolStripMenuItem"
        Me.PlanificationDeLannéeToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.PlanificationDeLannéeToolStripMenuItem.Text = "Planification de l'année"
        '
        'AideToolStripMenuItem
        '
        Me.AideToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AProposDeToolStripMenuItem})
        Me.AideToolStripMenuItem.Name = "AideToolStripMenuItem"
        Me.AideToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.AideToolStripMenuItem.Text = "Aide"
        '
        'AProposDeToolStripMenuItem
        '
        Me.AProposDeToolStripMenuItem.Name = "AProposDeToolStripMenuItem"
        Me.AProposDeToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.AProposDeToolStripMenuItem.Text = "A propos de"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1283, 686)
        Me.Controls.Add(Me.grpProjects)
        Me.Controls.Add(Me.grpProjectsMembers)
        Me.Controls.Add(Me.grpResourcePlanning)
        Me.Controls.Add(Me.grpProjectManager)
        Me.Controls.Add(Me.grpCustomers)
        Me.Controls.Add(Me.btcDashboard)
        Me.Controls.Add(Me.btcDuplicates)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btcCustomers)
        Me.Controls.Add(Me.btcFermer)
        Me.Controls.Add(Me.btcPlanificationRessources)
        Me.Controls.Add(Me.btcMembresProjets)
        Me.Controls.Add(Me.btcProjectManager)
        Me.Controls.Add(Me.BTCProjets)
        Me.Controls.Add(Me.myMenuStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.myMenuStrip
        Me.Name = "frmMain"
        Me.Text = "Project Plan"
        Me.grpProjects.ResumeLayout(False)
        Me.grpProjects.PerformLayout()
        CType(Me.dgvProjets, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpProjectManager.ResumeLayout(False)
        CType(Me.dgvProjectManager, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpProjectsMembers.ResumeLayout(False)
        CType(Me.dgvProjectsMembers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpResourcePlanning.ResumeLayout(False)
        Me.grpVisualisation.ResumeLayout(False)
        Me.grpVisualisation.PerformLayout()
        Me.grpAttribution.ResumeLayout(False)
        Me.grpAttribution.PerformLayout()
        Me.grpCustomers.ResumeLayout(False)
        CType(Me.dgvCustomers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.myMenuStrip.ResumeLayout(False)
        Me.myMenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BTCProjets As Button
    Friend WithEvents btcProjectManager As Button
    Friend WithEvents btcMembresProjets As Button
    Friend WithEvents btcPlanificationRessources As Button
    Friend WithEvents btcFermer As Button
    Friend WithEvents grpProjects As GroupBox
    Friend WithEvents btcModifyProject As Button
    Friend WithEvents btcAddProject As Button
    Friend WithEvents dgvProjets As DataGridView
    Friend WithEvents grpProjectManager As GroupBox
    Friend WithEvents btcModifyProjectManager As Button
    Friend WithEvents btcAddProjectManager As Button
    Friend WithEvents dgvProjectManager As DataGridView
    Friend WithEvents grpProjectsMembers As GroupBox
    Friend WithEvents btcModifyProjectsMembers As Button
    Friend WithEvents btcAddProjectsMembers As Button
    Friend WithEvents dgvProjectsMembers As DataGridView
    Friend WithEvents grpResourcePlanning As GroupBox
    Friend WithEvents btcResources As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents btcAdminResource As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents btcTableResources As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents btcGestion As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents btcStatistics As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents btcFilter As Button
    Friend WithEvents labFilters As Label
    Friend WithEvents texFilter As TextBox
    Friend WithEvents btcFilterClear As Button
    Friend WithEvents lovFilterStatus As ComboBox
    Friend WithEvents btcCustomers As Button
    Friend WithEvents grpCustomers As GroupBox
    Friend WithEvents dgvCustomers As DataGridView
    Friend WithEvents btcCustomerAdd As Button
    Friend WithEvents btcCustomerModify As Button
    Friend WithEvents lovFilterCategory As ComboBox
    Friend WithEvents labProjectsNumber As Label
    Friend WithEvents labFilterCategory As Label
    Friend WithEvents labFilterStatus As Label
    Friend WithEvents LabFilterText As Label
    Friend WithEvents labDisplayProjectResources As Label
    Friend WithEvents btcDisplayProjectResources As Button
    Friend WithEvents grpVisualisation As GroupBox
    Friend WithEvents grpAttribution As GroupBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents btcTableResourcesExecuted As Button
    Friend WithEvents btcDuplicates As Button
    Friend WithEvents btcDashboard As Button
    Friend WithEvents chkAllProjects As CheckBox
    Friend WithEvents myMenuStrip As MenuStrip
    Friend WithEvents ProjectPlanToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PersonnesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CommanditairesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChefsDeProjetsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MembresDeProjetsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BaseDeDonnéesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConnexionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AideToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AProposDeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProjetsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ListeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PlanificationDesRessourcesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TableauDesRessourcesPlanifiéesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TableauDesRessourcesPlanifiéesEtExécutéesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatistiquesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VisualiserLesRessourcesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents AjoutDeTâchesAdministrativesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AjoutDeRessourcesDeProjetToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ValidationDesRessourcesEffectuéesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DashboardToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RessourcesÀPlanifierToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PlanificationDeLannéeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents QuitterToolStripMenuItem As ToolStripMenuItem
End Class
