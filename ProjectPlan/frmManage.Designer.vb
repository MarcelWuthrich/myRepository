<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManage
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmManage))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btcValidate = New System.Windows.Forms.Button()
        Me.btcFermer = New System.Windows.Forms.Button()
        Me.grpResources = New System.Windows.Forms.GroupBox()
        Me.lstPlanResources = New System.Windows.Forms.ListBox()
        Me.dptDateTo = New System.Windows.Forms.DateTimePicker()
        Me.chkDateTo = New System.Windows.Forms.CheckBox()
        Me.btcCheckDouble = New System.Windows.Forms.Button()
        Me.grpResources.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(141, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Valider toutes les ressources"
        '
        'btcValidate
        '
        Me.btcValidate.Location = New System.Drawing.Point(522, 23)
        Me.btcValidate.Name = "btcValidate"
        Me.btcValidate.Size = New System.Drawing.Size(75, 23)
        Me.btcValidate.TabIndex = 6
        Me.btcValidate.Text = "Valider"
        Me.btcValidate.UseVisualStyleBackColor = True
        '
        'btcFermer
        '
        Me.btcFermer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btcFermer.Location = New System.Drawing.Point(764, 97)
        Me.btcFermer.Name = "btcFermer"
        Me.btcFermer.Size = New System.Drawing.Size(75, 23)
        Me.btcFermer.TabIndex = 8
        Me.btcFermer.Text = "Fermer"
        Me.btcFermer.UseVisualStyleBackColor = True
        '
        'grpResources
        '
        Me.grpResources.Controls.Add(Me.lstPlanResources)
        Me.grpResources.Controls.Add(Me.dptDateTo)
        Me.grpResources.Controls.Add(Me.chkDateTo)
        Me.grpResources.Controls.Add(Me.btcValidate)
        Me.grpResources.Controls.Add(Me.Label3)
        Me.grpResources.Location = New System.Drawing.Point(40, 22)
        Me.grpResources.Name = "grpResources"
        Me.grpResources.Size = New System.Drawing.Size(626, 366)
        Me.grpResources.TabIndex = 11
        Me.grpResources.TabStop = False
        Me.grpResources.Text = "Ressources"
        '
        'lstPlanResources
        '
        Me.lstPlanResources.FormattingEnabled = True
        Me.lstPlanResources.Location = New System.Drawing.Point(9, 75)
        Me.lstPlanResources.Name = "lstPlanResources"
        Me.lstPlanResources.Size = New System.Drawing.Size(588, 264)
        Me.lstPlanResources.TabIndex = 11
        '
        'dptDateTo
        '
        Me.dptDateTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dptDateTo.Location = New System.Drawing.Point(323, 22)
        Me.dptDateTo.Name = "dptDateTo"
        Me.dptDateTo.Size = New System.Drawing.Size(143, 20)
        Me.dptDateTo.TabIndex = 10
        '
        'chkDateTo
        '
        Me.chkDateTo.AutoSize = True
        Me.chkDateTo.Location = New System.Drawing.Point(183, 27)
        Me.chkDateTo.Name = "chkDateTo"
        Me.chkDateTo.Size = New System.Drawing.Size(125, 17)
        Me.chkDateTo.TabIndex = 9
        Me.chkDateTo.Text = "Uniquement jusqu'au"
        Me.chkDateTo.UseVisualStyleBackColor = True
        '
        'btcCheckDouble
        '
        Me.btcCheckDouble.Location = New System.Drawing.Point(764, 191)
        Me.btcCheckDouble.Name = "btcCheckDouble"
        Me.btcCheckDouble.Size = New System.Drawing.Size(75, 23)
        Me.btcCheckDouble.TabIndex = 13
        Me.btcCheckDouble.Text = "Doublons"
        Me.btcCheckDouble.UseVisualStyleBackColor = True
        Me.btcCheckDouble.Visible = False
        '
        'frmManage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(937, 563)
        Me.Controls.Add(Me.btcCheckDouble)
        Me.Controls.Add(Me.grpResources)
        Me.Controls.Add(Me.btcFermer)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmManage"
        Me.Text = "Gestion"
        Me.grpResources.ResumeLayout(False)
        Me.grpResources.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label3 As Label
    Friend WithEvents btcValidate As Button
    Friend WithEvents btcFermer As Button
    Friend WithEvents grpResources As GroupBox
    Friend WithEvents dptDateTo As DateTimePicker
    Friend WithEvents chkDateTo As CheckBox
    Friend WithEvents btcCheckDouble As Button
    Friend WithEvents lstPlanResources As ListBox
End Class
