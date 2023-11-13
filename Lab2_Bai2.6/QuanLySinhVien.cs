using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QLSV
{
    public class QuanLySinhVien
    {
        private readonly SqlConnection _dbConnect;

        public QuanLySinhVien()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "DESKTOP-38JM1H0";
            builder.UserID = "sa";
            builder.Password = "123456";
            builder.InitialCatalog = "QLSV";
            _dbConnect = new SqlConnection(builder.ConnectionString);
        }
        public DbConnection DbConnect => _dbConnect;


        public bool Add(SinhVien s)
        {
            try
            {
                string query = "INSERT INTO SINHVIEN(id, ho_ten, diem_toan, diem_ly, diem_hoa, diem_trung_binh, ma_lop) " +
                               "OUTPUT inserted.id " +
                               "VALUES (@id,@ho_ten,@dt,@dl,@dh,@dtb,@malop)";
               using (SqlCommand command = new SqlCommand(query,_dbConnect)) {
                    command.Parameters.AddWithValue("@id",s.Mssv);
                    command.Parameters.AddWithValue("@ho_ten",s.Ten);
                    command.Parameters.AddWithValue("@dt",s.DiemToan);
                    command.Parameters.AddWithValue("@dl",s.DiemLy);
                    command.Parameters.AddWithValue("@dh",s.DiemHoa);
                    command.Parameters.AddWithValue("@dtb",s.Dtb);
                    command.Parameters.AddWithValue("@malop",s.Malop);
                    _dbConnect.Open();
                    command.ExecuteScalar();
                    return true;
                }
            }
            catch (SqlException ex) 
            {
                throw ex;
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
            catch
            {
                return false;
            }
            finally { 
                _dbConnect.Close();
            }   
        }

        public bool Delete(string id)
        {
            try
            {
               string query = "DELETE SINHVIEN " +
                              "OUTPUT deleted.id " +
                              "WHERE id = @id";
               using (SqlCommand command = new SqlCommand(query,_dbConnect)) {
                    command.Parameters.AddWithValue("@id",id);
                    _dbConnect.Open();
                    if (command.ExecuteScalar() != null)
                        return true;
                    return false;
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
            finally { 
                _dbConnect.Close();
            }   
        }

       


        public List<SinhVien> Search(string id, string name)
        {

            try
            {
                List<SinhVien> result = new List<SinhVien> ();
                string query = "SELECT id, ho_ten, ma_lop, diem_toan, diem_ly, diem_hoa, diem_trung_binh " +
                               "FROM SINHVIEN " +
                               "WHERE id = @id OR ho_ten = @ho_ten";
                using (SqlCommand command = new SqlCommand(query, _dbConnect))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@ho_ten", name);
                    
                    _dbConnect.Open(); 
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string maLop = "KTPM2022.";
                            switch (reader.GetInt32(2) )
                            {
                                case 1:
                                    maLop += "1";
                                    break;
                                case 2:
                                    maLop += "2";
                                    break;
                                case 3:
                                    maLop += "3";
                                    break;
                                case 4:
                                    maLop += "4";
                                    break;
                            }

                            SinhVien s = new SinhVien (
                                reader.GetString(0),
                                reader.GetString(1),
                                maLop,
                                (float)reader.GetDecimal(3),
                                (float)reader.GetDecimal(4),
                                (float)reader.GetDecimal(5),
                                (float)reader.GetDecimal(6));
                            result.Add (s);
                        }
                    }

                    return result;  
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString()); 
                return null;
            }
            finally
            {
                _dbConnect.Close();
            }
        }


        public List<SinhVien> GetSinhVienByClassId(int classID)
        {
            try
            {
                List<SinhVien> result = new List<SinhVien>();
                string query = "SELECT id, ho_ten, ma_lop, diem_toan, diem_ly, diem_hoa, diem_trung_binh " +
                               "FROM SINHVIEN " +
                               "WHERE ma_lop = @malop";

                using (SqlCommand command = new SqlCommand(query, _dbConnect))
                {
                    command.Parameters.AddWithValue("@malop",classID);
                    _dbConnect.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string maLop = "KTPM2022.";
                            switch (reader.GetInt32(2))
                            {
                                case 1:
                                    maLop += "1";
                                    break;
                                case 2:
                                    maLop += "2";
                                    break;
                                case 3:
                                    maLop += "3";
                                    break;
                                case 4:
                                    maLop += "4";
                                    break;
                            }
                            SinhVien s = new SinhVien(
                                reader.GetString(0),
                                reader.GetString(1),
                                maLop,
                                (float)reader.GetDecimal(3),
                                (float)reader.GetDecimal(4),
                                (float)reader.GetDecimal(5),
                                (float)reader.GetDecimal(6));
                            result.Add(s);
                        }
                    }

                    return result;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
            finally
            {
                _dbConnect.Close();
            }
        }
    }

}
