﻿namespace NZWalks.Models.Domain.DTO
{
    public class RegionModel
    {
        public Guid RegID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Area { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public long Population { get; set; }


    }
}
