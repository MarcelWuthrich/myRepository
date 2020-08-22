<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmResourceAdminList
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
        Me.lstAdminResources = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'lstAdminResources
        '
        Me.lstAdminResources.FormattingEnabled = True
        Me.lstAdminResources.Location = New System.Drawing.Point(12, 21)
        Me.lstAdminResources.Name = "lstAdminResources"
        Me.lstAdminResources.Size = New System.Drawing.Size(369, 251)
        Me.lstAdminResources.TabIndex = 0
        '
        'frmResourceAdminList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(395, 290)
        Me.Controls.Add(Me.lstAdminResources)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmResourceAdminList"
        Me.Text = "Admin Resources List"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lstAdminResources As ListBox
End Class
