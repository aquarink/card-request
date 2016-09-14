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
    public partial class HrdEmployee : System.Web.UI.Page
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

            if (this.IsPostBack)
            {
                this.EditEmployeeData();
            }
            else
            {
                this.EmployeeData();
            }
        }

        private void EmployeeData()
        {
            StringBuilder htmlTable = new StringBuilder();

            SqlConnection koneksi = new SqlConnection(ConfigurationManager.ConnectionStrings["JnyCardEntities"].ToString());

            try
            {
                koneksi.Open();

                SqlCommand sqlCommandFetch = new SqlCommand("SELECT idEmp, nik, namaEmp, statusEmp FROM EmployeeTable WHERE (statusEmp = 1)", koneksi);
                SqlDataReader sqlDataReader = sqlCommandFetch.ExecuteReader();

                //
                htmlTable.Append("<table class='table table-responsive'><tr><th>EMPLOYE ID</th><th>EMPLOYE NAME</th><th>REQUEST CARD</th><th>EDIT</th><th>DELETE</th></tr>");
                //
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + sqlDataReader["nik"] + "</td>");
                        htmlTable.Append("<td>" + sqlDataReader["namaEmp"] + "</td>");
                        htmlTable.Append("<td><a class='btn btn-warning' href='HrdCheck.aspx/Employe=" + sqlDataReader["idEmp"] + "'>Request Card</a></td>");

                        //
                        htmlTable.Append("<td><a class='btn btn-info' data-toggle='modal' data-target='#myModal" + sqlDataReader["nik"] + "'>Edit " + sqlDataReader["namaEmp"] + "</a></td>");
                        //
                        htmlTable.Append("<div class='modal fade' id='myModal" + sqlDataReader["nik"] + "' tabindex='-1' role='dialog' aria-labelledby='myModalLabel'>");
                        htmlTable.Append("<div class='modal-dialog' role='document'>");
                        htmlTable.Append("<div class='modal-content'>");
                        htmlTable.Append("<div class='modal-header'>");
                        htmlTable.Append("<button type='button' class='close' data-dismiss='modal' aria-label='Close'><span aria-hidden='true'>&times;</span></button>");
                        htmlTable.Append("<h4 class='modal-title' id='myModalLabel'>Edit " + sqlDataReader["namaEmp"] + " Data</h4>");
                        htmlTable.Append("</div>");
                        htmlTable.Append("<div class='modal-body'>");
                        //
                        htmlTable.Append("<form class='form-group' action='' method='POST'>");
                        htmlTable.Append("<label>Name</label>");
                        htmlTable.Append("<input class='form-control' type='text' name='txtNamaEdit' value='" + sqlDataReader["namaEmp"] + "'>");
                        htmlTable.Append("<input class='form-control' type='hidden' name='txtId' value='" + sqlDataReader["idEmp"] + "' />");
                        htmlTable.Append("<hr />");
                        htmlTable.Append("<input name='updateEmployee' class='btn btn-lg btn-success btn-block' type='submit' value='Update Employee Data'/>");
                        htmlTable.Append("</form>");
                        //
                        htmlTable.Append("</div>");
                        htmlTable.Append("</div>");
                        htmlTable.Append("</div>");
                        htmlTable.Append("</div>");
                        //
                        
                        htmlTable.Append("</tr>");
                    }
                    //
                    htmlTable.Append("</table>");

                    EmployeeDataPlaceHolder.Controls.Add(new Literal { Text = htmlTable.ToString() });

                    sqlDataReader.Close();
                    sqlDataReader.Dispose();
                }

            }
            catch (Exception ex)
            {
                LabelPesan.Text = "Insert Employee " + ex.Message;
            }
            finally
            {
                koneksi.Close();
            }
        }

        private void EditEmployeeData()
        {
            string updateEmployee = Request.Form["updateEmployee"];
            string txtNamaEdit = Request.Form["txtNamaEdit"];
            string txtId = Request.Form["txtId"];
            //
            if (updateEmployee == "Update Employee Data")
            {
                // Update
                if (String.IsNullOrEmpty(txtNamaEdit) || String.IsNullOrEmpty(txtId))
                {
                    LabelPesan.Text = "Kolom Harus Diisi";
                }
                else
                {
                    SqlConnection koneksi = new SqlConnection(ConfigurationManager.ConnectionStrings["JnyCardEntities"].ToString());
                    
                    try
                    {
                        koneksi.Open();

                        SqlCommand sqlCommandUpdateEmp = new SqlCommand("UPDATE EmployeeTable SET namaEmp = @namaEmp WHERE idEmp = @idEmp", koneksi);
                        sqlCommandUpdateEmp.Parameters.Add(new SqlParameter("@namaEmp", txtNamaEdit));
                        sqlCommandUpdateEmp.Parameters.Add(new SqlParameter("@idEmp", txtId));

                        int updateEmpData = sqlCommandUpdateEmp.ExecuteNonQuery();
                        if (updateEmpData > 0)
                        {
                            koneksi.Close();
                            Response.Redirect("HrdEmployee.aspx");
                        }
                        else
                        {
                            LabelPesan.Text = "Update Data Request Failed";
                        }
                    }
                    catch (Exception ex)
                    {
                        LabelPesan.Text = "Update Data " + ex.Message;
                    }
                }
            }
            else 
            {
                // Bukan Post Back Edit Employee Data
                LabelPesan.Text = "Result search data..!";
            }
        }

        private void SearchDataEmp()
        {
            StringBuilder htmlSearchTable = new StringBuilder();

            SqlConnection koneksi = new SqlConnection(ConfigurationManager.ConnectionStrings["JnyCardEntities"].ToString());

            try
            {
                koneksi.Open();

                SqlCommand sqlCommandSearchFetch = new SqlCommand("SELECT idEmp,nik,namaEmp,statusEmp FROM EmployeeTable WHERE (nik LIKE '%" + SearchTextBox.Text + "%') OR (namaEmp LIKE '%" + SearchTextBox.Text + "%') AND (statusEmp = 1)", koneksi);
                SqlDataReader sqlSearchDataReader = sqlCommandSearchFetch.ExecuteReader();

                //
                htmlSearchTable.Append("<table class='table table-responsive'><tr><th>EMPLOYE ID</th><th>EMPLOYE NAME</th><th>REQUEST CARD</th><th>EDIT</th><th>DELETE</th></tr>");
                //
                if (sqlSearchDataReader.HasRows)
                {
                    while (sqlSearchDataReader.Read())
                    {
                        htmlSearchTable.Append("<tr>");
                        htmlSearchTable.Append("<td>" + sqlSearchDataReader["nik"] + "</td>");
                        htmlSearchTable.Append("<td>" + sqlSearchDataReader["namaEmp"] + "</td>");
                        htmlSearchTable.Append("<td><a class='btn btn-warning' href='HrdCheck.aspx/Employe=" + sqlSearchDataReader["idEmp"] + "'>Request Card</a></td>");

                        //
                        htmlSearchTable.Append("<td><a class='btn btn-info' data-toggle='modal' data-target='#myModal" + sqlSearchDataReader["nik"] + "'>Edit " + sqlSearchDataReader["namaEmp"] + "</a></td>");
                        //
                        htmlSearchTable.Append("<div class='modal fade' id='myModal" + sqlSearchDataReader["nik"] + "' tabindex='-1' role='dialog' aria-labelledby='myModalLabel'>");
                        htmlSearchTable.Append("<div class='modal-dialog' role='document'>");
                        htmlSearchTable.Append("<div class='modal-content'>");
                        htmlSearchTable.Append("<div class='modal-header'>");
                        htmlSearchTable.Append("<button type='button' class='close' data-dismiss='modal' aria-label='Close'><span aria-hidden='true'>&times;</span></button>");
                        htmlSearchTable.Append("<h4 class='modal-title' id='myModalLabel'>Edit " + sqlSearchDataReader["namaEmp"] + " Data</h4>");
                        htmlSearchTable.Append("</div>");
                        htmlSearchTable.Append("<div class='modal-body'>");
                        //
                        htmlSearchTable.Append("<form class='form-group' action='' method='POST'>");
                        htmlSearchTable.Append("<label>Name</label>");
                        htmlSearchTable.Append("<input class='form-control' type='text' name='txtNamaEdit' value='" + sqlSearchDataReader["namaEmp"] + "'>");
                        htmlSearchTable.Append("<input class='form-control' type='hidden' name='txtId' value='" + sqlSearchDataReader["idEmp"] + "' />");
                        htmlSearchTable.Append("<hr />");
                        htmlSearchTable.Append("<input name='updateEmployee' class='btn btn-lg btn-success btn-block' type='submit' value='Update Employee Data'/>");
                        htmlSearchTable.Append("</form>");
                        //
                        htmlSearchTable.Append("</div>");
                        htmlSearchTable.Append("</div>");
                        htmlSearchTable.Append("</div>");
                        htmlSearchTable.Append("</div>");
                        //

                        htmlSearchTable.Append("</tr>");
                    }
                    //
                    htmlSearchTable.Append("</table>");

                    SearchEmployeeDataPlaceHolder.Controls.Add(new Literal { Text = htmlSearchTable.ToString() });

                    sqlSearchDataReader.Close();
                    sqlSearchDataReader.Dispose();
                }

            }
            catch (Exception ex)
            {
                LabelPesan.Text = "Insert Employee " + ex.Message;
            }
            finally
            {
                koneksi.Close();
            }
        }

        protected void BtnSearch(object sender, EventArgs e)
        {
            this.SearchDataEmp();
        }
    }
}