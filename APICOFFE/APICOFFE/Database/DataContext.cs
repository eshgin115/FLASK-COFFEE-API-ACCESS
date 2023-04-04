using APICOFFE;
using APICOFFE.Database;
using APICOFFE.Database.Models;
using APICOFFE.Database.Models.Common;
using APICOFFE.Extensions;
using Microsoft.EntityFrameworkCore;

namespace FLASK_COFFEE_API.Database
{
    public partial class DataContext : DbContext
    {
        public DataContext(DbContextOptions options)
             : base(options)
        {

        }
        //public DbSet<Food> Foods { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserActivation> UserActivations { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<BasketProduct> BasketProducts { get; set; }
        //public DbSet<OrderProduct> OrderProducts { get; set; }
        //public DbSet<Order> Orders { get; set; }
        //public DbSet<Contact> Contacts { get; set; }
        public DbSet<WelcomeSlider> WelcomeSliders { get; set; }
        public DbSet<ShortInfo> ShortInfo { get; set; }
        public DbSet<Navbar> Navbars { get; set; }
        public DbSet<Subnavbar> Subnavbars { get; set; }
        //public DbSet<OurHistory> OurHistory { get; set; }
        public DbSet<PaymentBenefits> PaymentBenefits { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }
        //public DbSet<FoodSize> FoodSizes { get; set; }
        //public DbSet<FoodTag> FoodTags { get; set; }
        //public DbSet<Size> Sizes { get; set; }
        //public DbSet<Tag> Tags { get; set; }
        //public DbSet<FoodCategory> FoodCategories { get; set; }
        //public DbSet<FoodImage> FoodImages { get; set; }
        //public DbSet<Drink> Drinks { get; set; }
        //public DbSet<DrinkCategory> DrinkCategories { get; set; }
        //public DbSet<DrinkSize> DrinkSizes { get; set; }
        //public DbSet<DrinkTag> DrinkTags { get; set; }
        public DbSet<DiscoverMenu> DiscoverMenu { get; set; }
        public DbSet<DiscoverMenuImage> DiscoverMenuImages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly<Program>();
        }
    }






    

    #region Auditing

    public partial class DataContext
    {
        public override int SaveChanges()
        {
            AutoAudit();

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            AutoAudit();

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AutoAudit();

            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            AutoAudit();

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        private void AutoAudit()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is not IAuditable auditableEntry) //Short version
                {
                    continue;
                }

                //IAuditable auditableEntry = (IAuditable)entry;

                DateTime currentDate = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    auditableEntry.CreatedAt = currentDate;
                    auditableEntry.UpdatedAt = currentDate;
                }
                else if (entry.State == EntityState.Modified)
                {
                    auditableEntry.UpdatedAt = currentDate;
                }
            }
        }
    }

    #endregion
}
