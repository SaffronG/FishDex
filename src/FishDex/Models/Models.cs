namespace FishDex.Models
{
    public class Fish
    {
        public Fish(string Name, decimal Length, decimal Weight, Location? LocationCaught = null)
        {
            this.Name = Name;
            this.Length = Length;
            this.Weight = Weight;
            TimeCaught = DateTime.Now;
            if (LocationCaught is null) 
                LocationCaught = new Location { Name = "Unknown" };
            else 
                this.LocationCaught = LocationCaught;
        }
        public string Name { get; set; }
        public decimal Length { get; set; }
        public decimal Weight { get; set; }
        public DateTime TimeCaught { get; set; }
        public Location? LocationCaught { get; set; }
        public string? Notes { get; set; }
    }
    public record Location
    {
        public required string Name { get; set; }
        public string? County { get; set; }
    }
    public record StoredFishPic
    {
        public StoredFishPic(string fileName, string fishAssociation) 
        {
            FileName = fileName;
            FishAssociation = fishAssociation;
            DateAdded = DateTime.Now;
        }

        public string FileName { get; set; }
        public string FishAssociation { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
