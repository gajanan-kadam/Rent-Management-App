using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Rent_Management_App
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\android-aac3asd323ew\Documents\FlatData.mdf;Integrated Security=True;Connect Timeout=30");
        private void gunaButton2_Click(object sender, EventArgs e)
        {
            gunaTextBox1.Clear();
            gunaTextBox2.Clear();
            con.Close();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "insert into admin values('" + gunaTextBox1.Text + "','" + gunaTextBox2.Text + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("ADMIN ADDED SUCCESSFULLT");
                con.Close();

            }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void gunaLabel4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
