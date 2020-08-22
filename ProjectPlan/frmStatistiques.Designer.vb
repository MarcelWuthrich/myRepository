<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStatistics
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStatistics))
        Me.btcClose = New System.Windows.Forms.Button()
        Me.lstMembers = New System.Windows.Forms.ListBox()
        Me.labProjectMember = New System.Windows.Forms.Label()
        Me.texProjectMember = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.texStatProjects1Month = New System.Windows.Forms.TextBox()
        Me.texStatFree1Month = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.texStatAdmin1Month = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lab1mois = New System.Windows.Forms.Label()
        Me.lab3mois = New System.Windows.Forms.Label()
        Me.texStatAdmin3Month = New System.Windows.Forms.TextBox()
        Me.texStatFree3Month = New System.Windows.Forms.TextBox()
        Me.texStatProjects3Month = New System.Windows.Forms.TextBox()
        Me.lab6mois = New System.Windows.Forms.Label()
        Me.texStatAdmin6Month = New System.Windows.Forms.TextBox()
        Me.texStatFree6Month = New System.Windows.Forms.TextBox()
        Me.texStatProjects6Month = New System.Windows.Forms.TextBox()
        Me.lab12mois = New System.Windows.Forms.Label()
        Me.texStatAdmin12Month = New System.Windows.Forms.TextBox()
        Me.texStatFree12Month = New System.Windows.Forms.TextBox()
        Me.texStatProjects12Month = New System.Windows.Forms.TextBox()
        Me.tabStatistics = New System.Windows.Forms.TabControl()
        Me.tabProjectMember = New System.Windows.Forms.TabPage()
        Me.labEndYear = New System.Windows.Forms.Label()
        Me.texStatAdminEndYear = New System.Windows.Forms.TextBox()
        Me.texStatFreeEndYear = New System.Windows.Forms.TextBox()
        Me.texStatProjectsEndYear = New System.Windows.Forms.TextBox()
        Me.labProjects = New System.Windows.Forms.Label()
        Me.labAdminTasks = New System.Windows.Forms.Label()
        Me.texAdminTasks = New System.Windows.Forms.TextBox()
        Me.texProjects = New System.Windows.Forms.TextBox()
        Me.tabProjects = New System.Windows.Forms.TabPage()
        Me.texEffectivePlusEstimatedResources = New System.Windows.Forms.TextBox()
        Me.labEffectivePlusEstimatedResources = New System.Windows.Forms.Label()
        Me.texEffectiveResources = New System.Windows.Forms.TextBox()
        Me.labEffectiveResources = New System.Windows.Forms.Label()
        Me.texProjectDaysEffectivePlaned = New System.Windows.Forms.TextBox()
        Me.labProjectDaysEffectivePlaned = New System.Windows.Forms.Label()
        Me.lstProjectMembers = New System.Windows.Forms.ListBox()
        Me.texProjectRate = New System.Windows.Forms.TextBox()
        Me.labProjectRate = New System.Windows.Forms.Label()
        Me.texProjectDaysInitialPlaned = New System.Windows.Forms.TextBox()
        Me.labProjectDaysInitialPlaned = New System.Windows.Forms.Label()
        Me.texProjectDeadline = New System.Windows.Forms.TextBox()
        Me.labProjectDeadline = New System.Windows.Forms.Label()
        Me.texProjectDescription = New System.Windows.Forms.TextBox()
        Me.lstProjects = New System.Windows.Forms.ListBox()
        Me.tabStatistics.SuspendLayout()
        Me.tabProjectMember.SuspendLayout()
        Me.tabProjects.SuspendLayout()
        Me.SuspendLayout()
        '
        'btcClose
        '
        Me.btcClose.Location = New System.Drawing.Point(344, 552)
        Me.btcClose.Name = "btcClose"
        Me.btcClose.Size = New System.Drawing.Size(75, 23)
        Me.btcClose.TabIndex = 0
        Me.btcClose.Text = "&Fermer"
        Me.btcClose.UseVisualStyleBackColor = True
        '
        'lstMembers
        '
        Me.lstMembers.FormattingEnabled = True
        Me.lstMembers.Location = New System.Drawing.Point(40, 31)
        Me.lstMembers.Name = "lstMembers"
        Me.lstMembers.Size = New System.Drawing.Size(208, 134)
        Me.lstMembers.Sorted = True
        Me.lstMembers.TabIndex = 1
        '
        'labProjectMember
        '
        Me.labProjectMember.AutoSize = True
        Me.labProjectMember.Location = New System.Drawing.Point(313, 34)
        Me.labProjectMember.Name = "labProjectMember"
        Me.labProjectMember.Size = New System.Drawing.Size(94, 13)
        Me.labProjectMember.TabIndex = 2
        Me.labProjectMember.Text = "Membre de projets"
        '
        'texProjectMember
        '
        Me.texProjectMember.Location = New System.Drawing.Point(510, 31)
        Me.texProjectMember.Name = "texProjectMember"
        Me.texProjectMember.ReadOnly = True
        Me.texProjectMember.Size = New System.Drawing.Size(262, 20)
        Me.texProjectMember.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(313, 103)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(148, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Nbre de jours pour des projets"
        '
        'texStatProjects1Month
        '
        Me.texStatProjects1Month.Location = New System.Drawing.Point(508, 100)
        Me.texStatProjects1Month.Name = "texStatProjects1Month"
        Me.texStatProjects1Month.ReadOnly = True
        Me.texStatProjects1Month.Size = New System.Drawing.Size(48, 20)
        Me.texStatProjects1Month.TabIndex = 5
        Me.texStatProjects1Month.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'texStatFree1Month
        '
        Me.texStatFree1Month.Location = New System.Drawing.Point(508, 152)
        Me.texStatFree1Month.Name = "texStatFree1Month"
        Me.texStatFree1Month.ReadOnly = True
        Me.texStatFree1Month.Size = New System.Drawing.Size(48, 20)
        Me.texStatFree1Month.TabIndex = 7
        Me.texStatFree1Month.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(313, 155)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Nombre de jours libres"
        '
        'texStatAdmin1Month
        '
        Me.texStatAdmin1Month.Location = New System.Drawing.Point(508, 126)
        Me.texStatAdmin1Month.Name = "texStatAdmin1Month"
        Me.texStatAdmin1Month.ReadOnly = True
        Me.texStatAdmin1Month.Size = New System.Drawing.Size(48, 20)
        Me.texStatAdmin1Month.TabIndex = 9
        Me.texStatAdmin1Month.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(313, 129)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(133, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Nbre de jours administratifs"
        '
        'lab1mois
        '
        Me.lab1mois.AutoSize = True
        Me.lab1mois.Location = New System.Drawing.Point(513, 84)
        Me.lab1mois.Name = "lab1mois"
        Me.lab1mois.Size = New System.Drawing.Size(37, 13)
        Me.lab1mois.TabIndex = 10
        Me.lab1mois.Text = "1 mois"
        '
        'lab3mois
        '
        Me.lab3mois.AutoSize = True
        Me.lab3mois.Location = New System.Drawing.Point(567, 84)
        Me.lab3mois.Name = "lab3mois"
        Me.lab3mois.Size = New System.Drawing.Size(37, 13)
        Me.lab3mois.TabIndex = 14
        Me.lab3mois.Text = "3 mois"
        '
        'texStatAdmin3Month
        '
        Me.texStatAdmin3Month.Location = New System.Drawing.Point(562, 126)
        Me.texStatAdmin3Month.Name = "texStatAdmin3Month"
        Me.texStatAdmin3Month.ReadOnly = True
        Me.texStatAdmin3Month.Size = New System.Drawing.Size(48, 20)
        Me.texStatAdmin3Month.TabIndex = 13
        Me.texStatAdmin3Month.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'texStatFree3Month
        '
        Me.texStatFree3Month.Location = New System.Drawing.Point(562, 152)
        Me.texStatFree3Month.Name = "texStatFree3Month"
        Me.texStatFree3Month.ReadOnly = True
        Me.texStatFree3Month.Size = New System.Drawing.Size(48, 20)
        Me.texStatFree3Month.TabIndex = 12
        Me.texStatFree3Month.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'texStatProjects3Month
        '
        Me.texStatProjects3Month.Location = New System.Drawing.Point(562, 100)
        Me.texStatProjects3Month.Name = "texStatProjects3Month"
        Me.texStatProjects3Month.ReadOnly = True
        Me.texStatProjects3Month.Size = New System.Drawing.Size(48, 20)
        Me.texStatProjects3Month.TabIndex = 11
        Me.texStatProjects3Month.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lab6mois
        '
        Me.lab6mois.AutoSize = True
        Me.lab6mois.Location = New System.Drawing.Point(621, 84)
        Me.lab6mois.Name = "lab6mois"
        Me.lab6mois.Size = New System.Drawing.Size(37, 13)
        Me.lab6mois.TabIndex = 18
        Me.lab6mois.Text = "6 mois"
        '
        'texStatAdmin6Month
        '
        Me.texStatAdmin6Month.Location = New System.Drawing.Point(616, 126)
        Me.texStatAdmin6Month.Name = "texStatAdmin6Month"
        Me.texStatAdmin6Month.ReadOnly = True
        Me.texStatAdmin6Month.Size = New System.Drawing.Size(48, 20)
        Me.texStatAdmin6Month.TabIndex = 17
        Me.texStatAdmin6Month.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'texStatFree6Month
        '
        Me.texStatFree6Month.Location = New System.Drawing.Point(616, 152)
        Me.texStatFree6Month.Name = "texStatFree6Month"
        Me.texStatFree6Month.ReadOnly = True
        Me.texStatFree6Month.Size = New System.Drawing.Size(48, 20)
        Me.texStatFree6Month.TabIndex = 16
        Me.texStatFree6Month.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'texStatProjects6Month
        '
        Me.texStatProjects6Month.Location = New System.Drawing.Point(616, 100)
        Me.texStatProjects6Month.Name = "texStatProjects6Month"
        Me.texStatProjects6Month.ReadOnly = True
        Me.texStatProjects6Month.Size = New System.Drawing.Size(48, 20)
        Me.texStatProjects6Month.TabIndex = 15
        Me.texStatProjects6Month.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lab12mois
        '
        Me.lab12mois.AutoSize = True
        Me.lab12mois.Location = New System.Drawing.Point(672, 84)
        Me.lab12mois.Name = "lab12mois"
        Me.lab12mois.Size = New System.Drawing.Size(43, 13)
        Me.lab12mois.TabIndex = 22
        Me.lab12mois.Text = "12 mois"
        '
        'texStatAdmin12Month
        '
        Me.texStatAdmin12Month.Location = New System.Drawing.Point(670, 126)
        Me.texStatAdmin12Month.Name = "texStatAdmin12Month"
        Me.texStatAdmin12Month.ReadOnly = True
        Me.texStatAdmin12Month.Size = New System.Drawing.Size(48, 20)
        Me.texStatAdmin12Month.TabIndex = 21
        Me.texStatAdmin12Month.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'texStatFree12Month
        '
        Me.texStatFree12Month.Location = New System.Drawing.Point(670, 152)
        Me.texStatFree12Month.Name = "texStatFree12Month"
        Me.texStatFree12Month.ReadOnly = True
        Me.texStatFree12Month.Size = New System.Drawing.Size(48, 20)
        Me.texStatFree12Month.TabIndex = 20
        Me.texStatFree12Month.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'texStatProjects12Month
        '
        Me.texStatProjects12Month.Location = New System.Drawing.Point(670, 100)
        Me.texStatProjects12Month.Name = "texStatProjects12Month"
        Me.texStatProjects12Month.ReadOnly = True
        Me.texStatProjects12Month.Size = New System.Drawing.Size(48, 20)
        Me.texStatProjects12Month.TabIndex = 19
        Me.texStatProjects12Month.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tabStatistics
        '
        Me.tabStatistics.Controls.Add(Me.tabProjectMember)
        Me.tabStatistics.Controls.Add(Me.tabProjects)
        Me.tabStatistics.Location = New System.Drawing.Point(23, 27)
        Me.tabStatistics.Name = "tabStatistics"
        Me.tabStatistics.SelectedIndex = 0
        Me.tabStatistics.Size = New System.Drawing.Size(812, 494)
        Me.tabStatistics.TabIndex = 24
        '
        'tabProjectMember
        '
        Me.tabProjectMember.BackColor = System.Drawing.SystemColors.Control
        Me.tabProjectMember.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tabProjectMember.Controls.Add(Me.labEndYear)
        Me.tabProjectMember.Controls.Add(Me.texStatAdminEndYear)
        Me.tabProjectMember.Controls.Add(Me.texStatFreeEndYear)
        Me.tabProjectMember.Controls.Add(Me.texStatProjectsEndYear)
        Me.tabProjectMember.Controls.Add(Me.labProjects)
        Me.tabProjectMember.Controls.Add(Me.labAdminTasks)
        Me.tabProjectMember.Controls.Add(Me.texAdminTasks)
        Me.tabProjectMember.Controls.Add(Me.texProjects)
        Me.tabProjectMember.Controls.Add(Me.lstMembers)
        Me.tabProjectMember.Controls.Add(Me.texStatFree3Month)
        Me.tabProjectMember.Controls.Add(Me.lab12mois)
        Me.tabProjectMember.Controls.Add(Me.texStatProjects3Month)
        Me.tabProjectMember.Controls.Add(Me.labProjectMember)
        Me.tabProjectMember.Controls.Add(Me.texStatAdmin3Month)
        Me.tabProjectMember.Controls.Add(Me.texStatAdmin12Month)
        Me.tabProjectMember.Controls.Add(Me.lab1mois)
        Me.tabProjectMember.Controls.Add(Me.texProjectMember)
        Me.tabProjectMember.Controls.Add(Me.lab3mois)
        Me.tabProjectMember.Controls.Add(Me.texStatFree12Month)
        Me.tabProjectMember.Controls.Add(Me.texStatAdmin1Month)
        Me.tabProjectMember.Controls.Add(Me.Label1)
        Me.tabProjectMember.Controls.Add(Me.texStatProjects6Month)
        Me.tabProjectMember.Controls.Add(Me.texStatProjects12Month)
        Me.tabProjectMember.Controls.Add(Me.Label3)
        Me.tabProjectMember.Controls.Add(Me.texStatProjects1Month)
        Me.tabProjectMember.Controls.Add(Me.texStatFree6Month)
        Me.tabProjectMember.Controls.Add(Me.lab6mois)
        Me.tabProjectMember.Controls.Add(Me.texStatFree1Month)
        Me.tabProjectMember.Controls.Add(Me.Label2)
        Me.tabProjectMember.Controls.Add(Me.texStatAdmin6Month)
        Me.tabProjectMember.Location = New System.Drawing.Point(4, 22)
        Me.tabProjectMember.Name = "tabProjectMember"
        Me.tabProjectMember.Padding = New System.Windows.Forms.Padding(3)
        Me.tabProjectMember.Size = New System.Drawing.Size(804, 468)
        Me.tabProjectMember.TabIndex = 0
        Me.tabProjectMember.Text = "Membres de projets"
        '
        'labEndYear
        '
        Me.labEndYear.AutoSize = True
        Me.labEndYear.Location = New System.Drawing.Point(723, 84)
        Me.labEndYear.Name = "labEndYear"
        Me.labEndYear.Size = New System.Drawing.Size(49, 13)
        Me.labEndYear.TabIndex = 30
        Me.labEndYear.Text = "End year"
        '
        'texStatAdminEndYear
        '
        Me.texStatAdminEndYear.Location = New System.Drawing.Point(724, 126)
        Me.texStatAdminEndYear.Name = "texStatAdminEndYear"
        Me.texStatAdminEndYear.ReadOnly = True
        Me.texStatAdminEndYear.Size = New System.Drawing.Size(48, 20)
        Me.texStatAdminEndYear.TabIndex = 29
        Me.texStatAdminEndYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'texStatFreeEndYear
        '
        Me.texStatFreeEndYear.Location = New System.Drawing.Point(724, 152)
        Me.texStatFreeEndYear.Name = "texStatFreeEndYear"
        Me.texStatFreeEndYear.ReadOnly = True
        Me.texStatFreeEndYear.Size = New System.Drawing.Size(48, 20)
        Me.texStatFreeEndYear.TabIndex = 28
        Me.texStatFreeEndYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'texStatProjectsEndYear
        '
        Me.texStatProjectsEndYear.Location = New System.Drawing.Point(724, 100)
        Me.texStatProjectsEndYear.Name = "texStatProjectsEndYear"
        Me.texStatProjectsEndYear.ReadOnly = True
        Me.texStatProjectsEndYear.Size = New System.Drawing.Size(48, 20)
        Me.texStatProjectsEndYear.TabIndex = 27
        Me.texStatProjectsEndYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'labProjects
        '
        Me.labProjects.AutoSize = True
        Me.labProjects.Location = New System.Drawing.Point(37, 232)
        Me.labProjects.Name = "labProjects"
        Me.labProjects.Size = New System.Drawing.Size(187, 13)
        Me.labProjects.TabIndex = 26
        Me.labProjects.Text = "Nombre de jour planifiés sur les projets"
        '
        'labAdminTasks
        '
        Me.labAdminTasks.AutoSize = True
        Me.labAdminTasks.Location = New System.Drawing.Point(420, 232)
        Me.labAdminTasks.Name = "labAdminTasks"
        Me.labAdminTasks.Size = New System.Drawing.Size(115, 13)
        Me.labAdminTasks.TabIndex = 25
        Me.labAdminTasks.Text = "Tâches administratives"
        '
        'texAdminTasks
        '
        Me.texAdminTasks.Location = New System.Drawing.Point(420, 267)
        Me.texAdminTasks.Multiline = True
        Me.texAdminTasks.Name = "texAdminTasks"
        Me.texAdminTasks.ReadOnly = True
        Me.texAdminTasks.Size = New System.Drawing.Size(352, 149)
        Me.texAdminTasks.TabIndex = 24
        '
        'texProjects
        '
        Me.texProjects.Location = New System.Drawing.Point(40, 267)
        Me.texProjects.Multiline = True
        Me.texProjects.Name = "texProjects"
        Me.texProjects.ReadOnly = True
        Me.texProjects.Size = New System.Drawing.Size(352, 149)
        Me.texProjects.TabIndex = 23
        '
        'tabProjects
        '
        Me.tabProjects.BackColor = System.Drawing.SystemColors.Control
        Me.tabProjects.Controls.Add(Me.texEffectivePlusEstimatedResources)
        Me.tabProjects.Controls.Add(Me.labEffectivePlusEstimatedResources)
        Me.tabProjects.Controls.Add(Me.texEffectiveResources)
        Me.tabProjects.Controls.Add(Me.labEffectiveResources)
        Me.tabProjects.Controls.Add(Me.texProjectDaysEffectivePlaned)
        Me.tabProjects.Controls.Add(Me.labProjectDaysEffectivePlaned)
        Me.tabProjects.Controls.Add(Me.lstProjectMembers)
        Me.tabProjects.Controls.Add(Me.texProjectRate)
        Me.tabProjects.Controls.Add(Me.labProjectRate)
        Me.tabProjects.Controls.Add(Me.texProjectDaysInitialPlaned)
        Me.tabProjects.Controls.Add(Me.labProjectDaysInitialPlaned)
        Me.tabProjects.Controls.Add(Me.texProjectDeadline)
        Me.tabProjects.Controls.Add(Me.labProjectDeadline)
        Me.tabProjects.Controls.Add(Me.texProjectDescription)
        Me.tabProjects.Controls.Add(Me.lstProjects)
        Me.tabProjects.Location = New System.Drawing.Point(4, 22)
        Me.tabProjects.Name = "tabProjects"
        Me.tabProjects.Padding = New System.Windows.Forms.Padding(3)
        Me.tabProjects.Size = New System.Drawing.Size(804, 468)
        Me.tabProjects.TabIndex = 1
        Me.tabProjects.Text = "Projects"
        '
        'texEffectivePlusEstimatedResources
        '
        Me.texEffectivePlusEstimatedResources.Location = New System.Drawing.Point(682, 182)
        Me.texEffectivePlusEstimatedResources.Name = "texEffectivePlusEstimatedResources"
        Me.texEffectivePlusEstimatedResources.ReadOnly = True
        Me.texEffectivePlusEstimatedResources.Size = New System.Drawing.Size(100, 20)
        Me.texEffectivePlusEstimatedResources.TabIndex = 17
        '
        'labEffectivePlusEstimatedResources
        '
        Me.labEffectivePlusEstimatedResources.AutoSize = True
        Me.labEffectivePlusEstimatedResources.Location = New System.Drawing.Point(547, 185)
        Me.labEffectivePlusEstimatedResources.Name = "labEffectivePlusEstimatedResources"
        Me.labEffectivePlusEstimatedResources.Size = New System.Drawing.Size(129, 13)
        Me.labEffectivePlusEstimatedResources.TabIndex = 16
        Me.labEffectivePlusEstimatedResources.Text = "Jours planifiés et travaillés"
        '
        'texEffectiveResources
        '
        Me.texEffectiveResources.Location = New System.Drawing.Point(148, 234)
        Me.texEffectiveResources.Name = "texEffectiveResources"
        Me.texEffectiveResources.ReadOnly = True
        Me.texEffectiveResources.Size = New System.Drawing.Size(100, 20)
        Me.texEffectiveResources.TabIndex = 15
        '
        'labEffectiveResources
        '
        Me.labEffectiveResources.AutoSize = True
        Me.labEffectiveResources.Location = New System.Drawing.Point(61, 237)
        Me.labEffectiveResources.Name = "labEffectiveResources"
        Me.labEffectiveResources.Size = New System.Drawing.Size(76, 13)
        Me.labEffectiveResources.TabIndex = 14
        Me.labEffectiveResources.Text = "Jours travaillés"
        '
        'texProjectDaysEffectivePlaned
        '
        Me.texProjectDaysEffectivePlaned.Location = New System.Drawing.Point(357, 182)
        Me.texProjectDaysEffectivePlaned.Name = "texProjectDaysEffectivePlaned"
        Me.texProjectDaysEffectivePlaned.ReadOnly = True
        Me.texProjectDaysEffectivePlaned.Size = New System.Drawing.Size(100, 20)
        Me.texProjectDaysEffectivePlaned.TabIndex = 13
        '
        'labProjectDaysEffectivePlaned
        '
        Me.labProjectDaysEffectivePlaned.AutoSize = True
        Me.labProjectDaysEffectivePlaned.Location = New System.Drawing.Point(267, 185)
        Me.labProjectDaysEffectivePlaned.Name = "labProjectDaysEffectivePlaned"
        Me.labProjectDaysEffectivePlaned.Size = New System.Drawing.Size(73, 13)
        Me.labProjectDaysEffectivePlaned.TabIndex = 12
        Me.labProjectDaysEffectivePlaned.Text = "Jours planifiés"
        '
        'lstProjectMembers
        '
        Me.lstProjectMembers.FormattingEnabled = True
        Me.lstProjectMembers.Location = New System.Drawing.Point(267, 208)
        Me.lstProjectMembers.Name = "lstProjectMembers"
        Me.lstProjectMembers.Size = New System.Drawing.Size(515, 82)
        Me.lstProjectMembers.TabIndex = 11
        '
        'texProjectRate
        '
        Me.texProjectRate.Location = New System.Drawing.Point(148, 260)
        Me.texProjectRate.Name = "texProjectRate"
        Me.texProjectRate.ReadOnly = True
        Me.texProjectRate.Size = New System.Drawing.Size(100, 20)
        Me.texProjectRate.TabIndex = 9
        '
        'labProjectRate
        '
        Me.labProjectRate.AutoSize = True
        Me.labProjectRate.Location = New System.Drawing.Point(61, 263)
        Me.labProjectRate.Name = "labProjectRate"
        Me.labProjectRate.Size = New System.Drawing.Size(81, 13)
        Me.labProjectRate.TabIndex = 8
        Me.labProjectRate.Text = "Taux réalisation"
        '
        'texProjectDaysInitialPlaned
        '
        Me.texProjectDaysInitialPlaned.Location = New System.Drawing.Point(148, 208)
        Me.texProjectDaysInitialPlaned.Name = "texProjectDaysInitialPlaned"
        Me.texProjectDaysInitialPlaned.ReadOnly = True
        Me.texProjectDaysInitialPlaned.Size = New System.Drawing.Size(100, 20)
        Me.texProjectDaysInitialPlaned.TabIndex = 7
        '
        'labProjectDaysInitialPlaned
        '
        Me.labProjectDaysInitialPlaned.AutoSize = True
        Me.labProjectDaysInitialPlaned.Location = New System.Drawing.Point(14, 211)
        Me.labProjectDaysInitialPlaned.Name = "labProjectDaysInitialPlaned"
        Me.labProjectDaysInitialPlaned.Size = New System.Drawing.Size(122, 13)
        Me.labProjectDaysInitialPlaned.TabIndex = 6
        Me.labProjectDaysInitialPlaned.Text = "Jours initialement prévus"
        '
        'texProjectDeadline
        '
        Me.texProjectDeadline.Location = New System.Drawing.Point(148, 182)
        Me.texProjectDeadline.Name = "texProjectDeadline"
        Me.texProjectDeadline.ReadOnly = True
        Me.texProjectDeadline.Size = New System.Drawing.Size(100, 20)
        Me.texProjectDeadline.TabIndex = 5
        '
        'labProjectDeadline
        '
        Me.labProjectDeadline.AutoSize = True
        Me.labProjectDeadline.Location = New System.Drawing.Point(93, 185)
        Me.labProjectDeadline.Name = "labProjectDeadline"
        Me.labProjectDeadline.Size = New System.Drawing.Size(49, 13)
        Me.labProjectDeadline.TabIndex = 4
        Me.labProjectDeadline.Text = "Deadline"
        '
        'texProjectDescription
        '
        Me.texProjectDescription.Location = New System.Drawing.Point(267, 31)
        Me.texProjectDescription.Multiline = True
        Me.texProjectDescription.Name = "texProjectDescription"
        Me.texProjectDescription.ReadOnly = True
        Me.texProjectDescription.Size = New System.Drawing.Size(515, 134)
        Me.texProjectDescription.TabIndex = 3
        '
        'lstProjects
        '
        Me.lstProjects.FormattingEnabled = True
        Me.lstProjects.Location = New System.Drawing.Point(40, 31)
        Me.lstProjects.Name = "lstProjects"
        Me.lstProjects.Size = New System.Drawing.Size(208, 134)
        Me.lstProjects.Sorted = True
        Me.lstProjects.TabIndex = 2
        '
        'frmStatistics
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(917, 609)
        Me.Controls.Add(Me.tabStatistics)
        Me.Controls.Add(Me.btcClose)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmStatistics"
        Me.Text = "Statistiques"
        Me.tabStatistics.ResumeLayout(False)
        Me.tabProjectMember.ResumeLayout(False)
        Me.tabProjectMember.PerformLayout()
        Me.tabProjects.ResumeLayout(False)
        Me.tabProjects.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btcClose As Button
    Friend WithEvents lstMembers As ListBox
    Friend WithEvents labProjectMember As Label
    Friend WithEvents texProjectMember As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents texStatProjects1Month As TextBox
    Friend WithEvents texStatFree1Month As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents texStatAdmin1Month As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents lab1mois As Label
    Friend WithEvents lab3mois As Label
    Friend WithEvents texStatAdmin3Month As TextBox
    Friend WithEvents texStatFree3Month As TextBox
    Friend WithEvents texStatProjects3Month As TextBox
    Friend WithEvents lab6mois As Label
    Friend WithEvents texStatAdmin6Month As TextBox
    Friend WithEvents texStatFree6Month As TextBox
    Friend WithEvents texStatProjects6Month As TextBox
    Friend WithEvents lab12mois As Label
    Friend WithEvents texStatAdmin12Month As TextBox
    Friend WithEvents texStatFree12Month As TextBox
    Friend WithEvents texStatProjects12Month As TextBox
    Friend WithEvents tabStatistics As TabControl
    Friend WithEvents tabProjectMember As TabPage
    Friend WithEvents tabProjects As TabPage
    Friend WithEvents labProjects As Label
    Friend WithEvents labAdminTasks As Label
    Friend WithEvents texAdminTasks As TextBox
    Friend WithEvents texProjects As TextBox
    Friend WithEvents lstProjects As ListBox
    Friend WithEvents texProjectDescription As TextBox
    Friend WithEvents texProjectDaysInitialPlaned As TextBox
    Friend WithEvents labProjectDaysInitialPlaned As Label
    Friend WithEvents texProjectDeadline As TextBox
    Friend WithEvents labProjectDeadline As Label
    Friend WithEvents texProjectRate As TextBox
    Friend WithEvents labProjectRate As Label
    Friend WithEvents lstProjectMembers As ListBox
    Friend WithEvents texProjectDaysEffectivePlaned As TextBox
    Friend WithEvents labProjectDaysEffectivePlaned As Label
    Friend WithEvents texEffectiveResources As TextBox
    Friend WithEvents labEffectiveResources As Label
    Friend WithEvents texEffectivePlusEstimatedResources As TextBox
    Friend WithEvents labEffectivePlusEstimatedResources As Label
    Friend WithEvents labEndYear As Label
    Friend WithEvents texStatAdminEndYear As TextBox
    Friend WithEvents texStatFreeEndYear As TextBox
    Friend WithEvents texStatProjectsEndYear As TextBox
End Class
