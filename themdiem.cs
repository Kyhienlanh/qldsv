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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace quanlidiem
{
    public partial class themdiem : Form
    {
        public themdiem()
        {
            InitializeComponent();
        }
        public themdiem(string a)
        {
            InitializeComponent();
            label1.Text = a;
        }

        private void themdiem_Load(object sender, EventArgs e)
        {
           
            modify modify = new modify();
            dataGridView2.DataSource = modify.getallmahp();
            dataGridView2.Visible = false;
            modify.themdulieumh(comboBox1,label1.Text);
            label1.Hide();
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            dataGridView1.Rows.Clear();
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                if (comboBox1.Text == dataGridView2[2, i].Value.ToString())
                {
                    dataGridView1.Rows.Add(dataGridView2[0, i].Value, dataGridView2[1, i].Value, dataGridView2[2, i].Value, dataGridView2[3, i].Value, dataGridView2[4, i].Value, dataGridView2[5, i].Value, dataGridView2[6, i].Value);
                }
               
            }
        }
       

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text = comboBox1.Text.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string a = textBox1.Text;
            string b= textBox2.Text;
            float c;
            float d ;
            if (float.TryParse(textBox3.Text, out c) && float.TryParse(textBox4.Text, out d))
            {
                modify modify = new modify();
                modify.UpdateDiem(a, b, c, d);
                dataGridView2.DataSource = modify.getallmahp();
               
            }
            dataGridView1.Rows.Clear();
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                if (comboBox1.Text == dataGridView2[2, i].Value.ToString())
                {
                    dataGridView1.Rows.Add(dataGridView2[0, i].Value, dataGridView2[1, i].Value, dataGridView2[2, i].Value, dataGridView2[3, i].Value, dataGridView2[4, i].Value, dataGridView2[5, i].Value, dataGridView2[6, i].Value);
                }

            }


        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
          
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            using (SqlConnection sqlConnection = connection.GetSqlConnection())
            {
                SqlCommand command = new SqlCommand();

                string query = "SELECT * FROM Diem WHERE maMh = @a";
                sqlConnection.Open();
                command = new SqlCommand(query, sqlConnection);
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@a", comboBox1.SelectedValue.ToString());

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);

                CrystalReport3 report = new CrystalReport3();
                report.SetDataSource(table);
                XUATBAOCAO xUATBAOCAO = new XUATBAOCAO();
                xUATBAOCAO.crystalReportViewer1.ReportSource = report;
                xUATBAOCAO.ShowDialog();
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
