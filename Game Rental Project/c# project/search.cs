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

namespace projeect
{
    public partial class search : Form
    {
        public search()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=WIN-MEVUK5IVNVJ;Initial Catalog=gameRental;Integrated Security=True");
            string query = "";
            if (radioButton1.Checked == true)
            {
                 query = "select name,year,category,add_date from game where name = '"+textBox1.Text+ "'";
            }
            else if (radioButton2.Checked == true) {
                query = "select name,year,category,add_date from game where year = '" + textBox1.Text + "'";
            }
                else if (radioButton3.Checked == true) {  query = "select name,year,category,add_date from game where category = '" + textBox1.Text + "'"; }
                else if (radioButton4.Checked == true) {  query = "select name,year,category,add_date from game where vendor_ID=(select vendor_ID from vendor where name='"+textBox1.Text+"')" ; }
                else
                {
                    label3.Text = "Fill All Fields";
                    label3.Show();
                    return;
                }
                SqlDataAdapter sda = new SqlDataAdapter(query, sqlConnection);
                DataTable dtbl = new DataTable("search");
                sda.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
                dataGridView1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Hide();
            Admin user = new Admin();
            user.Size = new Size(1500, 900);
            user.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
