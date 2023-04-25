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
    public partial class sql : Form
    {
        public sql()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=WIN-MEVUK5IVNVJ;Initial Catalog=gameRental;Integrated Security=True");
            string query = "select y.name_of_game as [most rented] from(select game.Name as name_of_game, count(rent.ID_game) as num_of_games from game left outer join rent on game.ID_game = rent.ID_game group by game.Name) y where y.num_of_games = (select max(y.num_of_games) from(select game.Name as name_of_game, count(rent.ID_game) as num_of_games from game left outer join rent  on game.ID_game = rent.ID_game group by game.Name) y)";

            SqlDataAdapter sda = new SqlDataAdapter(query, sqlConnection);
            DataTable dtbl = new DataTable("a");
            sda.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            dataGridView1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=WIN-MEVUK5IVNVJ;Initial Catalog=gameRental;Integrated Security=True");
            string query = "select y.name_of_game as [not rented] from (select game.Name as name_of_game , count(rent.ID_game) as num_of_games from game left outer join rent  on game.ID_game = rent.ID_game AND rent.rent_date >= '2022-4-27' group by game.Name) y where y.num_of_games=0";

            SqlDataAdapter sda = new SqlDataAdapter(query, sqlConnection);
            DataTable dtbl = new DataTable("B");
            sda.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            dataGridView1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=WIN-MEVUK5IVNVJ;Initial Catalog=gameRental;Integrated Security=True");
            string query = "select top 1 Client.name ,COUNT(rent.Client_ID) as num_of_client from Client left outer join rent on Client.Client_ID = rent.Client_ID AND rent.rent_date >= '2022-4-27' group by Client.name order by num_of_client desc";

            SqlDataAdapter sda = new SqlDataAdapter(query, sqlConnection);
            DataTable dtbl = new DataTable("C");
            sda.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            dataGridView1.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=WIN-MEVUK5IVNVJ;Initial Catalog=gameRental;Integrated Security=True");
            string query = "select vendor.name from vendor where vendor.vendor_ID  in (select y.vendor_ID from (select vendor.vendor_ID ,COUNT(rent.vendor_ID) as max_num from rent,vendor where rent.vendor_ID = vendor.vendor_ID group by vendor.vendor_ID) y where y.max_num = (select  max(y.num_of_rent) as vendor_ID from (select rent.vendor_ID, COUNT(rent.vendor_ID) as num_of_rent from rent group by rent.vendor_ID) y))";

            SqlDataAdapter sda = new SqlDataAdapter(query, sqlConnection);
            DataTable dtbl = new DataTable("D");
            sda.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            dataGridView1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=WIN-MEVUK5IVNVJ;Initial Catalog=gameRental;Integrated Security=True");
            string query = "select y.name as vendor from(select vendor.name,count(rent.vendor_ID) as count from vendor left outer join rent  on vendor.vendor_ID = rent.vendor_ID AND rent.rent_date >= '2022-4-27' group by vendor.name) y where y.count = 0";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlConnection);
            DataTable dtbl = new DataTable("E");
            sda.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            dataGridView1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=WIN-MEVUK5IVNVJ;Initial Catalog=gameRental;Integrated Security=True");
            string query = "SELECT vendor.name FROM vendor WHERE NOT EXISTS (SELECT * FROM  game WHERE game.add_date >= '2021-5-27' AND game.vendor_ID=vendor.vendor_ID)";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlConnection);
            DataTable dtbl = new DataTable("F");
            sda.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            dataGridView1.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            main user = new main();
            user.Size = new Size(1500, 900);
            user.Show();
        }
    }
}
