using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLibrary.Business;
using BusinessLibrary.Data;

namespace BusinessLibrary.Common
{
    public class CustomerCollection : BindingList<Customer>
    {
        public int CreditHoldCount => this.Count(x => x.CreditHold == false);

        public decimal TotalYTDSales => this.Sum(x => x.YTDSales);

        public CustomerCollection()
        {
            //var collection = CustomerRepository.GetCustomers();
            //foreach (var item in collection)
            //{
            //    Items.Add(item);
            //}
        }



        public int CreditHoldCountOW
        {
            get
            {
                int count = 0;

                foreach (Customer customer in this)
                {
                    if (customer.CreditHold == false)
                    {
                        count += 1;
                    }
                }
                return count;
            }
        }

        public int CustomerCountOW
        {
            get
            {
                int count = 0;

                foreach (Customer customer in this)
                {
                    ++count;
                }
                return count;
            }
        }

        public decimal TotalYTDSalesOW
        {
            get
            {
                decimal count = 0;

                foreach(Customer customer in this)
                {
                    count += customer.YTDSales;
                }
                return count;
            }
        }
    }

}
