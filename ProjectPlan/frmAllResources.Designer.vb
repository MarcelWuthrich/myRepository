<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAllResources
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
        Me.dgvResources = New System.Windows.Forms.DataGridView()
        Me.grpFiltre = New System.Windows.Forms.GroupBox()
        Me.btcDisplay = New System.Windows.Forms.Button()
        Me.lovYear = New System.Windows.Forms.ComboBox()
        Me.lovMonth = New System.Windows.Forms.ComboBox()
        Me.btcClose = New System.Windows.Forms.Button()
        CType(Me.dgvResources, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFiltre.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvResources
        '
        Me.dgvResources.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvResources.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResources.Location = New System.Drawing.Point(62, 111)
        Me.dgvResources.Name = "dgvResources"
        Me.dgvResources.Size = New System.Drawing.Size(1427, 788)
        Me.dgvResources.TabIndex = 0
        '
        'grpFiltre
        '
        Me.grpFiltre.Controls.Add(Me.btcDisplay)
        Me.grpFiltre.Controls.Add(Me.lovYear)
        Me.grpFiltre.Controls.Add(Me.lovMonth)
        Me.grpFiltre.Location = New System.Drawing.Point(62, 37)
        Me.grpFiltre.Name = "grpFiltre"
        Me.grpFiltre.Size = New System.Drawing.Size(420, 49)
        Me.grpFiltre.TabIndex = 1
        Me.grpFiltre.TabStop = False
        Me.grpFiltre.Text = "Filtre"
        '
        'btcDisplay
        '
        Me.btcDisplay.Location = New System.Drawing.Point(322, 20)
        Me.btcDisplay.Name = "btcDisplay"
        Me.btcDisplay.Size = New System.Drawing.Size(75, 23)
        Me.btcDisplay.TabIndex = 2
        Me.btcDisplay.Text = "Affiche"
        Me.btcDisplay.UseVisualStyleBackColor = True
        '
        'lovYear
        '
        Me.lovYear.FormattingEnabled = True
        Me.lovYear.Location = New System.Drawing.Point(171, 19)
        Me.lovYear.Name = "lovYear"
        Me.lovYear.Size = New System.Drawing.Size(121, 21)
        Me.lovYear.TabIndex = 1
        '
        'lovMonth
        '
        Me.lovMonth.FormattingEnabled = True
        Me.lovMonth.Location = New System.Drawing.Point(31, 19)
        Me.lovMonth.Name = "lovMonth"
        Me.lovMonth.Size = New System.Drawing.Size(121, 21)
        Me.lovMonth.TabIndex = 0
        '
        'btcClose
        '
        Me.btcClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btcClose.Location = New System.Drawing.Point(1414, 54)
        Me.btcClose.Name = "btcClose"
        Me.btcClose.Size = New System.Drawing.Size(75, 23)
        Me.btcClose.TabIndex = 2
        Me.btcClose.Text = "Fermer"
        Me.btcClose.UseVisualStyleBackColor = True
        '
        'frmAllResources
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1668, 923)
        Me.Controls.Add(Me.btcClose)
        Me.Controls.Add(Me.grpFiltre)
        Me.Controls.Add(Me.dgvResources)
        Me.Name = "frmAllResources"
        Me.Text = "Ressources planifiées et exécutées"
        CType(Me.dgvResources, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFiltre.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvResources As DataGridView
    Friend WithEvents grpFiltre As GroupBox
    Friend WithEvents lovYear As ComboBox
    Friend WithEvents lovMonth As ComboBox
    Friend WithEvents btcClose As Button
    Friend WithEvents btcDisplay As Button
End Class
