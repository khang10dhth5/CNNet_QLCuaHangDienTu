using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_Nhom16
{
    class XuLyDB
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds= new DataSet();
        App_Config_Setting ast = new App_Config_Setting();
        string ProjectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        public bool SaoLuu(string TenFile)
        {


            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string time = DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss");
                string sql = string.Format("BACKUP DATABASE QL_THIETBI TO DISK = N'" + ProjectPath+ "\\Data\\" + TenFile + time+".bak'");
                SqlCommand command = new SqlCommand(sql, con);
                //command.CommandText = sql1;
                command.ExecuteNonQuery();
                if (con.State == ConnectionState.Open)
                    con.Close();
                return true;

            }
            catch (SqlException ex)
            {
                return false;
            }

        }

        public DataTable LayDSFileBackup()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("FileName", typeof(string));
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string sql = string.Format(@"EXEC xp_dirtree '{0}\Data\', 1, 1", ProjectPath); 
                SqlCommand command = new SqlCommand(sql, con);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["subdirectory"].ToString().IndexOf(".bak") > 0)
                    {
                        DataRow r = dt.NewRow();
                        r["FileName"] = dr["subdirectory"];
                        dt.Rows.Add(r);
                    }
                };
                if (con.State == ConnectionState.Open)
                    con.Close();

            }
            
            catch (SqlException ex)
            {
            }
            return dt;
        }

        public bool PhucHoi(string DuongDan)
        {
            int kq = 0;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string sql1 = string.Format("Use master; ALTER DATABASE QL_THIETBI SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                SqlCommand cmd1 = new SqlCommand(sql1,con);
                int kq1 = cmd1.ExecuteNonQuery();
                if (con.State == ConnectionState.Open)
                    con.Close();

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string sql = string.Format("Use master; RESTORE DATABASE QL_THIETBI FROM DISK = '" + DuongDan + "' WITH REPLACE");
                SqlCommand cmd = new SqlCommand(sql, con);
                kq = cmd.ExecuteNonQuery();
                if (con.State == ConnectionState.Open)
                    con.Close();

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string sql2 = string.Format("Use master; ALTER DATABASE QL_THIETBI SET MULTI_USER WITH ROLLBACK IMMEDIATE");
                SqlCommand cmd2 = new SqlCommand(sql2, con);
                int kq2 = cmd2.ExecuteNonQuery();
                if (con.State == ConnectionState.Open)
                    con.Close();
                return true;
            }
            catch (SqlException ex)
            {
                return false;
            }
        }


        public XuLyDB()
        {
            //string sql = @"server=NITRO5; database=QLSV; User ID=sa; Password=123456";
            string sql = @"Data Source=NITRO5; Initial Catalog=QL_THIETBI; Integrated Security =false; User ID=sa; Password=123";
            //string sql = ast.getConnectionString("QLSINHVIENConnectionString");
            con = new SqlConnection(sql);
        }
        public bool test_Connection(string connectionstring)
        {
            try
            {   // thành công
                con = new SqlConnection(connectionstring);
                con.Open();
                con.Close();
                return true;
            }
            catch(SqlException ex)
            {
                return false;
            }
        }
        public XuLyDB(string serverName, string dbName, bool auth,string uid,string pass)
        {
            string sql;
            if(auth)//win auth
                sql = string.Format(@"Data Source={0}; Initial Catalog={1}; Integrated Security =true;",serverName,dbName);
            else sql = string.Format(@"Data Source={0}; Initial Catalog={1}; Integrated Security =false; User ID={2}; Password={3}", serverName, dbName, uid,pass);
            
            con = new SqlConnection(sql);
        }
        //đọc dữ liệu
        public DataTable LayDL(string lenhsql, string tableName)
        {
            da = new SqlDataAdapter(lenhsql, con);
            da.Fill(ds, tableName);
            return ds.Tables[tableName];
        }
        //đọc dl bằng datatable
        public DataTable LayDLDataTable(string lenhsql)
        {
            da = new SqlDataAdapter(lenhsql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        //cập nhật cả bảng xuống db
        public void UpdateDB(DataTable dt)
        {
            SqlCommandBuilder scb = new SqlCommandBuilder(da);
            da.Update(dt);//or  da.Update(ds,"KHOA");
        }
        //cập nhật cả bảng xuống db c2
        public void UpdateDB2(string lenhsql, DataTable dt)
        {
            da = new SqlDataAdapter(lenhsql, con);
            SqlCommandBuilder scb = new SqlCommandBuilder(da);
            da.Update(dt);//or  da.Update(ds,"KHOA");
        }
        //thêm/xóa/sửa 1 dòng
        public bool ThemXoaSua(string sql)
        {
            

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand command = new SqlCommand(sql,con);
                //command.CommandText = sql1;
                command.ExecuteNonQuery();
                if (con.State == ConnectionState.Open)
                    con.Close();
                return true;
                
            }
            catch (SqlException ex) 
            {
                return false;
            }
            
        }
        
        public bool checkTonTai(string lenhSQLSelect)
        {
            int dem = 0;

            if (con.State == ConnectionState.Closed)
                con.Open();

            cmd = new SqlCommand(lenhSQLSelect.Trim(), con);
            SqlDataReader dr = cmd.ExecuteReader();//read data
            while (dr.Read())
            {
                dem++;
            }
            dr.Close();
            if (con.State == ConnectionState.Open)
                con.Close();
            if (dem > 0) return true;
            else return false;
        }

        //đọc dl bằng datatable
        public string LayDL(string lenhsql)
        {
            da = new SqlDataAdapter(lenhsql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
                return dt.Rows[0][0].ToString();
            return "";
        }
    }
}
