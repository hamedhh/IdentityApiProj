using IdentityApiProj.Data.EF.DbContext;
using IdentityApiProj.Data.EF.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    public class CreateDB
    {
        private readonly ApplicationDbContext _dbContext;
        protected const string sqlConnectionString = @"Data Source=localhost;initial Catalog=IdentityApiProjDB;User Id=sa;password=Hh@123456;Trusted_Connection=False;MultipleActiveResultSets=true;";
        protected readonly DbContextOptionsBuilder<ApplicationDbContext> _contextOptionsBuilder;

        public CreateDB()
        {
            _contextOptionsBuilder = CreateSqlDb();

            _dbContext = new ApplicationDbContext(_contextOptionsBuilder.Options);
        }

        protected DbContextOptionsBuilder<ApplicationDbContext> CreateSqlDb()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder

                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
                .UseSqlServer(string.Format(sqlConnectionString, this.GetType().Name));
            return builder;
        }
        public async Task<int> AddAsync(Category category)
        {
            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            return category.id;

        }

        public void Generate()
        {

            using (var context = new ApplicationDbContext(_contextOptionsBuilder.Options))
            {
                context.Users.Add(new User() {
                    Name = "Hamed",
                    ProfileUrl ="admin",
                
                });
                context.SaveChanges();
            }

            //          CreateDB c = new CreateDB();
            //await c.AddAsync(new IdentityApiProj.Data.EF.Model.Category()
            //{
            //    Name = "firstCata",
            //    CreateDate = DateTime.Now,
            //});
        }
    }
}
