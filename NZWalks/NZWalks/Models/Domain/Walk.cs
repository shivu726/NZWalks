﻿using System.ComponentModel.DataAnnotations;

namespace NZWalks.Models.Domain
{
    public class Walk
    {
        [Key]
        public int WalkID { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }

        public int RegionID { get; set; }
        public int WalkDifficultyID { get; set; }

        // Navigation property

        public Region Regions { get; set; }
        public WalkDifficulty WalkDifficulties { get; set; }


    }
}
