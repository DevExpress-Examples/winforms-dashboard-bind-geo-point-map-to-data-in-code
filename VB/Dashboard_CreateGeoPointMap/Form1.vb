Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports DevExpress.DashboardCommon
Imports DevExpress.DataAccess.ConnectionParameters

Namespace Dashboard_CreateGeoPointMap
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()

			' Creates a new dashboard and a data source for this dashboard.
			Dim dashboard As New Dashboard()
            Dim dataSource As New DataSource( _
                New SqlDataProvider( _
                    "Connection 1", _
                    New Access97ConnectionParameters("..\..\Data\Cities.mdb", "", ""), _
                    "select * from Cities"))

			' Creates a Geo Point Map dashboard item and specifies its data source.
			Dim geopointMap As New GeoPointMapDashboardItem()
			geopointMap.DataSource = dataSource

			' Loads the map of the world.
			geopointMap.Area = ShapefileArea.WorldCountries

			' Provides city coordinates and corresponding populations.
			geopointMap.Latitude = New Dimension("Latitude")
			geopointMap.Longitude = New Dimension("Longitude")
			geopointMap.Value = New Measure("Population")

			' Adds the Geo Point Map dashboard item to the dashboard and opens this
			' dashboard in the Dashboard Viewer.
			dashboard.Items.Add(geopointMap)
			dashboardViewer1.Dashboard = dashboard
		End Sub
	End Class
End Namespace
