using Microsoft.EntityFrameworkCore;

namespace weatherUploader.Models.Entity
{
    public class WeatherDbContext: DbContext
    {
        public WeatherDbContext(DbContextOptions<WeatherDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<WheatherForecast> WheatherForecast { get; set; }
        public DbSet<WeatherFileInfo> WeatherFileInfo { get; set; }
    }
}
