<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmProjectRemarks
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProjectRemarks))
        Me.dgvProjectRemarks = New System.Windows.Forms.DataGridView()
        Me.btcFermer = New System.Windows.Forms.Button()
        Me.btcModify = New System.Windows.Forms.Button()
        Me.btcAdd = New System.Windows.Forms.Button()
        CType(Me.dgvProjectRemarks, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvProjectRemarks
        '
        Me.dgvProjectRemarks.AllowUserToAddRows = False
        Me.dgvProjectRemarks.AllowUserToDeleteRows = False
        Me.dgvProjectRemarks.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvProjectRemarks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProjectRemarks.Location = New System.Drawing.Point(31, 54)
        Me.dgvProjectRemarks.Name = "dgvProjectRemarks"
        Me.dgvProjectRemarks.Size = New System.Drawing.Size(642, 346)
        Me.dgvProjectRemarks.TabIndex = 0
        '
        'btcFermer
        '
        Me.btcFermer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btcFermer.Location = New System.Drawing.Point(742, 137)
        Me.btcFermer.Name = "btcFermer"
        Me.btcFermer.Size = New System.Drawing.Size(141, 23)
        Me.btcFermer.TabIndex = 1
        Me.btcFermer.Text = "Fermer"
        Me.btcFermer.UseVisualStyleBackColor = True
        '
        'btcModify
        '
        Me.btcModify.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btcModify.Location = New System.Drawing.Point(742, 96)
        Me.btcModify.Name = "btcModify"
        Me.btcModify.Size = New System.Drawing.Size(141, 23)
        Me.btcModify.TabIndex = 2
        Me.btcModify.Text = "Modifier"
        Me.btcModify.UseVisualStyleBackColor = True
        '
        'btcAdd
        '
        Me.btcAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btcAdd.Location = New System.Drawing.Point(742, 54)
        Me.btcAdd.Name = "btcAdd"
        Me.btcAdd.Size = New System.Drawing.Size(141, 23)
        Me.btcAdd.TabIndex = 3
        Me.btcAdd.Text = "Ajouter"
        Me.btcAdd.UseVisualStyleBackColor = True
        '
        'frmProjectRemarks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(932, 467)
        Me.Controls.Add(Me.btcAdd)
        Me.Controls.Add(Me.btcModify)
        Me.Controls.Add(Me.btcFermer)
        Me.Controls.Add(Me.dgvProjectRemarks)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmProjectRemarks"
        Me.Text = "Commentaires"
        CType(Me.dgvProjectRemarks, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvProjectRemarks As DataGridView
    Friend WithEvents btcFermer As Button
    Friend WithEvents btcModify As Button
    Friend WithEvents btcAdd As Button
End Class
