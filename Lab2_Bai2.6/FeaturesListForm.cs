using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV_GUI
{
    public partial class FeaturesListForm : Form
    {
        public FeaturesListForm()
        {
            InitializeComponent();
        }

        private void FeaturesListForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnAddNewStudent_Click(object sender, EventArgs e)
        {
            AddingForm frm = new AddingForm();
            frm.Show();
        }

        private void btnSearchStudent_Click(object sender, EventArgs e)
        {
            SearchingForm frm = new SearchingForm();
            frm.Show();
        }

        private void btnDeletingStudent_Click(object sender, EventArgs e)
        {
            DeletingForm frm = new DeletingForm();
            frm.Show();
        }

        private void btnShowClassList_Click(object sender, EventArgs e)
        {
            ShowClassList frm = new ShowClassList();
            frm.Show();
        }

        private void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            UpdatingForm frm = new UpdatingForm();
            frm.Show();
        }
    }
}
