using System.Windows.Forms;
using DevExpress.DashboardCommon;
using DevExpress.DataAccess.ConnectionParameters;

namespace Dashboard_CreateGeoPointMap {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

            // Creates a new dashboard and a data source for this dashboard.
            Dashboard dashboard = new Dashboard();
            DataSource dataSource = new DataSource(new SqlDataProvider("Connection 1",
                new Access97ConnectionParameters(@"..\..\Data\Cities.mdb", "", ""),
                "select * from Cities"));

            // Creates a Geo Point Map dashboard item and specifies its data source.
            GeoPointMapDashboardItem geopointMap = new GeoPointMapDashboardItem();
            geopointMap.DataSource = dataSource;

            // Loads the map of the world.
            geopointMap.Area = ShapefileArea.WorldCountries;

            // Provides city coordinates and corresponding populations.
            geopointMap.Latitude = new Dimension("Latitude");
            geopointMap.Longitude = new Dimension("Longitude");
            geopointMap.Value = new Measure("Population");

            // Adds the Geo Point Map dashboard item to the dashboard and opens this
            // dashboard in the Dashboard Viewer.
            dashboard.Items.Add(geopointMap);
            dashboardViewer1.Dashboard = dashboard;
        }
    }
}
