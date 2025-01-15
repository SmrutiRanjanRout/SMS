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
    public partial class Section : System.Web.UI.Page
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
                PopulateSectionData();
            }
        }

        protected void dgCase_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            string SectionID = string.Empty;
            string strSQL = string.Empty;
            int ret = 0;
            clsDataAccess objAccess = new clsDataAccess();

            if (e.CommandName == "cmd_edit")
            {
                if (e.Item.FindControl("lblGridSectionID") != null)
                {
                    SectionID = ((Label)e.Item.FindControl("lblGridSectionID")).Text;
                    this.ViewState["SectionID"] = SectionID;
                    PopulatePartDetail(SectionID);

                    this.btnAddSection.Visible = false;
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

                strSQL = "select Name, Cast(isActive as Int) as isActive from Section Where ID = " + Convert.ToString(this.ViewState["SectionID"]);
                objAccess.GetDataTable(strSQL, ConfigurationManager.AppSettings["StrConn"].ToString(), ref objdt);
                if (objdt.Rows.Count > 0)
                {
                    this.txtname.Text = Convert.ToString(objdt.Rows[0]["Name"]);
                    this.rblActive.SelectedValue = Convert.ToString(objdt.Rows[0]["isActive"]);
                }
            }
        }

        private void PopulateDivLock()
        {
            this.txtname.Enabled = false;
            this.rblActive.Enabled = false;
        }

        private void PopulateSectionData()
        {
            string strSQL;
            DataTable objdt;
            clsDataAccess objAccess;
            int ret;

            ret = 0;
            strSQL = string.Empty;
            objdt = new DataTable();
            objAccess = new clsDataAccess();

            strSQL = "select id, Name, case isActive when 1 then 'Active' else 'InActive' end as IsActive from Section order by id";
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

        protected void btnAddSection_Click(object sender, EventArgs e)
        {
            this.lblMessage.Text = "";
            PopulateClear();

            this.txtname.Enabled = true;
            this.rblActive.Enabled = true;

            this.divView.Visible = false;
            this.pnlDataDetail.Visible = true;
            this.divAddEdit.Visible = true;

            this.btnAddSection.Visible = false;
            this.btnSave.Visible = true;
            this.btnUpdate.Visible = false;
            this.btnEdit.Visible = false;
            this.btnBack.Visible = true;
            this.btnCancel.Visible = false;

            this.ViewState["SectionID"] = null;
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {

            this.divView.Visible = false;
            this.pnlDataDetail.Visible = true;
            this.divAddEdit.Visible = true;

            this.lblMessage.Text = "";

            this.txtname.Enabled = true;
            this.rblActive.Enabled = true;

            this.btnAddSection.Visible = false;
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

                strSQL = "Insert into Section (Name, isActive)Values('" + txtname.Text.Trim() + "', " + Convert.ToInt32(rblActive.SelectedValue) + ")";
                ret = objAccess.ExecuteNonQuery(strSQL, ConfigurationManager.AppSettings["StrConn"].ToString());
                if (ret > 0)
                {
                    this.ViewState["SectionID"] = null;
                    this.btnBack_Click(this, null);
                    this.lblMessage.Text = "Record Successfully Inserted";
                    this.lblMessage.ForeColor = System.Drawing.Color.FromArgb(51, 153, 102);
                }
                else
                {
                    this.lblMessage.Text = "Enter Section";
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
                string SectionID = string.Empty;

                SectionID = this.ViewState["SectionID"].ToString();

                string strSQL = string.Empty;

                int isActive = Convert.ToInt32(rblActive.SelectedValue);

                strSQL = "update Section set Name = '" + txtname.Text + "', isActive = " + isActive + " where id = " + SectionID;
                success = objAccess.ExecuteNonQuery(strSQL, ConfigurationManager.AppSettings["StrConn"].ToString());
                if (success > 0)
                {
                    PopulatePartDetail(SectionID);

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
                this.lblMessage.Text = "Enter Section Name";
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

            this.btnAddSection.Visible = true;
            this.btnSave.Visible = false;
            this.btnUpdate.Visible = false;
            this.btnEdit.Visible = false;
            this.btnBack.Visible = false;
            this.btnCancel.Visible = false;

            PopulateSectionData();

            this.ViewState["SectionID"] = null;
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.divView.Visible = false;
            this.pnlDataDetail.Visible = true;
            this.divAddEdit.Visible = true;

            string SectionID;
            SectionID = this.ViewState["SectionID"].ToString();
            this.lblMessage.Text = "";
            this.btnAddSection.Visible = false;
            this.btnSave.Visible = false;
            this.btnUpdate.Visible = false;
            this.btnEdit.Visible = true;
            this.btnBack.Visible = true;
            this.btnCancel.Visible = false;
            PopulatePartDetail(SectionID);
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
            PopulateSectionData();
            dgCase.CurrentPageIndex = e.NewPageIndex;
            dgCase.DataBind();
        }
    }
}