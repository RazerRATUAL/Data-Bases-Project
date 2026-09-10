using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Data.SqlClient;

namespace ProiectBazeDeDate
{
    public partial class Signup : Form
    {
        private string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\JocDB.mdf;Integrated Security=True";
        public Signup()
        {
            InitializeComponent();
        }

        private void btnRenunta_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool EmailValid(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

        private void btnSalveaza_Click(object sender, EventArgs e)
        {
            string user = txtNume.Text;

            if (user == "")
            {
                MessageBox.Show("No Name");
                return;
            }

            if (user.Length <= 4)
            {
                MessageBox.Show("Min name Lenght: 4 characters");
                return;
            }

            string pass = txtParola.Text;
            string confirm = txtConfirmParola.Text;

            if (pass == "" || confirm == "")
            {
                MessageBox.Show("No password");
                return;
            }

            if (pass != confirm)
            {
                MessageBox.Show("Not the same password");
                return;
            }

            string email = txtEmail.Text;

            if (!EmailValid(email))
            {
                MessageBox.Show("Mail invalid");
                return;
            }

            InsertUtilizator(email, user, pass);
            this.Close();
        }

        private void InsertUtilizator(string email, string user, string pass)
        {
            var con = new SqlConnection(connStr);
            con.Open();
            string query = "INSERT INTO Utilizatori VALUES (@email, @nume, @parola)";
            var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@nume", user);
            cmd.Parameters.AddWithValue("@parola", pass);
            cmd.ExecuteNonQuery();

            con.Close();
            con.Dispose();
            cmd.Dispose();
        }
    }
}
