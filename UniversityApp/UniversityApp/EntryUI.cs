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

namespace UniversityApp
{
    public partial class EntryUI : Form
    {
        public EntryUI()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //take user input
            string name = nametextBox.Text;
            string emailaddress = emailaddresstextBox.Text;
             string address = addresstextBox.Text;
            string phone = phonenotextBox.Text;
            //connect with database
            string connectionstring = "Data Source=(local)\\sqlexpress;Database=universityDb;Integrated Security=true";
            //1.connection 
            SqlConnection connection=new SqlConnection(connectionstring);
            connection.Open();

            //insert data into database
            string query = "insert into tStudents values ('" + name + "','" + emailaddress + "','" + address + "','" +
                           phone + "')";
            SqlCommand command = new SqlCommand(query, connection);
            int rowaffected=command.ExecuteNonQuery();
            connection.Close();
            if (rowaffected>0)
            {
                MessageBox.Show("Data has saved successfully");
            }
            else
            {
                MessageBox.Show("Couldn't save data");
            }
           nametextBox.Clear();
           emailaddresstextBox.Clear();
           addresstextBox.Clear();
          phonenotextBox.Clear();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
