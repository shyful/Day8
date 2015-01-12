using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversityApp
{
    public partial class MenuUi : Form
    {
        public MenuUi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EntryUI aEntryUi=new EntryUI();
            aEntryUi.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StudentSearch aStudentSearch=new StudentSearch();
            aStudentSearch.Show();
        }
    }
}
