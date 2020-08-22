Imports System.Data.SqlClient
'Imports Microsoft.VisualBasic
'Imports Microsoft.Office.Interop.Excel


Public Class frmDashboard

    'Définition des couleurs pour les tâches
    Dim ColorForTotal As Color = Color.LightBlue
    Dim ColorForInfra As Color = Color.LightGreen
    Dim ColorForSAP As Color = Color.Yellow
    Dim ColorForHelpdesk As Color = Color.Pink
    Dim ColorForPlaning As Color = Color.Orange

    'Définition de diverses variables
    Dim myColWidth As Integer = 60
    Dim i As Integer = 0

    'Définition des variables pour les totaux
    Dim myTotalInfra As Single = 0
    Dim myTotalSAP As Single = 0
    Dim myTotalHelpdesk As Single = 0
    Dim myTotalPlaning As Single = 0


    Private Sub pExportToExcel()

        Try


            Dim myApplication As Microsoft.Office.Interop.Excel.Application
            Dim myWorkbook As Microsoft.Office.Interop.Excel.Workbook
            Dim myWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
            myApplication = New Microsoft.Office.Interop.Excel.Application()
            myWorkbook = myApplication.Workbooks.Add()


            Dim NCol As Integer = dgvProjects.Columns.Count
            Dim NRow As Integer = dgvProjects.RowCount

            myWorkSheet = DirectCast(myWorkbook.Worksheets.Item(1), Microsoft.Office.Interop.Excel.Worksheet)

            'myApplication.Application.Visible = True


            'Définition des tâches
            myWorkSheet.Cells.Item(1, 4) = "Total"
            myWorkSheet.Cells.Item(1, 5) = "Total"
            myWorkSheet.Cells.Item(1, 6) = "Total"
            myWorkSheet.Cells.Item(1, 7) = "Total"
            myWorkSheet.Cells.Item(1, 8) = "Infrastructure"
            myWorkSheet.Cells.Item(1, 9) = "Infrastructure"
            myWorkSheet.Cells.Item(1, 10) = "Infrastructure"
            myWorkSheet.Cells.Item(1, 11) = "Infrastructure"
            myWorkSheet.Cells.Item(1, 12) = "SAP"
            myWorkSheet.Cells.Item(1, 13) = "SAP"
            myWorkSheet.Cells.Item(1, 14) = "SAP"
            myWorkSheet.Cells.Item(1, 15) = "SAP"
            myWorkSheet.Cells.Item(1, 16) = "Helpdesk"
            myWorkSheet.Cells.Item(1, 17) = "Helpdesk"
            myWorkSheet.Cells.Item(1, 18) = "Helpdesk"
            myWorkSheet.Cells.Item(1, 19) = "Helpdesk"
            myWorkSheet.Cells.Item(1, 20) = "Planification"
            myWorkSheet.Cells.Item(1, 21) = "Planification"
            myWorkSheet.Cells.Item(1, 22) = "Planification"
            myWorkSheet.Cells.Item(1, 23) = "Planification"



            'Exportation des entêtes de colonnes
            Dim Count = 1
            For i As Integer = 1 To NCol
                If dgvProjects.Columns(i - 1).Visible = True Then
                    myWorkSheet.Cells.Item(2, Count) = dgvProjects.Columns(i - 1).Name
                    Count = Count + 1
                End If
            Next


            'Exportation des données
            For i As Integer = 0 To dgvProjects.Rows.Count - 1
                Dim cant As Integer = 1
                For j As Integer = 0 To dgvProjects.Columns.Count - 1
                    If dgvProjects.Columns(j).Visible = True Then
                        myWorkSheet.Cells(i + 3, cant) = dgvProjects.Rows(i).Cells(j).Value
                        cant = cant + 1
                    End If
                Next
            Next

            'Définition des couleurs
            Dim MyColor As Color
            Dim MyColorRGB As Integer
            Dim myRange As String = ""

            'Total
            MyColor = ColorForTotal
            MyColorRGB = RGB(MyColor.R, MyColor.G, MyColor.B)
            myRange = CStr("D1:G" & dgvProjects.Rows.Count + 2)
            myWorkSheet.Range(myRange).Interior.Color = MyColorRGB

            'Infrastructure
            MyColor = ColorForInfra
            MyColorRGB = RGB(MyColor.R, MyColor.G, MyColor.B)
            myRange = CStr("H1:K" & dgvProjects.Rows.Count + 2)
            myWorkSheet.Range(myRange).Interior.Color = MyColorRGB

            'SAP
            MyColor = ColorForSAP
            MyColorRGB = RGB(MyColor.R, MyColor.G, MyColor.B)
            myRange = CStr("L1:O" & dgvProjects.Rows.Count + 2)
            myWorkSheet.Range(myRange).Interior.Color = MyColorRGB

            'Helpdesk
            MyColor = ColorForHelpdesk
            MyColorRGB = RGB(MyColor.R, MyColor.G, MyColor.B)
            myRange = CStr("P1:S" & dgvProjects.Rows.Count + 2)
            myWorkSheet.Range(myRange).Interior.Color = MyColorRGB

            'Planification
            MyColor = ColorForPlaning
            MyColorRGB = RGB(MyColor.R, MyColor.G, MyColor.B)
            myRange = CStr("T1:W" & dgvProjects.Rows.Count + 2)
            myWorkSheet.Range(myRange).Interior.Color = MyColorRGB


            myWorkSheet.Rows.Item(1).Font.Bold = 1
            myWorkSheet.Rows.Item(2).Font.Bold = 1
            myWorkSheet.Rows.Item(dgvProjects.Rows.Count + 2).Font.Bold = 1
            myWorkSheet.Rows.Item(1).HorizontalAlignment = 3
            myWorkSheet.Columns.AutoFit()
            myApplication.Application.Visible = True


        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Sub frmDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'cnProjectPlan = cnProjectPlanWUM

        Me.Cursor = Cursors.WaitCursor

        Try


            'Hauteur des colonnes en automatique --> bug ???
            tabTaskType.SelectedTab = tabPlaning
            tabTaskType.SelectedTab = tabHelpdesk
            tabTaskType.SelectedTab = tabSAP
            tabTaskType.SelectedTab = tabInfrastructure


            'Affiche les projets
            pDisplayProjects()

            'Affiche les tâches : 1 = infrastructure
            pDisplayResouces(Me.dgvInfrastructure, 1)
            pDisplayResouces(Me.dgvSAP, 2)
            pDisplayResouces(Me.dgvHelpdesk, 3)
            pDisplayResouces(Me.dgvPlaning, 4)


            'Affiche les dates de libres
            pDisplayFreeDates()

            Me.Cursor = Cursors.Default

            myTotalInfra = 0
            myTotalSAP = 0
            myTotalHelpdesk = 0
            myTotalPlaning = 0

        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub pDisplayProjects()

        Try


            Dim TotalEstimated As Single = 0
            Dim TotalExecuted As Single = 0
            Dim TotalPlan As Single = 0
            Dim TotalToPlan As Single = 0

            Dim TotalInfraEstimated As Single = 0
            Dim TotalInfraExecuted As Single = 0
            Dim TotalInfraPlan As Single = 0
            Dim TotalInfraToPlan As Single = 0

            Dim TotalSAPEstimated As Single = 0
            Dim TotalSAPExecuted As Single = 0
            Dim TotalSAPPlan As Single = 0
            Dim TotalSAPToPlan As Single = 0

            Dim TotalHelpdeskEstimated As Single = 0
            Dim TotalHelpdeskExecuted As Single = 0
            Dim TotalHelpdeskPlan As Single = 0
            Dim TotalHelpdeskToPlan As Single = 0

            Dim TotalPlaningEstimated As Single = 0
            Dim TotalPlaningExecuted As Single = 0
            Dim TotalPlaningPlan As Single = 0
            Dim TotalPlaningToPlan As Single = 0

            Dim ActiveRow As Integer = 0
            Dim MySQLConnection As New SqlConnection

            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = ""
            Sql = "SELECT ID_Project FROM Projects WHERE CE_ID_Status IN (6,7,8,9);"

            Me.Cursor = Cursors.WaitCursor

            'On vide le DataGridView
            dgvProjects.Rows.Clear()
            dgvProjects.Columns.Clear()

            'On rend certains éléments invisible durant le chargement des données
            dgvProjects.Visible = False



            'Définition du DataGridView
            dgvProjects.ReadOnly = True
            dgvProjects.AllowUserToAddRows = False
            dgvProjects.AllowUserToDeleteRows = False
            dgvProjects.MultiSelect = False


            'Définition des colonnes
            dgvProjects.Columns.Add("ID", "ID")                         '0  ID_Project 
            dgvProjects.Columns.Add("Projet", "Projet")                 '1  Nom du projet
            dgvProjects.Columns.Add("Deadline", "Deadline")             '2  Deadline
            dgvProjects.Columns.Add("Estimées", "Estimées")             '3  Ressources estimées pour tout le projet
            dgvProjects.Columns.Add("Effectuées", "Effectuées")         '4  Ressources effectuées pour tout le projet
            dgvProjects.Columns.Add("Planifiées", "Planifiées")         '5  Ressources planifiées pour tout le projet
            dgvProjects.Columns.Add("A planifier", "A planifier")       '6  Ressources à encore à planifier pour tout le projet

            dgvProjects.Columns.Add("Estimées", "Estimées")             '7  Ressources estimées pour l'infra
            dgvProjects.Columns.Add("Effectuées", "Effectuées")         '8  Ressources effectuées pour l'infra
            dgvProjects.Columns.Add("Planifiées", "Planifiées")         '9  Ressources planifiées pour l'infra
            dgvProjects.Columns.Add("A planifier", "A planifier")       '10 Ressources à encore à planifier pour l'infra

            dgvProjects.Columns.Add("Estimées", "Estimées")             '11  Ressources estimées pour SAP
            dgvProjects.Columns.Add("Effectuées", "Effectuées")         '12  Ressources effectuées pour SAP
            dgvProjects.Columns.Add("Planifiées", "Planifiées")         '13  Ressources planifiées pour SAP
            dgvProjects.Columns.Add("A planifier", "A planifier")       '14 Ressources à encore à planifier pour SAP

            dgvProjects.Columns.Add("Estimées", "Estimées")             '15  Ressources estimées pour Helpdesk
            dgvProjects.Columns.Add("Effectuées", "Effectuées")         '16  Ressources effectuées pour Helpdesk
            dgvProjects.Columns.Add("Planifiées", "Planifiées")         '17  Ressources planifiées pour Helpdesk
            dgvProjects.Columns.Add("A planifier", "A planifier")       '18 Ressources à encore à planifier pour Helpdesk

            dgvProjects.Columns.Add("Estimées", "Estimées")             '19  Ressources estimées pour la planification
            dgvProjects.Columns.Add("Effectuées", "Effectuées")         '20  Ressources effectuées pour la planification
            dgvProjects.Columns.Add("Planifiées", "Planifiées")         '21  Ressources planifiées pour la planification
            dgvProjects.Columns.Add("A planifier", "A planifier")       '22 Ressources à encore à planifier pour la planification


            'La colonne 0 (ID_Project) n'est pas visible
            'dgvProjects.Columns(0).Visible = False
            For i = 0 To 21
                dgvProjects.Columns(i).Visible = True
            Next i

            'On empêche de trier les colonnes de manière alphabétiques
            For i = 0 To 21
                dgvProjects.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next i


            MySQLConnection.ConnectionString = cnProjectPlan
            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)

            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read

                Dim thisProject As New myProject
                Dim thisCategory As New myProjectCategory
                Dim thisPlan As New myPlanResource
                Dim thisExec As New myExecuteResource

                Try
                    'Lecture du projet
                    thisProject.ID_Project = mySQLDataReader.GetValue(0)
                    thisProject.Read()


                    'On ajoute le projet dans le DataGridView
                    dgvProjects.Rows.Add()
                    dgvProjects.Item(0, ActiveRow).Value = thisProject.ID_Project           'ID du projet
                    dgvProjects.Item(1, ActiveRow).Value = thisProject.Title                'Titre du projet
                    dgvProjects.Item(2, ActiveRow).Value = Format(thisProject.DeadLine, "dd.MM.yyyy")             'Deadline du projet
                    dgvProjects.Item(3, ActiveRow).Value = thisProject.EstimatedResources   'Ressources estimées totales
                    dgvProjects.Item(4, ActiveRow).Value = thisProject.EffectiveResources   'Ressources effectives totales
                    thisProject.GetPlanResources()
                    dgvProjects.Item(5, ActiveRow).Value = thisProject.PlanRessources       'Ressources planifiées totales

                    Dim RessourcesToPlan As Single = thisProject.EstimatedResources - thisProject.EffectiveResources - thisProject.PlanRessources
                    If RessourcesToPlan < 0 Then RessourcesToPlan = 0
                    dgvProjects.Item(6, ActiveRow).Value = RessourcesToPlan

                    TotalEstimated = TotalEstimated + thisProject.EstimatedResources
                    TotalExecuted = TotalExecuted + thisProject.EffectiveResources
                    TotalPlan = TotalPlan + thisProject.PlanRessources
                    TotalToPlan = TotalToPlan + RessourcesToPlan

                    '=================================================
                    'Début Définition des couleurs de fond
                    '=================================================

                    'Couleur de fond pour le total
                    Me.texColorTotal.BackColor = ColorForTotal
                    dgvProjects.Columns(3).DefaultCellStyle.BackColor = ColorForTotal
                    dgvProjects.Columns(4).DefaultCellStyle.BackColor = ColorForTotal
                    dgvProjects.Columns(5).DefaultCellStyle.BackColor = ColorForTotal
                    dgvProjects.Columns(6).DefaultCellStyle.BackColor = ColorForTotal


                    'Couleur de fond pour l'infra
                    Me.texColorInfra.BackColor = ColorForInfra
                    dgvProjects.Columns(7).DefaultCellStyle.BackColor = ColorForInfra
                    dgvProjects.Columns(8).DefaultCellStyle.BackColor = ColorForInfra
                    dgvProjects.Columns(9).DefaultCellStyle.BackColor = ColorForInfra
                    dgvProjects.Columns(10).DefaultCellStyle.BackColor = ColorForInfra


                    'Couleur de fond pour SAP
                    Me.texColorSAP.BackColor = ColorForSAP
                    dgvProjects.Columns(11).DefaultCellStyle.BackColor = ColorForSAP
                    dgvProjects.Columns(12).DefaultCellStyle.BackColor = ColorForSAP
                    dgvProjects.Columns(13).DefaultCellStyle.BackColor = ColorForSAP
                    dgvProjects.Columns(14).DefaultCellStyle.BackColor = ColorForSAP


                    'Couleur de fond pour Helpdesk
                    Me.texColorHelpdesk.BackColor = ColorForHelpdesk
                    dgvProjects.Columns(15).DefaultCellStyle.BackColor = ColorForHelpdesk
                    dgvProjects.Columns(16).DefaultCellStyle.BackColor = ColorForHelpdesk
                    dgvProjects.Columns(17).DefaultCellStyle.BackColor = ColorForHelpdesk
                    dgvProjects.Columns(18).DefaultCellStyle.BackColor = ColorForHelpdesk

                    'Couleur de fond pour la planification
                    Me.texColorPlaning.BackColor = ColorForPlaning
                    dgvProjects.Columns(19).DefaultCellStyle.BackColor = ColorForPlaning
                    dgvProjects.Columns(20).DefaultCellStyle.BackColor = ColorForPlaning
                    dgvProjects.Columns(21).DefaultCellStyle.BackColor = ColorForPlaning
                    dgvProjects.Columns(22).DefaultCellStyle.BackColor = ColorForPlaning

                    '=================================================
                    'Fin Définition des couleurs de fond
                    '=================================================

                    '=================================================
                    'Début Ressources pour l'infra
                    '=================================================
                    thisPlan.CE_ID_Project = thisProject.ID_Project
                    dgvProjects.Item(7, ActiveRow).Value = thisProject.EstimatedResourcesInfra
                    TotalInfraEstimated = TotalInfraEstimated + thisProject.EstimatedResourcesInfra

                    thisExec.CE_ID_Project = thisProject.ID_Project
                    thisExec.CE_ID_Task = 1   '1 = Infrastructure
                    thisExec.GetExecutedProjectResourcesPerTaskAndProject()
                    dgvProjects.Item(8, ActiveRow).Value = thisExec.ExecutedProjectResourcesPerTaskAndProject
                    TotalInfraExecuted = TotalInfraExecuted + thisExec.ExecutedProjectResourcesPerTaskAndProject

                    thisPlan.CE_ID_Project = thisProject.ID_Project
                    thisPlan.CE_ID_Task = 1   '1 = Infrastructure
                    thisPlan.GetPlanProjectResourcesPerTaskAndProject()
                    dgvProjects.Item(9, ActiveRow).Value = thisPlan.PlanProjectResourcesPerTaskAndProject
                    TotalInfraPlan = TotalInfraPlan + thisPlan.PlanProjectResourcesPerTaskAndProject

                    Dim PlanForInfra As Single = thisProject.EstimatedResourcesInfra - thisExec.ExecutedProjectResourcesPerTaskAndProject - thisPlan.PlanProjectResourcesPerTaskAndProject
                    If PlanForInfra < 0 Then
                        PlanForInfra = 0
                        dgvProjects.Item(10, ActiveRow).Value = PlanForInfra & " (<--)"
                        dgvProjects.Item(10, ActiveRow).Style.ForeColor = Color.Red
                    Else
                        dgvProjects.Item(10, ActiveRow).Value = PlanForInfra
                    End If
                    TotalInfraToPlan = TotalInfraToPlan + PlanForInfra
                    '=================================================
                    'Fin Ressources pour l'infra
                    '=================================================



                    '=================================================
                    'Début Ressources pour SAP
                    '=================================================
                    thisPlan.CE_ID_Project = thisProject.ID_Project
                    dgvProjects.Item(11, ActiveRow).Value = thisProject.EstimatedResourcesSAP
                    TotalSAPEstimated = TotalSAPEstimated + thisProject.EstimatedResourcesSAP

                    thisExec.CE_ID_Project = thisProject.ID_Project
                    thisExec.CE_ID_Task = 2   '2 = SAP
                    thisExec.GetExecutedProjectResourcesPerTaskAndProject()
                    dgvProjects.Item(12, ActiveRow).Value = thisExec.ExecutedProjectResourcesPerTaskAndProject
                    TotalSAPExecuted = TotalSAPExecuted + thisExec.ExecutedProjectResourcesPerTaskAndProject

                    thisPlan.CE_ID_Project = thisProject.ID_Project
                    thisPlan.CE_ID_Task = 2   '2 = SAP
                    thisPlan.GetPlanProjectResourcesPerTaskAndProject()
                    dgvProjects.Item(13, ActiveRow).Value = thisPlan.PlanProjectResourcesPerTaskAndProject
                    TotalSAPPlan = TotalSAPPlan + thisPlan.PlanProjectResourcesPerTaskAndProject


                    Dim PlanForSAP As Single = thisProject.EstimatedResourcesSAP - thisExec.ExecutedProjectResourcesPerTaskAndProject - thisPlan.PlanProjectResourcesPerTaskAndProject
                    If PlanForSAP < 0 Then
                        PlanForSAP = 0
                        dgvProjects.Item(14, ActiveRow).Value = PlanForSAP & " (<--)"
                        dgvProjects.Item(14, ActiveRow).Style.ForeColor = Color.Red
                    Else
                        dgvProjects.Item(14, ActiveRow).Value = PlanForSAP
                    End If
                    TotalSAPToPlan = TotalSAPToPlan + PlanForSAP
                    '=================================================
                    'Fin Ressources pour SAP
                    '=================================================



                    '=================================================
                    'Début Ressources pour Helpdesk
                    '=================================================
                    thisPlan.CE_ID_Project = thisProject.ID_Project
                    dgvProjects.Item(15, ActiveRow).Value = thisProject.EstimatedResourcesHelpdesk
                    TotalHelpdeskEstimated = TotalHelpdeskEstimated + thisProject.EstimatedResourcesHelpdesk

                    thisExec.CE_ID_Project = thisProject.ID_Project
                    thisExec.CE_ID_Task = 3   '3 = Helpdesk
                    thisExec.GetExecutedProjectResourcesPerTaskAndProject()
                    dgvProjects.Item(16, ActiveRow).Value = thisExec.ExecutedProjectResourcesPerTaskAndProject
                    TotalHelpdeskExecuted = TotalHelpdeskExecuted + thisExec.ExecutedProjectResourcesPerTaskAndProject

                    thisPlan.CE_ID_Project = thisProject.ID_Project
                    thisPlan.CE_ID_Task = 3   '3 = Helpdesk
                    thisPlan.GetPlanProjectResourcesPerTaskAndProject()
                    dgvProjects.Item(17, ActiveRow).Value = thisPlan.PlanProjectResourcesPerTaskAndProject
                    TotalHelpdeskPlan = TotalHelpdeskPlan + thisPlan.PlanProjectResourcesPerTaskAndProject

                    Dim PlanForHelpdesk As Single = thisProject.EstimatedResourcesHelpdesk - thisExec.ExecutedProjectResourcesPerTaskAndProject - thisPlan.PlanProjectResourcesPerTaskAndProject
                    If PlanForHelpdesk < 0 Then
                        PlanForHelpdesk = 0
                        dgvProjects.Item(18, ActiveRow).Value = PlanForHelpdesk & " (<--)"
                        dgvProjects.Item(18, ActiveRow).Style.ForeColor = Color.Red
                    Else
                        dgvProjects.Item(18, ActiveRow).Value = PlanForHelpdesk
                    End If
                    TotalHelpdeskToPlan = TotalHelpdeskToPlan + PlanForHelpdesk

                    '=================================================
                    'Fin Ressources pour Helpdesk
                    '=================================================




                    '=================================================
                    'Début Ressources pour la planification
                    '=================================================
                    thisPlan.CE_ID_Project = thisProject.ID_Project
                    dgvProjects.Item(19, ActiveRow).Value = thisProject.EstimatedResourcesPlaning
                    TotalPlaningEstimated = TotalPlaningEstimated + thisProject.EstimatedResourcesPlaning

                    thisExec.CE_ID_Project = thisProject.ID_Project
                    thisExec.CE_ID_Task = 4   '4 = Planing
                    thisExec.GetExecutedProjectResourcesPerTaskAndProject()
                    dgvProjects.Item(20, ActiveRow).Value = thisExec.ExecutedProjectResourcesPerTaskAndProject
                    TotalPlaningExecuted = TotalPlaningExecuted + thisExec.ExecutedProjectResourcesPerTaskAndProject

                    thisPlan.CE_ID_Project = thisProject.ID_Project
                    thisPlan.CE_ID_Task = 4   '4 = Planing
                    thisPlan.GetPlanProjectResourcesPerTaskAndProject()
                    dgvProjects.Item(21, ActiveRow).Value = thisPlan.PlanProjectResourcesPerTaskAndProject
                    TotalPlaningPlan = TotalPlaningPlan + thisPlan.PlanProjectResourcesPerTaskAndProject

                    Dim PlanForPlaning As Single = thisProject.EstimatedResourcesPlaning - thisExec.ExecutedProjectResourcesPerTaskAndProject - thisPlan.PlanProjectResourcesPerTaskAndProject
                    If PlanForPlaning < 0 Then
                        PlanForPlaning = 0
                        dgvProjects.Item(22, ActiveRow).Value = PlanForPlaning & " (<--)"
                        dgvProjects.Item(22, ActiveRow).Style.ForeColor = Color.Red
                    Else
                        dgvProjects.Item(22, ActiveRow).Value = PlanForPlaning
                    End If
                    TotalPlaningToPlan = TotalPlaningToPlan + PlanForPlaning

                    '=================================================
                    'Fin Ressources pour la planification
                    '=================================================



                    'On ajuste automatiquement la taille des coloness titre et catégorie
                    Dim myCol0 As DataGridViewColumn = dgvProjects.Columns(0)
                    myCol0.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    dgvProjects.AutoResizeColumn(1)
                    dgvProjects.AutoResizeColumn(2)
                    dgvProjects.AutoResizeColumn(3)
                    dgvProjects.AutoResizeColumn(4)
                    dgvProjects.AutoResizeColumn(5)




                    Dim myCol6 As DataGridViewColumn = dgvProjects.Columns(6)
                    Dim myCol7 As DataGridViewColumn = dgvProjects.Columns(7)
                    Dim myCol8 As DataGridViewColumn = dgvProjects.Columns(8)
                    Dim myCol9 As DataGridViewColumn = dgvProjects.Columns(9)
                    Dim myCol10 As DataGridViewColumn = dgvProjects.Columns(10)
                    Dim myCol11 As DataGridViewColumn = dgvProjects.Columns(11)
                    Dim myCol12 As DataGridViewColumn = dgvProjects.Columns(12)
                    Dim myCol13 As DataGridViewColumn = dgvProjects.Columns(13)
                    Dim myCol14 As DataGridViewColumn = dgvProjects.Columns(14)
                    Dim myCol15 As DataGridViewColumn = dgvProjects.Columns(15)
                    Dim myCol16 As DataGridViewColumn = dgvProjects.Columns(16)
                    Dim myCol17 As DataGridViewColumn = dgvProjects.Columns(17)
                    Dim myCol18 As DataGridViewColumn = dgvProjects.Columns(18)
                    Dim myCol19 As DataGridViewColumn = dgvProjects.Columns(19)
                    Dim myCol20 As DataGridViewColumn = dgvProjects.Columns(20)
                    Dim myCol21 As DataGridViewColumn = dgvProjects.Columns(21)
                    Dim myCol22 As DataGridViewColumn = dgvProjects.Columns(22)

                    myCol6.Width = myColWidth
                    myCol7.Width = myColWidth
                    myCol8.Width = myColWidth
                    myCol9.Width = myColWidth
                    myCol10.Width = myColWidth
                    myCol11.Width = myColWidth
                    myCol12.Width = myColWidth
                    myCol13.Width = myColWidth
                    myCol14.Width = myColWidth
                    myCol15.Width = myColWidth
                    myCol16.Width = myColWidth
                    myCol17.Width = myColWidth
                    myCol18.Width = myColWidth
                    myCol19.Width = myColWidth
                    myCol20.Width = myColWidth
                    myCol21.Width = myColWidth
                    myCol22.Width = myColWidth

                    'Alignement des cellules
                    dgvProjects.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgvProjects.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgvProjects.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgvProjects.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgvProjects.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                    dgvProjects.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgvProjects.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgvProjects.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgvProjects.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                    dgvProjects.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgvProjects.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgvProjects.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgvProjects.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                    dgvProjects.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgvProjects.Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgvProjects.Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgvProjects.Columns(18).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                    dgvProjects.Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgvProjects.Columns(20).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgvProjects.Columns(21).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgvProjects.Columns(22).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter





                    ActiveRow = ActiveRow + 1
                Catch ex As Exception
                End Try

            End While

            mySQLDataReader.Close()
            MySQLConnection.Close()



            'Récupération des totaux
            myTotalInfra = TotalInfraToPlan
            myTotalSAP = TotalSAPToPlan
            myTotalHelpdesk = TotalHelpdeskToPlan
            myTotalPlaning = TotalPlaningToPlan


            'Affichage des totaux
            dgvProjects.Rows.Add()
            dgvProjects.Item(1, ActiveRow).Value = "TOTAUX"
            dgvProjects.Item(3, ActiveRow).Value = TotalEstimated
            dgvProjects.Item(4, ActiveRow).Value = TotalExecuted
            dgvProjects.Item(5, ActiveRow).Value = TotalPlan
            dgvProjects.Item(6, ActiveRow).Value = TotalToPlan

            dgvProjects.Item(7, ActiveRow).Value = TotalInfraEstimated
            dgvProjects.Item(8, ActiveRow).Value = TotalInfraExecuted
            dgvProjects.Item(9, ActiveRow).Value = TotalInfraPlan
            dgvProjects.Item(10, ActiveRow).Value = TotalInfraToPlan

            dgvProjects.Item(11, ActiveRow).Value = TotalSAPEstimated
            dgvProjects.Item(12, ActiveRow).Value = TotalSAPExecuted
            dgvProjects.Item(13, ActiveRow).Value = TotalSAPPlan
            dgvProjects.Item(14, ActiveRow).Value = TotalSAPToPlan

            dgvProjects.Item(15, ActiveRow).Value = TotalHelpdeskEstimated
            dgvProjects.Item(16, ActiveRow).Value = TotalHelpdeskExecuted
            dgvProjects.Item(17, ActiveRow).Value = TotalHelpdeskPlan
            dgvProjects.Item(18, ActiveRow).Value = TotalHelpdeskToPlan

            dgvProjects.Item(19, ActiveRow).Value = TotalPlaningEstimated
            dgvProjects.Item(20, ActiveRow).Value = TotalPlaningExecuted
            dgvProjects.Item(21, ActiveRow).Value = TotalPlaningPlan
            dgvProjects.Item(22, ActiveRow).Value = TotalPlaningToPlan

            dgvProjects.Item(1, ActiveRow).Style.Font = New Font("Arial", 10, FontStyle.Bold)

            dgvProjects.Item(3, ActiveRow).Style.Font = New Font("Arial", 10, FontStyle.Bold)
            dgvProjects.Item(4, ActiveRow).Style.Font = New Font("Arial", 10, FontStyle.Bold)
            dgvProjects.Item(5, ActiveRow).Style.Font = New Font("Arial", 10, FontStyle.Bold)
            dgvProjects.Item(6, ActiveRow).Style.Font = New Font("Arial", 10, FontStyle.Bold)

            dgvProjects.Item(7, ActiveRow).Style.Font = New Font("Arial", 10, FontStyle.Bold)
            dgvProjects.Item(8, ActiveRow).Style.Font = New Font("Arial", 10, FontStyle.Bold)
            dgvProjects.Item(9, ActiveRow).Style.Font = New Font("Arial", 10, FontStyle.Bold)
            dgvProjects.Item(10, ActiveRow).Style.Font = New Font("Arial", 10, FontStyle.Bold)

            dgvProjects.Item(11, ActiveRow).Style.Font = New Font("Arial", 10, FontStyle.Bold)
            dgvProjects.Item(12, ActiveRow).Style.Font = New Font("Arial", 10, FontStyle.Bold)
            dgvProjects.Item(13, ActiveRow).Style.Font = New Font("Arial", 10, FontStyle.Bold)
            dgvProjects.Item(14, ActiveRow).Style.Font = New Font("Arial", 10, FontStyle.Bold)

            dgvProjects.Item(15, ActiveRow).Style.Font = New Font("Arial", 10, FontStyle.Bold)
            dgvProjects.Item(16, ActiveRow).Style.Font = New Font("Arial", 10, FontStyle.Bold)
            dgvProjects.Item(17, ActiveRow).Style.Font = New Font("Arial", 10, FontStyle.Bold)
            dgvProjects.Item(18, ActiveRow).Style.Font = New Font("Arial", 10, FontStyle.Bold)

            dgvProjects.Item(19, ActiveRow).Style.Font = New Font("Arial", 10, FontStyle.Bold)
            dgvProjects.Item(20, ActiveRow).Style.Font = New Font("Arial", 10, FontStyle.Bold)
            dgvProjects.Item(21, ActiveRow).Style.Font = New Font("Arial", 10, FontStyle.Bold)
            dgvProjects.Item(22, ActiveRow).Style.Font = New Font("Arial", 10, FontStyle.Bold)




            'dgvProjects.Rows(0).Selected = True
            'ID_Project = dgvProjects.Item(0, dgvProjects.CurrentCell.RowIndex).Value

            'On rend certains éléments visible après le chargement des données
            dgvProjects.Visible = True


            Me.Cursor = Cursors.Default

        Catch ex As Exception

            If DebugFlag = True Then MessageBox.Show(ex.ToString)

        End Try
    End Sub

    Private Sub pDisplayResouces(thisDGV As DataGridView, ID_Task As Integer)

        Try

            'Déclaration des variables

            Dim mySQLDataReader As SqlDataReader
            Dim MySQLConnection As New SqlConnection
            Dim Sql As String = ""


            Dim myMember As New myProjectMember
            Dim myStat As New myStatistics

            'Projets planifiés
            Dim PP1mois As String = ""
            Dim PP3mois As String = ""
            Dim PP6mois As String = ""
            Dim PP12mois As String = ""
            Dim PPYear As String = ""

            'Administratif planifiés
            Dim AP1mois As String = ""
            Dim AP3mois As String = ""
            Dim AP6mois As String = ""
            Dim AP12mois As String = ""
            Dim APYear As String = ""

            'libres
            Dim F1mois As String = ""
            Dim F3mois As String = ""
            Dim F6mois As String = ""
            Dim F12mois As String = ""
            Dim FYear As String = ""

            'Totaux
            Dim PPTotal1mois As Single = 0
            Dim PPTotal3mois As Single = 0
            Dim PPTotal6mois As Single = 0
            Dim PPTotal12mois As Single = 0
            Dim PPTotalYear As Single = 0

            Dim APTotal1mois As Single = 0
            Dim APTotal3mois As Single = 0
            Dim APTotal6mois As Single = 0
            Dim APTotal12mois As Single = 0
            Dim APTotalYear As Single = 0

            Dim FTotal1mois As Single = 0
            Dim FTotal3mois As Single = 0
            Dim FTotal6mois As Single = 0
            Dim FTotal12mois As Single = 0
            Dim FTotalYear As Single = 0

            'On vide le DataGridView
            thisDGV.Rows.Clear()
            thisDGV.Columns.Clear()

            'On rend certains éléments invisible durant le chargement des données
            'thisDGV.Visible = False

            'Définition du DataGridView
            thisDGV.ReadOnly = True
            thisDGV.AllowUserToAddRows = False
            thisDGV.AllowUserToDeleteRows = False
            thisDGV.MultiSelect = False



            'Définition des colonnes
            thisDGV.Columns.Add("", "")
            thisDGV.Columns.Add("1 mois", "1 mois")
            thisDGV.Columns.Add("3 mois", "3 mois")
            thisDGV.Columns.Add("6 mois", "6 mois")
            thisDGV.Columns.Add("12 mois", "12 mois")
            thisDGV.Columns.Add("fin année", "fin année")

            'On ajoute les lignes
            thisDGV.Rows.Add()
            thisDGV.Rows.Add()
            thisDGV.Rows.Add()
            thisDGV.Item(0, 0).Value = "Planifié projet"
            thisDGV.Item(0, 1).Value = "Planifié administratif"
            thisDGV.Item(0, 2).Value = "Libre"



            'Commande sQL
            Sql = "SELECT ID_ProjectMember FROM ProjectsMembers WHERE Enable = 1 AND CE_ID_Task=" & ID_Task
            MySQLConnection.ConnectionString = cnProjectPlan
            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)

            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read

                Try
                    'Lecture du projet
                    myMember.ID_ProjectMember = mySQLDataReader.GetValue(0)
                    myMember.Read()
                Catch ex As Exception
                End Try

                myStat.ID_ProjectMember = myMember.ID_ProjectMember
                myStat.GetProjectDays()
                myStat.GetAdminDays()
                myStat.GetFreeDays()

                'Nom de la personne
                Dim thisName As String = UCase(Microsoft.VisualBasic.Left(myMember.Lastname, 2) & Microsoft.VisualBasic.Left(myMember.FirstName, 1))

                thisName = Replace(thisName, "Ü", "U")
                thisName = Replace(thisName, "Ù", "U")
                thisName = Replace(thisName, "Ú", "U")
                thisName = Replace(thisName, "Û", "U")
                thisName = Replace(thisName, "Ä", "A")
                thisName = Replace(thisName, "À", "A")
                thisName = Replace(thisName, "Á", "A")
                thisName = Replace(thisName, "Â", "A")
                thisName = Replace(thisName, "Ê", "E")
                thisName = Replace(thisName, "È", "E")
                thisName = Replace(thisName, "É", "E")
                thisName = Replace(thisName, "Ë", "E")
                thisName = Replace(thisName, "Î", "I")
                thisName = Replace(thisName, "Ì", "I")
                thisName = Replace(thisName, "Í", "I")
                thisName = Replace(thisName, "Î", "I")


                'Projets planifiés

                PPTotal1mois = PPTotal1mois + myStat.DaysOnProjects1Month
                PPTotal3mois = PPTotal3mois + myStat.DaysOnProjects3Month
                PPTotal6mois = PPTotal6mois + myStat.DaysOnProjects6Month
                PPTotal12mois = PPTotal12mois + myStat.DaysOnProjects12Month
                PPTotalYear = PPTotalYear + myStat.DaysOnProjectsEndYear

                If PP1mois = "" Then
                    PP1mois = thisName & " : " & Format(myStat.DaysOnProjects1Month, "0.0")
                Else
                    PP1mois &= vbCrLf & thisName & " : " & Format(myStat.DaysOnProjects1Month, "0.0")
                End If

                If PP3mois = "" Then
                    PP3mois = thisName & " : " & Format(myStat.DaysOnProjects3Month, "0.0")
                Else
                    PP3mois &= vbCrLf & thisName & " : " & Format(myStat.DaysOnProjects3Month, "0.0")
                End If

                If PP6mois = "" Then
                    PP6mois = thisName & " : " & Format(myStat.DaysOnProjects6Month, "0.0")
                Else
                    PP6mois &= vbCrLf & thisName & " : " & Format(myStat.DaysOnProjects6Month, "0.0")
                End If

                If PP12mois = "" Then
                    PP12mois = thisName & " : " & Format(myStat.DaysOnProjects12Month, "0.0")
                Else
                    PP12mois &= vbCrLf & thisName & " : " & Format(myStat.DaysOnProjects12Month, "0.0")
                End If

                If PPYear = "" Then
                    PPYear = thisName & " : " & Format(myStat.DaysOnProjectsEndYear, "0.0")
                Else
                    PPYear &= vbCrLf & thisName & " : " & Format(myStat.DaysOnProjectsEndYear, "0.0")
                End If





                'Administrtatif planifié

                APTotal1mois = APTotal1mois + myStat.DaysOnAdmin1Month
                APTotal3mois = APTotal3mois + myStat.DaysOnAdmin3Month
                APTotal6mois = APTotal6mois + myStat.DaysOnAdmin6Month
                APTotal12mois = APTotal12mois + myStat.DaysOnAdmin12Month
                APTotalYear = APTotalYear + myStat.DaysOnAdminEndYear

                If AP1mois = "" Then
                    AP1mois = thisName & " : " & Format(myStat.DaysOnAdmin1Month, "0.0")
                Else
                    AP1mois &= vbCrLf & thisName & " : " & Format(myStat.DaysOnAdmin1Month, "0.0")
                End If

                If AP3mois = "" Then
                    AP3mois = thisName & " : " & Format(myStat.DaysOnAdmin3Month, "0.0")
                Else
                    AP3mois &= vbCrLf & thisName & " : " & Format(myStat.DaysOnAdmin3Month)
                End If

                If AP6mois = "" Then
                    AP6mois = thisName & " : " & Format(myStat.DaysOnAdmin6Month, "0.0")
                Else
                    AP6mois &= vbCrLf & thisName & " : " & Format(myStat.DaysOnAdmin6Month, "0.0")
                End If

                If AP12mois = "" Then
                    AP12mois = thisName & " : " & Format(myStat.DaysOnAdmin12Month, "0.0")
                Else
                    AP12mois &= vbCrLf & thisName & " : " & Format(myStat.DaysOnAdmin12Month, "0.0")
                End If

                If APYear = "" Then
                    APYear = thisName & " : " & Format(myStat.DaysOnAdminEndYear, "0.0")
                Else
                    APYear &= vbCrLf & thisName & " : " & Format(myStat.DaysOnAdminEndYear, "0.0")
                End If





                'Ressources libres

                FTotal1mois = FTotal1mois + myStat.DaysFree1Month
                FTotal3mois = FTotal3mois + myStat.DaysFree3Month
                FTotal6mois = FTotal6mois + myStat.DaysFree6Month
                FTotal12mois = FTotal12mois + myStat.DaysFree12Month
                FTotalYear = FTotalYear + myStat.DaysFreeEndYear

                If F1mois = "" Then
                    F1mois = thisName & " : " & Format(myStat.DaysFree1Month, "0.0")
                Else
                    F1mois &= vbCrLf & thisName & " : " & Format(myStat.DaysFree1Month, "0.0")
                End If

                If F3mois = "" Then
                    F3mois = thisName & " : " & Format(myStat.DaysFree3Month, "0.0")
                Else
                    F3mois &= vbCrLf & thisName & " : " & Format(myStat.DaysFree3Month, "0.0")
                End If

                If F6mois = "" Then
                    F6mois = thisName & " : " & Format(myStat.DaysFree6Month, "0.0")
                Else
                    F6mois &= vbCrLf & thisName & " : " & Format(myStat.DaysFree6Month, "0.0")
                End If

                If F12mois = "" Then
                    F12mois = thisName & " : " & Format(myStat.DaysFree12Month, "0.0")
                Else
                    F12mois &= vbCrLf & thisName & " : " & Format(myStat.DaysFree12Month, "0.0")
                End If

                If FYear = "" Then
                    FYear = thisName & " : " & Format(myStat.DaysFreeEndYear, "0.0")
                Else
                    FYear &= vbCrLf & thisName & " : " & Format(myStat.DaysFreeEndYear, "0.0")
                End If



            End While


            'On ajoute les totaux
            PP1mois &= vbCrLf & "Total : " & CStr(PPTotal1mois)
            PP3mois &= vbCrLf & "Total : " & CStr(PPTotal3mois)
            PP6mois &= vbCrLf & "Total : " & CStr(PPTotal6mois)
            PP12mois &= vbCrLf & "Total : " & CStr(PPTotal12mois)
            PPYear &= vbCrLf & "Total : " & CStr(PPTotalYear)

            AP1mois &= vbCrLf & "Total : " & CStr(APTotal1mois)
            AP3mois &= vbCrLf & "Total : " & CStr(APTotal3mois)
            AP6mois &= vbCrLf & "Total : " & CStr(APTotal6mois)
            AP12mois &= vbCrLf & "Total : " & CStr(APTotal12mois)
            APYear &= vbCrLf & "Total : " & CStr(APTotalYear)

            F1mois &= vbCrLf & "Total : " & CStr(FTotal1mois)
            F3mois &= vbCrLf & "Total : " & CStr(FTotal3mois)
            F6mois &= vbCrLf & "Total : " & CStr(FTotal6mois)
            F12mois &= vbCrLf & "Total : " & CStr(FTotal12mois)
            FYear &= vbCrLf & "Total : " & CStr(FTotalYear)


            'On remplit la grille
            'thisDGV.Item(colonne, ligne).value

            thisDGV.Item(1, 0).Value = PP1mois
            thisDGV.Item(2, 0).Value = PP3mois
            thisDGV.Item(3, 0).Value = PP6mois
            thisDGV.Item(4, 0).Value = PP12mois
            thisDGV.Item(5, 0).Value = PPYear

            thisDGV.Item(1, 1).Value = AP1mois
            thisDGV.Item(2, 1).Value = AP3mois
            thisDGV.Item(3, 1).Value = AP6mois
            thisDGV.Item(4, 1).Value = AP12mois
            thisDGV.Item(5, 1).Value = APYear

            thisDGV.Item(1, 2).Value = F1mois
            thisDGV.Item(2, 2).Value = F3mois
            thisDGV.Item(3, 2).Value = F6mois
            thisDGV.Item(4, 2).Value = F12mois
            thisDGV.Item(5, 2).Value = FYear



            'On met la grille en mode multiligne
            thisDGV.Rows(0).DefaultCellStyle.WrapMode = DataGridViewTriState.True
            thisDGV.Rows(1).DefaultCellStyle.WrapMode = DataGridViewTriState.True
            thisDGV.Rows(2).DefaultCellStyle.WrapMode = DataGridViewTriState.True

            'On resize la lignes
            thisDGV.AutoResizeRow(0, autoSizeRowMode:=DataGridViewAutoSizeRowMode.AllCells)
            thisDGV.AutoResizeRow(1, autoSizeRowMode:=DataGridViewAutoSizeRowMode.AllCells)
            thisDGV.AutoResizeRow(2, autoSizeRowMode:=DataGridViewAutoSizeRowMode.AllCells)

            'On resize les colonnes
            For i = 0 To 5
                thisDGV.AutoResizeColumn(i)
            Next i


            'On aligne le texte
            For i = 1 To 5
                thisDGV.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Next i


            'On empêche de trier les colonnes de manière alphabétiques
            For i = 0 To 5
                thisDGV.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next i


            Select Case ID_Task
                Case 1
                    dgvInfrastructure.DefaultCellStyle.BackColor = ColorForInfra

                Case 2
                    dgvSAP.DefaultCellStyle.BackColor = ColorForSAP

                Case 3
                    dgvHelpdesk.DefaultCellStyle.BackColor = ColorForHelpdesk

                Case 4
                    dgvPlaning.DefaultCellStyle.BackColor = ColorForPlaning

            End Select



            mySQLDataReader.Close()
            MySQLConnection.Close()


            Me.Cursor = Cursors.Default

        Catch ex As Exception

            If DebugFlag = True Then MessageBox.Show(ex.ToString)

        End Try
    End Sub

    Private Sub grpHelpdesk_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub btcFermer_Click(sender As Object, e As EventArgs) Handles btcFermer.Click
        Try
            Me.Close()
        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try
    End Sub


    Private Sub pDisplayFreeDates()

        Try

            'Affichage des couleurs de fond
            Me.texFreeDateInfra.BackColor = ColorForInfra
            Me.texFreeDateSAP.BackColor = ColorForSAP
            Me.texFreeDateHelpdesk.BackColor = ColorForHelpdesk
            Me.texFreeDatePlaning.BackColor = ColorForPlaning

            'On compte le nombre de membres actifs pour chaque tâche
            Dim myCountMembersInfra = fGetProjectMembersForTask(1)
            Dim myCountMembersSAP = fGetProjectMembersForTask(2)
            Dim myCountMembersHelpdesk = fGetProjectMembersForTask(3)
            Dim myCountMembersPlaning = fGetProjectMembersForTask(4)


            Dim thisDate As Date = Today
            Dim FreeNow As Boolean = False

            Dim StillToPlanInfra As Single = myTotalInfra
            Dim StillToPlanSAP As Single = myTotalSAP
            Dim StillToPlanHelpdesk As Single = myTotalHelpdesk
            Dim StillToPlanPlaning As Single = myTotalPlaning

            Dim FreeDateInfra As Date = Nothing
            Dim FreeDateSAP As Date = Nothing
            Dim FreeDateHelpdesk As Date = Nothing
            Dim FreeDatePlaning As Date = Nothing

            '================================================================
            'On calcule la première date de libre pour le team infrastructure
            '================================================================
            FreeNow = False
            thisDate = Today

            While FreeNow = False

                'On décompte uniquement les jours de libre durant les jours de semaine
                Select Case thisDate.DayOfWeek
                    Case DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday

                        'On soustrait le nombre de membres de l'infa diminué du nombre de personnes déjà planifiées
                        StillToPlanInfra = StillToPlanInfra - (myCountMembersInfra - fGetPlanResourcesForTask(1, thisDate))
                        If StillToPlanInfra < 0 Then
                            FreeNow = True
                            FreeDateInfra = thisDate
                        End If
                End Select
                thisDate = DateAdd(DateInterval.Day, 1, thisDate)
            End While
            '================================================================
            'On calcule la première date de libre pour le team infrastructure
            '================================================================


            '================================================================
            'On calcule la première date de libre pour le team SAP
            '================================================================
            FreeNow = False
            thisDate = Today

            While FreeNow = False

                'On décompte uniquement les jours de libre durant les jours de semaine
                Select Case thisDate.DayOfWeek
                    Case DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday

                        'On soustrait le nombre de membres de SAP diminué du nombre de personnes déjà planifiées
                        StillToPlanSAP = StillToPlanSAP - (myCountMembersSAP - fGetPlanResourcesForTask(2, thisDate))
                        If StillToPlanSAP < 0 Then
                            FreeNow = True
                            FreeDateSAP = thisDate
                        End If
                End Select
                thisDate = DateAdd(DateInterval.Day, 1, thisDate)
            End While
            '================================================================
            'On calcule la première date de libre pour le team SAP
            '================================================================


            '================================================================
            'On calcule la première date de libre pour le team Helpdesk
            '================================================================
            FreeNow = False
            thisDate = Today

            While FreeNow = False

                'On décompte uniquement les jours de libre durant les jours de semaine
                Select Case thisDate.DayOfWeek
                    Case DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday

                        'On soustrait le nombre de membres du helpdesk diminué du nombre de personnes déjà planifiées
                        StillToPlanHelpdesk = StillToPlanHelpdesk - (myCountMembersHelpdesk - fGetPlanResourcesForTask(3, thisDate))
                        If StillToPlanHelpdesk < 0 Then
                            FreeNow = True
                            FreeDateHelpdesk = thisDate
                        End If
                End Select
                thisDate = DateAdd(DateInterval.Day, 1, thisDate)
            End While
            '================================================================
            'On calcule la première date de libre pour le team Helpdesk
            '================================================================


            '================================================================
            'On calcule la première date de libre pour le team Planification
            '================================================================
            FreeNow = False
            thisDate = Today

            While FreeNow = False

                'On décompte uniquement les jours de libre durant les jours de semaine
                Select Case thisDate.DayOfWeek
                    Case DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday

                        'On soustrait le nombre de membres de la planification diminué du nombre de personnes déjà planifiées
                        StillToPlanPlaning = StillToPlanPlaning - (myCountMembersPlaning - fGetPlanResourcesForTask(4, thisDate))
                        If StillToPlanPlaning < 0 Then
                            FreeNow = True
                            FreeDatePlaning = thisDate
                        End If
                End Select
                thisDate = DateAdd(DateInterval.Day, 1, thisDate)
            End While
            '================================================================
            'On calcule la première date de libre pour le team Planification
            '================================================================

            'Affichage des soldes
            Me.texFreeDateInfra.Text = Format(FreeDateInfra, "D")
            Me.texFreeDateSAP.Text = Format(FreeDateSAP, "D")
            Me.texFreeDateHelpdesk.Text = Format(FreeDateHelpdesk, "D")
            Me.texFreeDatePlaning.Text = Format(FreeDatePlaning, "D")











        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Function fGetProjectMembersForTask(ID_Task As Integer) As Integer

        Dim myCount As Integer = 0

        Try

            Dim MySQLConnection As New SqlConnection
            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT COUNT(ID_ProjectMember) FROM ProjectsMembers WHERE Enable = 1 AND CE_ID_Task = " & ID_Task

            MySQLConnection.ConnectionString = cnProjectPlan
            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)
            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read

                'Lecture du premier paramètre COUNT
                Try
                    myCount = mySQLDataReader.GetValue(0)
                Catch ex As Exception
                End Try

            End While

            mySQLDataReader.Close()
            MySQLConnection.Close()

        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try

        Return myCount

    End Function

    Private Function fGetPlanResourcesForTask(ID_Task As Integer, myDay As Date) As Single

        Dim myCount As Integer = 0

        Try

            Dim MySQLConnection As New SqlConnection
            Dim mySQLDataReader As SqlDataReader
            Dim Sql As String = "SELECT COUNT(ID_Resource) FROM PlanResources WHERE PlanDate = '" & fConvertDateOnlySQL(myDay) & "' AND CE_ID_ProjectMember IN (SELECT ID_ProjectMember FROM ProjectsMembers WHERE CE_ID_Task = " & ID_Task & ");"

            MySQLConnection.ConnectionString = cnProjectPlan
            MySQLConnection.Open()

            Dim mySQLCommand As SqlCommand = New SqlCommand(Sql, MySQLConnection)
            mySQLDataReader = mySQLCommand.ExecuteReader()

            While mySQLDataReader.Read

                'Lecture du premier paramètre COUNT
                Try
                    'Lecture du nombre d'enregistrement (en demi-jour)
                    myCount = mySQLDataReader.GetValue(0)

                    'Lecture du nombre d'enregistrements (en jour)
                    myCount = myCount / 2
                Catch ex As Exception
                End Try

            End While

            mySQLDataReader.Close()
            MySQLConnection.Close()

        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try

        Return myCount

    End Function

    Private Sub btcChart_Click(sender As Object, e As EventArgs) Handles btcChart.Click
        Try
            Dim myForm As Form = frmChart

            'Affiche la fenêtre en mode non-modal
            myForm.Show()

            'Affiche la fenêtre en mode modal
            'myForm.ShowDialog()
            'myForm.Dispose()
        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try
    End Sub


    Private Sub dgvProjets_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvProjects.CellDoubleClick

        Try

            dgvProjects.Rows(dgvProjects.CurrentCell.RowIndex).Selected = True
            ID_Project = dgvProjects.Item(0, dgvProjects.CurrentCell.RowIndex).Value

            Dim myForm As Form = frmProjectDetails
            myForm.ShowDialog()
            myForm.Dispose()

            'Affiche les projets
            pDisplayProjects()

        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Sub btcExportToExcel_Click(sender As Object, e As EventArgs) Handles btcExportToExcel.Click
        Try

            Me.Cursor = Cursors.WaitCursor
            pExportToExcel()
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            If DebugFlag = True Then MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

End Class