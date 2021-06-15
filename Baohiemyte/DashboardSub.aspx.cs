using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace Baohiemyte
{
    public partial class DashboardSub : System.Web.UI.Page
    {
        DataProfile data = new DataProfile();
        int useid, huyen_id, xa_id, per;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["id"] == null)
            //{
            //    Response.Redirect("Default.aspx");
            //}
            //useid = Convert.ToInt32(Session["id"].ToString());
            //huyen_id = Convert.ToInt32(Session["huyen_id"].ToString());
            //xa_id = Convert.ToInt32(Session["xa_id"].ToString());
            //per = Convert.ToInt32(Session["per"].ToString());
            huyen_id = 1;
            xa_id = 1;
            if (!IsPostBack)
            {
                LoadData();
            }
        }
        protected void LoadData()
        {
            string s = "select LoaiBH, count(LoaiBH) as Tongso from NCC_Baohiem where huyen_id = '" + huyen_id + "' group by LoaiBH";
            //if (per == 2)
            //{
            //    s = "select LoaiBH, count(LoaiBH) as Tongso from NCC_Baohiem where huyen_id = '" + huyen_id+ "' group by LoaiBH ";
            //}
            //else
            //{
            //    s = "select LoaiBH, count(LoaiBH) as Tongso from NCC_Baohiem where huyen_id = '" + huyen_id + "' and xa_id = '" + xa_id + "' group by LoaiBH ";
            //}

            DataTable tbl = data.GetDataTable(s);
            string[] x = new string[tbl.Rows.Count];
            int[] y = new int[tbl.Rows.Count];

            for (int i=0; i<tbl.Rows.Count; i++)
            {
                x[i] = tbl.Rows[i][0].ToString();
                y[i] = Convert.ToInt32(tbl.Rows[i][1].ToString());

            }
            baohiemchart.Series[0].Points.Clear();
            baohiemchart.Series[0].Points.DataBindXY(x, y);
            baohiemchart.Series[0].ChartType = SeriesChartType.Pie;
            baohiemchart.Series["baohiemSeries1"].Label = "#PERCENT{P2}";
            baohiemchart.Series["baohiemSeries1"].LegendText = "#VALX";

            baohiemchart.ChartAreas["baohiemChartArea1"].Area3DStyle.Enable3D = true;


            baohiemchart.Legends["baohiemLegend"].Enabled = true;
            baohiemchart.Legends["baohiemLegend"].LegendStyle = LegendStyle.Column;
            baohiemchart.Legends["baohiemLegend"].Alignment = StringAlignment.Center;
            baohiemchart.Legends["baohiemLegend"].Docking = Docking.Right;

            //Column chart
            baohiemchartcol.Series[0].Points.Clear();
            baohiemchartcol.Series[0].Points.DataBindXY(x, y);
            baohiemchartcol.Series[0].ChartType = SeriesChartType.Column;
            baohiemchartcol.Series[0].IsValueShownAsLabel = true;

            baohiemchartcol.Legends["baohiemcolLegend"].Enabled = false;

            baohiemchartcol.ChartAreas["baohiemcolChartArea1"].AxisX.MajorGrid.Enabled = false;
            baohiemchartcol.ChartAreas["baohiemcolChartArea1"].AxisY.MajorGrid.Enabled = false;
            //baohiemchartcol.ChartAreas["baohiemcolChartArea1"].Area3DStyle.Enable3D = true;

        }
    }
}