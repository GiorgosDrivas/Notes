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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-K90N83G;Initial Catalog=Notes;Integrated Security=True");

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            String username, password;

            username = UsernameTXT.Text;
            password = Password_TXT.Text;

            try
            {
                String querry = "SELECT * FROM users WHERE username ='"+UsernameTXT.Text+"' AND password = '"+Password_TXT.Text+"'";
                SqlDataAdapter sda = new SqlDataAdapter(querry, conn);

                DataTable dtable = new DataTable();

                sda.Fill(dtable);

                if(dtable.Rows.Count >0)
                {
                    username = UsernameTXT.Text;
                    password = Password_TXT.Text;

                    Notes form2 = new Notes();
                    form2.Show();
                    this.Hide();
                }

                else
                {
                    MessageBox.Show("Invalid login","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    UsernameTXT.Clear();
                    Password_TXT.Clear();

                    UsernameTXT.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally
            {
                conn.Close();
            }
        }

        private void Btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
