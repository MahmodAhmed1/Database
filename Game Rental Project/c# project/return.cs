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
    public partial class Return : Form
    {
        public Return()
        {
            InitializeComponent();
            
        }

        private void Return_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gameRentalDataSet.game' table. You can move, or remove it, as needed.
            this.gameTableAdapter.Fill(this.gameRentalDataSet.game);
            // TODO: This line of code loads data into the 'gameRentalDataSet1.rent' table. You can move, or remove it, as needed.
            this.rentTableAdapter1.Fill(this.gameRentalDataSet1.rent);
            // TODO: This line of code loads data into the 'gameRentalDataSet.rent' table. You can move, or remove it, as needed.
            this.rentTableAdapter.Fill(this.gameRentalDataSet.rent);
           /* SqlConnection sqlConnection = new SqlConnection("Data Source=WIN-MEVUK5IVNVJ;Initial Catalog=gameRental;Integrated Security=True");
            string query = "select name,year,category from game where ID_game = (select ID_game from rent where ID_game = " + textBox2.Text + ")";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlConnection);
            DataTable dtbl = new DataTable("search");
            sda.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            dataGridView1.Show();*/

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection Conn = new SqlConnection("Data Source=WIN-MEVUK5IVNVJ;Initial Catalog=gameRental;Integrated Security=True");
            SqlCommand Comm1 = new SqlCommand("select * from game where ID_game=(select ID_game from rent where ID_game="+textBox2.Text+")"  + "", Conn);
            Conn.Open();
            SqlDataReader DR1 = Comm1.ExecuteReader();
            if (DR1.Read())
            {
                label3.Text = DR1.GetValue(4).ToString();
                label4.Text = DR1.GetValue(5).ToString();
                label5.Text = DR1.GetValue(6).ToString();
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin admin = new Admin();
            admin.Size = new Size(1500, 900);
            admin.Show();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=WIN-MEVUK5IVNVJ;Initial Catalog=gameRental;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            sqlCommand.CommandText = "insert into [return] values (" + main.userId + ",(select vendor_ID from game where ID_game=" + textBox2.Text + ")," + textBox2.Text + ",'" + DateTime.Now.ToString("yyyy-MM-dd") + "')";
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            label6.Show();
            await Task.Delay(2000);
            label6.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
