namespace FishDex.Models
{
    public record Fish
    {
        public required string Name { get; set; }
        //
        //public int Length { get; set; }
        //
        //public int Weight { get; set; }
        //
        //public DateTime TimeCaught { get; set; }
        //
        //public required Location LocationCaught { get; set; }
        //
        //public string? Notes { get; set; }
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
