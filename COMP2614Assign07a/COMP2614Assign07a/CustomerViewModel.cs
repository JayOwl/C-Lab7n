using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace COMP2614Assign07a
{
    public class CustomerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public CustomerViewModel()
        {
            
            this.Customers = CustomerRepository.GetAllCustomers();
            this.Customer = new Customer();
        }

        private Customer customer;

        public Customer Customer
        {
            get
            {
                return this.customer;
            }
            set
            {
                this.customer = value;
                OnPropertyChanged();
            }
        }


        public CustomerCollection Customers { get; set; }

        public void SetDisplayCustomer(Customer customer)
        {
            this.Customer = new Customer
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
            return this.Customer;
        }
    }
}
