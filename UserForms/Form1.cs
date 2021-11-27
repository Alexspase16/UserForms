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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (cb_agree.Checked)
            {
                string firstName = txt_firstName.Text;
                string lastName = txt_lastName.Text;
                string email = txt_email.Text;
                string userName = txt_userName.Text;
                string password = txt_password.Text;

                string dateOfBirth = dateTimePicker1.Value.Date.ToString("yyyy-MM-dd hh:mm:ss");

                string gender = "";

                if (rb_m.Checked)               
                    gender = rb_m.Text;

                if (rb_f.Checked)
                    gender = rb_f.Text;

                var connString = "Server=localhost;Port=3306;User id=root; Password=Vesna#12345;Persistsecurityinfo=True;Database=dbo";

                MySqlConnection conn = new MySqlConnection(connString);
                MySqlCommand command = conn.CreateCommand();

                command.CommandText = "insert into dbo.Users (FirstName, LastName, Email, DateOfBirth, DateOfBirthString, UserName, Password, Gender) value('" + firstName + "', '" + lastName + "', '" + email + "', CAST(N'"+ dateOfBirth + "' AS DateTime), '" + dateOfBirth + "', '" + userName + "', '"+ password + "', '"+ gender + "');";

                try
                {
                    conn.Open();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                command.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("The user id created.");
            }
            else
            {
                MessageBox.Show("You must first agree to the rules of this application!");
            }
        }

        private void btn_openForm2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
