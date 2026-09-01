using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

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
}
