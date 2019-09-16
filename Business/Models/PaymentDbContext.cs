using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Business.Models;

namespace Business.Models
{
    public class PaymentDbContext : DbContext
    {
        public PaymentDbContext(DbContextOptions<PaymentDbContext> options) : base(options)
        {
        }

        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Product { get; set; }

        public DbSet<Carts> Carts { get; set; }
       
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<ContactSMS> ContactSMS { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<ProductCategorie> ProductCategorie { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<Business.Models.PaymentDetails> PaymentDetails { get; set; }
      

    }
}
