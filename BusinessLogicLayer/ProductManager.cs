using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class ProductManager
    {
        private readonly ProductDbContext _context;

        // Constructor nhận ApplicationDbContext để làm việc với cơ sở dữ liệu
        public ProductManager(ProductDbContext context)
        {
            _context = context;
        }

        // Phương thức lấy tất cả sản phẩm từ cơ sở dữ liệu
        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList(); // Giả sử có bảng Products trong cơ sở dữ liệu
        }

        // Phương thức thêm sản phẩm mới vào cơ sở dữ liệu
        public void AddProduct(Product product)
        {
            _context.Products.Add(product);   // Thêm sản phẩm vào bảng Products
            _context.SaveChanges();           // Lưu thay đổi vào cơ sở dữ liệu
        }
    }


}
