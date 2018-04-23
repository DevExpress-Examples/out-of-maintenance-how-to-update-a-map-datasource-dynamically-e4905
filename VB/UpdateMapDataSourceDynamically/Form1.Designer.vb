Imports Microsoft.VisualBasic
Imports System
Namespace UpdateMapDataSourceDynamically
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Dim imageTilesLayer1 As New DevExpress.XtraMap.ImageTilesLayer()
			Dim openStreetMapDataProvider1 As New DevExpress.XtraMap.OpenStreetMapDataProvider()
			Dim vectorItemsLayer1 As New DevExpress.XtraMap.VectorItemsLayer()
			Me.mapControl1 = New DevExpress.XtraMap.MapControl()
			Me.timer1 = New System.Windows.Forms.Timer(Me.components)
			Me.panel1 = New System.Windows.Forms.Panel()
			Me.button1 = New System.Windows.Forms.Button()
			CType(Me.mapControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.panel1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' mapControl1
			' 
			Me.mapControl1.Dock = System.Windows.Forms.DockStyle.Fill
			imageTilesLayer1.DataProvider = openStreetMapDataProvider1
			Me.mapControl1.Layers.Add(imageTilesLayer1)
			Me.mapControl1.Layers.Add(vectorItemsLayer1)
			Me.mapControl1.Location = New System.Drawing.Point(0, 0)
			Me.mapControl1.Name = "mapControl1"
			Me.mapControl1.Size = New System.Drawing.Size(625, 439)
			Me.mapControl1.TabIndex = 0
			' 
			' timer1
			' 
'			Me.timer1.Tick += New System.EventHandler(Me.timer1_Tick);
			' 
			' panel1
			' 
			Me.panel1.Controls.Add(Me.button1)
			Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
			Me.panel1.Location = New System.Drawing.Point(0, 0)
			Me.panel1.Name = "panel1"
			Me.panel1.Size = New System.Drawing.Size(625, 33)
			Me.panel1.TabIndex = 1
			' 
			' button1
			' 
			Me.button1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.button1.Location = New System.Drawing.Point(0, 0)
			Me.button1.Name = "button1"
			Me.button1.Size = New System.Drawing.Size(625, 33)
			Me.button1.TabIndex = 1
			Me.button1.Text = "Update DataSource"
			Me.button1.UseVisualStyleBackColor = True
'			Me.button1.Click += New System.EventHandler(Me.button1_Click);
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(625, 439)
			Me.Controls.Add(Me.panel1)
			Me.Controls.Add(Me.mapControl1)
			Me.Name = "Form1"
			Me.Text = "Form1"
			CType(Me.mapControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.panel1.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private mapControl1 As DevExpress.XtraMap.MapControl
		Private WithEvents timer1 As System.Windows.Forms.Timer
		Private panel1 As System.Windows.Forms.Panel
		Private WithEvents button1 As System.Windows.Forms.Button
	End Class
End Namespace

