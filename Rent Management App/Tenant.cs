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
    public partial class Tenant : Form
    {
        public Tenant()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\android-aac3asd323ew\Documents\FlatData.mdf;Integrated Security=True;Connect Timeout=30");
        private void gunaLabel6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void populate()
        {
            con.Open();
            string query = "select  * from tenant";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            gunaDataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            try { 
                if(gunaTextBox1.Text=="" || gunaTextBox2.Text=="" || gunaTextBox3.Text == "") { MessageBox.Show("Invalid Input"); }
                else
                {
                    con.Open();
                    string query = "insert into tenant values('"+gunaTextBox1.Text+"','"+gunaTextBox2.Text+"','"+gunaTextBox3.Text+"','"+gunaDateTimePicker1.Text+"')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully Added");
                    con.Close();
                    populate();


                }
            }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Tenant_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void gunaLabel4_Click(object sender, EventArgs e)
        {
            Rent rt = new Rent();
            this.Hide();
            rt.Show();
        }

        private void gunaLabel3_Click(object sender, EventArgs e)
        {
            LandLord l = new LandLord();
            l.Show();
            this.Hide();
        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
