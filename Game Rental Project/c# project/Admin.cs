using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeect
{
    public partial class Admin : Form
    {
        public Admin()
        {
            
            InitializeComponent();
            
            if (SignUp.type == 1)
            {
                button2.Show();
                button4.Show();
                label2.Text = main.email;
                label2.Show();
            }
            else {
                label2.Text = main.email;
                label2.Show();
            }
            


        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            updateDetails admin = new updateDetails();
            admin.Size = new Size(1500, 900);
            admin.Show();
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Browse admin = new Browse();
            admin.Size = new Size(1500, 900);
            admin.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            addGame admin= new addGame();
            admin.Size = new Size(1500, 900);
            admin.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            updateGame admin = new updateGame();
            admin.Size = new Size(1500, 900);
            admin.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            search admin = new search();
            admin.Size = new Size(1500, 900);
            admin.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            main Main= new main();
            Main.Size = new Size(1500, 900);
            Main.Show();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Rent Main = new Rent();
            Main.Size = new Size(1500, 900);
            Main.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Rent Main = new Rent();
            Main.Size = new Size(1500, 900);
            Main.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Admin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gameRentalDataSet.game' table. You can move, or remove it, as needed.
            this.gameTableAdapter.Fill(this.gameRentalDataSet.game);
           

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Return Main = new Return();
            Main.Size = new Size(1500, 900);
            Main.Show();
        }
    }
}
