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
    public partial class EditDialog : Form
    {
        public Customer Customer { get; set; }

        public CustomerViewModel CustomerVM { get; set; }

        public EditDialog()
        {
            CustomerVM = new CustomerViewModel();
            InitializeComponent();
        }

        private void EditDialog_Load(object sender, EventArgs e)
        {
            try
            {
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
            textBoxCustomerCode.DataBindings.Add("Text", CustomerVM, "Customer.CustomerCode", false, DataSourceUpdateMode.OnValidation, "");
            textBoxCompanyName.DataBindings.Add("Text", CustomerVM, "Customer.CompanyName", false, DataSourceUpdateMode.OnValidation, "");
            textBoxAddress.DataBindings.Add("Text", CustomerVM, "Customer.Address", false, DataSourceUpdateMode.OnValidation, "");
            textBoxAddress2.DataBindings.Add("Text", CustomerVM, "Customer.Address2", false, DataSourceUpdateMode.OnValidation, "");
            textBoxCity.DataBindings.Add("Text", CustomerVM, "Customer.City", false, DataSourceUpdateMode.OnValidation, "");
            textBoxProvince.DataBindings.Add("Text", CustomerVM, "Customer.Province", false, DataSourceUpdateMode.OnValidation, "");
            textBoxPostalCode.DataBindings.Add("Text", CustomerVM, "Customer.PostalCode", false, DataSourceUpdateMode.OnValidation, "");
            textBoxNotes.DataBindings.Add("Text", CustomerVM, "Customer.Notes", false, DataSourceUpdateMode.OnValidation, "");
            textBoxYTDSales.DataBindings.Add("Text", CustomerVM, "Customer.YTDSales", true, DataSourceUpdateMode.OnValidation, "0.00", "#,##0.00;(#,##0.00);0.00");
            checkBoxCreditHold.DataBindings.Add("Checked", CustomerVM, "Customer.CreditHold");

            labelCustomerLegend.Text = string.Empty;
            labelCustomerData.Text = string.Empty;
            labelProvince.Text = string.Empty;
        }

     
        private void buttonSave_Click(object sender, EventArgs e)
        {

            // get the customer from the database using the clientcode
           
     

            int? customerCodeStringLength = CustomerVM.Customer.CustomerCode?.Length;
            int? customerCompanyNameStringLength = CustomerVM.Customer.CompanyName?.Length;
            int? customerAddressStringLength = CustomerVM.Customer.Address?.Length;
            int? customerAddress2StringLength = CustomerVM.Customer.Address2?.Length;
            int? customerCityStringLength = CustomerVM.Customer.City?.Length;
            int? customerProvinceStringLength = CustomerVM.Customer.Province?.Length;
            int? customerPostalCodeStringLength = CustomerVM.Customer.PostalCode?.Length;
            //int customerYTDSalesStringLength = CustomerVM.Customer.YTDSales.Length;
            //int customerPostalCodeStringLength = CustomerVM.Customer.PostalCode.Length;


            try
            {
                if (customerCodeStringLength.GetValueOrDefault(0) < 5)
                {
                    errorProvider.SetError(buttonSave, "Validate");
                    MessageBox.Show(CustomerValidation.ErrorMessage, "Customer Code needs to be longer has been updated.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                if (customerCompanyNameStringLength <= 0)
                {
                    errorProvider.SetError(buttonSave, "Validate");
                    MessageBox.Show(CustomerValidation.ErrorMessage, "Company Name needs to be longer.", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                if (customerAddressStringLength < 4)
                {
                    errorProvider.SetError(buttonSave, "Validate");
                }
                else
                {
                    MessageBox.Show(CustomerValidation.ErrorMessage, "Address needs to be long.", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                if (customerAddress2StringLength < 2)
                {
                    errorProvider.SetError(buttonSave, "Validate");
                }
                else
                {
                    MessageBox.Show(CustomerValidation.ErrorMessage, "Address2 needs to be long.", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                if (customerCityStringLength < 3)
                {
                    errorProvider.SetError(buttonSave, "Validate");
                }
                else
                {
                    MessageBox.Show(CustomerValidation.ErrorMessage, "City needs to be longer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (customerProvinceStringLength < 2)
                {
                    errorProvider.SetError(buttonSave, "Validate");
                }
                else
                {
                    MessageBox.Show(CustomerValidation.ErrorMessage, "Province needs to be longer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (customerPostalCodeStringLength < 8)
                {
                    errorProvider.SetError(buttonSave, "Validate");
                }
                else
                {
                    MessageBox.Show(CustomerValidation.ErrorMessage, "Customer postal code needs to be longer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                bool isExistedCustomer = CustomerRepository.VerifyIfCustomerExist(CustomerVM.Customer.CustomerCode);

                if (isExistedCustomer)
                {
                    CustomerRepository.UpdateCustomer(CustomerVM.Customer);
                    MessageBox.Show($"Customer {CustomerVM.Customer.CustomerCode} has been updated.");
                }
                else
                {
                    CustomerRepository.AddCustomer(CustomerVM.Customer);
                    MessageBox.Show($"Customer {CustomerVM.Customer.CustomerCode} has been created.");
                }

            }



            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Processing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DialogResult = DialogResult.OK;
            this.Dispose();


        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonNewCustomer_Click(object sender, EventArgs e)
        {
            CustomerVM.SetDisplayCustomer(new Customer());
            textBoxCustomerCode.Select();
            textBoxCustomerCode.SelectAll();
        }

        private void labelCustomerData_Click(object sender, EventArgs e)
        {

        }

  
        private void LabelCustomerLegend_Click(object sender, EventArgs e)
        {

        }

        private void ButtonDeleteCustomer_Click_1(object sender, EventArgs e)
        {
            if (CustomerRepository.DeleteProduct(CustomerVM.Customer))
            {
                MessageBox.Show($"Customer {CustomerVM.Customer.CustomerCode} has been deleted.");
            }
            else
            {
                MessageBox.Show("Bye");
            }

            DialogResult = DialogResult.OK;
        }
    }
}
