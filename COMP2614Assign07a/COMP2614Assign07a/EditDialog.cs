using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        public EditDialog()
        {
            InitializeComponent();
        }

        private void EditDialog_Load(object sender, EventArgs e)
        {
            textBoxCustomerCode.DataBindings.Add("Text", Customer, "CustomerCode", false, DataSourceUpdateMode.OnValidation, "");
            textBoxCompanyName.DataBindings.Add("Text", Customer, "CompanyName", false, DataSourceUpdateMode.OnValidation, "");
            textBoxAddress.DataBindings.Add("Text", Customer, "Address", false, DataSourceUpdateMode.OnValidation, "");
            textBoxAddress2.DataBindings.Add("Text", Customer, "Address2", false, DataSourceUpdateMode.OnValidation, "");
            textBoxCity.DataBindings.Add("Text", Customer, "City", false, DataSourceUpdateMode.OnValidation, "");
            textBoxProvince.DataBindings.Add("Text", Customer, "Province", false, DataSourceUpdateMode.OnValidation, "");
            textBoxPostalCode.DataBindings.Add("Text", Customer, "PostalCode", false, DataSourceUpdateMode.OnValidation, "");
            textBoxNotes.DataBindings.Add("Text", Customer, "Notes", false, DataSourceUpdateMode.OnValidation, "");
            textBoxYTDSales.DataBindings.Add("Text", Customer, "YTDSales", true, DataSourceUpdateMode.OnValidation, "0.00", "#,##0.00;(#,##0.00);0.00");
            checkBoxCreditHold.DataBindings.Add("Checked", Customer, "CreditHold");

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
    }
}
