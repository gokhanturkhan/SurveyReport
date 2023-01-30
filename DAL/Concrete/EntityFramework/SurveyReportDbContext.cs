using ENT.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete.EntityFramework
{
    public class SurveyReportDbContext : DbContext
    {
        public SurveyReportDbContext(DbContextOptions options) : base(options) 
        {}

        public DbSet<User> Users { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Answer> Answers { get; set; }

        public DbSet<FixedAnswer> FixedAnswers { get; set; }
    }
}
