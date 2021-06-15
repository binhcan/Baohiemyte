using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Baohiemyte
{
    public partial class Default : System.Web.UI.Page
    {
        DataProfile data = new DataProfile();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtusername.Focus();
                Session.RemoveAll();

            }
        }

        protected void bttLogin_Click(object sender, EventArgs e)
        {
            string sql = "select * from [Users] where Username='" + txtusername.Text.ToLower() + "' and Password='" + txtpassword.Text + "'";
            DataTable login = data.GetDataTable(sql);
            //string pas = txtpass.Text;
            if (login.Rows.Count > 0)
            {


                Session["use"] = txtusername.Text.ToLower();
                Session["pas"] = login.Rows[0]["Password"].ToString();
                Session["id"] = login.Rows[0]["id"].ToString();
                Session["per"] = login.Rows[0]["Per"].ToString();
                Session["huyen_id"] = login.Rows[0]["huyen_id"].ToString();
                Session["xa_id"] = login.Rows[0]["xa_id"].ToString();
                Session["hoten"] = txtHoten.Text.Trim();
                Response.Redirect("DashBoardSub.aspx");
                
            }
            else
            {
                Response.Write("<script language='javascript'> alert('Login Fail !') </script>");
                txtusername.Focus();
            }
            txtusername.Text = "";
            txtpassword.Text = "";
        }
    }
}
