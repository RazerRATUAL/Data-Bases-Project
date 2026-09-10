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
using System.Data.SqlClient;

namespace ProiectBazeDeDate
{
    public partial class Login : Form
    {
        private string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\JocDB.mdf;Integrated Security=True";

        public Login()
        {
            InitializeComponent();
        }

        private void btnConectare_Click(object sender, EventArgs e)
        {
            Logare();
        }

        private void Logare()
        {
            string email = txtEmail.Text;
            string pass = txtParola.Text;

            if (!ExistaUtilizator(email, pass))
            {
                MessageBox.Show("Wrong email/password.");
                txtEmail.Text = "";
                txtParola.Text = "";
                return;
            }
            else
            {
                GameForm frm = new GameForm();
                this.Visible = false;
                frm.ShowDialog();
                Application.Exit();
            }
        }

        private bool ExistaUtilizator(string email, string pass)
        {
            string query = "SELECT COUNT(Email) FROM Utilizatori WHERE Email = @email AND Parola = @parola";
            var con = new SqlConnection(connStr);
            con.Open();
            var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("email", email);
            cmd.Parameters.AddWithValue("parola", pass);
            int x = (int)cmd.ExecuteScalar();

            con.Close();
            cmd.Dispose();
            con.Dispose();

            return x == 1;
        }

        private void txtParola_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Logare();
        }

        private void btnInregistrare_Click(object sender, EventArgs e)
        {
            Signup frm = new Signup();
            this.Visible = false;
            frm.ShowDialog();
            this.Visible = true;
        }
    }
}
