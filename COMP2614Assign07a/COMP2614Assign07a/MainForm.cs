using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLibrary.Business;
using BusinessLibrary.Common;
using BusinessLibrary;
using BusinessLibrary.Data;

namespace COMP2614Assign07a
{
    public partial class MainForm : Form
    {
        private CustomerViewModel customerVM;
     
        public MainForm()
        {
            InitializeComponent();
           CustomerCollection newTotal = CustomerRepository.GetCustomers();

            labelTotalYTDSalesOW.Text = newTotal.TotalYTDSalesOW.ToString();
            labelCreditHoldCountOW.Text = newTotal.CreditHoldCountOW.ToString();
            labelCustomerCount.Text = newTotal.CustomerCountOW.ToString();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            customerVM = new CustomerViewModel();
            setBindings();
            setupDataGridView();
        }

        private void setBindings()
        {



            dataGridViewCustomers.AutoGenerateColumns = false;
            dataGridViewCustomers.DataSource = customerVM.Customers;


        }

        private void setupDataGridView()
        {
            dataGridViewCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCustomers.MultiSelect = false;
            dataGridViewCustomers.AllowUserToAddRows = false;
            dataGridViewCustomers.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridViewCustomers.AllowUserToOrderColumns = false;
            dataGridViewCustomers.AllowUserToResizeColumns = false;
            dataGridViewCustomers.AllowUserToResizeRows = false;
            dataGridViewCustomers.ColumnHeadersDefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);

            DataGridViewTextBoxColumn customerCode = new DataGridViewTextBoxColumn();
            customerCode.Name = "customerCode";
            customerCode.DataPropertyName = "CustomerCode";
            customerCode.HeaderText = "CustomerCode";
            customerCode.Width = 90;
            customerCode.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewCustomers.Columns.Add(customerCode);

            DataGridViewTextBoxColumn companyName = new DataGridViewTextBoxColumn();
            companyName.Name = "companyName";
            companyName.DataPropertyName = "CompanyName";
            companyName.HeaderText = "CompanyName";
            companyName.Width = 90;
            companyName.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewCustomers.Columns.Add(companyName);

            DataGridViewTextBoxColumn address = new DataGridViewTextBoxColumn();
            address.Name = "address";
            address.DataPropertyName = "Address";
            address.HeaderText = "Address";
            address.Width = 90;
            address.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewCustomers.Columns.Add(address);

            DataGridViewTextBoxColumn address2 = new DataGridViewTextBoxColumn();
            address2.Name = "address2";
            address2.DataPropertyName = "Address2";
            address2.HeaderText = "Address2";
            address2.Width = 90;
            address2.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewCustomers.Columns.Add(address2);

            DataGridViewTextBoxColumn city = new DataGridViewTextBoxColumn();
            city.Name = "city";
            city.DataPropertyName = "City";
            city.HeaderText = "City";
            city.Width = 90;
            city.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewCustomers.Columns.Add(city);

            DataGridViewTextBoxColumn province = new DataGridViewTextBoxColumn();
            province.Name = "province";
            province.DataPropertyName = "Province";
            province.HeaderText = "Province";
            province.Width = 90;
            province.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewCustomers.Columns.Add(province);

            DataGridViewTextBoxColumn postalCode = new DataGridViewTextBoxColumn();
            postalCode.Name = "postalCode";
            postalCode.DataPropertyName = "PostalCode";
            postalCode.HeaderText = "PostalCode";
            postalCode.Width = 90;
            postalCode.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewCustomers.Columns.Add(postalCode);

            DataGridViewTextBoxColumn ytdSales = new DataGridViewTextBoxColumn();
            ytdSales.Name = "ytdSales";
            ytdSales.DataPropertyName = "YTDSales";
            ytdSales.HeaderText = "YTDSales";
            ytdSales.Width = 90;
            ytdSales.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            ytdSales.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ytdSales.DefaultCellStyle.Format = "N2";
            ytdSales.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewCustomers.Columns.Add(ytdSales);

            DataGridViewCheckBoxColumn creditHold = new DataGridViewCheckBoxColumn();
            creditHold.Name = "creditHold";
            creditHold.DataPropertyName = "CreditHold";
            creditHold.HeaderText = "CreditHold";
            creditHold.Width = 70;
            creditHold.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewCustomers.Columns.Add(creditHold);

            DataGridViewTextBoxColumn notes = new DataGridViewTextBoxColumn();
            notes.Name = "notes";
            notes.DataPropertyName = "Notes";
            notes.HeaderText = "Notes";
            notes.Width = 90;
            notes.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewCustomers.Columns.Add(notes);
        }

        private void dataGridViewCustomers_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int index = dataGridViewCustomers.CurrentRow.Index;

                Customer customer = customerVM.Customers[index];
                customerVM.SetDisplayCustomer(customer);
            }
            catch (Exception)
            {
                
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int index = dataGridViewCustomers.CurrentRow.Index;

            Customer customer = customerVM.GetDisplayCustomer();
            customerVM.Customers[index] = customer;
            customerVM.Customers.ResetItem(index);

            //string outputLegend = string.Format("{0}\r\n{1}\r\n{2}\r\n{3}\r\n{4}\r\n{5}\r\n{6}\r\n{7}\r\n{8}\r\n{9}\r\n"
            //                             , "CustomerCode:"
            //                             , "CompanyName:"
            //                             , "Address:"
            //                             , "Address2:"
            //                             , "City:"
            //                             , "Province:"
            //                             , "PostalCode:"
            //                             , "YTDSales:"
            //                             , "Notes:"
            //                             , "CreditHold:");

            //string outputData = string.Format("{0}\r\n{1}\r\n{2}\r\n{3}\r\n{4}\r\n{5}\r\n{6}\r\n{7}\r\n{8}\r\n{9}\r\n"
            //                 , customer.CustomerCode
            //                 , customer.CompanyName
            //                 , customer.Address
            //                 , customer.Address2
            //                 , customer.City
            //                 , customer.Province
            //                 , customer.PostalCode
            //                 , customer.YTDSales
            //                 , customer.Notes
            //                 , customer.CreditHold);

            //labelCustomerLegend.Text = outputLegend;
            //labelCustomerData.Text = outputData;
        }

   
        private void LabelCustomerLegend_Click(object sender, EventArgs e)
        {

        }
        private void LabelCustomerData_Click(object sender, EventArgs e)
        {

        }

        private void buttonEditRecord_Click(object sender, EventArgs e)
        {
            int index = dataGridViewCustomers.CurrentRow.Index;
            Customer customer = customerVM.GetDisplayCustomer();
            
            EditDialog dialog = new EditDialog();
            dialog.CustomerVM.Customer = customer;
            dialog.CustomerVM.DeleteBoxChecked = checkBoxDelete.Checked;

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                customerVM = new CustomerViewModel();
                setBindings();
                setupDataGridView();
            }
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }
    }
}
