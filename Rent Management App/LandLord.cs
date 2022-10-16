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
using System.Data.OleDb;

namespace Rent_Management_App
{
    public partial class LandLord : Form
    {
        public LandLord()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\android-aac3asd323ew\Documents\FlatData.mdf;Integrated Security=True;Connect Timeout=30");
        private void fillcombo()
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select name from tenant", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gunaComboBox1.DataSource = dt;
            gunaComboBox1.DisplayMember = "name";
            gunaComboBox1.ValueMember = "name";
            con.Close();
        }
        private void gunaLabel5_Click(object sender, EventArgs e)
        {

        }

        private void LandLord_Load(object sender, EventArgs e)
        {
            fillcombo();
        }

        private void gunaLabel6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlDataAdapter data = new SqlDataAdapter("select sum(amount) from rent where name='" + gunaComboBox1.Text + "'", con);
            DataTable dt = new DataTable();
            data.Fill(dt);
            gunaTextBox1.Text = dt.Rows[0][0].ToString()+" RS.";
            con.Close();
        }

        private void gunaLabel2_Click(object sender, EventArgs e)
        {
            Tenant t = new Tenant();
            t.Show();
            this.Hide();
        }

        private void gunaLabel4_Click(object sender, EventArgs e)
        {
            Rent rt = new Rent();
            rt.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
