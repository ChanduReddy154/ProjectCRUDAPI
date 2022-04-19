using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCRUD.Models
{
    public class ProjectDBContext : DbContext
    {
        public ProjectDBContext(DbContextOptions<ProjectDBContext>  options) : base(options)
        {

        }
        public DbSet<Student> Student { get; set; }

        public DbSet<Gender> Gender { get; set; }

        public DbSet<Address> Address { get; set; }
    }
}
