using Microsoft.EntityFrameworkCore;
using product_crud.Domain.Entities;


namespace product_crud.Domain.Context
{
    public class ProductsContext : DbContext
    {
        public ProductsContext(DbContextOptions<ProductsContext> options) : base(options) { }



        public DbSet<Product> Products { get; set; }

    }
}
