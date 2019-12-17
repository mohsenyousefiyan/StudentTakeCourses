using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TakeCourses.InfraStructures.DAL.SQL.Context
{
    public class ApplicationQueryDbContext : BaseDbContext
    {
        public ApplicationQueryDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
