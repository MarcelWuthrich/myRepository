Imports System.Data.SqlClient



Public Class frmResourceAdmin



    Private Sub frmResourceAdmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            Me.radDaily.Checked = True

            Me.grpDaily.Visible = True
            Me.grpWeekly.Visible = False


            Me.texNumberOfWeeks.Text = "1"
            Me.texNumberOfDays.Text = "1"


            pLoadProjectMember()

            pLoadAdminResources()



        Catch ex As Exception

        End Try

    End Sub

    Private Sub btcFermer_Click(sender As Object, e As EventArgs) Handles btcFermer.Click
        Try
            Me.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btcPlan_Click(sender As Object, e As EventArgs) Handles btcPlan.Click

        Try


            'On lit le membre de projet sélectionné
            Dim ID_ProjectMember As String = DirectCast(lstProjectMember.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim ProjectMember As String = DirectCast(lstProjectMember.SelectedItem, KeyValuePair(Of String, String)).Value

            'On lit la ressource administrative sélectionnée
            Dim ID_AdminResource As String = DirectCast(lstAdminResources.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim AdminResource As String = DirectCast(lstAdminResources.SelectedItem, KeyValuePair(Of String, String)).Value


            'Définition des variables pour le messagebox
            Dim Message As String = ""
            Dim Caption As String = ""
            Dim Buttons As MessageBoxButtons
            Dim Icon As MessageBoxIcon
            Dim Result As New DialogResult


            'Message = "Vous souhaitez planifier des ressouces administratives" & vbCrLf & vbCrLf & AdminResource & vbCrLf & vbCrLf & "pour" & vbCrLf & vbCrLf & ProjectMember
            'Caption = "Confirmation de planification"
            'Buttons = MessageBoxButtons.YesNo
            'Icon = MessageBoxIcon.Question
            'Result = MessageBox.Show(Message, Caption, Buttons, Icon)

            'If Result = vbNo Then
            '    Exit Sub
            'End If

            If Me.radDaily.Checked = True Then
                'Si c'est journalier, on le traite dans ce test IF .. THEN .. END IF

                Dim _Date As Date = Me.dtpDate.Value
                Dim _Numbers As Integer = Val(Me.texNumberOfDays.Text)
                Dim _Result As String = ""
                Dim _AM As Boolean = Me.chkAM.Checked
                Dim _PM As Boolean = Me.chkPM.Checked

                Dim I As Integer = 0

                Dim _Counter As Integer = 1

                Do Until _Counter > _Numbers

                    If (_Date.DayOfWeek = DayOfWeek.Saturday Or _Date.DayOfWeek = DayOfWeek.Sunday) And Me.radWeekDays.Checked = True Then
                        ' C'est un samedi ou un dimanche et on veut ignorer cette date
                        ' Donc on ne fait rien
                    Else
                        'Dans tous les autres cas, on prend la date
                        _Result = Format(_Date, "D")

                        Dim _myPlanResourceAM As New myPlanResource
                        Dim _myPlanResourcePM As New myPlanResource

                        If _AM = True Then
                            _myPlanResourceAM.CE_ID_AdminResource = ID_AdminResource
                            _myPlanResourceAM.CE_ID_ProjectMember = ID_ProjectMember
                            _myPlanResourceAM.CE_ID_Project = 0
                            _myPlanResourceAM.HalfDay = 1
                            _myPlanResourceAM.PlanDate = _Date
                            _myPlanResourceAM.CheckIfPlaned()
                        End If

                        If _PM = True Then
                            _myPlanResourcePM.CE_ID_AdminResource = ID_AdminResource
                            _myPlanResourcePM.CE_ID_ProjectMember = ID_ProjectMember
                            _myPlanResourcePM.CE_ID_Project = 0
                            _myPlanResourcePM.HalfDay = 2
                            _myPlanResourcePM.PlanDate = _Date
                            _myPlanResourcePM.CheckIfPlaned()
                        End If


                        If _myPlanResourceAM.IsPlaned = True Then

                            Dim _myProjectMember As New myProjectMember
                            _myProjectMember.ID_ProjectMember = _myPlanResourceAM.CE_ID_ProjectMember
                            _myProjectMember.Read()

                            Message = _myProjectMember.FullName & " est déjà occupé le " & Format(_myPlanResourceAM.PlanDate, "d") & " matin" & vbCrLf & "Est-ce que vous souhaitez remplacer la valeur existante ?" & vbCrLf & vbCrLf & "Oui : je veux remplacer la valeur existante" & vbCrLf & "Non : je ne veux PAS remplacer la valeur existante" & vbCrLf & "Annuler : je ne continue pas"
                            Caption = "Ressource planifiée"
                            Buttons = MessageBoxButtons.YesNoCancel
                            Icon = MessageBoxIcon.Question
                            'Displays the MessageBox
                            Result = MessageBox.Show(Message, Caption, Buttons, Icon)

                            Select Case Result
                                Case vbCancel
                                    'MessageBox.Show("Alors on s'arrête là")
                                    Exit Sub
                                Case vbNo
                                    'MessageBox.Show("On continue sans enregistrer")
                                Case vbYes
                                    'MessageBox.Show("On continue et on enregistre")
                                    _myPlanResourceAM.Save()
                            End Select
                        Else
                            _myPlanResourceAM.Save()
                        End If

                        If _myPlanResourcePM.IsPlaned = True Then

                            Dim _myProjectMember As New myProjectMember
                            _myProjectMember.ID_ProjectMember = _myPlanResourcePM.CE_ID_ProjectMember
                            _myProjectMember.Read()

                            Message = _myProjectMember.FullName & " est déjà occupé le " & Format(_myPlanResourcePM.PlanDate, "d") & " après-midi" & vbCrLf & "Est-ce que vous souhaitez remplacer la valeur existante ?" & vbCrLf & vbCrLf & "Oui : je veux remplacer la valeur existante" & vbCrLf & "Non : je ne veux PAS remplacer la valeur existante" & vbCrLf & "Annuler : je ne continue pas"
                            Caption = "Ressource planifiée"
                            Buttons = MessageBoxButtons.YesNoCancel
                            Icon = MessageBoxIcon.Question
                            'Displays the MessageBox
                            Result = MessageBox.Show(Message, Caption, Buttons, Icon)

                            Select Case Result
                                Case vbCancel
                                    'MessageBox.Show("Alors on s'arrête là")
                                    Exit Sub
                                Case vbNo
                                    'MessageBox.Show("On continue sans enregistrer")
                                Case vbYes
                                    'MessageBox.Show("On continue et on enregistre")
                                    _myPlanResourcePM.Save()
                            End Select
                        Else
                            _myPlanResourcePM.Save()
                        End If


                        'On incrémente le compteur uniquement si on veut la date
                        _Counter = _Counter + 1
                    End If

                    'On incrémente le jour
                    _Date = DateAdd(DateInterval.Day, 1, _Date)

                Loop




            End If

            If Me.radWeekly.Checked = True Then
                'Si c'est mensuel, on le traite dans ce test IF .. THEN .. END IF

                Dim _Date As Date = Me.dtpDate.Value
                Dim _Numbers As Integer = Val(Me.texNumberOfWeeks.Text)
                Dim _Result As String = ""
                Dim _AM As Boolean = Me.chkWeekAM.Checked
                Dim _PM As Boolean = Me.chkWeekPM.Checked

                Dim _Monday As Boolean = Me.chkMonday.Checked
                Dim _Tuesday As Boolean = Me.chkTuesday.Checked
                Dim _Wednesday As Boolean = Me.chkWednesday.Checked
                Dim _Thursday As Boolean = Me.chkThursday.Checked
                Dim _Friday As Boolean = Me.chkFriday.Checked
                Dim _Saturday As Boolean = Me.chkSaturday.Checked
                Dim _Sunday As Boolean = Me.chkSunday.Checked


                Dim I As Integer = 0

                Dim _Counter As Integer = 1
                Dim _MaxDate As Date = DateAdd(DateInterval.Day, (7 * _Numbers) - 1, _Date)


                Do Until _Date > _MaxDate

                    If (_Monday = True And _Date.DayOfWeek = DayOfWeek.Monday) Or
                       (_Tuesday = True And _Date.DayOfWeek = DayOfWeek.Tuesday) Or
                       (_Wednesday = True And _Date.DayOfWeek = DayOfWeek.Wednesday) Or
                       (_Thursday = True And _Date.DayOfWeek = DayOfWeek.Thursday) Or
                       (_Friday = True And _Date.DayOfWeek = DayOfWeek.Friday) Or
                      (_Saturday = True And _Date.DayOfWeek = DayOfWeek.Saturday) Or
                        (_Sunday = True And _Date.DayOfWeek = DayOfWeek.Sunday) Then

                        '_Result = Format(_Date, "D")

                        Dim _myPlanResourceAM As New myPlanResource
                        Dim _myPlanResourcePM As New myPlanResource

                        If _AM = True Then
                            _myPlanResourceAM.CE_ID_AdminResource = ID_AdminResource
                            _myPlanResourceAM.CE_ID_ProjectMember = ID_ProjectMember
                            _myPlanResourceAM.CE_ID_Project = 0
                            _myPlanResourceAM.HalfDay = 1
                            _myPlanResourceAM.PlanDate = _Date
                            _myPlanResourceAM.CheckIfPlaned()
                        End If

                        If _PM = True Then
                            _myPlanResourcePM.CE_ID_AdminResource = ID_AdminResource
                            _myPlanResourcePM.CE_ID_ProjectMember = ID_ProjectMember
                            _myPlanResourcePM.CE_ID_Project = 0
                            _myPlanResourcePM.HalfDay = 2
                            _myPlanResourcePM.PlanDate = _Date
                            _myPlanResourcePM.CheckIfPlaned()
                        End If

                        If _myPlanResourceAM.IsPlaned = True Then

                            Dim _myProjectMember As New myProjectMember
                            _myProjectMember.ID_ProjectMember = _myPlanResourceAM.CE_ID_ProjectMember
                            _myProjectMember.Read()

                            Message = _myProjectMember.FullName & " est déjà occupé le " & Format(_myPlanResourceAM.PlanDate, "d") & " matin" & vbCrLf & "Est-ce que vous souhaitez remplacer la valeur existante ?" & vbCrLf & vbCrLf & "Oui : je veux remplacer la valeur existante" & vbCrLf & "Non : je ne veux PAS remplacer la valeur existante" & vbCrLf & "Annuler : je ne continue pas"
                            Caption = "Ressource planifiée"
                            Buttons = MessageBoxButtons.YesNoCancel
                            Icon = MessageBoxIcon.Question
                            'Displays the MessageBox
                            Result = MessageBox.Show(Message, Caption, Buttons, Icon)

                            Select Case Result
                                Case vbCancel
                                    'MessageBox.Show("Alors on s'arrête là")
                                    Exit Sub
                                Case vbNo
                                    'MessageBox.Show("On continue sans enregistrer")
                                Case vbYes
                                    'MessageBox.Show("On continue et on enregistre")
                                    _myPlanResourceAM.Save()
                            End Select
                        Else
                            _myPlanResourceAM.Save()
                        End If

                        If _myPlanResourcePM.IsPlaned = True Then

                            Dim _myProjectMember As New myProjectMember
                            _myProjectMember.ID_ProjectMember = _myPlanResourcePM.CE_ID_ProjectMember
                            _myProjectMember.Read()

                            Message = _myProjectMember.FullName & " est déjà occupé le " & Format(_myPlanResourcePM.PlanDate, "d") & " après-midi" & vbCrLf & "Est-ce que vous souhaitez remplacer la valeur existante ?" & vbCrLf & vbCrLf & "Oui : je veux remplacer la valeur existante" & vbCrLf & "Non : je ne veux PAS remplacer la valeur existante" & vbCrLf & "Annuler : je ne continue pas"
                            Caption = "Ressource planifiée"
                            Buttons = MessageBoxButtons.YesNoCancel
                            Icon = MessageBoxIcon.Question
                            'Displays the MessageBox
                            Result = MessageBox.Show(Message, Caption, Buttons, Icon)

                            Select Case Result
                                Case vbCancel
                                    'MessageBox.Show("Alors on s'arrête là")
                                    Exit Sub
                                Case vbNo
                                    'MessageBox.Show("On continue sans enregistrer")
                                Case vbYes
                                    'MessageBox.Show("On continue et on enregistre")
                                    _myPlanResourcePM.Save()
                            End Select
                        Else
                            _myPlanResourcePM.Save()
                        End If


                    End If



                    'On incrémente le jour
                    _Date = DateAdd(DateInterval.Day, 1, _Date)

                Loop




            End If

            Call frmTabResources.pDisplayResourcesTable()

            'Message = "Les ressources administratives sont planifiées"
            'Caption = "Planification"
            'Buttons = MessageBoxButtons.OK
            'Icon = MessageBoxIcon.Information
            'MessageBox.Show(Message, Caption, Buttons, Icon)


        Catch ex As Exception

            If DebugFlag = True Then MessageBox.Show(ex.ToString)

        End Try

    End Sub

    Private Sub btcPlanFree_Click(sender As Object, e As EventArgs) Handles btcPlanFree.Click

        Try

            'On lit le membre de projet sélectionné
            Dim ID_ProjectMember As String = DirectCast(lstProjectMember.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim ProjectMember As String = DirectCast(lstProjectMember.SelectedItem, KeyValuePair(Of String, String)).Value

            'On lit la ressource administrative sélectionnée
            Dim ID_AdminResource As String = DirectCast(lstAdminResources.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim AdminResource As String = DirectCast(lstAdminResources.SelectedItem, KeyValuePair(Of String, String)).Value

            'On lit le nombre de jours à partir de la date définie
            Dim _Date As Date = Me.dtpDate.Value
            Dim _Numbers As Integer = Val(Me.texNumberOfDays.Text)

            'On lit les demi-jours
            Dim _AM As Boolean = Me.chkAM.Checked
            Dim _PM As Boolean = Me.chkPM.Checked

            'Variable mise à true si un jour est enregistré
            Dim thisDaySaved As Boolean = False

            'Définition des variables pour le messagebox
            Dim Message As String = ""
            Dim Caption As String = ""
            Dim Buttons As MessageBoxButtons
            Dim Icon As MessageBoxIcon
            Dim Result As New DialogResult


            'Demande de confirmation de planification
            If _Numbers = 1 Then
                Message = "Souhaitez-vous planifier 1 journée de """ & AdminResource & """ à partir du " & Format(_Date, "d") & " pour " & ProjectMember & " ?"
            Else
                Message = "Souhaitez-vous planifier " & _Numbers & " journées de """ & AdminResource & """ à partir du " & Format(_Date, "d") & " pour " & ProjectMember & " ?"
            End If

            Caption = "Confirmation de planification"
            Buttons = MessageBoxButtons.YesNo
            Icon = MessageBoxIcon.Question
            Result = MessageBox.Show(Message, Caption, Buttons, Icon)

            If Result = vbNo Then
                Exit Sub
            End If

            Dim _Counter As Integer = 1
            Dim _Result As String = ""

            Do Until _Counter > _Numbers

                If (_Date.DayOfWeek = DayOfWeek.Saturday Or _Date.DayOfWeek = DayOfWeek.Sunday) And Me.radWeekDays.Checked = True Then
                    ' C'est un samedi ou un dimanche et on veut ignorer cette date
                    ' Donc on ne fait rien
                Else
                    'Dans tous les autres cas, on prend la date
                    _Result = Format(_Date, "D")

                    Dim _myPlanResourceAM As New myPlanResource
                    _myPlanResourceAM.CE_ID_AdminResource = ID_AdminResource
                    _myPlanResourceAM.CE_ID_ProjectMember = ID_ProjectMember
                    _myPlanResourceAM.CE_ID_Project = 0
                    _myPlanResourceAM.PlanDate = _Date
                    _myPlanResourceAM.HalfDay = 1
                    _myPlanResourceAM.CheckIfPlaned()

                    Dim _myPlanResourcePM As New myPlanResource
                    _myPlanResourcePM.CE_ID_AdminResource = ID_AdminResource
                    _myPlanResourcePM.CE_ID_ProjectMember = ID_ProjectMember
                    _myPlanResourcePM.CE_ID_Project = 0
                    _myPlanResourcePM.PlanDate = _Date
                    _myPlanResourcePM.HalfDay = 2
                    _myPlanResourcePM.CheckIfPlaned()


                    If _myPlanResourceAM.IsPlaned = False Then
                        _myPlanResourceAM.Save()
                        thisDaySaved = True
                    End If

                    If _myPlanResourcePM.IsPlaned = False Then
                        _myPlanResourcePM.Save()
                        thisDaySaved = True
                    End If


                    If thisDaySaved = True Then
                        'On incrémente le compteur uniquement si on veut la date
                        _Counter = _Counter + 1
                        'On remet la variable sur False
                        thisDaySaved = False
                    End If
                End If

                'On incrémente le jour
                _Date = DateAdd(DateInterval.Day, 1, _Date)

            Loop

            Call frmTabResources.pDisplayResourcesTable()

            Message = "Les ressources administratives sont planifiées"
            Caption = "Planification"
            Buttons = MessageBoxButtons.OK
            Icon = MessageBoxIcon.Information
            MessageBox.Show(Message, Caption, Buttons, Icon)


        Catch ex As Exception

        End Try
    End Sub

    Private Sub radDaily_CheckedChanged(sender As Object, e As EventArgs) Handles radDaily.CheckedChanged

        Try
            Me.grpDaily.Visible = True
            Me.grpWeekly.Visible = False
            Me.btcPlanFree.Enabled = True
        Catch ex As Exception
        End Try

    End Sub

    Private Sub radWeekly_CheckedChanged(sender As Object, e As EventArgs) Handles radWeekly.CheckedChanged

        Try
            Me.grpDaily.Visible = False
            Me.grpWeekly.Visible = True
            Me.btcPlanFree.Enabled = False
        Catch ex As Exception
        End Try

    End Sub


    Private Sub pLoadProjectMember()

        Try


            Me.lstProjectMember.Items.Clear()

            Dim myDictionnary As New Dictionary(Of String, String)()



            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT ID_ProjectMember, FirstName, Lastname FROM ProjectsMembers where Enable = 1 ;"
            Dim MySQLConnection As New SqlConnection


            MySQLConnection.ConnectionString = cnProjectPlan


            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)

            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read


                Try
                    Dim _ID_ProjectMember As Integer = 0
                    Dim _FirstName As String = ""
                    Dim _LastName As String = ""

                    Try
                        _ID_ProjectMember = mySQLDataReader.GetValue(0)
                    Catch ex As Exception
                    End Try

                    Try
                        _FirstName = mySQLDataReader.GetString(1)
                    Catch ex As Exception
                    End Try

                    Try
                        _LastName = mySQLDataReader.GetString(2)
                    Catch ex As Exception
                    End Try


                    myDictionnary.Add(Str(_ID_ProjectMember), _LastName & " " & _FirstName)

                Catch ex As Exception
                End Try

            End While

            mySQLDataReader.Close()
            MySQLConnection.Close()

            Me.lstProjectMember.DataSource = New BindingSource(myDictionnary, Nothing)
            Me.lstProjectMember.DisplayMember = "Value"
            Me.lstProjectMember.ValueMember = "Key)"



        Catch ex As Exception

        End Try

    End Sub

    Private Sub pLoadAdminResources()

        Try

            Me.lstAdminResources.Items.Clear()

            Dim myDictionnary As New Dictionary(Of String, String)()

            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT ID_AdminResource, AdminResource FROM AdminResources where Enable = 1 ORDER by DisplayOrder ASC;"
            Dim MySQLConnection As New SqlConnection


            MySQLConnection.ConnectionString = cnProjectPlan


            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)

            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read


                Try
                    Dim _Resource As String = ""
                    Dim _ID_Resource As Integer = 0

                    Try
                        _ID_Resource = mySQLDataReader.GetValue(0)
                    Catch ex As Exception
                    End Try

                    Try
                        _Resource = mySQLDataReader.GetString(1)
                    Catch ex As Exception
                    End Try


                    myDictionnary.Add(Str(_ID_Resource), _Resource)

                Catch ex As Exception
                End Try

            End While

            mySQLDataReader.Close()
            MySQLConnection.Close()

            Me.lstAdminResources.DataSource = New BindingSource(myDictionnary, Nothing)
            Me.lstAdminResources.DisplayMember = "Value"
            Me.lstAdminResources.ValueMember = "Key)"


        Catch ex As Exception

        End Try

    End Sub
End Class