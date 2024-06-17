using Microsoft.EntityFrameworkCore;
using Summer_Intership_Application.Models;

namespace Summer_Intership_Application.Data
{
    public class DataContext : DbContext 
    {
        public DataContext(DbContextOptions<DataContext> dbContextOptions) : base(dbContextOptions) { }
        public DbSet<DetailInformation> DetailInformations { get; set; }
        public DbSet<AddtionalQuestions> AddtionalQuestions { get; set; }
        public DbSet<Question> Questions { get; set; }
    }
}
