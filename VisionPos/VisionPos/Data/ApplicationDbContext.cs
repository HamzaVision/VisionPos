using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VisionPos.Models;

namespace VisionPos.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerTypes> CustomerTypes { get; set; }

        public DbSet<tbItems> tbItems { get; set; }
        public DbSet<tbSalesInvoice> tbSalesInvoice { get; set; }
        public DbSet<tbSalesInvoiceItems> tbSalesInvoiceItems { get; set; }
    }
}