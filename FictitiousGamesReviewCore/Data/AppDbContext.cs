using FictitiousGamesReviewCore.Models;
using Microsoft.EntityFrameworkCore;

namespace FictitiousGamesReviewCore.Data
{
    /// <summary>
    /// アプリケーションがDB接続するためのクラス
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }  
    }
}
