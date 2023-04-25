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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        public static int type = -1;
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text))
            {
                label7.Text = "you Should Fill This Field";
                label7.Show();
                label8.Text = "you Should Fill This Field";
                label8.Show();
                label9.Text = "you Should Fill This Field";
                label9.Show();
                return;
            }

            if (radioButton1.Checked == true)
                {
                SqlConnection conn = new SqlConnection("Data Source=WIN-MEVUK5IVNVJ;Initial Catalog=gameRental;Integrated Security=True");
                conn.Open();
                SqlCommand comm = new SqlCommand("SELECT COUNT(*) FROM admin", conn);
                Int32 count = (Int32)comm.ExecuteScalar();
                
                SqlConnection sqlConnection = new SqlConnection("Data Source=WIN-MEVUK5IVNVJ;Initial Catalog=gameRental;Integrated Security=True");
                 SqlCommand sqlCommand = new SqlCommand();
                 sqlCommand.Connection=sqlConnection;
                 sqlConnection.Open();
                sqlCommand.CommandText = " insert into admin Values("+count+",'" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "',' " + textBox4.Text + "', '" + textBox5.Text + "')";
                 sqlCommand.ExecuteNonQuery();
                 sqlConnection.Close();
                type = 1;
                main.userId = count;
                this.Hide();
                Admin admin = new Admin();
                admin.Size = new Size(1500, 900);
                admin.Show();
                }
            
            else if (radioButton2.Checked == true) {
                SqlConnection conn = new SqlConnection("Data Source=WIN-MEVUK5IVNVJ;Initial Catalog=gameRental;Integrated Security=True");
                conn.Open();
                SqlCommand comm = new SqlCommand("SELECT COUNT(*) FROM client", conn);
                Int32 ccount = (Int32)comm.ExecuteScalar();
     
                SqlConnection sqlConnection = new SqlConnection("Data Source=WIN-MEVUK5IVNVJ;Initial Catalog=gameRental;Integrated Security=True");
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection=sqlConnection;
                sqlConnection.Open();
                sqlCommand.CommandText = " insert into client Values("+ccount +",'" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "',' " + textBox4.Text + "', '" + textBox5.Text + "')";
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                type = 0;
                main.userId = ccount;
                this.Hide();
                Admin user = new Admin();
                user.Size = new Size(1500, 900);
                user.Show();
                }
           

        }
        
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
          

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            main user = new main();
            user.Size = new Size(1500, 900);
            user.Show();
        }
    }
}
