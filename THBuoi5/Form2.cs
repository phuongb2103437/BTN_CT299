using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THBuoi5
{
    public partial class Form2 : Form
    {
        public SqlConnection conn = new SqlConnection();
        public Form2()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string nv = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            comboBox_NV.Text = nv;
            comboBox_PB.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            comboBox_CV.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            comboBox_Thang.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox_CV.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox_SN.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            comboBox_Nam.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            //pictureBox1.Image = new Bitmap(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Function f = new Function();
            f.Ketnoi(conn);
            f.HienThiDataGridView(dataGridView1, "select * from CHAMCONG", conn);
        }

        private void button4_Click(object sender, EventArgs e)// Dat Lai
        {
            comboBox_NV.Enabled = false;
            string sql_manv = "select max(substring(manv,3,len(manv) - 1)) from NHANVIEN";
            SqlCommand comd = new SqlCommand(sql_manv, conn);
            SqlDataReader reader = comd.ExecuteReader();
            if (reader.Read())
            {
                int manv_tt = Convert.ToInt32(reader.GetValue(0).ToString()) + 1;
                if (manv_tt < 10)
                    comboBox_NV.Text = "NV00" + manv_tt.ToString();
                else if (manv_tt < 100)
                    comboBox_NV.Text = "NV0" + manv_tt.ToString();
                else
                    comboBox_NV.Text = "NV" + manv_tt.ToString();
            }
            reader.Close();

            textBox_HoTen.Text = "";
            textBox_NgaySinh.Text = "";
            textBox_QueQuan.Text = "";
            textBox_SDT.Text = "";
            textBox_MPB.Text = "";

        }
    }
}
