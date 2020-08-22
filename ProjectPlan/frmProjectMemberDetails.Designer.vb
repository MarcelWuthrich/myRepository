<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProjectMemberDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProjectMemberDetails))
        Me.labID_ProjectMember = New System.Windows.Forms.Label()
        Me.texID_ProjectMember = New System.Windows.Forms.TextBox()
        Me.chkActive = New System.Windows.Forms.CheckBox()
        Me.labNom = New System.Windows.Forms.Label()
        Me.texNom = New System.Windows.Forms.TextBox()
        Me.btcOK = New System.Windows.Forms.Button()
        Me.btcAnnuler = New System.Windows.Forms.Button()
        Me.labPrenom = New System.Windows.Forms.Label()
        Me.texPrenom = New System.Windows.Forms.TextBox()
        Me.lovTasks = New System.Windows.Forms.ComboBox()
        Me.labTache = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'labID_ProjectMember
        '
        Me.labID_ProjectMember.AutoSize = True
        Me.labID_ProjectMember.Location = New System.Drawing.Point(35, 30)
        Me.labID_ProjectMember.Name = "labID_ProjectMember"
        Me.labID_ProjectMember.Size = New System.Drawing.Size(18, 13)
        Me.labID_ProjectMember.TabIndex = 46
        Me.labID_ProjectMember.Text = "ID"
        '
        'texID_ProjectMember
        '
        Me.texID_ProjectMember.Location = New System.Drawing.Point(84, 27)
        Me.texID_ProjectMember.Name = "texID_ProjectMember"
        Me.texID_ProjectMember.ReadOnly = True
        Me.texID_ProjectMember.Size = New System.Drawing.Size(56, 20)
        Me.texID_ProjectMember.TabIndex = 45
        '
        'chkActive
        '
        Me.chkActive.AutoSize = True
        Me.chkActive.Location = New System.Drawing.Point(84, 132)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.Size = New System.Drawing.Size(56, 17)
        Me.chkActive.TabIndex = 40
        Me.chkActive.Text = "Activé"
        Me.chkActive.UseVisualStyleBackColor = True
        '
        'labNom
        '
        Me.labNom.AutoSize = True
        Me.labNom.Location = New System.Drawing.Point(35, 83)
        Me.labNom.Name = "labNom"
        Me.labNom.Size = New System.Drawing.Size(29, 13)
        Me.labNom.TabIndex = 44
        Me.labNom.Text = "Nom"
        '
        'texNom
        '
        Me.texNom.Location = New System.Drawing.Point(84, 80)
        Me.texNom.Name = "texNom"
        Me.texNom.Size = New System.Drawing.Size(213, 20)
        Me.texNom.TabIndex = 39
        '
        'btcOK
        '
        Me.btcOK.Location = New System.Drawing.Point(222, 169)
        Me.btcOK.Name = "btcOK"
        Me.btcOK.Size = New System.Drawing.Size(75, 23)
        Me.btcOK.TabIndex = 42
        Me.btcOK.Text = "OK"
        Me.btcOK.UseVisualStyleBackColor = True
        '
        'btcAnnuler
        '
        Me.btcAnnuler.Location = New System.Drawing.Point(84, 169)
        Me.btcAnnuler.Name = "btcAnnuler"
        Me.btcAnnuler.Size = New System.Drawing.Size(75, 23)
        Me.btcAnnuler.TabIndex = 41
        Me.btcAnnuler.Text = "Annuler"
        Me.btcAnnuler.UseVisualStyleBackColor = True
        '
        'labPrenom
        '
        Me.labPrenom.AutoSize = True
        Me.labPrenom.Location = New System.Drawing.Point(35, 57)
        Me.labPrenom.Name = "labPrenom"
        Me.labPrenom.Size = New System.Drawing.Size(43, 13)
        Me.labPrenom.TabIndex = 43
        Me.labPrenom.Text = "Prénom"
        '
        'texPrenom
        '
        Me.texPrenom.Location = New System.Drawing.Point(84, 54)
        Me.texPrenom.Name = "texPrenom"
        Me.texPrenom.Size = New System.Drawing.Size(213, 20)
        Me.texPrenom.TabIndex = 38
        '
        'lovTasks
        '
        Me.lovTasks.FormattingEnabled = True
        Me.lovTasks.Location = New System.Drawing.Point(84, 107)
        Me.lovTasks.Name = "lovTasks"
        Me.lovTasks.Size = New System.Drawing.Size(213, 21)
        Me.lovTasks.TabIndex = 47
        '
        'labTache
        '
        Me.labTache.AutoSize = True
        Me.labTache.Location = New System.Drawing.Point(35, 110)
        Me.labTache.Name = "labTache"
        Me.labTache.Size = New System.Drawing.Size(38, 13)
        Me.labTache.TabIndex = 48
        Me.labTache.Text = "Tâche"
        '
        'frmProjectMemberDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(418, 270)
        Me.Controls.Add(Me.labTache)
        Me.Controls.Add(Me.lovTasks)
        Me.Controls.Add(Me.labID_ProjectMember)
        Me.Controls.Add(Me.texID_ProjectMember)
        Me.Controls.Add(Me.chkActive)
        Me.Controls.Add(Me.labNom)
        Me.Controls.Add(Me.texNom)
        Me.Controls.Add(Me.btcOK)
        Me.Controls.Add(Me.btcAnnuler)
        Me.Controls.Add(Me.labPrenom)
        Me.Controls.Add(Me.texPrenom)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmProjectMemberDetails"
        Me.Text = "Détails des membres des projets"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents labID_ProjectMember As Label
    Friend WithEvents texID_ProjectMember As TextBox
    Friend WithEvents chkActive As CheckBox
    Friend WithEvents labNom As Label
    Friend WithEvents texNom As TextBox
    Friend WithEvents btcOK As Button
    Friend WithEvents btcAnnuler As Button
    Friend WithEvents labPrenom As Label
    Friend WithEvents texPrenom As TextBox
    Friend WithEvents lovTasks As ComboBox
    Friend WithEvents labTache As Label
End Class
