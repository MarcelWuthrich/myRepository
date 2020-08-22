<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDashboard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDashboard))
        Me.dgvProjects = New System.Windows.Forms.DataGridView()
        Me.dgvInfrastructure = New System.Windows.Forms.DataGridView()
        Me.dgvSAP = New System.Windows.Forms.DataGridView()
        Me.dgvHelpdesk = New System.Windows.Forms.DataGridView()
        Me.dgvPlaning = New System.Windows.Forms.DataGridView()
        Me.texColorInfra = New System.Windows.Forms.TextBox()
        Me.texColorSAP = New System.Windows.Forms.TextBox()
        Me.texColorHelpdesk = New System.Windows.Forms.TextBox()
        Me.texColorPlaning = New System.Windows.Forms.TextBox()
        Me.texColorTotal = New System.Windows.Forms.TextBox()
        Me.btcFermer = New System.Windows.Forms.Button()
        Me.tabTaskType = New System.Windows.Forms.TabControl()
        Me.tabInfrastructure = New System.Windows.Forms.TabPage()
        Me.tabSAP = New System.Windows.Forms.TabPage()
        Me.tabHelpdesk = New System.Windows.Forms.TabPage()
        Me.tabPlaning = New System.Windows.Forms.TabPage()
        Me.texFreeDateInfra = New System.Windows.Forms.TextBox()
        Me.labFreeDateInfra = New System.Windows.Forms.Label()
        Me.labFreeDateSAP = New System.Windows.Forms.Label()
        Me.texFreeDateSAP = New System.Windows.Forms.TextBox()
        Me.labFreeDateHelpdesk = New System.Windows.Forms.Label()
        Me.texFreeDateHelpdesk = New System.Windows.Forms.TextBox()
        Me.labFreeDatePlaning = New System.Windows.Forms.Label()
        Me.texFreeDatePlaning = New System.Windows.Forms.TextBox()
        Me.grpNextFreeDate = New System.Windows.Forms.GroupBox()
        Me.btcChart = New System.Windows.Forms.Button()
        Me.btcExportToExcel = New System.Windows.Forms.Button()
        CType(Me.dgvProjects, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvInfrastructure, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSAP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvHelpdesk, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPlaning, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabTaskType.SuspendLayout()
        Me.tabInfrastructure.SuspendLayout()
        Me.tabSAP.SuspendLayout()
        Me.tabHelpdesk.SuspendLayout()
        Me.tabPlaning.SuspendLayout()
        Me.grpNextFreeDate.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvProjects
        '
        Me.dgvProjects.AllowUserToResizeColumns = False
        Me.dgvProjects.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvProjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProjects.Location = New System.Drawing.Point(23, 73)
        Me.dgvProjects.Name = "dgvProjects"
        Me.dgvProjects.Size = New System.Drawing.Size(1550, 495)
        Me.dgvProjects.TabIndex = 0
        '
        'dgvInfrastructure
        '
        Me.dgvInfrastructure.AllowUserToResizeColumns = False
        Me.dgvInfrastructure.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvInfrastructure.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInfrastructure.Location = New System.Drawing.Point(6, 6)
        Me.dgvInfrastructure.Name = "dgvInfrastructure"
        Me.dgvInfrastructure.Size = New System.Drawing.Size(545, 260)
        Me.dgvInfrastructure.TabIndex = 0
        '
        'dgvSAP
        '
        Me.dgvSAP.AllowUserToResizeColumns = False
        Me.dgvSAP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSAP.Location = New System.Drawing.Point(6, 6)
        Me.dgvSAP.Name = "dgvSAP"
        Me.dgvSAP.Size = New System.Drawing.Size(545, 260)
        Me.dgvSAP.TabIndex = 0
        '
        'dgvHelpdesk
        '
        Me.dgvHelpdesk.AllowUserToResizeColumns = False
        Me.dgvHelpdesk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvHelpdesk.Location = New System.Drawing.Point(6, 6)
        Me.dgvHelpdesk.Name = "dgvHelpdesk"
        Me.dgvHelpdesk.Size = New System.Drawing.Size(545, 260)
        Me.dgvHelpdesk.TabIndex = 0
        '
        'dgvPlaning
        '
        Me.dgvPlaning.AllowUserToResizeColumns = False
        Me.dgvPlaning.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPlaning.Location = New System.Drawing.Point(6, 6)
        Me.dgvPlaning.Name = "dgvPlaning"
        Me.dgvPlaning.Size = New System.Drawing.Size(545, 260)
        Me.dgvPlaning.TabIndex = 0
        '
        'texColorInfra
        '
        Me.texColorInfra.Location = New System.Drawing.Point(638, 23)
        Me.texColorInfra.Name = "texColorInfra"
        Me.texColorInfra.ReadOnly = True
        Me.texColorInfra.Size = New System.Drawing.Size(100, 20)
        Me.texColorInfra.TabIndex = 5
        Me.texColorInfra.Text = "Infrastructure"
        Me.texColorInfra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'texColorSAP
        '
        Me.texColorSAP.Location = New System.Drawing.Point(744, 23)
        Me.texColorSAP.Name = "texColorSAP"
        Me.texColorSAP.ReadOnly = True
        Me.texColorSAP.Size = New System.Drawing.Size(100, 20)
        Me.texColorSAP.TabIndex = 6
        Me.texColorSAP.Text = "SAP"
        Me.texColorSAP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'texColorHelpdesk
        '
        Me.texColorHelpdesk.Location = New System.Drawing.Point(850, 23)
        Me.texColorHelpdesk.Name = "texColorHelpdesk"
        Me.texColorHelpdesk.ReadOnly = True
        Me.texColorHelpdesk.Size = New System.Drawing.Size(100, 20)
        Me.texColorHelpdesk.TabIndex = 7
        Me.texColorHelpdesk.Text = "Helpdesk"
        Me.texColorHelpdesk.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'texColorPlaning
        '
        Me.texColorPlaning.Location = New System.Drawing.Point(956, 23)
        Me.texColorPlaning.Name = "texColorPlaning"
        Me.texColorPlaning.ReadOnly = True
        Me.texColorPlaning.Size = New System.Drawing.Size(100, 20)
        Me.texColorPlaning.TabIndex = 8
        Me.texColorPlaning.Text = "Planification"
        Me.texColorPlaning.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'texColorTotal
        '
        Me.texColorTotal.Location = New System.Drawing.Point(532, 23)
        Me.texColorTotal.Name = "texColorTotal"
        Me.texColorTotal.ReadOnly = True
        Me.texColorTotal.Size = New System.Drawing.Size(100, 20)
        Me.texColorTotal.TabIndex = 9
        Me.texColorTotal.Text = "Total"
        Me.texColorTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btcFermer
        '
        Me.btcFermer.Location = New System.Drawing.Point(254, 19)
        Me.btcFermer.Name = "btcFermer"
        Me.btcFermer.Size = New System.Drawing.Size(75, 23)
        Me.btcFermer.TabIndex = 10
        Me.btcFermer.Text = "Fermer"
        Me.btcFermer.UseVisualStyleBackColor = True
        '
        'tabTaskType
        '
        Me.tabTaskType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tabTaskType.Controls.Add(Me.tabInfrastructure)
        Me.tabTaskType.Controls.Add(Me.tabSAP)
        Me.tabTaskType.Controls.Add(Me.tabHelpdesk)
        Me.tabTaskType.Controls.Add(Me.tabPlaning)
        Me.tabTaskType.Location = New System.Drawing.Point(23, 581)
        Me.tabTaskType.Name = "tabTaskType"
        Me.tabTaskType.SelectedIndex = 0
        Me.tabTaskType.Size = New System.Drawing.Size(565, 298)
        Me.tabTaskType.TabIndex = 11
        '
        'tabInfrastructure
        '
        Me.tabInfrastructure.Controls.Add(Me.dgvInfrastructure)
        Me.tabInfrastructure.Location = New System.Drawing.Point(4, 22)
        Me.tabInfrastructure.Name = "tabInfrastructure"
        Me.tabInfrastructure.Padding = New System.Windows.Forms.Padding(3)
        Me.tabInfrastructure.Size = New System.Drawing.Size(557, 272)
        Me.tabInfrastructure.TabIndex = 0
        Me.tabInfrastructure.Text = "Infrastructure"
        Me.tabInfrastructure.UseVisualStyleBackColor = True
        '
        'tabSAP
        '
        Me.tabSAP.Controls.Add(Me.dgvSAP)
        Me.tabSAP.Location = New System.Drawing.Point(4, 22)
        Me.tabSAP.Name = "tabSAP"
        Me.tabSAP.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSAP.Size = New System.Drawing.Size(557, 272)
        Me.tabSAP.TabIndex = 1
        Me.tabSAP.Text = "SAP"
        Me.tabSAP.UseVisualStyleBackColor = True
        '
        'tabHelpdesk
        '
        Me.tabHelpdesk.Controls.Add(Me.dgvHelpdesk)
        Me.tabHelpdesk.Location = New System.Drawing.Point(4, 22)
        Me.tabHelpdesk.Name = "tabHelpdesk"
        Me.tabHelpdesk.Size = New System.Drawing.Size(557, 272)
        Me.tabHelpdesk.TabIndex = 2
        Me.tabHelpdesk.Text = "Helpdesk"
        Me.tabHelpdesk.UseVisualStyleBackColor = True
        '
        'tabPlaning
        '
        Me.tabPlaning.Controls.Add(Me.dgvPlaning)
        Me.tabPlaning.Location = New System.Drawing.Point(4, 22)
        Me.tabPlaning.Name = "tabPlaning"
        Me.tabPlaning.Size = New System.Drawing.Size(557, 272)
        Me.tabPlaning.TabIndex = 3
        Me.tabPlaning.Text = "Planification"
        Me.tabPlaning.UseVisualStyleBackColor = True
        '
        'texFreeDateInfra
        '
        Me.texFreeDateInfra.Location = New System.Drawing.Point(138, 42)
        Me.texFreeDateInfra.Name = "texFreeDateInfra"
        Me.texFreeDateInfra.ReadOnly = True
        Me.texFreeDateInfra.Size = New System.Drawing.Size(154, 20)
        Me.texFreeDateInfra.TabIndex = 12
        '
        'labFreeDateInfra
        '
        Me.labFreeDateInfra.AutoSize = True
        Me.labFreeDateInfra.Location = New System.Drawing.Point(34, 45)
        Me.labFreeDateInfra.Name = "labFreeDateInfra"
        Me.labFreeDateInfra.Size = New System.Drawing.Size(69, 13)
        Me.labFreeDateInfra.TabIndex = 13
        Me.labFreeDateInfra.Text = "Infrastructure"
        '
        'labFreeDateSAP
        '
        Me.labFreeDateSAP.AutoSize = True
        Me.labFreeDateSAP.Location = New System.Drawing.Point(34, 97)
        Me.labFreeDateSAP.Name = "labFreeDateSAP"
        Me.labFreeDateSAP.Size = New System.Drawing.Size(28, 13)
        Me.labFreeDateSAP.TabIndex = 15
        Me.labFreeDateSAP.Text = "SAP"
        '
        'texFreeDateSAP
        '
        Me.texFreeDateSAP.Location = New System.Drawing.Point(138, 94)
        Me.texFreeDateSAP.Name = "texFreeDateSAP"
        Me.texFreeDateSAP.ReadOnly = True
        Me.texFreeDateSAP.Size = New System.Drawing.Size(154, 20)
        Me.texFreeDateSAP.TabIndex = 14
        '
        'labFreeDateHelpdesk
        '
        Me.labFreeDateHelpdesk.AutoSize = True
        Me.labFreeDateHelpdesk.Location = New System.Drawing.Point(34, 149)
        Me.labFreeDateHelpdesk.Name = "labFreeDateHelpdesk"
        Me.labFreeDateHelpdesk.Size = New System.Drawing.Size(52, 13)
        Me.labFreeDateHelpdesk.TabIndex = 17
        Me.labFreeDateHelpdesk.Text = "Helpdesk"
        '
        'texFreeDateHelpdesk
        '
        Me.texFreeDateHelpdesk.Location = New System.Drawing.Point(138, 146)
        Me.texFreeDateHelpdesk.Name = "texFreeDateHelpdesk"
        Me.texFreeDateHelpdesk.ReadOnly = True
        Me.texFreeDateHelpdesk.Size = New System.Drawing.Size(154, 20)
        Me.texFreeDateHelpdesk.TabIndex = 16
        '
        'labFreeDatePlaning
        '
        Me.labFreeDatePlaning.AutoSize = True
        Me.labFreeDatePlaning.Location = New System.Drawing.Point(34, 201)
        Me.labFreeDatePlaning.Name = "labFreeDatePlaning"
        Me.labFreeDatePlaning.Size = New System.Drawing.Size(64, 13)
        Me.labFreeDatePlaning.TabIndex = 19
        Me.labFreeDatePlaning.Text = "Planification"
        '
        'texFreeDatePlaning
        '
        Me.texFreeDatePlaning.Location = New System.Drawing.Point(138, 198)
        Me.texFreeDatePlaning.Name = "texFreeDatePlaning"
        Me.texFreeDatePlaning.ReadOnly = True
        Me.texFreeDatePlaning.Size = New System.Drawing.Size(154, 20)
        Me.texFreeDatePlaning.TabIndex = 20
        '
        'grpNextFreeDate
        '
        Me.grpNextFreeDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpNextFreeDate.Controls.Add(Me.texFreeDateSAP)
        Me.grpNextFreeDate.Controls.Add(Me.texFreeDatePlaning)
        Me.grpNextFreeDate.Controls.Add(Me.texFreeDateInfra)
        Me.grpNextFreeDate.Controls.Add(Me.labFreeDatePlaning)
        Me.grpNextFreeDate.Controls.Add(Me.labFreeDateInfra)
        Me.grpNextFreeDate.Controls.Add(Me.labFreeDateHelpdesk)
        Me.grpNextFreeDate.Controls.Add(Me.labFreeDateSAP)
        Me.grpNextFreeDate.Controls.Add(Me.texFreeDateHelpdesk)
        Me.grpNextFreeDate.Location = New System.Drawing.Point(682, 603)
        Me.grpNextFreeDate.Name = "grpNextFreeDate"
        Me.grpNextFreeDate.Size = New System.Drawing.Size(374, 266)
        Me.grpNextFreeDate.TabIndex = 21
        Me.grpNextFreeDate.TabStop = False
        Me.grpNextFreeDate.Text = "Prochaine date de libre"
        '
        'btcChart
        '
        Me.btcChart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btcChart.Image = CType(resources.GetObject("btcChart.Image"), System.Drawing.Image)
        Me.btcChart.Location = New System.Drawing.Point(1204, 635)
        Me.btcChart.Name = "btcChart"
        Me.btcChart.Size = New System.Drawing.Size(134, 134)
        Me.btcChart.TabIndex = 22
        Me.btcChart.UseVisualStyleBackColor = True
        '
        'btcExportToExcel
        '
        Me.btcExportToExcel.Location = New System.Drawing.Point(368, 20)
        Me.btcExportToExcel.Name = "btcExportToExcel"
        Me.btcExportToExcel.Size = New System.Drawing.Size(104, 23)
        Me.btcExportToExcel.TabIndex = 23
        Me.btcExportToExcel.Text = "Export vers Excel"
        Me.btcExportToExcel.UseVisualStyleBackColor = True
        '
        'frmDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1577, 896)
        Me.Controls.Add(Me.btcExportToExcel)
        Me.Controls.Add(Me.btcChart)
        Me.Controls.Add(Me.grpNextFreeDate)
        Me.Controls.Add(Me.tabTaskType)
        Me.Controls.Add(Me.btcFermer)
        Me.Controls.Add(Me.texColorTotal)
        Me.Controls.Add(Me.texColorPlaning)
        Me.Controls.Add(Me.texColorHelpdesk)
        Me.Controls.Add(Me.texColorSAP)
        Me.Controls.Add(Me.texColorInfra)
        Me.Controls.Add(Me.dgvProjects)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDashboard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dashboard"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvProjects, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvInfrastructure, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSAP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvHelpdesk, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPlaning, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabTaskType.ResumeLayout(False)
        Me.tabInfrastructure.ResumeLayout(False)
        Me.tabSAP.ResumeLayout(False)
        Me.tabHelpdesk.ResumeLayout(False)
        Me.tabPlaning.ResumeLayout(False)
        Me.grpNextFreeDate.ResumeLayout(False)
        Me.grpNextFreeDate.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvProjects As DataGridView
    Friend WithEvents dgvInfrastructure As DataGridView
    Friend WithEvents dgvSAP As DataGridView
    Friend WithEvents dgvHelpdesk As DataGridView
    Friend WithEvents dgvPlaning As DataGridView
    Friend WithEvents texColorInfra As TextBox
    Friend WithEvents texColorSAP As TextBox
    Friend WithEvents texColorHelpdesk As TextBox
    Friend WithEvents texColorPlaning As TextBox
    Friend WithEvents texColorTotal As TextBox
    Friend WithEvents btcFermer As Button
    Friend WithEvents tabTaskType As TabControl
    Friend WithEvents tabInfrastructure As TabPage
    Friend WithEvents tabSAP As TabPage
    Friend WithEvents tabHelpdesk As TabPage
    Friend WithEvents tabPlaning As TabPage
    Friend WithEvents texFreeDateInfra As TextBox
    Friend WithEvents labFreeDateInfra As Label
    Friend WithEvents labFreeDateSAP As Label
    Friend WithEvents texFreeDateSAP As TextBox
    Friend WithEvents labFreeDateHelpdesk As Label
    Friend WithEvents texFreeDateHelpdesk As TextBox
    Friend WithEvents labFreeDatePlaning As Label
    Friend WithEvents texFreeDatePlaning As TextBox
    Friend WithEvents grpNextFreeDate As GroupBox
    Friend WithEvents btcChart As Button
    Friend WithEvents btcExportToExcel As Button
End Class
