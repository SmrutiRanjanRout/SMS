using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMS
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
        private string ConnectionString
        {
            get
            {
                return ConfigurationManager.AppSettings["ConnectionString"];
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DataTable objdt = new DataTable();
            clsDataAccess objAccess = new clsDataAccess();

            int Count = 0;
            lblMessage.Text = "";

            string PassWord = clsCommon.Encrypt(this.txtPassword.Text.Trim());
            string Email = txtUsername.Text.Trim();

            string SQL = "Select count(*) as Count from Users where Email = '" + Email + "' and Password = '" + PassWord + "'";
            int ret = objAccess.GetDataTable(SQL.ToString(), ConfigurationManager.AppSettings["StrConn"].ToString(), ref objdt);
            if (ret > 0)
            {
                if (objdt.Rows.Count > 0)
                {
                    Count = Convert.ToInt32(objdt.Rows[0]["Count"]);
                }
                if (Count == 1)
                {
                    Response.Redirect("frmMainMasterHome.aspx", true);
                }
                else
                {
                    lblMessage.Text = "Invalid Username or Password";
                }
            }
        }
    }
}