using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using System.Data.SqlClient;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("wtf");

            var result = Task.Run<Supplier>(() => test());

            result.Wait();

        }

        public static async Task<Supplier> test()
        {
            using (var conn = new SqlConnection("Server=localhost;Database=WaterPoint;User Id=sa;Password=n5bcvK*K;"))
            {
                try
                {
                    await conn.OpenAsync().ConfigureAwait(false);

                    using (var reader = await conn.QueryMultipleAsync(@"
                        select * from supplier where id = 3
                        
                        select * from product where supplierId = 3", null, null, null, CommandType.Text))
                    {
                        var products = reader.Read<Product>().ToList();

                        var category = reader.Read<Category>().ToList();

                        return null;
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public class Category
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public IEnumerable<Product> Products { get; set; }
        }
        public class Supplier
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public ICollection<Product> Products { get; set; }
        }
        public class Product
        {
            public int Id { get; set; }
            public int SupplierId { get; set; }
            public string Name { get; set; }
            public IEnumerable<Category> Categories { get; set; }
        }
    }
}
