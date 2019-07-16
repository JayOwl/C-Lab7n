using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLibrary.Business;
using BusinessLibrary.Common;
using Microsoft.Build.Tasks;
using System.Windows.Forms;

namespace BusinessLibrary.Data
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

        private static readonly string customerTableName = "Client838629";


        public static int AddCustomer(Customer customer)
        {
            int rowsAffected;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = $@"INSERT INTO {customerTableName}
                                (ClientCode, CompanyName, Address1, Address2, City, Province, PostalCode, YTDSales, CreditHold, Notes)
                                VALUES (@clientcode, @companyname, @address1, @address2, @city, @province, @postalcode, @ytdsales, @credithold, @notes)";

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Connection = conn;
                   
                    cmd.Parameters.AddWithValue("@clientcode", customer.CustomerCode);                 

                    if (customer.CompanyName != null)
                    {
                        cmd.Parameters.AddWithValue("@companyname", customer.CompanyName);
                    }
                    else
                    {
                        // cmd.Parameters.AddWithValue("@companyname", "");

                        throw new ArgumentNullException("Company Cannot be null");
                        
                        //MessageBox.Show(CustomerValidation.ErrorMessage, "This cannot be empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                      // errorProvider.SetValue(); 
                    }

                    if (customer.Address != null)
                    {
                        cmd.Parameters.AddWithValue("@address1", customer.Address);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@address1", DBNull.Value);
                    }


                    if (customer.Address2 != null)
                    {
                        cmd.Parameters.AddWithValue("@address2", customer.Address2);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@address2", DBNull.Value);
                    }

                    if (customer.City != null)
                    {
                        cmd.Parameters.AddWithValue("@city", customer.City);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@city", DBNull.Value);
                    }

                    if (customer.Province != null)
                    {
                        cmd.Parameters.AddWithValue("@province", customer.Province);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@province", DBNull.Value);
                    }
                    
                    cmd.Parameters.AddWithValue("@ytdsales", customer.YTDSales);      
                    cmd.Parameters.AddWithValue("@credithold", customer.CreditHold);

                    if (customer.PostalCode != null)
                    {
                        cmd.Parameters.AddWithValue("@postalcode", customer.PostalCode);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@postalcode", DBNull.Value);
                    }                  

                    if (customer.Notes != null)
                    {
                        cmd.Parameters.AddWithValue("@notes", customer.Notes);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@notes", DBNull.Value);
                    }
                    
                    conn.Open();

                    rowsAffected = cmd.ExecuteNonQuery();
                     return rowsAffected;
                }
            }
           
        }

        public static int UpdateCustomer(Customer customer)
        {
            int rowsAffected;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = $@"UPDATE {customerTableName}
                                    SET 
                                    ClientCode = @customerCode, 
                                    CompanyName = @companyname, 
                                    Address1 = @address1, 
                                    Address2 = @address2, 
                                    City = @city , 
                                    Province = @province, 
                                    PostalCode = @postalcode, 
                                    YTDSales = @ytdsales, 
                                    CreditHold = @credithold, 
                                    Notes = @notes
                                    WHERE ClientCode = @customerCode";

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Connection = conn;

                    cmd.Parameters.AddWithValue("@customerCode", customer.CustomerCode);
                    cmd.Parameters.AddWithValue("@companyname", customer.CompanyName);
                    cmd.Parameters.AddWithValue("@address1", customer.Address);
                    cmd.Parameters.AddWithValue("@address2", customer.Address2);
                    cmd.Parameters.AddWithValue("@city", customer.City);
                    cmd.Parameters.AddWithValue("@province", customer.Province);
                    cmd.Parameters.AddWithValue("@ytdsales", customer.YTDSales);
                    cmd.Parameters.AddWithValue("@credithold", customer.CreditHold);
                    cmd.Parameters.AddWithValue("@postalcode", customer.PostalCode);
                    cmd.Parameters.AddWithValue("@notes", customer.Notes);

                    conn.Open();

                    rowsAffected = cmd.ExecuteNonQuery();
                }

            }
            return rowsAffected;
        }

        public static bool VerifyIfCustomerExist(string clientCode)
        {
            string query = $@"SELECT ClientCode, CompanyName, Address1, Address2, City, Province, PostalCode, YTDSales, CreditHold, Notes
                                FROM {customerTableName}
                                where ClientCode = '{clientCode}'";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Connection = conn;
                    conn.Open();

                    var reader = cmd.ExecuteReader();

                    var existed = reader.HasRows;

                    conn.Close();
                    return existed;
                }
            }
        }
    
        public static CustomerCollection GetCustomers()
        {
            CustomerCollection customers;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = $@"SELECT ClientCode, CompanyName, Address1, Address2, City, Province, PostalCode, YTDSales, CreditHold, Notes
                                FROM {customerTableName}
                                ORDER By ClientCode";

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Connection = conn;

                    conn.Open();

                    customers = new CustomerCollection();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        string customerCode;
                        string companyName;
                        string address;
                        string address2;
                        string city;
                        string province;
                        string postalCode;
                        decimal ytdSales;
                        bool creditHold;
                        string notes;

                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                            {
                                customerCode = reader["ClientCode"] as string;
                            }
                            else
                            {
                                customerCode = null;
                            }

                            if (!reader.IsDBNull(1))
                            {
                                companyName = reader["CompanyName"] as string;
                            }
                            else
                            {
                                companyName = null;
                            }

                            if (!reader.IsDBNull(2))
                            {
                                address = reader["Address1"] as string;
                            }
                            else
                            {
                                address = null;
                            }

                            if (!reader.IsDBNull(3))
                            {
                                address2 = reader["Address2"] as string;
                            }
                            else
                            {
                                address2 = null;
                            }

                            if (!reader.IsDBNull(4))
                            {
                                city = reader["City"] as string;
                            }
                            else
                            {
                                city = null;
                            }

                            if (!reader.IsDBNull(5))
                            {
                                province = reader["Province"] as string;
                            }
                            else
                            {
                                province = null;
                            }

                            if (!reader.IsDBNull(6))
                            {
                                postalCode = reader["PostalCode"] as string;
                            }
                            else
                            {
                                postalCode = null;
                            }

                            if (!reader.IsDBNull(7))
                            {
                                ytdSales = (decimal)reader["YTDSales"];
                            }
                            else
                            {
                                ytdSales = 0.0m;
                            }

                            if (!reader.IsDBNull(8))
                            {
                                creditHold = (bool)reader["CreditHold"];
                            }
                            else
                            {
                                creditHold = false;
                            }

                            if (!reader.IsDBNull(9))
                            {
                                notes = reader["Notes"] as string;
                            }
                            else
                            {
                                notes = null;
                            }

                            customers.Add(new Customer
                            {
                                CustomerCode = customerCode,
                                CompanyName = companyName,
                                Address = address,
                                Address2 = address2,
                                City = city,
                                Province = province,
                                PostalCode = postalCode,
                                YTDSales = ytdSales,
                                CreditHold = creditHold,
                                Notes = notes
                            });
                        }

                    }

                }

            }
            return customers;
        }


        public static bool DeleteProduct(Customer customer)
        {
            int rowsAffected;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = $@"DELETE {customerTableName}
                                WHERE ClientCode = @customerCode";

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@customerCode", customer.CustomerCode);

                    conn.Open();

                    rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }


        //public static CustomerCollection GetAllCustomers()
        //{

        //    CustomerCollection customers;

        //    using (SqlConnection conn = new SqlConnection(connString))
        //    {
        //        //string query = $"SELECT CustomerCode, CompanyName, Address, City, Province, PostalCode, CreditHold From Customer";
        //        string query = $"SELECT ClientCode, CompanyName, Address1, Address2, City, Province, PostalCode, YTDSales, CreditHold, Notes From Client838629";
        //        using (SqlCommand cmd = new SqlCommand())
        //        {
        //            cmd.CommandType = CommandType.Text;
        //            cmd.CommandText = query;
        //            cmd.Connection = conn;

        //            conn.Open();
        //            customers = new CustomerCollection();

        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                string customerCode = null;
        //                string companyName = null;
        //                string address = null;
        //                string address2 = null;
        //                string city = null;
        //                string province = null;
        //                string postalCode = null;
        //                decimal ytdSales = 0.0m;
        //                bool creditHold = false;
        //                string notes = null;

        //                while (reader.Read())
        //                {
        //                    if (!reader.IsDBNull(0))
        //                    {
        //                        customerCode = reader["ClientCode"] as string;
        //                    }

        //                    if (!reader.IsDBNull(1))
        //                    {
        //                        companyName = reader["CompanyName"] as string;
        //                    }

        //                    if (!reader.IsDBNull(2))
        //                    {
        //                        address = reader["Address1"] as string;
        //                    }

        //                    if (!reader.IsDBNull(3))
        //                    {
        //                        address2 = reader["Address2"] as string;
        //                    }

        //                    if (!reader.IsDBNull(4))
        //                    {
        //                        city = reader["City"] as string;
        //                    }

        //                    if (!reader.IsDBNull(5))
        //                    {
        //                        province = reader["Province"] as string;
        //                    }

        //                    if (!reader.IsDBNull(6))
        //                    {
        //                        postalCode = reader["PostalCode"] as string;
        //                    }
        //                    if (!reader.IsDBNull(7))
        //                    {
        //                        ytdSales = (decimal)reader["YTDSales"];
        //                    }

        //                    if (!reader.IsDBNull(8))
        //                    {
        //                        creditHold = (bool)reader["CreditHold"];
        //                    }

        //                    if (!reader.IsDBNull(9))
        //                    {
        //                        notes = reader["Notes"] as string;
        //                    }

        //                    customers.Add(new Customer { CustomerCode = customerCode, CompanyName = companyName, Address = address, Address2 = address2, City = city,
        //                        Province = province, PostalCode = postalCode, YTDSales = ytdSales, CreditHold = creditHold, Notes = notes });
                       

        //                    customerCode = null;
        //                    companyName = null;
        //                    address = null;
        //                    address2 = null;
        //                    city = null;
        //                    province = null;
        //                    postalCode = null;
        //                    ytdSales = 0.0m;
        //                    creditHold = false;
        //                    notes = null;
        //                }
        //            }
        //        }
        //        return customers;
        //    }
        //}
    }
}
