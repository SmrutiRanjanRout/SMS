using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMS
{
    public partial class StudentFees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (clsCommon.IsValidSessionState() == 0)
            {
                //Response.Redirect("default.aspx", true);
            }
            if (!this.IsPostBack)
            {
                divAddEdit.Visible = false;
                PopulateClass();
                PopulateStudentFeesData();
            }
        }
        private void PopulateClass()
        {
            string strSQL;
            DataTable objdt;
            clsDataAccess objAccess;
            int ret;

            ret = 0;
            strSQL = string.Empty;
            objdt = new DataTable();
            objAccess = new clsDataAccess();

            strSQL = "select id, name from class where isactive = 1 order by id";
            ret = objAccess.GetDataTable(strSQL, ConfigurationManager.AppSettings["StrConn"].ToString(), ref objdt);
            if (ret > 0)
            {
                if (objdt.Rows.Count > 0)
                {
                    this.ddlClass.DataSource = null;
                    this.ddlClass.DataBind();

                    this.ddlClass.DataSource = objdt;
                    this.ddlClass.DataBind();
                    this.ddlClass.SelectedIndex = 0;
                }
            }
        }
        protected void dgCase_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            string StudentFeesID = string.Empty;
            string strSQL = string.Empty;
            int ret = 0;
            clsDataAccess objAccess = new clsDataAccess();

            if (e.CommandName == "cmd_edit")
            {
                if (e.Item.FindControl("lblGridStudentFeesID") != null)
                {
                    StudentFeesID = ((Label)e.Item.FindControl("lblGridStudentFeesID")).Text;
                    this.ViewState["StudentFeesID"] = StudentFeesID;
                    PopulatePartDetail(StudentFeesID);

                    this.btnAddStudentFees.Visible = false;
                    this.btnSave.Visible = false;
                    this.btnUpdate.Visible = false;
                    this.btnEdit.Visible = true;
                    this.btnBack.Visible = true;
                    this.btnCancel.Visible = false;

                    this.divView.Visible = false;
                    this.pnlDataDetail.Visible = true;
                    this.divAddEdit.Visible = true;

                    this.lblMessage.Text = "";

                    PopulateDivLock();
                }
            }
        }

        private void PopulatePartDetail(string strSiteID)
        {
            {
                string strSQL;
                DataTable objdt;
                clsDataAccess objAccess;

                strSQL = "";
                objdt = new DataTable();
                objAccess = new clsDataAccess();

                strSQL = "select ClassID, Fees, Cast(isActive as Int) as isActive from StudentsFees Where ID = " + Convert.ToString(this.ViewState["StudentFeesID"]);
                objAccess.GetDataTable(strSQL, ConfigurationManager.AppSettings["StrConn"].ToString(), ref objdt);
                if (objdt.Rows.Count > 0)
                {
                    this.ddlClass.SelectedValue = Convert.ToString(objdt.Rows[0]["ClassID"]);
                    this.txtname.Text = Convert.ToString(objdt.Rows[0]["Fees"]);
                    this.rblActive.SelectedValue = Convert.ToString(objdt.Rows[0]["isActive"]);
                }
            }
        }

        private void PopulateDivLock()
        {
            this.txtname.Enabled = false;
            this.rblActive.Enabled = false;
        }

        private void PopulateStudentFeesData()
        {
            string strSQL;
            DataTable objdt;
            clsDataAccess objAccess;
            int ret;

            ret = 0;
            strSQL = string.Empty;
            objdt = new DataTable();
            objAccess = new clsDataAccess();

            strSQL = "select t1.id, t1.ClassID, t2.Name as Class, t1.fees, case t1.isActive when 1 then 'Active' else 'InActive' end as IsActive from StudentsFees as t1 left outer join Class as t2 on t1.ClassID = t2.Id order by id";
            ret = objAccess.GetDataTable(strSQL, ConfigurationManager.AppSettings["StrConn"].ToString(), ref objdt);
            if (ret > 0)
            {
                if (objdt.Rows.Count > 0)
                {
                    this.dgCase.DataSource = null;
                    this.dgCase.DataBind();

                    this.dgCase.DataSource = objdt;
                    this.dgCase.DataBind();
                }
            }
        }

        protected void btnAddStudentFees_Click(object sender, EventArgs e)
        {
            this.lblMessage.Text = "";
            PopulateClear();

            this.txtname.Enabled = true;
            this.rblActive.Enabled = true;

            this.divView.Visible = false;
            this.pnlDataDetail.Visible = true;
            this.divAddEdit.Visible = true;

            this.btnAddStudentFees.Visible = false;
            this.btnSave.Visible = true;
            this.btnUpdate.Visible = false;
            this.btnEdit.Visible = false;
            this.btnBack.Visible = true;
            this.btnCancel.Visible = false;

            this.ViewState["StudentFeesID"] = null;
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {

            this.divView.Visible = false;
            this.pnlDataDetail.Visible = true;
            this.divAddEdit.Visible = true;

            this.lblMessage.Text = "";

            this.txtname.Enabled = true;
            this.rblActive.Enabled = true;

            this.btnAddStudentFees.Visible = false;
            this.btnSave.Visible = false;
            this.btnUpdate.Visible = true;
            this.btnEdit.Visible = false;
            this.btnBack.Visible = false;
            this.btnCancel.Visible = true;

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtname.Text != "")
            {
                int ret = 0;
                string strSQL = string.Empty;
                clsDataAccess objAccess = new clsDataAccess();

                strSQL = "Insert into StudentsFees (ClassID, Fees, isActive)Values('" + ddlClass.SelectedValue + "', '" + txtname.Text.Trim() + "', " + Convert.ToInt32(rblActive.SelectedValue) + ")";
                ret = objAccess.ExecuteNonQuery(strSQL, ConfigurationManager.AppSettings["StrConn"].ToString());
                if (ret > 0)
                {
                    this.ViewState["StudentFeesID"] = null;
                    this.btnBack_Click(this, null);
                    this.lblMessage.Text = "Record Successfully Inserted";
                    this.lblMessage.ForeColor = System.Drawing.Color.FromArgb(51, 153, 102);
                }
                else
                {
                    this.lblMessage.Text = "Enter StudentFees";
                    this.lblMessage.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0);
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            clsDataAccess objAccess = new clsDataAccess();
            if (txtname.Text != "")
            {
                int success = 0;
                string StudentFeesID = string.Empty;

                StudentFeesID = this.ViewState["StudentFeesID"].ToString();

                string strSQL = string.Empty;

                int isActive = Convert.ToInt32(rblActive.SelectedValue);

                strSQL = "update StudentsFees set ClassID = '" + ddlClass.SelectedValue + "', Fees = '" + txtname.Text + "', isActive = " + isActive + " where id = " + StudentFeesID;
                success = objAccess.ExecuteNonQuery(strSQL, ConfigurationManager.AppSettings["StrConn"].ToString());
                if (success > 0)
                {
                    PopulatePartDetail(StudentFeesID);

                    this.btnCancel_Click(this, null);

                    this.lblMessage.Text = "Record Successfully Updated";
                    this.lblMessage.ForeColor = System.Drawing.Color.FromArgb(51, 153, 102);
                }
                else
                {
                    this.lblMessage.Text = "Sorry, Unable To Update Record";
                    this.lblMessage.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0);
                }
            }
            else
            {
                this.lblMessage.Text = "Enter StudentFees Name";
                this.lblMessage.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0);
            }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            this.txtname.Enabled = true;
            this.rblActive.Enabled = true;

            this.divView.Visible = true;
            this.pnlDataDetail.Visible = false;
            this.divAddEdit.Visible = false;

            this.lblMessage.Text = "";

            this.btnAddStudentFees.Visible = true;
            this.btnSave.Visible = false;
            this.btnUpdate.Visible = false;
            this.btnEdit.Visible = false;
            this.btnBack.Visible = false;
            this.btnCancel.Visible = false;

            PopulateStudentFeesData();

            this.ViewState["StudentFeesID"] = null;
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.divView.Visible = false;
            this.pnlDataDetail.Visible = true;
            this.divAddEdit.Visible = true;

            string StudentFeesID;
            StudentFeesID = this.ViewState["StudentFeesID"].ToString();
            this.lblMessage.Text = "";
            this.btnAddStudentFees.Visible = false;
            this.btnSave.Visible = false;
            this.btnUpdate.Visible = false;
            this.btnEdit.Visible = true;
            this.btnBack.Visible = true;
            this.btnCancel.Visible = false;
            PopulatePartDetail(StudentFeesID);
            PopulateDivLock();
        }

        private void PopulateClear()
        {
            this.txtname.Text = "";
            this.rblActive.SelectedValue = "1";
        }

        protected void dgCase_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            this.lblMessage.Text = "";
            PopulateStudentFeesData();
            dgCase.CurrentPageIndex = e.NewPageIndex;
            dgCase.DataBind();
        }
    }
}