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
    public partial class addGame : Form
    {
        public addGame()
        {
            InitializeComponent();
        }
        public static Int32 Vcount = 0;
        private async void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {

                label8.Text = "you Should Fill all * Fields";
                label8.Show();

                return;
            }
            SqlConnection conn = new SqlConnection("Data Source=WIN-MEVUK5IVNVJ;Initial Catalog=gameRental;Integrated Security=True");
            SqlCommand comm = new SqlCommand("SELECT COUNT(*) FROM vendor", conn);
            conn.Open();
            Vcount = (Int32)comm.ExecuteScalar();
            conn.Close();
            SqlConnection sqlConnection = new SqlConnection("Data Source=WIN-MEVUK5IVNVJ;Initial Catalog=gameRental;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            sqlCommand.CommandText = " insert into vendor Values(" + Vcount + ",'" + textBox1.Text + "')";
            Vcount++;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            label6.Show();
            await Task.Delay(500);
            label6.Hide();
            this.Hide();
            addGame admin = new addGame();
            admin.Size = new Size(1500, 900);
            admin.Show();

        }
        private async void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                label8.Text = "you Should Fill All Fields";
                label8.Show();
                
                return;
            }


            SqlConnection conn = new SqlConnection("Data Source=WIN-MEVUK5IVNVJ;Initial Catalog=gameRental;Integrated Security=True");
            conn.Open();
            SqlCommand comm = new SqlCommand("SELECT COUNT(*) FROM game", conn);
            Int32 count = (Int32)comm.ExecuteScalar();
            SqlConnection sqlConnection = new SqlConnection("Data Source=WIN-MEVUK5IVNVJ;Initial Catalog=gameRental;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            sqlCommand.CommandText = " insert into game values((select vendor_ID from vendor where name = '"+textBox2.Text+"') ,"+count+"," +main.userId+","+main.userId+",'"+textBox6.Text+"','"+textBox3.Text+"','"+textBox4.Text+"','"+textBox5.Text+ "')";
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
           

            label6.Show();
            await Task.Delay(2000);
            label6.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin admin= new Admin();
            admin.Size = new Size(1500, 900);
            admin.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void addGame_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gameRentalDataSet.vendor' table. You can move, or remove it, as needed.
            this.vendorTableAdapter.Fill(this.gameRentalDataSet.vendor);

        }
    }
}
