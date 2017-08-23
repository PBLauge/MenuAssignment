using System;
using System.Collections.Generic;
using System.Text;
using MenuAppEntity;
using Microsoft.EntityFrameworkCore;

namespace MenuAppDAL.Context
{
    class InMemoryContext : DbContext
    {
        static DbContextOptions<InMemoryContext> options = 
            new DbContextOptionsBuilder<InMemoryContext>().UseInMemoryDatabase("TheDB").Options;


        public InMemoryContext() : base(options)
        {

        }

        public DbSet<Video> Videos { get; set; }
    }
}
