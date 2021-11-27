using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserForms
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        int index;

        private void Form2_Load(object sender, EventArgs e)
        {
            var connString = "Server=localhost;Port=3306;User id=root; Password=Vesna#12345;Persistsecurityinfo=True;Database=dbo";

            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand command = conn.CreateCommand();

            command.CommandText = "SELECT * FROM Users";
            MySqlDataAdapter dAdapter = new MySqlDataAdapter(command);

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            DataTable dTable = new DataTable();
            //fill the DataTable
            dAdapter.Fill(dTable);

            //BindingSource to sync DataTable and DataGridView
            BindingSource bSource = new BindingSource();

            //set the BindingSource DataSource
            bSource.DataSource = dTable;

            //set the DataGridView DataSource
            dataGridView1.DataSource = bSource;

            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                index = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());

                var connString = "Server=localhost;Port=3306;User id=root;Password=Vesna#12345;persistsecurityinfo=True;database=dbo";
                MySqlConnection conn = new MySqlConnection(connString);
                MySqlCommand command = conn.CreateCommand();

                command.CommandText = "UPDATE Users SET FirstName='" + dataGridView1.SelectedRows[0].Cells[1].Value.ToString() + "', LastName='" + dataGridView1.SelectedRows[0].Cells[2].Value.ToString() + "', Email='" + dataGridView1.SelectedRows[0].Cells[3].Value.ToString() + "', DateOfBirth=CAST(N'" + DateTime.ParseExact(dataGridView1.SelectedRows[0].Cells[4].Value.ToString(), "dd.MM.yyyy hh:mm:ss" ,CultureInfo.InvariantCulture).ToString("yyyy-MM-dd") + "' AS DateTime), DateOfBirthString='" + dataGridView1.SelectedRows[0].Cells[4].Value.ToString() + "', Username='" + dataGridView1.SelectedRows[0].Cells[5].Value.ToString() + "', Password='" + dataGridView1.SelectedRows[0].Cells[6].Value.ToString() + "', Gender='" + dataGridView1.SelectedRows[0].Cells[7].Value.ToString() + "' WHERE Id = " + index + ";";

                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                command.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Успешно едитиран корисник.");
            }
            else
            {
                MessageBox.Show("Селектирајте ја редицата што сакате да ја едитирате!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                index = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());

                var connString = "Server=localhost;Port=3306;User id=root;Password=Vesna#12345;persistsecurityinfo=True;database=dbo";
                MySqlConnection conn = new MySqlConnection(connString);
                MySqlCommand command = conn.CreateCommand();

                command.CommandText = "DELETE FROM Users WHERE Id = " + index + ";";

                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                command.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Успешно избришан корисник.");
            }
            else
            {
                MessageBox.Show("Селектирајте ја редицата што сакате да ја избришете!");
            }
        }
    }
}
