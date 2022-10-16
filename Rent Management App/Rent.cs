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
    public partial class Rent : Form
    {
        public Rent()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\android-aac3asd323ew\Documents\FlatData.mdf;Integrated Security=True;Connect Timeout=30");
        private void gunaLabel2_Click(object sender, EventArgs e)
        {
            Tenant t = new Tenant();
            this.Hide();
            t.Show();

        }
        private void fillcombo()
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT name FROM tenant", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gunaComboBox1.DataSource = dt;
            gunaComboBox1.DisplayMember = "name";
            gunaComboBox1.ValueMember = "name";
            con.Close();

        }

        private void gunaComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void gunaLabel6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Rent_Load(object sender, EventArgs e)
        {
            fillcombo();
            populate();
        }
        private void populate()
        {
            con.Open();
            string query = "select  * from rent";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            gunaDataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            try
            {
                if (gunaComboBox1.Text == "" || gunaTextBox2.Text == "") { MessageBox.Show("Invalid Input"); }
                else
                {
                    con.Open();
                    string query = "insert into rent values('" + gunaComboBox1.Text + "','" + gunaTextBox2.Text + "','" + gunaDateTimePicker1.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully Added");
                    con.Close();
                    populate();
               }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void gunaLabel3_Click(object sender, EventArgs e)
        {
            LandLord ld = new LandLord();
            ld.Show();
            this.Hide();
        }
    }
}
