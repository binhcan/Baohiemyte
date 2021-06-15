using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Baohiemyte
{
    public partial class ThemmoiBaohiem : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                Load_dropHuyen();
                Load_dropXa();
                LoadPage();
                //Load_Baohiem();
            }
        }
        private void LoadPage()
        {
            //add - edit bao hiem

            txthoten.Text = "";
            txtngaysinh.Text = "";
            txtgioitinh.Text = "";
            txtsoBH.Text = "";
            txtdoituong.Text = "";
            btedit.Visible = false;
            btsave.Visible = true;

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
            DropHuyen.DataSource = tbl;
            DropHuyen.DataTextField = "Huyen";
            DropHuyen.DataValueField = "ID";
            DropHuyen.DataBind();

            //DropHuyen.Items.Insert(0, "--Chọn huyện--");

            if (huyen_id > 0 && per > 1)
            {
                DropHuyen.SelectedValue = huyen_id.ToString();
                DropHuyen.Enabled = false;
            }

        }
        private void Load_dropXa()
        {
            string sql = "select * from DM_Xa where Idhuyen = '" + DropHuyen.SelectedValue + "' ";
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
        private void Load_Baohiem()
        {
            string sql = "select top 1 a. *, b.xa from NCC_Baohiem a " +
                " left join  DM_Xa b on a.Xa_id = b.Id " +
               " where a.huyen_id= '" + huyen_id + "' and a.xa_id = '" + Dropxa.SelectedValue + "' " +
                " order by a.id desc ";

            DataTable tbl = data.GetDataTable(sql);
            rptbaohiem.DataSource = tbl;
            rptbaohiem.DataBind();
        }
        protected void btsave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txthoten.Text) || string.IsNullOrEmpty(txtsoBH.Text) || string.IsNullOrEmpty(txtngaysinh.Text) || string.IsNullOrEmpty(txtdoituong.Text) || Dropxa.SelectedIndex < 1)
            {
                Response.Write("<script language='javascript'> alert('Thông tin bạn nhập chưa đầy đủ, hãy kiểm tra lại!') </script>");
            }
            else
            {
                string sql = "insert into NCC_Baohiem (SoBHXH,Hoten,Gioitinh,Namsinh,xa_id,huyen_id,LoaiBH,Create_by,Create_date) " +
                " values ('" + txtsoBH.Text.Trim() + "', N'" + txthoten.Text.Trim() + "',N'" + txtgioitinh.Text.Trim() + "','" + txtngaysinh.Text.Trim() + "'," +
                "'" + Dropxa.SelectedValue + "','" + DropHuyen.SelectedValue + "','" + txtsoBH.Text.Trim().Substring(0, 2) + "', '" + useid + "', Getdate() ) ";

                data.ExcuteQuery(sql);
                Load_Baohiem();
                LoadPage();
            }
        }

        protected void btedit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txthoten.Text) || string.IsNullOrEmpty(txtsoBH.Text) || string.IsNullOrEmpty(txtngaysinh.Text) || string.IsNullOrEmpty(txtdoituong.Text) || Dropxa.SelectedIndex < 1)
            {
                Response.Write("<script language='javascript'> alert('Thông tin bạn nhập chưa đầy đủ, hãy kiểm tra lại!') </script>");
            }
            else
            {
                string sql = "update NCC_Baohiem set SoBHXH='" + txtsoBH.Text.Trim() + "',Hoten=N'" + txthoten.Text.Trim() + "'," +
                    " Gioitinh=N'" + txtgioitinh.Text.Trim() + "',Namsinh='" + txtngaysinh.Text.Trim() + "',xa_id='" + Dropxa.SelectedValue + "'," +
                    " huyen_id='" + DropHuyen.SelectedValue + "',LoaiBH='" + txtsoBH.Text.Trim().Substring(0, 2) + "',update_by='" + useid + "',update_date = Getdate() " +
                    " where id = '" + HiddenField1.Value + "' ";


                data.ExcuteQuery(sql);
                Load_Baohiem();
                LoadPage();
            }
        }

        protected void bthuythaotac_Click(object sender, EventArgs e)
        {
            LoadPage();
        }

        protected void txtsoBH_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtsoBH.Text)) txtdoituong.Text = txtsoBH.Text.Trim().Substring(0, 2);
        }

        protected void DropHuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_dropXa();
        }

        protected void btThoat_Click(object sender, EventArgs e)
        {
            Response.Redirect("BaohiemCheck.aspx");
        }

        protected void lbteditbh_Click(object sender, EventArgs e)
        {
            var idbh = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            string sql = "select * from NCC_Baohiem where id = '" + idbh + "' ";
            DataTable tbl = data.GetDataTable(sql);

            HiddenField1.Value = idbh.ToString();
            txthoten.Text = tbl.Rows[0]["Hoten"].ToString(); ;
            txtngaysinh.Text = tbl.Rows[0]["Namsinh"].ToString(); ;
            txtgioitinh.Text = tbl.Rows[0]["Gioitinh"].ToString(); ;
            txtsoBH.Text = tbl.Rows[0]["SoBHXH"].ToString(); ;
            txtdoituong.Text = tbl.Rows[0]["LoaiBH"].ToString();
            Dropxa.SelectedValue = tbl.Rows[0]["Xa_id"].ToString().Trim();
            DropHuyen.SelectedValue = tbl.Rows[0]["Huyen_id"].ToString().Trim();

            btedit.Visible = true;
            btsave.Visible = false;
        }

        protected void lblxoabh_Click(object sender, EventArgs e)
        {
            var idbh = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            string sql = "delete NCC_Baohiem where Id = '" + idbh + "' ";
            data.ExcuteQuery(sql);

            Response.Redirect("ThemmoiBaohiem.aspx");
        }
    }
}