using System;

namespace FishLog.Models
{
    public class Fish
    {
        public string Id { get; set; }
        public string Species { get; set; }
        public double Weight { get; set; }
        public double Length { get; set; }
        public DateTime DateCaught { get; set; }
        public TimeSpan TimeCaught { get; set; }
        public string Bait { get; set; }
        public int AirTemp { get; set; }
        public int WaterTemp { get; set; }
        public string Location { get; set; }
        public int Depth { get; set; }
    }

}