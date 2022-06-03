using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Create_Users_DataGrid.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=UserImage")
        {
        }

        public virtual DbSet<User_Image> User_Image { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User_Image>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User_Image>()
                .Property(e => e.ImageURL)
                .IsUnicode(false);
        }
    }
}
