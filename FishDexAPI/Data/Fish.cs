namespace FishDex.API.Data
{
    public class Fish(int id, string name, int weight, int length)
    {
        public int Id { get; set; } = id;

        public string Name { get; set; } = name;
        public int Weight { get; set; } = weight;

        public int Length { get; set; }

    }
}
