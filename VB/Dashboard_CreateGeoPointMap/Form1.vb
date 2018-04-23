Imports System.Windows.Forms
Imports DevExpress.DashboardCommon
Imports DevExpress.DataAccess.ConnectionParameters
Imports DevExpress.DataAccess.Sql

Namespace Dashboard_CreateGeoPointMap
    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()

            ' Creates a new dashboard and a data source for this dashboard.
            Dim dashboard As New Dashboard()
            Dim dataSource As New DashboardSqlDataSource()
            Dim sqlQuery As New CustomSqlQuery("Cities", "select * from Cities")
            dataSource.ConnectionParameters =
                New Access97ConnectionParameters("..\..\Data\Cities.mdb", "", "")
            dataSource.Queries.Add(sqlQuery)

            ' Creates a Geo Point Map dashboard item and specifies its data source.
            Dim geopointMap As New GeoPointMapDashboardItem()
            geopointMap.DataSource = dataSource
            geopointMap.DataMember = "Cities"

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
