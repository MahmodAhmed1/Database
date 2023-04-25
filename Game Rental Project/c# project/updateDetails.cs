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
    public partial class updateDetails : Form
    {
        public updateDetails()
        {
            InitializeComponent();
            if (SignUp.type == 1) { 
            SqlConnection Conn = new SqlConnection("Data Source=WIN-MEVUK5IVNVJ;Initial Catalog=gameRental;Integrated Security=True");
            SqlCommand Comm1 = new SqlCommand("select * from admin where A_ID=" +main.userId + "", Conn);
            Conn.Open();
            SqlDataReader DR1 = Comm1.ExecuteReader();
            if (DR1.Read())
            {
                textBox1.Text = DR1.GetValue(1).ToString();
                textBox2.Text = DR1.GetValue(2).ToString();
                textBox3.Text = DR1.GetValue(3).ToString();
                textBox4.Text = DR1.GetValue(4).ToString();
                textBox5.Text = DR1.GetValue(5).ToString();
            }
            Conn.Close();
            }
            else
            {
                SqlConnection Conn = new SqlConnection("Data Source=WIN-MEVUK5IVNVJ;Initial Catalog=gameRental;Integrated Security=True");
                SqlCommand Comm1 = new SqlCommand("select * from client where Client_ID=" + main.userId + "", Conn);
                Conn.Open();
                SqlDataReader DR1 = Comm1.ExecuteReader();
                if (DR1.Read())
                {
                    textBox1.Text = DR1.GetValue(1).ToString();
                    textBox2.Text = DR1.GetValue(2).ToString();
                    textBox3.Text = DR1.GetValue(3).ToString();
                    textBox4.Text = DR1.GetValue(4).ToString();
                    textBox5.Text = DR1.GetValue(5).ToString();
                }
                Conn.Close();
            }

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
            sqlCommand.CommandText = " update admin set name='" + textBox1.Text + "',phone='" + textBox2.Text + "',address='" + textBox3.Text + "',email='" + textBox4.Text + "' ,password='" + textBox5.Text + "'where A_ID=" + main.userId + "";
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin user = new Admin();
            user.Size = new Size(1500, 900);
            user.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
