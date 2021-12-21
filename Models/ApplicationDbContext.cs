using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Files.Models;

namespace Files.Models
{
     public class ApplicationDbContext : DbContext
     {

          public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
          {

          }

          public DbSet<Files> files { get; set; }
     }
}