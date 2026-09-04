using k8s.KubeConfigModels;
using Microsoft.EntityFrameworkCore;

namespace FishDex.API.Data
{
    public class Fish(int id, string name, int weight, int length)
    {
        public int Id { get; set; } = id;

        public string Name { get; set; } = name;
        public int Weight { get; set; } = weight;

        public int Length { get; set; } = length;

    }

public class FishDbContext(DbContextOptions<FishDbContext> options) : DbContext(options)
    {
        public DbSet<Fish> FishList { get; set; } = null!;

    }
}
