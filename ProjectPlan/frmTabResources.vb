Imports System.Data.SqlClient

Public Class frmTabResources

    Dim thisRow As String = ""
    Dim thisColumn As String = ""


    Public Sub pDisplayResourcesTable()

        Try

            Dim thisMinDate As Date = Nothing
            Dim thisMaxDate As Date = Nothing

            'On vide le DataGridView
            dgvResources.Rows.Clear()
            dgvResources.Columns.Clear()


            'Définition du DataGridView
            dgvResources.ReadOnly = True
            dgvResources.AllowUserToAddRows = False
            dgvResources.AllowUserToDeleteRows = False

            'dgvTabResources.MultiSelect = False
            dgvResources.MultiSelect = True


            'On recherche les dates la plus grande et la plus petite dans le filtre
            Dim thisProjectResources As New myPlanResource
            thisMinDate = dtpDateFrom.Value
            thisMaxDate = dtpDateTo.Value

            'On lit le filtre du membre de projet
            Dim Filter_ID_ProjectMember As String = DirectCast(lovProjectMember.SelectedItem, KeyValuePair(Of String, String)).Key

            'On lit le filtre de la tâche
            Dim Filter_ID_Task As String = DirectCast(lovTasks.SelectedItem, KeyValuePair(Of String, String)).Key


            'On recherche le nombre de membres de projet qui ont des ressources planifiées
            thisProjectResources.GetProjectMembersCount()


            'On définit les variables pour les boucles
            Dim x As Integer = 0
            Dim y As Integer = 0

            Dim _LoopDate As Date
            Dim _LoopColumn As Integer = 0
            Dim _LoopRow As Integer = 0



            'On définit les membres de projets à afficher
            Dim SQL As String = ""


            If Filter_ID_ProjectMember = 0 And Filter_ID_Task = 0 Then
                SQL = "SELECT ID_ProjectMember FROM ProjectsMembers WHERE Enable = 1 ORDER BY CE_ID_Task, ID_ProjectMember ASC"
            End If

            If Filter_ID_ProjectMember = 0 And Filter_ID_Task > 0 Then
                SQL = "SELECT ID_ProjectMember FROM ProjectsMembers WHERE Enable = 1  AND CE_ID_Task = " & Filter_ID_Task & " ORDER BY CE_ID_Task, ID_ProjectMember ASC"
            End If

            If Filter_ID_ProjectMember > 0 And Filter_ID_Task = 0 Then
                SQL = "SELECT ID_ProjectMember FROM ProjectsMembers WHERE Enable = 1  AND ID_ProjectMember = " & Filter_ID_ProjectMember & " ORDER BY CE_ID_Task, ID_ProjectMember ASC"
            End If

            If Filter_ID_ProjectMember > 0 And Filter_ID_Task > 0 Then
                SQL = "SELECT ID_ProjectMember FROM ProjectsMembers WHERE Enable = 1  AND CE_ID_Task = " & Filter_ID_Task & " AND ID_ProjectMember = " & Filter_ID_ProjectMember & " ORDER BY CE_ID_Task, ID_ProjectMember ASC"
            End If







            'On lit tous les membres de projets
            Dim MySQLConnection As New SqlConnection
            Dim mySQLDataReader As SqlDataReader
            'Dim Sql As String = "SELECT DISTINCT CE_ID_ProjectMember FROM PlanResources "
            'SQL &= "WHERE PlanDate >='" & fConvertDateTimeSQL(dtpDateFrom.Value) & "' "
            'Sql &= "AND PlanDate <='" & fConvertDateTimeSQL(dtpDateTo.Value) & "' ORDER BY CE_ID_ProjectMember ASC;"



            'Si on ne filtre pas sur les membres de projets, on prend tout le monde
            'If Filter_ID_ProjectMember = 0 Then
            '    Sql = "SELECT DISTINCT CE_ID_ProjectMember FROM PlanResources WHERE PlanDate >='" & fConvertDateTimeSQL(dtpDateFrom.Value) & "' AND PlanDate <='" & fConvertDateTimeSQL(dtpDateTo.Value) & "' ORDER BY CE_ID_ProjectMember ASC;"
            'Else
            '    Sql = "SELECT DISTINCT CE_ID_ProjectMember FROM PlanResources WHERE CE_ID_ProjectMember = " & Filter_ID_ProjectMember & " AND PlanDate >='" & fConvertDateTimeSQL(dtpDateFrom.Value) & "' AND PlanDate <='" & fConvertDateTimeSQL(dtpDateTo.Value) & "' ORDER BY CE_ID_ProjectMember ASC;"
            'End If



            MySQLConnection.ConnectionString = cnProjectPlan
            MySQLConnection.Open()
            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)
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
                dgvResources.Columns(x + 1).Width = 160




                y = 0
                _LoopDate = thisMinDate

                Do Until _LoopDate > thisMaxDate

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

                Loop




                'Compteur de colonnes (membres de projets)
                x = x + 1

                dgvResources.Refresh()


            End While

            mySQLDataReader.Close()
            MySQLConnection.Close()




        Catch ex As Exception

            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try


    End Sub

    Private Sub frmTabResources_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Me.WindowState = FormWindowState.Maximized

        Try

            'Définition du filtre par défaut
            Me.dtpDateFrom.Value = Today
            Me.dtpDateTo.Value = DateAdd(DateInterval.Day, 30, Today)

            pPopulateProjectMembers()

            pPopulateTasks()

            pDisplayResourcesTable()

        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try


    End Sub

    Private Sub pPopulateProjectMembers()

        Try

            Me.lovProjectMember.Items.Clear()

            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT ID_ProjectMember FROM ProjectsMembers WHERE Enable = 1 ORDER BY ID_ProjectMember ASC ;"
            Dim MySQLConnection As New SqlConnection

            Dim ID_ProjectMember As Integer = 0
            Dim myDictionnary As New Dictionary(Of String, String)()

            'On insère une ligne vide
            myDictionnary.Add(Str(0), "")

            MySQLConnection.ConnectionString = cnProjectPlan
            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)
            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read


                Try
                    ID_ProjectMember = mySQLDataReader.GetValue(0)
                Catch ex As Exception
                End Try

                Dim myProjectMember As New myProjectMember
                myProjectMember.ID_ProjectMember = ID_ProjectMember
                myProjectMember.Read()

                myDictionnary.Add(Str(myProjectMember.ID_ProjectMember), myProjectMember.FullName)

            End While

            mySQLDataReader.Close()
            MySQLConnection.Close()

            Me.lovProjectMember.DataSource = New BindingSource(myDictionnary, Nothing)
            Me.lovProjectMember.DisplayMember = "Value"
            Me.lovProjectMember.ValueMember = "Key"

            Me.lovProjectMember.SelectedIndex = 0

        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Sub pPopulateTasks()

        Try

            Me.lovTasks.Items.Clear()

            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT ID_Task FROM Tasks WHERE Enable = 1 ORDER BY DisplayOrder ASC "
            Dim MySQLConnection As New SqlConnection

            Dim ID_Task As Integer = 0
            Dim myDictionnary As New Dictionary(Of String, String)()

            'On insère une ligne vide
            myDictionnary.Add(Str(0), "")

            MySQLConnection.ConnectionString = cnProjectPlan
            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)
            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read


                Try
                    ID_Task = mySQLDataReader.GetValue(0)
                Catch ex As Exception
                End Try

                Dim myTask As New myTask
                myTask.ID_Task = ID_Task
                myTask.Read()

                myDictionnary.Add(Str(myTask.ID_Task), myTask.Task)

            End While

            mySQLDataReader.Close()
            MySQLConnection.Close()

            Me.lovTasks.DataSource = New BindingSource(myDictionnary, Nothing)
            Me.lovTasks.DisplayMember = "Value"
            Me.lovTasks.ValueMember = "Key"

            Me.lovTasks.SelectedIndex = 0

        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try

    End Sub

    'Private Sub dvgtabresources_CellMouseEnter(sender As Object, e As MouseEventArgs) Handles dgvTabResources.MouseHover
    '    Try
    '        'Debug.Print(dgvTabResources.Item(e.ColumnIndex, e.RowIndex).Value.ToString())
    '        Dim X, Y As Integer

    '        Dim hit As DataGridView.HitTestInfo = dgvTabResources.HitTest(e.X, e.Y)
    '        X = 0


    '        'If hit.Type = DataGridViewHitTestType.Cell Then


    '        '    If Not hit Is m_HoveredItem Then
    '        '        Me.ToolTip2.Hide(Me.DataGridView1)
    '        '        m_HoveredItem = hit
    '        '        If hit Is Nothing Then
    '        '            Me.ToolTip2.SetToolTip(Me.DataGridView1, "")
    '        '        Else
    '        '            'Me.ToolTip2.SetToolTip(Me.DataGridView1, ConnectedUsers(Me.DataGridView1.Rows(hit.RowIndex).Cells("Database").Value, Instance))
    '        '            Me.ToolTip2.Show(ConnectedUsers(Me.DataGridView1.Rows(hit.RowIndex).Cells("Database").Value, Instance), DataGridView1, e.X, e.Y)
    '        '        End If
    '        '    End If

    '        'End If
    '    Catch ex As Exception
    '    End Try

    'End Sub

    Private Sub dgvTabResources_DoubleCellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResources.CellDoubleClick

        Try

            'Lecture de la date planifiée
            Dim _PlanDate As Date
            _PlanDate = dgvResources.Item(0, e.RowIndex).Value

            'Lecture du membre de projet
            Dim _Member As String
            _Member = dgvResources.Columns(e.ColumnIndex).HeaderText

            'Définition des variables pour le messagebox
            Dim Message As String = ""
            Dim Caption As String = ""
            Dim Buttons As MessageBoxButtons
            Dim Icon As MessageBoxIcon
            Dim Result As New DialogResult

            'Validation de la suppression
            Message &= dgvResources.Item(e.ColumnIndex, e.RowIndex).Value.ToString() & vbCrLf & "Pour :" & _Member & vbCrLf & "Date : " & Format(_PlanDate, "D")
            Message &= vbCrLf & vbCrLf & "Voulez-vous vraiment supprimer cette planification ?"
            Caption = "Confirmation de planification"
            Buttons = MessageBoxButtons.YesNo
            Icon = MessageBoxIcon.Question
            Result = MessageBox.Show(Message, Caption, Buttons, Icon)

            If Result = vbYes Then

                'On enclenche le sablier
                Cursor.Current = Cursors.WaitCursor

                'On determine l'ID du membre de projet
                Dim _myMember As New myProjectMember
                _myMember.FullName = _Member
                _myMember.GetIDMemberFromFullName()

                'On determe l'ID de la resource et on efface l'enregistrement
                Dim thisProjectResource As New myPlanResource
                thisProjectResource.CE_ID_ProjectMember = _myMember.ID_ProjectMember
                thisProjectResource.PlanDate = _PlanDate
                thisProjectResource.GetResourceFromDateAndMember()
                thisProjectResource.Delete()

                'On actualise la table
                pDisplayResourcesTable()

                Cursor.Current = Cursors.Default

            End If


        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgvTabResources_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvResources.MouseUp
        Try
            If e.Button <> MouseButtons.Right Then Return

            Dim cms = New ContextMenuStrip

            'Pour détermine la cellule sélectionnée
            Dim ht As DataGridView.HitTestInfo
            ht = Me.dgvResources.HitTest(e.X, e.Y)
            thisRow = ht.RowIndex
            thisColumn = ht.ColumnIndex

            Dim _row As Integer = CInt(thisRow)
            Dim _col As Integer = CInt(thisColumn)
            Me.dgvResources.CurrentCell = Me.dgvResources(_col, _row)

            Dim item1 = cms.Items.Add("Effacer")
            item1.Tag = 1
            AddHandler item1.Click, AddressOf menuChoice

            Dim item2 = cms.Items.Add("Insérer une/des tâche/s administrative/s")
            item2.Tag = 2
            AddHandler item2.Click, AddressOf menuChoice

            Dim item3 = cms.Items.Add("Insérer un/des projet/s")
            item3.Tag = 3
            AddHandler item3.Click, AddressOf menuChoice

            Dim item4 = cms.Items.Add(StrDup(20, Chr(151)))
            item4.Tag = 4
            AddHandler item4.Click, AddressOf menuChoice

            Dim item5 = cms.Items.Add("Bloquer une/des date/s")
            item5.Tag = 5
            AddHandler item5.Click, AddressOf menuChoice

            Dim item6 = cms.Items.Add("Débloquer une/des date/s")
            item6.Tag = 6
            AddHandler item6.Click, AddressOf menuChoice

            Dim item7 = cms.Items.Add(StrDup(20, Chr(151)))
            item7.Tag = 7
            AddHandler item7.Click, AddressOf menuChoice

            Dim item8 = cms.Items.Add("Ajouter une/des remarque/s")
            item8.Tag = 8
            AddHandler item8.Click, AddressOf menuChoice

            Dim item9 = cms.Items.Add("Effacer une/des remarque/s")
            item9.Tag = 9
            AddHandler item9.Click, AddressOf menuChoice

            '-- etc
            '..

            cms.Show(dgvResources, e.Location)


        Catch ex As Exception

        End Try
    End Sub

    Private Sub menuChoice(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim item = CType(sender, ToolStripMenuItem)
            Dim selection = CInt(item.Tag)

            If selection = 1 Then

                'effacer des ressources avec sélection multiple

                'On enclenche le sablier
                Cursor.Current = Cursors.WaitCursor

                Dim mySelectedCell As DataGridViewTextBoxCell
                For Each mySelectedCell In dgvResources.SelectedCells
                    Dim myCol As Integer = mySelectedCell.ColumnIndex
                    Dim myRow As Integer = mySelectedCell.RowIndex

                    Dim myText As String = dgvResources.Item(0, myRow).Value
                    Dim myDate As Date = dgvResources.Item(0, myRow).Value
                    Dim myHalfDay As Integer = 0
                    Dim myMember As String = ""

                    Select Case UCase(Strings.Right(myText, 2))
                        Case "AM"
                            myHalfDay = 1
                        Case "PM"
                            myHalfDay = 2
                    End Select

                    'Recherche de l'ID_ProjectMember
                    Dim myFindMember As New myProjectMember
                    myMember = dgvResources.Columns(myCol).HeaderText
                    myFindMember.FullName = myMember
                    myFindMember.GetIDMemberFromFullName()

                    'On determe l'ID de la resource et on efface l'enregistrement
                    Dim myPlanRes As New myPlanResource
                    myPlanRes.CE_ID_ProjectMember = myFindMember.ID_ProjectMember
                    myPlanRes.PlanDate = myDate
                    myPlanRes.HalfDay = myHalfDay
                    myPlanRes.GetResourceFromDateAndMember()
                    myPlanRes.Delete()

                    'MsgBox("Row : " & myRow & ", Column : " & myCol & vbCrLf & "Text : " & myText & vbCrLf & "Date : " & myDate & vbCrLf & "Member : " & myFindMember.FullName)

                Next mySelectedCell

                'On actualise la table
                pDisplayResourcesTable()

                'On déclenche le sablier
                Cursor.Current = Cursors.Default

            End If

            If selection = 2 Then
                'Ajout d'une tâche administrative avec sélection multiple

                'On reset la variable globale
                G_ID_ResourceAdmin = 0

                'On affiche la fenêtre des ressouces administratives
                Dim myForm As Form = frmResourceAdminList
                myForm.ShowDialog()
                myForm.Dispose()

                'On enclenche le sablier
                Cursor.Current = Cursors.WaitCursor

                Dim mySelectedCell As DataGridViewTextBoxCell
                For Each mySelectedCell In dgvResources.SelectedCells
                    Dim myCol As Integer = mySelectedCell.ColumnIndex
                    Dim myRow As Integer = mySelectedCell.RowIndex

                    Dim myText As String = dgvResources.Item(0, myRow).Value
                    Dim myDate As Date = dgvResources.Item(0, myRow).Value
                    Dim myHalfDay As Integer = 0
                    Dim myMember As String = ""

                    Select Case UCase(Strings.Right(myText, 2))
                        Case "AM"
                            myHalfDay = 1
                        Case "PM"
                            myHalfDay = 2
                    End Select

                    'Recherche de l'ID_ProjectMember
                    Dim myFindMember As New myProjectMember
                    myMember = dgvResources.Columns(myCol).HeaderText
                    myFindMember.FullName = myMember
                    myFindMember.GetIDMemberFromFullName()

                    Dim thisPlan As New myPlanResource
                    If G_ID_ResourceAdmin <> 0 Then
                        'On ne sauve QUE si on a une tâche administrative sélectionnée (<> 0)
                        thisPlan.CE_ID_ProjectMember = myFindMember.ID_ProjectMember
                        thisPlan.CE_ID_AdminResource = G_ID_ResourceAdmin
                        thisPlan.PlanDate = myDate
                        thisPlan.HalfDay = myHalfDay
                        thisPlan.Save()
                    End If

                    'MsgBox("Row : " & myRow & ", Column : " & myCol & vbCrLf & "Text : " & myText & vbCrLf & "Date : " & myDate & vbCrLf & "Member : " & myFindMember.FullName)

                Next mySelectedCell

                'On reset la variable globale
                G_ID_ResourceAdmin = 0

                'On actualise la table
                pDisplayResourcesTable()

                'On déclenche le sablier
                Cursor.Current = Cursors.Default



            End If

            If selection = 3 Then
                'Ajout d'un projet avec sélection multiple


                'On reset la variable globale
                G_ID_ResourceProject = 0

                'On affiche la fenêtre des projets
                Dim myForm As Form = frmResourceProjectList
                myForm.ShowDialog()
                myForm.Dispose()

                'On enclenche le sablier
                Cursor.Current = Cursors.WaitCursor

                Dim mySelectedCell As DataGridViewTextBoxCell
                For Each mySelectedCell In dgvResources.SelectedCells
                    Dim myCol As Integer = mySelectedCell.ColumnIndex
                    Dim myRow As Integer = mySelectedCell.RowIndex

                    Dim myText As String = dgvResources.Item(0, myRow).Value
                    Dim myDate As Date = dgvResources.Item(0, myRow).Value
                    Dim myHalfDay As Integer = 0
                    Dim myMember As String = ""

                    Select Case UCase(Strings.Right(myText, 2))
                        Case "AM"
                            myHalfDay = 1
                        Case "PM"
                            myHalfDay = 2
                    End Select

                    'Recherche de l'ID_ProjectMember
                    Dim myFindMember As New myProjectMember
                    myMember = dgvResources.Columns(myCol).HeaderText
                    myFindMember.FullName = myMember
                    myFindMember.GetIDMemberFromFullName()

                    Dim thisPlan As New myPlanResource
                    If G_ID_ResourceProject <> 0 Then
                        'On ne sauve QUE si on a un projet sélectionné (<> 0)
                        thisPlan.CE_ID_ProjectMember = myFindMember.ID_ProjectMember
                        thisPlan.PlanDate = myDate
                        thisPlan.HalfDay = myHalfDay
                        thisPlan.CE_ID_Project = G_ID_ResourceProject
                        thisPlan.Save()
                    End If

                    'MsgBox("Row : " & myRow & ", Column : " & myCol & vbCrLf & "Text : " & myText & vbCrLf & "Date : " & myDate & vbCrLf & "Member : " & myFindMember.FullName)

                Next mySelectedCell

                'On reset la variable globale
                G_ID_ResourceProject = 0

                'On actualise la table
                pDisplayResourcesTable()

                'On déclenche le sablier
                Cursor.Current = Cursors.Default



            End If

            If selection = 4 Then
                'On ne fait rien, c'est une ligne
            End If

            If selection = 5 Then

                ' Bloquer des dates avec sélection multiple

                'On enclenche le sablier
                Cursor.Current = Cursors.WaitCursor

                Dim mySelectedCell As DataGridViewTextBoxCell
                For Each mySelectedCell In dgvResources.SelectedCells
                    Dim myCol As Integer = mySelectedCell.ColumnIndex
                    Dim myRow As Integer = mySelectedCell.RowIndex

                    Dim myText As String = dgvResources.Item(0, myRow).Value
                    Dim myDate As Date = dgvResources.Item(0, myRow).Value
                    Dim myHalfDay As Integer = 0
                    Dim myMember As String = ""

                    Select Case UCase(Strings.Right(myText, 2))
                        Case "AM"
                            myHalfDay = 1
                        Case "PM"
                            myHalfDay = 2
                    End Select

                    'Recherche de l'ID_ProjectMember
                    Dim myFindMember As New myProjectMember
                    myMember = dgvResources.Columns(myCol).HeaderText
                    myFindMember.FullName = myMember
                    myFindMember.GetIDMemberFromFullName()

                    'On determe l'ID de la resource et on efface l'enregistrement
                    Dim myPlanRes As New myPlanResource
                    myPlanRes.CE_ID_ProjectMember = myFindMember.ID_ProjectMember
                    myPlanRes.PlanDate = myDate
                    myPlanRes.HalfDay = myHalfDay
                    myPlanRes.GetResourceFromDateAndMember()
                    myPlanRes.Blocked = True
                    myPlanRes.Save()

                Next mySelectedCell


                'On actualise la table
                pDisplayResourcesTable()

                'On déclenche le sablier
                Cursor.Current = Cursors.Default



            End If

            If selection = 6 Then

                ' Déboquer des dates avec sélection multiple

                'On enclenche le sablier
                Cursor.Current = Cursors.WaitCursor

                Dim mySelectedCell As DataGridViewTextBoxCell
                For Each mySelectedCell In dgvResources.SelectedCells
                    Dim myCol As Integer = mySelectedCell.ColumnIndex
                    Dim myRow As Integer = mySelectedCell.RowIndex

                    Dim myText As String = dgvResources.Item(0, myRow).Value
                    Dim myDate As Date = dgvResources.Item(0, myRow).Value
                    Dim myHalfDay As Integer = 0
                    Dim myMember As String = ""

                    Select Case UCase(Strings.Right(myText, 2))
                        Case "AM"
                            myHalfDay = 1
                        Case "PM"
                            myHalfDay = 2
                    End Select

                    'Recherche de l'ID_ProjectMember
                    Dim myFindMember As New myProjectMember
                    myMember = dgvResources.Columns(myCol).HeaderText
                    myFindMember.FullName = myMember
                    myFindMember.GetIDMemberFromFullName()

                    'On determe l'ID de la resource et on efface l'enregistrement
                    Dim myPlanRes As New myPlanResource
                    myPlanRes.CE_ID_ProjectMember = myFindMember.ID_ProjectMember
                    myPlanRes.PlanDate = myDate
                    myPlanRes.HalfDay = myHalfDay
                    myPlanRes.GetResourceFromDateAndMember()
                    myPlanRes.Blocked = False
                    myPlanRes.Save()

                Next mySelectedCell


                'On actualise la table
                pDisplayResourcesTable()

                'On déclenche le sablier
                Cursor.Current = Cursors.Default



            End If

            If selection = 7 Then
                'On ne fait rien, c'est une ligne
            End If

            If selection = 8 Then

                'Ajouter une remarque avec sélection multiple

                Dim myRemark As String = ""

                myRemark = InputBox("Introduire le texte :", "Remarque")

                If myRemark = "" Then Exit Sub

                'On enclenche le sablier
                Cursor.Current = Cursors.WaitCursor

                Dim mySelectedCell As DataGridViewTextBoxCell
                For Each mySelectedCell In dgvResources.SelectedCells
                    Dim myCol As Integer = mySelectedCell.ColumnIndex
                    Dim myRow As Integer = mySelectedCell.RowIndex

                    Dim myText As String = dgvResources.Item(0, myRow).Value
                    Dim myDate As Date = dgvResources.Item(0, myRow).Value
                    Dim myHalfDay As Integer = 0
                    Dim myMember As String = ""

                    Select Case UCase(Strings.Right(myText, 2))
                        Case "AM"
                            myHalfDay = 1
                        Case "PM"
                            myHalfDay = 2
                    End Select

                    'Recherche de l'ID_ProjectMember
                    Dim myFindMember As New myProjectMember
                    myMember = dgvResources.Columns(myCol).HeaderText
                    myFindMember.FullName = myMember
                    myFindMember.GetIDMemberFromFullName()

                    'On determe l'ID de la resource et on efface l'enregistrement
                    Dim myPlanRes As New myPlanResource
                    myPlanRes.CE_ID_ProjectMember = myFindMember.ID_ProjectMember
                    myPlanRes.PlanDate = myDate
                    myPlanRes.HalfDay = myHalfDay
                    myPlanRes.GetResourceFromDateAndMember()
                    myPlanRes.Remark = myRemark
                    myPlanRes.Save()

                Next mySelectedCell


                'On actualise la table
                pDisplayResourcesTable()

                'On déclenche le sablier
                Cursor.Current = Cursors.Default


            End If

            If selection = 9 Then

                'Effacer une/des remarque/s avec sélection multiple

                'On enclenche le sablier
                Cursor.Current = Cursors.WaitCursor

                Dim mySelectedCell As DataGridViewTextBoxCell
                For Each mySelectedCell In dgvResources.SelectedCells
                    Dim myCol As Integer = mySelectedCell.ColumnIndex
                    Dim myRow As Integer = mySelectedCell.RowIndex

                    Dim myText As String = dgvResources.Item(0, myRow).Value
                    Dim myDate As Date = dgvResources.Item(0, myRow).Value
                    Dim myHalfDay As Integer = 0
                    Dim myMember As String = ""

                    Select Case UCase(Strings.Right(myText, 2))
                        Case "AM"
                            myHalfDay = 1
                        Case "PM"
                            myHalfDay = 2
                    End Select

                    'Recherche de l'ID_ProjectMember
                    Dim myFindMember As New myProjectMember
                    myMember = dgvResources.Columns(myCol).HeaderText
                    myFindMember.FullName = myMember
                    myFindMember.GetIDMemberFromFullName()

                    'On determe l'ID de la resource et on efface l'enregistrement
                    Dim myPlanRes As New myPlanResource
                    myPlanRes.CE_ID_ProjectMember = myFindMember.ID_ProjectMember
                    myPlanRes.PlanDate = myDate
                    myPlanRes.HalfDay = myHalfDay
                    myPlanRes.GetResourceFromDateAndMember()
                    myPlanRes.Remark = ""
                    myPlanRes.Save()

                Next mySelectedCell


                'On actualise la table
                pDisplayResourcesTable()

                'On déclenche le sablier
                Cursor.Current = Cursors.Default


            End If

        Catch ex As Exception

            If DebugFlag = True Then MessageBox.Show(ex.ToString)

        End Try
    End Sub

    Private Sub btcDisplay_Click(sender As Object, e As EventArgs) Handles btcFilter.Click

        Try

            Cursor.Current = Cursors.WaitCursor
            pDisplayResourcesTable()
            Cursor.Current = Cursors.Default

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btcFilterClear_Click(sender As Object, e As EventArgs) Handles btcFilterClear.Click

        Try

            Cursor.Current = Cursors.WaitCursor

            Me.dtpDateFrom.Value = fPlanResourceGetMinDate()
            Me.dtpDateTo.Value = fPlanResourceGetMaxDate()

            pDisplayResourcesTable()
            Cursor.Current = Cursors.Default

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btcFilter30Days_Click(sender As Object, e As EventArgs) Handles btcFilter30Days.Click

        Try

            Cursor.Current = Cursors.WaitCursor

            'Définition du filtre par défaut (30 Jours)
            Me.dtpDateFrom.Value = Today
            Me.dtpDateTo.Value = DateAdd(DateInterval.Day, 30, Today)

            pDisplayResourcesTable()
            Cursor.Current = Cursors.Default

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btcAdminResource_Click(sender As Object, e As EventArgs) Handles btcAdminResource.Click

        Try

            Dim myForm As Form = frmResourceAdmin
            myForm.ShowDialog()
            myForm.Dispose()

            'Cursor.Current = Cursors.WaitCursor
            'pDisplayResourcesTable()
            'Cursor.Current = Cursors.Default

        Catch ex As Exception

        End Try


    End Sub

    Private Sub btcResources_Click(sender As Object, e As EventArgs) Handles btcResources.Click
        Try

            Dim myForm As Form = frmResourceProject
            myForm.ShowDialog()
            myForm.Dispose()

            'Cursor.Current = Cursors.WaitCursor
            'pDisplayResourcesTable()
            'Cursor.Current = Cursors.Default

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btcFermer_Click(sender As Object, e As EventArgs) Handles btcFermer.Click

        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btcGestion_Click(sender As Object, e As EventArgs) Handles btcGestion.Click
        Try


            Dim myForm As Form = frmManage
            myForm.ShowDialog()
            myForm.Dispose()

            'pDisplayResourcesTable()

        Catch ex As Exception

        End Try
    End Sub


End Class