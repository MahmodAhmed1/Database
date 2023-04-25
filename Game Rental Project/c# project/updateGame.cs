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
    public partial class updateGame : Form
    {
        public updateGame()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            SqlConnection Conn = new SqlConnection("Data Source=WIN-MEVUK5IVNVJ;Initial Catalog=gameRental;Integrated Security=True");
            SqlCommand Comm1 = new SqlCommand("select * from game where ID_game=" + textBox2.Text + "", Conn);
            Conn.Open();
            SqlDataReader DR1 = Comm1.ExecuteReader();
            if (DR1.Read())
            {
                textBox6.Text = DR1.GetValue(4).ToString();
                textBox8.Text = DR1.GetValue(5).ToString();
                textBox6.Text = DR1.GetValue(4).ToString();
                textBox9.Text = DR1.GetValue(6).ToString();
                textBox7.Text = DR1.GetValue(7).ToString();

            }
            else
            {
                label1.Text = "fail input";
                label1.Show();
                panel1.Hide();
                return;
            }
            Conn.Close();

            panel1.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin admin = new Admin();
         
            admin.Show();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            label6.Show();
            await Task.Delay(2000);
            label6.Hide();

            SqlConnection sqlConnection = new SqlConnection("Data Source=WIN-MEVUK5IVNVJ;Initial Catalog=gameRental;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            sqlCommand.CommandText = " update game set name='"+textBox6.Text+ "',year=" + textBox8.Text + ",category='" + textBox9.Text + "' where ID_game=" + textBox2.Text +"";
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
