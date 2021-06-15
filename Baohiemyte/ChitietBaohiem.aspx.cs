using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Baohiemyte
{
    public partial class ChitietBaohiem : System.Web.UI.Page
    {
        DataProfile data = new DataProfile();
        int useid, id_get, idbh, huyen_id, xa_id, per;
        string hoten;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            useid = Convert.ToInt32(Session["id"].ToString());
            huyen_id = Convert.ToInt32(Session["huyen_id"].ToString());
            xa_id = Convert.ToInt32(Session["xa_id"].ToString());
            idbh = Convert.ToInt32(Request.QueryString["id"].ToString());
            per = Convert.ToInt32(Session["per"].ToString());
            hoten = Session["hoten"].ToString();
            //huyen_id = 1;
            //xa_id = 1;
            if (!IsPostBack)
            {
                Load_dropHuyen();
                Load_dropXa();
                Load_Page();
                Load_data();
            }
        }
        private void Load_Page()
        {

            divedit.Visible = false;
            divview.Visible = true;
            divbuttonedit.Visible = false;
            divbutton.Visible = true;
            divbaogiam.Visible = false;
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

        private void Load_data()
        {
            string sql1 = "select a.*,b.Xa, c.Huyen from NCC_Baohiem a " +
               "left join DM_xa b on a.Xa_id = b.Id " +
               " left join DM_Huyen c on a.Huyen_id = c.id " +
               " where a.Id = '" + idbh + "' ";
            DataTable tbl1 = data.GetDataTable(sql1);
            //view
            lblidbh.Text = tbl1.Rows[0]["Id"].ToString();
            lblhotenbh.Text = tbl1.Rows[0]["Hoten"].ToString();
            lblgioitinhbh.Text = tbl1.Rows[0]["Gioitinh"].ToString();
            lblsoBH.Text = tbl1.Rows[0]["SoBHXH"].ToString();
            lblnamsinhbh.Text = tbl1.Rows[0]["Namsinh"].ToString();
            lblxabh.Text = tbl1.Rows[0]["Xa"].ToString();
            lblHuyenbh.Text = tbl1.Rows[0]["Huyen"].ToString();
            lbldoituongbh.Text = tbl1.Rows[0]["LoaiBH"].ToString();
            lblbaogiambh.Text = tbl1.Rows[0]["Baogiam"].ToString();
            lblthoigianbaogiam.Text = tbl1.Rows[0]["Thoigianbaogiam"].ToString();
            lbllydobaogiam.Text = tbl1.Rows[0]["Lydo"].ToString();

            //edit

            txthoten.Text = lblhotenbh.Text;
            txtngaysinh.Text = lblnamsinhbh.Text;
            txtgioitinh.Text = lblgioitinhbh.Text;
            txtsoBH.Text = lblsoBH.Text;
            txtdoituong.Text = lbldoituongbh.Text.ToUpper();
            Dropxa.SelectedValue = tbl1.Rows[0]["Xa_id"].ToString().Trim();
            DropHuyen.SelectedValue = tbl1.Rows[0]["Huyen_id"].ToString().Trim();

        }
        protected void btcancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Danhsach.aspx");
        }
                
        protected void btsaveedit_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txthoten.Text) || String.IsNullOrEmpty(txtsoBH.Text) || String.IsNullOrEmpty(txtdoituong.Text) || Dropxa.SelectedIndex == 0)
            {
                Response.Write("<script language='javascript'> alert('Bạn phải nhập đủ thông tin!') </script>");
            }
            else
            {
                if (txtsoBH.Text.Substring(0, 2) != txtdoituong.Text.Trim().ToUpper())
                {
                    Response.Write("<script language='javascript'> alert('Kiểm tra lại số BHXH và đối tượng!') </script>");
                }
                else
                {
                    string sql = "update NCC_Baohiem set Hoten = N'" + txthoten.Text.Trim() + "', Namsinh = '" + txtngaysinh.Text.Trim() + "', " +
                " Gioitinh = N'" + txtgioitinh.Text + "', Xa_id = '" + Dropxa.SelectedValue + "', LoaiBH = N'" + txtdoituong.Text.Trim().ToUpper() + "', " +
                "SoBHXH = '" + txtsoBH.Text.Trim().ToUpper() + "' ,update_date = Getdate(), update_by = '" + useid + "', HotenUser = N'" + hoten + "'  " +
                " where id = '" + Convert.ToInt32(lblidbh.Text) + "' ";
                    data.ExcuteQuery(sql);
                    Load_data();
                    Load_Page();
                }

            }
        }

        protected void btcanceledit_Click(object sender, EventArgs e)
        {
            Load_Page();
        }

        protected void btupdate_Click(object sender, EventArgs e)
        {
            Load_data();
            divedit.Visible = true;
            divview.Visible = false;
            divbutton.Visible = false;
            divbuttonedit.Visible = true;
        }
        protected void btBaogiam_Click(object sender, EventArgs e)
        {
            datepickerbh.Value = "";
            txtlydobaogiambh.Text = "";
            divbaogiam.Visible = true;
        }
        protected void btbaogiambh_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtlydobaogiambh.Text) || String.IsNullOrEmpty(datepickerbh.Value))
            {
                Response.Write("<script language='javascript'> alert('Bạn phải nhập đủ thời gian và lý do báo giảm!') </script>");
            }
            else
            {
                string sql = "update NCC_Baohiem set Baogiam = 1, update_date = Getdate(), update_by = '" + useid + "', HotenUser = N'" + hoten + "',  " +
                    " Thoigianbaogiam = Convert(Datetime,'" + datepickerbh.Value + "',103), Lydo = N'" + txtlydobaogiambh.Text + "' " +
                " where Id = '" + Convert.ToInt32(lblidbh.Text) + "' ";
                data.ExcuteQuery(sql);
                Load_Page();
                Load_data();
            }
        }

        protected void btcancelbaogiam_Click(object sender, EventArgs e)
        {
            datepickerbh.Value = "";
            txtlydobaogiambh.Text = "";
            divbaogiam.Visible = false;
        }
    }
}