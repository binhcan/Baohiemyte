using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Baohiemyte
{
    public partial class Danhsach : System.Web.UI.Page
    {
        DataProfile data = new DataProfile();
        int useid, huyen_id, xa_id, per;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            useid = Convert.ToInt32(Session["id"].ToString());
            huyen_id = Convert.ToInt32(Session["huyen_id"].ToString());
            xa_id = Convert.ToInt32(Session["xa_id"].ToString());
            per = Convert.ToInt32(Session["per"].ToString());
            //huyen_id = 1;
            //xa_id = 1;
            if (!IsPostBack)
            {
                Load_dropHuyen();
                Load_dropXa();
                LoadData();
            }
        }
        private void Load_dropHuyen()
        {
            string sql = "";
            if (huyen_id > 0)
            {
                sql = "select * from DM_Huyen where id = '" + huyen_id + "' ";
            }
            else
            {
                sql = "select * from DM_Huyen ";
            }
            DataTable tbl = data.GetDataTable(sql);
            Drophuyen.DataSource = tbl;
            Drophuyen.DataTextField = "Huyen";
            Drophuyen.DataValueField = "ID";
            Drophuyen.DataBind();

            //DropHuyen.Items.Insert(0, "--Chọn huyện--");

            if (huyen_id > 0 && per > 1)
            {
                Drophuyen.SelectedValue = huyen_id.ToString();
                Drophuyen.Enabled = false;
            }
        }

        private void Load_dropXa()
        {
            string sql = "select * from DM_Xa where Idhuyen = '" + Drophuyen.SelectedValue + "' ";
            DataTable tbl = data.GetDataTable(sql);
            Dropxa.DataSource = tbl;
            Dropxa.DataTextField = "Xa";
            Dropxa.DataValueField = "ID";
            Dropxa.DataBind();

            Dropxa.Items.Insert(0, "--Chọn xã--");

            if (xa_id > 0 && per > 2)
            {
                Dropxa.SelectedValue = xa_id.ToString();
                Dropxa.Enabled = false;
            }

        }
        protected void LoadData()
        {
            string s="";
            if (Dropxa.SelectedIndex==0)
            {
                s = "select * from NCC_Baohiem where huyen_id = '"+Drophuyen.SelectedValue+"' ";
            }
            else
            {
                s = "select * from NCC_Baohiem where huyen_id = '" + Drophuyen.SelectedValue + "' and xa_id = '" + Dropxa.SelectedValue + "' ";
            }    
            
            DataTable tbl = data.GetDataTable(s);
            //DataTable tbl = data.GetDataTableStore_All("BaoHiemGetAll");
            rptBaohiem.DataSource = tbl;
            rptBaohiem.DataBind();
        }

        protected void lbtnview_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            Response.Redirect("ChitietBaohiem.aspx?id=" + id);
        }

        protected void lbtnbaogiam_Click(object sender, EventArgs e)
        {

        }

        protected void lbtxoa_Click(object sender, EventArgs e)
        {

        }

        protected void Drophuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_dropXa();
        }

        protected void Dropxa_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        protected void rptBaohiem_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }


    }
}