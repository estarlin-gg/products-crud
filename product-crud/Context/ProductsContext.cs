using Microsoft.EntityFrameworkCore;
using product_crud.Models;

namespace product_crud.Context
{
    public class ProductsContext : DbContext
    {
        public ProductsContext(DbContextOptions<ProductsContext> options): base(options) { }



        public DbSet<Product> Products { get; set; }
       
    }
}
