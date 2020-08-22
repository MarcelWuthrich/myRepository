<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmProjectDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProjectDetails))
        Me.texTitre = New System.Windows.Forms.TextBox()
        Me.labTitre = New System.Windows.Forms.Label()
        Me.labCategorie = New System.Windows.Forms.Label()
        Me.labDescription = New System.Windows.Forms.Label()
        Me.texDescription = New System.Windows.Forms.TextBox()
        Me.labDeadline = New System.Windows.Forms.Label()
        Me.dtpDeadline = New System.Windows.Forms.DateTimePicker()
        Me.lovProjectManager = New System.Windows.Forms.ComboBox()
        Me.labChefProjet = New System.Windows.Forms.Label()
        Me.labStatut = New System.Windows.Forms.Label()
        Me.lovStatus = New System.Windows.Forms.ComboBox()
        Me.btcAnnuler = New System.Windows.Forms.Button()
        Me.btcOK = New System.Windows.Forms.Button()
        Me.labEstimateResources = New System.Windows.Forms.Label()
        Me.texEstimatedResources = New System.Windows.Forms.TextBox()
        Me.labImplementationRate = New System.Windows.Forms.Label()
        Me.texImplementationRate = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.labID_Project = New System.Windows.Forms.Label()
        Me.texID_Project = New System.Windows.Forms.TextBox()
        Me.lovPriority = New System.Windows.Forms.ComboBox()
        Me.labPriority = New System.Windows.Forms.Label()
        Me.lovProjectCategory = New System.Windows.Forms.ComboBox()
        Me.labClient = New System.Windows.Forms.Label()
        Me.lovCustomer = New System.Windows.Forms.ComboBox()
        Me.texPlanResources = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.labPlanResources = New System.Windows.Forms.Label()
        Me.labExecutedResources = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.texExecutedResources = New System.Windows.Forms.TextBox()
        Me.btcComments = New System.Windows.Forms.Button()
        Me.lovUrgency = New System.Windows.Forms.ComboBox()
        Me.labUrgency = New System.Windows.Forms.Label()
        Me.dtpBegin = New System.Windows.Forms.DateTimePicker()
        Me.labBegin = New System.Windows.Forms.Label()
        Me.labEstimateResourcesInfra = New System.Windows.Forms.Label()
        Me.texEstimatedResourcesInfra = New System.Windows.Forms.TextBox()
        Me.labEstimateResourcesSAP = New System.Windows.Forms.Label()
        Me.texEstimatedResourcesSAP = New System.Windows.Forms.TextBox()
        Me.labEstimateResourcesHelpdesk = New System.Windows.Forms.Label()
        Me.texEstimatedResourcesHelpdesk = New System.Windows.Forms.TextBox()
        Me.labEstimateResourcesPlaning = New System.Windows.Forms.Label()
        Me.texEstimatedResourcesPlaning = New System.Windows.Forms.TextBox()
        Me.grpResourcesEstimated = New System.Windows.Forms.GroupBox()
        Me.texITBoard = New System.Windows.Forms.TextBox()
        Me.labTextForITBoard = New System.Windows.Forms.Label()
        Me.labRemarks = New System.Windows.Forms.Label()
        Me.dgvProjectRemarks = New System.Windows.Forms.DataGridView()
        Me.btcRemarkAdd = New System.Windows.Forms.Button()
        Me.btcRemarkRemove = New System.Windows.Forms.Button()
        Me.btcRemardModify = New System.Windows.Forms.Button()
        Me.grpResourcesEstimated.SuspendLayout()
        CType(Me.dgvProjectRemarks, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'texTitre
        '
        Me.texTitre.Location = New System.Drawing.Point(164, 49)
        Me.texTitre.Name = "texTitre"
        Me.texTitre.Size = New System.Drawing.Size(647, 20)
        Me.texTitre.TabIndex = 1
        '
        'labTitre
        '
        Me.labTitre.AutoSize = True
        Me.labTitre.Location = New System.Drawing.Point(130, 52)
        Me.labTitre.Name = "labTitre"
        Me.labTitre.Size = New System.Drawing.Size(28, 13)
        Me.labTitre.TabIndex = 1
        Me.labTitre.Text = "Titre"
        '
        'labCategorie
        '
        Me.labCategorie.AutoSize = True
        Me.labCategorie.Location = New System.Drawing.Point(106, 241)
        Me.labCategorie.Name = "labCategorie"
        Me.labCategorie.Size = New System.Drawing.Size(52, 13)
        Me.labCategorie.TabIndex = 3
        Me.labCategorie.Text = "Categorie"
        '
        'labDescription
        '
        Me.labDescription.AutoSize = True
        Me.labDescription.Location = New System.Drawing.Point(98, 78)
        Me.labDescription.Name = "labDescription"
        Me.labDescription.Size = New System.Drawing.Size(60, 13)
        Me.labDescription.TabIndex = 5
        Me.labDescription.Text = "Description"
        '
        'texDescription
        '
        Me.texDescription.Location = New System.Drawing.Point(164, 75)
        Me.texDescription.Multiline = True
        Me.texDescription.Name = "texDescription"
        Me.texDescription.Size = New System.Drawing.Size(647, 103)
        Me.texDescription.TabIndex = 8
        '
        'labDeadline
        '
        Me.labDeadline.AutoSize = True
        Me.labDeadline.Location = New System.Drawing.Point(105, 294)
        Me.labDeadline.Name = "labDeadline"
        Me.labDeadline.Size = New System.Drawing.Size(53, 13)
        Me.labDeadline.TabIndex = 7
        Me.labDeadline.Text = "DeadLine"
        '
        'dtpDeadline
        '
        Me.dtpDeadline.Location = New System.Drawing.Point(164, 291)
        Me.dtpDeadline.Name = "dtpDeadline"
        Me.dtpDeadline.Size = New System.Drawing.Size(200, 20)
        Me.dtpDeadline.TabIndex = 5
        '
        'lovProjectManager
        '
        Me.lovProjectManager.FormattingEnabled = True
        Me.lovProjectManager.Location = New System.Drawing.Point(164, 211)
        Me.lovProjectManager.Name = "lovProjectManager"
        Me.lovProjectManager.Size = New System.Drawing.Size(200, 21)
        Me.lovProjectManager.Sorted = True
        Me.lovProjectManager.TabIndex = 3
        '
        'labChefProjet
        '
        Me.labChefProjet.AutoSize = True
        Me.labChefProjet.Location = New System.Drawing.Point(85, 214)
        Me.labChefProjet.Name = "labChefProjet"
        Me.labChefProjet.Size = New System.Drawing.Size(73, 13)
        Me.labChefProjet.TabIndex = 10
        Me.labChefProjet.Text = "Chef de projet"
        '
        'labStatut
        '
        Me.labStatut.AutoSize = True
        Me.labStatut.Location = New System.Drawing.Point(570, 187)
        Me.labStatut.Name = "labStatut"
        Me.labStatut.Size = New System.Drawing.Size(35, 13)
        Me.labStatut.TabIndex = 11
        Me.labStatut.Text = "Statut"
        '
        'lovStatus
        '
        Me.lovStatus.FormattingEnabled = True
        Me.lovStatus.Items.AddRange(New Object() {"1 ; sijfiej", "2 ; ifjwijfe"})
        Me.lovStatus.Location = New System.Drawing.Point(611, 184)
        Me.lovStatus.Name = "lovStatus"
        Me.lovStatus.Size = New System.Drawing.Size(200, 21)
        Me.lovStatus.TabIndex = 4
        '
        'btcAnnuler
        '
        Me.btcAnnuler.Location = New System.Drawing.Point(166, 424)
        Me.btcAnnuler.Name = "btcAnnuler"
        Me.btcAnnuler.Size = New System.Drawing.Size(75, 23)
        Me.btcAnnuler.TabIndex = 9
        Me.btcAnnuler.Text = "Annuler"
        Me.btcAnnuler.UseVisualStyleBackColor = True
        '
        'btcOK
        '
        Me.btcOK.Location = New System.Drawing.Point(278, 424)
        Me.btcOK.Name = "btcOK"
        Me.btcOK.Size = New System.Drawing.Size(75, 23)
        Me.btcOK.TabIndex = 10
        Me.btcOK.Text = "OK"
        Me.btcOK.UseVisualStyleBackColor = True
        '
        'labEstimateResources
        '
        Me.labEstimateResources.AutoSize = True
        Me.labEstimateResources.Location = New System.Drawing.Point(11, 130)
        Me.labEstimateResources.Name = "labEstimateResources"
        Me.labEstimateResources.Size = New System.Drawing.Size(31, 13)
        Me.labEstimateResources.TabIndex = 16
        Me.labEstimateResources.Text = "Total"
        '
        'texEstimatedResources
        '
        Me.texEstimatedResources.Location = New System.Drawing.Point(124, 127)
        Me.texEstimatedResources.Name = "texEstimatedResources"
        Me.texEstimatedResources.ReadOnly = True
        Me.texEstimatedResources.Size = New System.Drawing.Size(58, 20)
        Me.texEstimatedResources.TabIndex = 6
        '
        'labImplementationRate
        '
        Me.labImplementationRate.AutoSize = True
        Me.labImplementationRate.Location = New System.Drawing.Point(62, 372)
        Me.labImplementationRate.Name = "labImplementationRate"
        Me.labImplementationRate.Size = New System.Drawing.Size(96, 13)
        Me.labImplementationRate.TabIndex = 18
        Me.labImplementationRate.Text = "Taux de réalisation"
        '
        'texImplementationRate
        '
        Me.texImplementationRate.Location = New System.Drawing.Point(164, 369)
        Me.texImplementationRate.Name = "texImplementationRate"
        Me.texImplementationRate.ReadOnly = True
        Me.texImplementationRate.Size = New System.Drawing.Size(100, 20)
        Me.texImplementationRate.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(270, 372)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 13)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "( % )"
        '
        'labID_Project
        '
        Me.labID_Project.AutoSize = True
        Me.labID_Project.Location = New System.Drawing.Point(140, 26)
        Me.labID_Project.Name = "labID_Project"
        Me.labID_Project.Size = New System.Drawing.Size(18, 13)
        Me.labID_Project.TabIndex = 39
        Me.labID_Project.Text = "ID"
        '
        'texID_Project
        '
        Me.texID_Project.Location = New System.Drawing.Point(164, 23)
        Me.texID_Project.Name = "texID_Project"
        Me.texID_Project.ReadOnly = True
        Me.texID_Project.Size = New System.Drawing.Size(121, 20)
        Me.texID_Project.TabIndex = 38
        '
        'lovPriority
        '
        Me.lovPriority.FormattingEnabled = True
        Me.lovPriority.Location = New System.Drawing.Point(611, 211)
        Me.lovPriority.Name = "lovPriority"
        Me.lovPriority.Size = New System.Drawing.Size(200, 21)
        Me.lovPriority.TabIndex = 40
        '
        'labPriority
        '
        Me.labPriority.AutoSize = True
        Me.labPriority.Location = New System.Drawing.Point(566, 214)
        Me.labPriority.Name = "labPriority"
        Me.labPriority.Size = New System.Drawing.Size(39, 13)
        Me.labPriority.TabIndex = 41
        Me.labPriority.Text = "Priorité"
        '
        'lovProjectCategory
        '
        Me.lovProjectCategory.FormattingEnabled = True
        Me.lovProjectCategory.Location = New System.Drawing.Point(164, 238)
        Me.lovProjectCategory.Name = "lovProjectCategory"
        Me.lovProjectCategory.Size = New System.Drawing.Size(200, 21)
        Me.lovProjectCategory.TabIndex = 42
        '
        'labClient
        '
        Me.labClient.AutoSize = True
        Me.labClient.Location = New System.Drawing.Point(82, 187)
        Me.labClient.Name = "labClient"
        Me.labClient.Size = New System.Drawing.Size(76, 13)
        Me.labClient.TabIndex = 44
        Me.labClient.Text = "Commanditaire"
        '
        'lovCustomer
        '
        Me.lovCustomer.FormattingEnabled = True
        Me.lovCustomer.Location = New System.Drawing.Point(164, 184)
        Me.lovCustomer.Name = "lovCustomer"
        Me.lovCustomer.Size = New System.Drawing.Size(200, 21)
        Me.lovCustomer.Sorted = True
        Me.lovCustomer.TabIndex = 43
        '
        'texPlanResources
        '
        Me.texPlanResources.Location = New System.Drawing.Point(164, 343)
        Me.texPlanResources.Name = "texPlanResources"
        Me.texPlanResources.ReadOnly = True
        Me.texPlanResources.Size = New System.Drawing.Size(100, 20)
        Me.texPlanResources.TabIndex = 45
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(270, 346)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 13)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "( nombre de jours )"
        '
        'labPlanResources
        '
        Me.labPlanResources.AutoSize = True
        Me.labPlanResources.Location = New System.Drawing.Point(48, 346)
        Me.labPlanResources.Name = "labPlanResources"
        Me.labPlanResources.Size = New System.Drawing.Size(110, 13)
        Me.labPlanResources.TabIndex = 47
        Me.labPlanResources.Text = "Ressources planifiées"
        '
        'labExecutedResources
        '
        Me.labExecutedResources.AutoSize = True
        Me.labExecutedResources.Location = New System.Drawing.Point(48, 320)
        Me.labExecutedResources.Name = "labExecutedResources"
        Me.labExecutedResources.Size = New System.Drawing.Size(107, 13)
        Me.labExecutedResources.TabIndex = 50
        Me.labExecutedResources.Text = "Ressources réalisées"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(270, 320)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 13)
        Me.Label6.TabIndex = 49
        Me.Label6.Text = "( nombre de jours )"
        '
        'texExecutedResources
        '
        Me.texExecutedResources.Location = New System.Drawing.Point(164, 317)
        Me.texExecutedResources.Name = "texExecutedResources"
        Me.texExecutedResources.ReadOnly = True
        Me.texExecutedResources.Size = New System.Drawing.Size(100, 20)
        Me.texExecutedResources.TabIndex = 48
        '
        'btcComments
        '
        Me.btcComments.Location = New System.Drawing.Point(392, 424)
        Me.btcComments.Name = "btcComments"
        Me.btcComments.Size = New System.Drawing.Size(81, 23)
        Me.btcComments.TabIndex = 51
        Me.btcComments.Text = "Commentaires"
        Me.btcComments.UseVisualStyleBackColor = True
        Me.btcComments.Visible = False
        '
        'lovUrgency
        '
        Me.lovUrgency.FormattingEnabled = True
        Me.lovUrgency.Location = New System.Drawing.Point(611, 238)
        Me.lovUrgency.Name = "lovUrgency"
        Me.lovUrgency.Size = New System.Drawing.Size(200, 21)
        Me.lovUrgency.TabIndex = 52
        '
        'labUrgency
        '
        Me.labUrgency.AutoSize = True
        Me.labUrgency.Location = New System.Drawing.Point(557, 241)
        Me.labUrgency.Name = "labUrgency"
        Me.labUrgency.Size = New System.Drawing.Size(48, 13)
        Me.labUrgency.TabIndex = 53
        Me.labUrgency.Text = "Urgence"
        '
        'dtpBegin
        '
        Me.dtpBegin.Location = New System.Drawing.Point(164, 265)
        Me.dtpBegin.Name = "dtpBegin"
        Me.dtpBegin.Size = New System.Drawing.Size(200, 20)
        Me.dtpBegin.TabIndex = 54
        '
        'labBegin
        '
        Me.labBegin.AutoSize = True
        Me.labBegin.Location = New System.Drawing.Point(105, 268)
        Me.labBegin.Name = "labBegin"
        Me.labBegin.Size = New System.Drawing.Size(36, 13)
        Me.labBegin.TabIndex = 55
        Me.labBegin.Text = "Début"
        '
        'labEstimateResourcesInfra
        '
        Me.labEstimateResourcesInfra.AutoSize = True
        Me.labEstimateResourcesInfra.Location = New System.Drawing.Point(11, 26)
        Me.labEstimateResourcesInfra.Name = "labEstimateResourcesInfra"
        Me.labEstimateResourcesInfra.Size = New System.Drawing.Size(69, 13)
        Me.labEstimateResourcesInfra.TabIndex = 60
        Me.labEstimateResourcesInfra.Text = "Infrastructure"
        '
        'texEstimatedResourcesInfra
        '
        Me.texEstimatedResourcesInfra.Location = New System.Drawing.Point(124, 23)
        Me.texEstimatedResourcesInfra.Name = "texEstimatedResourcesInfra"
        Me.texEstimatedResourcesInfra.Size = New System.Drawing.Size(58, 20)
        Me.texEstimatedResourcesInfra.TabIndex = 59
        '
        'labEstimateResourcesSAP
        '
        Me.labEstimateResourcesSAP.AutoSize = True
        Me.labEstimateResourcesSAP.Location = New System.Drawing.Point(11, 52)
        Me.labEstimateResourcesSAP.Name = "labEstimateResourcesSAP"
        Me.labEstimateResourcesSAP.Size = New System.Drawing.Size(28, 13)
        Me.labEstimateResourcesSAP.TabIndex = 62
        Me.labEstimateResourcesSAP.Text = "SAP"
        '
        'texEstimatedResourcesSAP
        '
        Me.texEstimatedResourcesSAP.Location = New System.Drawing.Point(124, 49)
        Me.texEstimatedResourcesSAP.Name = "texEstimatedResourcesSAP"
        Me.texEstimatedResourcesSAP.Size = New System.Drawing.Size(58, 20)
        Me.texEstimatedResourcesSAP.TabIndex = 61
        '
        'labEstimateResourcesHelpdesk
        '
        Me.labEstimateResourcesHelpdesk.AutoSize = True
        Me.labEstimateResourcesHelpdesk.Location = New System.Drawing.Point(11, 78)
        Me.labEstimateResourcesHelpdesk.Name = "labEstimateResourcesHelpdesk"
        Me.labEstimateResourcesHelpdesk.Size = New System.Drawing.Size(52, 13)
        Me.labEstimateResourcesHelpdesk.TabIndex = 64
        Me.labEstimateResourcesHelpdesk.Text = "Helpdesk"
        '
        'texEstimatedResourcesHelpdesk
        '
        Me.texEstimatedResourcesHelpdesk.Location = New System.Drawing.Point(124, 75)
        Me.texEstimatedResourcesHelpdesk.Name = "texEstimatedResourcesHelpdesk"
        Me.texEstimatedResourcesHelpdesk.Size = New System.Drawing.Size(58, 20)
        Me.texEstimatedResourcesHelpdesk.TabIndex = 63
        '
        'labEstimateResourcesPlaning
        '
        Me.labEstimateResourcesPlaning.AutoSize = True
        Me.labEstimateResourcesPlaning.Location = New System.Drawing.Point(11, 104)
        Me.labEstimateResourcesPlaning.Name = "labEstimateResourcesPlaning"
        Me.labEstimateResourcesPlaning.Size = New System.Drawing.Size(64, 13)
        Me.labEstimateResourcesPlaning.TabIndex = 66
        Me.labEstimateResourcesPlaning.Text = "Planification"
        '
        'texEstimatedResourcesPlaning
        '
        Me.texEstimatedResourcesPlaning.Location = New System.Drawing.Point(124, 101)
        Me.texEstimatedResourcesPlaning.Name = "texEstimatedResourcesPlaning"
        Me.texEstimatedResourcesPlaning.Size = New System.Drawing.Size(58, 20)
        Me.texEstimatedResourcesPlaning.TabIndex = 65
        '
        'grpResourcesEstimated
        '
        Me.grpResourcesEstimated.Controls.Add(Me.labEstimateResourcesInfra)
        Me.grpResourcesEstimated.Controls.Add(Me.labEstimateResourcesPlaning)
        Me.grpResourcesEstimated.Controls.Add(Me.texEstimatedResourcesInfra)
        Me.grpResourcesEstimated.Controls.Add(Me.texEstimatedResourcesPlaning)
        Me.grpResourcesEstimated.Controls.Add(Me.labEstimateResourcesSAP)
        Me.grpResourcesEstimated.Controls.Add(Me.labEstimateResourcesHelpdesk)
        Me.grpResourcesEstimated.Controls.Add(Me.texEstimatedResourcesSAP)
        Me.grpResourcesEstimated.Controls.Add(Me.texEstimatedResourcesHelpdesk)
        Me.grpResourcesEstimated.Controls.Add(Me.texEstimatedResources)
        Me.grpResourcesEstimated.Controls.Add(Me.labEstimateResources)
        Me.grpResourcesEstimated.Location = New System.Drawing.Point(611, 278)
        Me.grpResourcesEstimated.Name = "grpResourcesEstimated"
        Me.grpResourcesEstimated.Size = New System.Drawing.Size(200, 169)
        Me.grpResourcesEstimated.TabIndex = 67
        Me.grpResourcesEstimated.TabStop = False
        Me.grpResourcesEstimated.Text = "Ressources estimées (jours)"
        '
        'texITBoard
        '
        Me.texITBoard.Location = New System.Drawing.Point(852, 75)
        Me.texITBoard.Multiline = True
        Me.texITBoard.Name = "texITBoard"
        Me.texITBoard.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.texITBoard.Size = New System.Drawing.Size(511, 103)
        Me.texITBoard.TabIndex = 68
        '
        'labTextForITBoard
        '
        Me.labTextForITBoard.AutoSize = True
        Me.labTextForITBoard.Location = New System.Drawing.Point(849, 52)
        Me.labTextForITBoard.Name = "labTextForITBoard"
        Me.labTextForITBoard.Size = New System.Drawing.Size(102, 13)
        Me.labTextForITBoard.TabIndex = 69
        Me.labTextForITBoard.Text = "Texte pour IT-Board"
        '
        'labRemarks
        '
        Me.labRemarks.AutoSize = True
        Me.labRemarks.Location = New System.Drawing.Point(849, 214)
        Me.labRemarks.Name = "labRemarks"
        Me.labRemarks.Size = New System.Drawing.Size(61, 13)
        Me.labRemarks.TabIndex = 70
        Me.labRemarks.Text = "Remarques"
        '
        'dgvProjectRemarks
        '
        Me.dgvProjectRemarks.AllowUserToAddRows = False
        Me.dgvProjectRemarks.AllowUserToDeleteRows = False
        Me.dgvProjectRemarks.AllowUserToResizeColumns = False
        Me.dgvProjectRemarks.AllowUserToResizeRows = False
        Me.dgvProjectRemarks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProjectRemarks.Location = New System.Drawing.Point(852, 258)
        Me.dgvProjectRemarks.Name = "dgvProjectRemarks"
        Me.dgvProjectRemarks.Size = New System.Drawing.Size(511, 189)
        Me.dgvProjectRemarks.TabIndex = 71
        '
        'btcRemarkAdd
        '
        Me.btcRemarkAdd.Location = New System.Drawing.Point(946, 209)
        Me.btcRemarkAdd.Margin = New System.Windows.Forms.Padding(0)
        Me.btcRemarkAdd.Name = "btcRemarkAdd"
        Me.btcRemarkAdd.Size = New System.Drawing.Size(77, 23)
        Me.btcRemarkAdd.TabIndex = 72
        Me.btcRemarkAdd.Text = "Ajouter"
        Me.btcRemarkAdd.UseVisualStyleBackColor = True
        '
        'btcRemarkRemove
        '
        Me.btcRemarkRemove.Location = New System.Drawing.Point(1137, 209)
        Me.btcRemarkRemove.Margin = New System.Windows.Forms.Padding(0)
        Me.btcRemarkRemove.Name = "btcRemarkRemove"
        Me.btcRemarkRemove.Size = New System.Drawing.Size(77, 23)
        Me.btcRemarkRemove.TabIndex = 73
        Me.btcRemarkRemove.Text = "Supprimer"
        Me.btcRemarkRemove.UseVisualStyleBackColor = True
        '
        'btcRemardModify
        '
        Me.btcRemardModify.Location = New System.Drawing.Point(1041, 209)
        Me.btcRemardModify.Name = "btcRemardModify"
        Me.btcRemardModify.Size = New System.Drawing.Size(77, 23)
        Me.btcRemardModify.TabIndex = 74
        Me.btcRemardModify.Text = "Modifier"
        Me.btcRemardModify.UseVisualStyleBackColor = True
        '
        'frmProjectDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1393, 486)
        Me.Controls.Add(Me.btcRemardModify)
        Me.Controls.Add(Me.btcRemarkRemove)
        Me.Controls.Add(Me.btcRemarkAdd)
        Me.Controls.Add(Me.dgvProjectRemarks)
        Me.Controls.Add(Me.labRemarks)
        Me.Controls.Add(Me.labTextForITBoard)
        Me.Controls.Add(Me.texITBoard)
        Me.Controls.Add(Me.grpResourcesEstimated)
        Me.Controls.Add(Me.dtpBegin)
        Me.Controls.Add(Me.labBegin)
        Me.Controls.Add(Me.lovUrgency)
        Me.Controls.Add(Me.labUrgency)
        Me.Controls.Add(Me.btcComments)
        Me.Controls.Add(Me.labExecutedResources)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.texExecutedResources)
        Me.Controls.Add(Me.labPlanResources)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.texPlanResources)
        Me.Controls.Add(Me.labClient)
        Me.Controls.Add(Me.lovCustomer)
        Me.Controls.Add(Me.lovProjectCategory)
        Me.Controls.Add(Me.lovPriority)
        Me.Controls.Add(Me.labPriority)
        Me.Controls.Add(Me.labID_Project)
        Me.Controls.Add(Me.texID_Project)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.labImplementationRate)
        Me.Controls.Add(Me.texImplementationRate)
        Me.Controls.Add(Me.btcOK)
        Me.Controls.Add(Me.btcAnnuler)
        Me.Controls.Add(Me.lovStatus)
        Me.Controls.Add(Me.labStatut)
        Me.Controls.Add(Me.labChefProjet)
        Me.Controls.Add(Me.lovProjectManager)
        Me.Controls.Add(Me.dtpDeadline)
        Me.Controls.Add(Me.labDeadline)
        Me.Controls.Add(Me.labDescription)
        Me.Controls.Add(Me.texDescription)
        Me.Controls.Add(Me.labCategorie)
        Me.Controls.Add(Me.labTitre)
        Me.Controls.Add(Me.texTitre)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmProjectDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Details du projet"
        Me.grpResourcesEstimated.ResumeLayout(False)
        Me.grpResourcesEstimated.PerformLayout()
        CType(Me.dgvProjectRemarks, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents texTitre As TextBox
    Friend WithEvents labTitre As Label
    Friend WithEvents labCategorie As Label
    Friend WithEvents labDescription As Label
    Friend WithEvents texDescription As TextBox
    Friend WithEvents labDeadline As Label
    Friend WithEvents dtpDeadline As DateTimePicker
    Friend WithEvents lovProjectManager As ComboBox
    Friend WithEvents labChefProjet As Label
    Friend WithEvents labStatut As Label
    Friend WithEvents lovStatus As ComboBox
    Friend WithEvents btcAnnuler As Button
    Friend WithEvents btcOK As Button
    Friend WithEvents labEstimateResources As Label
    Friend WithEvents texEstimatedResources As TextBox
    Friend WithEvents labImplementationRate As Label
    Friend WithEvents texImplementationRate As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents labID_Project As Label
    Friend WithEvents texID_Project As TextBox
    Friend WithEvents lovPriority As ComboBox
    Friend WithEvents labPriority As Label
    Friend WithEvents lovProjectCategory As ComboBox
    Friend WithEvents labClient As Label
    Friend WithEvents lovCustomer As ComboBox
    Friend WithEvents texPlanResources As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents labPlanResources As Label
    Friend WithEvents labExecutedResources As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents texExecutedResources As TextBox
    Friend WithEvents btcComments As Button
    Friend WithEvents lovUrgency As ComboBox
    Friend WithEvents labUrgency As Label
    Friend WithEvents dtpBegin As DateTimePicker
    Friend WithEvents labBegin As Label
    Friend WithEvents labEstimateResourcesInfra As Label
    Friend WithEvents texEstimatedResourcesInfra As TextBox
    Friend WithEvents labEstimateResourcesSAP As Label
    Friend WithEvents texEstimatedResourcesSAP As TextBox
    Friend WithEvents labEstimateResourcesHelpdesk As Label
    Friend WithEvents texEstimatedResourcesHelpdesk As TextBox
    Friend WithEvents labEstimateResourcesPlaning As Label
    Friend WithEvents texEstimatedResourcesPlaning As TextBox
    Friend WithEvents grpResourcesEstimated As GroupBox
    Friend WithEvents texITBoard As TextBox
    Friend WithEvents labTextForITBoard As Label
    Friend WithEvents labRemarks As Label
    Friend WithEvents dgvProjectRemarks As DataGridView
    Friend WithEvents btcRemarkAdd As Button
    Friend WithEvents btcRemarkRemove As Button
    Friend WithEvents btcRemardModify As Button
End Class
