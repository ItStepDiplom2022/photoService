using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoService.DAL
{
    public class PhotoServiceDbContextFactory : IDesignTimeDbContextFactory<PhotoServiceDbContext>
    {
        public PhotoServiceDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PhotoServiceDbContext>();
            optionsBuilder.UseSqlServer("Server=.;Database=PhotoService;Trusted_Connection=True;");

            return new PhotoServiceDbContext(optionsBuilder.Options);
        }
    }
}
