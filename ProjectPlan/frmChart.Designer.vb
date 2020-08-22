<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmChart
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim DataPoint1 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0R, 10.0R)
        Dim DataPoint2 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(1.0R, 20.0R)
        Dim DataPoint3 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(2.0R, 25.0R)
        Dim DataPoint4 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(3.0R, 15.0R)
        Dim DataPoint5 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(4.0R, 21.0R)
        Dim DataPoint6 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(5.0R, 25.0R)
        Dim DataPoint7 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(6.0R, 15.0R)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChart))
        Me.myChart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.radInfrastructure = New System.Windows.Forms.RadioButton()
        Me.radTotal = New System.Windows.Forms.RadioButton()
        Me.radSAP = New System.Windows.Forms.RadioButton()
        Me.radHelpdesk = New System.Windows.Forms.RadioButton()
        Me.radPlanification = New System.Windows.Forms.RadioButton()
        Me.btcFermer = New System.Windows.Forms.Button()
        CType(Me.myChart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'myChart
        '
        Me.myChart.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ChartArea1.AxisX.Maximum = 10.0R
        ChartArea1.AxisX.Minimum = 0R
        ChartArea1.AxisY.Maximum = 30.0R
        ChartArea1.AxisY.Minimum = 0R
        ChartArea1.Name = "ChartArea1"
        Me.myChart.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.myChart.Legends.Add(Legend1)
        Me.myChart.Location = New System.Drawing.Point(19, 64)
        Me.myChart.Name = "myChart"
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series1.Legend = "Legend1"
        Series1.Name = "mySeries1"
        DataPoint1.Label = ""
        DataPoint1.LegendText = "test"
        Series1.Points.Add(DataPoint1)
        Series1.Points.Add(DataPoint2)
        Series1.Points.Add(DataPoint3)
        Series1.Points.Add(DataPoint4)
        Series1.Points.Add(DataPoint5)
        Series1.Points.Add(DataPoint6)
        Series1.Points.Add(DataPoint7)
        Me.myChart.Series.Add(Series1)
        Me.myChart.Size = New System.Drawing.Size(1400, 700)
        Me.myChart.TabIndex = 0
        Me.myChart.Text = "Chart1"
        '
        'radInfrastructure
        '
        Me.radInfrastructure.AutoSize = True
        Me.radInfrastructure.Location = New System.Drawing.Point(455, 13)
        Me.radInfrastructure.Name = "radInfrastructure"
        Me.radInfrastructure.Size = New System.Drawing.Size(87, 17)
        Me.radInfrastructure.TabIndex = 1
        Me.radInfrastructure.TabStop = True
        Me.radInfrastructure.Text = "Infrastructure"
        Me.radInfrastructure.UseVisualStyleBackColor = True
        '
        'radTotal
        '
        Me.radTotal.AutoSize = True
        Me.radTotal.Location = New System.Drawing.Point(344, 13)
        Me.radTotal.Name = "radTotal"
        Me.radTotal.Size = New System.Drawing.Size(49, 17)
        Me.radTotal.TabIndex = 2
        Me.radTotal.TabStop = True
        Me.radTotal.Text = "Total"
        Me.radTotal.UseVisualStyleBackColor = True
        '
        'radSAP
        '
        Me.radSAP.AutoSize = True
        Me.radSAP.Location = New System.Drawing.Point(572, 13)
        Me.radSAP.Name = "radSAP"
        Me.radSAP.Size = New System.Drawing.Size(46, 17)
        Me.radSAP.TabIndex = 3
        Me.radSAP.TabStop = True
        Me.radSAP.Text = "SAP"
        Me.radSAP.UseVisualStyleBackColor = True
        '
        'radHelpdesk
        '
        Me.radHelpdesk.AutoSize = True
        Me.radHelpdesk.Location = New System.Drawing.Point(663, 13)
        Me.radHelpdesk.Name = "radHelpdesk"
        Me.radHelpdesk.Size = New System.Drawing.Size(70, 17)
        Me.radHelpdesk.TabIndex = 4
        Me.radHelpdesk.TabStop = True
        Me.radHelpdesk.Text = "Helpdesk"
        Me.radHelpdesk.UseVisualStyleBackColor = True
        '
        'radPlanification
        '
        Me.radPlanification.AutoSize = True
        Me.radPlanification.Location = New System.Drawing.Point(780, 13)
        Me.radPlanification.Name = "radPlanification"
        Me.radPlanification.Size = New System.Drawing.Size(82, 17)
        Me.radPlanification.TabIndex = 5
        Me.radPlanification.TabStop = True
        Me.radPlanification.Text = "Planification"
        Me.radPlanification.UseVisualStyleBackColor = False
        '
        'btcFermer
        '
        Me.btcFermer.Location = New System.Drawing.Point(984, 10)
        Me.btcFermer.Name = "btcFermer"
        Me.btcFermer.Size = New System.Drawing.Size(75, 23)
        Me.btcFermer.TabIndex = 6
        Me.btcFermer.Text = "Fermer"
        Me.btcFermer.UseVisualStyleBackColor = True
        '
        'frmChart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1453, 779)
        Me.Controls.Add(Me.btcFermer)
        Me.Controls.Add(Me.radPlanification)
        Me.Controls.Add(Me.radHelpdesk)
        Me.Controls.Add(Me.radSAP)
        Me.Controls.Add(Me.radTotal)
        Me.Controls.Add(Me.radInfrastructure)
        Me.Controls.Add(Me.myChart)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmChart"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chart graphique"
        CType(Me.myChart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents myChart As DataVisualization.Charting.Chart
    Friend WithEvents radInfrastructure As RadioButton
    Friend WithEvents radTotal As RadioButton
    Friend WithEvents radSAP As RadioButton
    Friend WithEvents radHelpdesk As RadioButton
    Friend WithEvents radPlanification As RadioButton
    Friend WithEvents btcFermer As Button
End Class
