using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THBuoi5
{
    internal class Function
    {
        public void Ketnoi(SqlConnection conn)
        {
            string chuoiketnoi = "SERVER = JARVIS\\TIENPHUONG; database = NHANSU; integrated security = True";
            conn.ConnectionString = chuoiketnoi;
            conn.Open();
        }

        public void HienThiDataGridView(DataGridView dg, string sql, SqlConnection conn)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "new table");
            dg.DataSource = dataSet;
            dg.DataMember = "new table";

        }

        public void LoadComb(ComboBox comb, string sql, SqlConnection conn, string hienthi, string giatri)
        {
            SqlCommand comd = new SqlCommand(sql, conn);
            SqlDataReader reader = comd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            comb.DataSource = table;
            comb.DisplayMember = hienthi;
            comb.ValueMember = giatri;
        }
        public void CapNhat(string sql, SqlConnection conn)
        {
            MessageBox.Show(sql);
            SqlCommand comd = new SqlCommand(sql, conn);
            try
            {

                comd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

