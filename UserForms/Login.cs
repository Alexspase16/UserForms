using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserForms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button_Login_Click(object sender, EventArgs e)
        {
            LoginUser(textBox_User.Text, textBox_Pass.Text);
        }

        private void LoginUser(String username, String password)
        {
            if (username == "")
            {
                lblError.Text = "Username is required field!";
                lblError.Visible = true;
            }
            if (password == "")
            {
                lblError.Text = "Password is required field!";
                lblError.Visible = true;
            }
            if (username == "" && password == "")
            {
                lblError.Text = "Username and Password are required fields!";
                lblError.Visible = true;
            }
            if (username != "" && password != "")
            {

                var connString = "Server=localhost;Port=3306;User id=root; Password=Vesna#12345;Persistsecurityinfo=True;Database=dbo";

                MySqlConnection conn = new MySqlConnection(connString);
                MySqlCommand command = conn.CreateCommand();

                command.CommandText = "SELECT * FROM dbo.Users WHERE Username=@user and Password = @pass";

                command.CommandType = CommandType.Text;

                command.Parameters.AddWithValue("@user", username);
                command.Parameters.AddWithValue("@pass", password);

                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                MySqlDataReader rdr = command.ExecuteReader();

                if (rdr.Read())
                {
                    MessageBox.Show("Successful login!");
                    Form1 form1 = new Form1();
                    this.Hide();
                    form1.ShowDialog();
                    this.Close();
                }
                else
                    MessageBox.Show("Unsuccessful login!");
                conn.Close();
            }

        }
    }
}
