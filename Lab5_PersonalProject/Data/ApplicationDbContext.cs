using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Lab5_PersonalProject.Models;


namespace Lab5_PersonalProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ComputerParts> parts { get; set; }

        public DbSet<SellerInformation> Seller { get; set; }
    }
}
