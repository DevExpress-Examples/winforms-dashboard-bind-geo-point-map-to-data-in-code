using System.Windows.Forms;
using DevExpress.DashboardCommon;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;

namespace Dashboard_CreateGeoPointMap {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

            // Creates a new dashboard and a data source for this dashboard.
            Dashboard dashboard = new Dashboard();
            DashboardSqlDataSource dataSource = new DashboardSqlDataSource();
            CustomSqlQuery sqlQuery = new CustomSqlQuery("Cities", "select * from Cities");
            dataSource.ConnectionParameters = 
                new Access97ConnectionParameters(@"..\..\Data\Cities.mdb", "", "");
            dataSource.Queries.Add(sqlQuery);

            // Creates a Geo Point Map dashboard item and specifies its data source.
            GeoPointMapDashboardItem geopointMap = new GeoPointMapDashboardItem();
            geopointMap.DataSource = dataSource;
            geopointMap.DataMember = "Cities";

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
