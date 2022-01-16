using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;
//using System.Data.Entity;
//using System.Data.Entity;

namespace guestbook.Models
{
    public class guestbookContext : DbContext
    {
        public guestbookContext(DbContextOptions<guestbookContext> options) : base(options)
        {

        }
        public virtual DbSet<message> messages { get; set; }
        public virtual DbSet<User> Users { get; set; }


        //protected override void OnModelCreating(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;Database=guest;Trusted_Connection=True;");
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Entity<message>()
        //    //        .HasOptional(c => c.chatId)
        //    //        .WithMany()
        //    //        .HasForeignKey(c => c.SpouseId);
        //    base.OnModelCreating(modelBuilder);
        //}
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // configures one-to-many relationship
        //    modelBuilder.Entity<message>()
        //        .HasRequired<User>(s => s.UserId)
        //        .WithMany(g => g.messages)
        //        .HasForeignKey<int>(s => s.CurrentGradeId);
        //}
    }

}

