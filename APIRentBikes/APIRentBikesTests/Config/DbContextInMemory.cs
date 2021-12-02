using APIRentBikesTests.FakeData;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRentBikesTests.Config
{
    public static class DbContextInMemory
    {
        public static ApplicationDbContext Get()
        {
            return new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase($"RentBikesTests.Db").Options);
        }
    }
}
