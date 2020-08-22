<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProjectCustomer
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
        Me.labID_Customer = New System.Windows.Forms.Label()
        Me.texID_Customer = New System.Windows.Forms.TextBox()
        Me.chkActive = New System.Windows.Forms.CheckBox()
        Me.labNom = New System.Windows.Forms.Label()
        Me.texNom = New System.Windows.Forms.TextBox()
        Me.btcOK = New System.Windows.Forms.Button()
        Me.btcAnnuler = New System.Windows.Forms.Button()
        Me.labPrenom = New System.Windows.Forms.Label()
        Me.texPrenom = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'labID_Customer
        '
        Me.labID_Customer.AutoSize = True
        Me.labID_Customer.Location = New System.Drawing.Point(32, 27)
        Me.labID_Customer.Name = "labID_Customer"
        Me.labID_Customer.Size = New System.Drawing.Size(18, 13)
        Me.labID_Customer.TabIndex = 55
        Me.labID_Customer.Text = "ID"
        '
        'texID_Customer
        '
        Me.texID_Customer.Location = New System.Drawing.Point(81, 24)
        Me.texID_Customer.Name = "texID_Customer"
        Me.texID_Customer.ReadOnly = True
        Me.texID_Customer.Size = New System.Drawing.Size(56, 20)
        Me.texID_Customer.TabIndex = 54
        '
        'chkActive
        '
        Me.chkActive.AutoSize = True
        Me.chkActive.Location = New System.Drawing.Point(81, 103)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.Size = New System.Drawing.Size(56, 17)
        Me.chkActive.TabIndex = 49
        Me.chkActive.Text = "Activé"
        Me.chkActive.UseVisualStyleBackColor = True
        '
        'labNom
        '
        Me.labNom.AutoSize = True
        Me.labNom.Location = New System.Drawing.Point(32, 80)
        Me.labNom.Name = "labNom"
        Me.labNom.Size = New System.Drawing.Size(29, 13)
        Me.labNom.TabIndex = 53
        Me.labNom.Text = "Nom"
        '
        'texNom
        '
        Me.texNom.Location = New System.Drawing.Point(81, 77)
        Me.texNom.Name = "texNom"
        Me.texNom.Size = New System.Drawing.Size(213, 20)
        Me.texNom.TabIndex = 48
        '
        'btcOK
        '
        Me.btcOK.Location = New System.Drawing.Point(219, 166)
        Me.btcOK.Name = "btcOK"
        Me.btcOK.Size = New System.Drawing.Size(75, 23)
        Me.btcOK.TabIndex = 51
        Me.btcOK.Text = "OK"
        Me.btcOK.UseVisualStyleBackColor = True
        '
        'btcAnnuler
        '
        Me.btcAnnuler.Location = New System.Drawing.Point(81, 166)
        Me.btcAnnuler.Name = "btcAnnuler"
        Me.btcAnnuler.Size = New System.Drawing.Size(75, 23)
        Me.btcAnnuler.TabIndex = 50
        Me.btcAnnuler.Text = "Annuler"
        Me.btcAnnuler.UseVisualStyleBackColor = True
        '
        'labPrenom
        '
        Me.labPrenom.AutoSize = True
        Me.labPrenom.Location = New System.Drawing.Point(32, 54)
        Me.labPrenom.Name = "labPrenom"
        Me.labPrenom.Size = New System.Drawing.Size(43, 13)
        Me.labPrenom.TabIndex = 52
        Me.labPrenom.Text = "Prénom"
        '
        'texPrenom
        '
        Me.texPrenom.Location = New System.Drawing.Point(81, 51)
        Me.texPrenom.Name = "texPrenom"
        Me.texPrenom.Size = New System.Drawing.Size(213, 20)
        Me.texPrenom.TabIndex = 47
        '
        'frmProjectCustomer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(403, 259)
        Me.Controls.Add(Me.labID_Customer)
        Me.Controls.Add(Me.texID_Customer)
        Me.Controls.Add(Me.chkActive)
        Me.Controls.Add(Me.labNom)
        Me.Controls.Add(Me.texNom)
        Me.Controls.Add(Me.btcOK)
        Me.Controls.Add(Me.btcAnnuler)
        Me.Controls.Add(Me.labPrenom)
        Me.Controls.Add(Me.texPrenom)
        Me.Name = "frmProjectCustomer"
        Me.Text = "Détails des commanditaires"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents labID_Customer As Label
    Friend WithEvents texID_Customer As TextBox
    Friend WithEvents chkActive As CheckBox
    Friend WithEvents labNom As Label
    Friend WithEvents texNom As TextBox
    Friend WithEvents btcOK As Button
    Friend WithEvents btcAnnuler As Button
    Friend WithEvents labPrenom As Label
    Friend WithEvents texPrenom As TextBox
End Class
