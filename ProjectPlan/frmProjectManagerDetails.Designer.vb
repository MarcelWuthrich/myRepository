<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProjectManagerDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProjectManagerDetails))
        Me.btcOK = New System.Windows.Forms.Button()
        Me.btcAnnuler = New System.Windows.Forms.Button()
        Me.labPrenom = New System.Windows.Forms.Label()
        Me.texPrenom = New System.Windows.Forms.TextBox()
        Me.labNom = New System.Windows.Forms.Label()
        Me.texNom = New System.Windows.Forms.TextBox()
        Me.chkActive = New System.Windows.Forms.CheckBox()
        Me.labID_ProjectManger = New System.Windows.Forms.Label()
        Me.texID_ProjectManager = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btcOK
        '
        Me.btcOK.Location = New System.Drawing.Point(227, 154)
        Me.btcOK.Name = "btcOK"
        Me.btcOK.Size = New System.Drawing.Size(75, 23)
        Me.btcOK.TabIndex = 5
        Me.btcOK.Text = "OK"
        Me.btcOK.UseVisualStyleBackColor = True
        '
        'btcAnnuler
        '
        Me.btcAnnuler.Location = New System.Drawing.Point(89, 154)
        Me.btcAnnuler.Name = "btcAnnuler"
        Me.btcAnnuler.Size = New System.Drawing.Size(75, 23)
        Me.btcAnnuler.TabIndex = 4
        Me.btcAnnuler.Text = "Annuler"
        Me.btcAnnuler.UseVisualStyleBackColor = True
        '
        'labPrenom
        '
        Me.labPrenom.AutoSize = True
        Me.labPrenom.Location = New System.Drawing.Point(40, 42)
        Me.labPrenom.Name = "labPrenom"
        Me.labPrenom.Size = New System.Drawing.Size(43, 13)
        Me.labPrenom.TabIndex = 20
        Me.labPrenom.Text = "Prénom"
        '
        'texPrenom
        '
        Me.texPrenom.Location = New System.Drawing.Point(89, 39)
        Me.texPrenom.Name = "texPrenom"
        Me.texPrenom.Size = New System.Drawing.Size(213, 20)
        Me.texPrenom.TabIndex = 1
        '
        'labNom
        '
        Me.labNom.AutoSize = True
        Me.labNom.Location = New System.Drawing.Point(40, 68)
        Me.labNom.Name = "labNom"
        Me.labNom.Size = New System.Drawing.Size(29, 13)
        Me.labNom.TabIndex = 34
        Me.labNom.Text = "Nom"
        '
        'texNom
        '
        Me.texNom.Location = New System.Drawing.Point(89, 65)
        Me.texNom.Name = "texNom"
        Me.texNom.Size = New System.Drawing.Size(213, 20)
        Me.texNom.TabIndex = 2
        '
        'chkActive
        '
        Me.chkActive.AutoSize = True
        Me.chkActive.Location = New System.Drawing.Point(89, 91)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.Size = New System.Drawing.Size(56, 17)
        Me.chkActive.TabIndex = 3
        Me.chkActive.Text = "Activé"
        Me.chkActive.UseVisualStyleBackColor = True
        '
        'labID_ProjectManger
        '
        Me.labID_ProjectManger.AutoSize = True
        Me.labID_ProjectManger.Location = New System.Drawing.Point(40, 15)
        Me.labID_ProjectManger.Name = "labID_ProjectManger"
        Me.labID_ProjectManger.Size = New System.Drawing.Size(18, 13)
        Me.labID_ProjectManger.TabIndex = 37
        Me.labID_ProjectManger.Text = "ID"
        '
        'texID_ProjectManager
        '
        Me.texID_ProjectManager.Location = New System.Drawing.Point(89, 12)
        Me.texID_ProjectManager.Name = "texID_ProjectManager"
        Me.texID_ProjectManager.ReadOnly = True
        Me.texID_ProjectManager.Size = New System.Drawing.Size(56, 20)
        Me.texID_ProjectManager.TabIndex = 36
        '
        'frmProjectManagerDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(376, 227)
        Me.Controls.Add(Me.labID_ProjectManger)
        Me.Controls.Add(Me.texID_ProjectManager)
        Me.Controls.Add(Me.chkActive)
        Me.Controls.Add(Me.labNom)
        Me.Controls.Add(Me.texNom)
        Me.Controls.Add(Me.btcOK)
        Me.Controls.Add(Me.btcAnnuler)
        Me.Controls.Add(Me.labPrenom)
        Me.Controls.Add(Me.texPrenom)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmProjectManagerDetails"
        Me.Text = "Détails du chef de projet"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btcOK As Button
    Friend WithEvents btcAnnuler As Button
    Friend WithEvents labPrenom As Label
    Friend WithEvents texPrenom As TextBox
    Friend WithEvents labNom As Label
    Friend WithEvents texNom As TextBox
    Friend WithEvents chkActive As CheckBox
    Friend WithEvents labID_ProjectManger As Label
    Friend WithEvents texID_ProjectManager As TextBox
End Class
