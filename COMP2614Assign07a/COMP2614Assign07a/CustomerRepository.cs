using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2614Assign07a
{
    public class CustomerRepository
    {
        private static readonly string connString = @"Server=tcp:skeena.database.windows.net,1433; 
                                                      Initial Catalog=comp2614;
                                                      User ID=student;
                                                      Password=93nu5/nrCKX;
                                                      Encrypt=True;
                                                      TrustServerCertificate=False;
                                                      Connection Timeout=30;";

        public static CustomerCollection GetAllCustomers()
        {

            CustomerCollection customers;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                //string query = $"SELECT CustomerCode, CompanyName, Address, City, Province, PostalCode, CreditHold From Customer";
                string query = $"SELECT ClientCode, CompanyName, Address1, Address2, City, Province, PostalCode, YTDSales, CreditHold, Notes From Client123456";
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Connection = conn;

                    conn.Open();
                    customers = new CustomerCollection();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        string customerCode = null;
                        string companyName = null;
                        string address = null;
                        string address2 = null;
                        string city = null;
                        string province = null;
                        string postalCode = null;
                        decimal ytdSales = 0.0m;
                        bool creditHold = false;
                        string notes = null;

                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                            {
                                customerCode = reader["ClientCode"] as string;
                            }

                            if (!reader.IsDBNull(1))
                            {
                                companyName = reader["CompanyName"] as string;
                            }

                            if (!reader.IsDBNull(2))
                            {
                                address = reader["Address1"] as string;
                            }

                            if (!reader.IsDBNull(3))
                            {
                                address2 = reader["Address2"] as string;
                            }

                            if (!reader.IsDBNull(4))
                            {
                                city = reader["City"] as string;
                            }

                            if (!reader.IsDBNull(5))
                            {
                                province = reader["Province"] as string;
                            }

                            if (!reader.IsDBNull(6))
                            {
                                postalCode = reader["PostalCode"] as string;
                            }
                            if (!reader.IsDBNull(7))
                            {
                                ytdSales = (decimal)reader["YTDSales"];
                            }

                            if (!reader.IsDBNull(8))
                            {
                                creditHold = (bool)reader["CreditHold"];
                            }

                            if (!reader.IsDBNull(9))
                            {
                                notes = reader["Notes"] as string;
                            }

                            customers.Add(new Customer { CustomerCode = customerCode, CompanyName = companyName, Address = address, Address2 = address2, City = city,
                                Province = province, PostalCode = postalCode, YTDSales = ytdSales, CreditHold = creditHold, Notes = notes });
                       

                            customerCode = null;
                            companyName = null;
                            address = null;
                            address2 = null;
                            city = null;
                            province = null;
                            postalCode = null;
                            ytdSales = 0.0m;
                            creditHold = false;
                            notes = null;
                        }
                    }
                }
                return customers;
            }
        }
    }
}
