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

namespace Notes
{
    public partial class Notes : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-K90N83G;Initial Catalog=Notes;Integrated Security=True");
        
        public Notes()
        {
            InitializeComponent();
        }
        

        private void MainPage_Load(object sender, EventArgs e)
        {
            display();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into notes values('"+ TextBox.Text+"','"+ nameTXT.Text+"')";
            cmd.ExecuteNonQuery();
            conn.Close();
            nameTXT.Text = "";
            TextBox.Text = "";
            display();
            MessageBox.Show("Your note has been stored in the database!");
        }

        public void display()
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from notes";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from notes where Name='"+nameTXT.Text+"'";
            cmd.ExecuteNonQuery();
            conn.Close();
            display();
            MessageBox.Show("Your note has been deleted!");
        }

        private void View_Click(object sender, EventArgs e)
        {
            display();
        }
    }
}
