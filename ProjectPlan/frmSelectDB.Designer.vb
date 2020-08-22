<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectDB
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSelectDB))
        Me.btcConnect = New System.Windows.Forms.Button()
        Me.grpDatabase = New System.Windows.Forms.GroupBox()
        Me.labOKNOK = New System.Windows.Forms.Label()
        Me.btcTestConnexion = New System.Windows.Forms.Button()
        Me.labPassword = New System.Windows.Forms.Label()
        Me.texPassword = New System.Windows.Forms.TextBox()
        Me.labUsername = New System.Windows.Forms.Label()
        Me.texUsername = New System.Windows.Forms.TextBox()
        Me.labServerName = New System.Windows.Forms.Label()
        Me.texServerName = New System.Windows.Forms.TextBox()
        Me.labDatabaseName = New System.Windows.Forms.Label()
        Me.texDatabaseName = New System.Windows.Forms.TextBox()
        Me.lovDB = New System.Windows.Forms.ComboBox()
        Me.grpDatabase.SuspendLayout()
        Me.SuspendLayout()
        '
        'btcConnect
        '
        Me.btcConnect.Location = New System.Drawing.Point(170, 185)
        Me.btcConnect.Name = "btcConnect"
        Me.btcConnect.Size = New System.Drawing.Size(125, 23)
        Me.btcConnect.TabIndex = 3
        Me.btcConnect.Text = "Connect"
        Me.btcConnect.UseVisualStyleBackColor = True
        '
        'grpDatabase
        '
        Me.grpDatabase.Controls.Add(Me.labOKNOK)
        Me.grpDatabase.Controls.Add(Me.btcTestConnexion)
        Me.grpDatabase.Controls.Add(Me.labPassword)
        Me.grpDatabase.Controls.Add(Me.texPassword)
        Me.grpDatabase.Controls.Add(Me.labUsername)
        Me.grpDatabase.Controls.Add(Me.texUsername)
        Me.grpDatabase.Controls.Add(Me.labServerName)
        Me.grpDatabase.Controls.Add(Me.texServerName)
        Me.grpDatabase.Controls.Add(Me.labDatabaseName)
        Me.grpDatabase.Controls.Add(Me.texDatabaseName)
        Me.grpDatabase.Controls.Add(Me.lovDB)
        Me.grpDatabase.Controls.Add(Me.btcConnect)
        Me.grpDatabase.Location = New System.Drawing.Point(12, 12)
        Me.grpDatabase.Name = "grpDatabase"
        Me.grpDatabase.Size = New System.Drawing.Size(353, 238)
        Me.grpDatabase.TabIndex = 4
        Me.grpDatabase.TabStop = False
        Me.grpDatabase.Text = "Select Database"
        '
        'labOKNOK
        '
        Me.labOKNOK.AutoSize = True
        Me.labOKNOK.Location = New System.Drawing.Point(111, 190)
        Me.labOKNOK.Name = "labOKNOK"
        Me.labOKNOK.Size = New System.Drawing.Size(22, 13)
        Me.labOKNOK.TabIndex = 14
        Me.labOKNOK.Text = "OK"
        '
        'btcTestConnexion
        '
        Me.btcTestConnexion.Location = New System.Drawing.Point(9, 185)
        Me.btcTestConnexion.Name = "btcTestConnexion"
        Me.btcTestConnexion.Size = New System.Drawing.Size(96, 23)
        Me.btcTestConnexion.TabIndex = 13
        Me.btcTestConnexion.Text = "Test connexion"
        Me.btcTestConnexion.UseVisualStyleBackColor = True
        '
        'labPassword
        '
        Me.labPassword.AutoSize = True
        Me.labPassword.Location = New System.Drawing.Point(6, 147)
        Me.labPassword.Name = "labPassword"
        Me.labPassword.Size = New System.Drawing.Size(53, 13)
        Me.labPassword.TabIndex = 12
        Me.labPassword.Text = "Password"
        '
        'texPassword
        '
        Me.texPassword.Location = New System.Drawing.Point(130, 144)
        Me.texPassword.Name = "texPassword"
        Me.texPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.texPassword.Size = New System.Drawing.Size(165, 20)
        Me.texPassword.TabIndex = 11
        '
        'labUsername
        '
        Me.labUsername.AutoSize = True
        Me.labUsername.Location = New System.Drawing.Point(6, 121)
        Me.labUsername.Name = "labUsername"
        Me.labUsername.Size = New System.Drawing.Size(55, 13)
        Me.labUsername.TabIndex = 10
        Me.labUsername.Text = "Username"
        '
        'texUsername
        '
        Me.texUsername.Location = New System.Drawing.Point(130, 118)
        Me.texUsername.Name = "texUsername"
        Me.texUsername.Size = New System.Drawing.Size(165, 20)
        Me.texUsername.TabIndex = 9
        '
        'labServerName
        '
        Me.labServerName.AutoSize = True
        Me.labServerName.Location = New System.Drawing.Point(6, 95)
        Me.labServerName.Name = "labServerName"
        Me.labServerName.Size = New System.Drawing.Size(118, 13)
        Me.labServerName.TabIndex = 8
        Me.labServerName.Text = "Server / instance name"
        '
        'texServerName
        '
        Me.texServerName.Location = New System.Drawing.Point(130, 92)
        Me.texServerName.Name = "texServerName"
        Me.texServerName.Size = New System.Drawing.Size(165, 20)
        Me.texServerName.TabIndex = 7
        '
        'labDatabaseName
        '
        Me.labDatabaseName.AutoSize = True
        Me.labDatabaseName.Location = New System.Drawing.Point(6, 69)
        Me.labDatabaseName.Name = "labDatabaseName"
        Me.labDatabaseName.Size = New System.Drawing.Size(82, 13)
        Me.labDatabaseName.TabIndex = 6
        Me.labDatabaseName.Text = "Database name"
        '
        'texDatabaseName
        '
        Me.texDatabaseName.Location = New System.Drawing.Point(130, 66)
        Me.texDatabaseName.Name = "texDatabaseName"
        Me.texDatabaseName.Size = New System.Drawing.Size(165, 20)
        Me.texDatabaseName.TabIndex = 5
        '
        'lovDB
        '
        Me.lovDB.FormattingEnabled = True
        Me.lovDB.Location = New System.Drawing.Point(6, 29)
        Me.lovDB.Name = "lovDB"
        Me.lovDB.Size = New System.Drawing.Size(289, 21)
        Me.lovDB.TabIndex = 4
        '
        'frmSelectDB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(406, 284)
        Me.Controls.Add(Me.grpDatabase)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSelectDB"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ProjectPlan - Database"
        Me.grpDatabase.ResumeLayout(False)
        Me.grpDatabase.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btcConnect As Button
    Friend WithEvents grpDatabase As GroupBox
    Friend WithEvents lovDB As ComboBox
    Friend WithEvents labServerName As Label
    Friend WithEvents texServerName As TextBox
    Friend WithEvents labDatabaseName As Label
    Friend WithEvents texDatabaseName As TextBox
    Friend WithEvents labUsername As Label
    Friend WithEvents texUsername As TextBox
    Friend WithEvents labPassword As Label
    Private WithEvents texPassword As TextBox
    Friend WithEvents btcTestConnexion As Button
    Friend WithEvents labOKNOK As Label
End Class
