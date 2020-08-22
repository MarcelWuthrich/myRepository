<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmResourceProjectList
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
        Me.lstProjectResources = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'lstProjectResources
        '
        Me.lstProjectResources.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstProjectResources.FormattingEnabled = True
        Me.lstProjectResources.Location = New System.Drawing.Point(12, 21)
        Me.lstProjectResources.Name = "lstProjectResources"
        Me.lstProjectResources.Size = New System.Drawing.Size(369, 251)
        Me.lstProjectResources.TabIndex = 1
        '
        'frmResourceProjectList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(395, 290)
        Me.Controls.Add(Me.lstProjectResources)
        Me.Name = "frmResourceProjectList"
        Me.Text = "Project Resources List"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lstProjectResources As ListBox
End Class
