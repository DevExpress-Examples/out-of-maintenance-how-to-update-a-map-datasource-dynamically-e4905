Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraMap
Imports DevExpress.Utils

Namespace UpdateMapDataSourceDynamically
	Partial Public Class Form1
		Inherits Form

		Private latitude As Double = 0

		' Create a vector items layer.
		Private itemsLayer As New VectorItemsLayer()
		Private dataAdapter As New ListSourceDataAdapter()

		' Create an image collection.
		Private imageCollection As New ImageCollection()

		Public Sub New()
			InitializeComponent()
			timer1.Enabled = False

			' Add a vector items layer to the map control created at design time.
			mapControl1.Layers.Add(itemsLayer)

			' Specify mappings for Latitude and Longitude coordinates.
			dataAdapter.Mappings.Latitude = "Latitude"
			dataAdapter.Mappings.Longitude = "Longitude"
			itemsLayer.Data = dataAdapter

			' Specify an image for generated vector items.    
			Dim image As New Bitmap("..\..\Plane.png")
			imageCollection.ImageSize = New Size(40, 40)
			imageCollection.Images.Add(image)
			mapControl1.ImageList = imageCollection
			itemsLayer.ItemImageIndex = 0

			UpdateDataSource()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			timer1.Enabled = True
			timer1.Interval = 1000
			timer1.Start()
		End Sub

		Public Sub UpdateDataSource()
			dataAdapter.DataSource = CreateTable(20)
		End Sub

		Private Sub NextLatitude()
			latitude += 0.5
			If latitude > 180 Then
				latitude = -180
			End If
		End Sub

		Private Function CreateTable(ByVal pointsNumber As Integer) As DataTable
			' Create an empty table.
			Dim table As New DataTable("Table")

			' Add two columns to the table.
			table.Columns.Add("Latitude", GetType(Double))
			table.Columns.Add("Longitude", GetType(Double))

			' Add data rows to the table.
			Dim row As DataRow = Nothing
			NextLatitude()

			For i As Integer = 1 To pointsNumber
				row = table.NewRow()
				row("Latitude") = Math.Sin(latitude + i) * 76
				row("Longitude") = Math.Sin(latitude + i - Math.PI / 2) * 176
				table.Rows.Add(row)
				table.EndLoadData()
			Next i
			Return table
		End Function

		Private Sub timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles timer1.Tick
			UpdateDataSource()
		End Sub
	End Class
End Namespace
