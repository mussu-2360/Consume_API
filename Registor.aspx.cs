using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD_API_Source
{
    public partial class Registor : System.Web.UI.Page
    {
        CallingApi objApiCall;
        Student st;
        DataTable dt;
        static int StuId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindInwardGrid();
            }

        }

        public void BindInwardGrid()
        {
            Student st = new Student();
            objApiCall = new CallingApi();
            DataTable dt = CallingApi.CallApiGetDt("Crud/Getdata1");
            if (dt.Rows.Count > 0)
            {
                grd.DataSource = dt;
                grd.DataBind();

            }
            else
            {
                grd.DataSource = null;
                grd.DataBind();

            }
        }

        protected void sbmbtn_Click(object sender, EventArgs e)
        {
            st = new Student();
            // objApiCall = new ClsAPICalling();
            st.FirstName = txtfname.Text;
            st.LastName = txtlname.Text;
            st.DateOfBirth = txtdob.Text;
            st.Email = txtemail.Text;
            // st.PhoneNumber = int.Parse(txtno.Text);
            st.PhoneNumber = txtno.Text;
            st.Address = txtadd.Text;
            st.StudentId = StuId;
            dt = new DataTable();
            if (sbmbtn.Text == "Submit")
            {
                dt = CallingApi.CallApiPostDS("Crud/insertdata", st);
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["res"].ToString() == "1")
                    {
                        lblmsg.Text = dt.Rows[0]["msg"].ToString();
                        lblmsg.ForeColor = System.Drawing.Color.Green;
                        lblmsg.Focus();
                    }
                }
            }
            else if (sbmbtn.Text == "Update")
            {
                dt = CallingApi.CallApiPostDS("Crud/UpdateStudent", st);
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["res"].ToString() == "1")
                    {
                        lblmsg.Text = dt.Rows[0]["msg"].ToString();
                        lblmsg.ForeColor = System.Drawing.Color.Green;
                        lblmsg.Focus();
                    }
                }
            }


            //dt = CallingApi.CallApiPostDS("Crud/insertdata", st);
            //else if (dt != null && dt.rows.count > 0)
            //{
            //    if (dt.rows[0]["res"].tostring() == "1")
            //    {
            //        lblmsg.text = dt.rows[0]["msg"].tostring();
            //        lblmsg.forecolor = system.drawing.color.green;
            //        lblmsg.focus();
            //    }
            //}
            BindInwardGrid();
            Clear();
        }

        public void Clear()
        {
            txtfname.Text = "";
            txtlname.Text = "";
            txtdob.Text = "";
            txtemail.Text = "";
            txtno.Text = "";
            txtadd.Text = "";
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Button button1 = (Button)sender;
            GridViewRow row = (GridViewRow)button1.Parent.Parent;
            txtfname.Text = ((Label)row.FindControl("lblFirstName") as Label).Text;
            txtlname.Text = ((Label)row.FindControl("lblLastName") as Label).Text;
            txtdob.Text = ((Label)row.FindControl("lblDateOfBirth") as Label).Text;
            txtemail.Text = ((Label)row.FindControl("lblEmail") as Label).Text;
            txtno.Text = ((Label)row.FindControl("lblPhoneNumber") as Label).Text;
            txtadd.Text = ((Label)row.FindControl("lblAddress") as Label).Text;
            string studentid = ((Label)row.FindControl("lblStudentId") as Label).Text;
            StuId = Convert.ToInt32(studentid);
            sbmbtn.Text = "Update";
        }

        protected void btndelete_Click1(object sender, EventArgs e)
        {

            Button button1 = (Button)sender;
            GridViewRow row = (GridViewRow)button1.Parent.Parent;
            string studentid = ((Label)row.FindControl("lblStudentId") as Label).Text;
            StuId = Convert.ToInt32(studentid);
            DataTable dt = CallingApi.CallApiGetDt("Crud/delete?StudentId=" + StuId);
            if (dt != null && dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["res"].ToString() == "1")
                {
                    lblmsg.Text = "Delete Row Successfully !!";
                    lblmsg.ForeColor = System.Drawing.Color.Green;
                    lblmsg.Focus();
                    BindInwardGrid();
                }
                else
                {
                    lblmsg.Text = "Delete Row Not Successfully !!";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    lblmsg.Focus();
                }
            }

        }
    }

}





