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
    public partial class main : Form
    {
        
        public main()
        {
            InitializeComponent();
           
            
        }
        public static int userId = -1;
        public static string email = "";
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gameRentalDataSet.admin' table. You can move, or remove it, as needed.
            this.adminTableAdapter.Fill(this.gameRentalDataSet.admin);
            SqlConnection sqlconnection = new SqlConnection("Data Source=WIN-MEVUK5IVNVJ;Initial Catalog=gameRental;Integrated Security=True");
            SqlCommand sqlcommand = new SqlCommand();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public static int id = -1;
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUp signUp = new SignUp();
          
            signUp.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection Conn = new SqlConnection("Data Source=WIN-MEVUK5IVNVJ;Initial Catalog=gameRental;Integrated Security=True");
            SqlCommand Comm1 = new SqlCommand("select * from admin where email='" + textBox1.Text + "'and password='" + textBox2.Text + "'", Conn);
            Conn.Open();
            SqlDataReader DR1 = Comm1.ExecuteReader();
            if (DR1.Read())
            {
                string id = DR1.GetValue(0).ToString();
                main.userId = Convert.ToInt32(id);
                SignUp.type = 1;
                this.Hide();
                Admin admin = new Admin();
                admin.Size = new Size(1500, 900);
                admin.Show();
                email = textBox1.Text;
                return;

            }
            Conn.Close();

           
            SqlConnection Conn1 = new SqlConnection("Data Source=WIN-MEVUK5IVNVJ;Initial Catalog=gameRental;Integrated Security=True");
            SqlCommand Comm11 = new SqlCommand("select * from client where email='" + textBox1.Text + "'and password='" + textBox2.Text + "'", Conn1);
            Conn1.Open();
            SqlDataReader DR11 = Comm11.ExecuteReader();
            if (DR11.Read())
            {
                string id = DR11.GetValue(0).ToString();
                main.userId = Convert.ToInt32(id);
                SignUp.type = 0;
                this.Hide();
                Admin admin = new Admin();
                admin.Size = new Size(1500, 900);
                admin.Show();
                email = textBox1.Text;
                return;

            }
            Conn.Close();


            label7.Text = "Enter Correct Data";
            label7.Show();
            label3.Text = "Enter Correct Data";
            label3.Show();
            return;
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            sql Main = new sql();
            Main.Size = new Size(1500, 900);
            Main.Show();
        }
    }
}
