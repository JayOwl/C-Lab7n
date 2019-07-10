using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using COMP2614Assign07a.Business;
//using COMP2614Assign07a.Common;

namespace COMP2614Assign07a
{
    class CustomerViewModel : ViewModelBase
    {
        private Customer customer;

        public CustomerViewModel()
        {
            
            this.Customers = CustomerRepository.GetCustomers();
            Customer = new Customer();
        }


        public Customer Customer
        {
            get { return customer; }
            set
            {
                customer = value;
                OnPropertyChanged("Customer");
            }
        }


        public CustomerCollection Customers { get; set; }

        public void SetDisplayCustomer(Customer customer)
        {
            Customer = new Customer
            {
                CustomerCode = customer.CustomerCode,
                CompanyName = customer.CompanyName,
                Address = customer.Address,
                Address2 = customer.Address2,
                City  = customer.City,
                Province = customer.Province,
                PostalCode = customer.PostalCode,
                YTDSales = customer.YTDSales,
                CreditHold = customer.CreditHold,
                Notes = customer.Notes
            };
        }

        public Customer GetDisplayCustomer()
        {
            OnPropertyChanged("Customer");
            return Customer;
        }
    }
}
