using System;
using System.Data.SqlClient;
using System.Collections.Generic;

using AppKit;

namespace DrugStore
{
    public static class SqlClass
    {
        private static SqlConnectionStringBuilder GetConecctionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "azure sql adress";
            builder.UserID = "My ID";
            builder.Password = "My Password";
            builder.InitialCatalog = "DrugStoreDB";
            builder.Encrypt = false;
            return builder;
        }

        public static List<CatalogueItem> GetCollectionCatalogue()
        {
            List<CatalogueItem> a = new List<CatalogueItem>();
            using (SqlConnection connection = new SqlConnection(GetConecctionString().ConnectionString))
            {
                connection.Open();
                String sql = @"select Name, Brand, Price, Available, Description, Picture  from dbo.Goods;";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            a.Add(new CatalogueItem(reader.GetString(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetString(4), (byte[])reader.GetValue(5)));
                        }
                    }
                }
            }
            return a;
        }

        public static void AddItemToBase(CatalogueItem itemToAdd)
        {
            using (SqlConnection connection = new SqlConnection(GetConecctionString().ConnectionString))
            {
                connection.Open();
                String sql = @"insert dbo.Goods(Name, Brand, Price, Available, Description, Picture) values(@name, @brand, @price, @available, @description ,@binaryvalue);";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add("name", System.Data.SqlDbType.NVarChar).Value = itemToAdd.Name;
                    command.Parameters.Add("brand", System.Data.SqlDbType.NVarChar).Value = itemToAdd.Brand;
                    command.Parameters.Add("price", System.Data.SqlDbType.Int).Value = itemToAdd.Price;
                    command.Parameters.Add("available", System.Data.SqlDbType.Int).Value = itemToAdd.Available;
                    command.Parameters.Add("description", System.Data.SqlDbType.NVarChar).Value = itemToAdd.Description;
                    command.Parameters.Add("binaryvalue", System.Data.SqlDbType.VarBinary).Value = itemToAdd.Image;
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void EditRow(CatalogueItem itemToEdit)
        {
            using (SqlConnection connection = new SqlConnection(GetConecctionString().ConnectionString))
            {
                connection.Open();
                String sql = @"update dbo.Goods set Name = @name, Brand = @brand , Price = @price , Available = @available , Description = @description , Picture = @binaryvalue where Name = @name";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add("name", System.Data.SqlDbType.NVarChar).Value = itemToEdit.Name;
                    command.Parameters.Add("brand", System.Data.SqlDbType.NVarChar).Value = itemToEdit.Brand;
                    command.Parameters.Add("price", System.Data.SqlDbType.Int).Value = itemToEdit.Price;
                    command.Parameters.Add("available", System.Data.SqlDbType.Int).Value = itemToEdit.Available;
                    command.Parameters.Add("description", System.Data.SqlDbType.NVarChar).Value = itemToEdit.Description;
                    command.Parameters.Add("binaryvalue", System.Data.SqlDbType.VarBinary).Value = itemToEdit.Image;
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteRow(CatalogueItem itemToDelete)
        {
            using (SqlConnection connection = new SqlConnection(GetConecctionString().ConnectionString))
            {
                connection.Open();
                String sql = @"delete dbo.Goods where Name = @name";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add("name", System.Data.SqlDbType.NVarChar).Value = itemToDelete.Name;
                    command.ExecuteNonQuery();
                }
            }
        }

        public static List<OrderItem> GetCollectionOrders()
        {
            List<OrderItem> a = new List<OrderItem>();
            using (SqlConnection connection = new SqlConnection(GetConecctionString().ConnectionString))
            {
                connection.Open();
                String sql = @"select CustomerName, DrugName, Adress, PhoneNumber, Count from dbo.Orders join dbo.Customers ON CustomerName = Name where Derived =0;";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            a.Add(new OrderItem(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4)));
                        }
                    }
                }
            }
            return a;
        }

        public static void DeleteOrder(OrderItem item)
        {
            using (SqlConnection connection = new SqlConnection(GetConecctionString().ConnectionString))
            {
                connection.Open();
                String sql = @"update dbo.Orders set Derived = 1 where CustomerName =@name";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add("name", System.Data.SqlDbType.NVarChar).Value = item.CustomerName;
                    command.ExecuteNonQuery();
                }
            }
        }

        public static List<BrandItem> GetBrandCollection()
        {
            List<BrandItem> a = new List<BrandItem>();
            using (SqlConnection connection = new SqlConnection(GetConecctionString().ConnectionString))
            {
                connection.Open();
                String sql = @"select Brand, Country from dbo.OurBrands;";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            a.Add(new BrandItem(reader.GetString(0), reader.GetString(1)));
                        }
                    }
                }
            }
            return a;
        }

        public static void AddBrand(BrandItem itemToAdd)
        {
            using (SqlConnection connection = new SqlConnection(GetConecctionString().ConnectionString))
            {
                connection.Open();
                String sql = @"insert dbo.OurBrands(Brand, Country) values(@name , @country);";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add("name", System.Data.SqlDbType.NVarChar).Value = itemToAdd.Name;
                    command.Parameters.Add("country", System.Data.SqlDbType.NVarChar).Value = itemToAdd.Country;
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteBrand(BrandItem item)
        {
            using (SqlConnection connection = new SqlConnection(GetConecctionString().ConnectionString))
            {
                connection.Open();
                String sql = @"delete dbo.OurBrands where Brand =@name";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add("name", System.Data.SqlDbType.NVarChar).Value = item.Name;
                    command.ExecuteNonQuery();
                }
            }
        }

        public static NSAlert GetError(string toError)
        {
            NSAlert NotValid = new NSAlert();
            NotValid.AlertStyle = NSAlertStyle.Warning;
            NotValid.MessageText = "Ошибка";
            NotValid.InformativeText = toError;
            NotValid.Icon = NSImage.ImageNamed(NSImageName.Caution);
            return NotValid;
        }
        
    }
}
