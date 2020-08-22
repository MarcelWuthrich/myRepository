<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlanProject
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPlanProject))
        Me.radProjectsPlaned = New System.Windows.Forms.RadioButton()
        Me.grpProjects = New System.Windows.Forms.GroupBox()
        Me.radProjectsAll = New System.Windows.Forms.RadioButton()
        Me.lstProjects = New System.Windows.Forms.ListBox()
        Me.labProjectNumber = New System.Windows.Forms.Label()
        Me.labPlanResources = New System.Windows.Forms.Label()
        Me.lstPlanResources = New System.Windows.Forms.ListBox()
        Me.lstExecutedResources = New System.Windows.Forms.ListBox()
        Me.labExecutedResources = New System.Windows.Forms.Label()
        Me.labTotalPlanResources = New System.Windows.Forms.Label()
        Me.labTotalExecutedResources = New System.Windows.Forms.Label()
        Me.btcClose = New System.Windows.Forms.Button()
        Me.grpProjects.SuspendLayout()
        Me.SuspendLayout()
        '
        'radProjectsPlaned
        '
        Me.radProjectsPlaned.AutoSize = True
        Me.radProjectsPlaned.Checked = True
        Me.radProjectsPlaned.Location = New System.Drawing.Point(6, 19)
        Me.radProjectsPlaned.Name = "radProjectsPlaned"
        Me.radProjectsPlaned.Size = New System.Drawing.Size(284, 17)
        Me.radProjectsPlaned.TabIndex = 0
        Me.radProjectsPlaned.TabStop = True
        Me.radProjectsPlaned.Text = "Uniquement des projets avec des ressources planifiées"
        Me.radProjectsPlaned.UseVisualStyleBackColor = True
        '
        'grpProjects
        '
        Me.grpProjects.Controls.Add(Me.radProjectsAll)
        Me.grpProjects.Controls.Add(Me.radProjectsPlaned)
        Me.grpProjects.Location = New System.Drawing.Point(37, 23)
        Me.grpProjects.Name = "grpProjects"
        Me.grpProjects.Size = New System.Drawing.Size(385, 72)
        Me.grpProjects.TabIndex = 1
        Me.grpProjects.TabStop = False
        Me.grpProjects.Text = "Projets"
        '
        'radProjectsAll
        '
        Me.radProjectsAll.AutoSize = True
        Me.radProjectsAll.Location = New System.Drawing.Point(6, 42)
        Me.radProjectsAll.Name = "radProjectsAll"
        Me.radProjectsAll.Size = New System.Drawing.Size(99, 17)
        Me.radProjectsAll.TabIndex = 1
        Me.radProjectsAll.Text = "Tous les projets"
        Me.radProjectsAll.UseVisualStyleBackColor = True
        '
        'lstProjects
        '
        Me.lstProjects.FormattingEnabled = True
        Me.lstProjects.Location = New System.Drawing.Point(37, 123)
        Me.lstProjects.Name = "lstProjects"
        Me.lstProjects.Size = New System.Drawing.Size(385, 186)
        Me.lstProjects.TabIndex = 2
        '
        'labProjectNumber
        '
        Me.labProjectNumber.AutoSize = True
        Me.labProjectNumber.Location = New System.Drawing.Point(37, 102)
        Me.labProjectNumber.Name = "labProjectNumber"
        Me.labProjectNumber.Size = New System.Drawing.Size(93, 13)
        Me.labProjectNumber.TabIndex = 3
        Me.labProjectNumber.Text = "Nombre de projets"
        '
        'labPlanResources
        '
        Me.labPlanResources.AutoSize = True
        Me.labPlanResources.Location = New System.Drawing.Point(473, 23)
        Me.labPlanResources.Name = "labPlanResources"
        Me.labPlanResources.Size = New System.Drawing.Size(110, 13)
        Me.labPlanResources.TabIndex = 4
        Me.labPlanResources.Text = "Ressources planifiées"
        '
        'lstPlanResources
        '
        Me.lstPlanResources.FormattingEnabled = True
        Me.lstPlanResources.Location = New System.Drawing.Point(476, 42)
        Me.lstPlanResources.Name = "lstPlanResources"
        Me.lstPlanResources.Size = New System.Drawing.Size(219, 264)
        Me.lstPlanResources.TabIndex = 5
        '
        'lstExecutedResources
        '
        Me.lstExecutedResources.FormattingEnabled = True
        Me.lstExecutedResources.Location = New System.Drawing.Point(738, 42)
        Me.lstExecutedResources.Name = "lstExecutedResources"
        Me.lstExecutedResources.Size = New System.Drawing.Size(219, 264)
        Me.lstExecutedResources.TabIndex = 6
        '
        'labExecutedResources
        '
        Me.labExecutedResources.AutoSize = True
        Me.labExecutedResources.Location = New System.Drawing.Point(735, 23)
        Me.labExecutedResources.Name = "labExecutedResources"
        Me.labExecutedResources.Size = New System.Drawing.Size(115, 13)
        Me.labExecutedResources.TabIndex = 7
        Me.labExecutedResources.Text = "Ressources exécutées"
        '
        'labTotalPlanResources
        '
        Me.labTotalPlanResources.AutoSize = True
        Me.labTotalPlanResources.Location = New System.Drawing.Point(473, 318)
        Me.labTotalPlanResources.Name = "labTotalPlanResources"
        Me.labTotalPlanResources.Size = New System.Drawing.Size(31, 13)
        Me.labTotalPlanResources.TabIndex = 8
        Me.labTotalPlanResources.Text = "Total"
        '
        'labTotalExecutedResources
        '
        Me.labTotalExecutedResources.AutoSize = True
        Me.labTotalExecutedResources.Location = New System.Drawing.Point(735, 318)
        Me.labTotalExecutedResources.Name = "labTotalExecutedResources"
        Me.labTotalExecutedResources.Size = New System.Drawing.Size(31, 13)
        Me.labTotalExecutedResources.TabIndex = 9
        Me.labTotalExecutedResources.Text = "Total"
        '
        'btcClose
        '
        Me.btcClose.Location = New System.Drawing.Point(446, 360)
        Me.btcClose.Name = "btcClose"
        Me.btcClose.Size = New System.Drawing.Size(75, 23)
        Me.btcClose.TabIndex = 10
        Me.btcClose.Text = "Fermer"
        Me.btcClose.UseVisualStyleBackColor = True
        '
        'frmPlanProject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1020, 450)
        Me.Controls.Add(Me.btcClose)
        Me.Controls.Add(Me.labTotalExecutedResources)
        Me.Controls.Add(Me.labTotalPlanResources)
        Me.Controls.Add(Me.labExecutedResources)
        Me.Controls.Add(Me.lstExecutedResources)
        Me.Controls.Add(Me.lstPlanResources)
        Me.Controls.Add(Me.labPlanResources)
        Me.Controls.Add(Me.labProjectNumber)
        Me.Controls.Add(Me.lstProjects)
        Me.Controls.Add(Me.grpProjects)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPlanProject"
        Me.Text = "Planification des projets"
        Me.grpProjects.ResumeLayout(False)
        Me.grpProjects.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents radProjectsPlaned As RadioButton
    Friend WithEvents grpProjects As GroupBox
    Friend WithEvents radProjectsAll As RadioButton
    Friend WithEvents lstProjects As ListBox
    Friend WithEvents labProjectNumber As Label
    Friend WithEvents labPlanResources As Label
    Friend WithEvents lstPlanResources As ListBox
    Friend WithEvents lstExecutedResources As ListBox
    Friend WithEvents labExecutedResources As Label
    Friend WithEvents labTotalPlanResources As Label
    Friend WithEvents labTotalExecutedResources As Label
    Friend WithEvents btcClose As Button
End Class
