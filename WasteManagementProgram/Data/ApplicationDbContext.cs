﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WasteManagementProgram.Models;

namespace WasteManagementProgram.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>()
            .HasData(
            new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
              new IdentityRole
              {
                  Name = "Customer",
                  NormalizedName = "CUSTOMER"
              },
                new IdentityRole
                {
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE"
                }
            );
        }
        public DbSet<WasteManagementProgram.Models.Addresses> Addresses { get; set; }
        public DbSet<WasteManagementProgram.Models.Customer> Customer { get; set; }
        public DbSet<WasteManagementProgram.Models.Employee> Employee { get; set; }
        public DbSet<WasteManagementProgram.Models.ServiceInfo> ServiceInfo { get; set; }
        public IEnumerable ServiceInfos { get; internal set; }
    }
}
