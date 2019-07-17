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
using BusinessLibrary.Business;
using BusinessLibrary.Common;
using BusinessLibrary.Data;

namespace COMP2614Assign07a
{
    public partial class Delete : Form
    {

        private void Delete_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    setBindings();
            //}

            //catch (SqlException ex)
            //{
            //    MessageBox.Show(ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Processing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        public CustomerViewModel CustomerVM { get; set; }

        public Delete()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }


        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Customer {CustomerVM.Customer.CustomerCode} has been deleted.");

            if (CustomerRepository.DeleteProduct(CustomerVM.Customer))
            {
                MessageBox.Show($"Customer {CustomerVM.Customer.CustomerCode} has been deleted.");
            }
            else
            {
                MessageBox.Show("Bye");
            }

            this.Dispose();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }

   
    }
}
