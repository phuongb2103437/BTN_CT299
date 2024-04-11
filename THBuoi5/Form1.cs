using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THBuoi5
{
    public partial class Form1 : Form
    {
        public SqlConnection conn = new SqlConnection();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Function f = new Function();
            f.Ketnoi(conn);
            f.HienThiDataGridView(dataGridView1, "select * from NHANVIEN", conn);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string nv = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox_MaNV.Text = nv;
            textBox_HoTen.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox_NgaySinh.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox_QueQuan.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox_SDT.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            pictureBox1.Image = new Bitmap(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
            textBox_MPB.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
           
        }

        private void button2_Click(object sender, EventArgs e) //Them
        {
            string nv = textBox_MaNV.Text;
            string hoten = textBox_HoTen.Text;
            string ngaysinh = textBox_NgaySinh.Text;
            string quequan = textBox_QueQuan.Text;
            string sdt = textBox_SDT.Text;
            string sql_them = "insert into NHANVIEN(manv,hoten,ngaysinh,quequan,sdt) " +
                "values('" + nv + "','N" + hoten + "','" + ngaysinh + "', 'N" + quequan + "', '" + sdt + "')";
            SqlCommand comd = new SqlCommand(sql_them, conn);
            comd.ExecuteNonQuery();

            Function Func = new Function();
            Func.HienThiDataGridView(dataGridView1, "select * from NHANVIEN", conn);
        }

        private void button6_Click(object sender, EventArgs e) //Dat Lai
        {
            textBox_MaNV.Enabled = false;
            string sql_manv = "select max(substring(manv,3,len(manv) - 1)) from NHANVIEN";
            SqlCommand comd = new SqlCommand(sql_manv, conn);
            SqlDataReader reader = comd.ExecuteReader();
            if (reader.Read())
            {
                int manv_tt = Convert.ToInt32(reader.GetValue(0).ToString()) + 1;
                if (manv_tt < 10)
                    textBox_MaNV.Text = "NV00" + manv_tt.ToString();
                else if (manv_tt < 100)
                    textBox_MaNV.Text = "NV0" + manv_tt.ToString();
                else
                    textBox_MaNV.Text = "NV" + manv_tt.ToString();
            }
            reader.Close();

            textBox_HoTen.Text = "";
            textBox_NgaySinh.Text = "";
            textBox_QueQuan.Text = "";
            textBox_SDT.Text = "";
            textBox_MPB.Text = "";
        }

        private void button3_Click(object sender, EventArgs e) //Sua
        {
            string nv = textBox_MaNV.Text;
            string hoten = textBox_HoTen.Text;
            string ngaysinh = textBox_NgaySinh.Text;
            string quequan = textBox_QueQuan.Text;
            string sdt = textBox_SDT.Text;
            string mpb = textBox_MPB.Text;
            string sql = "update nhanvien set MaNV = '" + nv + "', HoTen = N'" + hoten + "', NgaySinh = '" + ngaysinh + "',SDT = '"+ sdt +"', MPB = '"+ mpb +"' where  MaNV = '" + nv + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();

            Function Func = new Function();
            Func.HienThiDataGridView(dataGridView1, "select * from NHANVIEN", conn);
        }

        private void button4_Click(object sender, EventArgs e)// Xoa
        {
            string nv = textBox_MaNV.Text;
            string sql = "delete from nhanvien where MaNV = '" + nv + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();

            Function Func = new Function();
            Func.HienThiDataGridView(dataGridView1, "select * from NHANVIEN", conn);
        }

        private void button1_Click(object sender, EventArgs e)// Load Anh
        {
            OpenFileDialog diaglog = new OpenFileDialog();
            DialogResult result = diaglog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file_anh = diaglog.FileName;
                pictureBox1.Image = new Bitmap(file_anh);
            }
        }
    }
}
