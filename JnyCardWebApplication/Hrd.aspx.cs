using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace JnyCardWebApplication
{
    public partial class Hrd : System.Web.UI.Page
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
        }

        protected void NewEmployee_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TxtIdEmployee.Text) || String.IsNullOrEmpty(TxtName.Text))
            {
                msgLabel.Text = "Kolom Harus Diisi";
            }
            else
            {
                SqlConnection koneksi = new SqlConnection(ConfigurationManager.ConnectionStrings["JnyCardEntities"].ToString());

                try
                {
                    koneksi.Open();

                    SqlCommand sqlCommandCheck = new SqlCommand("SELECT * FROM EmployeeTable WHERE nik = @nik AND statusEmp = 1", koneksi);
                    sqlCommandCheck.Parameters.Add(new SqlParameter("@nik", TxtIdEmployee.Text));

                    SqlDataReader sqlDataReaderCheck = sqlCommandCheck.ExecuteReader();

                    

                    if (sqlDataReaderCheck.Read())
                    {
                        msgLabel.Text = "Employee ID Alreade Exists";
                        sqlDataReaderCheck.Close();
                    }
                        
                    else
                    {
                        sqlDataReaderCheck.Close();
                        try
                        {
                            SqlCommand sqlCommand = new SqlCommand("INSERT INTO EmployeeTable (nik,namaEmp,statusEmp) VALUES(@nik,@namaEmp,@statusEmp)", koneksi);
                            sqlCommand.Parameters.Add(new SqlParameter("@nik", TxtIdEmployee.Text));
                            sqlCommand.Parameters.Add(new SqlParameter("@namaEmp", TxtName.Text));
                            sqlCommand.Parameters.Add(new SqlParameter("@statusEmp", 1));

                            int insertDataEmp = sqlCommand.ExecuteNonQuery();
                            if (insertDataEmp > 0)
                            {
                                try
                                {
                                    DateTime nowDate = DateTime.Now;
                                    SqlCommand sqlCommand2 = new SqlCommand("INSERT INTO RequestTable (idClient,ktgClient,reqDate,statusReq) VALUES(@idClient,@ktgClient,@reqDate,@statusReq)", koneksi);
                                    sqlCommand2.Parameters.Add(new SqlParameter("@idClient", TxtIdEmployee.Text));
                                    sqlCommand2.Parameters.Add(new SqlParameter("@ktgClient", 2));
                                    sqlCommand2.Parameters.Add(new SqlParameter("@reqDate", nowDate));
                                    sqlCommand2.Parameters.Add(new SqlParameter("@statusReq", 1));

                                    int insertDataReq = sqlCommand2.ExecuteNonQuery();
                                    if (insertDataReq > 0)
                                    {
                                        koneksi.Close();
                                        Response.Redirect("HrdCheck.aspx");
                                    }
                                    else
                                    {
                                        msgLabel.Text = "Insert Data Request Failed";
                                    }
                                }
                                catch (Exception ex)
                                {
                                    msgLabel.Text = "Insert Request " + ex.Message;
                                }
                            }
                            else
                            {
                                msgLabel.Text = "Insert Data Employee Failed";
                            }

                        }
                        catch (Exception ex)
                        {
                            msgLabel.Text = "Insert Employee " + ex.Message;
                        }
                    }
                }
                catch (Exception ex)
                {
                    msgLabel.Text = "Sql Command Check " + ex.Message;
                }
            }
        }
    }
}