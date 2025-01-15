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
    public partial class Students : System.Web.UI.Page
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
                PopulateSection();
                PopulateTitle();
                PopulateStudents();
                PopulateStudentsData();
            }
        }

        private void PopulateStudents()
        {
            string strSQL;
            DataTable objdt;
            clsDataAccess objAccess;
            int ret;

            ret = 0;
            strSQL = string.Empty;
            objdt = new DataTable();
            objAccess = new clsDataAccess();

            strSQL = "Select t1.id, t2.Name as Class, t3.Name + ' ' + t1.FirstName + ' ' + t1.SurName as Name,";
            strSQL += " t1.City, t1.PinCode, t1.MobileNumber, case t1.isActive when 1 then 'Active' else 'InActive' end as IsActive";
            strSQL += " from Students as t1 left outer join Class as t2 on t1.ClassID = t2.Id";
            strSQL += " left outer join Title as t3 on t1.TitleId = t3.Id order by t2.Name, t1.Id";
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
        private void PopulateTitle()
        {
            string strSQL;
            DataTable objdt;
            clsDataAccess objAccess;
            int ret;

            ret = 0;
            strSQL = string.Empty;
            objdt = new DataTable();
            objAccess = new clsDataAccess();

            strSQL = "select id, name from title order by id";
            ret = objAccess.GetDataTable(strSQL, ConfigurationManager.AppSettings["StrConn"].ToString(), ref objdt);
            if (ret > 0)
            {
                if (objdt.Rows.Count > 0)
                {
                    this.ddlTitle.DataSource = null;
                    this.ddlTitle.DataBind();

                    this.ddlTitle.DataSource = objdt;
                    this.ddlTitle.DataBind();
                    this.ddlTitle.SelectedIndex = 0;
                }
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

        private void PopulateSection()
        {
            string strSQL;
            DataTable objdt;
            clsDataAccess objAccess;
            int ret;

            ret = 0;
            strSQL = string.Empty;
            objdt = new DataTable();
            objAccess = new clsDataAccess();

            strSQL = "select id, name from section where isactive = 1 order by id";
            ret = objAccess.GetDataTable(strSQL, ConfigurationManager.AppSettings["StrConn"].ToString(), ref objdt);
            if (ret > 0)
            {
                if (objdt.Rows.Count > 0)
                {
                    this.ddlSection.DataSource = null;
                    this.ddlSection.DataBind();

                    this.ddlSection.DataSource = objdt;
                    this.ddlSection.DataBind();
                    this.ddlSection.SelectedIndex = 0;
                }
            }
        }
        protected void dgCase_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            string StudentsID = string.Empty;
            string strSQL = string.Empty;
            int ret = 0;
            clsDataAccess objAccess = new clsDataAccess();

            if (e.CommandName == "cmd_edit")
            {
                if (e.Item.FindControl("lblGridStudentsID") != null)
                {
                    StudentsID = ((Label)e.Item.FindControl("lblGridStudentsID")).Text;
                    this.ViewState["StudentsID"] = StudentsID;
                    PopulatePartDetail(StudentsID);
                    this.btnAddStudents.Visible = false;
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
                strSQL = "select FirstName, SurName, TitleId, FatherName, MotherName, ClassId, SectionId, Address, City, State, PinCode, MobileNumber, GenderId, Cast(isActive as Int) as isActive from Students Where ID = " + Convert.ToString(this.ViewState["StudentsID"]);
                objAccess.GetDataTable(strSQL, ConfigurationManager.AppSettings["StrConn"].ToString(), ref objdt);
                if (objdt.Rows.Count > 0)
                {
                    this.txtfirstname.Text = Convert.ToString(objdt.Rows[0]["FirstName"]);
                    this.txtSurname.Text = Convert.ToString(objdt.Rows[0]["SurName"]);
                    this.ddlTitle.SelectedValue = Convert.ToString(objdt.Rows[0]["TitleId"]);
                    this.txtFathersName.Text = Convert.ToString(objdt.Rows[0]["FatherName"]);
                    this.txtMothersName.Text = Convert.ToString(objdt.Rows[0]["MotherName"]);
                    this.ddlClass.SelectedValue = Convert.ToString(objdt.Rows[0]["ClassId"]);
                    this.ddlSection.SelectedValue= Convert.ToString(objdt.Rows[0]["SectionId"]);
                    this.txtAddress.Text = Convert.ToString(objdt.Rows[0]["Address"]);
                    this.txtCity.Text = Convert.ToString(objdt.Rows[0]["City"]);
                    this.txtState.Text = Convert.ToString(objdt.Rows[0]["State"]);
                    this.txtPincode.Text = Convert.ToString(objdt.Rows[0]["Pincode"]);
                    this.txtMobileNumber.Text = Convert.ToString(objdt.Rows[0]["MobileNumber"]);
                    this.rblGender.SelectedValue = Convert.ToString(objdt.Rows[0]["GenderId"]);
                    this.rblActive.SelectedValue = Convert.ToString(objdt.Rows[0]["isActive"]);
                }
            }
        }
        private void PopulateDivLock()
        {
            this.txtfirstname.Enabled = false;
            this.txtSurname.Enabled = false;
            this.ddlTitle.Enabled = false;  
            this.txtFathersName.Enabled = false;
            this.txtMothersName.Enabled = false ;
            this.ddlClass.Enabled = false;
            this.ddlSection.Enabled = false;
            this.txtAddress.Enabled = false;
            this.txtCity.Enabled = false;
            this.txtState.Enabled = false;
            this.txtPincode.Enabled = false;
            this.txtMobileNumber.Enabled = false;
            this.rblGender.Enabled = false;
            this.rblActive.Enabled = false;
        }
        private void PopulateStudentsData()
        {
            string strSQL;
            DataTable objdt;
            clsDataAccess objAccess;
            int ret;
            ret = 0;
            strSQL = string.Empty;
            objdt = new DataTable();
            objAccess = new clsDataAccess();
            strSQL = "select a.id, b.name + ' ' + a.FirstName + a.SurName as Name, c.Name as Class, a.City, a.PinCode, a.MobileNumber, case a.isActive when 1 then 'Active' else 'InActive' end as IsActive from Students a left outer join title b on a.TitleId= b.Id left outer join class c on a.ClassId = c.Id order by a.id";
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
        protected void btnAddStudents_Click(object sender, EventArgs e)
        {
            this.lblMessage.Text = "";

            PopulateClear();

            this.txtfirstname.Enabled = true;
            this.txtSurname.Enabled = true;
            this.ddlTitle.Enabled = true;
            this.txtFathersName.Enabled = true;
            this.txtMothersName.Enabled = true;
            this.ddlClass.Enabled = true;
            this.ddlSection.Enabled = true;
            this.txtAddress.Enabled = true;
            this.txtCity.Enabled = true;
            this.txtState.Enabled = true;
            this.txtPincode.Enabled = true;
            this.txtMobileNumber.Enabled = true;
            this.rblGender.Enabled = true;
            this.rblActive.Enabled = true;

            this.divView.Visible = false;
            this.pnlDataDetail.Visible = true;
            this.divAddEdit.Visible = true;
            this.btnAddStudents.Visible = false;
            this.btnSave.Visible = true;
            this.btnUpdate.Visible = false;
            this.btnEdit.Visible = false;
            this.btnBack.Visible = true;
            this.btnCancel.Visible = false;
            this.ViewState["StudentsID"] = null;
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            this.divView.Visible = false;
            this.pnlDataDetail.Visible = true;
            this.divAddEdit.Visible = true;
            this.lblMessage.Text = "";

            this.txtfirstname.Enabled = true;
            this.txtSurname.Enabled = true;
            this.ddlTitle.Enabled = true;
            this.txtFathersName.Enabled = true;
            this.txtMothersName.Enabled = true;
            this.ddlClass.Enabled = true;
            this.ddlSection.Enabled = true;
            this.txtAddress.Enabled = true;
            this.txtCity.Enabled = true;
            this.txtState.Enabled = true;
            this.txtPincode.Enabled = true;
            this.txtMobileNumber.Enabled = true;
            this.rblGender.Enabled = true;
            this.rblActive.Enabled = true;

            this.btnAddStudents.Visible = false;
            this.btnSave.Visible = false;
            this.btnUpdate.Visible = true;
            this.btnEdit.Visible = false;
            this.btnBack.Visible = false;
            this.btnCancel.Visible = true;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtfirstname.Text != "")
            {
                int ret = 0;
                string strSQL = string.Empty;
                clsDataAccess objAccess = new clsDataAccess();
                strSQL = "Insert into Students (FirstName, SurName, TitleId, FatherName, MotherName, ClassId, SectionId, Address, City, State, PinCode, MobileNumber, GenderId, isActive)Values('" + txtfirstname.Text.Trim() + "', '" + txtSurname.Text.Trim() + "', '" + ddlTitle.SelectedValue + "', '" + txtFathersName.Text.Trim() + "', '" + txtMothersName.Text.Trim() + "', '" + ddlClass.SelectedValue + "', '" + ddlSection.SelectedValue + "', '" + txtAddress.Text.Trim() + "', '" + txtCity.Text.Trim() + "', '" + txtState.Text.Trim() + "', '" + txtPincode.Text.Trim() + "', '" + txtMobileNumber.Text.Trim() + "', '" + rblGender.SelectedValue + "', " + Convert.ToInt32(rblActive.SelectedValue) + ")";
                ret = objAccess.ExecuteNonQuery(strSQL, ConfigurationManager.AppSettings["StrConn"].ToString());
                if (ret > 0)
                {
                    this.ViewState["StudentsID"] = null;
                    this.btnBack_Click(this, null);
                    this.lblMessage.Text = "Record Successfully Inserted";
                    this.lblMessage.ForeColor = System.Drawing.Color.FromArgb(51, 153, 102);
                }
                else
                {
                    this.lblMessage.Text = "Enter Students";
                    this.lblMessage.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0);
                }
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            clsDataAccess objAccess = new clsDataAccess();
            if (txtfirstname.Text != "")
            {
                int success = 0;
                string StudentsID = string.Empty;
                StudentsID = this.ViewState["StudentsID"].ToString();
                string strSQL = string.Empty;
                int isActive = Convert.ToInt32(rblActive.SelectedValue);
                strSQL = "update Students set FirstName = '" + txtfirstname.Text.Trim() + "', SurName = '" + txtSurname.Text.Trim() + "', TitleId = '" + ddlTitle.SelectedValue + "', FatherName = '" + txtFathersName.Text.Trim() + "', MotherName = '" + txtMothersName.Text.Trim() + "', ClassId = '" + ddlClass.SelectedValue + "', SectionId = '" + ddlSection.SelectedValue + "', Address = '" + txtAddress.Text.Trim() + "', City = '" + txtCity.Text.Trim() + "', State = '" + txtState.Text.Trim() + "', PinCode = '" + txtPincode.Text.Trim() + "', MobileNumber = '" + txtMobileNumber.Text.Trim() + "', GenderId = '" + rblGender.SelectedValue + "', isActive = " + isActive + " where id = " + StudentsID;
                success = objAccess.ExecuteNonQuery(strSQL, ConfigurationManager.AppSettings["StrConn"].ToString());
                if (success > 0)
                {
                    PopulatePartDetail(StudentsID);
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
                this.lblMessage.Text = "Enter Students Name";
                this.lblMessage.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0);
            }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            this.txtfirstname.Enabled = true;
            this.txtSurname.Enabled = true;
            this.ddlTitle.Enabled = true;
            this.txtFathersName.Enabled = true;
            this.txtMothersName.Enabled = true;
            this.ddlClass.Enabled = true;
            this.ddlSection.Enabled = true;
            this.txtAddress.Enabled = true;
            this.txtCity.Enabled = true;
            this.txtState.Enabled = true;
            this.txtPincode.Enabled = true;
            this.txtMobileNumber.Enabled = true;
            this.rblGender.Enabled = true;
            this.rblActive.Enabled = true;

            this.divView.Visible = true;
            this.pnlDataDetail.Visible = false;
            this.divAddEdit.Visible = false;
            this.lblMessage.Text = "";
            this.btnAddStudents.Visible = true;
            this.btnSave.Visible = false;
            this.btnUpdate.Visible = false;
            this.btnEdit.Visible = false;
            this.btnBack.Visible = false;
            this.btnCancel.Visible = false;
            PopulateStudentsData();
            this.ViewState["StudentsID"] = null;
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.divView.Visible = false;
            this.pnlDataDetail.Visible = true;
            this.divAddEdit.Visible = true;
            string StudentsID;
            StudentsID = this.ViewState["StudentsID"].ToString();
            this.lblMessage.Text = "";
            this.btnAddStudents.Visible = false;
            this.btnSave.Visible = false;
            this.btnUpdate.Visible = false;
            this.btnEdit.Visible = true;
            this.btnBack.Visible = true;
            this.btnCancel.Visible = false;
            PopulatePartDetail(StudentsID);
            PopulateDivLock();
        }
        private void PopulateClear()
        {
            this.txtfirstname.Text = ""; ;
            this.txtSurname.Text = ""; ;
            this.ddlTitle.SelectedValue = "1";
            this.txtFathersName.Text = ""; ;
            this.txtMothersName.Text = ""; ;
            this.ddlClass.SelectedValue = "1";
            this.ddlSection.SelectedValue = "1";
            this.txtAddress.Text = ""; ;
            this.txtCity.Text = ""; ;
            this.txtState.Text = ""; ;
            this.txtPincode.Text = ""; ;
            this.txtMobileNumber.Text = ""; ;
            this.rblGender.SelectedValue = "1";
            this.rblActive.SelectedValue = "1";
        }
        protected void dgCase_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            this.lblMessage.Text = "";
            PopulateStudentsData();
            dgCase.CurrentPageIndex = e.NewPageIndex;
            dgCase.DataBind();
        }
    }
}