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

namespace COMP2614Assign07a
{
    public partial class EditDialog : Form
    {
        public Customer Customer { get; set; }

        private CustomerViewModel customerVM;

        public EditDialog()
        {
            InitializeComponent();
        }

        private void EditDialog_Load(object sender, EventArgs e)
        {
            try
            {
                customerVM = new CustomerViewModel();
                setBindings();
            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Processing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void setBindings()
        {
            textBoxCustomerCode.DataBindings.Add("Text", customerVM, "Customer.CustomerCode", false, DataSourceUpdateMode.OnValidation, "");
            textBoxCompanyName.DataBindings.Add("Text", customerVM, "Customer.CompanyName", false, DataSourceUpdateMode.OnValidation, "");
            textBoxAddress.DataBindings.Add("Text", customerVM, "Customer.Address", false, DataSourceUpdateMode.OnValidation, "");
            textBoxAddress2.DataBindings.Add("Text", customerVM, "Customer.Address2", false, DataSourceUpdateMode.OnValidation, "");
            textBoxCity.DataBindings.Add("Text", customerVM, "Customer.City", false, DataSourceUpdateMode.OnValidation, "");
            textBoxProvince.DataBindings.Add("Text", customerVM, "Customer.Province", false, DataSourceUpdateMode.OnValidation, "");
            textBoxPostalCode.DataBindings.Add("Text", customerVM, "Customer.PostalCode", false, DataSourceUpdateMode.OnValidation, "");
            textBoxNotes.DataBindings.Add("Text", customerVM, "Customer.Notes", false, DataSourceUpdateMode.OnValidation, "");
            textBoxYTDSales.DataBindings.Add("Text", customerVM, "Customer.YTDSales", true, DataSourceUpdateMode.OnValidation, "0.00", "#,##0.00;(#,##0.00);0.00");
            checkBoxCreditHold.DataBindings.Add("Checked", customerVM, "Customer.CreditHold");

            labelCustomerLegend.Text = string.Empty;
            labelCustomerData.Text = string.Empty;
            labelProvince.Text = string.Empty;
        }

     
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (textBoxAddress.Text.Length > 2)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Something Terrrible has Happened");
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonNewCustomer_Click(object sender, EventArgs e)
        {
            customerVM.SetDisplayCustomer(new Customer());
            textBoxCustomerCode.Select();
            textBoxCustomerCode.SelectAll();
        }

        private void labelCustomerData_Click(object sender, EventArgs e)
        {

        }
    }
}
