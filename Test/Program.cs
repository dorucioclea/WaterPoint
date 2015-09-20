using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using System.Data.SqlClient;
using System.Web;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("wtf");
            //var d = new Category { Id = 1, Name = "test" };

            //var postData = d.ToDictionary();

            //var nv = HttpUtility.ParseQueryString(string.Empty);

            //foreach (var p in postData)
            //    nv.Add(p.Key, p.Value.ToString());

            //Console.WriteLine(nv.ToString());

            //            var result = Task.Run<Supplier>(() => QueryOneToManyAsync<Product, Supplier>(
            //@"
            //select * from supplier where id = 3
            //select * from product where SupplierId =3
            //", null, (a, b) => { b.Products = a; }));


            //            result.Wait();


            //var lookup = new Dictionary<int, Supplier>();

            //var result = Task.Run<Supplier>(() => QueryAsync<Product, Supplier>(@"select s.*, p.* from supplier s join product p on p.SupplierId = s.id where s.id = 3",
            //    null,
            //    (s, p) =>
            //    {


            //        Supplier supplier;

            //        if(!lookup.TryGetValue(s.Id, out supplier))
            //        {
            //            lookup.Add(s.Id, supplier = s);
            //        }

            //        if (supplier.Products == null)
            //            supplier.Products = new List<Product>();                    

            //        supplier.Products.Add(p);

            //        return supplier;

            //    }));


            //result.Wait();

            //Console.WriteLine(result.Result.Products.Count());

        }


        public static async Task<TReturn> QueryAsync<TNested, TReturn>(string sql, object parameters, Func<TReturn, TNested, TReturn> mapAction)
            where TReturn : class
            where TNested : class
        {
            using (var conn = new SqlConnection("Server=localhost;Database=WaterPoint;User Id=sa;Password=n5bcvK*K;"))
            {
                try
                {
                    await conn.OpenAsync().ConfigureAwait(false);

                    var reader = await conn.QueryAsync<TReturn, TNested, TReturn>(sql, mapAction, null, commandType: CommandType.Text);

                    return reader.FirstOrDefault();

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


        public static async Task<TReturn> QueryOneToManyAsync<TNested, TReturn>(string sql, object parameters, Action<ICollection<TNested>, TReturn> mapAction)
            where TReturn : class
            where TNested : class
        {
            using (var conn = new SqlConnection("Server=localhost;Database=WaterPoint;User Id=sa;Password=n5bcvK*K;"))
            {
                try
                {
                    await conn.OpenAsync().ConfigureAwait(false);

                    using (var reader = await conn.QueryMultipleAsync(sql, parameters, null, null, CommandType.Text))
                    {
                        var result = reader.Read<TReturn>().SingleOrDefault();

                        var nested = reader.Read<TNested>().ToList();

                        mapAction.Invoke(nested, result);

                        return result;
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
            //public ICollection<Product> Products { get; set; }
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
            public ICollection<Category> Categories { get; set; }
        }
    }
}
