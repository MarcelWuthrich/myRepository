Imports System.Data.SqlClient

Public Class frmAllResources
    Private Sub frmAllResources_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.WindowState = FormWindowState.Maximized


        Try

            pPopulateMonth()
            pPopulateYear()

            'pDisplayResources()


        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Sub btcClose_Click(sender As Object, e As EventArgs) Handles btcClose.Click

        Try

            Me.Close()

        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub pPopulateMonth()

        Try

            Dim MonthName As String = ""
            Dim MonthNumber As Integer = 0
            Dim myDictionnary As New Dictionary(Of String, String)()

            MonthNumber = 1
            MonthName = "Janvier"
            myDictionnary.Add(Str(MonthNumber), MonthName)

            MonthNumber = 2
            MonthName = "Février"
            myDictionnary.Add(Str(MonthNumber), MonthName)

            MonthNumber = 3
            MonthName = "Mars"
            myDictionnary.Add(Str(MonthNumber), MonthName)

            MonthNumber = 4
            MonthName = "Avril"
            myDictionnary.Add(Str(MonthNumber), MonthName)

            MonthNumber = 5
            MonthName = "Mai"
            myDictionnary.Add(Str(MonthNumber), MonthName)

            MonthNumber = 6
            MonthName = "Juin"
            myDictionnary.Add(Str(MonthNumber), MonthName)

            MonthNumber = 7
            MonthName = "Juillet"
            myDictionnary.Add(Str(MonthNumber), MonthName)

            MonthNumber = 8
            MonthName = "Août"
            myDictionnary.Add(Str(MonthNumber), MonthName)

            MonthNumber = 9
            MonthName = "Septembre"
            myDictionnary.Add(Str(MonthNumber), MonthName)

            MonthNumber = 10
            MonthName = "Octobre"
            myDictionnary.Add(Str(MonthNumber), MonthName)

            MonthNumber = 11
            MonthName = "Novembre"
            myDictionnary.Add(Str(MonthNumber), MonthName)

            MonthNumber = 12
            MonthName = "Décembre"
            myDictionnary.Add(Str(MonthNumber), MonthName)


            lovMonth.Items.Clear()

            Me.lovMonth.DataSource = New BindingSource(myDictionnary, Nothing)
            Me.lovMonth.DisplayMember = "Value"
            Me.lovMonth.ValueMember = "Key"

            Me.lovMonth.SelectedIndex = Month(Today) - 1
            'Me.lovMonth.SelectedIndex = 4



        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Sub pPopulateYear()

        Try

            Dim myMinPlanDate As Date = fPlanResourceGetMinDate()
            Dim myMaxPlanDate As Date = fPlanResourceGetMaxDate()

            Dim myMinExecutedDate As Date = fExecutedResourceGetMinDate()
            Dim myMaxExecutedDate As Date = fExecutedResourceGetMaxDate()

            Dim myMinYear As Integer = 0
            Dim myMaxYear As Integer = 0

            If Year(myMinPlanDate) < Year(myMinExecutedDate) Then
                myMinYear = Year(myMinPlanDate)
            Else
                myMinYear = Year(myMinExecutedDate)
            End If

            If Year(myMaxPlanDate) > Year(myMaxExecutedDate) Then
                myMaxYear = Year(myMaxPlanDate)
            Else
                myMaxYear = Year(myMaxExecutedDate)
            End If

            Dim YearName As String = ""
            Dim YearNumber As Integer = 0
            Dim myDictionnary As New Dictionary(Of String, String)()

            For I = myMinYear To myMaxYear
                YearName = I
                YearNumber = I
                myDictionnary.Add(Str(YearNumber), YearName)
            Next

            lovYear.Items.Clear()

            Me.lovYear.DataSource = New BindingSource(myDictionnary, Nothing)
            Me.lovYear.DisplayMember = "Value"
            Me.lovYear.ValueMember = "Key"

            'Affichage de l'année en cours
            Dim thisYear As Integer = 0
            For I = 0 To lovYear.Items.Count - 1
                thisYear = DirectCast(lovYear.Items(I), KeyValuePair(Of String, String)).Key
                If thisYear = Year(Today) Then
                    Me.lovYear.SelectedIndex = I
                    Exit For
                End If
            Next I

        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub pDisplayResources()

        Try

            'On vide le DataGridView
            dgvResources.Rows.Clear()
            dgvResources.Columns.Clear()

            'Définition du DataGridView
            dgvResources.ReadOnly = True
            dgvResources.AllowUserToAddRows = False
            dgvResources.AllowUserToDeleteRows = False

            dgvResources.MultiSelect = False
            dgvResources.Refresh()

            'On enclenche le sablier
            Cursor.Current = Cursors.WaitCursor

            'Lecture du mois
            Dim myMonth As String = lovMonth.SelectedValue.ToString()

            'Lecture de l'année
            Dim myYear As String = lovYear.SelectedValue.ToString


            Dim MinDate As Date = New Date(myYear, myMonth, 1)
            Dim MaxDate As Date = DateAdd(DateInterval.Month, 1, MinDate)


            '=======================================================================
            'On recherche les ID_ProjectMember des resources planifiées et executées
            '=======================================================================

            Dim MySQLConnection As New SqlConnection
            Dim mySQLDataReader As SqlDataReader
            Dim SQL As String = ""
            SQL = "SELECT DISTINCT CE_ID_ProjectMember FROM PlanResources WHERE PlanDate >='" & fConvertDateTimeSQL(MinDate) & "' AND PlanDate <'" & fConvertDateTimeSQL(MaxDate) & "' "

            MySQLConnection.ConnectionString = cnProjectPlan
            MySQLConnection.Open()
            Dim mySQLCommand As SqlCommand = New SqlCommand(SQL, MySQLConnection)
            mySQLDataReader = mySQLCommand.ExecuteReader()

            Dim Array_ID_ProjectMember(0) As Integer

            While mySQLDataReader.Read
                'Lecture du premier paramètre CE_ID_ProjectMember
                Dim thisID As Integer = 0
                Try
                    thisID = mySQLDataReader.GetValue(0)
                Catch ex As Exception
                End Try
                If Array_ID_ProjectMember.Contains(thisID) Then
                    'On ne fait s'il existe déjà
                Else
                    ReDim Preserve Array_ID_ProjectMember(Array_ID_ProjectMember.Length)
                    Array_ID_ProjectMember(Array_ID_ProjectMember.Length - 1) = thisID
                End If
            End While

            mySQLDataReader.Close()
            MySQLConnection.Close()

            SQL = "SELECT DISTINCT CE_ID_ProjectMember FROM ExecutedResources WHERE PlanDate >='" & fConvertDateTimeSQL(MinDate) & "' AND PlanDate <'" & fConvertDateTimeSQL(MaxDate) & "' "

            MySQLConnection.ConnectionString = cnProjectPlan
            MySQLConnection.Open()
            mySQLCommand = New SqlCommand(SQL, MySQLConnection)
            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read
                'Lecture du premier paramètre CE_ID_ProjectMember
                Dim thisID As Integer = 0
                Try
                    thisID = mySQLDataReader.GetValue(0)
                Catch ex As Exception
                End Try
                If Array_ID_ProjectMember.Contains(thisID) Then
                    'On ne fait s'il existe déjà
                Else
                    ReDim Preserve Array_ID_ProjectMember(Array_ID_ProjectMember.Length)
                    Array_ID_ProjectMember(Array_ID_ProjectMember.Length - 1) = thisID
                End If
            End While

            mySQLDataReader.Close()
            MySQLConnection.Close()

            '===========================================================================
            'Fin de recherche les ID_ProjectMember des resources planifiées et executées
            '===========================================================================


            '===================================
            'Début de l'affichage des ressources
            '===================================

            'On définit les variables pour les boucles
            Dim x As Integer = 0
            Dim y As Integer = 0
            Dim I As Integer = 0

            Dim _LoopDate As Date = Nothing
            Dim _LoopColumn As Integer = 0
            Dim _LoopRow As Integer = 0

            dgvResources.Columns.Add("", "")

            For I = 1 To Array_ID_ProjectMember.Length - 1

                y = 0

                Dim myMember As New myProjectMember
                myMember.ID_ProjectMember = Array_ID_ProjectMember(I)
                myMember.Read()

                dgvResources.Columns.Add(myMember.FullName, myMember.FullName)

                'On ajuste la taille des colonnes
                dgvResources.Columns(I).Width = 160


                _LoopDate = MinDate
                Do Until _LoopDate >= MaxDate

                    If x = 0 Then
                        'On créé de nouvelles lignes uniquement lorsqu'on met le premier membre de projet
                        dgvResources.Rows.Add()
                        'dgvTabResources.Item(x, y).Value = Format(_LoopDate, "D")
                        dgvResources.Item(x, y).Value = Format(_LoopDate, "D") & " AM"
                        dgvResources.Item(x, y).Selected = False

                        dgvResources.Rows.Add()
                        dgvResources.Item(x, y + 1).Value = Format(_LoopDate, "D") & " PM"
                        dgvResources.AutoResizeColumn(x)

                        If Weekday(_LoopDate) = vbSunday Or Weekday(_LoopDate) = vbSaturday Then
                            dgvResources.Item(x, y).Style.BackColor = Color.Black
                            dgvResources.Item(x, y).Style.ForeColor = Color.White
                            dgvResources.Item(x, y + 1).Style.BackColor = Color.Black
                            dgvResources.Item(x, y + 1).Style.ForeColor = Color.White
                        End If
                    End If

                    'On définit une variable HD (HalfDay) pour le matin et après-midi
                    Dim HD As Integer = 0

                    For HD = 1 To 2

                        '==============================================
                        'début de l'affichage des ressources planifiées
                        '==============================================
                        Dim thisPlanResource As New myPlanResource
                        thisPlanResource.CE_ID_ProjectMember = Array_ID_ProjectMember(I)
                        thisPlanResource.PlanDate = _LoopDate
                        thisPlanResource.HalfDay = HD
                        thisPlanResource.GetIDResourceFromDateAndMember()
                        thisPlanResource.Read()

                        If thisPlanResource.IsAdminResource Then

                            Dim thisAdminResource As New myAdminResource
                            thisAdminResource.ID_AdminResource = thisPlanResource.CE_ID_AdminResource
                            thisAdminResource.read()

                            'Pour le matin
                            If HD = 1 Then

                                'Si bloqué
                                If thisPlanResource.Blocked = True Then
                                    dgvResources.Item(x + 1, y).Style.BackColor = Color.SlateGray
                                Else
                                    dgvResources.Item(x + 1, y).Style.BackColor = Color.LightGray
                                End If

                                'Si remarque
                                If thisPlanResource.Remark = "" Then
                                    dgvResources.Item(x + 1, y).Value = thisAdminResource.AdminResource
                                    dgvResources.Item(x + 1, y).ToolTipText = thisAdminResource.AdminResource
                                Else
                                    dgvResources.Item(x + 1, y).Value = "(*) " & thisAdminResource.AdminResource
                                    dgvResources.Item(x + 1, y).ToolTipText = thisAdminResource.AdminResource & vbCrLf & StrDup(15, Chr(151)) & vbCrLf & thisPlanResource.Remark

                                End If

                                dgvResources.Item(x + 1, y).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                            End If

                            'Après-midi
                            If HD = 2 Then

                                'Si bloqué
                                If thisPlanResource.Blocked = True Then
                                    dgvResources.Item(x + 1, y + 1).Style.BackColor = Color.SlateGray
                                Else
                                    dgvResources.Item(x + 1, y + 1).Style.BackColor = Color.LightGray
                                End If

                                'Si remarque
                                If thisPlanResource.Remark = "" Then
                                    dgvResources.Item(x + 1, y + 1).Value = thisAdminResource.AdminResource
                                    dgvResources.Item(x + 1, y + 1).ToolTipText = thisAdminResource.AdminResource
                                Else
                                    dgvResources.Item(x + 1, y + 1).Value = "(*) " & thisAdminResource.AdminResource
                                    dgvResources.Item(x + 1, y + 1).ToolTipText = thisAdminResource.AdminResource & vbCrLf & StrDup(15, Chr(151)) & vbCrLf & thisPlanResource.Remark
                                End If

                                dgvResources.Item(x + 1, y + 1).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                            End If
                        End If

                        If thisPlanResource.IsProjectResource Then
                            Dim thisProjectResource As New myProject
                            thisProjectResource.ID_Project = thisPlanResource.CE_ID_Project
                            thisProjectResource.Read()

                            'Si matin
                            If HD = 1 Then

                                'Si bloqué
                                If thisPlanResource.Blocked = True Then
                                    dgvResources.Item(x + 1, y).Style.BackColor = Color.ForestGreen
                                Else
                                    dgvResources.Item(x + 1, y).Style.BackColor = Color.LightGreen
                                End If

                                'Si remarque
                                If thisPlanResource.Remark = "" Then
                                    dgvResources.Item(x + 1, y).Value = thisProjectResource.Title
                                    dgvResources.Item(x + 1, y).ToolTipText = thisProjectResource.Title
                                Else
                                    dgvResources.Item(x + 1, y).Value = "(*) " & thisProjectResource.Title
                                    dgvResources.Item(x + 1, y).ToolTipText = thisProjectResource.Title & vbCrLf & StrDup(15, Chr(151)) & vbCrLf & thisPlanResource.Remark
                                End If

                                dgvResources.Item(x + 1, y).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                            End If

                            'Si après-midi
                            If HD = 2 Then

                                'Si bloqué
                                If thisPlanResource.Blocked = True Then
                                    dgvResources.Item(x + 1, y + 1).Style.BackColor = Color.ForestGreen
                                Else
                                    dgvResources.Item(x + 1, y + 1).Style.BackColor = Color.LightGreen
                                End If

                                'Si remarque
                                If thisPlanResource.Remark = "" Then
                                    dgvResources.Item(x + 1, y + 1).Value = thisProjectResource.Title
                                    dgvResources.Item(x + 1, y + 1).ToolTipText = thisProjectResource.Title
                                Else
                                    dgvResources.Item(x + 1, y + 1).Value = "(*) " & thisProjectResource.Title
                                    dgvResources.Item(x + 1, y + 1).ToolTipText = thisProjectResource.Title & vbCrLf & StrDup(15, Chr(151)) & vbCrLf & thisPlanResource.Remark
                                End If

                                dgvResources.Item(x + 1, y + 1).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                            End If
                        End If
                        '============================================
                        'fin de l'affichage des ressources planifiées
                        '============================================

                        '=============================================
                        'début de l'affichage des ressources exécutées
                        '=============================================
                        Dim thisExecutedResource As New myExecuteResource
                        thisExecutedResource.CE_ID_ProjectMember = Array_ID_ProjectMember(I)
                        thisExecutedResource.PlanDate = _LoopDate
                        thisExecutedResource.HalfDay = HD
                        thisExecutedResource.GetIDResourceFromDateAndMember()

                        thisExecutedResource.Read()

                        If thisExecutedResource.IsAdminResource Then
                            Dim thisAdminResource As New myAdminResource
                            thisAdminResource.ID_AdminResource = thisExecutedResource.CE_ID_AdminResource
                            thisAdminResource.read()
                            If HD = 1 Then
                                dgvResources.Item(x + 1, y).Value = thisAdminResource.AdminResource
                                dgvResources.Item(x + 1, y).Style.BackColor = Color.Orange
                                dgvResources.Item(x + 1, y).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                            End If
                            If HD = 2 Then
                                dgvResources.Item(x + 1, y + 1).Value = thisAdminResource.AdminResource
                                dgvResources.Item(x + 1, y + 1).Style.BackColor = Color.Orange
                                dgvResources.Item(x + 1, y + 1).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                            End If
                        End If

                        If thisExecutedResource.IsProjectResource Then
                            Dim thisProjectResource As New myProject
                            thisProjectResource.ID_Project = thisExecutedResource.CE_ID_Project
                            thisProjectResource.Read()
                            If HD = 1 Then
                                dgvResources.Item(x + 1, y).Value = thisProjectResource.Title
                                dgvResources.Item(x + 1, y).Style.BackColor = Color.Yellow
                                dgvResources.Item(x + 1, y).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                            End If
                            If HD = 2 Then
                                dgvResources.Item(x + 1, y + 1).Value = thisProjectResource.Title
                                dgvResources.Item(x + 1, y + 1).Style.BackColor = Color.Yellow
                                dgvResources.Item(x + 1, y + 1).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                            End If
                        End If
                        '===========================================
                        'fin de l'affichage des ressources exécutées
                        '===========================================


                        If Weekday(_LoopDate) = vbSunday Or Weekday(_LoopDate) = vbSaturday Then
                            dgvResources.Item(x + 1, y).Style.BackColor = Color.Black
                            dgvResources.Item(x + 1, y).Style.ForeColor = Color.White
                            dgvResources.Item(x + 1, y + 1).Style.BackColor = Color.Black
                            dgvResources.Item(x + 1, y + 1).Style.ForeColor = Color.White
                        End If

                    Next HD



                    'Compteur de lignes (dates)
                    y = y + 2

                    'On passe à la date suivante
                    _LoopDate = DateAdd(DateInterval.Day, 1, _LoopDate)
                Loop

                'Compteur de colonnes (membres de projets)
                x = x + 1

                'Actualisation de l'affichage par membre de projets ou de tâches administratives
                dgvResources.Refresh()

            Next I


            'On enclenche le sablier
            Cursor.Current = Cursors.Default

        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Sub btcDisplay_Click(sender As Object, e As EventArgs) Handles btcDisplay.Click

        Try
            pDisplayResources()
        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Sub pDisplayResourcesPlan(MinDate As Date, MaxDate As Date)

        Try

            'On définit les variables pour les boucles
            Dim x As Integer = 0
            Dim y As Integer = 0

            Dim _LoopDate As Date = Nothing
            Dim _LoopColumn As Integer = 0
            Dim _LoopRow As Integer = 0



            'On lit tous les membres de projets
            Dim MySQLConnection As New SqlConnection
            Dim mySQLDataReader As SqlDataReader
            Dim SQL As String = ""

            SQL = "SELECT DISTINCT CE_ID_ProjectMember FROM PlanResources WHERE PlanDate >='" & fConvertDateTimeSQL(MinDate) & "' AND PlanDate <'" & fConvertDateTimeSQL(MaxDate) & "' "

            MySQLConnection.ConnectionString = cnProjectPlan
            MySQLConnection.Open()
            Dim mySQLCommand As SqlCommand = New SqlCommand(SQL, MySQLConnection)
            mySQLDataReader = mySQLCommand.ExecuteReader()


            Dim thisProjetMember As New myProjectMember
            Dim _ColumnHeader As String = ""
            _ColumnHeader = ""
            dgvResources.Columns.Add(_ColumnHeader, _ColumnHeader)


            While mySQLDataReader.Read


                'Lecture du premier paramètre CE_ID_ProjectMember
                Try
                    thisProjetMember.ID_ProjectMember = mySQLDataReader.GetValue(0)
                Catch ex As Exception
                End Try

                thisProjetMember.Read()

                'On crée une colonne pour chaque membre de projet
                _ColumnHeader = thisProjetMember.FullName
                dgvResources.Columns.Add(_ColumnHeader, _ColumnHeader)
                dgvResources.Columns(x + 1).Width = 120


                y = 0
                _LoopDate = MinDate

                Do Until _LoopDate >= MaxDate

                    If x = 0 Then
                        'On créé de nouvelles lignes uniquement lorsqu'on met le premier membre de projet
                        dgvResources.Rows.Add()
                        'dgvTabResources.Item(x, y).Value = Format(_LoopDate, "D")
                        dgvResources.Item(x, y).Value = Format(_LoopDate, "D") & " AM"
                        dgvResources.Item(x, y).Selected = False

                        dgvResources.Rows.Add()
                        dgvResources.Item(x, y + 1).Value = Format(_LoopDate, "D") & " PM"
                        dgvResources.AutoResizeColumn(x)

                        If Weekday(_LoopDate) = vbSunday Or Weekday(_LoopDate) = vbSaturday Then
                            dgvResources.Item(x, y).Style.BackColor = Color.Black
                            dgvResources.Item(x, y).Style.ForeColor = Color.White
                            dgvResources.Item(x, y + 1).Style.BackColor = Color.Black
                            dgvResources.Item(x, y + 1).Style.ForeColor = Color.White
                        End If
                    End If

                    For myHalfDay As Integer = 1 To 2

                        Dim thisProjectResource As New myPlanResource
                        thisProjectResource.CE_ID_ProjectMember = thisProjetMember.ID_ProjectMember
                        thisProjectResource.PlanDate = _LoopDate

                        'Ressource du matin
                        thisProjectResource.HalfDay = myHalfDay
                        thisProjectResource.GetResourceFromDateAndMember()

                        If thisProjectResource.CE_ID_AdminResource <> 0 Then
                            'C'est une ressource administrative
                            Dim _myAdminResource As New myAdminResource
                            _myAdminResource.ID_AdminResource = thisProjectResource.CE_ID_AdminResource
                            _myAdminResource.read()

                            Select Case myHalfDay
                                Case 1
                                    'matin

                                    'Affichage de la ressource administrative
                                    If Len(thisProjectResource.Remark) > 0 Then
                                        dgvResources.Item(x + 1, y).Value = "(*) " & _myAdminResource.AdminResource
                                    Else
                                        dgvResources.Item(x + 1, y).Value = _myAdminResource.AdminResource
                                    End If

                                    'Affichage du tooltiptext
                                    If Len(thisProjectResource.Remark) > 0 Then
                                        dgvResources.Item(x + 1, y).ToolTipText = _myAdminResource.AdminResource & vbCrLf & StrDup(15, Chr(151)) & vbCrLf & thisProjectResource.Remark
                                    Else
                                        dgvResources.Item(x + 1, y).ToolTipText = _myAdminResource.AdminResource
                                    End If

                                    'Affichage de la couleur en cas de blocage
                                    If thisProjectResource.Blocked = True Then
                                        dgvResources.Item(x + 1, y).Style.BackColor = Color.SlateGray
                                    Else
                                        dgvResources.Item(x + 1, y).Style.BackColor = Color.LightGray
                                    End If

                                    'Centrer le texte
                                    dgvResources.Item(x + 1, y).Style.Alignment = DataGridViewContentAlignment.MiddleCenter



                                Case 2
                                    'après-midi

                                    'Affichage de la ressource administrative
                                    If Len(thisProjectResource.Remark) > 0 Then
                                        dgvResources.Item(x + 1, y + 1).Value = "(*) " & _myAdminResource.AdminResource
                                    Else
                                        dgvResources.Item(x + 1, y + 1).Value = _myAdminResource.AdminResource
                                    End If

                                    'Affichage du tooltiptext
                                    If Len(thisProjectResource.Remark) > 0 Then
                                        dgvResources.Item(x + 1, y + 1).ToolTipText = _myAdminResource.AdminResource & vbCrLf & StrDup(15, Chr(151)) & vbCrLf & thisProjectResource.Remark
                                    Else
                                        dgvResources.Item(x + 1, y + 1).ToolTipText = _myAdminResource.AdminResource
                                    End If

                                    'Affichage de la couleur en cas de blocage
                                    If thisProjectResource.Blocked = True Then
                                        dgvResources.Item(x + 1, y + 1).Style.BackColor = Color.SlateGray
                                    Else
                                        dgvResources.Item(x + 1, y + 1).Style.BackColor = Color.LightGray
                                    End If

                                    'Centrer le texte
                                    dgvResources.Item(x + 1, y + 1).Style.Alignment = DataGridViewContentAlignment.MiddleCenter


                            End Select

                        End If


                        If thisProjectResource.CE_ID_Project <> 0 Then
                            'C'est une ressource de projet
                            Dim _myProject As New myProject
                            _myProject.ID_Project = thisProjectResource.CE_ID_Project
                            _myProject.Read()

                            Select Case myHalfDay
                                Case 1
                                    'matin

                                    'Affichage du projet
                                    If Len(thisProjectResource.Remark) > 0 Then
                                        dgvResources.Item(x + 1, y).Value = "(*) " & _myProject.Title
                                    Else
                                        dgvResources.Item(x + 1, y).Value = _myProject.Title
                                    End If

                                    'Affichage du tooltiptext
                                    If Len(thisProjectResource.Remark) > 0 Then
                                        dgvResources.Item(x + 1, y).ToolTipText = _myProject.Title & vbCrLf & StrDup(15, Chr(151)) & vbCrLf & thisProjectResource.Remark
                                    Else
                                        dgvResources.Item(x + 1, y).ToolTipText = _myProject.Title
                                    End If

                                    'Affichage de la couleur en cas de blocage
                                    If thisProjectResource.Blocked = True Then
                                        dgvResources.Item(x + 1, y).Style.BackColor = Color.ForestGreen
                                    Else
                                        dgvResources.Item(x + 1, y).Style.BackColor = Color.LightGreen
                                    End If

                                    'Centrer le texte
                                    dgvResources.Item(x + 1, y).Style.Alignment = DataGridViewContentAlignment.MiddleCenter

                                Case 2
                                    'après-midi

                                    'Affichage du projet
                                    If Len(thisProjectResource.Remark) > 0 Then
                                        dgvResources.Item(x + 1, y + 1).Value = "(*) " & _myProject.Title
                                    Else
                                        dgvResources.Item(x + 1, y + 1).Value = _myProject.Title
                                    End If

                                    'Affichage du tooltiptext
                                    If Len(thisProjectResource.Remark) > 0 Then
                                        dgvResources.Item(x + 1, y + 1).ToolTipText = _myProject.Title & vbCrLf & StrDup(15, Chr(151)) & vbCrLf & thisProjectResource.Remark
                                    Else
                                        dgvResources.Item(x + 1, y + 1).ToolTipText = _myProject.Title
                                    End If

                                    'Affichage de la couleur en cas de blocage
                                    If thisProjectResource.Blocked = True Then
                                        dgvResources.Item(x + 1, y + 1).Style.BackColor = Color.ForestGreen
                                    Else
                                        dgvResources.Item(x + 1, y + 1).Style.BackColor = Color.LightGreen
                                    End If

                                    'Centrer le texte
                                    dgvResources.Item(x + 1, y + 1).Style.Alignment = DataGridViewContentAlignment.MiddleCenter

                            End Select

                        End If

                        If thisProjectResource.CE_ID_Project = 0 And thisProjectResource.CE_ID_AdminResource = 0 And (Weekday(_LoopDate) = vbSaturday Or Weekday(_LoopDate) = vbSunday) Then
                            'C'est un week-end il n'y a rien de planifié, on met en noir

                            Select Case myHalfDay
                                Case 1
                                    'matin
                                    dgvResources.Item(x + 1, y).Style.BackColor = Color.Black

                                Case 2
                                    'après-midi
                                    dgvResources.Item(x + 1, y + 1).Style.BackColor = Color.Black
                            End Select


                        End If

                    Next myHalfDay




                    'Compteur de lignes (dates)
                    'Modification pour HalfDay
                    'y = y + 1
                    y = y + 2

                    'On passe à la date suivante
                    _LoopDate = DateAdd(DateInterval.Day, 1, _LoopDate)

                    dgvResources.Refresh()

                Loop




                'Compteur de colonnes (membres de projets)
                x = x + 1



            End While







        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try

    End Sub
End Class