using System;
using DataAccessLayer;

namespace TestDbConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing database connection...");

            try
            {
                using (var context = new ProductDbContext())
                {
                    var productCount = context.Products.Count();
                    Console.WriteLine($"Số lượng sản phẩm trong cơ sở dữ liệu: {productCount}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Kết nối thất bại: {ex.Message}");
            }
        }
    }
}
