using System.Windows.Forms;
using DevExpress.DashboardCommon;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;

namespace Dashboard_CreateGeoPointMap {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

            Dashboard dashboard = new Dashboard();
            DashboardSqlDataSource dataSource = new DashboardSqlDataSource();
            CustomSqlQuery sqlQuery = new CustomSqlQuery("Cities", "select * from Cities");
            dataSource.ConnectionParameters = 
                new Access97ConnectionParameters(@"..\..\Data\Cities.mdb", "", "");
            dataSource.Queries.Add(sqlQuery);

            GeoPointMapDashboardItem geopointMap = new GeoPointMapDashboardItem();
            geopointMap.DataSource = dataSource;
            geopointMap.DataMember = "Cities";

            geopointMap.Area = ShapefileArea.WorldCountries;

            geopointMap.Latitude = new Dimension("Latitude");
            geopointMap.Longitude = new Dimension("Longitude");
            geopointMap.Value = new Measure("Population");

            dashboard.Items.Add(geopointMap);
            dashboardViewer1.Dashboard = dashboard;
        }
    }
}
