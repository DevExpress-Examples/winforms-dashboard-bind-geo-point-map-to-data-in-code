Imports System.Windows.Forms
Imports DevExpress.DashboardCommon
Imports DevExpress.DataAccess.ConnectionParameters
Imports DevExpress.DataAccess.Sql

Namespace Dashboard_CreateGeoPointMap
	Partial Public Class Form1
		Inherits Form

		Public Sub New()
			InitializeComponent()

			Dim dashboard As New Dashboard()
			Dim dataSource As New DashboardSqlDataSource()
			Dim sqlQuery As New CustomSqlQuery("Cities", "select * from Cities")
			dataSource.ConnectionParameters = New Access97ConnectionParameters("..\..\Data\Cities.mdb", "", "")
			dataSource.Queries.Add(sqlQuery)

			Dim geopointMap As New GeoPointMapDashboardItem()
			geopointMap.DataSource = dataSource
			geopointMap.DataMember = "Cities"

			geopointMap.Area = ShapefileArea.WorldCountries

			geopointMap.Latitude = New Dimension("Latitude")
			geopointMap.Longitude = New Dimension("Longitude")
			geopointMap.Value = New Measure("Population")

			dashboard.Items.Add(geopointMap)
			dashboardViewer1.Dashboard = dashboard
		End Sub
	End Class
End Namespace
