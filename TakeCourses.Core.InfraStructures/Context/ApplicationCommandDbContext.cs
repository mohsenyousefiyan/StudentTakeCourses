using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TakeCourses.InfraStructures.DAL.SQL.Context
{
    public class ApplicationCommandDbContext:BaseDbContext
    {       

        public ApplicationCommandDbContext(DbContextOptions options) : base(options)
        {

        }

      
    }
}
