using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraMap;
using DevExpress.Utils;

namespace UpdateMapDataSourceDynamically {
    public partial class Form1 : Form {

        double latitude = 0;

        // Create a vector items layer.
        VectorItemsLayer itemsLayer = new VectorItemsLayer();
        ListSourceDataAdapter dataAdapter = new ListSourceDataAdapter();

        // Create an image collection.
        ImageCollection imageCollection = new ImageCollection();

        public Form1() {
            InitializeComponent();
            timer1.Enabled = false;

            // Add a vector items layer to the map control created at design time.
            mapControl1.Layers.Add(itemsLayer);

            // Specify mappings for Latitude and Longitude coordinates.
            dataAdapter.Mappings.Latitude = "Latitude";
            dataAdapter.Mappings.Longitude = "Longitude";
            itemsLayer.Data = dataAdapter;

            // Specify an image for generated vector items.    
            Bitmap image = new Bitmap(@"..\..\Plane.png");
            imageCollection.ImageSize = new Size(40, 40);
            imageCollection.Images.Add(image);
            mapControl1.ImageList = imageCollection;
            itemsLayer.ItemImageIndex = 0;

            UpdateDataSource();
        }

        private void button1_Click(object sender, EventArgs e) {
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Start();
        }

        public void UpdateDataSource() {
            dataAdapter.DataSource = CreateTable(20);
        }

        void NextLatitude() {
            latitude += 0.5;
            if (latitude > 180) latitude = -180;
        }

        private DataTable CreateTable(int pointsNumber) {
            // Create an empty table.
            DataTable table = new DataTable("Table");

            // Add two columns to the table.
            table.Columns.Add("Latitude", typeof(double));
            table.Columns.Add("Longitude", typeof(double));

            // Add data rows to the table.
            DataRow row = null;
            NextLatitude();

            for (int i = 1; i <= pointsNumber; i++) {
                row = table.NewRow();
                row["Latitude"] = Math.Sin(latitude + i) * 76;
                row["Longitude"] = Math.Sin(latitude + i - Math.PI / 2) * 176;
                table.Rows.Add(row);
                table.EndLoadData();
            }
            return table;
        }

        private void timer1_Tick(object sender, EventArgs e) {
            UpdateDataSource();
        }
    }
}
