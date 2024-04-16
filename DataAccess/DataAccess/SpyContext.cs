using Microsoft.EntityFrameworkCore;

namespace pisLab1;

public class SpyContext
{
    public static DbContextOptions<ApplicationContext> Options { get; set; }

    public static void Create()
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            
            pisLab1.Spy spy1 = new pisLab1.Spy {Id = Guid.NewGuid(), FirstName = "John", SecondName = "Doe",Alias = "Pol", DateOfBirth = DateTime.Now, Nationality = "Russian"};;
            pisLab1.Spy spy2 = new pisLab1.Spy {Id = Guid.NewGuid(), FirstName = "Jole", SecondName = "Doe",Alias = "Ron", DateOfBirth = DateTime.Now, Nationality = "Russian"};;
            db.Spies.AddRange(spy1,spy2);

            Mission mission1 = new Mission { Id = Guid.NewGuid(), Name = "Day x", Description = "Random data", SpyId = spy1 };
            Mission mission2 = new Mission { Id = Guid.NewGuid(), Name = "Day r", Description = "Random data", SpyId = spy2 };
            db.Missions.AddRange(mission1,mission2);

            Equipment equipment1 = new Equipment { Id = Guid.NewGuid(), Name = "Pistol", Description = "Random data", SpyId = spy1 };
            Equipment equipment2 = new Equipment { Id = Guid.NewGuid(), Name = "Action Rifle", Description = "Random data", SpyId = spy2 };
            db.Equipments.AddRange(equipment1,equipment2);
            
            db.SaveChanges();
            Console.WriteLine("!!!!");
        }
    }
    
    public class ApplicationContext : DbContext
    {
        public DbSet<Spy> Spies => Set<Spy>();
        public DbSet<Equipment> Equipments => Set<Equipment>();
        public DbSet<Mission> Missions => Set<Mission>();

        public ApplicationContext() : base(Options)
        {
        
        }
   
    }
}