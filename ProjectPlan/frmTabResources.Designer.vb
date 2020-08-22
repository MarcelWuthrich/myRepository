<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTabResources
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTabResources))
        Me.dgvResources = New System.Windows.Forms.DataGridView()
        Me.dtpDateFrom = New System.Windows.Forms.DateTimePicker()
        Me.grpFilters = New System.Windows.Forms.GroupBox()
        Me.lovProjectMember = New System.Windows.Forms.ComboBox()
        Me.labProjectMember = New System.Windows.Forms.Label()
        Me.btcFilter30Days = New System.Windows.Forms.Button()
        Me.btcFilterClear = New System.Windows.Forms.Button()
        Me.btcFilter = New System.Windows.Forms.Button()
        Me.labDateTo = New System.Windows.Forms.Label()
        Me.dtpDateTo = New System.Windows.Forms.DateTimePicker()
        Me.labDateFrom = New System.Windows.Forms.Label()
        Me.btcAdminResource = New System.Windows.Forms.Button()
        Me.btcResources = New System.Windows.Forms.Button()
        Me.grpResourcesPlan = New System.Windows.Forms.GroupBox()
        Me.btcFermer = New System.Windows.Forms.Button()
        Me.btcGestion = New System.Windows.Forms.Button()
        Me.grpManageResources = New System.Windows.Forms.GroupBox()
        Me.lovTasks = New System.Windows.Forms.ComboBox()
        Me.labTaches = New System.Windows.Forms.Label()
        CType(Me.dgvResources, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFilters.SuspendLayout()
        Me.grpResourcesPlan.SuspendLayout()
        Me.grpManageResources.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvResources
        '
        Me.dgvResources.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvResources.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResources.Location = New System.Drawing.Point(54, 114)
        Me.dgvResources.Name = "dgvResources"
        Me.dgvResources.Size = New System.Drawing.Size(1446, 716)
        Me.dgvResources.TabIndex = 0
        '
        'dtpDateFrom
        '
        Me.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateFrom.Location = New System.Drawing.Point(55, 19)
        Me.dtpDateFrom.Name = "dtpDateFrom"
        Me.dtpDateFrom.Size = New System.Drawing.Size(93, 20)
        Me.dtpDateFrom.TabIndex = 1
        '
        'grpFilters
        '
        Me.grpFilters.Controls.Add(Me.lovTasks)
        Me.grpFilters.Controls.Add(Me.labTaches)
        Me.grpFilters.Controls.Add(Me.lovProjectMember)
        Me.grpFilters.Controls.Add(Me.labProjectMember)
        Me.grpFilters.Controls.Add(Me.btcFilter30Days)
        Me.grpFilters.Controls.Add(Me.btcFilterClear)
        Me.grpFilters.Controls.Add(Me.btcFilter)
        Me.grpFilters.Controls.Add(Me.labDateTo)
        Me.grpFilters.Controls.Add(Me.dtpDateTo)
        Me.grpFilters.Controls.Add(Me.labDateFrom)
        Me.grpFilters.Controls.Add(Me.dtpDateFrom)
        Me.grpFilters.Location = New System.Drawing.Point(54, 24)
        Me.grpFilters.Name = "grpFilters"
        Me.grpFilters.Size = New System.Drawing.Size(541, 84)
        Me.grpFilters.TabIndex = 2
        Me.grpFilters.TabStop = False
        Me.grpFilters.Text = "Filtres"
        '
        'lovProjectMember
        '
        Me.lovProjectMember.FormattingEnabled = True
        Me.lovProjectMember.Location = New System.Drawing.Point(185, 48)
        Me.lovProjectMember.Name = "lovProjectMember"
        Me.lovProjectMember.Size = New System.Drawing.Size(121, 21)
        Me.lovProjectMember.TabIndex = 16
        '
        'labProjectMember
        '
        Me.labProjectMember.AutoSize = True
        Me.labProjectMember.Location = New System.Drawing.Point(59, 51)
        Me.labProjectMember.Name = "labProjectMember"
        Me.labProjectMember.Size = New System.Drawing.Size(89, 13)
        Me.labProjectMember.TabIndex = 15
        Me.labProjectMember.Text = "Membre de projet"
        '
        'btcFilter30Days
        '
        Me.btcFilter30Days.Location = New System.Drawing.Point(448, 19)
        Me.btcFilter30Days.Name = "btcFilter30Days"
        Me.btcFilter30Days.Size = New System.Drawing.Size(75, 23)
        Me.btcFilter30Days.TabIndex = 14
        Me.btcFilter30Days.Text = "30 jours"
        Me.btcFilter30Days.UseVisualStyleBackColor = True
        '
        'btcFilterClear
        '
        Me.btcFilterClear.Image = CType(resources.GetObject("btcFilterClear.Image"), System.Drawing.Image)
        Me.btcFilterClear.Location = New System.Drawing.Point(419, 19)
        Me.btcFilterClear.Name = "btcFilterClear"
        Me.btcFilterClear.Size = New System.Drawing.Size(23, 23)
        Me.btcFilterClear.TabIndex = 13
        Me.btcFilterClear.UseVisualStyleBackColor = True
        '
        'btcFilter
        '
        Me.btcFilter.Location = New System.Drawing.Point(338, 19)
        Me.btcFilter.Name = "btcFilter"
        Me.btcFilter.Size = New System.Drawing.Size(75, 23)
        Me.btcFilter.TabIndex = 5
        Me.btcFilter.Text = "Filtre"
        Me.btcFilter.UseVisualStyleBackColor = True
        '
        'labDateTo
        '
        Me.labDateTo.AutoSize = True
        Me.labDateTo.Location = New System.Drawing.Point(183, 25)
        Me.labDateTo.Name = "labDateTo"
        Me.labDateTo.Size = New System.Drawing.Size(14, 13)
        Me.labDateTo.TabIndex = 4
        Me.labDateTo.Text = "A"
        '
        'dtpDateTo
        '
        Me.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateTo.Location = New System.Drawing.Point(213, 19)
        Me.dtpDateTo.Name = "dtpDateTo"
        Me.dtpDateTo.Size = New System.Drawing.Size(93, 20)
        Me.dtpDateTo.TabIndex = 3
        '
        'labDateFrom
        '
        Me.labDateFrom.AutoSize = True
        Me.labDateFrom.Location = New System.Drawing.Point(11, 25)
        Me.labDateFrom.Name = "labDateFrom"
        Me.labDateFrom.Size = New System.Drawing.Size(21, 13)
        Me.labDateFrom.TabIndex = 2
        Me.labDateFrom.Text = "De"
        '
        'btcAdminResource
        '
        Me.btcAdminResource.Location = New System.Drawing.Point(23, 19)
        Me.btcAdminResource.Name = "btcAdminResource"
        Me.btcAdminResource.Size = New System.Drawing.Size(92, 23)
        Me.btcAdminResource.TabIndex = 17
        Me.btcAdminResource.Text = "Administratives"
        Me.btcAdminResource.UseVisualStyleBackColor = True
        '
        'btcResources
        '
        Me.btcResources.Location = New System.Drawing.Point(143, 20)
        Me.btcResources.Name = "btcResources"
        Me.btcResources.Size = New System.Drawing.Size(92, 23)
        Me.btcResources.TabIndex = 19
        Me.btcResources.Text = "Projets"
        Me.btcResources.UseVisualStyleBackColor = True
        '
        'grpResourcesPlan
        '
        Me.grpResourcesPlan.Controls.Add(Me.btcAdminResource)
        Me.grpResourcesPlan.Controls.Add(Me.btcResources)
        Me.grpResourcesPlan.Location = New System.Drawing.Point(628, 24)
        Me.grpResourcesPlan.Name = "grpResourcesPlan"
        Me.grpResourcesPlan.Size = New System.Drawing.Size(260, 54)
        Me.grpResourcesPlan.TabIndex = 20
        Me.grpResourcesPlan.TabStop = False
        Me.grpResourcesPlan.Text = "Planification de ressources"
        '
        'btcFermer
        '
        Me.btcFermer.Location = New System.Drawing.Point(1071, 44)
        Me.btcFermer.Name = "btcFermer"
        Me.btcFermer.Size = New System.Drawing.Size(75, 23)
        Me.btcFermer.TabIndex = 21
        Me.btcFermer.Text = "&Fermer"
        Me.btcFermer.UseVisualStyleBackColor = True
        '
        'btcGestion
        '
        Me.btcGestion.Location = New System.Drawing.Point(17, 20)
        Me.btcGestion.Name = "btcGestion"
        Me.btcGestion.Size = New System.Drawing.Size(75, 23)
        Me.btcGestion.TabIndex = 25
        Me.btcGestion.Text = "Gestion"
        Me.btcGestion.UseVisualStyleBackColor = True
        '
        'grpManageResources
        '
        Me.grpManageResources.Controls.Add(Me.btcGestion)
        Me.grpManageResources.Location = New System.Drawing.Point(912, 24)
        Me.grpManageResources.Name = "grpManageResources"
        Me.grpManageResources.Size = New System.Drawing.Size(134, 54)
        Me.grpManageResources.TabIndex = 26
        Me.grpManageResources.TabStop = False
        Me.grpManageResources.Text = "Gestion des ressources"
        '
        'lovTasks
        '
        Me.lovTasks.FormattingEnabled = True
        Me.lovTasks.Location = New System.Drawing.Point(402, 48)
        Me.lovTasks.Name = "lovTasks"
        Me.lovTasks.Size = New System.Drawing.Size(121, 21)
        Me.lovTasks.TabIndex = 18
        '
        'labTaches
        '
        Me.labTaches.AutoSize = True
        Me.labTaches.Location = New System.Drawing.Point(335, 51)
        Me.labTaches.Name = "labTaches"
        Me.labTaches.Size = New System.Drawing.Size(43, 13)
        Me.labTaches.TabIndex = 17
        Me.labTaches.Text = "Tâches"
        '
        'frmTabResources
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1564, 876)
        Me.Controls.Add(Me.grpManageResources)
        Me.Controls.Add(Me.btcFermer)
        Me.Controls.Add(Me.grpResourcesPlan)
        Me.Controls.Add(Me.grpFilters)
        Me.Controls.Add(Me.dgvResources)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmTabResources"
        Me.Text = "Tableau des ressources"
        CType(Me.dgvResources, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFilters.ResumeLayout(False)
        Me.grpFilters.PerformLayout()
        Me.grpResourcesPlan.ResumeLayout(False)
        Me.grpManageResources.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvResources As DataGridView
    Friend WithEvents dtpDateFrom As DateTimePicker
    Friend WithEvents grpFilters As GroupBox
    Friend WithEvents btcFilter As Button
    Friend WithEvents labDateTo As Label
    Friend WithEvents dtpDateTo As DateTimePicker
    Friend WithEvents labDateFrom As Label
    Friend WithEvents btcFilterClear As Button
    Friend WithEvents btcFilter30Days As Button
    Friend WithEvents btcAdminResource As Button
    Friend WithEvents btcResources As Button
    Friend WithEvents grpResourcesPlan As GroupBox
    Friend WithEvents btcFermer As Button
    Friend WithEvents btcGestion As Button
    Friend WithEvents grpManageResources As GroupBox
    Friend WithEvents lovProjectMember As ComboBox
    Friend WithEvents labProjectMember As Label
    Friend WithEvents lovTasks As ComboBox
    Friend WithEvents labTaches As Label
End Class
