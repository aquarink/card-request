using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace JnyCardWebApplication
{
    public partial class HrdCheck : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string idUser = (string)(Session["idUser"]);
            string kategori = (string)(Session["kategori"]);

            //if (kategori == "2")
            //{
            //    Session["idUser"] = idUser;
            //    Session["kategori"] = kategori;
            //    Response.Redirect("Adm.aspx");
            //}
            //else if (kategori == "3")
            //{
            //    Session["idUser"] = idUser;
            //    Session["kategori"] = kategori;
            //    Response.Redirect("Mis.aspx");
            //}

            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }

        private void BindGrid()
        {
            StringBuilder htmlTable = new StringBuilder();

            SqlConnection koneksi = new SqlConnection(ConfigurationManager.ConnectionStrings["JnyCardEntities"].ToString());

            try
            {
                koneksi.Open();

                SqlCommand sqlCommandFetch = new SqlCommand("SELECT RequestTable.idReq, RequestTable.idClient, RequestTable.ktgClient, RequestTable.sp, RequestTable.reqDate, RequestTable.progressDate, RequestTable.doneDate, RequestTable.statusReq, EmployeeTable.idEmp, EmployeeTable.nik, EmployeeTable.namaEmp, EmployeeTable.statusEmp FROM RequestTable INNER JOIN EmployeeTable ON RequestTable.idClient = EmployeeTable.nik AND RequestTable.ktgClient = 2", koneksi);
                SqlDataReader sqlDataReader = sqlCommandFetch.ExecuteReader();

                //
                htmlTable.Append("<table class='table table-responsive'><tr><th>REQUEST DATE</th><th>EMPLOYE ID</th><th>EMPLOYE NAME</th><th>PROGRESS DATE</th><th>FINISH DATE</th></tr>");
                //
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        htmlTable.Append("<tr>");
                        //
                        string reqDateSql = sqlDataReader["reqDAte"].ToString();
                        DateTime reqDate = Convert.ToDateTime(reqDateSql);
                        htmlTable.Append("<td>" + reqDate + "</td>");

                        htmlTable.Append("<td>" + sqlDataReader["idClient"] + "</td>");

                        htmlTable.Append("<td>" + sqlDataReader["namaEmp"] + "</td>");
                        //
                        if(String.IsNullOrEmpty(sqlDataReader["progressDate"].ToString()))
                        {
                            htmlTable.Append("<td>Still Request</td>");
                            htmlTable.Append("<td>Still Request</td>");
                        }
                        else 
                        {
                            string progressDateSql = sqlDataReader["progressDate"].ToString();
                            DateTime progressDate = Convert.ToDateTime(progressDateSql);
                            htmlTable.Append("<td>" + progressDate + "</td>");
                            

                             if(String.IsNullOrEmpty(sqlDataReader["doneDate"].ToString()))
                             {
                                 htmlTable.Append("<td>On Progress</td>");
                             }
                             else
                             {
                                 string doneDateSql = sqlDataReader["doneDate"].ToString();
                                DateTime doneDate = Convert.ToDateTime(doneDateSql);
                                htmlTable.Append("<td>" + doneDate + "</td>");
                             }
                        }
                        //
                        htmlTable.Append("</tr>");
                    }
                }
                htmlTable.Append("</table>");
                HistoryPlaceHolder.Controls.Add(new Literal { Text = htmlTable.ToString() });

                sqlDataReader.Close();
                sqlDataReader.Dispose();
            }
            catch (Exception ex)
            {
                LabelHistory.Text = "Insert Employee " + ex.Message;
            }
            finally
            {
                koneksi.Close();
            }
        }
    }
}