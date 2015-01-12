using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace UniversityApp
{
    public partial class StudentSearch : Form
    {
        public StudentSearch()
        {
            InitializeComponent();
        }
        
        private void searchButton_Click(object sender, EventArgs e)
        {
            string inputid = idsearchtextBox.Text;
            string connectionstring = "Data Source=(local)\\sqlexpress;Database=universityDb;Integrated Security=true";
            //1.connection 
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            string query = "select * from tStudents";
            if (!string.IsNullOrEmpty(inputid))
            {
                query = "select * from tStudents where id ='" + inputid + "'";
            }
            ArrayList array=new ArrayList();
            SqlCommand command=new SqlCommand(query,connection);
            SqlDataReader reader = command.ExecuteReader();
            listView1.Items.Clear();
            while (reader.Read())
            {
             Student aStudent=new Student();
                aStudent.id = (int) reader["Id"];
                aStudent.name = reader["Name"].ToString();
                aStudent.email = reader["EmailAddress"].ToString();
                aStudent.address = reader["Address"].ToString();
                aStudent.phone = reader["PhoneNumber"].ToString();
                array.Add(aStudent);
                string[] rowStrings = { aStudent.id.ToString(),aStudent.name,aStudent.email,aStudent.address,aStudent.phone };
                var ListViewItem = new ListViewItem(rowStrings);
                listView1.Items.Add(ListViewItem);
                ListViewItem.Tag = aStudent;

            }
connection.Close();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(idlabel.Text);
            string name = nametextBox.Text;
            string emailaddress = emailaddresstextBox.Text;
            string address = addresstextBox.Text;
            string phone = phonenotextBox.Text;
            //connect with database
            string connectionstring = "Data Source=(local)\\sqlexpress;Database=universityDb;Integrated Security=true";
            //1.connection 
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();

            //insert data into database
            string query = "update  tStudents set Name= '" + name + "',EmailAddress='" + emailaddress + "',Address='" +
                           address + "',PhoneNumber='" + phone + "' where Id='" + id + "'";
            ;
            SqlCommand command = new SqlCommand(query, connection);
            int rowaffected = command.ExecuteNonQuery();
            
            if (rowaffected > 0)
            {
                MessageBox.Show("Data has saved successfully");
            }
            else
            {
                MessageBox.Show("Couldn't save data");
            }


             query = "select * from tStudents";
            ArrayList array = new ArrayList();
             command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            listView1.Items.Clear();
            while (reader.Read())
            {
                Student aStudent = new Student();
                aStudent.id = (int) reader["Id"];
                aStudent.name = reader["Name"].ToString();
                aStudent.email = reader["EmailAddress"].ToString();
                aStudent.address = reader["Address"].ToString();
                aStudent.phone = reader["PhoneNumber"].ToString();
                array.Add(aStudent);
                string[] rowStrings =
                {
                    aStudent.id.ToString(), aStudent.name, aStudent.email, aStudent.address,
                    aStudent.phone
                };
                var ListViewItem = new ListViewItem(rowStrings);
                listView1.Items.Add(ListViewItem);
                ListViewItem.Tag = aStudent;
            }
            connection.Close();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem selectedItem = listView1.SelectedItems[0];
            Student selectedStudent =(Student) selectedItem.Tag;
            idlabel.Text = selectedStudent.id.ToString();
            nametextBox.Text = selectedStudent.name;
             emailaddresstextBox.Text = selectedStudent.email; 
            addresstextBox.Text = selectedStudent.address;
           phonenotextBox.Text = selectedStudent.phone;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(idlabel.Text);
            string connectionstring = "Data Source=(local)\\sqlexpress;Database=universityDb;Integrated Security=true";
            //1.connection 
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
           
            string query = "delete from tStudents where Id= '" + id + "'";
            SqlCommand command = new SqlCommand(query, connection);
            //int rowaffected = 
            command.ExecuteNonQuery();
             query = "select * from tStudents";
            ArrayList array = new ArrayList();
             command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            listView1.Items.Clear();
            while (reader.Read())
            {
                Student aStudent = new Student();
                aStudent.id = (int) reader["Id"];
                aStudent.name = reader["Name"].ToString();
                aStudent.email = reader["EmailAddress"].ToString();
                aStudent.address = reader["Address"].ToString();
                aStudent.phone = reader["PhoneNumber"].ToString();
                array.Add(aStudent);
                string[] rowStrings =
                {
                    aStudent.id.ToString(), aStudent.name, aStudent.email, aStudent.address,
                    aStudent.phone
                };
                var ListViewItem = new ListViewItem(rowStrings);
                listView1.Items.Add(ListViewItem);
                ListViewItem.Tag = aStudent;

            }
            connection.Close();
        }

      
    }
}
