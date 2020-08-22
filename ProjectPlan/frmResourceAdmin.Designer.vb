<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmResourceAdmin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmResourceAdmin))
        Me.btcPlan = New System.Windows.Forms.Button()
        Me.btcFermer = New System.Windows.Forms.Button()
        Me.labProjectMember = New System.Windows.Forms.Label()
        Me.labAdminResource = New System.Windows.Forms.Label()
        Me.grpSchedule = New System.Windows.Forms.GroupBox()
        Me.radWeekly = New System.Windows.Forms.RadioButton()
        Me.radDaily = New System.Windows.Forms.RadioButton()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.grpWeekly = New System.Windows.Forms.GroupBox()
        Me.texNumberOfWeeks = New System.Windows.Forms.TextBox()
        Me.chkMonday = New System.Windows.Forms.CheckBox()
        Me.labNumberOfWeeks = New System.Windows.Forms.Label()
        Me.chkTuesday = New System.Windows.Forms.CheckBox()
        Me.chkWednesday = New System.Windows.Forms.CheckBox()
        Me.chkSunday = New System.Windows.Forms.CheckBox()
        Me.chkThursday = New System.Windows.Forms.CheckBox()
        Me.chkSaturday = New System.Windows.Forms.CheckBox()
        Me.chkFriday = New System.Windows.Forms.CheckBox()
        Me.grpDaily = New System.Windows.Forms.GroupBox()
        Me.radDays = New System.Windows.Forms.RadioButton()
        Me.radWeekDays = New System.Windows.Forms.RadioButton()
        Me.texNumberOfDays = New System.Windows.Forms.TextBox()
        Me.labNumberOfDays = New System.Windows.Forms.Label()
        Me.lstAdminResources = New System.Windows.Forms.ListBox()
        Me.lstProjectMember = New System.Windows.Forms.ListBox()
        Me.btcPlanFree = New System.Windows.Forms.Button()
        Me.chkAM = New System.Windows.Forms.CheckBox()
        Me.chkPM = New System.Windows.Forms.CheckBox()
        Me.chkWeekAM = New System.Windows.Forms.CheckBox()
        Me.chkWeekPM = New System.Windows.Forms.CheckBox()
        Me.grpSchedule.SuspendLayout()
        Me.grpWeekly.SuspendLayout()
        Me.grpDaily.SuspendLayout()
        Me.SuspendLayout()
        '
        'btcPlan
        '
        Me.btcPlan.Location = New System.Drawing.Point(436, 289)
        Me.btcPlan.Name = "btcPlan"
        Me.btcPlan.Size = New System.Drawing.Size(75, 23)
        Me.btcPlan.TabIndex = 20
        Me.btcPlan.Text = "Planifie"
        Me.btcPlan.UseVisualStyleBackColor = True
        '
        'btcFermer
        '
        Me.btcFermer.Location = New System.Drawing.Point(329, 289)
        Me.btcFermer.Name = "btcFermer"
        Me.btcFermer.Size = New System.Drawing.Size(75, 23)
        Me.btcFermer.TabIndex = 3
        Me.btcFermer.Text = "&Fermer"
        Me.btcFermer.UseVisualStyleBackColor = True
        '
        'labProjectMember
        '
        Me.labProjectMember.AutoSize = True
        Me.labProjectMember.Location = New System.Drawing.Point(23, 45)
        Me.labProjectMember.Name = "labProjectMember"
        Me.labProjectMember.Size = New System.Drawing.Size(89, 13)
        Me.labProjectMember.TabIndex = 18
        Me.labProjectMember.Text = "Membre de projet"
        '
        'labAdminResource
        '
        Me.labAdminResource.AutoSize = True
        Me.labAdminResource.Location = New System.Drawing.Point(23, 153)
        Me.labAdminResource.Name = "labAdminResource"
        Me.labAdminResource.Size = New System.Drawing.Size(125, 13)
        Me.labAdminResource.TabIndex = 20
        Me.labAdminResource.Text = "Ressource administrative"
        '
        'grpSchedule
        '
        Me.grpSchedule.Controls.Add(Me.grpWeekly)
        Me.grpSchedule.Controls.Add(Me.grpDaily)
        Me.grpSchedule.Controls.Add(Me.radWeekly)
        Me.grpSchedule.Controls.Add(Me.radDaily)
        Me.grpSchedule.Controls.Add(Me.dtpDate)
        Me.grpSchedule.Location = New System.Drawing.Point(436, 33)
        Me.grpSchedule.Name = "grpSchedule"
        Me.grpSchedule.Size = New System.Drawing.Size(490, 215)
        Me.grpSchedule.TabIndex = 22
        Me.grpSchedule.TabStop = False
        Me.grpSchedule.Text = "Planification des jours"
        '
        'radWeekly
        '
        Me.radWeekly.AutoSize = True
        Me.radWeekly.Location = New System.Drawing.Point(29, 70)
        Me.radWeekly.Name = "radWeekly"
        Me.radWeekly.Size = New System.Drawing.Size(94, 17)
        Me.radWeekly.TabIndex = 5
        Me.radWeekly.TabStop = True
        Me.radWeekly.Text = "Hebdomadaire"
        Me.radWeekly.UseVisualStyleBackColor = True
        '
        'radDaily
        '
        Me.radDaily.AutoSize = True
        Me.radDaily.Location = New System.Drawing.Point(29, 43)
        Me.radDaily.Name = "radDaily"
        Me.radDaily.Size = New System.Drawing.Size(70, 17)
        Me.radDaily.TabIndex = 4
        Me.radDaily.TabStop = True
        Me.radDaily.Text = "Journalier"
        Me.radDaily.UseVisualStyleBackColor = True
        '
        'dtpDate
        '
        Me.dtpDate.Location = New System.Drawing.Point(160, 24)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(315, 20)
        Me.dtpDate.TabIndex = 1
        '
        'grpWeekly
        '
        Me.grpWeekly.Controls.Add(Me.chkWeekPM)
        Me.grpWeekly.Controls.Add(Me.chkWeekAM)
        Me.grpWeekly.Controls.Add(Me.texNumberOfWeeks)
        Me.grpWeekly.Controls.Add(Me.chkMonday)
        Me.grpWeekly.Controls.Add(Me.labNumberOfWeeks)
        Me.grpWeekly.Controls.Add(Me.chkTuesday)
        Me.grpWeekly.Controls.Add(Me.chkWednesday)
        Me.grpWeekly.Controls.Add(Me.chkSunday)
        Me.grpWeekly.Controls.Add(Me.chkThursday)
        Me.grpWeekly.Controls.Add(Me.chkSaturday)
        Me.grpWeekly.Controls.Add(Me.chkFriday)
        Me.grpWeekly.Location = New System.Drawing.Point(160, 50)
        Me.grpWeekly.Name = "grpWeekly"
        Me.grpWeekly.Size = New System.Drawing.Size(315, 125)
        Me.grpWeekly.TabIndex = 19
        Me.grpWeekly.TabStop = False
        '
        'texNumberOfWeeks
        '
        Me.texNumberOfWeeks.Location = New System.Drawing.Point(124, 79)
        Me.texNumberOfWeeks.Name = "texNumberOfWeeks"
        Me.texNumberOfWeeks.Size = New System.Drawing.Size(38, 20)
        Me.texNumberOfWeeks.TabIndex = 16
        '
        'chkMonday
        '
        Me.chkMonday.AutoSize = True
        Me.chkMonday.Location = New System.Drawing.Point(15, 17)
        Me.chkMonday.Name = "chkMonday"
        Me.chkMonday.Size = New System.Drawing.Size(48, 17)
        Me.chkMonday.TabIndex = 9
        Me.chkMonday.Text = "lundi"
        Me.chkMonday.UseVisualStyleBackColor = True
        '
        'labNumberOfWeeks
        '
        Me.labNumberOfWeeks.AutoSize = True
        Me.labNumberOfWeeks.Location = New System.Drawing.Point(12, 82)
        Me.labNumberOfWeeks.Name = "labNumberOfWeeks"
        Me.labNumberOfWeeks.Size = New System.Drawing.Size(106, 13)
        Me.labNumberOfWeeks.TabIndex = 17
        Me.labNumberOfWeeks.Text = "Nombre de semaines"
        '
        'chkTuesday
        '
        Me.chkTuesday.AutoSize = True
        Me.chkTuesday.Location = New System.Drawing.Point(15, 45)
        Me.chkTuesday.Name = "chkTuesday"
        Me.chkTuesday.Size = New System.Drawing.Size(51, 17)
        Me.chkTuesday.TabIndex = 10
        Me.chkTuesday.Text = "mardi"
        Me.chkTuesday.UseVisualStyleBackColor = True
        '
        'chkWednesday
        '
        Me.chkWednesday.AutoSize = True
        Me.chkWednesday.Location = New System.Drawing.Point(77, 17)
        Me.chkWednesday.Name = "chkWednesday"
        Me.chkWednesday.Size = New System.Drawing.Size(66, 17)
        Me.chkWednesday.TabIndex = 11
        Me.chkWednesday.Text = "mercredi"
        Me.chkWednesday.UseVisualStyleBackColor = True
        '
        'chkSunday
        '
        Me.chkSunday.AutoSize = True
        Me.chkSunday.Location = New System.Drawing.Point(222, 17)
        Me.chkSunday.Name = "chkSunday"
        Me.chkSunday.Size = New System.Drawing.Size(72, 17)
        Me.chkSunday.TabIndex = 15
        Me.chkSunday.Text = "dimanche"
        Me.chkSunday.UseVisualStyleBackColor = True
        '
        'chkThursday
        '
        Me.chkThursday.AutoSize = True
        Me.chkThursday.Location = New System.Drawing.Point(77, 45)
        Me.chkThursday.Name = "chkThursday"
        Me.chkThursday.Size = New System.Drawing.Size(48, 17)
        Me.chkThursday.TabIndex = 12
        Me.chkThursday.Text = "jeudi"
        Me.chkThursday.UseVisualStyleBackColor = True
        '
        'chkSaturday
        '
        Me.chkSaturday.AutoSize = True
        Me.chkSaturday.Location = New System.Drawing.Point(149, 45)
        Me.chkSaturday.Name = "chkSaturday"
        Me.chkSaturday.Size = New System.Drawing.Size(59, 17)
        Me.chkSaturday.TabIndex = 14
        Me.chkSaturday.Text = "samedi"
        Me.chkSaturday.UseVisualStyleBackColor = True
        '
        'chkFriday
        '
        Me.chkFriday.AutoSize = True
        Me.chkFriday.Location = New System.Drawing.Point(149, 17)
        Me.chkFriday.Name = "chkFriday"
        Me.chkFriday.Size = New System.Drawing.Size(67, 17)
        Me.chkFriday.TabIndex = 13
        Me.chkFriday.Text = "vendredi"
        Me.chkFriday.UseVisualStyleBackColor = True
        '
        'grpDaily
        '
        Me.grpDaily.Controls.Add(Me.chkPM)
        Me.grpDaily.Controls.Add(Me.chkAM)
        Me.grpDaily.Controls.Add(Me.radDays)
        Me.grpDaily.Controls.Add(Me.radWeekDays)
        Me.grpDaily.Controls.Add(Me.texNumberOfDays)
        Me.grpDaily.Controls.Add(Me.labNumberOfDays)
        Me.grpDaily.Location = New System.Drawing.Point(160, 50)
        Me.grpDaily.Name = "grpDaily"
        Me.grpDaily.Size = New System.Drawing.Size(315, 125)
        Me.grpDaily.TabIndex = 18
        Me.grpDaily.TabStop = False
        '
        'radDays
        '
        Me.radDays.AutoSize = True
        Me.radDays.Location = New System.Drawing.Point(169, 60)
        Me.radDays.Name = "radDays"
        Me.radDays.Size = New System.Drawing.Size(128, 17)
        Me.radDays.TabIndex = 10
        Me.radDays.Text = "Semaine et week-end"
        Me.radDays.UseVisualStyleBackColor = True
        '
        'radWeekDays
        '
        Me.radWeekDays.AutoSize = True
        Me.radWeekDays.Checked = True
        Me.radWeekDays.Location = New System.Drawing.Point(169, 33)
        Me.radWeekDays.Name = "radWeekDays"
        Me.radWeekDays.Size = New System.Drawing.Size(124, 17)
        Me.radWeekDays.TabIndex = 9
        Me.radWeekDays.TabStop = True
        Me.radWeekDays.Text = "Uniquement semaine"
        Me.radWeekDays.UseVisualStyleBackColor = True
        '
        'texNumberOfDays
        '
        Me.texNumberOfDays.Location = New System.Drawing.Point(105, 46)
        Me.texNumberOfDays.Name = "texNumberOfDays"
        Me.texNumberOfDays.Size = New System.Drawing.Size(38, 20)
        Me.texNumberOfDays.TabIndex = 7
        Me.texNumberOfDays.Text = "1"
        '
        'labNumberOfDays
        '
        Me.labNumberOfDays.AutoSize = True
        Me.labNumberOfDays.Location = New System.Drawing.Point(15, 49)
        Me.labNumberOfDays.Name = "labNumberOfDays"
        Me.labNumberOfDays.Size = New System.Drawing.Size(84, 13)
        Me.labNumberOfDays.TabIndex = 8
        Me.labNumberOfDays.Text = "Nombre de jours"
        '
        'lstAdminResources
        '
        Me.lstAdminResources.FormattingEnabled = True
        Me.lstAdminResources.Location = New System.Drawing.Point(150, 153)
        Me.lstAdminResources.Name = "lstAdminResources"
        Me.lstAdminResources.Size = New System.Drawing.Size(254, 95)
        Me.lstAdminResources.TabIndex = 23
        '
        'lstProjectMember
        '
        Me.lstProjectMember.FormattingEnabled = True
        Me.lstProjectMember.Location = New System.Drawing.Point(150, 45)
        Me.lstProjectMember.Name = "lstProjectMember"
        Me.lstProjectMember.Size = New System.Drawing.Size(254, 95)
        Me.lstProjectMember.TabIndex = 24
        '
        'btcPlanFree
        '
        Me.btcPlanFree.Location = New System.Drawing.Point(541, 289)
        Me.btcPlanFree.Name = "btcPlanFree"
        Me.btcPlanFree.Size = New System.Drawing.Size(75, 23)
        Me.btcPlanFree.TabIndex = 25
        Me.btcPlanFree.Text = "Jours libres"
        Me.btcPlanFree.UseVisualStyleBackColor = True
        '
        'chkAM
        '
        Me.chkAM.AutoSize = True
        Me.chkAM.Location = New System.Drawing.Point(168, 92)
        Me.chkAM.Name = "chkAM"
        Me.chkAM.Size = New System.Drawing.Size(42, 17)
        Me.chkAM.TabIndex = 11
        Me.chkAM.Text = "AM"
        Me.chkAM.UseVisualStyleBackColor = True
        '
        'chkPM
        '
        Me.chkPM.AutoSize = True
        Me.chkPM.Location = New System.Drawing.Point(231, 92)
        Me.chkPM.Name = "chkPM"
        Me.chkPM.Size = New System.Drawing.Size(42, 17)
        Me.chkPM.TabIndex = 12
        Me.chkPM.Text = "PM"
        Me.chkPM.UseVisualStyleBackColor = True
        '
        'chkWeekAM
        '
        Me.chkWeekAM.AutoSize = True
        Me.chkWeekAM.Location = New System.Drawing.Point(193, 81)
        Me.chkWeekAM.Name = "chkWeekAM"
        Me.chkWeekAM.Size = New System.Drawing.Size(42, 17)
        Me.chkWeekAM.TabIndex = 18
        Me.chkWeekAM.Text = "AM"
        Me.chkWeekAM.UseVisualStyleBackColor = True
        '
        'chkWeekPM
        '
        Me.chkWeekPM.AutoSize = True
        Me.chkWeekPM.Location = New System.Drawing.Point(231, 81)
        Me.chkWeekPM.Name = "chkWeekPM"
        Me.chkWeekPM.Size = New System.Drawing.Size(42, 17)
        Me.chkWeekPM.TabIndex = 19
        Me.chkWeekPM.Text = "PM"
        Me.chkWeekPM.UseVisualStyleBackColor = True
        '
        'frmResourceAdmin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(974, 361)
        Me.Controls.Add(Me.btcPlanFree)
        Me.Controls.Add(Me.lstProjectMember)
        Me.Controls.Add(Me.lstAdminResources)
        Me.Controls.Add(Me.grpSchedule)
        Me.Controls.Add(Me.btcPlan)
        Me.Controls.Add(Me.labAdminResource)
        Me.Controls.Add(Me.labProjectMember)
        Me.Controls.Add(Me.btcFermer)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmResourceAdmin"
        Me.Text = "Ressources adminstratives"
        Me.grpSchedule.ResumeLayout(False)
        Me.grpSchedule.PerformLayout()
        Me.grpWeekly.ResumeLayout(False)
        Me.grpWeekly.PerformLayout()
        Me.grpDaily.ResumeLayout(False)
        Me.grpDaily.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btcFermer As Button
    Friend WithEvents labProjectMember As Label
    Friend WithEvents labAdminResource As Label
    Friend WithEvents btcPlan As Button
    Friend WithEvents grpSchedule As GroupBox
    Friend WithEvents radWeekly As RadioButton
    Friend WithEvents radDaily As RadioButton
    Private WithEvents dtpDate As DateTimePicker
    Friend WithEvents grpWeekly As GroupBox
    Friend WithEvents texNumberOfWeeks As TextBox
    Friend WithEvents chkMonday As CheckBox
    Friend WithEvents labNumberOfWeeks As Label
    Friend WithEvents chkTuesday As CheckBox
    Friend WithEvents chkWednesday As CheckBox
    Friend WithEvents chkSunday As CheckBox
    Friend WithEvents chkThursday As CheckBox
    Friend WithEvents chkSaturday As CheckBox
    Friend WithEvents chkFriday As CheckBox
    Friend WithEvents grpDaily As GroupBox
    Friend WithEvents radDays As RadioButton
    Friend WithEvents radWeekDays As RadioButton
    Friend WithEvents texNumberOfDays As TextBox
    Friend WithEvents labNumberOfDays As Label
    Friend WithEvents lstAdminResources As ListBox
    Friend WithEvents lstProjectMember As ListBox
    Friend WithEvents btcPlanFree As Button
    Friend WithEvents chkPM As CheckBox
    Friend WithEvents chkAM As CheckBox
    Friend WithEvents chkWeekPM As CheckBox
    Friend WithEvents chkWeekAM As CheckBox
End Class
