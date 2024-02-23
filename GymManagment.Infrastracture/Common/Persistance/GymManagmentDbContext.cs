using GymManagment.Domain.Subscriptions;
using Microsoft.EntityFrameworkCore;

namespace GymManagment.Infrastracture.Common.Persistance;

public class GymManagmentDbContext : DbContext
{
    public DbSet<Subscription> Subscriptions { get; set; } = null!;

    public GymManagmentDbContext(DbContextOptions options) : base(options)
    {
        
    }
}