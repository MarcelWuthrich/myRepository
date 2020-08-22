<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProjectAddEstimateRessource
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
        Me.lovTasks = New System.Windows.Forms.ComboBox()
        Me.labTask = New System.Windows.Forms.Label()
        Me.labDaysNumber = New System.Windows.Forms.Label()
        Me.texDaysNumber = New System.Windows.Forms.TextBox()
        Me.btcOK = New System.Windows.Forms.Button()
        Me.btcAnnuler = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lovTasks
        '
        Me.lovTasks.FormattingEnabled = True
        Me.lovTasks.Location = New System.Drawing.Point(96, 18)
        Me.lovTasks.Name = "lovTasks"
        Me.lovTasks.Size = New System.Drawing.Size(121, 21)
        Me.lovTasks.TabIndex = 0
        '
        'labTask
        '
        Me.labTask.AutoSize = True
        Me.labTask.Location = New System.Drawing.Point(12, 21)
        Me.labTask.Name = "labTask"
        Me.labTask.Size = New System.Drawing.Size(38, 13)
        Me.labTask.TabIndex = 1
        Me.labTask.Text = "Tâche"
        '
        'labDaysNumber
        '
        Me.labDaysNumber.AutoSize = True
        Me.labDaysNumber.Location = New System.Drawing.Point(12, 53)
        Me.labDaysNumber.Name = "labDaysNumber"
        Me.labDaysNumber.Size = New System.Drawing.Size(70, 13)
        Me.labDaysNumber.TabIndex = 2
        Me.labDaysNumber.Text = "Nbre de jours"
        '
        'texDaysNumber
        '
        Me.texDaysNumber.Location = New System.Drawing.Point(96, 50)
        Me.texDaysNumber.Name = "texDaysNumber"
        Me.texDaysNumber.Size = New System.Drawing.Size(121, 20)
        Me.texDaysNumber.TabIndex = 3
        Me.texDaysNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btcOK
        '
        Me.btcOK.Location = New System.Drawing.Point(261, 18)
        Me.btcOK.Name = "btcOK"
        Me.btcOK.Size = New System.Drawing.Size(75, 23)
        Me.btcOK.TabIndex = 4
        Me.btcOK.Text = "OK"
        Me.btcOK.UseVisualStyleBackColor = True
        '
        'btcAnnuler
        '
        Me.btcAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btcAnnuler.Location = New System.Drawing.Point(261, 47)
        Me.btcAnnuler.Name = "btcAnnuler"
        Me.btcAnnuler.Size = New System.Drawing.Size(75, 23)
        Me.btcAnnuler.TabIndex = 5
        Me.btcAnnuler.Text = "Annuler"
        Me.btcAnnuler.UseVisualStyleBackColor = True
        '
        'frmProjectAddEstimateRessource
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btcAnnuler
        Me.ClientSize = New System.Drawing.Size(353, 96)
        Me.Controls.Add(Me.btcAnnuler)
        Me.Controls.Add(Me.btcOK)
        Me.Controls.Add(Me.texDaysNumber)
        Me.Controls.Add(Me.labDaysNumber)
        Me.Controls.Add(Me.labTask)
        Me.Controls.Add(Me.lovTasks)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProjectAddEstimateRessource"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ajout d'une estimation de ressources"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lovTasks As ComboBox
    Friend WithEvents labTask As Label
    Friend WithEvents labDaysNumber As Label
    Friend WithEvents texDaysNumber As TextBox
    Friend WithEvents btcOK As Button
    Friend WithEvents btcAnnuler As Button
End Class
